// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Message Interactive Content. </summary>
    public partial class AcsMessageInteractiveContent
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

        /// <summary> Initializes a new instance of <see cref="AcsMessageInteractiveContent"/>. </summary>
        internal AcsMessageInteractiveContent()
        {
        }

        /// <summary> Initializes a new instance of <see cref="AcsMessageInteractiveContent"/>. </summary>
        /// <param name="replyKind"> The Message interactive reply type. </param>
        /// <param name="buttonReply"> The Message Sent when a customer clicks a button. </param>
        /// <param name="listReply"> The Message Sent when a customer selects an item from a list. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal AcsMessageInteractiveContent(AcsInteractiveReplyKind? replyKind, AcsMessageInteractiveButtonReplyContent buttonReply, AcsMessageInteractiveListReplyContent listReply, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ReplyKind = replyKind;
            ButtonReply = buttonReply;
            ListReply = listReply;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The Message interactive reply type. </summary>
        public AcsInteractiveReplyKind? ReplyKind { get; }
        /// <summary> The Message Sent when a customer clicks a button. </summary>
        public AcsMessageInteractiveButtonReplyContent ButtonReply { get; }
        /// <summary> The Message Sent when a customer selects an item from a list. </summary>
        public AcsMessageInteractiveListReplyContent ListReply { get; }
    }
}
