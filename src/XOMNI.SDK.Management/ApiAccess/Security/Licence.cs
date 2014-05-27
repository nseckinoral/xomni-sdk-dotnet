using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Core.ApiAccess;

namespace XOMNI.SDK.Management.ApiAccess.Security
{
    internal class License : CRUDApiAccessBase<Model.Management.Security.License>
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/management/security/license/{0}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/management/security/licenses"; }
        }
    }
}
