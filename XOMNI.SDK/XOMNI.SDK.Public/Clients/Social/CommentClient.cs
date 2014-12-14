using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Social;

namespace XOMNI.SDK.Public.Clients.Social
{
	public class CommentClient : BaseClient
	{
		public CommentClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

		public async Task DeleteAsync(int commentId)
		{
			string path = string.Format("social/comment/{0}", commentId);
            await Client.DeleteAsync(path).ConfigureAwait(false);
		}

        public async Task<ApiResponse<SocialComment>> PostCommentAsync(SocialCommentToCommentRequest comment)
		{
			string path = "/social/comment";

            using (var response = await Client.PostAsJsonAsync(path, comment).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<SocialComment>>().ConfigureAwait(false);
			}
		}

        public async Task<ApiResponse<SocialComment>> PostCommentAsync(SocialCommentToPostRequest comment)
        {
            string path = "/social/comment";

            using (var response = await Client.PostAsJsonAsync(path, comment).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<SocialComment>>().ConfigureAwait(false);
            }
        }
	}
}