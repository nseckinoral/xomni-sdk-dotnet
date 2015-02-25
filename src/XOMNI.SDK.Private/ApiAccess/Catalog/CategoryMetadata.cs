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
        public Task<CategoryMetaData> AddMetadataAsync(CategoryMetaData categoryMetadata, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync<CategoryMetaData>(GenerateUrl(SingleOperationBaseUrl), categoryMetadata, credential);
        }

        public Task DeleteMetadataAsync(int categoryId, string metadataKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("categoryId", categoryId.ToString());
            additionalParameters.Add("metadataKey", metadataKey);

            return HttpProvider.DeleteAsync(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential);
        }

        public Task ClearMetadataAsync(int categoryId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("categoryId", categoryId.ToString());

            return HttpProvider.DeleteAsync(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

        public Task<List<Metadata>> GetAllMetadataAsync(int categoryId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("categoryId", categoryId.ToString());
            return HttpProvider.GetAsync<List<Metadata>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

        public Task<CategoryMetaData> UpdateMetadataAsync(CategoryMetaData categoryMetadata, ApiBasicCredential credential)
        {
            return HttpProvider.PutAsync<CategoryMetaData>(GenerateUrl(SingleOperationBaseUrl), categoryMetadata, credential);
        }

        #region low level methods
        public XOMNIRequestMessage<CategoryMetaData> CreateAddMetadataRequest(CategoryMetaData categoryMetadata, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<CategoryMetaData>(HttpProvider.CreatePostRequest(GenerateUrl(SingleOperationBaseUrl), credential, categoryMetadata));
        }

        public XOMNIRequestMessage CreateDeleteMetadataRequest(int categoryId, string metadataKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("categoryId", categoryId.ToString());
            additionalParameters.Add("metadataKey", metadataKey);

            return new XOMNIRequestMessage(HttpProvider.CreateDeleteRequest(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential));
        }

        public XOMNIRequestMessage CreateClearMetadataRequest(int categoryId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("categoryId", categoryId.ToString());
            return new XOMNIRequestMessage(HttpProvider.CreateDeleteRequest(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential));
        }

        public XOMNIRequestMessage<CategoryMetaData> CreateUpdateMetadataRequest(CategoryMetaData categoryMetadata, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<CategoryMetaData>(HttpProvider.CreatePutRequest(GenerateUrl(SingleOperationBaseUrl), credential, categoryMetadata));
        }

        public XOMNIRequestMessage<List<Metadata>> CreateGetAllMetadataRequest(int categoryId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("categoryId", categoryId.ToString());
            return new XOMNIRequestMessage<List<Metadata>>(HttpProvider.CreateGetRequest(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential));
        }

        #endregion
    }
}
