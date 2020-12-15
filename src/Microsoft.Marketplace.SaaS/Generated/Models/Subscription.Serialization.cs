// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Microsoft.Marketplace.SaaS.Models
{
    public partial class Subscription
    {
        internal static Subscription DeserializeSubscription(JsonElement element)
        {
            Optional<Guid> id = default;
            Optional<string> publisherId = default;
            Optional<string> offerId = default;
            Optional<string> name = default;
            Optional<SubscriptionStatusEnum> saasSubscriptionStatus = default;
            Optional<AadIdentifier> beneficiary = default;
            Optional<AadIdentifier> purchaser = default;
            Optional<string> planId = default;
            Optional<int> quantity = default;
            Optional<SubscriptionTerm> term = default;
            Optional<bool> isTest = default;
            Optional<bool> isFreeTrial = default;
            Optional<IReadOnlyList<AllowedCustomerOperationsEnum>> allowedCustomerOperations = default;
            Optional<Guid> sessionId = default;
            Optional<Guid> fulfillmentId = default;
            Optional<string> storeFront = default;
            Optional<SessionModeEnum> sessionMode = default;
            Optional<SandboxTypeEnum> sandboxType = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    id = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("publisherId"))
                {
                    publisherId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("offerId"))
                {
                    offerId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("saasSubscriptionStatus"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    saasSubscriptionStatus = property.Value.GetString().ToSubscriptionStatusEnum();
                    continue;
                }
                if (property.NameEquals("beneficiary"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    beneficiary = AadIdentifier.DeserializeAadIdentifier(property.Value);
                    continue;
                }
                if (property.NameEquals("purchaser"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    purchaser = AadIdentifier.DeserializeAadIdentifier(property.Value);
                    continue;
                }
                if (property.NameEquals("planId"))
                {
                    planId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("quantity"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    quantity = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("term"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    term = SubscriptionTerm.DeserializeSubscriptionTerm(property.Value);
                    continue;
                }
                if (property.NameEquals("isTest"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    isTest = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("isFreeTrial"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    isFreeTrial = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("allowedCustomerOperations"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<AllowedCustomerOperationsEnum> array = new List<AllowedCustomerOperationsEnum>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString().ToAllowedCustomerOperationsEnum());
                    }
                    allowedCustomerOperations = array;
                    continue;
                }
                if (property.NameEquals("sessionId"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    sessionId = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("fulfillmentId"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    fulfillmentId = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("storeFront"))
                {
                    storeFront = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sessionMode"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    sessionMode = property.Value.GetString().ToSessionModeEnum();
                    continue;
                }
                if (property.NameEquals("sandboxType"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    sandboxType = property.Value.GetString().ToSandboxTypeEnum();
                    continue;
                }
            }
            return new Subscription(Optional.ToNullable(id), publisherId.Value, offerId.Value, name.Value, Optional.ToNullable(saasSubscriptionStatus), beneficiary.Value, purchaser.Value, planId.Value, Optional.ToNullable(quantity), term.Value, Optional.ToNullable(isTest), Optional.ToNullable(isFreeTrial), Optional.ToList(allowedCustomerOperations), Optional.ToNullable(sessionId), Optional.ToNullable(fulfillmentId), storeFront.Value, Optional.ToNullable(sessionMode), Optional.ToNullable(sandboxType));
        }
    }
}
