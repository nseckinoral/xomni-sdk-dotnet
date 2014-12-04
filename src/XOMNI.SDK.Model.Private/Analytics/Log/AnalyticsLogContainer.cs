using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Private.Analytics.Log
{
    public class AnalyticsLogContainer<T>
    {
        public string ContinuationToken { get; set; }
        public List<T> Logs { get; set; }
    }
}
