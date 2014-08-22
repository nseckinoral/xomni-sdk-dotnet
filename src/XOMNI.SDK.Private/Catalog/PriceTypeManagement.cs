using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Management;

namespace XOMNI.SDK.Private.Catalog
{
    public class PriceTypeManagement : BaseCRUDSkipTakeManagement<Model.Catalog.PriceType>
    {
        protected override CRUDApiAccessBase<Model.Catalog.PriceType> ApiAccess
        {
            get { return new ApiAccess.Catalog.PriceType(); }
        }
    }
}
