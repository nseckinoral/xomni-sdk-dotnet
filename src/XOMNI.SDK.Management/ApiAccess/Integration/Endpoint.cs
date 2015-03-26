using System;
using System.Net;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model.Management.Integration;

namespace XOMNI.SDK.Management.ApiAccess.Integration
{
    internal class Endpoint : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/management/integration/endpoint"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        internal Task<EndpointDetail> GetAsync(ApiBasicCredential credential)
        {
            return HttpProvider.GetAsync<EndpointDetail>(GenerateUrl(SingleOperationBaseUrl), credential);
        }

        internal Task PostAsync(EndpointCreationRequest request, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync(GenerateUrl(SingleOperationBaseUrl), request, credential, HttpStatusCode.Accepted);
        }

        internal Task DeleteAsync(ApiBasicCredential credential)
        {
            return HttpProvider.DeleteAsync(GenerateUrl(SingleOperationBaseUrl), credential);
        }

        internal XOMNIRequestMessage CreatePostRequest(EndpointCreationRequest request, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage(HttpProvider.CreatePostRequest(GenerateUrl(SingleOperationBaseUrl), credential, request));
        }

        internal XOMNIRequestMessage<EndpointDetail> CreateGetRequest(ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<EndpointDetail>(HttpProvider.CreateGetRequest(GenerateUrl(SingleOperationBaseUrl), credential));
        }

        internal XOMNIRequestMessage CreateDeleteRequest(ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage(HttpProvider.CreateDeleteRequest(GenerateUrl(SingleOperationBaseUrl), credential));
        }
    }
}
