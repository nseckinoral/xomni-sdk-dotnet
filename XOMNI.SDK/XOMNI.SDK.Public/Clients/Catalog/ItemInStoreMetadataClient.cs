using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Catalog;
using XOMNI.SDK.Public.Extensions;

namespace XOMNI.SDK.Public.Clients.Catalog
{
    public class ItemInStoreMetadataClient : BaseClient
    {
        public ItemInStoreMetadataClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

		public async Task<ApiResponse<List<Metadata>>> GetAsync(int id, string key, string value,int skip,int take)
		{
            Validator.For(id, "id").IsGreaterThanOrEqual(1);
            Validator.For(key, "key").IsNotNullOrEmpty();
            Validator.For(value, "value").IsNotNullOrEmpty();
            Validator.For(skip, "skip").IsGreaterThanOrEqual(0);
            Validator.For(take, "take").IsGreaterThanOrEqual(1);

			string path = string.Format("/catalog/items/{0}/storemetadata?key={1}&value={2}&skip={3}&take={4}", id, key, value,skip,take);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<List<Metadata>>>().ConfigureAwait(false);
			}
		}
    }
}
