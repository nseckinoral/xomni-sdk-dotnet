using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;

namespace XOMNI.SDK.Public.Clients.PII
{
	public class ShoppingCartSearchClient : BaseClient
	{
		public ShoppingCartSearchClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

		public async Task<dynamic> PostAsync(object  body)
		{
			string path = "/pii/shoppingcartsearch";

			using (var response = await Client.PostAsJsonAsync(path, body).ConfigureAwait(false))
			{
				return await response.Content.ReadAsAsync<dynamic>().ConfigureAwait(false);
			}
		}
	}
}