using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Social;
using XOMNI.SDK.Public.Extensions;
using XOMNI.SDK.Public.Infrastructure;

namespace XOMNI.SDK.Public.Clients.Social
{
    public class PostClient : BaseClient
    {
        public PostClient(HttpClient httpClient)
            : base(httpClient)
        {

        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/social/post/getting-a-social-post-and-related-comments")]
		public async Task<ApiResponse<SocialPost>> GetAsync(int relatedItemId)
        {
            ValidatePIIToken();
            Validator.For(relatedItemId, "relatedItemId").IsGreaterThanOrEqual(1);

            string path = string.Format("/social/post?relatedItemId={0}", relatedItemId);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<SocialPost>>().ConfigureAwait(false);
            }
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/social/post/deleting-a-social-post")]
		public async Task<ApiResponse<SocialPost>> DeleteAsync(int socialPostId)
        {
            ValidatePIIToken();
            Validator.For(socialPostId, "socialPostId").IsGreaterThanOrEqual(1);

            string path = string.Format("/social/post/{0}", socialPostId);

            using (var response = await Client.DeleteAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<SocialPost>>().ConfigureAwait(false);
            }

        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/social/post/posting-a-social-message-for-a-product")]
		public async Task<ApiResponse<SocialPost>> PostAsync(SocialPostRequest socialPostRequest)
        {
            Validator.For(socialPostRequest, "socialPostRequest").IsNotNull();
            Validator.For(socialPostRequest.RelatedItemId, "RelatedItemId").IsGreaterThanOrEqual(1);
            Validator.For(socialPostRequest.Content, "Content").IsNotNullOrEmpty();

            string path = "/social/post";

            using (var response = await Client.PostAsJsonAsync(path, socialPostRequest).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<SocialPost>>().ConfigureAwait(false);
            }
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/social/post/fetching-policies-for-social-post-operation")]
		public async Task<ApiResponse<SocialPolicy>> GetPoliciesAsync()
        {
            ValidatePIIToken();

            string path = "/social/post/policies";

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<SocialPolicy>>().ConfigureAwait(false);
            }
        }
    }
}