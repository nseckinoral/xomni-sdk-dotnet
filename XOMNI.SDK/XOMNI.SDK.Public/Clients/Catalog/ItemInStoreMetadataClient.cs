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

        public async Task<ApiResponse<List<Metadata>>> GetAsync(int id, int skip, int take, string key = null, string value = null)
		{
            Validator.For(id, "id").IsGreaterThanOrEqual(1);
            
            string path = string.Format("/catalog/items/{0}/storemetadata?", id);
            if(!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
            {
                path += string.Format("key={0}&value={1}&", key, value);
            }

            else if (!string.IsNullOrEmpty(key) || !string.IsNullOrEmpty(value))
            {
                Validator.For(key, "key").IsNotNullOrEmpty();
                Validator.For(value, "value").IsNotNullOrEmpty();
            }

            Validator.For(skip, "skip").IsGreaterThanOrEqual(0);
            Validator.For(take, "take").IsGreaterThanOrEqual(1);

            path += string.Format("skip={0}&take={1}",skip,take);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<List<Metadata>>>().ConfigureAwait(false);
			}
		}
    }
}
