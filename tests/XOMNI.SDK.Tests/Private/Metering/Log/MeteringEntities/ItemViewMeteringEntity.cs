using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Tests.Private.Metering.Log.MeteringEntities
{
    public class ItemViewMeteringEntity : BaseMeteringEntity
    {
        public int ItemId { get; set; }
        public string ItemTitle { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public string ItemName { get; set; }
        public int? DefaultItemId { get; set; }
        public string Model { get; set; }

        public ItemViewMeteringEntity()
        {

        }

        public ItemViewMeteringEntity(DateTime meteringDate)
            : base(meteringDate)
        {

        }
    }
}
