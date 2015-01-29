using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Extensions;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model.Private.Analytics;

namespace XOMNI.SDK.Private.ApiAccess.Analytics
{
    internal class ServerAnalyticsSummary : ApiAccessBase
    {
        private CounterTypes counterType;
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/analytics/servercounters/{0}/summary/{1}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        internal Task<T> GetAsync<T>(CounterTypes counterType, PeriodTypes periodType, DateTime startDate, DateTime endDate, ApiBasicCredential credential)
        {
            Dictionary<string, string> queryStringParams = new Dictionary<string, string>();
            queryStringParams.Add("startOADate", ((int)startDate.ToOADate()).ToString());
            queryStringParams.Add("endOADate", ((int)endDate.ToOADate()).ToString());
            return HttpProvider.GetAsync<T>(GenerateUrl(string.Format(SingleOperationBaseUrl, counterType.ToString(), periodType.ToString()), queryStringParams), credential);
        }

        internal XOMNIRequestMessage<T> CreateGetRequest<T>(CounterTypes counterType, PeriodTypes periodType, DateTime startDate, DateTime endDate, ApiBasicCredential credential)
        {
            Dictionary<string, string> queryStringParams = new Dictionary<string, string>();
            queryStringParams.Add("startOADate", ((int)startDate.ToOADate()).ToString());
            queryStringParams.Add("endOADate", ((int)endDate.ToOADate()).ToString());
            return new XOMNIRequestMessage<T>(HttpProvider.CreateGetRequest(GenerateUrl(string.Format(SingleOperationBaseUrl, counterType.ToString(), periodType.ToString()), queryStringParams), credential));
        }
    }
}
