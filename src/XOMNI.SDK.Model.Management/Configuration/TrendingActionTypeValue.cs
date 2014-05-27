using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Management.Configuration
{
    public class TrendingActionTypeValue
    {
        /// <summary>
        /// Action Type unique id
        /// </summary>
        public TrendingActionType Id { get; set; }
        /// <summary>
        /// Description of the action type
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Impact value of the action type
        /// </summary>
        public double ImpactValue { get; set; }
    }
}
