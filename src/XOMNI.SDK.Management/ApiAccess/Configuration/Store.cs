using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Core.ApiAccess;

namespace XOMNI.SDK.Management.ApiAccess.Configuration
{
    internal class Store : CRUDApiAccessBase<Model.Management.Configuration.Store>
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/management/configuration/store/{0}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/management/configuration/stores"; }
        }
    }
}
