using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Private.ApiAccess.Asset;

namespace XOMNI.SDK.Private.Asset
{
    public class TemporaryStorageManagement : ManagementBase
    {
        private Temp temporaryStorageApi;

        public TemporaryStorageManagement()
        {
            temporaryStorageApi = new Temp();
        }

        public async Task<string> UploadAsync(string fileName, byte[] data)
        {
            return await temporaryStorageApi.UploadAsync(fileName, data, this.ApiCredential);
        }

        public async Task<int> CommitAsync(string fileName, string[] blockIds)
        {
            return await temporaryStorageApi.CommitAsync(fileName, blockIds, this.ApiCredential);
        }

        public async Task DeleteAsync(string fileName)
        {
            await temporaryStorageApi.DeleteAsync(fileName, this.ApiCredential);
        }
    }
}
