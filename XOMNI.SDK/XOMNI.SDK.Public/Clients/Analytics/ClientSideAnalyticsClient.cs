using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Models.Analytics;
using XOMNI.SDK.Public.Extensions;

namespace XOMNI.SDK.Public.Clients.Analytics
{
    public class ClientSideAnalyticsClient : BaseClient
    {
        public ClientSideAnalyticsClient(HttpClient httpClient)
            : base(httpClient)
        {

        }

        public async Task PostAsync(List<ClientLog> clientLogs)
        {
            Validator.For(clientLogs, "clientLogs").IsNotNull();

            string path = "/analytics/clientlogs";

            foreach (var log in clientLogs)
            {
                Validator.For(log.CounterName, "CounterName").IsNotNullOrEmpty();
                Validator.For(log.Value, "Value").IsGreaterThanOrEqual(1);
            }

            await Client.PostAsJsonAsync(path, clientLogs).ConfigureAwait(false);
        }
    }
}
