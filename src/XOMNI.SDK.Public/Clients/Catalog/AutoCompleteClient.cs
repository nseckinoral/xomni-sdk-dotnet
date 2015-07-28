using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Catalog;
using XOMNI.SDK.Public.Extensions;
using XOMNI.SDK.Public.Infrastructure;

namespace XOMNI.SDK.Public.Clients.Catalog
{
    public class AutoCompleteClient : BaseClient
    {
        public AutoCompleteClient(HttpClient httpClient)
            : base(httpClient)
        {

        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/auto-complete/auto-complete-for-brands-categories-and-items")]
        public async Task<ApiResponse<AutoCompleteResult>> GetAsync(AutoCompleteSearchType searchType, string searchTerm, int top, bool includeOnlyMasterItems)
        {
            Validator.For(searchTerm, "searchTerm").IsNotNullOrEmpty();
            Validator.For(searchTerm.Length, "searchTerm length").InRange(3, 25);
            Validator.For(top, "top").InRange(1, 100);

            string path = string.Format("/catalog/autocomplete/{0}?searchTerm={1}&top={2}&includeOnlyMasterItems={3}", searchType, searchTerm, top, includeOnlyMasterItems);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<AutoCompleteResult>>().ConfigureAwait(false);
            }
        }
    }
}