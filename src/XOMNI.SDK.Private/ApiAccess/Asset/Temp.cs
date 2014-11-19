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

        public Task<string> UploadAsync(string fileName, byte[] data, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("fileName", fileName);
            return HttpProvider.PutAsync<string>(GenerateUrl(SingleOperationBaseUrl, additionalParameters), data, credential);
        }

        public Task<int> CommitAsync(string fileName, string[] blockIds, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("fileName", fileName);
            return HttpProvider.PostAsync<int>(GenerateUrl(SingleOperationBaseUrl, additionalParameters), blockIds, credential, System.Net.HttpStatusCode.Created);
        }

        public Task DeleteAsync(string fileName, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("fileName", fileName);
            return HttpProvider.DeleteAsync(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential);
        }

        #region low level methods
        public XOMNIRequestMessage<string> CreateUploadRequest(string fileName, byte[] data, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("fileName", fileName);
            return new XOMNIRequestMessage<string>(HttpProvider.CreatePutRequest(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential, data));
        }

        public XOMNIRequestMessage<int> CreateCommitRequest(string fileName, string[] blockIds, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("fileName", fileName);
            return  new XOMNIRequestMessage<int>(HttpProvider.CreatePostRequest(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential, blockIds));
        }

        public XOMNIRequestMessage CreateDeleteRequest(string fileName, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("fileName", fileName);
            return new XOMNIRequestMessage(HttpProvider.CreateDeleteRequest(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential));
        }

        #endregion
    }
}
