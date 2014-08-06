using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model;

namespace XOMNI.SDK.Management.ApiAccess.Tenant
{
    public class Devices : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/management/tenant/devices/{0}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/management/tenant/devices"; }
        }

        internal Task<CountedCollectionContainer<XOMNI.SDK.Model.Management.Tenant.Device>> GetAllAsync(int skip, int take, ApiBasicCredential credential)
        {
            var additionalQueryString = new Dictionary<string, string>();
            additionalQueryString.Add("skip", skip.ToString());
            additionalQueryString.Add("take", take.ToString());

            return HttpProvider.GetAsync<CountedCollectionContainer<XOMNI.SDK.Model.Management.Tenant.Device>>(GenerateUrl(ListOperationBaseUrl, additionalQueryString), credential);
        }

        internal Task<XOMNI.SDK.Model.Management.Tenant.Device> CreateAsync(XOMNI.SDK.Model.Management.Tenant.Device device, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync<XOMNI.SDK.Model.Management.Tenant.Device>(GenerateUrl(ListOperationBaseUrl), device, credential);
        }

        internal Task<XOMNI.SDK.Model.Management.Tenant.Device> UpdateAsync(XOMNI.SDK.Model.Management.Tenant.Device device, ApiBasicCredential credential)
        {
            return HttpProvider.PutAsync<XOMNI.SDK.Model.Management.Tenant.Device>(GenerateUrl(String.Format(SingleOperationBaseUrl, device.DeviceId)), device, credential);
        }

        internal Task DeleteAsync(string deviceId, ApiBasicCredential credential)
        {
            return HttpProvider.DeleteAsync(GenerateUrl(String.Format(SingleOperationBaseUrl, deviceId)), credential);
        }

        internal Task<XOMNI.SDK.Model.Management.Tenant.Device> GetAsync(string deviceId, int relatedPublicApiUserId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalQueryString = new Dictionary<string, string>();
            additionalQueryString.Add("relatedPublicApiUserId", relatedPublicApiUserId.ToString());

            return HttpProvider.GetAsync<XOMNI.SDK.Model.Management.Tenant.Device>(GenerateUrl(String.Format(SingleOperationBaseUrl, deviceId), additionalQueryString), credential);
        }
    }
}
