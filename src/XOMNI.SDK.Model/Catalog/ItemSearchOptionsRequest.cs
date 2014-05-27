using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Catalog
{
    public class ItemSearchOptionsRequest : BaseItemSearchRequest
    {
        protected override bool IncludeStaticNavigationInternal
        {
            get
            {
                return true;
            }
        }

        protected override bool IncludeDynamicNavigationInternal
        {
            get
            {
                return true;
            }
        }

        protected override bool IncludeItemsInternal
        {
            get
            {
                return false;
            }
        }
    }
}
