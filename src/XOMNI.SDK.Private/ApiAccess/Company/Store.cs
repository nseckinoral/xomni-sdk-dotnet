using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model;

namespace XOMNI.SDK.Private.ApiAccess.Company
{
    public class Store : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/company/stores"; }
        }

        public Task<CountedCollectionContainer<Model.Private.Company.Store>> GetAsync(int skip, int take, ApiBasicCredential credential)
        {
            var additionalParams = new Dictionary<string,string>();
            additionalParams.Add("skip", skip.ToString());
            additionalParams.Add("take", take.ToString());
            return HttpProvider.GetAsync<CountedCollectionContainer<Model.Private.Company.Store>>(GenerateUrl(ListOperationBaseUrl, additionalParams), credential);
        }
    }
}
