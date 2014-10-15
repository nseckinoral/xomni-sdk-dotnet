using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.ApiAccess.Passbook
{
    public class PassbookTemplate : CRUDPApiAccessBase<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate>
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/passbook/template"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/passbook/templates"; }
        }
    }
}
