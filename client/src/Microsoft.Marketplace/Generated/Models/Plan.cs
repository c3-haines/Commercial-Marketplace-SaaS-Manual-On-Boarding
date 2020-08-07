// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Marketplace.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Plan
    {
        /// <summary>
        /// Initializes a new instance of the Plan class.
        /// </summary>
        public Plan()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Plan class.
        /// </summary>
        public Plan(string planId = default(string), string displayName = default(string), bool? isPrivate = default(bool?))
        {
            PlanId = planId;
            DisplayName = displayName;
            IsPrivate = isPrivate;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "planId")]
        public string PlanId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isPrivate")]
        public bool? IsPrivate { get; set; }

    }
}
