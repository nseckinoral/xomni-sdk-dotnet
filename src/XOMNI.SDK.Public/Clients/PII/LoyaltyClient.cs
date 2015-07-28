using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Infrastructure;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.PII;

namespace XOMNI.SDK.Public.Clients.PII
{
	public class LoyaltyClient : BaseClient
	{
		public LoyaltyClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/pii/loyalty/fetching-a-particular-loyalty-user")]
		public async Task<ApiResponse<LoyaltyUser>> GetAsync()
		{
            ValidatePIIToken();

			string path = "/pii/loyalty";

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<LoyaltyUser>>().ConfigureAwait(false);
			}
		}
	}
}