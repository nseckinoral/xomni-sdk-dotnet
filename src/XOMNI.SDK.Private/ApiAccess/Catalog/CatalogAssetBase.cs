using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model.Asset;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.ApiAccess.Catalog
{
    internal class CatalogAssetBase : ApiAccessBase
    {
        public virtual Task<AssetRelationMapping> PostRelationAsync(int id, AssetRelation assetRelation, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync<AssetRelationMapping>(GenerateUrl(string.Format(SingleOperationBaseUrl, id)), assetRelation, credential);
        }

        public virtual Task<AssetRelationMapping> PostRelationAsync(int id, int assetId, bool isDefault, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("assetId", assetId.ToString());

            if (isDefault != false)
            {
                additionalParameters.Add("isDefault", isDefault.ToString());
            }

            return HttpProvider.PostAsync<AssetRelationMapping>(GenerateUrl(string.Format(SingleOperationBaseUrl, id), additionalParameters), null, credential);
        }

        public virtual Task<List<T>> GetRelationAsync<T>(int id, ApiBasicCredential credential)
        {
            return HttpProvider.GetAsync<List<T>>(GenerateUrl(string.Format(SingleOperationBaseUrl, id)), credential);
        }

        public virtual Task DeleteRelationAsync(int id, int assetId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("assetId", assetId.ToString());
            return HttpProvider.DeleteAsync(GenerateUrl(string.Format(SingleOperationBaseUrl, id), additionalParameters), credential);
        }

        public virtual Task<AssetRelationMapping> PutRelationAsync(AssetRelationMapping assetRelationMapping, ApiBasicCredential credential)
        {
            return HttpProvider.PutAsync<AssetRelationMapping>(GenerateUrl(string.Format(SingleOperationBaseUrl, assetRelationMapping.RelatedId)), assetRelationMapping, credential);
        }

        protected override string SingleOperationBaseUrl { get { return string.Empty; } }

        protected override string ListOperationBaseUrl { get { return string.Empty; } }
    }

}
