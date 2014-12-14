using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;

namespace XOMNI.SDK.Public.Clients.Catalog
{
	public class ItemMetadataClient : BaseClient
	{
		public ItemMetadataClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

		public async Task<ApiResponse<Metadata>> GetAsync(int itemId)
		{
			string path = string.Format("/catalog/itemmetadata?itemId={0}", itemId);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
				return await response.Content.ReadAsAsync<ApiResponse<Metadata>>().ConfigureAwait(false);
			}
		}
	}
}