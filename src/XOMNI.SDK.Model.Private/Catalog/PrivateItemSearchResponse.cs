using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Model.Private.Asset;

namespace XOMNI.SDK.Model.Private.Catalog
{
    public class PrivateItemSearchResponse : Item
    {
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public bool HasVariants { get; set; }
        public RelatedImageAsset DefaultImage { get; set; }
        public RelatedAsset DefaultVideo { get; set; }
        public RelatedAsset DefaultDocument { get; set; }
    }
}
