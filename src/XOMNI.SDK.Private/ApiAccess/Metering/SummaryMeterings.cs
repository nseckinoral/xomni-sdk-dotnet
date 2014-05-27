using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Extensions;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model.Private.Metering;

namespace XOMNI.SDK.Private.ApiAccess.Metering
{
    internal class SummaryMeterings : ApiAccessBase
    {
        private CounterTypes counterType;
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/metering/counters/{0}/summary/{1}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        internal Task<T> GetAsync<T>(CounterTypes counterType, PeriodTypes periodType, DateTime startDate, DateTime endDate, ApiBasicCredential credential)
        {
            Dictionary<string,string> queryStringParams = new Dictionary<string,string>();
            queryStringParams.Add("startOADate", ((int)startDate.ToOADate()).ToString());
            queryStringParams.Add("endOADate", ((int)endDate.ToOADate()).ToString());
            return HttpProvider.GetAsync<T>(GenerateUrl(string.Format(SingleOperationBaseUrl, counterType.ToString(), periodType.ToString()), queryStringParams), credential);
        }
    }
}
