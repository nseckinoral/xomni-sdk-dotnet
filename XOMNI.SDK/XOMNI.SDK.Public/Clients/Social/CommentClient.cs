using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Social;
using XOMNI.SDK.Public.Extensions;

namespace XOMNI.SDK.Public.Clients.Social
{
	public class CommentClient : BaseClient
	{
		public CommentClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

        public async Task<ApiResponse<SocialComment>> DeleteAsync(int commentId)
		{
            ValidatePIIToken();
            Validator.For(commentId, "commentId").IsGreaterThanOrEqual(1);

			string path = string.Format("social/comment/{0}", commentId);

            using (var response = await Client.DeleteAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<SocialComment>>().ConfigureAwait(false);
            }
		}

		public async Task<ApiResponse<SocialComment>> PostCommentAsync(SocialCommentToCommentRequest comment)
		{
            ValidatePIIToken();
            Validator.For(comment.TargetCommentId, "TargetCommentId").IsGreaterThanOrEqual(1);
            Validator.For(comment.Content, "Content").IsNotNullOrEmpty();

			string path = "/social/comment";

			using (var response = await Client.PostAsJsonAsync(path, comment).ConfigureAwait(false))
			{
				return await response.Content.ReadAsAsync<ApiResponse<SocialComment>>().ConfigureAwait(false);
			}
		}

		public async Task<ApiResponse<SocialComment>> PostCommentAsync(SocialCommentToPostRequest comment)
		{
            ValidatePIIToken();
            Validator.For(comment.TargetPostId, "TargetPostId").IsGreaterThanOrEqual(1);
            Validator.For(comment.Content, "Content").IsNotNullOrEmpty();

			string path = "/social/comment";

            using (var response = await Client.PostAsJsonAsync(path, comment).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<SocialComment>>().ConfigureAwait(false);
            }
        }

        public async Task<ApiResponse<SocialPolicy>> GetPoliciesAsync(int targetPostId, int targetCommentId)
        {
            ValidatePIIToken();
            Validator.For(targetPostId, "targetPostId").IsGreaterThanOrEqual(1);
            Validator.For(targetCommentId, "targetCommentId").IsGreaterThanOrEqual(1);

            string path = string.Format("/social/comment/policies?targetPostId={0}&targetCommentId={1}", targetPostId, targetCommentId);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<SocialPolicy>>().ConfigureAwait(false);
            }
        }

	}
}
