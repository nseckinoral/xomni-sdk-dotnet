using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.Passbook
{
    public class PassbookTemplateManagement : ApiAccessBase
    {
        private XOMNI.SDK.Private.ApiAccess.Passbook.PassbookTemplate passbookTemplateApi;

        protected override string SingleOperationBaseUrl
        {
            get { return "/private/passbook/templates"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        public PassbookTemplateManagement()
        {
            passbookTemplateApi = new ApiAccess.Passbook.PassbookTemplate();
        }

        public Task<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate> AddAsync(XOMNI.SDK.Model.Private.Passbook.PassbookTemplateRequest passbookTemplate, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate>(GenerateUrl(SingleOperationBaseUrl), passbookTemplate, credential);
        }

        public Task<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate> UpdateAsync(XOMNI.SDK.Model.Private.Passbook.PassbookTemplateRequest passbookTemplate, ApiBasicCredential credential)
        {
            return HttpProvider.PutAsync<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate>(GenerateUrl(SingleOperationBaseUrl), passbookTemplate, credential);
        }

        public Task<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate> PatchAsync(dynamic passbookTemplate, ApiBasicCredential credential)
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

    }
}
