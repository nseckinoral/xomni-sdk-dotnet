using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model.Private.Asset;

namespace XOMNI.SDK.Private.ApiAccess.Asset
{
    public class Assets : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/storage/assets/{0}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        protected virtual string AssetRelationBaseUrl
        {
            get { return "/private/storage/assets/{0}/relations"; }
        }

        public Task<AssetRelations> GetAssetRelationsAsync(int assetId, ApiBasicCredential credential)
        {
            return HttpProvider.GetAsync<AssetRelations>(GenerateUrl(String.Format(AssetRelationBaseUrl, assetId)), credential);
        }

        public Task DeleteAssetAsync(int assetId, bool force, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("force", force.ToString());
            return HttpProvider.DeleteAsync(GenerateUrl(String.Format(AssetRelationBaseUrl, assetId), additionalParameters), credential);
        }
    }
}
