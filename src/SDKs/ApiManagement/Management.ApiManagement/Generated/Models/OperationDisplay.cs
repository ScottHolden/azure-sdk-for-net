// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.ApiManagement.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.ApiManagement;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The object that describes the operation.
    /// </summary>
    public partial class OperationDisplay
    {
        /// <summary>
        /// Initializes a new instance of the OperationDisplay class.
        /// </summary>
        public OperationDisplay()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the OperationDisplay class.
        /// </summary>
        /// <param name="provider">Friendly name of the resource
        /// provider</param>
        /// <param name="operation">Operation type: read, write, delete,
        /// listKeys/action, etc.</param>
        /// <param name="resource">Resource type on which the operation is
        /// performed.</param>
        /// <param name="description">Friendly name of the operation</param>
        public OperationDisplay(string provider = default(string), string operation = default(string), string resource = default(string), string description = default(string))
        {
            Provider = provider;
            Operation = operation;
            Resource = resource;
            Description = description;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets friendly name of the resource provider
        /// </summary>
        [JsonProperty(PropertyName = "provider")]
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets operation type: read, write, delete, listKeys/action,
        /// etc.
        /// </summary>
        [JsonProperty(PropertyName = "operation")]
        public string Operation { get; set; }

        /// <summary>
        /// Gets or sets resource type on which the operation is performed.
        /// </summary>
        [JsonProperty(PropertyName = "resource")]
        public string Resource { get; set; }

        /// <summary>
        /// Gets or sets friendly name of the operation
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

    }
}
