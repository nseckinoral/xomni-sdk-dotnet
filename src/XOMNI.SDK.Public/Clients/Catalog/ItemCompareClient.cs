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
    public class ItemCompareClient : BaseClient
    {
        public ItemCompareClient(HttpClient httpClient)
            : base(httpClient)
        {

        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/item-compare/getting-a-list-of-items-to-compare")]
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

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/item-compare/getting-a-compared-matrix-of-products")]
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