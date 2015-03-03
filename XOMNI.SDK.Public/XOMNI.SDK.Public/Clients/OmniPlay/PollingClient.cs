using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.OmniPlay;
using XOMNI.SDK.Public.Models.PII;
using XOMNI.SDK.Public.Extensions;
using XOMNI.SDK.Public.Models.Catalog;

namespace XOMNI.SDK.Public.Clients.OmniPlay
{
	public class PollingClient : BaseClient
	{
		public PollingClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

        public async Task<ApiResponse<WishlistWithItems>> GetWishlistAsync(Guid wishlistUniqueKey, Location location = null, bool includeItemStaticProperties = true, bool includeItemDynamicProperties = false, bool includeCategoryMetadata = false, AssetDetailType imageAssetDetail = AssetDetailType.None, AssetDetailType videoAssetDetail = AssetDetailType.None, AssetDetailType documentAssetDetail = AssetDetailType.None, string metadataKey = null, string metadataValue = null)
		{
            string path = string.Format("/omniplay/wishlist?wishlistUniqueKey={0}&", wishlistUniqueKey.ToString());

			if (location != null)
            {
                Validator.For(location.Latitude, "Latitude").InRange(-90, 90);
                Validator.For(location.Longitude, "Longitude").InRange(-180, 180);
                path += string.Format("longitude={0}&latitude={1}&", location.Longitude.ToString(), location.Latitude.ToString());
            }
            path += string.Format("includeItemStaticProperties={0}&includeItemDynamicProperties={1}&includeCategoryMetadata={2}&imageAssetDetail={3}&videoAssetDetail={4}&documentAssetDetail={5}", includeItemStaticProperties, includeItemDynamicProperties, includeCategoryMetadata, (int)imageAssetDetail, (int)videoAssetDetail, (int)documentAssetDetail);

            if(!string.IsNullOrEmpty(metadataKey) && !string.IsNullOrEmpty(metadataValue))
            {
                path += string.Format("&metadataKey={0}&metadataValue={1}", metadataKey, metadataValue);
            }
            else if(!string.IsNullOrEmpty(metadataKey) || !string.IsNullOrEmpty(metadataValue))
            {
                Validator.For(metadataKey, "metadataKey").IsNotNullOrEmpty();
                Validator.For(metadataValue, "metadataValue").IsNotNullOrEmpty();
            }
            using (var response = await Client.GetAsync(path).ConfigureAwait(false))

			{
                return await response.Content.ReadAsAsync<ApiResponse<WishlistWithItems>>().ConfigureAwait(false);
			}
		}

        public async Task<ApiResponse<ShoppingCartWithItems>> GetShoppingcartAsync(Guid shoppingcartUniqueKey, Location location = null, bool includeItemStaticProperties = true, bool includeItemDynamicProperties = false, bool includeCategoryMetadata = false, AssetDetailType imageAssetDetail = AssetDetailType.None, AssetDetailType videoAssetDetail = AssetDetailType.None, AssetDetailType documentAssetDetail = AssetDetailType.None, string metadataKey = null, string metadataValue = null)
		{
            string path = string.Format("/omniplay/shoppingcart?shoppingCartUniqueKey={0}&", shoppingcartUniqueKey.ToString());
            if (location != null)
            {
                Validator.For(location.Latitude, "Latitude").InRange(-90, 90);
                Validator.For(location.Longitude, "Longitude").InRange(-180, 180);
                path += string.Format("longitude={0}&latitude={1}&", location.Longitude.ToString(), location.Latitude.ToString());
            }
            path += string.Format("includeItemStaticProperties={0}&includeItemDynamicProperties={1}&includeCategoryMetadata={2}&imageAssetDetail={3}&videoAssetDetail={4}&documentAssetDetail={5}", includeItemStaticProperties, includeItemDynamicProperties, includeCategoryMetadata, (int)imageAssetDetail, (int)videoAssetDetail, (int)documentAssetDetail);

            if (!string.IsNullOrEmpty(metadataKey) && !string.IsNullOrEmpty(metadataValue))
            {
                path += string.Format("&metadataKey={0}&metadataValue={1}", metadataKey, metadataValue);
            }
            else if (!string.IsNullOrEmpty(metadataKey) || !string.IsNullOrEmpty(metadataValue))
            {
                Validator.For(metadataKey, "metadataKey").IsNotNullOrEmpty();
                Validator.For(metadataValue, "metadataValue").IsNotNullOrEmpty();
            }
            using (var response = await Client.GetAsync(path).ConfigureAwait(false))

			{
                return await response.Content.ReadAsAsync<ApiResponse<ShoppingCartWithItems>>().ConfigureAwait(false);
			}
		}
	}
}