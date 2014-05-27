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
    internal class DocumentMetadata : ApiAccessBase, IAssetMetadata
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/documentMetadata"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/documentMetadata"; }
        }

        public async Task<AssetMetadata> AddMetadataAsync(AssetMetadata assetMetadata, ApiBasicCredential credential)
        {
            AssetMetadata createdMetadata = await HttpProvider.PostAsync<AssetMetadata>(GenerateUrl(SingleOperationBaseUrl), assetMetadata, credential);
            return createdMetadata;
        }

        public async Task DeleteMetadataAsync(int assetId, string metadataKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("assetId", assetId.ToString());
            additionalParameters.Add("metadataKey", metadataKey);

            await HttpProvider.DeleteAsync(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential);
        }

        public async Task ClearMetadataAsync(int assetId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("assetId", assetId.ToString());
            await HttpProvider.DeleteAsync(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

        public async Task<AssetMetadata> UpdateMetadataAsync(AssetMetadata assetMetadata, ApiBasicCredential credential)
        {
            AssetMetadata updatedMetadata = await HttpProvider.PutAsync<AssetMetadata>(GenerateUrl(SingleOperationBaseUrl), assetMetadata, credential);
            return updatedMetadata;
        }

        public async Task<List<Metadata>> GetAllMetadataAsync(int assetId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("assetId", assetId.ToString());
            List<Metadata> assetMetadataList = await HttpProvider.GetAsync<List<Metadata>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
            return assetMetadataList;
        }
    }
}
