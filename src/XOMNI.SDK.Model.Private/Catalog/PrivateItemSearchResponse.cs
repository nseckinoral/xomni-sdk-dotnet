using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Model.Private.Asset;

namespace XOMNI.SDK.Model.Private.Catalog
{
    public class PrivateItemSearchResponse : Item
    {
        public RelatedImageAsset DefaultImage { get; set; }
        public Asset.Asset DefaultVideo { get; set; }
        public Asset.Asset DefaultDocument { get; set; }
    }
}
