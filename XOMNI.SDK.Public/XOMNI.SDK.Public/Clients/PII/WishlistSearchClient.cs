using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.PII;
using XOMNI.SDK.Public.Extensions;

namespace XOMNI.SDK.Public.Clients.PII
{
	public class WishlistSearchClient : BaseClient
	{
		public WishlistSearchClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

        public async Task<ApiResponse<List<Guid>>> PostAsync(WishlistSearchRequest searchRequest)
		{
            Validator.For(searchRequest, "searchRequest").IsNotNull();
            Validator.For(searchRequest.TimeInterval, "TimeInterval").InRange(0, 30);
            Validator.For(searchRequest.MaxDistance, "MaxDistance").InRange(0, 1);

            if (searchRequest.Location != null)
            {
                Validator.For(searchRequest.Location.Latitude, "Latitude").InRange(-90, 90);
                Validator.For(searchRequest.Location.Longitude, "Longitude").InRange(-180, 180);
            }

			string path = "/pii/wishlistsearch";

            using (var response = await Client.PostAsJsonAsync(path, searchRequest).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<List<Guid>>>().ConfigureAwait(false);
			}
		}
	}
}