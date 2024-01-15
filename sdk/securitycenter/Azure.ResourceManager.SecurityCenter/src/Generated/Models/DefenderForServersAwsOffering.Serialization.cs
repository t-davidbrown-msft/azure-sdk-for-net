// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public partial class DefenderForServersAwsOffering : IUtf8JsonSerializable, IJsonModel<DefenderForServersAwsOffering>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DefenderForServersAwsOffering>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<DefenderForServersAwsOffering>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DefenderForServersAwsOffering>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DefenderForServersAwsOffering)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(DefenderForServers))
            {
                writer.WritePropertyName("defenderForServers"u8);
                writer.WriteObjectValue(DefenderForServers);
            }
            if (Optional.IsDefined(ArcAutoProvisioning))
            {
                writer.WritePropertyName("arcAutoProvisioning"u8);
                writer.WriteObjectValue(ArcAutoProvisioning);
            }
            if (Optional.IsDefined(VaAutoProvisioning))
            {
                writer.WritePropertyName("vaAutoProvisioning"u8);
                writer.WriteObjectValue(VaAutoProvisioning);
            }
            if (Optional.IsDefined(MdeAutoProvisioning))
            {
                writer.WritePropertyName("mdeAutoProvisioning"u8);
                writer.WriteObjectValue(MdeAutoProvisioning);
            }
            if (Optional.IsDefined(SubPlan))
            {
                writer.WritePropertyName("subPlan"u8);
                writer.WriteObjectValue(SubPlan);
            }
            if (Optional.IsDefined(VmScanners))
            {
                writer.WritePropertyName("vmScanners"u8);
                writer.WriteObjectValue(VmScanners);
            }
            writer.WritePropertyName("offeringType"u8);
            writer.WriteStringValue(OfferingType.ToString());
            if (options.Format != "W" && Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
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
            writer.WriteEndObject();
        }

        DefenderForServersAwsOffering IJsonModel<DefenderForServersAwsOffering>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DefenderForServersAwsOffering>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DefenderForServersAwsOffering)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDefenderForServersAwsOffering(document.RootElement, options);
        }

        internal static DefenderForServersAwsOffering DeserializeDefenderForServersAwsOffering(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<AwsDefenderForServersInfo> defenderForServers = default;
            Optional<DefenderForServersAwsOfferingArcAutoProvisioning> arcAutoProvisioning = default;
            Optional<DefenderForServersAwsOfferingVulnerabilityAssessmentAutoProvisioning> vaAutoProvisioning = default;
            Optional<DefenderForServersAwsOfferingMdeAutoProvisioning> mdeAutoProvisioning = default;
            Optional<DefenderForServersAwsOfferingSubPlan> subPlan = default;
            Optional<DefenderForServersAwsOfferingVmScanners> vmScanners = default;
            OfferingType offeringType = default;
            Optional<string> description = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("defenderForServers"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    defenderForServers = AwsDefenderForServersInfo.DeserializeAwsDefenderForServersInfo(property.Value);
                    continue;
                }
                if (property.NameEquals("arcAutoProvisioning"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    arcAutoProvisioning = DefenderForServersAwsOfferingArcAutoProvisioning.DeserializeDefenderForServersAwsOfferingArcAutoProvisioning(property.Value);
                    continue;
                }
                if (property.NameEquals("vaAutoProvisioning"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    vaAutoProvisioning = DefenderForServersAwsOfferingVulnerabilityAssessmentAutoProvisioning.DeserializeDefenderForServersAwsOfferingVulnerabilityAssessmentAutoProvisioning(property.Value);
                    continue;
                }
                if (property.NameEquals("mdeAutoProvisioning"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    mdeAutoProvisioning = DefenderForServersAwsOfferingMdeAutoProvisioning.DeserializeDefenderForServersAwsOfferingMdeAutoProvisioning(property.Value);
                    continue;
                }
                if (property.NameEquals("subPlan"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    subPlan = DefenderForServersAwsOfferingSubPlan.DeserializeDefenderForServersAwsOfferingSubPlan(property.Value);
                    continue;
                }
                if (property.NameEquals("vmScanners"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    vmScanners = DefenderForServersAwsOfferingVmScanners.DeserializeDefenderForServersAwsOfferingVmScanners(property.Value);
                    continue;
                }
                if (property.NameEquals("offeringType"u8))
                {
                    offeringType = new OfferingType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("description"u8))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DefenderForServersAwsOffering(offeringType, description.Value, serializedAdditionalRawData, defenderForServers.Value, arcAutoProvisioning.Value, vaAutoProvisioning.Value, mdeAutoProvisioning.Value, subPlan.Value, vmScanners.Value);
        }

        BinaryData IPersistableModel<DefenderForServersAwsOffering>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DefenderForServersAwsOffering>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(DefenderForServersAwsOffering)} does not support '{options.Format}' format.");
            }
        }

        DefenderForServersAwsOffering IPersistableModel<DefenderForServersAwsOffering>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DefenderForServersAwsOffering>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDefenderForServersAwsOffering(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DefenderForServersAwsOffering)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<DefenderForServersAwsOffering>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
