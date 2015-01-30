using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Catalog;

namespace XOMNI.SDK.Public.Clients.Catalog
{
	public class BrandAssetClient : BaseClient
	{
		public BrandAssetClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

		public async Task<ApiResponse<List<ImageAsset>>> GetImagesAsync(int brandId, string metadataKey = null, string metadataValue = null, AssetDetailType includeMetadata = AssetDetailType.IncludeAll)
		{
            if(brandId<=0)
            {
                throw new ArgumentException("brandId must be greater than or equal to zero");
            }

            string path = string.Format("/catalog/brands/{0}/images?", brandId);

            if(!string.IsNullOrEmpty(metadataKey))
            {
                path += string.Format("metadataKey={0}&", metadataKey);
            }

            if (!string.IsNullOrEmpty(metadataValue))
            {
                path += string.Format("metadataValue={0}&", metadataValue);
            }

            path += string.Format("assetDetail={0}", includeMetadata);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<List<ImageAsset>>>().ConfigureAwait(false);
			}
		}

        public async Task<ApiResponse<List<Asset>>> GetVideosAsync(int brandId, string metadataKey = null, string metadataValue = null, AssetDetailType includeMetadata = AssetDetailType.IncludeAll)
		{
            if (brandId <= 0)
            {
                throw new ArgumentException("brandId must be greater than or equal to zero");
            }
            string path = string.Format("/catalog/brands/{0}/videos?", brandId);

            if (!string.IsNullOrEmpty(metadataKey))
            {
                path += string.Format("metadataKey={0}&", metadataKey);
            }

            if (!string.IsNullOrEmpty(metadataValue))
            {
                path += string.Format("metadataValue={0}&", metadataValue);
            }

            path += string.Format("assetDetail={0}", includeMetadata);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<List<Asset>>>().ConfigureAwait(false);
			}
		}

        public async Task<ApiResponse<List<Asset>>> GetDocumentsAsync(int brandId, string metadataKey = null, string metadataValue = null, AssetDetailType includeMetadata = AssetDetailType.IncludeAll)
		{
            if (brandId <= 0)
            {
                throw new ArgumentException("brandId must be greater than or equal to zero");
            }

            string path = string.Format("/catalog/brands/{0}/documents?", brandId);

            if (!string.IsNullOrEmpty(metadataKey))
            {
                path += string.Format("metadataKey={0}&", metadataKey);
            }

            if (!string.IsNullOrEmpty(metadataValue))
            {
                path += string.Format("metadataValue={0}&", metadataValue);
            }

            path += string.Format("assetDetail={0}", includeMetadata);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<List<Asset>>>().ConfigureAwait(false);
			}
		}
	}
}