using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model;

namespace XOMNI.SDK.Private.PII
{
    public class PIIUserManagement : ManagementBase
    {
        private XOMNI.SDK.Private.ApiAccess.PII.PIIUser piiUserApiAccess = null;
        public PIIUserManagement()
        {
            piiUserApiAccess = new ApiAccess.PII.PIIUser();
        }

        public virtual Task<CountedCollectionContainer<SDK.Model.Private.PII.PIIUser>> GetAllAsync(int skip, int take)
        {
            return piiUserApiAccess.GetAllAsync(skip, take, this.ApiCredential);
        }
        public virtual Task<CountedCollectionContainer<SDK.Model.Private.PII.PIIUser>> GetByCreatedOADate(int createdOADate, int skip, int take)
        {
            return piiUserApiAccess.GetByCreatedOADate(createdOADate, skip, take, this.ApiCredential);
        }

        public virtual Task<SDK.Model.Private.PII.PIIUser> PostAsync(SDK.Model.Private.PII.PIIUser entity)
        {
            return piiUserApiAccess.PostAsync(entity, this.ApiCredential);            
        }

        public virtual Task DeleteAsync(int id)
        {
            return piiUserApiAccess.DeleteAsync(id, this.ApiCredential);            
        }

        #region Low level methods

        public virtual XOMNIRequestMessage<CountedCollectionContainer<SDK.Model.Private.PII.PIIUser>> CreateGetAllRequest(int skip, int take)
        {
            return piiUserApiAccess.CreateGetAllRequest(skip, take, this.ApiCredential);
        }
        public virtual XOMNIRequestMessage<CountedCollectionContainer<SDK.Model.Private.PII.PIIUser>> CreateGetByCreatedOADateRequest(int createdOADate, int skip, int take)
        {
            return piiUserApiAccess.CreateGetByCreatedOADateRequest(createdOADate, skip, take, this.ApiCredential);
        }

        public virtual XOMNIRequestMessage<SDK.Model.Private.PII.PIIUser> CreatePostRequest(SDK.Model.Private.PII.PIIUser entity)
        {
            return piiUserApiAccess.CreatePostRequest(entity, this.ApiCredential);
        }

        public virtual XOMNIRequestMessage CreateDeleteRequest(int id)
        {
            return piiUserApiAccess.CreateDeleteRequest(id, this.ApiCredential);
        }
        #endregion
    }
}
