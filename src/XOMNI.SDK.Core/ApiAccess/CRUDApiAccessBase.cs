using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model;
using XOMNI.SDK.Core.Providers;

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

        public virtual Task<T> PostByCustomListOperationUrlAsync<T>(Dictionary<string, string> additionalParameters, object body, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync<T>(GenerateUrl(ListOperationBaseUrl, additionalParameters), body, credential);
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
