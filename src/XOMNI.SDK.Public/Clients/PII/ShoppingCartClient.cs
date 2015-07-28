using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.PII;
using XOMNI.SDK.Public.Extensions;
using XOMNI.SDK.Public.Models.Catalog;
using XOMNI.SDK.Public.Infrastructure;

namespace XOMNI.SDK.Public.Clients.PII
{
    public class ShoppingCartClient : BaseClient
    {
        public ShoppingCartClient(HttpClient httpClient)
            : base(httpClient)
        {

        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/pii/shopping-cart/deleting-a-shopping-cart")]
        public async Task DeleteAsync(Guid shoppingCartUniqueKey)
        {
            ValidatePIIToken();
            string path = string.Format("/pii/shoppingcart?shoppingCartUniqueKey={0}", shoppingCartUniqueKey);
            await Client.DeleteAsync(path).ConfigureAwait(false);
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/pii/shopping-cart/changing-shopping-cart-access-information")]
        public async Task PostAccessAsync(Guid shoppingCartUniqueKey, bool isPublic)
        {
            ValidatePIIToken();
            string path = string.Format("/pii/shoppingcartaccess?shoppingCartUniqueKey={0}&isPublic={1}", shoppingCartUniqueKey, isPublic);
            await Client.PostAsJsonAsync(path, string.Empty).ConfigureAwait(false);
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/pii/shopping-cart/fetching-all-shopping-carts")]
		public async Task<ApiResponse<List<Guid>>> GetAsync()
        {
            string path = "/pii/shoppingcarts";

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<List<Guid>>>().ConfigureAwait(false);
            }
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/pii/shopping-cart/clearing-all-items-in-a-shopping-carts")]
        public async Task DeleteAsync()
        {
            ValidatePIIToken();
            string path = "/pii/shoppingcarts";
            await Client.DeleteAsync(path).ConfigureAwait(false);
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/pii/shopping-cart/fetching-a-shopping-cart-with-a-shopping-cart-unique-key")]
		public async Task<ApiResponse<ShoppingCartWithItems>> GetAsync(Guid shoppingCartUniqueKey, Location location = null, bool includeItemStaticProperties = true, bool includeItemDynamicProperties = false, bool includeCategoryMetadata = false, AssetDetailType imageAssetDetail = AssetDetailType.None, AssetDetailType videoAssetDetail = AssetDetailType.None, AssetDetailType documentAssetDetail = AssetDetailType.None, string metadataKey = null, string metadataValue = null)
        {
            ValidatePIIToken();
            string path = string.Format("/pii/shoppingcart?shoppingCartUniqueKey={0}&",shoppingCartUniqueKey);

            if (location != null)
            {
                Validator.For(location.Longitude, "Longitude").InRange(-180, 180);
                Validator.For(location.Latitude, "Latitude").InRange(-90, 90);
                path+=string.Format("longitude={0}&latitude={1}&",location.Longitude,location.Latitude);
            }
            path += string.Format("includeItemStaticProperties={0}&includeItemDynamicProperties={1}&includeCategoryMetadata={2}&imageAssetDetail={3}&videoAssetDetail={4}&documentAssetDetail={5}",includeItemStaticProperties,includeItemDynamicProperties,includeCategoryMetadata,(int)imageAssetDetail,(int)videoAssetDetail,(int)documentAssetDetail);

            if(!string.IsNullOrEmpty(metadataKey) && !string.IsNullOrEmpty(metadataValue))
            {
                path += string.Format("&metadataKey={0}&metadataValue={1}",metadataKey,metadataValue);
            }
            else if(!string.IsNullOrEmpty(metadataKey) || !string.IsNullOrEmpty(metadataValue))
            {
                Validator.For(metadataKey, "metadataKey").IsNotNullOrEmpty();
                Validator.For(metadataValue, "metadataValue").IsNotNullOrEmpty();
            }

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<ShoppingCartWithItems>>().ConfigureAwait(false);
            }
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/pii/shopping-cart/creating-a-shopping-cart")]
		public async Task<ApiResponse<ShoppingCart>> PostShoppingCartAsync(ShoppingCart shoppingCart)
        {
            ValidatePIIToken();
            Validator.For(shoppingCart, "shoppingCart").IsNotNull();
            if (shoppingCart.LastSeenLocation != null)
            {
                Validator.For(shoppingCart.LastSeenLocation.Latitude, "Latitude").InRange(-90, 90);
                Validator.For(shoppingCart.LastSeenLocation.Longitude, "Longitude").InRange(-180, 180);
            }
            string path = "/pii/shoppingcart";

            using (var response = await Client.PostAsJsonAsync(path, shoppingCart).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<ShoppingCart>>().ConfigureAwait(false);
            }
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/pii/shopping-cart/changing-shopping-cart-name")]
		public async Task<ApiResponse<ShoppingCart>> PutAsync(ShoppingCart shoppingCart)
        {
            ValidatePIIToken();
            Validator.For(shoppingCart, "shoppingCart").IsNotNull();
            if (shoppingCart.LastSeenLocation != null)
            {
                Validator.For(shoppingCart.LastSeenLocation.Latitude, "Latitude").InRange(-90, 90);
                Validator.For(shoppingCart.LastSeenLocation.Longitude, "Longitude").InRange(-180, 180);
            }
            string path = "/pii/shoppingcart";

            using (var response = await Client.PutAsJsonAsync(path, shoppingCart).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<ShoppingCart>>().ConfigureAwait(false);
            }
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/pii/shopping-cart/emailing-a-shopping-cart")]
        public async Task PostMailAsync(MailSendRequest mailSendRequest)
        {
            ValidatePIIToken();
            Validator.For(mailSendRequest, "mailSendRequest").IsNotNull();

            string path = "/pii/shoppingcart/mail";
            await Client.PostAsJsonAsync(path, mailSendRequest).ConfigureAwait(false);
        }
    }
}