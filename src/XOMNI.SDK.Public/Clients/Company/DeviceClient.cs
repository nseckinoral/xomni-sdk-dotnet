using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Company;
using XOMNI.SDK.Public.Extensions;
using System.Reflection;
using System.Dynamic;

namespace XOMNI.SDK.Public.Clients.Company
{
    public class DeviceClient : BaseClient
    {
        public DeviceClient(HttpClient httpClient)
            : base(httpClient)
        {

        }

        private static Lazy<List<PropertyInfo>> lazyDeviceProperties = new Lazy<List<PropertyInfo>>(() => typeof(Device).GetRuntimeProperties().ToList());
        private static List<PropertyInfo> deviceProperties
        {
            get { return lazyDeviceProperties.Value; }
        }

        public async Task DeleteAsync(string deviceId)
        {
            Validator.For(deviceId, "deviceId").IsNotNullOrEmpty();
            string path = string.Format("/company/devices/{0}", deviceId);
            await Client.DeleteAsync(path).ConfigureAwait(false);
        }

        public async Task<ApiResponse<List<Device>>> GetAsync(double searchDistance, Location gpsLocation, int? deviceTypeId = null, string metadataKey = null, string metadataValue = null, bool includeMetadata = false)
        {
            Validator.For(searchDistance, "searchDistance").InRange(0, 1);
            Validator.For(gpsLocation, "gpsLocation").IsNotNull();
            Validator.For(gpsLocation.Latitude, "Latitude").InRange(-90, 90);
            Validator.For(gpsLocation.Longitude, "Longitude").InRange(-180, 180);

            string path = string.Format("/company/stores/{0}/Devices?searchDistance={1}&", gpsLocation.GetFormattedLocation(), searchDistance);
            if (deviceTypeId != null)
            {
                Validator.For(deviceTypeId, "deviceTypeId").IsGreaterThanOrEqual(1);
                path += string.Format("deviceTypeId={0}&", deviceTypeId);
            }

            if (!string.IsNullOrEmpty(metadataKey) && !string.IsNullOrEmpty(metadataValue))
            {
                path += string.Format("metadataKey={0}&metadataValue={1}&", metadataKey, metadataValue);
            }

            else if (!string.IsNullOrEmpty(metadataKey) || !string.IsNullOrEmpty(metadataValue))
            {
                Validator.For(metadataKey, "metadataKey").IsNotNullOrEmpty();
                Validator.For(metadataValue, "metadataValue").IsNotNullOrEmpty();
            }

            path += string.Format("includeMetadata={0}", includeMetadata);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<List<Device>>>().ConfigureAwait(false);
            }
        }

        public async Task<ApiResponse<List<Device>>> GetAsync(int? deviceTypeId = null, string metadataKey = null, string metadataValue = null, bool includeMetadata = false)
        {
            string path = "/company/stores/devices?";

            if (deviceTypeId != null)
            {
                Validator.For(deviceTypeId, "deviceTypeId").IsGreaterThanOrEqual(1);
                path += string.Format("deviceTypeId={0}&", deviceTypeId);
            }

            if (!string.IsNullOrEmpty(metadataKey) && !string.IsNullOrEmpty(metadataValue))
            {
                path += string.Format("metadataKey={0}&metadataValue={1}&", metadataKey, metadataValue);
            }
            else if (!string.IsNullOrEmpty(metadataKey) || !string.IsNullOrEmpty(metadataValue))
            {
                Validator.For(metadataKey, "metadataKey").IsNotNullOrEmpty();
                Validator.For(metadataValue, "metadataValue").IsNotNullOrEmpty();
            }

            path += string.Format("includeMetadata={0}", includeMetadata);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<List<Device>>>().ConfigureAwait(false);
            }
        }

        public async Task<ApiResponse<Device>> PatchAsync(string deviceId, dynamic devicePatch)
        {
            Validator.For(deviceId, "deviceId").IsNotNullOrEmpty();
            ValidatePatch(devicePatch);
            
            string path = string.Format("/company/devices/{0}", deviceId);

            using (var response = await Client.PatchAsJsonAsync(path, (object)devicePatch).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<Device>>().ConfigureAwait(false);
            }
        }

        public async Task<ApiResponse<Device>> PostAsync(Device device)
        {
            Validator.For(device, "device").IsNotNull(); 
            Validator.For(device.DeviceId, "deviceId").IsNotNullOrEmpty();
            Validator.For(device.Description, "description").IsNotNullOrEmpty();
            Validator.For(device.DeviceTypeId, "deviceTypeId").IsGreaterThanOrEqual(1);
            
            string path = "/company/devices";

            using (var response = await Client.PostAsJsonAsync(path, device).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<Device>>().ConfigureAwait(false);
            }
        }

        private void ValidatePatch(dynamic devicePatch)
        {
            if (Object.ReferenceEquals(null, devicePatch))
            {
                throw new ArgumentNullException("particularDeviceInfo can not be null.");
            }

            var devicePatchProperties = devicePatch.GetType().GetProperties() as PropertyInfo[];
            if (!devicePatchProperties.Any())
            {
                throw new ArgumentException("Device patch must be containt at least a property.");
            }
            var invalidParameters = devicePatchProperties.Where(t => !deviceProperties.Any(p => p.Name == t.Name));
            if (invalidParameters.Any())
            {
                throw new ArgumentException(string.Format("{0} parameter(s) invalid for device patch.", 
                    string.Join(",", invalidParameters.Select(t => string.Format("'{0}'",t.Name))))
                );
            }
        }
    }
}