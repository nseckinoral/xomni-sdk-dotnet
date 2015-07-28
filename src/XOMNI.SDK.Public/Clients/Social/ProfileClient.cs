using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Infrastructure;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Social;

namespace XOMNI.SDK.Public.Clients.Social
{
	public class ProfileClient : BaseClient
	{
		public ProfileClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/social/profile/fetching-social-platform-profiles")]
		public async Task<ApiResponse<List<SocialProfile>>> GetAsync()
		{
            ValidatePIIToken();

			string path = "/social/profiles";

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
				return await response.Content.ReadAsAsync<ApiResponse<List<SocialProfile>>>().ConfigureAwait(false);
			}
		}
	}
}