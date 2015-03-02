using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Catalog;
using XOMNI.SDK.Public.Extensions;

namespace XOMNI.SDK.Public.Clients.Catalog
{
    public class ItemClient : BaseClient
    {
        public ItemClient(HttpClient httpClient)
            : base(httpClient)
        {

        }

        public async Task<ApiResponse<SingleItemSearchResult<Item>>> GetAsync(int id, bool includeItemInStoreMetadata = false, bool includeItemStaticProperties = true, bool includeItemDynamicProperties = true, AssetDetailType imageAssetDetail = AssetDetailType.None, AssetDetailType videoAssetDetail = AssetDetailType.None, AssetDetailType documentAssetDetail = AssetDetailType.None)
        {
            Validator.For(id, "id").IsGreaterThanOrEqual(1);

            string path = string.Format("/catalog/item/{0}?includeItemStaticProperties={1}&includeItemDynamicProperties={2}&imageAssetDetail={3}&videoAssetDetail={4}&documentAssetDetail={5}&includeItemInStoreMetadata={6}", id, includeItemStaticProperties, includeItemDynamicProperties, (int)imageAssetDetail, (int)videoAssetDetail, (int)documentAssetDetail, includeItemInStoreMetadata);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<SingleItemSearchResult<Item>>>().ConfigureAwait(false);
            }
        }

        public async Task<ApiResponse<Navigation>> GetSearchOptions(ItemSearchOptionsRequest itemSearchOptionsRequest)
        {
            Validator.For(itemSearchOptionsRequest, "itemSearchOptionsRequest").IsNotNull().InRange();
            Validator.For(itemSearchOptionsRequest.Skip, "Skip").IsGreaterThanOrEqual(0);
            Validator.For(itemSearchOptionsRequest.Take, "Take").InRange(1, 1000);
            
            if(!string.IsNullOrEmpty(itemSearchOptionsRequest.DelimitedDynamicAttributeValues))
            {
                Validator.For(itemSearchOptionsRequest.DelimitedDynamicAttributeValues, "DelimitedDynamicAttriuteValues").KeyValuePairValid(';', ':');
            }

            if (itemSearchOptionsRequest.MinWeight.HasValue && itemSearchOptionsRequest.MaxWeight.HasValue)
            {
                Validator.For(itemSearchOptionsRequest.WeightTypeId, "WeightTypeId").IsNotNull();
            }

            if (itemSearchOptionsRequest.MinWidth.HasValue && itemSearchOptionsRequest.MinHeight.HasValue && itemSearchOptionsRequest.MinDepth.HasValue)
            {
                Validator.For(itemSearchOptionsRequest.DimensionTypeId, "DimensionTypeId").IsNotNull();
            }

            string path = "/catalog/itemsearchoptions";

            using (var response = await Client.PostAsJsonAsync(path, itemSearchOptionsRequest).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<Navigation>>().ConfigureAwait(false);
            }
        }

        public async Task<ApiResponse<MultipleItemSearchResult<Item>>> Search(ItemSearchRequest itemSearchRequest, bool includeItemInStoreMetadata = false)
        {
            Validator.For(itemSearchRequest, "itemSearchRequest").IsNotNull().InRange();
            Validator.For(itemSearchRequest.Skip, "Skip").IsGreaterThanOrEqual(0);
            Validator.For(itemSearchRequest.Take, "Take").IsGreaterThanOrEqual(1);

            if(!string.IsNullOrEmpty(itemSearchRequest.DelimitedDynamicAttributeValues))
            {
                Validator.For(itemSearchRequest.DelimitedDynamicAttributeValues, "DelimitedDynamicAttributeValues").KeyValuePairValid(';', ':');
            }

            if (itemSearchRequest.MinWeight.HasValue && itemSearchRequest.MaxWeight.HasValue)
            {
                Validator.For(itemSearchRequest.WeightTypeId, "WeightTypeId").IsNotNull();
            }

            if (itemSearchRequest.MinWidth.HasValue && itemSearchRequest.MinHeight.HasValue && itemSearchRequest.MinDepth.HasValue)
            {
                Validator.For(itemSearchRequest.DimensionTypeId, "DimensionTypeId").IsNotNull();
            }

            string path = string.Format("/catalog/items?includeItemInStoreMetadata={0}", includeItemInStoreMetadata);

            using (var response = await Client.PostAsJsonAsync(path, itemSearchRequest).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<MultipleItemSearchResult<Item>>>().ConfigureAwait(false);
            }
        }
    }
}