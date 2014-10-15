using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;

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

        public Task<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate> UpdateAsync(dynamic passbookTemplate)
        {
            return passbookTemplateApi.UpdateAsync(passbookTemplate, this.ApiCredential);
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
    }
}
