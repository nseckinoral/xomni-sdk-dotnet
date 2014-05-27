using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Core.Providers
{
    public class RetryHandler : DelegatingHandler
    {
        public RetryHandler(HttpMessageHandler innerHandler)
        {
            InnerHandler = innerHandler;
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;
            int retryCount = 4;

            for (int i = 0; i < retryCount; i++)
            {
                try
                {
                    response = await base.SendAsync(request, cancellationToken);
                    break;
                }
                catch (HttpRequestException requestEx)
                {
                    if (i == retryCount - 1)
                    {
                        throw;
                    }
                }
            }

            return response;
        }
    }
}
