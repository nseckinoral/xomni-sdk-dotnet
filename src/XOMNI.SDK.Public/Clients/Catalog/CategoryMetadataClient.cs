using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Extensions;
using System.Collections.Generic;
using XOMNI.SDK.Public.Infrastructure;

namespace XOMNI.SDK.Public.Clients.Catalog
{
	public class CategoryMetadataClient : BaseClient
	{
		public CategoryMetadataClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/category-metadata/fetching-the-metadata-of-a-category")]
        public async Task<ApiResponse<List<Metadata>>> GetAsync(int categoryId)
		{
            Validator.For(categoryId, "categoryId").IsGreaterThanOrEqual(1);

			string path = string.Format("/catalog/categorymetadata?categoryId={0}", categoryId);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
				return await response.Content.ReadAsAsync<ApiResponse<List<Metadata>>>().ConfigureAwait(false);
			}
		}
	}
}