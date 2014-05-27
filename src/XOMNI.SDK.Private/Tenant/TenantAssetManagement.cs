using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Private.ApiAccess.Tenant;

namespace XOMNI.SDK.Private.Tenant
{
    public class TenantAssetManagement : BaseCRUDSkipTakeManagement<Model.Private.Tenant.TenantAsset>
    {
        protected override Core.ApiAccess.CRUDApiAccessBase<Model.Private.Tenant.TenantAsset> ApiAccess
        {
            get { return new TenantAssets(); }
        }
    }
}
