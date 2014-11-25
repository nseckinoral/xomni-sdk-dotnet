using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.Auth
{
    public class PrincipalManagement : ManagementBase
    {
        private ApiAccess.Auth.Principal principalApi = null;

        public PrincipalManagement()
        {
            principalApi = new ApiAccess.Auth.Principal();
        }

        public Task<XOMNI.SDK.Model.Private.Auth.Principal> GetPrincipalAsync()
        {
            return principalApi.GetAsync(ApiCredential);
        }

        #region low level methods
        public XOMNIRequestMessage<XOMNI.SDK.Model.Private.Auth.Principal> CreateGetPrincipalRequest()
        {
            return principalApi.CreateGetRequest(ApiCredential);
        }

        #endregion
    }
}
