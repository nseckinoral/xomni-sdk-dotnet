using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model.Private.Analytics;
using XOMNI.SDK.Model.Private.Analytics.Log;
using XOMNI.SDK.Private.ApiAccess.Analytics;

namespace XOMNI.SDK.Private.Analytics
{
    public abstract class BaseAnalyticsManagement<T> : ManagementBase
    {
        protected abstract CounterTypes CounterType { get; }
        private ApiAccess.Analytics.ServerAnalytics analyticsApiAccess;

        public BaseAnalyticsManagement()
        {
            analyticsApiAccess = new ApiAccess.Analytics.ServerAnalytics(CounterType);
        }
        public Task<AnalyticsLogContainer<T>> GetAllAsync(DateTime date, string continuationKey = null)
        {
            return analyticsApiAccess.GetAllAsync<T>(date, continuationKey, this.ApiCredential);
        }

        #region low level methods
        public XOMNIRequestMessage<AnalyticsLogContainer<T>> CreateGetAllRequest(DateTime date, string continuationKey = null)
        {
            return analyticsApiAccess.CreateGetAllRequest<T>(date, continuationKey, this.ApiCredential);
        }
        #endregion
    }
}
