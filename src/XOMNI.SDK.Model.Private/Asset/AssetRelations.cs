using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Private.Asset
{
    public class AssetRelations
    {
        public List<int> RelatedItemIds { get; set; }
        public List<int> RelatedBrandIds { get; set; }
        public List<int> RelatedCategoryIds { get; set; }
    }
}
