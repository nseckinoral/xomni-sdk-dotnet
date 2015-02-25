using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Core.ApiAccess;

namespace XOMNI.SDK.Private.ApiAccess.PII
{
    public class Loyalty : CRUDPApiAccessBase<Model.Private.PII.LoyaltyUser>
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/pii/loyalty/{0}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/pii/loyalties"; }
        }
    }
}
