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
    internal class ItemMetadata : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/itemmetadata"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/itemmetadata"; }
        }

        public async Task<ItemMetaData> AddMetadataAsync(ItemMetaData itemMetadata, ApiBasicCredential credential)
        {
            ItemMetaData createdMetadata = await HttpProvider.PostAsync<ItemMetaData>(GenerateUrl(SingleOperationBaseUrl), itemMetadata, credential);
            return createdMetadata;
        }

        public async Task DeleteMetadataAsync(int itemId, string metadataKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("itemId", itemId.ToString());
            additionalParameters.Add("metadataKey", metadataKey);

            await HttpProvider.DeleteAsync(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential);
        }

        public async Task ClearMetadataAsync(int itemId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("itemId", itemId.ToString());

            await HttpProvider.DeleteAsync(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

        public async Task<ItemMetaData> UpdateMetadataAsync(ItemMetaData itemMetadata, ApiBasicCredential credential)
        {
            ItemMetaData updatedMetadata = await HttpProvider.PutAsync<ItemMetaData>(GenerateUrl(SingleOperationBaseUrl), itemMetadata, credential);
            return updatedMetadata;
        }

        public async Task<List<Metadata>> GetAllMetadataAsync(int itemId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("itemId", itemId.ToString());
            List<Metadata> itemMetadataList = await HttpProvider.GetAsync<List<Metadata>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
            return itemMetadataList;
        }
    }
}
