using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Private.Analytics.Log
{
    public class TrendingItemAnalyticsLog : BaseAnalyticsLog
    {
        public int? StoreId { get; set; }
        public int ItemId { get; set; }
        public string ItemTitle { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public string ItemName { get; set; }
        public int? DefaultItemId { get; set; }
        public string Model { get; set; }
        public double TotalActionTypeImpactValue { get; set; }
        public double TotalTimeImpactValue { get; set; }
        public int TotalActionCount { get; set; }
    }
}
