using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model;
using XOMNI.SDK.Model.Private.Catalog;

namespace XOMNI.SDK.Private.ApiAccess.Catalog.ItemSearch
{
    public class Search : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/items/search"; }
        }

        internal Task<CountedCollectionContainer<PrivateItemSearchResponse>> GetAsync(int skip, int take, int? categoryId, int? brandId, int? defaultItemId, string SKU, string UUID, bool includeOnlyMasterItems, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("skip", skip.ToString());
            additionalParameters.Add("take", take.ToString());
            if (categoryId.HasValue)
            {
                additionalParameters.Add("categoryId", categoryId.ToString());
            }
            if (brandId.HasValue)
            {
                additionalParameters.Add("brandId", brandId.ToString());
            }
            if (defaultItemId.HasValue)
            {
                additionalParameters.Add("defaultItemId", defaultItemId.ToString());
            }
            if (!string.IsNullOrEmpty(SKU))
            {
                additionalParameters.Add("SKU", SKU.ToString());
            }
            if (!string.IsNullOrEmpty(UUID))
            {
                additionalParameters.Add("UUID", UUID.ToString());
            }
            additionalParameters.Add("includeOnlyMasterItems", includeOnlyMasterItems.ToString());

            return HttpProvider.GetAsync<CountedCollectionContainer<PrivateItemSearchResponse>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

    }
}
