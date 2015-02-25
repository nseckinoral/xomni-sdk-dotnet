using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model.Asset;

namespace XOMNI.SDK.Private.Catalog
{
    public interface IAssetRelation
    {
        Task<AssetRelationMapping> RelateImageAsync(int relatedId, AssetRelation assetRelation);
        Task<AssetRelationMapping> RelateVideoAsync(int relatedId, AssetRelation assetRelation);
        Task<AssetRelationMapping> RelateDocumentAsync(int relatedId, AssetRelation assetRelation);
        Task<AssetRelationMapping> RelateImageAsync(int relatedId, int assetId, bool isDefault = false);
        Task<AssetRelationMapping> RelateVideoAsync(int relatedId, int assetId, bool isDefault = false);
        Task<AssetRelationMapping> RelateDocumentAsync(int relatedId, int assetId, bool isDefault = false);
        Task UnrelateImageAsync(int relatedId, int assetId);
        Task UnrelateVideoAsync(int relatedId, int assetId);
        Task UnrelateDocumentAsync(int relatedId, int assetId);
        Task<List<Model.Private.Asset.RelatedImageAsset>> GetImagesAsync(int relatedId);
        Task<List<Model.Private.Asset.RelatedAsset>> GetVideosAsync(int relatedId);
        Task<List<Model.Private.Asset.RelatedAsset>> GetDocumentsAsync(int relatedId);
        Task<AssetRelationMapping> UpdateImageRelationAsync(int relatedId, int assetId, bool isDefault);
        Task<AssetRelationMapping> UpdateVideoRelationAsync(int relatedId, int assetId, bool isDefault);
        Task<AssetRelationMapping> UpdateDocumentRelationAsync(int relatedId, int assetId, bool isDefault);
    }
}
