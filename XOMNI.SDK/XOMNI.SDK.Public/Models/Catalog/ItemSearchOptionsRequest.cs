using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Public.Models.Catalog
{
    public class ItemSearchOptionsRequest : ItemSearchRequest
    {
        protected override bool IncludeStaticNavigation
        {
            get
            {
                return true;
            }
        }

        protected override bool IncludeDynamicNavigation
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
