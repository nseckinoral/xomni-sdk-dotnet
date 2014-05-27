﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model;
using XOMNI.SDK.Model.Asset;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Private.ApiAccess;
using XOMNI.SDK.Private.ApiAccess.Asset;

namespace XOMNI.SDK.Private.Asset
{
    public abstract class AssetManagement : ManagementBase
    {
        internal abstract AssetBase AssetApi { get; }

        public virtual Task<CountedCollectionContainer<Model.Private.Asset.Asset>> GetAssets(int skip, int take, string fileName = null)
        {
            return GetAssetsInternal<Model.Private.Asset.Asset>(skip, take, fileName);
        }

        protected virtual Task<CountedCollectionContainer<T>> GetAssetsInternal<T>(int skip, int take, string fileName = null)
        {
            return AssetApi.Get<T>(skip, take, this.ApiCredential, fileName);
        }
    }
}
