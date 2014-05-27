using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model.Private.Catalog;
using XOMNI.SDK.Core.Management;

namespace XOMNI.SDK.Private.Catalog
{
    public class SummaryManagement : ManagementBase
    {
        private XOMNI.SDK.Private.ApiAccess.Catalog.Summary summaryApi;

        public SummaryManagement()
        {
            summaryApi = new ApiAccess.Catalog.Summary();
        }

        public Task<Summary> GetAsync()
        {
            return summaryApi.GetAsync(this.ApiCredential);
        }
    }
}
