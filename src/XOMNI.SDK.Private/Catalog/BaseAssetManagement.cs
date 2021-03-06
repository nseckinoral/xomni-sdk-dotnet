﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model;
using XOMNI.SDK.Model.Asset;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Private.ApiAccess.Catalog;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.Catalog
{
    public class BaseAssetManagement : ManagementBase
    {
        IAssetMetadata assetMetadataApi;

        public BaseAssetManagement(IAssetMetadata metadataApi)
        {
            assetMetadataApi = metadataApi;
        }

        public Task<AssetMetadata> AddMetadataAsync(int assetId, string metadataKey, string metadataValue)
        {
            var metadata = CreateAssetMetadata(assetId, metadataKey, metadataValue);
            return assetMetadataApi.AddMetadataAsync(metadata, this.ApiCredential);
        }

        public Task DeleteMetadataAsync(int assetId, string metadataKey)
        {
            if (String.IsNullOrEmpty(metadataKey))
            {
                throw new ArgumentNullException("metadataKey");
            }
            return assetMetadataApi.DeleteMetadataAsync(assetId, metadataKey, this.ApiCredential);
        }

        public Task ClearMetadataAsync(int assetId)
        {
            return assetMetadataApi.ClearMetadataAsync(assetId, this.ApiCredential);
        }

        public Task<AssetMetadata> UpdateMetadataAsync(int assetId, string metadataKey, string updatedMetadataValue)
        {
            var metadata = CreateAssetMetadata(assetId, metadataKey, updatedMetadataValue);
            return assetMetadataApi.UpdateMetadataAsync(metadata, this.ApiCredential);
        }

        public Task<List<Metadata>> GetAllMetadataAsync(int assetId)
        {
            return assetMetadataApi.GetAllMetadataAsync(assetId, this.ApiCredential);
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

        #region low level methods
        public XOMNIRequestMessage<AssetMetadata> CreateAddMetadataRequest(int assetId, string metadataKey, string metadataValue)
        {
            var metadata = CreateAssetMetadata(assetId, metadataKey, metadataValue);
            return assetMetadataApi.CreateAddMetadataRequest(metadata, this.ApiCredential);
        }

        public XOMNIRequestMessage CreateDeleteMetadataRequest(int assetId, string metadataKey)
        {
            if (String.IsNullOrEmpty(metadataKey))
            {
                throw new ArgumentNullException("metadataKey");
            }
            return assetMetadataApi.CreateDeleteMetadataRequest(assetId, metadataKey, this.ApiCredential);
        }

        public XOMNIRequestMessage CreateClearMetadataRequest(int assetId)
        {
            return assetMetadataApi.CreateClearMetadataRequest(assetId, this.ApiCredential);
        }

        public XOMNIRequestMessage<AssetMetadata> CreateUpdateMetadataRequest(int assetId, string metadataKey, string updatedMetadataValue)
        {
            var metadata = CreateAssetMetadata(assetId, metadataKey, updatedMetadataValue);
            return assetMetadataApi.CreateUpdateMetadataRequest(metadata, this.ApiCredential);
        }

        public XOMNIRequestMessage<List<Metadata>> CreateGetAllMetadataRequest(int assetId)
        {
            return assetMetadataApi.CreateGetAllMetadataRequest(assetId, this.ApiCredential);
        }
        #endregion
    }
}
