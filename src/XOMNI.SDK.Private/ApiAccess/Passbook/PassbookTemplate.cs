using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.ApiAccess.Passbook
{
    public class PassbookTemplate : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/passbook/template"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/passbook/templates"; }
        }

        public Task<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate> AddAsync(XOMNI.SDK.Model.Private.Passbook.PassbookTemplateRequest passbookTemplate, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate>(GenerateUrl(SingleOperationBaseUrl), passbookTemplate, credential);
        }

        public Task<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate> UpdateAsync(XOMNI.SDK.Model.Private.Passbook.PassbookTemplateRequest passbookTemplate, ApiBasicCredential credential)
        {
            return HttpProvider.PutAsync<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate>(GenerateUrl(SingleOperationBaseUrl), passbookTemplate, credential);
        }
        public Task<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate> UpdateAsync(dynamic passbookTemplate, ApiBasicCredential credential)
        {
            return HttpProvider.PatchAsync<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate>(GenerateUrl(SingleOperationBaseUrl), passbookTemplate, credential);
        }

        public Task DeleteAsync(int templateId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("templateId", templateId.ToString());

            return HttpProvider.DeleteAsync(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential);
        }

        public Task<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate> GetAsync(int templateId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("templateId", templateId.ToString());

            return HttpProvider.GetAsync<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate>(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential);
        }

        public Task<XOMNI.SDK.Model.CountedCollectionContainer<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate>> GetAllAsync(int skip, int take, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("skip", skip.ToString());
            additionalParameters.Add("take", take.ToString());

            return HttpProvider.GetAsync<XOMNI.SDK.Model.CountedCollectionContainer<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }
        #region low level methods
        public XOMNIRequestMessage<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate> CreateAddRequest(XOMNI.SDK.Model.Private.Passbook.PassbookTemplateRequest passbookTemplate, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<Model.Private.Passbook.PassbookTemplate>(HttpProvider.CreatePostRequest(GenerateUrl(SingleOperationBaseUrl), credential, passbookTemplate));
        }

        public XOMNIRequestMessage<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate> CreateUpdateRequest(XOMNI.SDK.Model.Private.Passbook.PassbookTemplateRequest passbookTemplate, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<Model.Private.Passbook.PassbookTemplate>(HttpProvider.CreatePutRequest(GenerateUrl(SingleOperationBaseUrl), credential, passbookTemplate));
        }
        public XOMNIRequestMessage<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate> CreateUpdateRequest(dynamic passbookTemplate, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<Model.Private.Passbook.PassbookTemplate>(HttpProvider.CreatePatchRequest(GenerateUrl(SingleOperationBaseUrl), credential, passbookTemplate));
        }

        public XOMNIRequestMessage CreateDeleteRequest(int templateId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("templateId", templateId.ToString());

            return new XOMNIRequestMessage(HttpProvider.CreateDeleteRequest(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential));
        }

        public XOMNIRequestMessage<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate> CreateGetRequest(int templateId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("templateId", templateId.ToString());

            return new XOMNIRequestMessage<Model.Private.Passbook.PassbookTemplate>(HttpProvider.CreateGetRequest(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential));
        }

        public XOMNIRequestMessage<XOMNI.SDK.Model.CountedCollectionContainer<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate>> CreateGetAllRequest(int skip, int take, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("skip", skip.ToString());
            additionalParameters.Add("take", take.ToString());

            return new XOMNIRequestMessage<Model.CountedCollectionContainer<Model.Private.Passbook.PassbookTemplate>>(HttpProvider.CreateGetRequest(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential));
        }

        #endregion
    }
}
