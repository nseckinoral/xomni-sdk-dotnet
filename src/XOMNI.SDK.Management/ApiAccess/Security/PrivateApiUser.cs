using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Core.ApiAccess;

namespace XOMNI.SDK.Management.ApiAccess.Security
{
    internal class PrivateApiUser : CRUDApiAccessBase<Model.Management.Security.ApiUser>
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/management/security/privateapiuser/{0}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/management/security/privateapiusers"; }
        }
    }
}
