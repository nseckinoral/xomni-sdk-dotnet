using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Management.ApiAccess.Configuration
{
    internal class TrendingActionTypes : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/management/configuration/trendingactiontypes"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        public async Task<List<XOMNI.SDK.Model.Management.Configuration.TrendingActionTypeValue>> GetAsync(ApiBasicCredential credential)
        {
            return await HttpProvider.GetAsync<List<XOMNI.SDK.Model.Management.Configuration.TrendingActionTypeValue>>(GenerateUrl(SingleOperationBaseUrl), credential);
        }

        public async Task<List<XOMNI.SDK.Model.Management.Configuration.TrendingActionTypeValue>> UpdateAsync(List<XOMNI.SDK.Model.Management.Configuration.TrendingActionTypeValue> popularityActionTypes, ApiBasicCredential credential)
        {
            return await HttpProvider.PutAsync<List<XOMNI.SDK.Model.Management.Configuration.TrendingActionTypeValue>>(GenerateUrl(SingleOperationBaseUrl), popularityActionTypes, credential);
        }
    }
}
