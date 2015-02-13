using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Catalog;
using XOMNI.SDK.Public.Extensions;

namespace XOMNI.SDK.Public.Clients.Catalog
{
	public class ItemCompareClient : BaseClient
	{
		public ItemCompareClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

        public async Task<ApiResponse<MultipleItemSearchResult<Item>>> CompareAsync(List<int> itemIds)
		{
            Validator.For(itemIds, "itemIds").IsNotNull();
            Validator.For(itemIds.Count, "Count").InRange(2, 5);

			string path = "/catalog/itemcompare";

			using (var response = await Client.PostAsJsonAsync(path, itemIds).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<MultipleItemSearchResult<Item>>>().ConfigureAwait(false);
			}
		}

        public async Task<ApiResponse<ItemCompareResult>> CompareMatrixAsync(List<int> itemIds)
		{
            Validator.For(itemIds, "itemIds").IsNotNull();
            Validator.For(itemIds.Count, "Count").InRange(2, 5);

			string path = "/catalog/itemcomparematrix";

            using (var response = await Client.PostAsJsonAsync(path, itemIds).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<ItemCompareResult>>().ConfigureAwait(false);
			}
		}
	}
}