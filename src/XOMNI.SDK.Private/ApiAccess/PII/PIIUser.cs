using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model;

namespace XOMNI.SDK.Private.ApiAccess.PII
{
    public class PIIUser : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/pii/user/{0}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/pii/users"; }
        }

        public virtual Task<CountedCollectionContainer<SDK.Model.Private.PII.PIIUser>> GetAllAsync(int skip, int take, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("skip", skip.ToString());
            additionalParameters.Add("take", take.ToString());
            return HttpProvider.GetAsync<CountedCollectionContainer<SDK.Model.Private.PII.PIIUser>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }
        public virtual Task<CountedCollectionContainer<SDK.Model.Private.PII.PIIUser>> GetByCreatedOADate(int createdOADate, int skip, int take, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("skip", skip.ToString());
            additionalParameters.Add("take", take.ToString());
            additionalParameters.Add("createdOADate", createdOADate.ToString());
            return HttpProvider.GetAsync<CountedCollectionContainer<SDK.Model.Private.PII.PIIUser>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

        public virtual Task<SDK.Model.Private.PII.PIIUser> PostAsync(SDK.Model.Private.PII.PIIUser entity, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync<SDK.Model.Private.PII.PIIUser>(string.Format(GenerateUrl(SingleOperationBaseUrl), string.Empty), entity, credential);
        }

        public virtual Task DeleteAsync(int id, ApiBasicCredential credential)
        {
            return HttpProvider.DeleteAsync(GenerateUrl(string.Format(SingleOperationBaseUrl, id)), credential);
        }

        #region Low level methods

        public virtual XOMNIRequestMessage<CountedCollectionContainer<SDK.Model.Private.PII.PIIUser>> CreateGetAllRequest(int skip, int take, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("skip", skip.ToString());
            additionalParameters.Add("take", take.ToString());
            return new XOMNIRequestMessage<CountedCollectionContainer<Model.Private.PII.PIIUser>>(HttpProvider.CreateGetRequest(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential));
        }
        public virtual XOMNIRequestMessage<CountedCollectionContainer<SDK.Model.Private.PII.PIIUser>> CreateGetByCreatedOADateRequest(int createdOADate, int skip, int take, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("skip", skip.ToString());
            additionalParameters.Add("take", take.ToString());
            additionalParameters.Add("createdOADate", createdOADate.ToString());
            return new XOMNIRequestMessage<CountedCollectionContainer<Model.Private.PII.PIIUser>>(HttpProvider.CreateGetRequest(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential));
        }

        public virtual XOMNIRequestMessage<SDK.Model.Private.PII.PIIUser> CreatePostRequest(SDK.Model.Private.PII.PIIUser entity, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<Model.Private.PII.PIIUser>(HttpProvider.CreatePostRequest(string.Format(GenerateUrl(SingleOperationBaseUrl), string.Empty), credential, entity));
        }

        public virtual XOMNIRequestMessage CreateDeleteRequest(int id, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage(HttpProvider.CreateDeleteRequest(GenerateUrl(string.Format(SingleOperationBaseUrl, id)), credential));
        }

        #endregion
    }
}
