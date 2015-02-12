using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Catalog;
using XOMNI.SDK.Public.Extensions;

namespace XOMNI.SDK.Public.Clients.Catalog
{
	public class AutoCompleteClient : BaseClient
	{
		public AutoCompleteClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

        public async Task<ApiResponse<AutoCompleteResult>> GetAsync(AutoCompleteSearchType searchType, string searchTerm, int skip, int take, bool includeOnlyMasterItems)
		{
            Validator.For(searchTerm, "searchTerm").IsNotNullOrEmpty();
            Validator.For(skip, "skip").IsGreaterThanOrEqual(0);
            Validator.For(take, "take").IsGreaterThanOrEqual(1);

			string path = string.Format("/catalog/autocomplete/{0}?searchTerm={1}&skip={2}&take={3}&includeOnlyMasterItems={4}", searchType, searchTerm, skip, take,includeOnlyMasterItems);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
				return await response.Content.ReadAsAsync<ApiResponse<AutoCompleteResult>>().ConfigureAwait(false);
			}
		}
	}
}