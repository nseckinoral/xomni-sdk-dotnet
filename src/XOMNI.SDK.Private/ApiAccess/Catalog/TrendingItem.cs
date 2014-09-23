using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model.Private.Catalog;

namespace XOMNI.SDK.Private.ApiAccess.Catalog
{
    public class TrendingItem : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        protected override string ListOperationBaseUrl
        {
            get
            {
                return "/private/catalog/trendingitems";
            }
        }

        public Task<IEnumerable<TrendingItemDto>> GetTrendingItemsAsync(int top, ApiBasicCredential credential, bool includeActionDetails = false)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("top", top.ToString());
            additionalParameters.Add("includeactiondetails", includeActionDetails.ToString().ToLowerInvariant());

            return HttpProvider.GetAsync<IEnumerable<TrendingItemDto>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

        public Task<IEnumerable<TrendingItemDto>> GetTrendingItemsByStoreIdAsync(int top, int storeId, ApiBasicCredential credential, bool includeActionDetails = false)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("top", top.ToString());
            additionalParameters.Add("storeid", storeId.ToString());
            additionalParameters.Add("includeactiondetails", includeActionDetails.ToString().ToLowerInvariant());

            return HttpProvider.GetAsync<IEnumerable<TrendingItemDto>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

        public Task<IEnumerable<TrendingItemDto>> GetTrendingItemsByBrandIdAsync(int top, int brandId, ApiBasicCredential credential, bool includeActionDetails = false)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("top", top.ToString());
            additionalParameters.Add("brandid", brandId.ToString());
            additionalParameters.Add("includeactiondetails", includeActionDetails.ToString().ToLowerInvariant());

            return HttpProvider.GetAsync<IEnumerable<TrendingItemDto>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

        public Task<IEnumerable<TrendingItemDto>> GetTrendingItemsByStoreAndBrandIdAsync(int top, int storeId, int brandId, ApiBasicCredential credential, bool includeActionDetails = false)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("top", top.ToString());
            additionalParameters.Add("storeid", storeId.ToString());
            additionalParameters.Add("brandid", brandId.ToString());
            additionalParameters.Add("includeactiondetails", includeActionDetails.ToString().ToLowerInvariant());

            return HttpProvider.GetAsync<IEnumerable<TrendingItemDto>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }
    }
}