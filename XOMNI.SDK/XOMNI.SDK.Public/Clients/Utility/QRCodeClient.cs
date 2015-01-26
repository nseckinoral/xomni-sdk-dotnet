using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;

namespace XOMNI.SDK.Public.Clients.Utility
{
	public class QRCodeClient : BaseClient
	{
		public QRCodeClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

		public async Task<byte[]> GetAsync(int moduleSize, string data)
		{
			string path = string.Format("/utils/qrcode?data={0}&moduleSize={1}", data, moduleSize);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
			}
		}
	}
}