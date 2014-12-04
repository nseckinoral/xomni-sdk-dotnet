using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model.Private.Analytics.Log;

namespace XOMNI.SDK.Private.Analytics.Log
{
    public class ClientAnalyticsManagement : ManagementBase
    {
        private ApiAccess.Analytics.ClientAnalytics analyticsApiAccess;

        public ClientAnalyticsManagement()
        {
            analyticsApiAccess = new ApiAccess.Analytics.ClientAnalytics();
        }
        public Task<AnalyticsLogContainer<ClientAnalyticsLog>> GetAllAsync(string counterName, DateTime meteringDate, string continuationKey = null)
        {
            return analyticsApiAccess.GetAllAsync(counterName, meteringDate, continuationKey, this.ApiCredential);
        }

        #region low level methods
        public XOMNIRequestMessage<AnalyticsLogContainer<ClientAnalyticsLog>> CreateGetAllRequest(string counterName, DateTime meteringDate, string continuationKey = null)
        {
            return analyticsApiAccess.CreateGetAllRequest<ClientAnalyticsLog>(counterName, meteringDate, continuationKey, this.ApiCredential);
        }
        #endregion
    }
}
