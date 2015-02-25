using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Management;

namespace XOMNI.SDK.Private.Catalog
{
    public class PriceTypeManagement : BaseCRUDPSkipTakeManagement<Model.Catalog.PriceType>
    {
        protected override CRUDPApiAccessBase<Model.Catalog.PriceType> CRUDPApiAccess
        {
            get { return new ApiAccess.Catalog.PriceType(); }
        }
    }
}
