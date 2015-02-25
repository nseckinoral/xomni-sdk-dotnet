using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Extensions;

namespace XOMNI.SDK.Public.Clients.PII
{
	public class ShoppingCartPassbookClient : BaseClient
	{
		public ShoppingCartPassbookClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

        public async Task<ApiResponse<byte[]>> GetAsync(Guid shoppingCartUniqueKey, string templateName)
		{
            ValidatePIIToken();

            string path = string.Format("/pii/shoppingcart/{0}", shoppingCartUniqueKey.ToString());

            Validator.For(templateName, "templateName").IsNotNullOrEmpty();
            path += string.Format("/passbook?templateName={0}", templateName.ToString());

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<byte[]>>().ConfigureAwait(false);
			}
		}
	}
}