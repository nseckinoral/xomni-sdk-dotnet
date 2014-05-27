using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model;
using XOMNI.SDK.Model.Asset;
using XOMNI.SDK.Core.ApiAccess;

namespace XOMNI.SDK.Private.ApiAccess.Catalog
{
    public interface IAssetMetadata
    {
        Task<AssetMetadata> AddMetadataAsync(AssetMetadata assetMetadata, ApiBasicCredential credential);
        Task DeleteMetadataAsync(int assetId, string metadataKey, ApiBasicCredential credential);
        Task ClearMetadataAsync(int assetId, ApiBasicCredential credential);
        Task<AssetMetadata> UpdateMetadataAsync(AssetMetadata assetMetadata, ApiBasicCredential credential);
        Task<List<Metadata>> GetAllMetadataAsync(int assetId, ApiBasicCredential credential);
    }
}
