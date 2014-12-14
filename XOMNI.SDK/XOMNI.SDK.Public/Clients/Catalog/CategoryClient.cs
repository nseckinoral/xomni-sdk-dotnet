using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models.Catalog;

namespace XOMNI.SDK.Public.Clients.Catalog
{
	public class CategoryClient : BaseClient
	{
		public CategoryClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

		public async Task<List<Category>> GetAsync(bool includeMetadata, int imageAssetDetail, int videoAssetDetail, int documentAssetDetail)
		{
			string path = string.Format("/catalog/categories?includeMetadata={0}&imageAssetDetail={1}&videoAssetDetail={2}&documentAssetDetail={3}", includeMetadata, imageAssetDetail, videoAssetDetail, documentAssetDetail);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<List<Category>>().ConfigureAwait(false);
			}
		}

		public async Task<CategoryTree<CategoryTreeItem>> GetAsync(int parentCategoryId, bool includeMetadata, int imageAssetDetail, int videoAssetDetail, int documentAssetDetail)
		{
			string path = string.Format("/catalog/categories?parentCategoryId={0}&includeMetadata={1}&imageAssetDetail={2}&videoAssetDetail={3}&documentAssetDetail={4}", parentCategoryId, includeMetadata, imageAssetDetail, videoAssetDetail, documentAssetDetail);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<CategoryTree<CategoryTreeItem>>().ConfigureAwait(false);
			}
		}
	}
}