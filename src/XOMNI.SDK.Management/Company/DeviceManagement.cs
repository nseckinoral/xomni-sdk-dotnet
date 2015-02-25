using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Management.ApiAccess.Company;
using XOMNI.SDK.Model;

namespace XOMNI.SDK.Management.Company
{
    public class DeviceManagement : ManagementBase
    {
        private Devices devicesApi;
        private DeviceMetadata deviceMetadataApi;
        public DeviceManagement()
        {
            devicesApi = new Devices();
            deviceMetadataApi = new DeviceMetadata();
        }

        public Task<CountedCollectionContainer<XOMNI.SDK.Model.Management.Company.Device>> GetAllAsync(int skip, int take)
        {
            return devicesApi.GetAllAsync(skip, take, this.ApiCredential);
        }

        public Task<XOMNI.SDK.Model.Management.Company.Device> AddAsync(XOMNI.SDK.Model.Management.Company.Device device)
        {
            return devicesApi.CreateAsync(device, this.ApiCredential);
        }

        public Task<XOMNI.SDK.Model.Management.Company.Device> UpdateAsync(XOMNI.SDK.Model.Management.Company.Device device)
        {
            return devicesApi.UpdateAsync(device, this.ApiCredential);
        }

        public Task DeleteAsync(string deviceId, int relatedLicenceId)
        {
            return devicesApi.DeleteAsync(deviceId, relatedLicenceId, this.ApiCredential);
        }

        public Task<XOMNI.SDK.Model.Management.Company.Device> GetAsync(string deviceId, int relatedLicenceId)
        {
            return devicesApi.GetAsync(deviceId, relatedLicenceId, this.ApiCredential);
        }

        public Task<Metadata> AddMetadataAsync(string deviceId, int relatedLicenceId, Metadata metadata)
        {
            return deviceMetadataApi.CreateAsync(deviceId, relatedLicenceId, metadata, this.ApiCredential);
        }

        public Task<Metadata> UpdateMetadataAsync(string deviceId, int relatedLicenceId, Metadata metadata)
        {
            return deviceMetadataApi.UpdateAsync(deviceId, relatedLicenceId, metadata, this.ApiCredential);
        }

        public Task DeleteMetadataAsync(string deviceId, int relatedLicenceId, string metadataKey)
        {
            return deviceMetadataApi.DeleteAsync(deviceId, relatedLicenceId, metadataKey, this.ApiCredential);
        }

        public Task ClearMetadataAsync(string deviceId, int relatedLicenceId)
        {
            return deviceMetadataApi.DeleteAsync(deviceId, relatedLicenceId, this.ApiCredential);
        }

        public Task<List<Metadata>> GetMetadataAsync(string deviceId, int relatedLicenceId)
        {
            return deviceMetadataApi.GetAsync(deviceId, relatedLicenceId, this.ApiCredential);
        }

        // For batch

        public virtual XOMNIRequestMessage<CountedCollectionContainer<XOMNI.SDK.Model.Management.Company.Device>> CreateGetAllRequest(int skip, int take)
        {
            return devicesApi.CreateGetAllRequest(skip, take, this.ApiCredential);
        }

        public virtual XOMNIRequestMessage<XOMNI.SDK.Model.Management.Company.Device> CreatePostRequest(XOMNI.SDK.Model.Management.Company.Device entity)
        {
            return devicesApi.CreatePostRequest(entity, this.ApiCredential);
        }

        public virtual XOMNIRequestMessage<XOMNI.SDK.Model.Management.Company.Device> CreatePutRequest(XOMNI.SDK.Model.Management.Company.Device entity)
        {
            return devicesApi.CreatePutRequest(entity, this.ApiCredential);
        }
        public virtual XOMNIRequestMessage CreateDeleteRequest(int id)
        {
            return devicesApi.CreateDeleteRequest(id, this.ApiCredential);
        }

        public virtual XOMNIRequestMessage<XOMNI.SDK.Model.Management.Company.Device> CreateGetByIdRequest(string deviceId, int relatedLicenceId)
        {
            return devicesApi.CreateGetByIdRequest(deviceId, relatedLicenceId, this.ApiCredential);
        }

        // For batch metadata
        public XOMNIRequestMessage<Metadata> CreatePostMetadataRequest(string deviceId, int relatedLicenceId, Metadata metadata)
        {
            return deviceMetadataApi.CreatePostRequest(deviceId, relatedLicenceId, metadata, this.ApiCredential);
        }

        public XOMNIRequestMessage<Metadata> CreatePutMetadataRequest(string deviceId, int relatedLicenceId, Metadata metadata)
        {
            return deviceMetadataApi.CreatePutRequest(deviceId, relatedLicenceId, metadata, this.ApiCredential);
        }

        public XOMNIRequestMessage CreateDeleteMetadataRequest(string deviceId, int relatedLicenceId, string metadataKey)
        {
            return deviceMetadataApi.CreateDeleteRequest(deviceId, relatedLicenceId, metadataKey, this.ApiCredential);
        }

        public XOMNIRequestMessage CreateClearMetadataRequest(string deviceId, int relatedLicenceId)
        {
            return deviceMetadataApi.CreateDeleteRequest(deviceId, relatedLicenceId, this.ApiCredential);
        }

        public XOMNIRequestMessage<List<Metadata>> CreateGetMetadataRequest(string deviceId, int relatedLicenceId)
        {
            return deviceMetadataApi.CreateGetByIdRequest(deviceId, relatedLicenceId, this.ApiCredential);
        }
    }
}
