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
    public class DeviceMetadata : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/management/company/licences/{0}/devices/{1}/metadata/{2}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/management/company/licences/{0}/devices/{0}/metadata"; }
        }

        internal Task<Metadata> CreateAsync(string deviceId, int licenceId, Metadata metadata, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync<Metadata>(GenerateUrl(String.Format(ListOperationBaseUrl, licenceId, deviceId)), metadata, credential);
        }

        internal Task<Metadata> UpdateAsync(string deviceId, int licenceId, Metadata metadata, ApiBasicCredential credential)
        {
            return HttpProvider.PutAsync<Metadata>(GenerateUrl(String.Format(ListOperationBaseUrl, licenceId, deviceId)), metadata, credential);
        }

        internal Task<List<Metadata>> GetAsync(string deviceId, int licenceId, ApiBasicCredential credential)
        {
            return HttpProvider.GetAsync<List<Metadata>>(GenerateUrl(String.Format(ListOperationBaseUrl, licenceId, deviceId)), credential);
        }

        internal Task DeleteAsync(string deviceId, int licenceId, string metadataKey, ApiBasicCredential credential)
        {
            return HttpProvider.DeleteAsync(GenerateUrl(String.Format(SingleOperationBaseUrl, licenceId, deviceId, metadataKey)), credential);
        }

        internal Task DeleteAsync(string deviceId, int licenceId, ApiBasicCredential credential)
        {
            return HttpProvider.DeleteAsync(GenerateUrl(String.Format(ListOperationBaseUrl, licenceId, deviceId)), credential);
        }
    }
}
