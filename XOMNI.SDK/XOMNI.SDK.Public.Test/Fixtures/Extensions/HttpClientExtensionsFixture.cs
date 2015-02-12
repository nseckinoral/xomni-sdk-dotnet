using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Extensions;
using System.Net.Http.Formatting;

namespace XOMNI.SDK.Public.Test.Fixtures.Extensions
{
    [TestClass]
    public class HttpClientExtensionsFixture 
    {
        const string requestUri = "http://www.test.com/";
        private HttpClient InitalizeMockedClient(HttpResponseMessage mockedHttpResponseMessage = null, Action<HttpRequestMessage, CancellationToken> testCallback = null)
        {
            var handler = new Mock<DelegatingHandler>();
            var handlerSetup = handler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());

            if (mockedHttpResponseMessage != null)
            {
                handlerSetup.Returns(Task.FromResult(mockedHttpResponseMessage));
            }
            else
            {
                handlerSetup.Returns(Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = new StringContent("")
                }));
            }

            if (testCallback != null)
            {
                handlerSetup.Callback(testCallback);
            }

            return new HttpClient(handler.Object);
        }

        [TestMethod, TestCategory("HttpClientExtensions"), TestCategory("PatchAsJsonAsync")]
        public async Task RequestUriTest()
        {
            var client = InitalizeMockedClient(testCallback:
                (req, cal) =>
                {
                    Assert.AreEqual(requestUri,req.RequestUri.ToString());
                }
            );
            await client.PatchAsJsonAsync<string>(requestUri, "test");
        }

        [TestMethod, TestCategory("HttpClientExtensions"), TestCategory("PatchAsJsonAsync")]
        public async Task HttpMethodTest()
        {
            var client = InitalizeMockedClient(testCallback:
                (req, cal) =>
                {
                    Assert.AreEqual(req.Method, new HttpMethod("PATCH"));
                }
            );
            await client.PatchAsJsonAsync<string>(requestUri, "test");
        }

        [TestMethod, TestCategory("HttpClientExtensions"), TestCategory("PatchAsJsonAsync")]
        public async Task RequestParseTest()
        {
            var client = InitalizeMockedClient(testCallback:
                async (req, cal) =>
                {
                    var response = await req.Content.ReadAsAsync<string>();
                    Assert.AreEqual(response, "test");
                }
            );
            await client.PatchAsJsonAsync<string>(requestUri, "test");
        }
    }
}
