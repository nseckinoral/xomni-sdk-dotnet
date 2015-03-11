using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Public.Models.Catalog
{
    public class ItemSearchRequest : SearchRequest
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public OrderedProperty? OrderedPropertyName { get; set; }
        public OrderByType? OrderBy { get; set; }
        public virtual bool IncludeStaticNavigation { get; set; }
        public virtual bool IncludeDynamicNavigation { get; set; }
        public List<int> ItemIds { get; set; }
        public bool IncludeItemStaticProperties { get; set; }
        public bool IncludeItemDynamicProperties { get; set; }
        public AssetDetailType DocumentAssetDetail { get; set; }
        public AssetDetailType VideoAssetDetail { get; set; }
        public AssetDetailType ImageAssetDetail { get; set; }
    }
}
