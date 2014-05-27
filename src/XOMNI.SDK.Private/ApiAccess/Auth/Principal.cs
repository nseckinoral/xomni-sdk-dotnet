using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.ApiAccess.Auth
{
    internal class Principal : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/auth/principal"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        public Task<Model.Private.Auth.Principal> GetAsync(ApiBasicCredential credential)
        {
            return HttpProvider.GetAsync<Model.Private.Auth.Principal>(GenerateUrl(SingleOperationBaseUrl), credential);
        }
    }
}
