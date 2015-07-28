using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Company;
using XOMNI.SDK.Public.Extensions;
using XOMNI.SDK.Public.Infrastructure;

namespace XOMNI.SDK.Public.Clients.Company
{
    public class DeviceStorageClient : BaseClient
    {
        public DeviceStorageClient(HttpClient httpClient)
            : base(httpClient)
        {

        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/company/device-storage/fetching-storage-data-of-an-device-by-device-id")]
		public async Task<ApiResponse<List<DeviceStorageItem>>> GetAsync(string deviceId, string key = null, bool delete = false)
        {
            Validator.For(deviceId, "deviceId").IsNotNullOrEmpty();

            string path = string.Format("/company/devices/{0}/storage?", deviceId);

            if (!string.IsNullOrEmpty(key))
            {
                path += string.Format("key={0}&", key);
            }

            path += string.Format("delete={0}", delete);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<List<DeviceStorageItem>>>().ConfigureAwait(false);
            }
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/company/device-storage/clearing-device-storage-data")]
        public async Task DeleteAsync(string deviceId, string key = null)
        {
            Validator.For(deviceId, "deviceId").IsNotNullOrEmpty();
            string path = string.Format("/company/devices/{0}/storage", deviceId);

            if (!string.IsNullOrEmpty(key))
            {
                path += string.Format("?key={0}", key);
            }
            await Client.DeleteAsync(path).ConfigureAwait(false);
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/company/device-storage/creating-a-new-data-storage-item")]
		public async Task<ApiResponse<DeviceStorageItem>> PostAsync(DeviceStorageItem storageItem)
        {
            Validator.For(storageItem, "storageItem").IsNotNull();
            Validator.For(storageItem.DeviceId, "DeviceId").IsNotNullOrEmpty();

            string path = string.Format("/company/devices/{0}/storage", storageItem.DeviceId);

            using (var response = await Client.PostAsJsonAsync(path, storageItem).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<DeviceStorageItem>>().ConfigureAwait(false);
            }
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/company/device-storage/updating-an-existing-device-storage-data")]
		public async Task<ApiResponse<DeviceStorageItem>> PutAsync(DeviceStorageItem storageItem)
        {
            Validator.For(storageItem, "storageItem").IsNotNull();
            Validator.For(storageItem.DeviceId, "DeviceId").IsNotNullOrEmpty();

            string path = string.Format("/company/devices/{0}/storage", storageItem.DeviceId);

            using (var response = await Client.PutAsJsonAsync(path, storageItem).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<DeviceStorageItem>>().ConfigureAwait(false);
            }
        }
    }
}