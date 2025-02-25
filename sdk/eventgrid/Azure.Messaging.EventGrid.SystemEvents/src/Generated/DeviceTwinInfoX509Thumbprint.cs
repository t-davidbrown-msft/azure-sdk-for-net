// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> The thumbprint is a unique value for the x509 certificate, commonly used to find a particular certificate in a certificate store. The thumbprint is dynamically generated using the SHA1 algorithm, and does not physically exist in the certificate. </summary>
    public partial class DeviceTwinInfoX509Thumbprint
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="DeviceTwinInfoX509Thumbprint"/>. </summary>
        /// <param name="primaryThumbprint"> Primary thumbprint for the x509 certificate. </param>
        /// <param name="secondaryThumbprint"> Secondary thumbprint for the x509 certificate. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="primaryThumbprint"/> or <paramref name="secondaryThumbprint"/> is null. </exception>
        internal DeviceTwinInfoX509Thumbprint(string primaryThumbprint, string secondaryThumbprint)
        {
            Argument.AssertNotNull(primaryThumbprint, nameof(primaryThumbprint));
            Argument.AssertNotNull(secondaryThumbprint, nameof(secondaryThumbprint));

            PrimaryThumbprint = primaryThumbprint;
            SecondaryThumbprint = secondaryThumbprint;
        }

        /// <summary> Initializes a new instance of <see cref="DeviceTwinInfoX509Thumbprint"/>. </summary>
        /// <param name="primaryThumbprint"> Primary thumbprint for the x509 certificate. </param>
        /// <param name="secondaryThumbprint"> Secondary thumbprint for the x509 certificate. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DeviceTwinInfoX509Thumbprint(string primaryThumbprint, string secondaryThumbprint, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            PrimaryThumbprint = primaryThumbprint;
            SecondaryThumbprint = secondaryThumbprint;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="DeviceTwinInfoX509Thumbprint"/> for deserialization. </summary>
        internal DeviceTwinInfoX509Thumbprint()
        {
        }

        /// <summary> Primary thumbprint for the x509 certificate. </summary>
        public string PrimaryThumbprint { get; }
        /// <summary> Secondary thumbprint for the x509 certificate. </summary>
        public string SecondaryThumbprint { get; }
    }
}
