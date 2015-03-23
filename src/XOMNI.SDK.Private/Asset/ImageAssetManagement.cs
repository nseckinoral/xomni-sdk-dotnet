﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Private.ApiAccess.Asset;

namespace XOMNI.SDK.Private.Asset
{
    public class ImageAssetManagement : AssetManagement
    {
        internal override ApiAccess.AssetBase AssetApi
        {
            get { return new Images(); }
        }

        public virtual Task SetResizableFlagAsync(int assetId)
        {
            return ((Images)AssetApi).PostResizableFlagAsync(assetId, base.ApiCredential);
        }

        public virtual Task RemoveResizableFlagAsync(int assetId)
        {
            return ((Images)AssetApi).DeleteResizableFlagAsync(assetId, base.ApiCredential);
        }

        public Task<Model.CountedCollectionContainer<Model.Private.Asset.ImageAsset>> GetAssetsAsync(int skip, int take, string fileName = null)
        {
            return base.GetAssetsInternalAsync<Model.Private.Asset.ImageAsset>(skip, take, fileName);
        }

        #region low level methods
        public virtual XOMNIRequestMessage CreateSetResizableFlagRequest(int assetId)
        {
            return ((Images)AssetApi).CreatePostResizableFlagRequest(assetId, base.ApiCredential);
        }

        public virtual XOMNIRequestMessage CreateRemoveResizableFlagRequest(int assetId)
        {
            return ((Images)AssetApi).CreateDeleteResizableFlagRequest(assetId, base.ApiCredential);
        }

        public XOMNIRequestMessage<Model.CountedCollectionContainer<Model.Private.Asset.ImageAsset>> CreateGetAssetsRequest(int skip, int take, string fileName = null)
        {
            return base.CreateGetAssetsRequestInternal<Model.Private.Asset.ImageAsset>(skip, take, fileName);
        }

        #endregion
    }
}
