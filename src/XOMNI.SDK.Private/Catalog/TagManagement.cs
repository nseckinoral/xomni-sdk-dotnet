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
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.Catalog
{
    public class TagManagement : BaseCRUDPSkipTakeManagement<Model.Catalog.Tag>
    {
        private TagMetadata tagMetadataApi;

        public TagManagement()
        {
            tagMetadataApi = new TagMetadata();
        }

        public Task<TagMetaData> AddMetadataAsync(int tagId, string metadataKey, string metadataValue)
        {
            var metadata = CreateTagMetadata(tagId, metadataKey, metadataValue);
            return tagMetadataApi.AddMetadataAsync(metadata, this.ApiCredential);
        }

        public Task<List<Metadata>> GetAllMetadataAsync(int tagId)
        {
            return tagMetadataApi.GetAllMetadataAsync(tagId, this.ApiCredential);
        }

        public Task DeleteMetadataAsync(int tagId, string metadataKey)
        {
            if (String.IsNullOrEmpty(metadataKey))
            {
                throw new ArgumentNullException("metadataKey");
            }
            return tagMetadataApi.DeleteMetadataAsync(tagId, metadataKey, this.ApiCredential);
        }

        public Task<TagMetaData> UpdateMetadataAsync(int tagId, string metadataKey, string updatedMetadataValue)
        {
            var metadata = CreateTagMetadata(tagId, metadataKey, updatedMetadataValue);
            return tagMetadataApi.UpdateMetadataAsync(metadata, this.ApiCredential);
        }

        public Task ClearMetadataAsync(int tagId)
        {
            return tagMetadataApi.ClearMetadataAsync(tagId, this.ApiCredential);
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

        protected override CRUDPApiAccessBase<Model.Catalog.Tag> CRUDPApiAccess
        {
            get { return new ApiAccess.Catalog.Tag(); }
        }

        #region low level methods
        public XOMNIRequestMessage<TagMetaData> CreateAddMetadataRequest(TagMetaData tagMetadata)
        {
            return tagMetadataApi.CreateAddMetadataRequest(tagMetadata, ApiCredential);
        }

        public XOMNIRequestMessage<List<Metadata>> CreateGetAllMetadataRequest(int tagId)
        {
            return tagMetadataApi.CreateGetAllMetadataRequest(tagId, ApiCredential);
        }

        public XOMNIRequestMessage CreateDeleteMetadataRequest(int tagId, string metadataKey)
        {
            return tagMetadataApi.CreateDeleteMetadataRequest(tagId, metadataKey, ApiCredential);
        }

        public XOMNIRequestMessage<TagMetaData> CreateUpdateMetadataRequest(TagMetaData tagMetadata)
        {
            return tagMetadataApi.CreateUpdateMetadataRequest(tagMetadata, ApiCredential);
        }

        public XOMNIRequestMessage CreateClearMetadataRequest(int tagId)
        {
            return tagMetadataApi.CreateClearMetadataRequest(tagId, ApiCredential);
        }
        #endregion
    }
}
