using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Tests.Private.Metering.Log.MeteringEntities
{
    public class TrendingItemMeteringLogEntity : BaseMeteringEntity
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

        public TrendingItemMeteringLogEntity()
        {

        }

        public TrendingItemMeteringLogEntity(DateTime meteringDate)
            : base(meteringDate)
        {

        }
    }
}
