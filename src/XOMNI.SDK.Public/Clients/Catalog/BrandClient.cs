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
	public class BrandClient : BaseClient
	{
		public BrandClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/brand/fetching-a-list-of-brands")]
        public async Task<ApiResponse<PaginatedContainer<Brand>>> GetAsync(int skip, int take)
		{
            Validator.For(skip, "skip").IsGreaterThanOrEqual(0);
            Validator.For(take, "take").InRange(1, 1000);

			string path = string.Format("/catalog/brands?skip={0}&take={1}", skip, take);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
				return await response.Content.ReadAsAsync<ApiResponse<PaginatedContainer<Brand>>>().ConfigureAwait(false);
			}
		}

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/brand/fetching-a-distinct-list-of-brands-of-a-set-of-items-in-a-particular-category")]
        public async Task<ApiResponse<PaginatedContainer<Brand>>> GetBrandsByCategoryAsync(int categoryId, int skip, int take)
		{
            Validator.For(categoryId, "categoryId").IsGreaterThanOrEqual(1);
            Validator.For(skip, "skip").IsGreaterThanOrEqual(0);
            Validator.For(take, "take").InRange(1, 1000);

			string path = string.Format("/catalog/brands?categoryId={0}&skip={1}&take={2}", categoryId, skip, take);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
				return await response.Content.ReadAsAsync<ApiResponse<PaginatedContainer<Brand>>>().ConfigureAwait(false);
			}
		}

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/brand/fetching-a-distinct-list-of-brands-of-a-set-of-products-having-a-particular-tag")]
        public async Task<ApiResponse<PaginatedContainer<Brand>>> GetBrandsByTagAsync(int tagId, int skip, int take)
        {
            Validator.For(tagId, "tagId").IsGreaterThanOrEqual(1);
            Validator.For(skip, "skip").IsGreaterThanOrEqual(0);
            Validator.For(take, "take").InRange(1, 1000);

            string path = string.Format("/catalog/brands?tagId={0}&skip={1}&take={2}", tagId, skip, take);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<PaginatedContainer<Brand>>>().ConfigureAwait(false);
            }
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/brand/fetching-brands-of-a-set-of-products-matching-a-specified-search-criteria")]
        public async Task<ApiResponse<List<Brand>>> GetBrandsBySearchRequestAsync(SearchRequest searchRequest)
        {
            Validator.For(searchRequest, "searchRequest").IsNotNull().InRange();
            
            string path = string.Format("/catalog/brands");

            using (var response = await Client.PostAsJsonAsync(path, searchRequest).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<List<Brand>>>().ConfigureAwait(false);
            }
        }
	}
}