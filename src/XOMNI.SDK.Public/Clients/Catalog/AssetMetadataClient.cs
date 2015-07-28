using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Infrastructure;
using XOMNI.SDK.Public.Models;

namespace XOMNI.SDK.Public.Clients.Catalog
{
    public class AssetMetadataClient : BaseClient
    {
        public AssetMetadataClient(HttpClient httpClient)
            : base(httpClient)
        {

        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/asset-metadata/fetching-image-assets-metadata")]
        public async Task<ApiResponse<List<Metadata>>> GetImageMetadataAsync(int assetId)
        {
            if (assetId <= 0)
            {
                throw new ArgumentException("assetId must be greater than or equal to zero");
            }

            string path = string.Format("/catalog/imagemetadata?assetId={0}", assetId);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<List<Metadata>>>().ConfigureAwait(false);
            }
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/asset-metadata/fetching-video-assets-metadata")]
        public async Task<ApiResponse<List<Metadata>>> GetVideoMetadataAsync(int assetId)
        {
            if (assetId <= 0)
            {
                throw new ArgumentException("assetId must be greater than or equal to zero");
            }

            string path = string.Format("/catalog/videometadata?assetId={0}", assetId);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<List<Metadata>>>().ConfigureAwait(false);
            }
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/asset-metadata/fetching-document-assets-metadata")]
        public async Task<ApiResponse<List<Metadata>>> GetDocumentMetadataAsync(int assetId)
        {
            if (assetId <= 0)
            {
                throw new ArgumentException("assetId must be greater than or equal to zero");
            }

            string path = string.Format("/catalog/documentmetadata?assetId={0}", assetId);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<List<Metadata>>>().ConfigureAwait(false);
            }
        }
    }
}