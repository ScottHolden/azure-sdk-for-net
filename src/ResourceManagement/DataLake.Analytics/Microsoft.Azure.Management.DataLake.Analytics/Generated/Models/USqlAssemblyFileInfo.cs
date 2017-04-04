// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.0.1.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.DataLake.Analytics.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.DataLake;
    using Microsoft.Azure.Management.DataLake.Analytics;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// A Data Lake Analytics catalog U-SQL assembly file information item.
    /// </summary>
    public partial class USqlAssemblyFileInfo
    {
        /// <summary>
        /// Initializes a new instance of the USqlAssemblyFileInfo class.
        /// </summary>
        public USqlAssemblyFileInfo()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the USqlAssemblyFileInfo class.
        /// </summary>
        /// <param name="type">the assembly file type. Possible values include:
        /// 'Assembly', 'Resource'</param>
        /// <param name="originalPath">the the original path to the assembly
        /// file.</param>
        /// <param name="contentPath">the the content path to the assembly
        /// file.</param>
        public USqlAssemblyFileInfo(FileType? type = default(FileType?), string originalPath = default(string), string contentPath = default(string))
        {
            Type = type;
            OriginalPath = originalPath;
            ContentPath = contentPath;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the assembly file type. Possible values include:
        /// 'Assembly', 'Resource'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public FileType? Type { get; set; }

        /// <summary>
        /// Gets or sets the the original path to the assembly file.
        /// </summary>
        [JsonProperty(PropertyName = "originalPath")]
        public string OriginalPath { get; set; }

        /// <summary>
        /// Gets or sets the the content path to the assembly file.
        /// </summary>
        [JsonProperty(PropertyName = "contentPath")]
        public string ContentPath { get; set; }

    }
}
