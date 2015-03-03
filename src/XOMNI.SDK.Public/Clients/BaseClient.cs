using System;
using System.Net.Http;
using System.Linq;
using XOMNI.SDK.Public.Infrastructure;

namespace XOMNI.SDK.Public.Clients
{
    public abstract class BaseClient
    {
        protected readonly HttpClient Client;

        protected BaseClient(HttpClient httpClient)
        {
            if (httpClient == null)
            {
                throw new ArgumentNullException("httpClient");
            }

            Client = httpClient;
        }

        protected void ValidatePIIToken()
        {
            var piiTokens = Enumerable.Empty<string>();
            Client.DefaultRequestHeaders.TryGetValues(Constants.PIITokenHeaderKey, out piiTokens);
            
            if (piiTokens == null || !piiTokens.Any())
            {
                throw new ArgumentException("User/OmniSession");
            }
        }
    }
}
