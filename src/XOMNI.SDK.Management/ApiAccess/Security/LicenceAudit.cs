using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model;

namespace XOMNI.SDK.Management.ApiAccess.Security
{
    public class LicenceAudit : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/management/security/licenses/audits"; }
        }

        internal Task<CountedCollectionContainer<XOMNI.SDK.Model.Management.Security.LicenseAuditLog>> GetAsync(int skip, int take, ApiBasicCredential credential)
        {
            var additionalQueryString = new Dictionary<string,string>();
            additionalQueryString.Add("skip",skip.ToString());
            additionalQueryString.Add("take",take.ToString());

            return HttpProvider.GetAsync<CountedCollectionContainer<XOMNI.SDK.Model.Management.Security.LicenseAuditLog>>(GenerateUrl(ListOperationBaseUrl, additionalQueryString), credential);
        }

    }
}
