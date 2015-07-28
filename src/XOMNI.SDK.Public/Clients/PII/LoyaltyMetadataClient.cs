using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Infrastructure;
using XOMNI.SDK.Public.Models;

namespace XOMNI.SDK.Public.Clients.PII
{
	public class LoyaltyMetadataClient : BaseClient
	{
		public LoyaltyMetadataClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/pii/loyalty-metadata/fetching-all-metadata-of-a-loyalty-user")]
		public async Task<ApiResponse<List<Metadata>>> GetAsync()
		{
            ValidatePIIToken(); 

			string path = "/pii/loyaltymetadata";

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<List<Metadata>>>().ConfigureAwait(false);
			}
		}
	}
}