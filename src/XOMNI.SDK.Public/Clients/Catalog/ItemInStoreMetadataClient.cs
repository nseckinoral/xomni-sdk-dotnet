using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Catalog;
using XOMNI.SDK.Public.Extensions;
using System.Globalization;
using XOMNI.SDK.Public.Infrastructure;

namespace XOMNI.SDK.Public.Clients.Catalog
{
    public class ItemInStoreMetadataClient : BaseClient
    {
        public ItemInStoreMetadataClient(HttpClient httpClient)
            : base(httpClient)
        {

        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/item-in-store-metadata/fetching-the-in-store-metadata-of-an-item")]
		public async Task<ApiResponse<List<GroupedInStoreMetadataContainer>>> GetAsync(int id, string key = null, string value = null, string keyPrefix = null, bool companyWide = false, Location location = null, double? searchDistance = null)
        {
            Validator.For(id, "id").IsGreaterThanOrEqual(1);
            string path = string.Format("/catalog/items/{0}/storemetadata?companyWide={1}", id, companyWide);
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(keyPrefix))
            {
                throw new ArgumentException("Key and keyPrefix parameters cannot be sent at the same time in a metadata query.");
            }

            if (companyWide)
            {
                if (location != null)
                {
                    Validator.For(location.Longitude, "Location.longitude").InRange(-180, 180);
                    Validator.For(location.Latitude, "Location.latitude").InRange(-90, 90);
                    Validator.For(searchDistance, "searchDistance").IsNotNull();
                    Validator.For(searchDistance.Value, "searchDistance").InRange(0, 10);
                    path += string.Format(CultureInfo.InvariantCulture.NumberFormat, "&longitude={0}&latitude={1}&searchDistance={2}", location.Longitude, location.Latitude, searchDistance);
                }
            }

            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
            {
                path += string.Format("&key={0}&value={1}", key, value);
            }
            else if (!(string.IsNullOrEmpty(key) && string.IsNullOrEmpty(value)))
            {
                Validator.For(key, "key").IsNotNullOrEmpty();
                Validator.For(value, "value").IsNotNullOrEmpty();
            }

            if (!string.IsNullOrEmpty(keyPrefix))
            {
                path += string.Format("&keyPrefix={0}", keyPrefix);
            }

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<List<GroupedInStoreMetadataContainer>>>().ConfigureAwait(false);
            }
        }
    }
}
