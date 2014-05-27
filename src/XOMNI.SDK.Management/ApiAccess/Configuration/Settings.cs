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

        public async Task<XOMNI.SDK.Model.Management.Configuration.Settings> GetAsync(ApiBasicCredential credential)
        {
            return await HttpProvider.GetAsync<XOMNI.SDK.Model.Management.Configuration.Settings>(GenerateUrl(SingleOperationBaseUrl), credential);
        }

        public async Task<XOMNI.SDK.Model.Management.Configuration.Settings> UpdateAsync(XOMNI.SDK.Model.Management.Configuration.Settings settings, ApiBasicCredential credential)
        {
            return await HttpProvider.PutAsync<XOMNI.SDK.Model.Management.Configuration.Settings>(GenerateUrl(SingleOperationBaseUrl), settings, credential);
        }
    }
}
