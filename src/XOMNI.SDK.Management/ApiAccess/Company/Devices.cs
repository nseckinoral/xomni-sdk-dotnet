using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model;

namespace XOMNI.SDK.Management.ApiAccess.Company
{
    internal class Devices : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/management/company/devices/{0}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/management/company/devices"; }
        }

        internal Task<CountedCollectionContainer<XOMNI.SDK.Model.Management.Company.Device>> GetAllAsync(int skip, int take, ApiBasicCredential credential)
        {
            var additionalQueryString = new Dictionary<string, string>();
            additionalQueryString.Add("skip", skip.ToString());
            additionalQueryString.Add("take", take.ToString());

            return HttpProvider.GetAsync<CountedCollectionContainer<XOMNI.SDK.Model.Management.Company.Device>>(GenerateUrl(ListOperationBaseUrl, additionalQueryString), credential);
        }

        internal Task<XOMNI.SDK.Model.Management.Company.Device> CreateAsync(XOMNI.SDK.Model.Management.Company.Device device, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync<XOMNI.SDK.Model.Management.Company.Device>(GenerateUrl(ListOperationBaseUrl), device, credential);
        }

        internal Task<XOMNI.SDK.Model.Management.Company.Device> UpdateAsync(XOMNI.SDK.Model.Management.Company.Device device, ApiBasicCredential credential)
        {
            return HttpProvider.PutAsync<XOMNI.SDK.Model.Management.Company.Device>(GenerateUrl(String.Format(SingleOperationBaseUrl, device.DeviceId)), device, credential);
        }

        internal Task DeleteAsync(string deviceId, int relatedLicenceId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalQueryString = new Dictionary<string, string>();
            additionalQueryString.Add("relatedLicenceId", relatedLicenceId.ToString());
            return HttpProvider.DeleteAsync(GenerateUrl(String.Format(SingleOperationBaseUrl, deviceId), additionalQueryString), credential);
        }

        internal Task<XOMNI.SDK.Model.Management.Company.Device> GetAsync(string deviceId, int relatedLicenceId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalQueryString = new Dictionary<string, string>();
            additionalQueryString.Add("relatedLicenceId", relatedLicenceId.ToString());

            return HttpProvider.GetAsync<XOMNI.SDK.Model.Management.Company.Device>(GenerateUrl(String.Format(SingleOperationBaseUrl, deviceId), additionalQueryString), credential);
        }
    }
}
