using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Extensions;

namespace XOMNI.SDK.Public.Clients.PII
{
	public class WishlistPassbookClient : BaseClient
	{
		public WishlistPassbookClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

        public async Task<ApiResponse<byte[]>> GetAsync(Guid wishlistUniqueKey, string templateName)
		{
            ValidatePIIToken();

			string path = string.Format("/pii/wishlist/{0}", wishlistUniqueKey.ToString());

            Validator.For(templateName, "templateName").IsNotNullOrEmpty();
            path += string.Format("/passbook?templateName={0}", templateName.ToString());

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<byte[]>>().ConfigureAwait(false);
			}
		}
	}
} 