using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.ApiAccess.Asset
{
    internal class Images : AssetBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/asset/image"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/asset/images"; }
        }

        public virtual Task PostResizableFlagAsync(int assetId, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync(GenerateUrl(SingleOperationBaseUrl) + "/" + assetId + "/resize", null, credential);
        }

        public virtual Task DeleteResizableFlagAsync(int assetId, ApiBasicCredential credential)
        {
            return HttpProvider.DeleteAsync(GenerateUrl(SingleOperationBaseUrl) + "/" + assetId + "/resize", credential);
        }
    }
}
