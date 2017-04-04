// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.0.1.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Sql.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.Sql;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The maximum size limits for a database.
    /// </summary>
    public partial class MaxSizeCapability
    {
        /// <summary>
        /// Initializes a new instance of the MaxSizeCapability class.
        /// </summary>
        public MaxSizeCapability()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the MaxSizeCapability class.
        /// </summary>
        /// <param name="limit">The maximum size of the database (see 'unit'
        /// for the units).</param>
        /// <param name="unit">The units that the limit is expressed in.
        /// Possible values include: 'Megabytes', 'Gigabytes', 'Terabytes',
        /// 'Petabytes'</param>
        /// <param name="status">The status of the maximum size capability.
        /// Possible values include: 'Visible', 'Available', 'Default',
        /// 'Disabled'</param>
        public MaxSizeCapability(long? limit = default(long?), MaxSizeUnits? unit = default(MaxSizeUnits?), CapabilityStatus? status = default(CapabilityStatus?))
        {
            Limit = limit;
            Unit = unit;
            Status = status;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the maximum size of the database (see 'unit' for the units).
        /// </summary>
        [JsonProperty(PropertyName = "limit")]
        public long? Limit { get; private set; }

        /// <summary>
        /// Gets the units that the limit is expressed in. Possible values
        /// include: 'Megabytes', 'Gigabytes', 'Terabytes', 'Petabytes'
        /// </summary>
        [JsonProperty(PropertyName = "unit")]
        public MaxSizeUnits? Unit { get; private set; }

        /// <summary>
        /// Gets the status of the maximum size capability. Possible values
        /// include: 'Visible', 'Available', 'Default', 'Disabled'
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public CapabilityStatus? Status { get; private set; }

    }
}
