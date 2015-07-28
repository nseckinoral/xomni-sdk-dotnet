using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.PII;
using XOMNI.SDK.Public.Extensions;
using XOMNI.SDK.Public.Infrastructure;

namespace XOMNI.SDK.Public.Clients.PII
{
	public class AnonymousClient : BaseClient
	{
		public AnonymousClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/pii/anonymous/requesting-an-anonymous-pii")]
		public async Task<ApiResponse<AnonymousUser>> PostAsync(AnonymousUserRequest anonymousUser)
		{
            Validator.For(anonymousUser.UserName, "UserName").IsNotNullOrEmpty();

			string path = "/pii/anonymous";

            using (var response = await Client.PostAsJsonAsync(path, anonymousUser).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<AnonymousUser>>().ConfigureAwait(false);
			}
		}
	}
}