﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// CPU usage is a measure of how much processing power a process is using over a period of time. To calculate this,
    /// you need to know how much CPU time the process has consumed during a specific interval.
    ///
    /// In order to perform a cpu monitor without requiring large
    /// amounts of permissions from the user, we can do a pseudo monitor
    /// where with poll the CPU to see how it does with a simple wait task.
    ///
    /// Loosely adapted from (using the concepts): https://mattwarren.org/2014/06/18/measuring-the-impact-of-the-net-garbage-collector/
    ///
    /// TODO: consider using System.Diagnostics.PerformanceCounter to keep track
    /// of the performance however it takes elevated permissions. We may consider
    /// using that instead if the application has elevated permissions.
    ///
    /// A lot of computations were taken from the azcopy cpuMonitor
    /// </summary>
    internal class CpuMonitor
    {
        private Task _monitoringWorker;
        private readonly TimeSpan _monitoringInterval;
        private CancellationTokenSource _cancellationTokenSource;

        public float CpuUsage { get; private set; }

        public bool IsRunning { get; private set; }

        /// <summary>
        /// CPUContentionExists returns true if demand for CPU capacity is affecting
        /// the ability of our GoRoutines to run when they want to run
        /// </summary>

        public bool ContentionExists { get; private set; }

        // TODO: Need to check whether there is a symbol for Testing already
//#if TESTING
//        public FrameworkInfo FrameworkInfo { get; set; }
//#else
//        public FrameworkInfo Framework { get; private set; }
//#endif

        /// <summary>
        /// Initalizes the CPU monitor.
        ///
        /// This should be called early on in the job transfers.
        /// </summary>
        public CpuMonitor()
        {
        }

        public CpuMonitor(TimeSpan monitoringInterval)
        {
            _monitoringInterval = monitoringInterval;
        }

        /// <summary>
        /// Does the computations to determine if the CPU is a contention in why things are slow.
        ///
        /// Each tick is equal to 100 nanoseconds
        /// TODO: when upgrade to .NET 7 comes, we can use the TimeSpan.Nanoseconds
        ///
        /// TODO: remove magic numbers
        /// </summary>
        internal async Task CalibrateComputation(CancellationToken cancellationToken)
        {
            bool oldIsSlow = false;

            Channel<TimeSpan> durations = Channel.CreateBounded<TimeSpan>(1000);

            // TODO: remove size once the Channels.Count feature comes out.
            int valuesInWindowCount = 0;
            Channel<bool> valuesInWindow = Channel.CreateBounded<bool>(100);

            int rollingCount = 0;
            // sleep for this long each time we probe for busy-ness of CPU
            TimeSpan waitTime = TimeSpan.FromMilliseconds(333);

            // keep track of this many recent samples
            long windowSize = Convert.ToInt64(TimeSpan.FromSeconds(5).TotalMilliseconds / waitTime.TotalMilliseconds);

            // a sample is considered slow if its this many times greater than the baseline (or more)
            float thresholdMultiplier = 50;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // testing indicates we need a lower threshold here, but not on Linux (since the lower number gives too many false alarms there)
                thresholdMultiplier = 10;
            }

            // run a separate loop to do the probes/measurements
            _monitoringWorker = MonitoringWorker(waitTime, durations, cancellationToken);
            _monitoringWorker.Start();

            // discard first value, it doesn't seem very reliable
            await durations.Reader.ReadAsync(cancellationToken).ConfigureAwait(false);

            // get the next 3 and average them, as our baseline. We chose 3 somewhat arbitrarily
            long firstSpan = 0;// get next duration.
            long secondSpan = 0;
            long thirdSpan = 0;

            float baselineAverageNs = (firstSpan + secondSpan + thirdSpan) / 3;

            //close(calibrationDone)

            // loop and monitor
            while (!cancellationToken.IsCancellationRequested)
            {
                while (await durations.Reader.WaitToReadAsync(cancellationToken).ConfigureAwait(false))
                {
                    TimeSpan duration = await durations.Reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                    // it took us over x times longer than normal to wake from sleep
                    bool latestWasSlow = (duration.Ticks * 100) > thresholdMultiplier * baselineAverageNs;

                    // maintain count of slow ones in the last "windowSize" intervals
                    valuesInWindowCount++;
                    await valuesInWindow.Writer.WriteAsync(latestWasSlow, cancellationToken).ConfigureAwait(false);

                    if (latestWasSlow)
                    {
                        rollingCount++;
                    }
                    else if (valuesInWindowCount > windowSize)
                    {
                        bool oldWasSlow = await valuesInWindow.Reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                        if (oldWasSlow)
                        {
                            rollingCount--;
                        }
                    }

                    // If lots of our recent samples passed the threshold for "slow", then assume that we are indeed generally slow
                    bool isGenerallySlow = rollingCount >= (windowSize / 2);
                    if (isGenerallySlow != oldIsSlow)
                    {
                        ContentionExists = true;
                    }
                }
            }
        }

        public void StartMonitoring()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            Task.Run(() => MonitorCpuUsage(_cancellationTokenSource.Token));
        }

        public void StopMonitoring()
        {
            _cancellationTokenSource?.Cancel();
        }

        private static async Task MonitoringWorker(
            TimeSpan waitTime,
            ChannelWriter<TimeSpan> durationWriter,
            CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                DateTimeOffset start = DateTimeOffset.UtcNow;

                Thread.Sleep(waitTime);

                DateTimeOffset endTime = DateTimeOffset.UtcNow;

                // how much longer than expected did it take for us to wake up?
                // This is assumed to be time in which we were ready to run, but we couldn't run, because something else was busy on the
                // CPU.
                TimeSpan diffFromStart = endTime.Subtract(start);
                TimeSpan excessTime = diffFromStart.Subtract(waitTime);

                await durationWriter.WriteAsync(excessTime, cancellationToken).ConfigureAwait(false);
            }
        }

        private async Task MonitorCpuUsage(CancellationToken cancellationToken)
        {
            // Use processor directives here instead
            // Oldest version we support is .NET Standard 2.0

            //#if NET6_0_OR_GREATER
            //    await MonitorCpuUsageNet6Plus(cancellationToken).ConfigureAwait(false);
            //#elif NETCOREAPP3_0_OR_GREATER
            //    await MonitorCpuUsageNetCore3(cancellationToken).ConfigureAwait(false);
            //#else
            //    await MonitorCpuUsageLegacy(cancellationToken).ConfigureAwait(false);
            //#endif
            await MonitorCpuUsageLegacy(cancellationToken).ConfigureAwait(false);
        }

        private async Task MonitorCpuUsageNet6Plus(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // Implement the actual code from this:
                // https://learn.microsoft.com/en-us/dotnet/core/diagnostics/diagnostic-resource-monitoring
                await Task.Delay(1000, cancellationToken).ConfigureAwait(false);
            }
        }

        private async Task MonitorCpuUsageNetCore3(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // It looks like we might be able to use this for 3.1Plus https://learn.microsoft.com/en-us/dotnet/core/diagnostics/event-counter-perf
                await Task.Delay(1000, cancellationToken).ConfigureAwait(false);
            }
        }

        private async Task MonitorCpuUsageLegacy(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // using process would work on all old and new frameworks
                // https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.process.getcurrentprocess?view=net-9.0#system-diagnostics-process-getcurrentprocess
                // This also has a GetAllProcesses() method

                var currentProcess = GetCurrentProcess();
                currentProcess.Refresh();
                CpuUsage = NormalizeProcessingTime(currentProcess, _monitoringInterval);
                await Task.Delay(_monitoringInterval, cancellationToken).ConfigureAwait(false);
            }
        }

        private static float NormalizeProcessingTime(Process currentProcess, TimeSpan monitoringInterval)
        {
            // CPU Usage = (CPU Time Used / (Time Elapsed * Number of Cores)) * 100
            // Process.TotalProcessorTime.TotlMilliseconds returns the processing time across all processors
            // Environment.ProcessorCount returns then total number of cores (which includes physical cores plus hyper
            // threaded cores
            return (float)(currentProcess.TotalProcessorTime.TotalMilliseconds / (monitoringInterval.TotalMilliseconds * GetCoreCount()));
        }

        private static int GetCoreCount()
        {
            return Environment.ProcessorCount;
        }

        //private FrameworkInfo GetFrameworkVersion()
        //{
        //    //return Environment.Version;
        //    var frameworkInfo = new FrameworkInfo();
        //    frameworkInfo.Type = RuntimeInformation.FrameworkDescription;
        //    frameworkInfo.Version = Environment.Version;

        //    return frameworkInfo;
        //}

        private Process GetCurrentProcess()
        {
            return Process.GetCurrentProcess();
        }

        private Process[] GetAllProcesses()
        {
            return Process.GetProcesses();
        }

        //internal class FrameworkInfo
        //{
        //    public string Type { get; set; }
        //    public Version Version { get; set; }

        //    public FrameworkInfo()
        //    {
        //        string frameworkDescription = RuntimeInformation.FrameworkDescription;
        //        string frameworkName = ExtractFrameworkName(frameworkDescription);

        //        Type = frameworkName;
        //        Version = Environment.Version;
        //    }

        //    private static string ExtractFrameworkName(string frameworkDescription)
        //    {
        //        if (frameworkDescription.StartsWith(".NET Framework"))
        //        {
        //            return ".NET Framework";
        //        }
        //        else if (frameworkDescription.StartsWith(".NET Core"))
        //        {
        //            return ".NET Core";
        //        }
        //        else if (frameworkDescription.StartsWith(".NET"))
        //        {
        //            return ".NET";
        //        }
        //        else
        //        {
        //            return "Unknown Framework";
        //        }
        //    }
        //}
    }
}
