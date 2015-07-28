using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Social;
using XOMNI.SDK.Public.Extensions;
using XOMNI.SDK.Public.Infrastructure;

namespace XOMNI.SDK.Public.Clients.Social
{
	public class TokenClient : BaseClient
	{
		public TokenClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/social/token/checking-if-xomni-has-a-valid-token")]
		public async Task<ApiResponse<Dictionary<string, string>>> GetAsync(SocialPlatformType socialPlatform)
		{
            ValidatePIIToken();
			string path = string.Format("/social/token/{0}", socialPlatform.ToString().ToLowerInvariant());

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<Dictionary<string, string>>>().ConfigureAwait(false);
			}
		}

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/social/token/assigning-a-social-token-for-a-pii-user")]
		public async Task<ApiResponse<Dictionary<string, string>>> PostAsync(SocialPlatformType socialPlatform, string token = null,string oauthToken = null,string oauthVerifier = null)
		{
            ValidatePIIToken();
            Dictionary<string, string> request = new Dictionary<string, string>();

            switch(socialPlatform)
            {
                case SocialPlatformType.Facebook:
                    Validator.For(token, "token").IsNotNullOrEmpty();
                    
                    if(!string.IsNullOrEmpty(oauthToken) || !string.IsNullOrEmpty(oauthVerifier))
                    {
                        throw new ArgumentException("You can not pass token and oauthToken/oauthVerifier at the same time.");
                    }
                    request.Add("access_token", token);
                    break;

                case SocialPlatformType.Twitter:
                    Validator.For(oauthToken, "oauthToken").IsNotNullOrEmpty();
                    Validator.For(oauthVerifier, "oauthVerifier").IsNotNullOrEmpty();

                    if(!string.IsNullOrEmpty(token))
                    {
                        throw new ArgumentException("You can not pass oauthToken/oauthVerifier and token at the same time.");
                    }

                    request.Add("oauth_token", oauthToken);
                    request.Add("oauth_verifier", oauthVerifier);
                    break;
            }

			string path = string.Format("/social/token/{0}", socialPlatform.ToString().ToLowerInvariant());

			using (var response = await Client.PostAsJsonAsync(path, request).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<Dictionary<string, string>>>().ConfigureAwait(false);
			}
		}
	}
}