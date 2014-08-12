using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Management.ApiAccess.Company;
using XOMNI.SDK.Model;

namespace XOMNI.SDK.Management.Company
{
    public class DeviceManagement : ManagementBase
    {
        private Devices devicesApi;
        public DeviceManagement()
        {
            devicesApi = new Devices();
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
    }
}
