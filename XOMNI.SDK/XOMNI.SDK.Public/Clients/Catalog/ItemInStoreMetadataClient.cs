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

        public async Task<ApiResponse<List<InStoreMetadata>>> GetAsync(int id, int skip, int take, string key = null, string value = null, string keyPrefix = null, bool companyWide = false)
        {
            Validator.For(id, "id").IsGreaterThanOrEqual(1);

            string path = string.Format("/catalog/items/{0}/storemetadata?", id);
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
            {
                path += string.Format("key={0}&value={1}&", key, value);
            }
            else if (!string.IsNullOrEmpty(key) || !string.IsNullOrEmpty(value))
            {
                Validator.For(key, "key").IsNotNullOrEmpty();
                Validator.For(value, "value").IsNotNullOrEmpty();
            }

            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(keyPrefix))
            {
                throw new ArgumentException("Key and keyPrefix parameters cannot be sent at the same time in a metadata query.");
            }

            if (!string.IsNullOrEmpty(keyPrefix))
            {
                path += string.Format("keyPrefix={0}&", keyPrefix);
            }

            Validator.For(skip, "skip").IsGreaterThanOrEqual(0);
            Validator.For(take, "take").IsGreaterThanOrEqual(1);

            path += string.Format("skip={0}&take={1}&companyWide={2}", skip, take, companyWide);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<List<InStoreMetadata>>>().ConfigureAwait(false);
            }
        }
    }
}
