using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Model.Private.Analytics;
using XOMNI.SDK.Core.Extensions;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model.Private.Analytics.Log;

namespace XOMNI.SDK.Private.ApiAccess.Analytics
{
    internal class ServerAnalytics : ApiAccessBase
    {
        private CounterTypes counterType;
        public ServerAnalytics(CounterTypes counterType)
        {
            this.counterType = counterType;
        }

        protected override string SingleOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        protected override string ListOperationBaseUrl
        {
            get { return String.Format("/private/analytics/servercounters/{0}/logs", counterType.ToString()); }
        }

        internal Task<AnalyticsLogContainer<T>> GetAllAsync<T>(DateTime date, string continuationKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> queryStringParams = new Dictionary<string, string>();
            queryStringParams.Add("oaDate", ((int)date.ToOADate()).ToString());
            if (continuationKey != null)
            {
                queryStringParams.Add("continuationKey", continuationKey);
            }
            return HttpProvider.GetAsync<AnalyticsLogContainer<T>>(GenerateUrl(ListOperationBaseUrl, queryStringParams), credential);
        }

        internal XOMNIRequestMessage<AnalyticsLogContainer<T>> CreateGetAllRequest<T>(DateTime date, string continuationKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> queryStringParams = new Dictionary<string, string>();
            queryStringParams.Add("oaDate", ((int)date.ToOADate()).ToString());
            if (continuationKey != null)
            {
                queryStringParams.Add("continuationKey", continuationKey);
            }
            return new XOMNIRequestMessage<AnalyticsLogContainer<T>>(HttpProvider.CreateGetRequest(GenerateUrl(ListOperationBaseUrl, queryStringParams), credential));
        }
    }
}
