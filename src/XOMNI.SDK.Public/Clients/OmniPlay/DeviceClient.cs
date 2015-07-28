using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.OmniPlay;
using XOMNI.SDK.Public.Extensions;
using XOMNI.SDK.Public.Infrastructure;

namespace XOMNI.SDK.Public.Clients.OmniPlay
{
	public class DeviceClient : BaseClient
	{
		public DeviceClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/omniplay/device/fetching-pii-user-omnitickets-on-omniplay-device-queue")]
		public async Task<ApiResponse<List<OmniTicketDetail>>> GetIncomingsAsync(string deviceId)
		{
            Validator.For(deviceId, "deviceId").IsNotNullOrEmpty();

			string path = string.Format("/omniplay/devices/{0}/incoming", deviceId);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<List<OmniTicketDetail>>>().ConfigureAwait(false);
			}
		}

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/omniplay/device/subscribing-to-omniplay-device-queue")]
        public async Task SubscribeToDeviceAsync(string deviceId)
        {
            ValidatePIIToken();
            Validator.For(deviceId, "deviceId").IsNotNullOrEmpty();

            string path = string.Format("/omniplay/devices/{0}", deviceId);
            await Client.PostAsync(path, null).ConfigureAwait(false);
        }
	}
}