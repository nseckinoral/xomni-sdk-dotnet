using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model;
using XOMNI.SDK.Model.Asset;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Private.ApiAccess;
using XOMNI.SDK.Private.ApiAccess.Asset;
using XOMNI.SDK.Model.Private.Asset;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.Asset
{
    public abstract class AssetManagement : ManagementBase
    {
        private Assets AssetsApi;
        public AssetManagement()
        {
            AssetsApi = new Assets();
        }
        internal abstract AssetBase AssetApi { get; }

        public virtual Task<CountedCollectionContainer<Model.Private.Asset.Asset>> GetAssets(int skip, int take, string fileName = null)
        {
            return GetAssetsInternal<Model.Private.Asset.Asset>(skip, take, fileName);
        }

        protected virtual Task<CountedCollectionContainer<T>> GetAssetsInternal<T>(int skip, int take, string fileName = null)
        {
            return AssetApi.GetAsync<T>(skip, take, this.ApiCredential, fileName);
        }

        public virtual Task<AssetRelations> GetAssetRelationsAsync(int assetId)
        {
            return AssetsApi.GetAssetRelationsAsync(assetId, this.ApiCredential);
        }

        public virtual Task DeleteAssetAsync(int assetId, bool force)
        {
            return AssetsApi.DeleteAssetAsync(assetId, force, this.ApiCredential);
        }

        #region low level methods

        public virtual XOMNIRequestMessage<CountedCollectionContainer<Model.Private.Asset.Asset>> CreateGetAssetsRequest(int skip, int take, string fileName = null)
        {
            return AssetApi.CreateGetRequest<Model.Private.Asset.Asset>(skip, take, this.ApiCredential, fileName);
        }

        protected virtual XOMNIRequestMessage<CountedCollectionContainer<T>> CreateGetAssetsRequestInternal<T>(int skip, int take, string fileName = null)
        {
            return AssetApi.CreateGetRequest<T>(skip, take, this.ApiCredential, fileName);
        }

        public virtual XOMNIRequestMessage<AssetRelations> CreateGetAssetRelationsRequest(int assetId)
        {
            return AssetsApi.CreateGetAssetRelationsRequest(assetId, this.ApiCredential);
        }

        public virtual XOMNIRequestMessage CreateDeleteAssetRequest(int assetId, bool force)
        {
            return AssetsApi.CreateDeleteAssetRequest(assetId, force, this.ApiCredential);
        }

        #endregion
    }
}
