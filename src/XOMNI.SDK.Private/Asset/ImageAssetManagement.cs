using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Private.ApiAccess.Asset;

namespace XOMNI.SDK.Private.Asset
{
    public class ImageAssetManagement : AssetManagement
    {
        internal override ApiAccess.AssetBase AssetApi
        {
            get { return new Images(); }
        }

        public virtual async Task SetResizableFlag(int assetId)
        {
            await ((Images)AssetApi).PostResizableFlagAsync(assetId, base.ApiCredential);
        }

        public virtual async Task RemoveResizableFlag(int assetId)
        {
            await ((Images)AssetApi).DeleteResizableFlagAsync(assetId, base.ApiCredential);
        }

        public Task<Model.CountedCollectionContainer<Model.Private.Asset.ImageAsset>> GetAssets(int skip, int take, string fileName = null)
        {
            return base.GetAssetsInternal<Model.Private.Asset.ImageAsset>(skip, take, fileName);
        }
    }
}
