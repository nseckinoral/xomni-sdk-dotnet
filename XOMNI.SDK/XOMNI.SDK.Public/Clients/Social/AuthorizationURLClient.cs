using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Social;

namespace XOMNI.SDK.Public.Clients.Social
{
	public class AuthorizationURLClient : BaseClient
	{
		public AuthorizationURLClient(HttpClient httpClient)
			: base(httpClient)
		{

		}
        public async Task<ApiResponse<string>> GetAsync(SocialPlatformType socialPlatformName)
		{
            ValidatePIIToken();

			string path = string.Format("/social/authurl/{0}", socialPlatformName.ToString().ToLowerInvariant());

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<string>>().ConfigureAwait(false);
			}
		}
	}
}