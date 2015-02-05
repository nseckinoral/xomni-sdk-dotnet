using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Extensions;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Utility;

namespace XOMNI.SDK.Public.Clients.Utility
{
	public class QRCodeClient : BaseClient
	{
		public QRCodeClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

		public async Task<byte[]> GetAsync(int moduleSize, string data, ErrorCorrectionLevel errorCorrectionLevel = ErrorCorrectionLevel.Quartile)
		{
            Validator.For(moduleSize, "moduleSize").IsGreaterThanOrEqual(1);
            Validator.For(data, "data").IsNotNull().IsNotNullOrEmpty();

            string path = string.Format("/utils/qrcode?data={0}&moduleSize={1}&errorCorrectionLevel={2}", data, moduleSize, errorCorrectionLevel);

            if(string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException("data");
            }
            if(moduleSize<=0)
            {
                throw new ArgumentException("moduleSize");
            }
            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
			}
		}
	}
}