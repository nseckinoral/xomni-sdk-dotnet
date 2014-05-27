using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Model.Private.Metering;
using XOMNI.SDK.Model.Private.Metering.Log;
using XOMNI.SDK.Private.ApiAccess.Metering;

namespace XOMNI.SDK.Private.Metering
{
    public abstract class BaseMeteringManagement<T> : ManagementBase
    {
        protected abstract CounterTypes CounterType { get; }
        private Meterings meteringApiAccess;

        public BaseMeteringManagement()
        {
            meteringApiAccess = new Meterings(CounterType);
        }
        public Task<MeteringLogContainer<T>> GetAllAsync(DateTime meteringDate, string continuationKey = null)
        {
            return meteringApiAccess.GetAllAsync<T>(meteringDate, continuationKey, this.ApiCredential);
        }
    }
}
