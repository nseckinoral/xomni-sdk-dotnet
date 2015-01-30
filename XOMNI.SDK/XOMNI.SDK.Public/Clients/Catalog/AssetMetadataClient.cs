using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;

namespace XOMNI.SDK.Public.Clients.Catalog
{
    public class AssetMetadataClient : BaseClient
    {
        public AssetMetadataClient(HttpClient httpClient)
            : base(httpClient)
        {

        }
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

        public async Task<ApiResponse<Metadata>> GetVideoMetadataAsync(int assetId)
        {
            if (assetId <= 0)
            {
                throw new ArgumentException("assetId must be greater than or equal to zero");
            }

            string path = string.Format("/catalog/videometadata?assetId={0}", assetId);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<Metadata>>().ConfigureAwait(false);
            }
        }

        public async Task<ApiResponse<Metadata>> GetDocumentMetadataAsync(int assetId)
        {
            if (assetId <= 0)
            {
                throw new ArgumentException("assetId must be greater than or equal to zero");
            }

            string path = string.Format("/catalog/documentmetadata?assetId={0}", assetId);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<Metadata>>().ConfigureAwait(false);
            }
        }
    }
}