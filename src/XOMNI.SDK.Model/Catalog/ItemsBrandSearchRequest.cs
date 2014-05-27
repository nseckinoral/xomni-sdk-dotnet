using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Catalog
{
    public class ItemsBrandSearchRequest : BaseItemSearchRequest
    {
        protected override bool IncludeItemsInternal
        {
            get { return false; }
        }
    }
}
