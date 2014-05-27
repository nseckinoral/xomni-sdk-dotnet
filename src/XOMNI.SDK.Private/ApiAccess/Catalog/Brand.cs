using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model;

namespace XOMNI.SDK.Private.ApiAccess.Catalog
{
    internal class Brand : CRUDApiAccessBase<Model.Catalog.Brand>
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/brand/{0}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/brands"; }
        }

        public Task<CountedCollectionContainer<Model.Catalog.Brand>> GetByCategoryIdAsync(int categoryId, int skip, int take, ApiBasicCredential credential)
        {
            Dictionary<string,string> additionalQueryString = new Dictionary<string,string>();
            additionalQueryString.Add("categoryId",categoryId.ToString());
            additionalQueryString.Add("skip",skip.ToString());
            additionalQueryString.Add("take",take.ToString());

            return HttpProvider.GetAsync<CountedCollectionContainer<Model.Catalog.Brand>>(GenerateUrl(ListOperationBaseUrl, additionalQueryString), credential);
        }
    }
}
