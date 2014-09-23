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

        public Task<ItemMetaData> AddMetadataAsync(ItemMetaData itemMetadata, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync<ItemMetaData>(GenerateUrl(SingleOperationBaseUrl), itemMetadata, credential);
        }

        public Task DeleteMetadataAsync(int itemId, string metadataKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("itemId", itemId.ToString());
            additionalParameters.Add("metadataKey", metadataKey);

            return HttpProvider.DeleteAsync(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential);
        }

        public Task ClearMetadataAsync(int itemId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("itemId", itemId.ToString());

            return HttpProvider.DeleteAsync(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

        public Task<ItemMetaData> UpdateMetadataAsync(ItemMetaData itemMetadata, ApiBasicCredential credential)
        {
            return HttpProvider.PutAsync<ItemMetaData>(GenerateUrl(SingleOperationBaseUrl), itemMetadata, credential);
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
