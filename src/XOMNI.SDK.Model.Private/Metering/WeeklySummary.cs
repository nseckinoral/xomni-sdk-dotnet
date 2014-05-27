using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Private.Metering
{
    public class WeeklyCountSummary : MonthlyCountSummary
    {
        public int WeekOfYear { get; set; }
    }
}
