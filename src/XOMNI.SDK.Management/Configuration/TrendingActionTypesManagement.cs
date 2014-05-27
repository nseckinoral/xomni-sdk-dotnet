using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Model.Management.Configuration;

namespace XOMNI.SDK.Management.Configuration
{
    public class TrendingActionTypesManagement : ManagementBase
    {
        private XOMNI.SDK.Management.ApiAccess.Configuration.TrendingActionTypes trendingActionTypeApi;

        /// <summary>
        /// Default constructor
        /// </summary>
        public TrendingActionTypesManagement()
        {
            trendingActionTypeApi = new ApiAccess.Configuration.TrendingActionTypes();
        }

        
        /// <summary>
        /// To fetch all of the trending action types.
        /// </summary>
        /// <returns>Current trending action types</returns>
        public async Task<List<TrendingActionTypeValue>> GetAsync()
        {
            return await trendingActionTypeApi.GetAsync(this.ApiCredential);
        }

        /// <summary>
        /// To update all of the trending action types
        /// </summary>
        /// <param name="trendingActionTypeValues">TrendingActionTypes to be updated</param>
        /// <returns>Updated settings</returns>
        public async Task<List<TrendingActionTypeValue>> UpdateAsync(List<TrendingActionTypeValue> trendingActionTypeValues)
        {
            return await trendingActionTypeApi.UpdateAsync(trendingActionTypeValues, this.ApiCredential);
        }
    }
}
