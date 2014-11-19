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

        #region low level methods
        public virtual XOMNIRequestMessage<AssetRelationMapping> CreatePostRelationRequest(int id, AssetRelation assetRelation, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<AssetRelationMapping>(HttpProvider.CreatePostRequest(GenerateUrl(string.Format(SingleOperationBaseUrl, id)), credential, assetRelation));
        }

        public virtual XOMNIRequestMessage<AssetRelationMapping> CreatePostRelationRequest(int id, int assetId, bool isDefault, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("assetId", assetId.ToString());

            if (isDefault != false)
            {
                additionalParameters.Add("isDefault", isDefault.ToString());
            }

            return new XOMNIRequestMessage<AssetRelationMapping>(HttpProvider.CreatePostRequest(GenerateUrl(string.Format(SingleOperationBaseUrl, id), additionalParameters), credential, null));
        }

        public virtual XOMNIRequestMessage<List<T>> CreateGetRelationRequest<T>(int id, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<List<T>>(HttpProvider.CreateGetRequest(GenerateUrl(string.Format(SingleOperationBaseUrl, id)), credential));
        }

        public virtual XOMNIRequestMessage CreateDeleteRelationRequest(int id, int assetId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("assetId", assetId.ToString());
            return new XOMNIRequestMessage(HttpProvider.CreateDeleteRequest(GenerateUrl(string.Format(SingleOperationBaseUrl, id), additionalParameters), credential));
        }

        public virtual XOMNIRequestMessage<AssetRelationMapping> CreatePutRelationRequest(AssetRelationMapping assetRelationMapping, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<AssetRelationMapping>(HttpProvider.CreatePutRequest(GenerateUrl(string.Format(SingleOperationBaseUrl, assetRelationMapping.RelatedId)), credential, assetRelationMapping));
        }
        #endregion
    }

}
