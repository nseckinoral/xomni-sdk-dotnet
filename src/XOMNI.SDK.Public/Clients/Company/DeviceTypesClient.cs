using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Company;
using XOMNI.SDK.Public.Extensions;
using XOMNI.SDK.Public.Infrastructure;

namespace XOMNI.SDK.Public.Clients.Company
{
	public class DeviceTypesClient : BaseClient
	{
		public DeviceTypesClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/company/device-types/fetching-a-list-of-device-types")]
		public async Task<ApiResponse<PaginatedContainer<DeviceType>>> GetAsync(int skip, int take)
		{
            Validator.For(skip, "skip").IsGreaterThanOrEqual(0);
            Validator.For(take, "take").InRange(1, 1000);

			string path = string.Format("/company/devicetypes?skip={0}&take={1}", skip, take);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<PaginatedContainer<DeviceType>>>().ConfigureAwait(false);
			}
		}
	}
}