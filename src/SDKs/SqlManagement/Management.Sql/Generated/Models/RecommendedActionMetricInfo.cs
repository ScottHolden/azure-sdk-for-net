// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
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
    /// Contains time series of various impacted metrics for an Azure SQL
    /// Database, Server or Elastic Pool Recommended Action.
    /// </summary>
    public partial class RecommendedActionMetricInfo
    {
        /// <summary>
        /// Initializes a new instance of the RecommendedActionMetricInfo
        /// class.
        /// </summary>
        public RecommendedActionMetricInfo()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RecommendedActionMetricInfo
        /// class.
        /// </summary>
        /// <param name="metricName">Gets the name of the metric. e.g., CPU,
        /// Number of Queries.</param>
        /// <param name="unit">Gets the unit in which metric is measured. e.g.,
        /// DTU, Frequency</param>
        /// <param name="timeGrain">Gets the duration of time interval for the
        /// value given by this MetricInfo. e.g., PT1H (1 hour)</param>
        /// <param name="startTime">Gets the start time of time interval given
        /// by this MetricInfo.</param>
        /// <param name="value">Gets the value of the metric in the time
        /// interval given by this MetricInfo.</param>
        public RecommendedActionMetricInfo(string metricName = default(string), string unit = default(string), string timeGrain = default(string), System.DateTime? startTime = default(System.DateTime?), double? value = default(double?))
        {
            MetricName = metricName;
            Unit = unit;
            TimeGrain = timeGrain;
            StartTime = startTime;
            Value = value;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the name of the metric. e.g., CPU, Number of Queries.
        /// </summary>
        [JsonProperty(PropertyName = "metricName")]
        public string MetricName { get; private set; }

        /// <summary>
        /// Gets the unit in which metric is measured. e.g., DTU, Frequency
        /// </summary>
        [JsonProperty(PropertyName = "unit")]
        public string Unit { get; private set; }

        /// <summary>
        /// Gets the duration of time interval for the value given by this
        /// MetricInfo. e.g., PT1H (1 hour)
        /// </summary>
        [JsonProperty(PropertyName = "timeGrain")]
        public string TimeGrain { get; private set; }

        /// <summary>
        /// Gets the start time of time interval given by this MetricInfo.
        /// </summary>
        [JsonProperty(PropertyName = "startTime")]
        public System.DateTime? StartTime { get; private set; }

        /// <summary>
        /// Gets the value of the metric in the time interval given by this
        /// MetricInfo.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public double? Value { get; private set; }

    }
}
