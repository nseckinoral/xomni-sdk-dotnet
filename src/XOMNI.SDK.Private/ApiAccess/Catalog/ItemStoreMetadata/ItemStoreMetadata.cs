using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model.Private.Catalog;

namespace XOMNI.SDK.Private.ApiAccess.Catalog.ItemStoreMetadata
{
    internal class ItemStoreMetadata : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/items/{0}/storemetadata"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/items/{0}/storemetadata"; }
        }

        public Task<List<InStoreMetadata>> AddInStoreMetadataAsync(int itemId, List<InStoreMetadata> inStoreMetadataList, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync<List<InStoreMetadata>>(GenerateUrl(string.Format(SingleOperationBaseUrl, itemId)), inStoreMetadataList, credential);
        }

        public Task<List<InStoreMetadata>> UpdateInStoreMetadataAsync(int itemId, List<InStoreMetadata> inStoreMetadataList, ApiBasicCredential credential)
        {
            return HttpProvider.PutAsync<List<InStoreMetadata>>(GenerateUrl(string.Format(SingleOperationBaseUrl, itemId)), inStoreMetadataList, credential);
        }

        public Task DeleteInStoreMetadataAsync(int itemId, int? storeId, string metadataKey, string metadataKeyPrefix, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            if (storeId.HasValue)
            {
                additionalParameters.Add("storeId", storeId.Value.ToString());
            }
            if (!string.IsNullOrEmpty(metadataKey))
            {
                additionalParameters.Add("metadataKey", metadataKey);
            }
            if (!string.IsNullOrEmpty(metadataKeyPrefix))
            {
                additionalParameters.Add("metadataKeyPrefix", metadataKeyPrefix);
            }

            return HttpProvider.DeleteAsync(GenerateUrl(string.Format(SingleOperationBaseUrl, itemId), additionalParameters), credential);
        }

        public Task<List<InStoreMetadata>> GetAllInStoreMetadataAsync(int itemId, ApiBasicCredential credential)
        {
            return HttpProvider.GetAsync<List<InStoreMetadata>>(GenerateUrl(string.Format(ListOperationBaseUrl, itemId)), credential);
        }

        #region low level methods

        public XOMNIRequestMessage<List<InStoreMetadata>> CreateAddInStoreMetadataRequest(int itemId, List<InStoreMetadata> inStoreMetadataList, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<List<InStoreMetadata>>(HttpProvider.CreatePostRequest(GenerateUrl(string.Format(SingleOperationBaseUrl, itemId)), credential, inStoreMetadataList));
        }

        public XOMNIRequestMessage<List<InStoreMetadata>> CreateUpdateInStoreMetadataRequest(int itemId, List<InStoreMetadata> inStoreMetadataList, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<List<InStoreMetadata>>(HttpProvider.CreatePostRequest(GenerateUrl(string.Format(SingleOperationBaseUrl, itemId)), credential, inStoreMetadataList));
        }

        public XOMNIRequestMessage CreateDeleteInStoreMetadataRequest(int itemId, int? storeId, string metadataKey, string metadataKeyPrefix, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            if (storeId.HasValue)
            {
                additionalParameters.Add("storeId", storeId.Value.ToString());
            }
            if (!string.IsNullOrEmpty(metadataKey))
            {
                additionalParameters.Add("metadataKey", metadataKey);
            }
            if (!string.IsNullOrEmpty(metadataKeyPrefix))
            {
                additionalParameters.Add("metadataKeyPrefix", metadataKeyPrefix);
            }

            return new XOMNIRequestMessage(HttpProvider.CreateDeleteRequest(GenerateUrl(string.Format(SingleOperationBaseUrl, itemId), additionalParameters), credential));
        }

        public XOMNIRequestMessage<List<InStoreMetadata>> CreateGetAllInStoreMetadataRequest(int itemId, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<List<InStoreMetadata>>(HttpProvider.CreateGetRequest(GenerateUrl(string.Format(ListOperationBaseUrl, itemId)), credential));
        }

        #endregion
    }
}
