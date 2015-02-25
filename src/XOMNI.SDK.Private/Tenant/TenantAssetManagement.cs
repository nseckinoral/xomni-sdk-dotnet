using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Private.ApiAccess.Tenant;

namespace XOMNI.SDK.Private.Tenant
{
    public class TenantAssetManagement : BaseCRUDPSkipTakeManagement<Model.Private.Tenant.TenantAsset>
    {
        protected override Core.ApiAccess.CRUDPApiAccessBase<Model.Private.Tenant.TenantAsset> CRUDPApiAccess
        {
            get { return new TenantAssets(); }
        }
    }
}
