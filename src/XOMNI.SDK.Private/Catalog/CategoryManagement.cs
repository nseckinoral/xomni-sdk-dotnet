﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model;
using XOMNI.SDK.Model.Asset;
using XOMNI.SDK.Model.Catalog;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Private.ApiAccess.Catalog;
using XOMNI.SDK.Private.ApiAccess.Catalog.CategoryAsset;
using System.Linq.Expressions;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.Catalog
{
    public class CategoryManagement : ManagementBase, IAssetRelation
    {
        private CategoryMetadata categoryMetadataApi;
        private XOMNI.SDK.Private.ApiAccess.Catalog.Category categoryApi;

        public CategoryManagement()
        {
            categoryMetadataApi = new CategoryMetadata();
            categoryApi = new ApiAccess.Catalog.Category();
        }

        /// <summary>
        /// Adds a new metadata to given category.
        /// </summary>
        /// <param name="categoryId">The unique id of the category.</param>
        /// <param name="metadataKey">Key for the metadata.</param>
        /// <param name="metadataValue">Value for the metadata.</param>
        /// <returns>Created metadata instance.</returns>
        /// <exception cref="XOMNI.SDK.Core.Exception.NotFoundException">Given category not found in backend.</exception>
        /// <exception cref="XOMNI.SDK.Core.Exception.ConflictException">Given metadata key already exists in category metadata collection.</exception>
        public Task<CategoryMetaData> AddMetadataAsync(int categoryId, string metadataKey, string metadataValue)
        {
            var metadata = CreateCategoryMetadata(categoryId, metadataKey, metadataValue);
            return categoryMetadataApi.AddMetadataAsync(metadata, this.ApiCredential);
        }

        public Task DeleteMetadataAsync(int categoryId, string metadataKey)
        {
            if (String.IsNullOrEmpty(metadataKey))
            {
                throw new ArgumentNullException("metadataKey");
            }
            return categoryMetadataApi.DeleteMetadataAsync(categoryId, metadataKey, this.ApiCredential);
        }

        public Task ClearMetadataAsync(int categoryId)
        {
            return categoryMetadataApi.ClearMetadataAsync(categoryId, this.ApiCredential);
        }

        public Task<List<Metadata>> GetAllMetadataAsync(int categoryId)
        {
            return categoryMetadataApi.GetAllMetadataAsync(categoryId, this.ApiCredential);
        }

        public Task<CategoryMetaData> UpdateMetadataAsync(int categoryId, string metadataKey, string updatedMetadataValue)
        {
            var metadata = CreateCategoryMetadata(categoryId, metadataKey, updatedMetadataValue);
            return categoryMetadataApi.UpdateMetadataAsync(metadata, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateImageAsync(int categoryId, AssetRelation assetRelation)
        {
            return GetAssetApi(AssetContentType.Image).PostRelationAsync(categoryId, assetRelation, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateVideoAsync(int categoryId, AssetRelation assetRelation)
        {
            return GetAssetApi(AssetContentType.Video).PostRelationAsync(categoryId, assetRelation, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateDocumentAsync(int categoryId, AssetRelation assetRelation)
        {
            return GetAssetApi(AssetContentType.Document).PostRelationAsync(categoryId, assetRelation, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateImageAsync(int categoryId, int assetId, bool isDefault = false)
        {
            return GetAssetApi(AssetContentType.Image).PostRelationAsync(categoryId, assetId, isDefault, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateVideoAsync(int categoryId, int assetId, bool isDefault = false)
        {
            return GetAssetApi(AssetContentType.Video).PostRelationAsync(categoryId, assetId, isDefault, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateDocumentAsync(int categoryId, int assetId, bool isDefault = false)
        {
            return GetAssetApi(AssetContentType.Document).PostRelationAsync(categoryId, assetId, isDefault, this.ApiCredential);
        }

        public Task UnrelateImageAsync(int categoryId, int assetId)
        {
            return GetAssetApi(AssetContentType.Image).DeleteRelationAsync(categoryId, assetId, this.ApiCredential);
        }

        public Task UnrelateVideoAsync(int categoryId, int assetId)
        {
            return GetAssetApi(AssetContentType.Video).DeleteRelationAsync(categoryId, assetId, this.ApiCredential);
        }

        public Task UnrelateDocumentAsync(int categoryId, int assetId)
        {
            return GetAssetApi(AssetContentType.Document).DeleteRelationAsync(categoryId, assetId, this.ApiCredential);
        }

        public Task<List<Model.Private.Asset.RelatedImageAsset>> GetImagesAsync(int categoryId)
        {
            return GetAssetApi(AssetContentType.Image).GetRelationAsync<Model.Private.Asset.RelatedImageAsset>(categoryId, this.ApiCredential);
        }

        public Task<List<Model.Private.Asset.RelatedAsset>> GetVideosAsync(int categoryId)
        {
            return GetAssetApi(AssetContentType.Video).GetRelationAsync<Model.Private.Asset.RelatedAsset>(categoryId, this.ApiCredential);
        }

        public Task<List<Model.Private.Asset.RelatedAsset>> GetDocumentsAsync(int categoryId)
        {
            return GetAssetApi(AssetContentType.Document).GetRelationAsync<Model.Private.Asset.RelatedAsset>(categoryId, this.ApiCredential);
        }

        public Task<AssetRelationMapping> UpdateImageRelationAsync(int categoryId, int assetId, bool isDefault)
        {
            AssetRelationMapping mapping = new AssetRelationMapping()
            {
                AssetId = assetId,
                RelatedId = categoryId,
                IsDefault = isDefault
            };

            return GetAssetApi(AssetContentType.Image).PutRelationAsync(mapping, this.ApiCredential);
        }

        public Task<AssetRelationMapping> UpdateVideoRelationAsync(int categoryId, int assetId, bool isDefault)
        {
            AssetRelationMapping mapping = new AssetRelationMapping()
            {
                AssetId = assetId,
                RelatedId = categoryId,
                IsDefault = isDefault
            };

            return GetAssetApi(AssetContentType.Video).PutRelationAsync(mapping, this.ApiCredential);
        }

        public Task<AssetRelationMapping> UpdateDocumentRelationAsync(int categoryId, int assetId, bool isDefault)
        {
            AssetRelationMapping mapping = new AssetRelationMapping()
            {
                AssetId = assetId,
                RelatedId = categoryId,
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

        public Task<XOMNI.SDK.Model.Private.Catalog.Category> AddCategoryAsync(XOMNI.SDK.Model.Private.Catalog.Category category)
        {
            return categoryApi.AddAsync(category, this.ApiCredential);
        }

        public Task<XOMNI.SDK.Model.Private.Catalog.Category> UpdateCategoryAsync(XOMNI.SDK.Model.Private.Catalog.Category category)
        {
            return categoryApi.UpdateAsync(category, this.ApiCredential);
        }

        public Task<XOMNI.SDK.Model.Private.Catalog.Category> PatchCategoryAsync(dynamic category)
        {
            return categoryApi.PatchAsync(category, this.ApiCredential);
        }

        public Task DeleteCategoryAsync(int categoryId)
        {
            return categoryApi.DeleteAsync(categoryId, this.ApiCredential);
        }

        public Task<Model.Private.Catalog.CategoryTree> GetCategoryTreeAsync()
        {
            return categoryApi.GetCategoryTreeAsync(this.ApiCredential);
        }

        public Task<XOMNI.SDK.Model.Private.Catalog.Category> GetCategoryAsync(int categoryId)
        {
            return categoryApi.GetByIdAsync(categoryId, this.ApiCredential);
        }

        #region low level methods

        /// <summary>
        /// Adds a new metadata to given category.
        /// </summary>
        /// <param name="categoryId">The unique id of the category.</param>
        /// <param name="metadataKey">Key for the metadata.</param>
        /// <param name="metadataValue">Value for the metadata.</param>
        /// <returns>Created metadata instance.</returns>
        /// <exception cref="XOMNI.SDK.Core.Exception.NotFoundException">Given category not found in backend.</exception>
        /// <exception cref="XOMNI.SDK.Core.Exception.ConflictException">Given metadata key already exists in category metadata collection.</exception>
        public XOMNIRequestMessage<CategoryMetaData> CreateAddMetadataRequest(int categoryId, string metadataKey, string metadataValue)
        {
            var metadata = CreateCategoryMetadata(categoryId, metadataKey, metadataValue);
            return categoryMetadataApi.CreateAddMetadataRequest(metadata, this.ApiCredential);
        }

        public XOMNIRequestMessage CreateDeleteMetadataRequest(int categoryId, string metadataKey)
        {
            if (String.IsNullOrEmpty(metadataKey))
            {
                throw new ArgumentNullException("metadataKey");
            }
            return categoryMetadataApi.CreateDeleteMetadataRequest(categoryId, metadataKey, this.ApiCredential);
        }

        public XOMNIRequestMessage CreateClearMetadataRequest(int categoryId)
        {
            return categoryMetadataApi.CreateClearMetadataRequest(categoryId, this.ApiCredential);
        }

        public XOMNIRequestMessage<List<Metadata>> CreateGetAllMetadataRequest(int categoryId)
        {
            return categoryMetadataApi.CreateGetAllMetadataRequest(categoryId, this.ApiCredential);
        }

        public XOMNIRequestMessage<CategoryMetaData> CreateUpdateMetadataRequest(int categoryId, string metadataKey, string updatedMetadataValue)
        {
            var metadata = CreateCategoryMetadata(categoryId, metadataKey, updatedMetadataValue);
            return categoryMetadataApi.CreateUpdateMetadataRequest(metadata, this.ApiCredential);
        }

        private CategoryMetaData CreateCategoryMetadata(int categoryId, string metadataKey, string metadataValue)
        {
            if (String.IsNullOrEmpty(metadataKey))
            {
                throw new ArgumentNullException("metadataKey");
            }
            CategoryMetaData metadata = new CategoryMetaData()
            {
                CategoryId = categoryId,
                Key = metadataKey,
                Value = metadataValue
            };
            return metadata;
        }

        public XOMNIRequestMessage<AssetRelationMapping> CreateRelateImageRequest(int categoryId, AssetRelation assetRelation)
        {
            return GetAssetApi(AssetContentType.Image).CreatePostRelationRequest(categoryId, assetRelation, this.ApiCredential);
        }

        public XOMNIRequestMessage<AssetRelationMapping> CreateRelateVideoRequest(int categoryId, AssetRelation assetRelation)
        {
            return GetAssetApi(AssetContentType.Video).CreatePostRelationRequest(categoryId, assetRelation, this.ApiCredential);
        }

        public XOMNIRequestMessage<AssetRelationMapping> CreateRelateDocumentRequest(int categoryId, AssetRelation assetRelation)
        {
            return GetAssetApi(AssetContentType.Document).CreatePostRelationRequest(categoryId, assetRelation, this.ApiCredential);
        }

        public XOMNIRequestMessage<AssetRelationMapping> CreateRelateImageRequest(int categoryId, int assetId, bool isDefault = false)
        {
            return GetAssetApi(AssetContentType.Image).CreatePostRelationRequest(categoryId, assetId, isDefault, this.ApiCredential);
        }

        public XOMNIRequestMessage<AssetRelationMapping> CreateRelateVideoRequest(int categoryId, int assetId, bool isDefault = false)
        {
            return GetAssetApi(AssetContentType.Video).CreatePostRelationRequest(categoryId, assetId, isDefault, this.ApiCredential);
        }

        public XOMNIRequestMessage<AssetRelationMapping> CreateRelateDocumentRequest(int categoryId, int assetId, bool isDefault = false)
        {
            return GetAssetApi(AssetContentType.Document).CreatePostRelationRequest(categoryId, assetId, isDefault, this.ApiCredential);
        }

        public XOMNIRequestMessage CreateUnrelateImageRequest(int categoryId, int assetId)
        {
            return GetAssetApi(AssetContentType.Image).CreateDeleteRelationRequest(categoryId, assetId, this.ApiCredential);
        }

        public XOMNIRequestMessage CreateUnrelateVideoRequest(int categoryId, int assetId)
        {
            return GetAssetApi(AssetContentType.Video).CreateDeleteRelationRequest(categoryId, assetId, this.ApiCredential);
        }

        public XOMNIRequestMessage CreateUnrelateDocumentRequest(int categoryId, int assetId)
        {
            return GetAssetApi(AssetContentType.Document).CreateDeleteRelationRequest(categoryId, assetId, this.ApiCredential);
        }

        public XOMNIRequestMessage<List<Model.Private.Asset.RelatedImageAsset>> CreateGetImagesRequest(int categoryId)
        {
            return GetAssetApi(AssetContentType.Image).CreateGetRelationRequest<Model.Private.Asset.RelatedImageAsset>(categoryId, this.ApiCredential);
        }

        public XOMNIRequestMessage<List<Model.Private.Asset.RelatedAsset>> CreateGetVideosRequest(int categoryId)
        {
            return GetAssetApi(AssetContentType.Video).CreateGetRelationRequest<Model.Private.Asset.RelatedAsset>(categoryId, this.ApiCredential);
        }

        public XOMNIRequestMessage<List<Model.Private.Asset.RelatedAsset>> CreateGetDocumentsRequest(int categoryId)
        {
            return GetAssetApi(AssetContentType.Document).CreateGetRelationRequest<Model.Private.Asset.RelatedAsset>(categoryId, this.ApiCredential);
        }

        public XOMNIRequestMessage<AssetRelationMapping> CreateUpdateImageRelationRequest(int categoryId, int assetId, bool isDefault)
        {
            AssetRelationMapping mapping = new AssetRelationMapping()
            {
                AssetId = assetId,
                RelatedId = categoryId,
                IsDefault = isDefault
            };

            return GetAssetApi(AssetContentType.Image).CreatePutRelationRequest(mapping, this.ApiCredential);
        }

        public XOMNIRequestMessage<AssetRelationMapping> CreateUpdateVideoRelationRequest(int categoryId, int assetId, bool isDefault)
        {
            AssetRelationMapping mapping = new AssetRelationMapping()
            {
                AssetId = assetId,
                RelatedId = categoryId,
                IsDefault = isDefault
            };

            return GetAssetApi(AssetContentType.Video).CreatePutRelationRequest(mapping, this.ApiCredential);
        }

        public XOMNIRequestMessage<AssetRelationMapping> CreateUpdateDocumentRelationRequest(int categoryId, int assetId, bool isDefault)
        {
            AssetRelationMapping mapping = new AssetRelationMapping()
            {
                AssetId = assetId,
                RelatedId = categoryId,
                IsDefault = isDefault
            };

            return GetAssetApi(AssetContentType.Document).CreatePutRelationRequest(mapping, this.ApiCredential);
        }

        public XOMNIRequestMessage<XOMNI.SDK.Model.Private.Catalog.Category> CreateAddCategoryRequest(XOMNI.SDK.Model.Private.Catalog.Category category)
        {
            return categoryApi.CreateAddRequest(category, this.ApiCredential);
        }

        public XOMNIRequestMessage<XOMNI.SDK.Model.Private.Catalog.Category> CreateUpdateCategoryRequest(XOMNI.SDK.Model.Private.Catalog.Category category)
        {
            return categoryApi.CreateUpdateRequest(category, this.ApiCredential);
        }

        public XOMNIRequestMessage<XOMNI.SDK.Model.Private.Catalog.Category> CreateUpdateCategoryRequest(dynamic category)
        {
            return categoryApi.CreatePatchRequest(category, this.ApiCredential);
        }

        public XOMNIRequestMessage CreateDeleteCategoryRequest(int categoryId)
        {
            return categoryApi.CreateDeleteRequest(categoryId, this.ApiCredential);
        }

        public XOMNIRequestMessage<Model.Private.Catalog.CategoryTree> CreateGetCategoryTreeRequest()
        {
            return categoryApi.CreateGetCategoryTreeRequest(this.ApiCredential);
        }

        public XOMNIRequestMessage<XOMNI.SDK.Model.Private.Catalog.Category> CreateGetCategoryRequest(int categoryId)
        {
            return categoryApi.CreateGetByIdRequest(categoryId, this.ApiCredential);
        }
        #endregion
    }
}
