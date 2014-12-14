using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;

namespace XOMNI.SDK.Public.Clients.PII
{
	public class ShoppingCartPassbookClient : BaseClient
	{
		public ShoppingCartPassbookClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

		public async Task<dynamic> GetAsync(string shoppingCartUniqueKey)
		{
			string path = string.Format("/pii/shoppingcart/{shoppingcartUniqueKey}/passbook?/pii/shoppingcart/{0}", shoppingCartUniqueKey);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
				return await response.Content.ReadAsAsync<dynamic>().ConfigureAwait(false);
			}
		}
	}
}