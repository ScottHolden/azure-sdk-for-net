// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Billing.Models
{
    using Azure;
    using Management;
    using Billing;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The details of the error.
    /// </summary>
    public partial class ErrorDetails
    {
        /// <summary>
        /// Initializes a new instance of the ErrorDetails class.
        /// </summary>
        public ErrorDetails() { }

        /// <summary>
        /// Initializes a new instance of the ErrorDetails class.
        /// </summary>
        /// <param name="code">Error code.</param>
        /// <param name="message">Error message indicating why the operation
        /// failed.</param>
        /// <param name="target">The target of the particular error.</param>
        public ErrorDetails(string code = default(string), string message = default(string), string target = default(string))
        {
            Code = code;
            Message = message;
            Target = target;
        }

        /// <summary>
        /// Gets error code.
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; protected set; }

        /// <summary>
        /// Gets error message indicating why the operation failed.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; protected set; }

        /// <summary>
        /// Gets the target of the particular error.
        /// </summary>
        [JsonProperty(PropertyName = "target")]
        public string Target { get; protected set; }

    }
}

