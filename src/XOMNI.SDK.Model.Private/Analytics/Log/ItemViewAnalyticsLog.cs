using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Private.Analytics.Log
{
    public class ItemViewAnalyticsLog : BaseAnalyticsLog
    {
        public int ItemId { get; set; }
        public string ItemTitle { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public string ItemName { get; set; }
        public int? DefaultItemId { get; set; }
        public string Model { get; set; }
    }
}
