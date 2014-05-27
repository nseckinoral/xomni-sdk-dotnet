using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model.Catalog;

namespace XOMNI.SDK.Model.Private.Catalog
{
    public class Price : BasePrice
    {
        public int PriceId { get; set; }
        public int ItemId { get; set; }
    }
}
