using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Private.Analytics
{
    public class WeeklyCountSummary : MonthlyCountSummary
    {
        public int WeekOfYear { get; set; }
    }
}
