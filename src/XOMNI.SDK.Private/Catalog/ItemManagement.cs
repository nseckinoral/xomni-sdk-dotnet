using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model;
using XOMNI.SDK.Model.Asset;
using XOMNI.SDK.Model.Catalog;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Private.ApiAccess.Catalog;
using XOMNI.SDK.Private.ApiAccess.Catalog.ItemAsset;
using XOMNI.SDK.Private.ApiAccess.Catalog.ItemPrice;

namespace XOMNI.SDK.Private.Catalog
{
    public class ItemManagement : BaseCRUDSkipTakeManagement<Model.Private.Catalog.Item>, IAssetRelation
    {
        private ItemMetadata itemMetadataApi;
        private RelatedItems relatedItemsApi;
        private BatchPrice batchPriceApi;
        private Price priceApi;

        private XOMNI.SDK.Private.ApiAccess.Catalog.ItemDynamicAttribute.DynamicAttribute itemDynamicAttributeApi;

        public ItemManagement()
        {
            itemMetadataApi = new ItemMetadata();
            relatedItemsApi = new RelatedItems();
            batchPriceApi = new BatchPrice();
            itemDynamicAttributeApi = new ApiAccess.Catalog.ItemDynamicAttribute.DynamicAttribute();
            priceApi = new Price();
        }

        public async Task<ItemMetaData> AddMetadataAsync(int itemId, string metadataKey, string metadataValue)
        {
            var metadata = CreateItemMetadata(itemId, metadataKey, metadataValue);
            ItemMetaData createdMetadata = await itemMetadataApi.AddMetadataAsync(metadata, this.ApiCredential);
            return createdMetadata;
        }

        public async Task DeleteMetadataAsync(int itemId, string metadataKey)
        {
            if (String.IsNullOrEmpty(metadataKey))
            {
                throw new ArgumentNullException("metadataKey");
            }
            await itemMetadataApi.DeleteMetadataAsync(itemId, metadataKey, this.ApiCredential);
        }

        public async Task ClearMetadataAsync(int itemId)
        {
            await itemMetadataApi.ClearMetadataAsync(itemId, this.ApiCredential);
        }

        public async Task<ItemMetaData> UpdateMetadataAsync(int itemId, string metadataKey, string updatedMetadataValue)
        {
            var metadata = CreateItemMetadata(itemId, metadataKey, updatedMetadataValue);
            ItemMetaData updatedMetadata = await itemMetadataApi.UpdateMetadataAsync(metadata, this.ApiCredential);
            return updatedMetadata;
        }

        public async Task<List<Metadata>> GetAllMetadataAsync(int itemId)
        {
            List<Metadata> itemMetadataList = await itemMetadataApi.GetAllMetadataAsync(itemId, this.ApiCredential);
            return itemMetadataList;
        }

        private ItemMetaData CreateItemMetadata(int itemId, string metadataKey, string metadataValue)
        {
            if (String.IsNullOrEmpty(metadataKey))
            {
                throw new ArgumentNullException("metadataKey");
            }
            ItemMetaData metadata = new ItemMetaData()
            {
                ItemId = itemId,
                Key = metadataKey,
                Value = metadataValue
            };
            return metadata;
        }

        public Task<List<int>> GetRelatedItemsAsync(int itemId)
        {
            return relatedItemsApi.GetByItemIdAsync(itemId, this.ApiCredential);
        }

        public Task DeleteItemRelationAsync(int itemId, int relatedItemId, ItemRelationDirection direction)
        {
            return relatedItemsApi.DeleteRelationAsync(itemId, relatedItemId, direction, this.ApiCredential);
        }

        public Task ClearRelatedItemsAsync(int itemId, ItemRelationDirection direction)
        {
            return relatedItemsApi.ClearRelatedItemsAsync(itemId, direction, this.ApiCredential);
        }

        public Task AddItemRelationAsync(int itemId, List<int> relatedItems, ItemRelationDirection direction)
        {
            return relatedItemsApi.AddRelationAsync(itemId, relatedItems, direction, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateImageAsync(int itemId, AssetRelation assetRelation)
        {
            return GetAssetApi(AssetContentType.Image).PostRelationAsync(brandId, assetRelation, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateVideoAsync(int itemId, AssetRelation assetRelation)
        {
            return GetAssetApi(AssetContentType.Video).PostRelationAsync(itemId, assetRelation, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateDocumentAsync(int itemId, AssetRelation assetRelation)
        {
            return GetAssetApi(AssetContentType.Document).PostRelationAsync(itemId, assetRelation, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateImageAsync(int itemId, int assetId, bool isDefault = false)
        {
            return GetAssetApi(AssetContentType.Image).PostRelationAsync(itemId, assetId, isDefault, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateVideoAsync(int itemId, int assetId, bool isDefault = false)
        {
            return GetAssetApi(AssetContentType.Video).PostRelationAsync(itemId, assetId, isDefault, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateDocumentAsync(int itemId, int assetId, bool isDefault = false)
        {
            return GetAssetApi(AssetContentType.Document).PostRelationAsync(itemId, assetId, isDefault, this.ApiCredential);
        }

        public Task UnrelateImageAsync(int itemId, int assetId)
        {
            return GetAssetApi(AssetContentType.Image).DeleteRelationAsync(itemId, assetId, this.ApiCredential);
        }

        public Task UnrelateVideoAsync(int itemId, int assetId)
        {
            return GetAssetApi(AssetContentType.Video).DeleteRelationAsync(itemId, assetId, this.ApiCredential);
        }

        public Task UnrelateDocumentAsync(int itemId, int assetId)
        {
            return GetAssetApi(AssetContentType.Document).DeleteRelationAsync(itemId, assetId, this.ApiCredential);
        }

        public Task<List<Model.Private.Asset.RelatedImageAsset>> GetImagesAsync(int itemId)
        {
            return GetAssetApi(AssetContentType.Image).GetRelationAsync<Model.Private.Asset.RelatedImageAsset>(itemId, this.ApiCredential);
        }

        public Task<List<Model.Private.Asset.RelatedAsset>> GetVideosAsync(int itemId)
        {
            return GetAssetApi(AssetContentType.Video).GetRelationAsync<Model.Private.Asset.RelatedAsset>(itemId, this.ApiCredential);
        }

        public Task<List<Model.Private.Asset.RelatedAsset>> GetDocumentsAsync(int itemId)
        {
            return GetAssetApi(AssetContentType.Document).GetRelationAsync<Model.Private.Asset.RelatedAsset>(itemId, this.ApiCredential);
        }

        public Task<AssetRelationMapping> UpdateImageRelation(int itemId, int assetId, bool isDefault)
        {
            AssetRelationMapping mapping = new AssetRelationMapping()
            {
                AssetId = assetId,
                RelatedId = itemId,
                IsDefault = isDefault
            };

            return GetAssetApi(AssetContentType.Image).PutRelationAsync(mapping, this.ApiCredential);
        }

        public Task<AssetRelationMapping> UpdateVideoRelation(int itemId, int assetId, bool isDefault)
        {
            AssetRelationMapping mapping = new AssetRelationMapping()
            {
                AssetId = assetId,
                RelatedId = itemId,
                IsDefault = isDefault
            };

            return GetAssetApi(AssetContentType.Video).PutRelationAsync(mapping, this.ApiCredential);
        }

        public Task<AssetRelationMapping> UpdateDocumentRelation(int itemId, int assetId, bool isDefault)
        {
            AssetRelationMapping mapping = new AssetRelationMapping()
            {
                AssetId = assetId,
                RelatedId = itemId,
                IsDefault = isDefault
            };

            return GetAssetApi(AssetContentType.Document).PutRelationAsync(mapping, this.ApiCredential);
        }

        private CatalogAssetBase GetAssetApi(AssetContentType assetType)
        {
            switch (assetType)
            {
                case AssetContentType.Image:
                    return new Image();
                case AssetContentType.Video:
                    return new Video();
                case AssetContentType.Document:
                    return new Document();
                default: return null;
            }
        }

        protected override XOMNI.SDK.Core.ApiAccess.CRUDApiAccessBase<Model.Private.Catalog.Item> ApiAccess
        {
            get { return new ApiAccess.Catalog.Item(); }
        }

        public async Task<XOMNI.SDK.Model.Private.Catalog.MultipleItemSearchResult> Search(XOMNI.SDK.Model.Private.Catalog.ItemSearchRequest itemSearchRequest, bool includeItemMetadata = false)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("includeItemMetadata", includeItemMetadata.ToString());
            var itemSearchResponse = await ApiAccess.PostByCustomListOperationUrlAsync<XOMNI.SDK.Model.Private.Catalog.ItemSearchPrivateSDK>(additionalParameters, itemSearchRequest, this.ApiCredential);
            var itemSearchResult = itemSearchResponse.SearchResult;

            return itemSearchResult;
        }

        public Task<List<Model.Private.Catalog.Price>> UpdatePricesAsync(int itemId, List<Model.Private.Catalog.Price> priceList)
        {
            return batchPriceApi.UpdateItemPricesAsync(itemId, priceList, this.ApiCredential);
        }

        public Task<List<Model.Private.Catalog.Price>> GetAllPrices(int itemId)
        {
            return priceApi.GetByItemIdAsync(itemId, this.ApiCredential);
        }

        public Task<List<Model.Catalog.DynamicAttribute>> UpdateDynamicAttributesAsync(int itemId, List<Model.Catalog.DynamicAttribute> dynamicAttributeList)
        {
            return itemDynamicAttributeApi.UpdateItemDynamicAttributesAsync(itemId, dynamicAttributeList, this.ApiCredential);
        }
    }
}
