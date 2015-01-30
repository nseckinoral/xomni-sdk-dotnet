using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Catalog;

namespace XOMNI.SDK.Public.Clients.Catalog
{
	public class BrandClient : BaseClient
	{
		public BrandClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

		public async Task<ApiResponse<PaginatedContainer<Brand>>> GetAsync(int skip, int take)
		{
            if(skip<=0 || take<=0)
            {
                throw new ArgumentException("Skip and/or take parameters are malformed.");
            }
			string path = string.Format("/catalog/brands?skip={0}&take={1}", skip, take);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
				return await response.Content.ReadAsAsync<ApiResponse<PaginatedContainer<Brand>>>().ConfigureAwait(false);
			}
		}

		public async Task<ApiResponse<PaginatedContainer<Brand>>> GetBrandsByCategoryAsync(int categoryId, int skip, int take)
		{
            if(categoryId<=0)
            {
                throw new ArgumentException("categoryId must be greater than or equal to zero");
            }
            if (skip <= 0 || take <= 0)
            {
                throw new ArgumentException("Skip and/or take parameters are malformed.");
            }
			string path = string.Format("/catalog/brands?categoryId={0}&skip={1}&take={2}", categoryId, skip, take);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
				return await response.Content.ReadAsAsync<ApiResponse<PaginatedContainer<Brand>>>().ConfigureAwait(false);
			}
		}

        public async Task<ApiResponse<PaginatedContainer<Brand>>> GetBrandsByTagAsync(int tagId, int skip, int take)
        {
            if (tagId <= 0)
            {
                throw new ArgumentException("tagId must be greater than or equal to zero");
            }
            if (skip <= 0 || take <= 0)
            {
                throw new ArgumentException("Skip and/or take parameters are malformed.");
            }
            string path = string.Format("/catalog/brands?tagId={0}&skip={1}&take={2}", tagId, skip, take);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<PaginatedContainer<Brand>>>().ConfigureAwait(false);
            }
        }

        public async Task<ApiResponse<PaginatedContainer<Brand>>> GetBrandsBySearchRequestAsync(SearchRequest searchRequest)
        {
            if(searchRequest==null)
            {
                throw new ArgumentNullException("searchrequest is required field.");
            }
            string path = string.Format("/catalog/brands");

            using (var response = await Client.PostAsJsonAsync(path, searchRequest).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<PaginatedContainer<Brand>>>().ConfigureAwait(false);
            }
        }
	}
}