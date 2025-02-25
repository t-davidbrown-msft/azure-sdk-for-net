// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class HealthcareFhirResourceUpdatedEventData : IUtf8JsonSerializable, IJsonModel<HealthcareFhirResourceUpdatedEventData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<HealthcareFhirResourceUpdatedEventData>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<HealthcareFhirResourceUpdatedEventData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<HealthcareFhirResourceUpdatedEventData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(HealthcareFhirResourceUpdatedEventData)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(FhirResourceType))
            {
                writer.WritePropertyName("resourceType"u8);
                writer.WriteStringValue(FhirResourceType.Value.ToString());
            }
            writer.WritePropertyName("resourceFhirAccount"u8);
            writer.WriteStringValue(FhirServiceHostName);
            writer.WritePropertyName("resourceFhirId"u8);
            writer.WriteStringValue(FhirResourceId);
            if (Optional.IsDefined(FhirResourceVersionId))
            {
                writer.WritePropertyName("resourceVersionId"u8);
                writer.WriteNumberValue(FhirResourceVersionId.Value);
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        HealthcareFhirResourceUpdatedEventData IJsonModel<HealthcareFhirResourceUpdatedEventData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<HealthcareFhirResourceUpdatedEventData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(HealthcareFhirResourceUpdatedEventData)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeHealthcareFhirResourceUpdatedEventData(document.RootElement, options);
        }

        internal static HealthcareFhirResourceUpdatedEventData DeserializeHealthcareFhirResourceUpdatedEventData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            HealthcareFhirResourceType? resourceType = default;
            string resourceFhirAccount = default;
            string resourceFhirId = default;
            long? resourceVersionId = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("resourceType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    resourceType = new HealthcareFhirResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("resourceFhirAccount"u8))
                {
                    resourceFhirAccount = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("resourceFhirId"u8))
                {
                    resourceFhirId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("resourceVersionId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    resourceVersionId = property.Value.GetInt64();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new HealthcareFhirResourceUpdatedEventData(resourceType, resourceFhirAccount, resourceFhirId, resourceVersionId, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<HealthcareFhirResourceUpdatedEventData>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<HealthcareFhirResourceUpdatedEventData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(HealthcareFhirResourceUpdatedEventData)} does not support writing '{options.Format}' format.");
            }
        }

        HealthcareFhirResourceUpdatedEventData IPersistableModel<HealthcareFhirResourceUpdatedEventData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<HealthcareFhirResourceUpdatedEventData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeHealthcareFhirResourceUpdatedEventData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(HealthcareFhirResourceUpdatedEventData)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<HealthcareFhirResourceUpdatedEventData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static HealthcareFhirResourceUpdatedEventData FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeHealthcareFhirResourceUpdatedEventData(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
