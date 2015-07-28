using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Extensions;
using XOMNI.SDK.Public.Infrastructure;

namespace XOMNI.SDK.Public.Clients.Catalog
{
	public class RelatedItemsClient : BaseClient
	{
		public RelatedItemsClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/related-items/fetching-related-items-of-an-item")]
		public async Task<ApiResponse<List<int>>> GetAsync(int itemId)
		{
            Validator.For(itemId, "itemId").IsGreaterThanOrEqual(1);
			string path = string.Format("/catalog/relatedItems?itemId={0}", itemId);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<List<int>>>().ConfigureAwait(false);
			}
		}
	}
}