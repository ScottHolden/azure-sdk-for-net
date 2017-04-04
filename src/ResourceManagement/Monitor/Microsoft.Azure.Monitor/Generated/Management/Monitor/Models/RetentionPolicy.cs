// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Insights.Models
{
    using Azure;
    using Management;
    using Insights;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Specifies the retention policy for the log.
    /// </summary>
    public partial class RetentionPolicy
    {
        /// <summary>
        /// Initializes a new instance of the RetentionPolicy class.
        /// </summary>
        public RetentionPolicy() { }

        /// <summary>
        /// Initializes a new instance of the RetentionPolicy class.
        /// </summary>
        /// <param name="enabled">a value indicating whether the retention
        /// policy is enabled.</param>
        /// <param name="days">the number of days for the retention in days. A
        /// value of 0 will retain the events indefinitely.</param>
        public RetentionPolicy(bool enabled, int days)
        {
            Enabled = enabled;
            Days = days;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the retention policy is
        /// enabled.
        /// </summary>
        [JsonProperty(PropertyName = "enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the number of days for the retention in days. A value
        /// of 0 will retain the events indefinitely.
        /// </summary>
        [JsonProperty(PropertyName = "days")]
        public int Days { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            //Nothing to validate
        }
    }
}

