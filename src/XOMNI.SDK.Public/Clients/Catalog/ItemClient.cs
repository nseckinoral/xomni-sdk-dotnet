using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Catalog;
using XOMNI.SDK.Public.Extensions;
using XOMNI.SDK.Public.Infrastructure;

namespace XOMNI.SDK.Public.Clients.Catalog
{
    public class ItemClient : BaseClient
    {
        public ItemClient(HttpClient httpClient)
            : base(httpClient)
        {

        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/item/fetching-a-single-item")]
        public async Task<ApiResponse<SingleItemSearchResult<Item>>> GetAsync(int id, bool includeItemInStoreMetadata = false, bool includeItemStaticProperties = true, bool includeItemDynamicProperties = true, AssetDetailType imageAssetDetail = AssetDetailType.None, AssetDetailType videoAssetDetail = AssetDetailType.None, AssetDetailType documentAssetDetail = AssetDetailType.None)
        {
            Validator.For(id, "id").IsGreaterThanOrEqual(1);

            string path = string.Format("/catalog/item/{0}?includeItemStaticProperties={1}&includeItemDynamicProperties={2}&imageAssetDetail={3}&videoAssetDetail={4}&documentAssetDetail={5}&includeItemInStoreMetadata={6}", id, includeItemStaticProperties, includeItemDynamicProperties, (int)imageAssetDetail, (int)videoAssetDetail, (int)documentAssetDetail, includeItemInStoreMetadata);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<SingleItemSearchResult<Item>>>().ConfigureAwait(false);
            }
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/item/fetching-navigation-and-search-options-for-items")]
        public async Task<ApiResponse<Navigation>> GetSearchOptionsAsync(ItemSearchOptionsRequest itemSearchOptionsRequest)
        {
            Validator.For(itemSearchOptionsRequest, "itemSearchOptionsRequest").IsNotNull().IsValid();

            string path = "/catalog/itemsearchoptions";

            using (var response = await Client.PostAsJsonAsync(path, itemSearchOptionsRequest).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<Navigation>>().ConfigureAwait(false);
            }
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/item/searching-items")]
        public async Task<ApiResponse<ItemSearchResult<MultipleItemSearchResult<Item>>>> SearchAsync(ItemSearchRequest itemSearchRequest, bool includeItemInStoreMetadata = false)
        {
            Validator.For(itemSearchRequest, "itemSearchRequest").IsNotNull().IsValid();


            string path = string.Format("/catalog/items?includeItemInStoreMetadata={0}", includeItemInStoreMetadata);

            using (var response = await Client.PostAsJsonAsync(path, itemSearchRequest).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<ItemSearchResult<MultipleItemSearchResult<Item>>>>().ConfigureAwait(false);
            }
        }
    }
}