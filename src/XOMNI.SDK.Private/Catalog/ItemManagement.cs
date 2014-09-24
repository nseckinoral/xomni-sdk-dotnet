using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XOMNI.SDK.Model;
using XOMNI.SDK.Model.Asset;
using XOMNI.SDK.Model.Catalog;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Private.ApiAccess.Catalog;
using XOMNI.SDK.Private.ApiAccess.Catalog.ItemAsset;
using XOMNI.SDK.Private.ApiAccess.Catalog.ItemPrice;
using XOMNI.SDK.Private.ApiAccess.Catalog.ItemStoreMetadata;
using XOMNI.SDK.Private.ApiAccess.Catalog.ItemSearch;
using XOMNI.SDK.Model.Private.Catalog;

namespace XOMNI.SDK.Private.Catalog
{
    public class ItemManagement : BaseCRUDSkipTakeManagement<Model.Private.Catalog.Item>, IAssetRelation
    {
        private readonly ItemMetadata itemMetadataApi;
        private readonly RelatedItems relatedItemsApi;
        private readonly BatchPrice batchPriceApi;
        private readonly XOMNI.SDK.Private.ApiAccess.Catalog.Price priceApi;
        private readonly ItemGroup itemGroup;
        private readonly ItemUngroup itemUngroup;
        private readonly ItemMove itemMove;
        private readonly ItemStoreMetadata itemStoreMetadataApi;
        private readonly Search itemSearchApi;

        private XOMNI.SDK.Private.ApiAccess.Catalog.ItemDynamicAttribute.DynamicAttribute itemDynamicAttributeApi;

        public ItemManagement()
        {
            itemMetadataApi = new ItemMetadata();
            relatedItemsApi = new RelatedItems();
            batchPriceApi = new BatchPrice();
            itemDynamicAttributeApi = new ApiAccess.Catalog.ItemDynamicAttribute.DynamicAttribute();
            priceApi = new XOMNI.SDK.Private.ApiAccess.Catalog.Price();
            itemGroup = new ItemGroup();
            itemUngroup = new ItemUngroup();
            itemMove = new ItemMove();
            itemStoreMetadataApi = new ItemStoreMetadata();
            itemSearchApi = new Search();
        }

        public Task<ItemMetaData> AddMetadataAsync(int itemId, string metadataKey, string metadataValue)
        {
            var metadata = CreateItemMetadata(itemId, metadataKey, metadataValue);
            return itemMetadataApi.AddMetadataAsync(metadata, this.ApiCredential);
        }

        public Task DeleteMetadataAsync(int itemId, string metadataKey)
        {
            if (String.IsNullOrEmpty(metadataKey))
            {
                throw new ArgumentNullException("metadataKey");
            }
            return itemMetadataApi.DeleteMetadataAsync(itemId, metadataKey, this.ApiCredential);
        }

        public Task ClearMetadataAsync(int itemId)
        {
            return itemMetadataApi.ClearMetadataAsync(itemId, this.ApiCredential);
        }

        public Task<ItemMetaData> UpdateMetadataAsync(int itemId, string metadataKey, string updatedMetadataValue)
        {
            var metadata = CreateItemMetadata(itemId, metadataKey, updatedMetadataValue);
            return itemMetadataApi.UpdateMetadataAsync(metadata, this.ApiCredential);
        }

        public Task<List<Metadata>> GetAllMetadataAsync(int itemId)
        {
            return itemMetadataApi.GetAllMetadataAsync(itemId, this.ApiCredential);
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
            return GetAssetApi(AssetContentType.Image).PostRelationAsync(itemId, assetRelation, this.ApiCredential);
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

        public Task<AssetRelationMapping> UpdateImageRelationAsync(int itemId, int assetId, bool isDefault)
        {
            AssetRelationMapping mapping = new AssetRelationMapping()
            {
                AssetId = assetId,
                RelatedId = itemId,
                IsDefault = isDefault
            };

            return GetAssetApi(AssetContentType.Image).PutRelationAsync(mapping, this.ApiCredential);
        }

        public Task<AssetRelationMapping> UpdateVideoRelationAsync(int itemId, int assetId, bool isDefault)
        {
            AssetRelationMapping mapping = new AssetRelationMapping()
            {
                AssetId = assetId,
                RelatedId = itemId,
                IsDefault = isDefault
            };

            return GetAssetApi(AssetContentType.Video).PutRelationAsync(mapping, this.ApiCredential);
        }

        public Task<AssetRelationMapping> UpdateDocumentRelationAsync(int itemId, int assetId, bool isDefault)
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

        public async Task<XOMNI.SDK.Model.Private.Catalog.MultipleItemSearchResult> SearchAsync(XOMNI.SDK.Model.Private.Catalog.ItemSearchRequest itemSearchRequest, bool includeItemMetadata = false)
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

        public Task<List<Model.Private.Catalog.Price>> GetAllPricesAsync(int itemId)
        {
            return priceApi.GetByItemIdAsync(itemId, this.ApiCredential);
        }

        public Task<List<Model.Catalog.DynamicAttribute>> UpdateDynamicAttributesAsync(int itemId, List<Model.Catalog.DynamicAttribute> dynamicAttributeList)
        {
            return itemDynamicAttributeApi.UpdateItemDynamicAttributesAsync(itemId, dynamicAttributeList, this.ApiCredential);
        }

        /// <summary>
        /// Makes the variant items of the default item master (in other words, ugroups them).
        /// </summary>
        /// <param name="defaultItemId">The id of the default item which will be used to ungroup its variant items.</param>
        public Task UngroupItemsAsync(int defaultItemId)
        {
            return itemUngroup.UngroupItemsAsync(defaultItemId, base.ApiCredential);
        }

        /// <summary>
        /// Moves variant items under a sepecified default item.
        /// </summary>
        /// <param name="defaultItemId">The id of the default item to move the variants item under.</param>
        /// <param name="variantItemIds">The ids of the items to move.</param>
        public Task GroupItemsAsync(int defaultItemId, IEnumerable<int> variantItemIds)
        {
            return itemGroup.GroupItemsAsync(defaultItemId, variantItemIds, base.ApiCredential);
        }

        /// <summary>
        /// Moves variant items under a different default item.
        /// </summary>
        /// <param name="defaultItemId">The id of the default item to move the variant items under.</param>
        /// <param name="variantItemIds">The ids of the items to move.</param>
        public Task MoveItemsAsync(int defaultItemId, IEnumerable<int> variantItemIds)
        {
            return itemMove.MoveItemsAsync(defaultItemId, variantItemIds, base.ApiCredential);
        }


        public Task<Model.Private.Catalog.InStoreMetadata> AddInStoreMetadataAsync(int itemId, Model.Private.Catalog.InStoreMetadata inStoreMetadata)
        {
            return itemStoreMetadataApi.AddInStoreMetadataAsync(itemId, inStoreMetadata, this.ApiCredential);
        }

        public Task<Model.Private.Catalog.InStoreMetadata> UpdateInStoreMetadataAsync(int itemId, Model.Private.Catalog.InStoreMetadata inStoreMetadata)
        {
            return itemStoreMetadataApi.UpdateInStoreMetadataAsync(itemId, inStoreMetadata, this.ApiCredential);
        }

        public Task<List<Model.Private.Catalog.InStoreMetadata>> GetAllInStoreMetadataAsync(int itemId)
        {
            return itemStoreMetadataApi.GetAllInStoreMetadataAsync(itemId, this.ApiCredential);
        }

        public Task DeleteInStoreMetadataAsync(int itemId, int storeId, string metadataKey)
        {
            return itemStoreMetadataApi.DeleteInStoreMetadataAsync(itemId, storeId, metadataKey, this.ApiCredential);
        }
        public Task ClearInStoreMetadataAsync(int itemId, int storeId)
        {
            return itemStoreMetadataApi.ClearInStoreMetadataAsync(itemId, storeId, this.ApiCredential);
        }

        public Task ClearInStoreMetadataAsync(int itemId)
        {
            return itemStoreMetadataApi.ClearInStoreMetadataAsync(itemId, this.ApiCredential);
        }

        public Task<CountedCollectionContainer<PrivateItemSearchResponse>> SearchAsync(int skip, int take, int? categoryId = null, int? brandId = null, int? defaultItemId = null, string SKU = null, string UUID = null, List<int> itemIds = null, bool includeOnlyMasterItems = false)
        {
            return itemSearchApi.GetAsync(skip, take, categoryId, brandId, defaultItemId, SKU, UUID, itemIds, includeOnlyMasterItems, this.ApiCredential);
        }
    }
}
