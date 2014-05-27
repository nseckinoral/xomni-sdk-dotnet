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
    internal class TagMetadata : ApiAccessBase
    {
        public async Task<TagMetaData> AddMetadataAsync(TagMetaData tagMetadata, ApiBasicCredential credential)
        {
            TagMetaData createdMetadata = await HttpProvider.PostAsync<TagMetaData>(GenerateUrl(SingleOperationBaseUrl), tagMetadata, credential);
            return createdMetadata;
        }

        public async Task<List<Metadata>> GetAllMetadataAsync(int tagId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("tagId", tagId.ToString());
            List<Metadata> tagMetadataList = await HttpProvider.GetAsync<List<Metadata>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
            return tagMetadataList;
        }

        public async Task DeleteMetadataAsync(int tagId, string metadataKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("tagId", tagId.ToString());
            additionalParameters.Add("metadataKey", metadataKey);

            await HttpProvider.DeleteAsync(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential);
        }

        public async Task<TagMetaData> UpdateMetadataAsync(TagMetaData tagMetadata, ApiBasicCredential credential)
        {
            TagMetaData updatedMetadata = await HttpProvider.PutAsync<TagMetaData>(GenerateUrl(SingleOperationBaseUrl), tagMetadata, credential);
            return updatedMetadata;
        }

        public async Task ClearMetadataAsync(int tagId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("tagId", tagId.ToString());

            await HttpProvider.DeleteAsync(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/tagmetadata"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/tagmetadata"; }
        }
    }
}
