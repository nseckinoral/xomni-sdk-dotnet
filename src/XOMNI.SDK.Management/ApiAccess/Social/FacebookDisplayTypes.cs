using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Management.ApiAccess.Social
{
    internal class FacebookDisplayTypes : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/management/social/facebookdisplaytypes"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        public Task<IDictionary<int, string>> GetAsync(ApiBasicCredential credential)
        {
            return HttpProvider.GetAsync<IDictionary<int, string>>(GenerateUrl(SingleOperationBaseUrl), credential);
        }

        internal XOMNIRequestMessage<IDictionary<int, string>> CreateGetRequest(ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<IDictionary<int, string>>(HttpProvider.CreateGetRequest(GenerateUrl(SingleOperationBaseUrl), credential));
        }
    }
}
