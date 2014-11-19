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

        internal Task<AssetRelations> GetAssetRelationsAsync(int assetId, ApiBasicCredential credential)
        {
            return HttpProvider.GetAsync<AssetRelations>(GenerateUrl(String.Format(AssetRelationBaseUrl, assetId)), credential);
        }

        internal Task DeleteAssetAsync(int assetId, bool force, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("force", force.ToString());
            return HttpProvider.DeleteAsync(GenerateUrl(String.Format(SingleOperationBaseUrl, assetId), additionalParameters), credential);
        }

        #region low level methods

        internal XOMNIRequestMessage<AssetRelations> CreateGetAssetRelationsRequest(int assetId, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<AssetRelations>(HttpProvider.CreateGetRequest(GenerateUrl(String.Format(AssetRelationBaseUrl, assetId)), credential));
        }

        internal XOMNIRequestMessage CreateDeleteAssetRequest(int assetId, bool force, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("force", force.ToString());
            return new XOMNIRequestMessage(HttpProvider.CreateDeleteRequest(GenerateUrl(String.Format(SingleOperationBaseUrl, assetId), additionalParameters), credential));
        }

        #endregion
    }
}
