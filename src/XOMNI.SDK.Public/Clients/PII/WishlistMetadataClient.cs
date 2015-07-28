using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Infrastructure;
using XOMNI.SDK.Public.Models;

namespace XOMNI.SDK.Public.Clients.PII
{
    public class WishlistMetadataClient : BaseClient
    {
        public WishlistMetadataClient(HttpClient httpClient)
            : base(httpClient)
        {

        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/pii/wishlist-metadata/fetching-the-metadata-of-a-wishlist")]
		public async Task<ApiResponse<List<Metadata>>> GetAsync(Guid wishlistUniqueKey)
        {
            if (wishlistUniqueKey.Equals(Guid.Empty))
            {
                throw new ArgumentOutOfRangeException("wishlistUniqueKey");
            }

            string path = string.Format("/pii/wishlistmetadata?wishlistUniqueKey={0}", wishlistUniqueKey);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<List<Metadata>>>().ConfigureAwait(false);
            }
        }
    }
}
