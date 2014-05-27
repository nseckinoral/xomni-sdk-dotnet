using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model;
using XOMNI.SDK.Model.Catalog;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Private.ApiAccess.Catalog;

namespace XOMNI.SDK.Private.Catalog
{
    public class TagManagement : BaseCRUDSkipTakeManagement<Model.Catalog.Tag>
    {
        private TagMetadata tagMetadataApi;

        public TagManagement()
        {
            tagMetadataApi = new TagMetadata();
        }

        public async Task<TagMetaData> AddMetadataAsync(int tagId, string metadataKey, string metadataValue)
        {
            var metadata = CreateTagMetadata(tagId, metadataKey, metadataValue);
            TagMetaData createdMetadata = await tagMetadataApi.AddMetadataAsync(metadata, this.ApiCredential);
            return createdMetadata;
        }

        public async Task<List<Metadata>> GetAllMetadataAsync(int tagId)
        {
            List<Metadata> tagMetadataList = await tagMetadataApi.GetAllMetadataAsync(tagId, this.ApiCredential);
            return tagMetadataList;
        }

        public async Task DeleteMetadataAsync(int tagId, string metadataKey)
        {
            if (String.IsNullOrEmpty(metadataKey))
            {
                throw new ArgumentNullException("metadataKey");
            }
            await tagMetadataApi.DeleteMetadataAsync(tagId, metadataKey, this.ApiCredential);
        }

        public async Task<TagMetaData> UpdateMetadataAsync(int tagId, string metadataKey, string updatedMetadataValue)
        {
            var metadata = CreateTagMetadata(tagId, metadataKey, updatedMetadataValue);
            TagMetaData updatedMetadata = await tagMetadataApi.UpdateMetadataAsync(metadata, this.ApiCredential);
            return updatedMetadata;
        }

        public async Task ClearMetadataAsync(int tagId)
        {
            await tagMetadataApi.ClearMetadataAsync(tagId, this.ApiCredential);
        }

        private TagMetaData CreateTagMetadata(int tagId, string metadataKey, string metadataValue)
        {
            if (String.IsNullOrEmpty(metadataKey))
            {
                throw new ArgumentNullException("metadataKey");
            }
            TagMetaData metadata = new TagMetaData()
            {
                TagId = tagId,
                Key = metadataKey,
                Value = metadataValue
            };
            return metadata;
        }

        protected override CRUDApiAccessBase<Model.Catalog.Tag> ApiAccess
        {
            get { return new ApiAccess.Catalog.Tag(); }
        }
    }
}
