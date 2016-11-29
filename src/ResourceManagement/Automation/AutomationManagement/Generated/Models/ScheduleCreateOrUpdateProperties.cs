// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Linq;
using Microsoft.Azure.Management.Automation.Models;

namespace Microsoft.Azure.Management.Automation.Models
{
    /// <summary>
    /// The parameters supplied to the create or update schedule operation.
    /// </summary>
    public partial class ScheduleCreateOrUpdateProperties
    {
        private AdvancedSchedule _advancedSchedule;
        
        /// <summary>
        /// Optional. Gets or sets the AdvancedSchedule.
        /// </summary>
        public AdvancedSchedule AdvancedSchedule
        {
            get { return this._advancedSchedule; }
            set { this._advancedSchedule = value; }
        }
        
        private string _description;
        
        /// <summary>
        /// Optional. Gets or sets the description of the schedule.
        /// </summary>
        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }
        
        private System.DateTimeOffset? _expiryTime;
        
        /// <summary>
        /// Optional. Gets or sets the end time of the schedule.
        /// </summary>
        public System.DateTimeOffset? ExpiryTime
        {
            get { return this._expiryTime; }
            set { this._expiryTime = value; }
        }
        
        private string _frequency;
        
        /// <summary>
        /// Required. Gets or sets the frequency of the schedule.
        /// </summary>
        public string Frequency
        {
            get { return this._frequency; }
            set { this._frequency = value; }
        }
        
        private byte? _interval;
        
        /// <summary>
        /// Optional. Gets or sets the interval of the schedule.
        /// </summary>
        public byte? Interval
        {
            get { return this._interval; }
            set { this._interval = value; }
        }
        
        private DateTimeOffset _startTime;
        
        /// <summary>
        /// Required. Gets or sets the start time of the schedule.
        /// </summary>
        public DateTimeOffset StartTime
        {
            get { return this._startTime; }
            set { this._startTime = value; }
        }
        
        private string _timeZone;
        
        /// <summary>
        /// Optional. Gets or sets the time zone of the schedule.
        /// </summary>
        public string TimeZone
        {
            get { return this._timeZone; }
            set { this._timeZone = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ScheduleCreateOrUpdateProperties
        /// class.
        /// </summary>
        public ScheduleCreateOrUpdateProperties()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the ScheduleCreateOrUpdateProperties
        /// class with required arguments.
        /// </summary>
        public ScheduleCreateOrUpdateProperties(DateTimeOffset startTime, string frequency)
            : this()
        {
            if (frequency == null)
            {
                throw new ArgumentNullException("frequency");
            }
            this.StartTime = startTime;
            this.Frequency = frequency;
        }
    }
}