using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model;
using XOMNI.SDK.Core.Providers;
using System.Net.Http;

namespace XOMNI.SDK.Core.ApiAccess
{
    public class CRUDApiAccessBase<T> : ApiAccessBase
    {
        public virtual Task<T> GetByIdAsync(int id, ApiBasicCredential credential)
        {
            return HttpProvider.GetAsync<T>(GenerateUrl(string.Format(SingleOperationBaseUrl, id)), credential);
        }

        public virtual Task<CountedCollectionContainer<T>> GetAllAsync(int skip, int take, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("skip", skip.ToString());
            additionalParameters.Add("take", take.ToString());
            return HttpProvider.GetAsync<CountedCollectionContainer<T>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

        public virtual Task<List<T>> GetByCustomListOperationUrlAsync(Dictionary<string, string> additionalParameters, ApiBasicCredential credential)
        {
            return HttpProvider.GetAsync<List<T>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

        public virtual Task<T> PostByCustomListOperationUrlAsync<T>(object body, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync<T>(GenerateUrl(ListOperationBaseUrl), body, credential);
        }

        public virtual Task<T> PostAsync(T entity, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync<T>(string.Format(GenerateUrl(SingleOperationBaseUrl), string.Empty), entity, credential);
        }

        public virtual Task DeleteAsync(int id, ApiBasicCredential credential)
        {
            return HttpProvider.DeleteAsync(GenerateUrl(string.Format(SingleOperationBaseUrl, id)), credential);
        }

        public virtual Task<T> PutAsync(T entity, ApiBasicCredential credential)
        {
            return HttpProvider.PutAsync<T>(GenerateUrl(SingleOperationBaseUrl), entity, credential);
        }

        #region Low level methods
        public virtual XOMNIRequestMessage<T> CreateGetByIdRequest(int id, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<T>(HttpProvider.CreateGetRequest(GenerateUrl(string.Format(SingleOperationBaseUrl, id)), credential));
        }

        public virtual XOMNIRequestMessage<CountedCollectionContainer<T>> CreateGetAllRequest(int skip, int take, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("skip", skip.ToString());
            additionalParameters.Add("take", take.ToString());
            return new XOMNIRequestMessage<CountedCollectionContainer<T>>(HttpProvider.CreateGetRequest(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential));
        }

        public virtual XOMNIRequestMessage<List<T>> CreateGetByCustomListOperationUrlRequest(Dictionary<string, string> additionalParameters, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<List<T>>(HttpProvider.CreateGetRequest(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential));
        }

        public virtual XOMNIRequestMessage<T> CreatePostByCustomListOperationUrlRequest<T>(object body, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<T>(HttpProvider.CreatePostRequest(GenerateUrl(ListOperationBaseUrl), credential, body));
        }

        public virtual XOMNIRequestMessage<T> CreatePostRequest(T entity, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<T>(HttpProvider.CreatePostRequest(string.Format(GenerateUrl(SingleOperationBaseUrl), string.Empty), credential, entity));
        }

        public virtual XOMNIRequestMessage CreateDeleteRequest(int id, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage(HttpProvider.CreateDeleteRequest(GenerateUrl(string.Format(SingleOperationBaseUrl, id)), credential));
        }

        public virtual XOMNIRequestMessage<T> CreatePutRequest(T entity, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<T>(HttpProvider.CreatePutRequest(GenerateUrl(SingleOperationBaseUrl), credential, entity));
        }

        public virtual XOMNIRequestMessage<T> CreatePatchRequest(dynamic entity, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<T>(HttpProvider.CreatePatchRequest(GenerateUrl(SingleOperationBaseUrl), credential, entity));
        }

        #endregion

        protected override string SingleOperationBaseUrl
        {
            get { return string.Empty; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return string.Empty; }
        }
    }
}
