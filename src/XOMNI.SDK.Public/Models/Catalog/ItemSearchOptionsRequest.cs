using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Public.Models.Catalog
{
    public class ItemSearchOptionsRequest : ItemSearchRequest
    {
        public override bool IncludeStaticNavigation
        {
            get
            {
                return true;
            }
        }

        public override bool IncludeDynamicNavigation
        {
            get
            {
                return true;
            }
        }
    }
}
