using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Management.ApiAccess.Integration;
using XOMNI.SDK.Model.Management.Integration;

namespace XOMNI.SDK.Management.Integration
{
    public class EndpointManagement : ManagementBase
    {
        protected readonly Endpoint endpointApi = new Endpoint();
        public virtual Task CreateAsync(EndpointCreationRequest request)
        {
            return endpointApi.PostAsync(request, this.ApiCredential);
        }

        public virtual Task<EndpointDetail> GetEndpointDetailAsync()
        {
            return endpointApi.GetAsync(this.ApiCredential);
        }

        public virtual Task DeleteAsync()
        {
            return endpointApi.DeleteAsync(this.ApiCredential);
        }

        public virtual XOMNIRequestMessage CreateEndpointCreationRequest(EndpointCreationRequest request)
        {
            return endpointApi.CreatePostRequest(request, this.ApiCredential);
        }
        public virtual XOMNIRequestMessage<EndpointDetail> CreateGetEndpointDetailRequest()
        {
            return endpointApi.CreateGetRequest(this.ApiCredential);
        }
        public virtual XOMNIRequestMessage CreateDeleteRequest()
        {
            return endpointApi.CreateDeleteRequest(this.ApiCredential);
        }
    }
}
