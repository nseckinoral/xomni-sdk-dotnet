using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model.Management.Integration;

namespace XOMNI.SDK.Management.ApiAccess.Integration
{
    public class MSG : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/management/integration/msg"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        internal Task<MSGIntegration> GetAsync(ApiBasicCredential credential)
        {
            return HttpProvider.GetAsync<MSGIntegration>(GenerateUrl(SingleOperationBaseUrl), credential);
        }

        internal Task<MSGIntegrationResponse> PostAsync(MSGIntegrationRequest request, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync<MSGIntegrationResponse>(GenerateUrl(SingleOperationBaseUrl), request, credential);
        }

        internal XOMNIRequestMessage<MSGIntegration> CreateGetRequest(ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<MSGIntegration>(HttpProvider.CreateGetRequest(GenerateUrl(SingleOperationBaseUrl), credential));
        }

        internal XOMNIRequestMessage<MSGIntegrationResponse> CreatePostRequest(MSGIntegrationRequest request, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<MSGIntegrationResponse>(HttpProvider.CreatePostRequest(GenerateUrl(SingleOperationBaseUrl), credential, request));
        }

        internal Task DeleteAsync(ApiBasicCredential credential)
        {
            return HttpProvider.DeleteAsync(GenerateUrl(SingleOperationBaseUrl), credential);
        }

        internal XOMNIRequestMessage CreateDeleteRequest(ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage(HttpProvider.CreateDeleteRequest(GenerateUrl(SingleOperationBaseUrl), credential), HttpStatusCode.Accepted);
        }
    }
}
