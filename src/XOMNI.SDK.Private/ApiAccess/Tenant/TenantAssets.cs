using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Core.ApiAccess;

namespace XOMNI.SDK.Private.ApiAccess.Tenant
{
    public class TenantAssets : CRUDApiAccessBase<Model.Private.Tenant.TenantAsset>
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/tenant/asset/{0}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/tenant/assets"; }
        }
    }
}
