using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Model;

namespace XOMNI.SDK.Private.Company
{
    public class StoreManagement : ManagementBase
    {
        private ApiAccess.Company.Store storeApi = null;

        public StoreManagement()
        {
            storeApi = new ApiAccess.Company.Store();
        }

        public Task<CountedCollectionContainer<Model.Private.Company.Store>> GetAsync(int skip, int take)
        {
            return storeApi.GetAsync(skip, take, ApiCredential);
        }
    }
}
