using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model;
using XOMNI.SDK.Model.Asset;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Private.ApiAccess.Catalog;

namespace XOMNI.SDK.Private.Catalog
{
    public class BaseAssetManagement:ManagementBase
    {
        IAssetMetadata assetMetadataApi;

        public BaseAssetManagement(IAssetMetadata metadataApi)
        {
            assetMetadataApi = metadataApi;
        }

        public async Task<AssetMetadata> AddMetadataAsync(int assetId, string metadataKey, string metadataValue)
        {
            var metadata = CreateAssetMetadata(assetId, metadataKey, metadataValue);
            AssetMetadata createdMetadata = await assetMetadataApi.AddMetadataAsync(metadata,this.ApiCredential);
            return createdMetadata;
        }

        public async Task DeleteMetadataAsync(int assetId, string metadataKey)
        {
            if (String.IsNullOrEmpty(metadataKey))
            {
                throw new ArgumentNullException("metadataKey");
            }
            await assetMetadataApi.DeleteMetadataAsync(assetId, metadataKey, this.ApiCredential);
        }

        public async Task ClearMetadataAsync(int assetId)
        {
            await assetMetadataApi.ClearMetadataAsync(assetId, this.ApiCredential);
        }

        public async Task<AssetMetadata> UpdateMetadataAsync(int assetId, string metadataKey, string updatedMetadataValue)
        {
            var metadata = CreateAssetMetadata(assetId, metadataKey, updatedMetadataValue);
            AssetMetadata updatedMetadata = await assetMetadataApi.UpdateMetadataAsync(metadata, this.ApiCredential);
            return updatedMetadata;
        }

        public async Task<List<Metadata>> GetAllMetadataAsync(int assetId)
        {
            List<Metadata> assetMetadataList = await assetMetadataApi.GetAllMetadataAsync(assetId, this.ApiCredential);
            return assetMetadataList;
        }

        private AssetMetadata CreateAssetMetadata(int assetId, string metadataKey, string metadataValue)
        {
            if (String.IsNullOrEmpty(metadataKey))
            {
                throw new ArgumentNullException("metadataKey");
            }
            AssetMetadata metadata = new AssetMetadata()
            {
                AssetId = assetId,
                Key = metadataKey,
                Value = metadataValue
            };
            return metadata;
        }
    }
}
