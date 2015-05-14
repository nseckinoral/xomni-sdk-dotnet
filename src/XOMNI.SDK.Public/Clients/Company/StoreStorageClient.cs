using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Extensions;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Company;

namespace XOMNI.SDK.Public.Clients.Company
{
    public class StoreStorageClient : BaseClient
    {
        public StoreStorageClient(HttpClient httpClient)
            : base(httpClient)
        {

        }

        public async Task<ApiResponse<List<StoreStorageItem>>> GetAsync(int storeId = 0, string key = null)
        {
            Validator.For(storeId, "storeId").IsGreaterThanOrEqual(0);

            string path = string.Format("/company/stores/{0}/storage?", storeId == 0 ? "current" : storeId.ToString());

            if (!string.IsNullOrEmpty(key))
            {
                path += string.Format("key={0}&", key);
            }
            
            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<List<StoreStorageItem>>>().ConfigureAwait(false);
            }
        }

        public async Task DeleteAsync(int storeId = 0, string key = null)
        {
            Validator.For(storeId, "storeId").IsGreaterThanOrEqual(0);

            string path = string.Format("/company/stores/{0}/storage?", storeId == 0 ? "current" : storeId.ToString());

            if (!string.IsNullOrEmpty(key))
            {
                path += string.Format("?key={0}", key);
            }

            await Client.DeleteAsync(path).ConfigureAwait(false);
        }

        public async Task<ApiResponse<StoreStorageItem>> PostAsync(StoreStorageItem storageItem)
        {
            Validator.For(storageItem, "storageItem").IsNotNull();
            Validator.For(storageItem.StoreId, "StoreId").IsGreaterThanOrEqual(0);

            string path = string.Format("/company/stores/{0}/storage", storageItem.StoreId == 0 ? "current" : storageItem.StoreId.ToString());

            using (var response = await Client.PostAsJsonAsync(path, storageItem).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<StoreStorageItem>>().ConfigureAwait(false);
            }
        }

        public async Task<ApiResponse<StoreStorageItem>> PutAsync(StoreStorageItem storageItem)
        {
            Validator.For(storageItem, "storageItem").IsNotNull(); 
            Validator.For(storageItem.StoreId, "StoreId").IsGreaterThanOrEqual(0);

            string path = string.Format("/company/stores/{0}/storage", storageItem.StoreId == 0 ? "current" : storageItem.StoreId.ToString());
            
            using (var response = await Client.PutAsJsonAsync(path, storageItem).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<StoreStorageItem>>().ConfigureAwait(false);
            }
        }
    }
}
