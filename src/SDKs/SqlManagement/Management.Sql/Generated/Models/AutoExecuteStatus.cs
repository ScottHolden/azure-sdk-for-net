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
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for AutoExecuteStatus.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AutoExecuteStatus
    {
        [EnumMember(Value = "Enabled")]
        Enabled,
        [EnumMember(Value = "Disabled")]
        Disabled,
        [EnumMember(Value = "Default")]
        Default
    }
    internal static class AutoExecuteStatusEnumExtension
    {
        internal static string ToSerializedValue(this AutoExecuteStatus? value)  =>
            value == null ? null : ((AutoExecuteStatus)value).ToSerializedValue();

        internal static string ToSerializedValue(this AutoExecuteStatus value)
        {
            switch( value )
            {
                case AutoExecuteStatus.Enabled:
                    return "Enabled";
                case AutoExecuteStatus.Disabled:
                    return "Disabled";
                case AutoExecuteStatus.Default:
                    return "Default";
            }
            return null;
        }

        internal static AutoExecuteStatus? ParseAutoExecuteStatus(this string value)
        {
            switch( value )
            {
                case "Enabled":
                    return AutoExecuteStatus.Enabled;
                case "Disabled":
                    return AutoExecuteStatus.Disabled;
                case "Default":
                    return AutoExecuteStatus.Default;
            }
            return null;
        }
    }
}
