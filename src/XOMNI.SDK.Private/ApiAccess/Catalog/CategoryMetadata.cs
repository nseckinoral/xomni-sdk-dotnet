using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model;
using XOMNI.SDK.Model.Catalog;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.ApiAccess.Catalog
{
    internal class CategoryMetadata : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/categorymetadata"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/categorymetadata"; }
        }

        /// <summary>
        /// Adds a new metadata to given category.
        /// </summary>
        /// <param name="categoryId">The unique id of the category.</param>
        /// <param name="metadataKey">Key for the metadata.</param>
        /// <param name="metadataValue">Value for the metadata.</param>
        /// <returns>Created metadata instance.</returns>
        /// <exception cref="XOMNI.SDK.Core.Exception.NotFoundException">Given category not found in backend.</exception>
        /// <exception cref="XOMNI.SDK.Core.Exception.ConflictException">Given metadata key already exists in category metadata collection.</exception>
        public async Task<CategoryMetaData> AddMetadataAsync(CategoryMetaData categoryMetadata, ApiBasicCredential credential)
        {
            CategoryMetaData createdMetadata = await HttpProvider.PostAsync<CategoryMetaData>(GenerateUrl(SingleOperationBaseUrl), categoryMetadata,credential);
            return createdMetadata;
        }

        public async Task DeleteMetadataAsync(int categoryId, string metadataKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("categoryId", categoryId.ToString());
            additionalParameters.Add("metadataKey", metadataKey);

            await HttpProvider.DeleteAsync(GenerateUrl(SingleOperationBaseUrl, additionalParameters),credential);
        }

        public async Task ClearMetadataAsync(int categoryId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("categoryId", categoryId.ToString());

            await HttpProvider.DeleteAsync(GenerateUrl(ListOperationBaseUrl, additionalParameters),credential);
        }

        public async Task<List<Metadata>> GetAllMetadataAsync(int categoryId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("categoryId", categoryId.ToString());
            List<Metadata> categoryMetadataList = await HttpProvider.GetAsync<List<Metadata>>(GenerateUrl(ListOperationBaseUrl, additionalParameters),credential);
            return categoryMetadataList;
        }

        public async Task<CategoryMetaData> UpdateMetadataAsync(CategoryMetaData categoryMetadata, ApiBasicCredential credential)
        {
            CategoryMetaData updatedMetadata = await HttpProvider.PutAsync<CategoryMetaData>(GenerateUrl(SingleOperationBaseUrl), categoryMetadata,credential);
            return updatedMetadata;
        }
    }
}
