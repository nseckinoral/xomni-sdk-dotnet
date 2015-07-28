using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Catalog;
using XOMNI.SDK.Public.Extensions;
using XOMNI.SDK.Public.Infrastructure;

namespace XOMNI.SDK.Public.Clients.Catalog
{
	public class TrendingItemClient : BaseClient
	{
		public TrendingItemClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/trending-items/fetching-a-list-of-trending-items")]
		public async Task<ApiResponse<List<TrendingItem>>> GetAsync(int top, bool includeActionDetails = true)
		{
            Validator.For(top, "top").IsGreaterThanOrEqual(1);

			string path = string.Format("/catalog/trendingitems?top={0}&includeActionDetails={1}", top, includeActionDetails);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<List<TrendingItem>>>().ConfigureAwait(false);
			}
		}

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/trending-items/fetching-a-list-of-trending-items-by-storeid")]
		public async Task<ApiResponse<List<TrendingItem>>> GetByStoreAsync(int top, int storeId, bool includeActionDetails = true)
		{
            Validator.For(top, "top").IsGreaterThanOrEqual(1);
            Validator.For(storeId, "storeId").IsGreaterThanOrEqual(1);
			string path = string.Format("/catalog/trendingitems?top={0}&storeId={1}&includeActionDetails={2}", top, storeId, includeActionDetails);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<List<TrendingItem>>>().ConfigureAwait(false);
			}
		}

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/trending-items/fetching-a-list-of-trending-items-by-brandid")]
		public async Task<ApiResponse<List<TrendingItem>>> GetByBrandAsync(int top, int brandId, bool includeActionDetails = true)
        {
            Validator.For(top, "top").IsGreaterThanOrEqual(1);
            Validator.For(brandId, "brandId").IsGreaterThanOrEqual(1);
            string path = string.Format("/catalog/trendingitems?top={0}&brandId={1}&includeActionDetails={2}", top, brandId, includeActionDetails);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<List<TrendingItem>>>().ConfigureAwait(false);
            }
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/trending-items/fetching-a-list-of-trending-items-by-brandid-and-storeid")]
		public async Task<ApiResponse<List<TrendingItem>>> GetByBrandAndStoreAsync(int top, int brandId, int storeId, bool includeActionDetails = true)
		{
            Validator.For(top, "top").IsGreaterThanOrEqual(1);
            Validator.For(brandId, "brandId").IsGreaterThanOrEqual(1);
            Validator.For(storeId, "storeId").IsGreaterThanOrEqual(1);
			string path = string.Format("/catalog/trendingitems?top={0}&brandId={1}&storeId={2}&includeActionDetails={3}", top, brandId, storeId, includeActionDetails);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<List<TrendingItem>>>().ConfigureAwait(false);
			}
		}
	}
}