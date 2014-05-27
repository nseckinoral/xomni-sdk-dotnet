using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.ApiAccess.Asset
{
    internal class Temp : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/asset/temp"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        public async Task<string> UploadAsync(string fileName, byte[] data, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("fileName", fileName);
            return await HttpProvider.PutAsync<string>(GenerateUrl(SingleOperationBaseUrl, additionalParameters), data, credential);
        }

        public async Task<int> CommitAsync(string fileName, string[] blockIds, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("fileName", fileName);
            return await HttpProvider.PostAsync<int>(GenerateUrl(SingleOperationBaseUrl, additionalParameters), blockIds, credential, System.Net.HttpStatusCode.Created);
        }

        public async Task DeleteAsync(string fileName, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("fileName", fileName);
            await HttpProvider.DeleteAsync(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential);
        }
    }
}
