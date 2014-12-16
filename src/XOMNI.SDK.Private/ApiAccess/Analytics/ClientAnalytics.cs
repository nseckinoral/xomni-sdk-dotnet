using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model.Private.Analytics.Log;
using XOMNI.SDK.Core.Extensions;
using XOMNI.SDK.Model.Private.Analytics;

namespace XOMNI.SDK.Private.ApiAccess.Analytics
{
    public class ClientAnalytics : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/analytics/clientcounters/{0}/logs"; }
        }

        protected string ClientSideKeysBaseUrl
        {
            get { return "/private/analytics/clientcounters"; }
        }

        internal Task<AnalyticsLogContainer<ClientAnalyticsLog>> GetAllAsync(string counterName, DateTime date, string continuationKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> queryStringParams = new Dictionary<string, string>();
            queryStringParams.Add("oaDate", ((int)date.ToOADate()).ToString());
            if (continuationKey != null)
            {
                queryStringParams.Add("continuationKey", continuationKey);
            }
            return HttpProvider.GetAsync<AnalyticsLogContainer<ClientAnalyticsLog>>(GenerateUrl(String.Format(ListOperationBaseUrl, counterName), queryStringParams), credential);
        }

        internal XOMNIRequestMessage<AnalyticsLogContainer<T>> CreateGetAllRequest<T>(string counterName, DateTime date, string continuationKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> queryStringParams = new Dictionary<string, string>();
            queryStringParams.Add("oaDate", ((int)date.ToOADate()).ToString());
            if (continuationKey != null)
            {
                queryStringParams.Add("continuationKey", continuationKey);
            }
            return new XOMNIRequestMessage<AnalyticsLogContainer<T>>(HttpProvider.CreateGetRequest(GenerateUrl(String.Format(ListOperationBaseUrl, counterName), queryStringParams), credential));
        }

        internal Task<ClientSideAnalyticKeysContainer> GetKeysAsync(string continuationKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> queryStringParams = new Dictionary<string, string>();
            if (continuationKey != null)
            {
                queryStringParams.Add("continuationKey", continuationKey);
            }
            return HttpProvider.GetAsync<ClientSideAnalyticKeysContainer>(GenerateUrl(ClientSideKeysBaseUrl, queryStringParams), credential);
        }

        internal XOMNIRequestMessage<ClientSideAnalyticKeysContainer> CreateGetKeysRequest(string continuationKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> queryStringParams = new Dictionary<string, string>();
            if (continuationKey != null)
            {
                queryStringParams.Add("continuationKey", continuationKey);
            }

            return new XOMNIRequestMessage<ClientSideAnalyticKeysContainer>(HttpProvider.CreateGetRequest(GenerateUrl(ClientSideKeysBaseUrl, queryStringParams), credential));
        }
    }
}
