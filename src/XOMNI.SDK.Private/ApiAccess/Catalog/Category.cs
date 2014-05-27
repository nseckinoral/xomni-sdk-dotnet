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

        public Task<Model.Private.Catalog.CategoryTree> GetCategoryTree(ApiBasicCredential credential)
        {
            return HttpProvider.GetAsync<Model.Private.Catalog.CategoryTree>(GenerateUrl(ListOperationBaseUrl), credential);
        }

        public Task<XOMNI.SDK.Model.Private.Catalog.Category> GetById(int categoryId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("categoryId", categoryId.ToString());

            return HttpProvider.GetAsync<XOMNI.SDK.Model.Private.Catalog.Category>(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential);
        }
    }
}
