using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.PII;
using XOMNI.SDK.Public.Extensions;
using XOMNI.SDK.Public.Infrastructure;

namespace XOMNI.SDK.Public.Clients.PII
{
	public class ShoppingCartSearchClient : BaseClient
	{
		public ShoppingCartSearchClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/pii/shopping-cart-search/fetching-nearby-active-shopping-carts-to-a-gps-location")]
		public async Task<ApiResponse<List<Guid>>> PostAsync(ShoppingCartSearchRequest searchRequest)
		{
            Validator.For(searchRequest, "searchRequest").IsNotNull();
            Validator.For(searchRequest.TimeInterval, "TimeInterval").InRange(0, 30);
            Validator.For(searchRequest.MaxDistance, "MaxDistance").InRange(0, 1);
            
            if(searchRequest.Location != null)
            {
                Validator.For(searchRequest.Location.Latitude, "Latitude").InRange(-90, 90);
                Validator.For(searchRequest.Location.Longitude, "Longitude").InRange(-180, 180);
            }

			string path = "/pii/shoppingcartsearch";

            using (var response = await Client.PostAsJsonAsync(path, searchRequest).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<List<Guid>>>().ConfigureAwait(false);
			}
		}
	}
}