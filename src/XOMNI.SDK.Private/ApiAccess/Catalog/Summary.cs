using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.ApiAccess.Catalog
{
    public class Summary : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/summary"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        public Task<Model.Private.Catalog.Summary> GetAsync(ApiBasicCredential credential)
        {
            return HttpProvider.GetAsync<Model.Private.Catalog.Summary>(GenerateUrl(SingleOperationBaseUrl), credential);
        }
    }
}
