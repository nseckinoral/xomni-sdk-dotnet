using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Company;
using XOMNI.SDK.Public.Extensions;

namespace XOMNI.SDK.Public.Clients.Company
{
	public class StoreClient : BaseClient
	{
		public StoreClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

        public async Task<ApiResponse<PaginatedContainer<Store>>> GetAsync(string locationInfo, int searchDistance, int skip, int take)
		{
            Validator.For(locationInfo, "LocationInfo").NotNull().IsEmpty().IsContain(';');
            Validator.For(searchDistance, "SearchDistance").InRange(0, 1);
            Validator.For(skip, "Skip").IsGreaterThanOrEqual(1);
            Validator.For(take, "Take").IsGreaterThanOrEqual(1);

			string path = string.Format("/company/stores?locationInfo={0}&searchDistance={1}&skip={2}&take={3}", locationInfo, searchDistance, skip, take);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<PaginatedContainer<Store>>>().ConfigureAwait(false);
			}
		}
	}
}