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

        public Task<string> UploadAsync(string fileName, byte[] data)
        {
            return temporaryStorageApi.UploadAsync(fileName, data, this.ApiCredential);
        }

        public Task<int> CommitAsync(string fileName, string[] blockIds)
        {
            return temporaryStorageApi.CommitAsync(fileName, blockIds, this.ApiCredential);
        }

        public Task DeleteAsync(string fileName)
        {
            return temporaryStorageApi.DeleteAsync(fileName, this.ApiCredential);
        }
    }
}
