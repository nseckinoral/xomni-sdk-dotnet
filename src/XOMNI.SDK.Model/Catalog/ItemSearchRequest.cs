using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Catalog
{
    public class ItemSearchRequest : BaseItemSearchRequest
    {
        public List<int> ItemIds { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public string OrderedPropertyName { get; set; }
        public string OrderBy { get; set; }

        public bool IncludeItemStaticProperties { get; set; }
        public bool IncludeItemDynamicProperties { get; set; }

        public AssetDetailType DocumentAssetDetail { get; set; }
        public AssetDetailType VideoAssetDetail { get; set; }
        public AssetDetailType ImageAssetDetail { get; set; }
        
        public ItemSearchRequest()
        {
            // Set default values.
            IncludeStaticNavigationInternal = true;
            IncludeDynamicNavigationInternal = true;
        }

        public bool IncludeStaticNavigation
        {
            get
            {
                return IncludeStaticNavigationInternal;
            }
            set
            {
                IncludeStaticNavigationInternal = value;
            }
        }

        public bool IncludeDynamicNavigation
        {
            get
            {
                return IncludeDynamicNavigationInternal;
            }
            set
            {
                IncludeDynamicNavigationInternal = value;
            }
        }

        protected override bool IncludeItemsInternal
        {
            get
            {
                return true;
            }
        }
    }
}
