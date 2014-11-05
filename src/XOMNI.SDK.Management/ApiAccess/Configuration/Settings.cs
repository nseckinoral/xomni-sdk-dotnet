using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Management.ApiAccess.Configuration
{
    internal class Settings : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/management/Configuration/settings"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        public Task<XOMNI.SDK.Model.Management.Configuration.Settings> GetAsync(ApiBasicCredential credential)
        {
            return HttpProvider.GetAsync<XOMNI.SDK.Model.Management.Configuration.Settings>(GenerateUrl(SingleOperationBaseUrl), credential);
        }

        public Task<XOMNI.SDK.Model.Management.Configuration.Settings> UpdateAsync(XOMNI.SDK.Model.Management.Configuration.Settings settings, ApiBasicCredential credential)
        {
            return HttpProvider.PutAsync<XOMNI.SDK.Model.Management.Configuration.Settings>(GenerateUrl(SingleOperationBaseUrl), settings, credential);
        }

        internal XOMNIRequestMessage<Model.Management.Configuration.Settings> CreateGetRequest(ApiBasicCredential apiBasicCredential)
        {
            return new XOMNIRequestMessage<Model.Management.Configuration.Settings>(HttpProvider.CreateGetRequest(GenerateUrl(SingleOperationBaseUrl), apiBasicCredential));

        }

        internal XOMNIRequestMessage<Model.Management.Configuration.Settings> CreatePutRequest(Model.Management.Configuration.Settings tenantSettings, ApiBasicCredential apiBasicCredential)
        {
            return new XOMNIRequestMessage<Model.Management.Configuration.Settings>(HttpProvider.CreatePutRequest(GenerateUrl(SingleOperationBaseUrl), apiBasicCredential, tenantSettings));
        }
    }
}
