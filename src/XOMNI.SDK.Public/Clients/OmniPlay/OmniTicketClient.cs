using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.OmniPlay;
using XOMNI.SDK.Public.Extensions;
using XOMNI.SDK.Public.Infrastructure;

namespace XOMNI.SDK.Public.Clients.OmniPlay
{
    public class OmniTicketClient : BaseClient
    {
        public OmniTicketClient(HttpClient httpClient)
            : base(httpClient)
        {

        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/omniplay/omniticket/generating-omniticket-for-a-pii")]
		public async Task<ApiResponse<OmniTicket>> GetTicketAsync()
        {
            ValidatePIIToken();
            string path = "/omniplay/pii/ticket";

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<OmniTicket>>().ConfigureAwait(false);
            }
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/omniplay/omniticket/fetching-all-pii-sessions-generated-by-omniticket")]
		public async Task<ApiResponse<List<OmniSession>>> GetSessionAsync()
        {
            ValidatePIIToken();
            string path = "/omniplay/pii/session";

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<List<OmniSession>>>().ConfigureAwait(false);
            }
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/omniplay/omniticket/deleting-pii-sessions")]
        public async Task DeleteAsync()
        {
            ValidatePIIToken();
            string path = "/omniplay/pii/session";
            await Client.DeleteAsync(path).ConfigureAwait(false);
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/omniplay/omniticket/generation-omniticket-for-a-wishlist")]
		public async Task<ApiResponse<OmniTicket>> GetAsync(Guid wishlistUniqueKey)
        {
            ValidatePIIToken();
            string path = string.Format("/omniplay/wishlist/ticket?wishlistUniqueKey={0}", wishlistUniqueKey);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<OmniTicket>>().ConfigureAwait(false);
            }
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/omniplay/omniticket/using-omniticket-for-a-pii")]
		public async Task<ApiResponse<OmniSession>> PostSessionAsync(OmniTicket omniTicket)
        {
            string path = "/omniplay/pii/session";

            using (var response = await Client.PostAsJsonAsync(path, omniTicket).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<OmniSession>>().ConfigureAwait(false);
            }
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/omniplay/omniticket/using-omniticket-for-a-wishlist")]
		public async Task<ApiResponse<WishlistImportResponse>> PostImportAsync(WishlistImportRequest wishlistImportRequest)
        {
            ValidatePIIToken();

            if (wishlistImportRequest.GpsLocation != null)
            {
                Validator.For(wishlistImportRequest.GpsLocation.Latitude, "Latitude").InRange(-90, 90);
                Validator.For(wishlistImportRequest.GpsLocation.Longitude, "Longitude").InRange(-180, 180);
            }
            string path = "/pii/wishlist/import";

            using (var response = await Client.PostAsJsonAsync(path, wishlistImportRequest).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<WishlistImportResponse>>().ConfigureAwait(false);
            }
        }
    }
}