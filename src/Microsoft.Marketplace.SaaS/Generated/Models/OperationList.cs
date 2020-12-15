// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Microsoft.Marketplace.SaaS.Models
{
    /// <summary> The OperationList. </summary>
    public partial class OperationList
    {
        /// <summary> Initializes a new instance of OperationList. </summary>
        internal OperationList()
        {
            Operations = new ChangeTrackingList<Operation>();
        }

        /// <summary> Initializes a new instance of OperationList. </summary>
        /// <param name="operations"> . </param>
        internal OperationList(IReadOnlyList<Operation> operations)
        {
            Operations = operations;
        }

        public IReadOnlyList<Operation> Operations { get; }
    }
}
