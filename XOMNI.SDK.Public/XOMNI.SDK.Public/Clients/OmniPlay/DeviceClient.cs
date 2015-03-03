using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.OmniPlay;
using XOMNI.SDK.Public.Extensions;

namespace XOMNI.SDK.Public.Clients.OmniPlay
{
	public class DeviceClient : BaseClient
	{
		public DeviceClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

		public async Task<ApiResponse<List<OmniTicketDetail>>> GetIncomingsAsync(string deviceId)
		{
            Validator.For(deviceId, "deviceId").IsNotNullOrEmpty();

			string path = string.Format("/omniplay/devices/{0}/incoming", deviceId);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<List<OmniTicketDetail>>>().ConfigureAwait(false);
			}
		}

        public async Task SubscribeToDevice(string deviceId)
        {
            ValidatePIIToken();
            Validator.For(deviceId, "deviceId").IsNotNullOrEmpty();

            string path = string.Format("/omniplay/devices/{0}", deviceId);
            await Client.PostAsync(path, null).ConfigureAwait(false);
        }
	}
}