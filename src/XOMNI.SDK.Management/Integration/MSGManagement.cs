using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Management.ApiAccess.Integration;
using XOMNI.SDK.Model.Management.Integration;

namespace XOMNI.SDK.Management.Integration
{
    public class MSGManagement : ManagementBase
    {
        private readonly MSG msgApi = new MSG();


        public virtual Task<MSGIntegration> GetAsync()
        {
            return msgApi.GetAsync(this.ApiCredential);
        }

        public virtual Task<MSGIntegrationResponse> PostAsync(MSGIntegrationRequest request)
        {
            return msgApi.PostAsync(request, this.ApiCredential);
        }

        public virtual XOMNIRequestMessage<MSGIntegration> CreateGetRequest()
        {
            return msgApi.CreateGetRequest(this.ApiCredential);
        }

        public virtual XOMNIRequestMessage<MSGIntegrationResponse> CreatePostRequest(MSGIntegrationRequest request)
        {
            return msgApi.CreatePostRequest(request, this.ApiCredential);
        }
    }
}
