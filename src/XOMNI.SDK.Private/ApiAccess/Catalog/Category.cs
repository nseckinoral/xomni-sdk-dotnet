using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Model.Catalog;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using XOMNI.SDK.Model;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Core.ApiAccess;

namespace XOMNI.SDK.Private.ApiAccess.Catalog
{
    /// <summary>
    /// Category class is responsible for category spesific backend operations
    /// </summary>
    internal class Category : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/category/{0}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/categories"; }
        }

        public Task<XOMNI.SDK.Model.Private.Catalog.Category> AddAsync(XOMNI.SDK.Model.Private.Catalog.Category category, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync<XOMNI.SDK.Model.Private.Catalog.Category>(GenerateUrl(SingleOperationBaseUrl), category, credential);
        }

        public Task<XOMNI.SDK.Model.Private.Catalog.Category> UpdateAsync(XOMNI.SDK.Model.Catalog.Category category, ApiBasicCredential credential)
        {
            return HttpProvider.PutAsync<XOMNI.SDK.Model.Private.Catalog.Category>(GenerateUrl(SingleOperationBaseUrl), category, credential);
        }

        public Task DeleteAsync(int categoryId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("categoryId", categoryId.ToString());

            return HttpProvider.DeleteAsync(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential);
        }

        public Task<Model.Private.Catalog.CategoryTree> GetCategoryTreeAsync(ApiBasicCredential credential)
        {
            return HttpProvider.GetAsync<Model.Private.Catalog.CategoryTree>(GenerateUrl(ListOperationBaseUrl), credential);
        }

        public Task<XOMNI.SDK.Model.Private.Catalog.Category> GetByIdAsync(int categoryId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("categoryId", categoryId.ToString());

            return HttpProvider.GetAsync<XOMNI.SDK.Model.Private.Catalog.Category>(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential);
        }

        internal Task<Model.Private.Catalog.Category> PatchAsync(dynamic category, ApiBasicCredential credential)
        {
            return HttpProvider.PatchAsync<XOMNI.SDK.Model.Private.Catalog.Category>(GenerateUrl(SingleOperationBaseUrl), category, credential);
        }

        #region low level methods
        public XOMNIRequestMessage<XOMNI.SDK.Model.Private.Catalog.Category> CreateAddRequest(XOMNI.SDK.Model.Private.Catalog.Category category, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<Model.Private.Catalog.Category>(HttpProvider.CreatePostRequest(GenerateUrl(SingleOperationBaseUrl), credential, category));
        }

        public XOMNIRequestMessage<XOMNI.SDK.Model.Private.Catalog.Category> CreateUpdateRequest(XOMNI.SDK.Model.Catalog.Category category, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<Model.Private.Catalog.Category>(HttpProvider.CreatePutRequest(GenerateUrl(SingleOperationBaseUrl), credential, category));
        }

        public XOMNIRequestMessage CreateDeleteRequest(int categoryId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("categoryId", categoryId.ToString());

            return new XOMNIRequestMessage(HttpProvider.CreateDeleteRequest(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential));
        }

        public XOMNIRequestMessage<Model.Private.Catalog.CategoryTree> CreateGetCategoryTreeRequest(ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<Model.Private.Catalog.CategoryTree>(HttpProvider.CreateGetRequest(GenerateUrl(ListOperationBaseUrl), credential));
        }

        public XOMNIRequestMessage<XOMNI.SDK.Model.Private.Catalog.Category> CreateGetByIdRequest(int categoryId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("categoryId", categoryId.ToString());

            return new XOMNIRequestMessage<Model.Private.Catalog.Category>(HttpProvider.CreateGetRequest(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential));
        }

        internal XOMNIRequestMessage<Model.Private.Catalog.Category> CreatePatchRequest(dynamic category, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<Model.Private.Catalog.Category>(HttpProvider.CreatePatchRequest(GenerateUrl(SingleOperationBaseUrl), credential, category));
        }
        #endregion
    }
}
