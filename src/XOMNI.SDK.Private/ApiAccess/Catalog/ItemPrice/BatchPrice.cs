using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.ApiAccess.Catalog.ItemPrice
{
    internal class BatchPrice : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/items/{0}/prices"; }
        }

        public Task<List<Model.Private.Catalog.Price>> UpdateItemPricesAsync(int itemId, List<Model.Private.Catalog.Price> priceList, ApiBasicCredential credential)
        {
            return HttpProvider.PutAsync<List<Model.Private.Catalog.Price>>(GenerateUrl(string.Format(ListOperationBaseUrl, itemId)), priceList, credential);
        }
    }
}
