// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.NetApp.Samples
{
    public partial class Sample_SubscriptionResourceExtensions
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task CheckNetAppNameAvailability_CheckNameAvailability()
        {
            // Generated from example definition: specification/netapp/resource-manager/Microsoft.NetApp/stable/2024-09-01/examples/CheckNameAvailability.json
            // this example is just showing the usage of "NetAppResource_CheckNameAvailability" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "D633CC2E-722B-4AE1-B636-BBD9E4C60ED9";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the operation
            AzureLocation location = new AzureLocation("eastus");
            NetAppNameAvailabilityContent content = new NetAppNameAvailabilityContent("accName", NetAppNameAvailabilityResourceType.MicrosoftNetAppNetAppAccounts, "myRG");
            NetAppCheckAvailabilityResult result = await subscriptionResource.CheckNetAppNameAvailabilityAsync(location, content);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task CheckNetAppFilePathAvailability_CheckFilePathAvailability()
        {
            // Generated from example definition: specification/netapp/resource-manager/Microsoft.NetApp/stable/2024-09-01/examples/CheckFilePathAvailability.json
            // this example is just showing the usage of "NetAppResource_CheckFilePathAvailability" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "D633CC2E-722B-4AE1-B636-BBD9E4C60ED9";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the operation
            AzureLocation location = new AzureLocation("eastus");
            NetAppFilePathAvailabilityContent content = new NetAppFilePathAvailabilityContent("my-exact-filepth", new ResourceIdentifier("/subscriptions/9760acf5-4638-11e7-9bdb-020073ca7778/resourceGroups/myRP/providers/Microsoft.Network/virtualNetworks/testvnet3/subnets/testsubnet3"));
            NetAppCheckAvailabilityResult result = await subscriptionResource.CheckNetAppFilePathAvailabilityAsync(location, content);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task CheckNetAppQuotaAvailability_CheckQuotaAvailability()
        {
            // Generated from example definition: specification/netapp/resource-manager/Microsoft.NetApp/stable/2024-09-01/examples/CheckQuotaAvailability.json
            // this example is just showing the usage of "NetAppResource_CheckQuotaAvailability" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "D633CC2E-722B-4AE1-B636-BBD9E4C60ED9";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the operation
            AzureLocation location = new AzureLocation("eastus");
            NetAppQuotaAvailabilityContent content = new NetAppQuotaAvailabilityContent("resource1", NetAppQuotaAvailabilityResourceType.MicrosoftNetAppNetAppAccounts, "myRG");
            NetAppCheckAvailabilityResult result = await subscriptionResource.CheckNetAppQuotaAvailabilityAsync(location, content);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task QueryRegionInfoNetAppResource_RegionInfoQuery()
        {
            // Generated from example definition: specification/netapp/resource-manager/Microsoft.NetApp/stable/2024-09-01/examples/RegionInfo.json
            // this example is just showing the usage of "NetAppResource_QueryRegionInfo" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "D633CC2E-722B-4AE1-B636-BBD9E4C60ED9";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the operation
            AzureLocation location = new AzureLocation("eastus");
            NetAppRegionInfo result = await subscriptionResource.QueryRegionInfoNetAppResourceAsync(location);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task QueryNetworkSiblingSetNetAppResource_NetworkSiblingSetQuery()
        {
            // Generated from example definition: specification/netapp/resource-manager/Microsoft.NetApp/stable/2024-09-01/examples/NetworkSiblingSet_Query.json
            // this example is just showing the usage of "NetAppResource_QueryNetworkSiblingSet" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "D633CC2E-722B-4AE1-B636-BBD9E4C60ED9";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the operation
            AzureLocation location = new AzureLocation("eastus");
            QueryNetworkSiblingSetContent content = new QueryNetworkSiblingSetContent("9760acf5-4638-11e7-9bdb-020073ca3333", new ResourceIdentifier("/subscriptions/9760acf5-4638-11e7-9bdb-020073ca7778/resourceGroups/myRP/providers/Microsoft.Network/virtualNetworks/testVnet/subnets/testSubnet"));
            NetworkSiblingSet result = await subscriptionResource.QueryNetworkSiblingSetNetAppResourceAsync(location, content);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task UpdateNetworkSiblingSetNetAppResource_NetworkFeaturesUpdate()
        {
            // Generated from example definition: specification/netapp/resource-manager/Microsoft.NetApp/stable/2024-09-01/examples/NetworkSiblingSet_Update.json
            // this example is just showing the usage of "NetAppResource_UpdateNetworkSiblingSet" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "D633CC2E-722B-4AE1-B636-BBD9E4C60ED9";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the operation
            AzureLocation location = new AzureLocation("eastus");
            UpdateNetworkSiblingSetContent content = new UpdateNetworkSiblingSetContent("9760acf5-4638-11e7-9bdb-020073ca3333", new ResourceIdentifier("/subscriptions/9760acf5-4638-11e7-9bdb-020073ca7778/resourceGroups/myRP/providers/Microsoft.Network/virtualNetworks/testVnet/subnets/testSubnet"), "12345_44420.8001578125", NetAppNetworkFeature.Standard);
            ArmOperation<NetworkSiblingSet> lro = await subscriptionResource.UpdateNetworkSiblingSetNetAppResourceAsync(WaitUntil.Completed, location, content);
            NetworkSiblingSet result = lro.Value;

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetNetAppQuotaLimits_QuotaLimits()
        {
            // Generated from example definition: specification/netapp/resource-manager/Microsoft.NetApp/stable/2024-09-01/examples/QuotaLimits_List.json
            // this example is just showing the usage of "NetAppResourceQuotaLimits_List" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "D633CC2E-722B-4AE1-B636-BBD9E4C60ED9";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the operation and iterate over the result
            AzureLocation location = new AzureLocation("eastus");
            await foreach (NetAppSubscriptionQuotaItem item in subscriptionResource.GetNetAppQuotaLimitsAsync(location))
            {
                Console.WriteLine($"Succeeded: {item}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetNetAppQuotaLimit_QuotaLimits()
        {
            // Generated from example definition: specification/netapp/resource-manager/Microsoft.NetApp/stable/2024-09-01/examples/QuotaLimits_Get.json
            // this example is just showing the usage of "NetAppResourceQuotaLimits_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "D633CC2E-722B-4AE1-B636-BBD9E4C60ED9";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the operation
            AzureLocation location = new AzureLocation("eastus");
            string quotaLimitName = "totalCoolAccessVolumesPerSubscription";
            NetAppSubscriptionQuotaItem result = await subscriptionResource.GetNetAppQuotaLimitAsync(location, quotaLimitName);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetNetAppAccounts_AccountsList()
        {
            // Generated from example definition: specification/netapp/resource-manager/Microsoft.NetApp/stable/2024-09-01/examples/Accounts_List.json
            // this example is just showing the usage of "Accounts_ListBySubscription" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "D633CC2E-722B-4AE1-B636-BBD9E4C60ED9";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the operation and iterate over the result
            await foreach (NetAppAccountResource item in subscriptionResource.GetNetAppAccountsAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                NetAppAccountData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine("Succeeded");
        }
    }
}
