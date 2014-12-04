using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Private.Analytics.Log
{
    public class ClientAnalyticsLog : BaseAnalyticsLog
    {
        public string CounterName { get; set; }
        public string DataBag { get; set; }
        public int Value { get; set; }
    }
}
