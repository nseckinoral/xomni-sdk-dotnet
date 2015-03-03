using System;
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

        private static IEnumerable<PropertyInfo> deviceProperties = typeof(Device).GetRuntimeProperties();

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

        public async Task<ApiResponse<Device>> PatchAsync(string deviceId, dynamic particularDeviceInfo)
        {
            Validator.For(deviceId, "deviceId").IsNotNullOrEmpty();

            IDictionary<string, object> expando;
            if (!Object.ReferenceEquals(null, particularDeviceInfo))
            {
                var properties = GetMatchingProperties(particularDeviceInfo);
                expando = CreateExpandoObject(particularDeviceInfo, properties);
            }
            else
            {
                throw new ArgumentNullException("particularDeviceInfo can not be null.");
            }

            string path = string.Format("/company/devices/{0}", deviceId);

            using (var response = await Client.PatchAsJsonAsync(path, expando).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<Device>>().ConfigureAwait(false);
            }
        }

        public async Task<ApiResponse<Device>> PostAsync(string deviceId, string description, Device device)
        {
            Validator.For(deviceId, "deviceId").IsNotNullOrEmpty();
            Validator.For(description, "description").IsNotNullOrEmpty();
            Validator.For(device, "device").IsNotNull();
            string path = "/company/devices";

            using (var response = await Client.PostAsJsonAsync(path, device).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<Device>>().ConfigureAwait(false);
            }
        }
        private List<PropertyMap> GetMatchingProperties(dynamic targetParameter)
        {
            List<PropertyMap> properties = new List<PropertyMap>();
            var targetParameterProperties = targetParameter.GetType().GetProperties();

            int counter = 4;
            foreach (PropertyInfo targetProperty in targetParameterProperties)
            {
                foreach (PropertyInfo sourceProperty in deviceProperties)
                {
                    if (targetProperty.Name == sourceProperty.Name)
                    {
                        properties.Add(new PropertyMap()
                        {
                            SourceProperty = sourceProperty,
                            TargetProperty = targetProperty
                        });
                        counter--;
                    }
                }
                if (counter == 4)
                {
                    throw new ArgumentException("Format of parameters are not correct.");
                }
                counter = 4;
            }
            if (properties.Count == 0)
            {
                throw new ArgumentException("Format of parameters are not correct.");
            }
            return properties;
        }
        private IDictionary<string, object> CreateExpandoObject(dynamic parameter, List<PropertyMap> propertyMap)
        {
            var expando = new ExpandoObject() as IDictionary<string, object>;
            foreach (var item in propertyMap)
            {
                expando.Add(item.TargetProperty.Name, item.TargetProperty.GetValue(parameter));
            }
            return expando;
        }
    }
}