// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#pragma warning disable SA1200 // Using directives should be placed correctly
using Azure.Core;
#pragma warning restore SA1200 // Using directives should be placed correctly
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Marketplace.SaaS;
using Microsoft.Marketplace.SaaS.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.Marketplace.Tests
{

    [TestFixture]
    public class FulfillmentTests : RecordedTestBase
    {
        private IConfigurationRoot config;

        // Changed to record when client code is generated first time manually.
        public FulfillmentTests() : base(true, RecordedTestMode.Record)
        {
            this.config = new ConfigurationBuilder()
                .AddUserSecrets<FulfillmentTests>()
                .AddEnvironmentVariables()
                .Build();
        }

        [RecordedTest]
        public async Task GetAllSubscriptionsAsListAsync()
        {
            var sut = InstrumentClient(GetMarketplaceSaaSClient());
            var subscriptions = await sut.Fulfillment.ListSubscriptionsAsync().ToListAsync();

            Debug.Print($"Received {subscriptions} subscriptions");
            Debug.Print($"Received {subscriptions.Select(s => s.Id).Distinct().ToList().Count} distinct subscriptions");

            NUnit.Framework.Assert.IsTrue(subscriptions.Any());
        }

        [RecordedTest]
        public async Task GetSubscription()
        {
            var sut = InstrumentClient(GetMarketplaceSaaSClient());
            var subscriptions = await sut.Fulfillment.ListSubscriptionsAsync().ToListAsync();
            Assert.IsTrue(subscriptions.Any());

            var subscription = subscriptions.First();

            var result = await sut.Fulfillment.GetSubscriptionAsync(subscription.Id.Value);

            Assert.IsNotNull(result);
        }

        [RecordedTest]
        public async Task GetAllSubscriptionsPaged()
        {
            var sut = InstrumentClient(GetMarketplaceSaaSClient());

            var subscriptions = new List<Subscription>();

            string continuationToken = null;
            await foreach (var subscriptionPage in sut.Fulfillment.ListSubscriptionsAsync(continuationToken).AsPages())
            {
                subscriptions.AddRange(subscriptionPage.Values);
                continuationToken = subscriptionPage.ContinuationToken;
            }

            Debug.Print($"Received {subscriptions} subscriptions");
            Debug.Print($"Received {subscriptions.Select(s => s.Id).Distinct().ToList().Count} distinct subscriptions");

            Assert.IsTrue(subscriptions.Any());
        }

        [RecordedTest]
        //[Ignore("Only use with a new marketplace token and record!")]
        public async Task ResolveSubscription()
        {
            var sut = InstrumentClient(GetMarketplaceSaaSClient());

            // This needs to be run manually after receiving a marketplace token on the landing page, and adding here.
            // Don't forget to urldecode if you are copying from the url param
            var marketplaceToken = "keS9yHatHjwwhsFx+qRXxKI9m2R8YyXGLA9GEvFbJbRWJGe6h6ClisIDoH1lquD+9XLjDXdHZ5aPbS/Rp5b5OujPhdYycjt+2RDhXQZ4oqLyflCGAno3+JGUUZnTIi5rn63gQ+uqHq9DgUSiAj5H9nsp03p9BcqxMrsctDeYbTfNau85EWD11Owlh4/RgNJ2l07uxxGv6D0yfnSh82sChlgXOFfz2ETS/ewZNevfxgw=";
            var resolvedSubscription = await sut.Fulfillment.ResolveAsync(marketplaceToken);

            Debug.Print(resolvedSubscription.Value.SubscriptionName);
            Assert.IsNotNull(resolvedSubscription);
        }

        [RecordedTest]
        public async Task UpdateSubscription()
        {
            var sut = InstrumentClient(GetMarketplaceSaaSClient());

            var subscriptions = await sut.Fulfillment.ListSubscriptionsAsync().ToListAsync();
            Assert.IsTrue(subscriptions.Any());

            var firstActiveSubscription = subscriptions.First(s => s.SaasSubscriptionStatus.Value == SubscriptionStatusEnum.Subscribed);

            var plan = firstActiveSubscription.PlanId == "silver" ? "gold" : "silver";

            var result = await sut.Fulfillment.UpdateSubscriptionAsync(firstActiveSubscription.Id.Value, new SubscriberPlan() { PlanId = plan });

            // Cannot check whether this succeeed or not.
            var operationId = Guid.TryParse(result, out var value) ? value : Guid.Empty;

            var operation = await sut.SubscriptionOperations.GetOperationStatusAsync(firstActiveSubscription.Id.Value, operationId);

            Assert.IsNotNull(operation);

            Debug.Print(Enum.GetName(typeof(OperationStatusEnum), operation.Value.Status));
        }

        private MarketplaceSaaSClient GetMarketplaceSaaSClient()
        {
            return new MarketplaceSaaSClient(new ClientSecretCredential(config["TenantId"], config["ClientId"], config["clientSecret"]), this.GetOptions());
        }

        private MarketplaceSaaSClientOptions GetOptions()
        {
            var options = new MarketplaceSaaSClientOptions()
            {
                Diagnostics = { IsLoggingEnabled = true },
                Retry =
                {
                    Mode = RetryMode.Exponential,
                    MaxRetries = 10,
                    Delay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.01 : 1),
                    MaxDelay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.1 : 60),
                    NetworkTimeout = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 100 : 400),
                },
                Transport = new HttpClientTransport(
                new HttpClient()
                {
                    Timeout = TimeSpan.FromSeconds(1000)
                })
            };
            if (Mode != RecordedTestMode.Live)
            {
                options.AddPolicy(new RecordedClientRequestIdPolicy(this.Recording, false), HttpPipelinePosition.PerCall);
            }

            return InstrumentClientOptions(options);
        }
    }
}
