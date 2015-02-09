using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Catalog;
using XOMNI.SDK.Public.Extensions;

namespace XOMNI.SDK.Public.Clients.Catalog
{
    public class BrandAssetClient : BaseClient
    {
        public BrandAssetClient(HttpClient httpClient)
            : base(httpClient)
        {

        }

        public async Task<ApiResponse<List<ImageAsset>>> GetImagesAsync(int brandId, string metadataKey = null, string metadataValue = null, AssetDetailType assetDetail = AssetDetailType.IncludeOnlyDefaultWithMetadata)
        {
            Validator.For(brandId, "brandId").IsGreaterThanOrEqual(1);

            string path = string.Format("/catalog/brands/{0}/images?", brandId);

            if (!string.IsNullOrEmpty(metadataKey) && !string.IsNullOrEmpty(metadataValue))
            {
                path += string.Format("metadataKey={0}&metadataValue={1}&", metadataKey, metadataValue);
            }
            else if (!string.IsNullOrEmpty(metadataKey) || !string.IsNullOrEmpty(metadataValue))
            {
                Validator.For(metadataKey, "metadataKey").IsNotNullOrEmpty();
                Validator.For(metadataValue, "metadataValue").IsNotNullOrEmpty();
            }

            path += string.Format("assetDetail={0}", (int)assetDetail);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<List<ImageAsset>>>().ConfigureAwait(false);
            }
        }

        public async Task<ApiResponse<List<Asset>>> GetVideosAsync(int brandId, string metadataKey = null, string metadataValue = null, AssetDetailType assetDetail = AssetDetailType.IncludeOnlyDefaultWithMetadata)
        {
            Validator.For(brandId, "brandId").IsGreaterThanOrEqual(1);

            string path = string.Format("/catalog/brands/{0}/videos?", brandId);

            if (!string.IsNullOrEmpty(metadataKey) && !string.IsNullOrEmpty(metadataValue))
            {
                path += string.Format("metadataKey={0}&metadataValue={1}&", metadataKey, metadataValue);
            }
            else if (!string.IsNullOrEmpty(metadataKey) || !string.IsNullOrEmpty(metadataValue))
            {
                Validator.For(metadataKey, "metadataKey").IsNotNullOrEmpty();
                Validator.For(metadataValue, "metadataValue").IsNotNullOrEmpty();
            }

            path += string.Format("assetDetail={0}", (int)assetDetail);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<List<Asset>>>().ConfigureAwait(false);
            }
        }

        public async Task<ApiResponse<List<Asset>>> GetDocumentsAsync(int brandId, string metadataKey = null, string metadataValue = null, AssetDetailType assetDetail = AssetDetailType.IncludeOnlyDefaultWithMetadata)
        {
            Validator.For(brandId, "brandId").IsGreaterThanOrEqual(1);

            string path = string.Format("/catalog/brands/{0}/documents?", brandId);

            if (!string.IsNullOrEmpty(metadataKey) && !string.IsNullOrEmpty(metadataValue))
            {
                path += string.Format("metadataKey={0}&metadataValue={1}&", metadataKey, metadataValue);
            }
            else if (!string.IsNullOrEmpty(metadataKey) || !string.IsNullOrEmpty(metadataValue))
            {
                Validator.For(metadataKey, "metadataKey").IsNotNullOrEmpty();
                Validator.For(metadataValue, "metadataValue").IsNotNullOrEmpty();
            }

            path += string.Format("assetDetail={0}", (int)assetDetail);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<List<Asset>>>().ConfigureAwait(false);
            }
        }
    }
}