// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure;
using Azure.Core;

namespace MgmtTypeSpec
{
    /// <summary></summary>
    public partial class PrivateLinks
    {
        private static ResponseClassifier _pipelineMessageClassifier200;
        private static ResponseClassifier _pipelineMessageClassifier200202;

        private static ResponseClassifier PipelineMessageClassifier200 => _pipelineMessageClassifier200 = new StatusCodeClassifier(stackalloc ushort[] { 200 });

        private static ResponseClassifier PipelineMessageClassifier200202 => _pipelineMessageClassifier200202 = new StatusCodeClassifier(stackalloc ushort[] { 200, 202 });

        internal HttpMessage CreateGetAllPrivateLinkResourcesRequest(Guid subscriptionId, string resourceGroupName, RequestContext context)
        {
            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier200);
            Request request = message.Request;
            request.Method = RequestMethod.Get;
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId.ToString(), true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/MgmtTypeSpec/privateLinkResources", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.SetValue("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateStartRequest(Guid subscriptionId, string resourceGroupName, string privateLinkResourceName, RequestContent content, RequestContext context)
        {
            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier200202);
            Request request = message.Request;
            request.Method = RequestMethod.Post;
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId.ToString(), true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/MgmtTypeSpec/privateLinkResources/", false);
            uri.AppendPath(privateLinkResourceName, true);
            uri.AppendPath("/start", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.SetValue("Content-Type", "application/json");
            request.Headers.SetValue("Accept", "application/json");
            request.Content = content;
            return message;
        }
    }
}
