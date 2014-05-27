using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.ApiAccess.Catalog
{
    public class Price : CRUDApiAccessBase<XOMNI.SDK.Model.Private.Catalog.Price>
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/price/{0}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/prices"; }
        }

        public Task<List<Model.Private.Catalog.Price>> GetByItemIdAsync(int itemId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalQueryString = new Dictionary<string, string>();
            additionalQueryString.Add("itemId", itemId.ToString());

            return GetByCustomListOperationUrlAsync(additionalQueryString, credential);
        }
    }
}
