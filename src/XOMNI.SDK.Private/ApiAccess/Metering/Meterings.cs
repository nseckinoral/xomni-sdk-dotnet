using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Model.Private.Metering;
using XOMNI.SDK.Core.Extensions;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model.Private.Metering.Log;

namespace XOMNI.SDK.Private.ApiAccess.Metering
{
    internal class Meterings : ApiAccessBase
    {
        private CounterTypes counterType;
        public Meterings(CounterTypes counterType)
        {
            this.counterType = counterType;
        }

        protected override string SingleOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        protected override string ListOperationBaseUrl
        {
            get { return String.Format("/private/metering/counters/{0}/logs", counterType.ToString()); }
        }

        internal Task<MeteringLogContainer<T>> GetAllAsync<T>(DateTime meteringDate, string continuationKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> queryStringParams = new Dictionary<string, string>();
            queryStringParams.Add("oaDate", ((int)meteringDate.ToOADate()).ToString());
            if (continuationKey != null)
            {
                queryStringParams.Add("continuationKey", continuationKey);
            }
            return HttpProvider.GetAsync<MeteringLogContainer<T>>(GenerateUrl(ListOperationBaseUrl, queryStringParams), credential);
        }

        internal XOMNIRequestMessage<MeteringLogContainer<T>> CreateGetAllRequest<T>(DateTime meteringDate, string continuationKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> queryStringParams = new Dictionary<string, string>();
            queryStringParams.Add("oaDate", ((int)meteringDate.ToOADate()).ToString());
            if (continuationKey != null)
            {
                queryStringParams.Add("continuationKey", continuationKey);
            }
            return new XOMNIRequestMessage<MeteringLogContainer<T>>(HttpProvider.CreateGetRequest(GenerateUrl(ListOperationBaseUrl, queryStringParams), credential));
        }
    }
}
