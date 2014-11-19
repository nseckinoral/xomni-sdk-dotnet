using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model;
using XOMNI.SDK.Model.Asset;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.ApiAccess.Catalog
{
    internal class VideoMetadata : ApiAccessBase, IAssetMetadata
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/videometadata"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/videometadata"; }
        }

        public Task<AssetMetadata> AddMetadataAsync(AssetMetadata assetMetadata, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync<AssetMetadata>(GenerateUrl(SingleOperationBaseUrl), assetMetadata, credential);
        }

        public Task DeleteMetadataAsync(int assetId, string metadataKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("assetId", assetId.ToString());
            additionalParameters.Add("metadataKey", metadataKey);

            return HttpProvider.DeleteAsync(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential);
        }

        public Task ClearMetadataAsync(int assetId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("assetId", assetId.ToString());
            return HttpProvider.DeleteAsync(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

        public Task<AssetMetadata> UpdateMetadataAsync(AssetMetadata assetMetadata, ApiBasicCredential credential)
        {
            return HttpProvider.PutAsync<AssetMetadata>(GenerateUrl(SingleOperationBaseUrl), assetMetadata, credential);
        }


        public Task<List<Metadata>> GetAllMetadataAsync(int assetId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("assetId", assetId.ToString());
            return HttpProvider.GetAsync<List<Metadata>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }


        #region low level methods
        public XOMNIRequestMessage<AssetMetadata> CreateAddMetadataRequest(AssetMetadata assetMetadata, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<AssetMetadata>(HttpProvider.CreatePostRequest(GenerateUrl(SingleOperationBaseUrl), credential, assetMetadata));
        }

        public XOMNIRequestMessage CreateDeleteMetadataRequest(int assetId, string metadataKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("assetId", assetId.ToString());
            additionalParameters.Add("metadataKey", metadataKey);

            return new XOMNIRequestMessage(HttpProvider.CreateDeleteRequest(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential));
        }

        public XOMNIRequestMessage CreateClearMetadataRequest(int assetId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("assetId", assetId.ToString());
            return new XOMNIRequestMessage(HttpProvider.CreateDeleteRequest(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential));
        }

        public XOMNIRequestMessage<AssetMetadata> CreateUpdateMetadataRequest(AssetMetadata assetMetadata, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<AssetMetadata>(HttpProvider.CreatePutRequest(GenerateUrl(SingleOperationBaseUrl), credential, assetMetadata));
        }

        public XOMNIRequestMessage<List<Metadata>> CreateGetAllMetadataRequest(int assetId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("assetId", assetId.ToString());
            return new XOMNIRequestMessage<List<Metadata>>(HttpProvider.CreateGetRequest(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential));
        }

        #endregion
    }
}
