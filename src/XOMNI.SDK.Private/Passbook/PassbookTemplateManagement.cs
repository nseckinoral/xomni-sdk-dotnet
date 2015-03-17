using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.Passbook
{
    public class PassbookTemplateManagement : ManagementBase
    {
        private XOMNI.SDK.Private.ApiAccess.Passbook.PassbookTemplate passbookTemplateApi;

        public PassbookTemplateManagement()
        {
            passbookTemplateApi = new ApiAccess.Passbook.PassbookTemplate();
        }

        public Task<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate> AddAsync(XOMNI.SDK.Model.Private.Passbook.PassbookTemplateRequest passbookTemplate)
        {
            return passbookTemplateApi.AddAsync(passbookTemplate, this.ApiCredential);
        }

        public Task<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate> UpdateAsync(XOMNI.SDK.Model.Private.Passbook.PassbookTemplateRequest passbookTemplate)
        {
            return passbookTemplateApi.UpdateAsync(passbookTemplate, this.ApiCredential);
        }

        public Task<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate> PatchAsync(dynamic passbookTemplate)
        {
            return passbookTemplateApi.PatchAsync(passbookTemplate, this.ApiCredential);
        }

        public Task DeleteAsync(int templateId)
        {
            return passbookTemplateApi.DeleteAsync(templateId, this.ApiCredential);
        }

        public Task<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate> GetAsync(int templateId)
        {
            return passbookTemplateApi.GetAsync(templateId, this.ApiCredential);
        }

        public Task<XOMNI.SDK.Model.CountedCollectionContainer<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate>> GetAllAsync(int skip, int take)
        {
            return passbookTemplateApi.GetAllAsync(skip, take, this.ApiCredential);
        }

        #region low level methods

        public XOMNIRequestMessage<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate> CreateAddRequest(XOMNI.SDK.Model.Private.Passbook.PassbookTemplateRequest passbookTemplate)
        {
            return passbookTemplateApi.CreateAddRequest(passbookTemplate, this.ApiCredential);
        }

        public XOMNIRequestMessage<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate> CreateUpdateRequest(XOMNI.SDK.Model.Private.Passbook.PassbookTemplateRequest passbookTemplate)
        {
            return passbookTemplateApi.CreateUpdateRequest(passbookTemplate, this.ApiCredential);
        }

        public XOMNIRequestMessage<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate> CreateUpdateRequest(dynamic passbookTemplate)
        {
            return passbookTemplateApi.CreateUpdateRequest(passbookTemplate, this.ApiCredential);
        }

        public XOMNIRequestMessage CreateDeleteRequest(int templateId)
        {
            return passbookTemplateApi.CreateDeleteRequest(templateId, this.ApiCredential);
        }

        public XOMNIRequestMessage<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate> CreateGetRequest(int templateId)
        {
            return passbookTemplateApi.CreateGetRequest(templateId, this.ApiCredential);
        }

        public XOMNIRequestMessage<XOMNI.SDK.Model.CountedCollectionContainer<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate>> CreateGetAllRequest(int skip, int take)
        {
            return passbookTemplateApi.CreateGetAllRequest(skip, take, this.ApiCredential);
        }
        
        #endregion
    }
}
