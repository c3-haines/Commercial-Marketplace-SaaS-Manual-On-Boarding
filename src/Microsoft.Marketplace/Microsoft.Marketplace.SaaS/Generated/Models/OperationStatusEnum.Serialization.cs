// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Microsoft.Marketplace.SaaS.Models
{
    internal static class OperationStatusEnumExtensions
    {
        public static string ToSerialString(this OperationStatusEnum value) => value switch
        {
            OperationStatusEnum.NotStarted => "NotStarted",
            OperationStatusEnum.InProgress => "InProgress",
            OperationStatusEnum.Succeeded => "Succeeded",
            OperationStatusEnum.Failed => "Failed",
            OperationStatusEnum.Conflict => "Conflict",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown OperationStatusEnum value.")
        };

        public static OperationStatusEnum ToOperationStatusEnum(this string value)
        {
            if (string.Equals(value, "NotStarted", StringComparison.InvariantCultureIgnoreCase)) return OperationStatusEnum.NotStarted;
            if (string.Equals(value, "InProgress", StringComparison.InvariantCultureIgnoreCase)) return OperationStatusEnum.InProgress;
            if (string.Equals(value, "Succeeded", StringComparison.InvariantCultureIgnoreCase)) return OperationStatusEnum.Succeeded;
            if (string.Equals(value, "Failed", StringComparison.InvariantCultureIgnoreCase)) return OperationStatusEnum.Failed;
            if (string.Equals(value, "Conflict", StringComparison.InvariantCultureIgnoreCase)) return OperationStatusEnum.Conflict;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown OperationStatusEnum value.");
        }
    }
}
