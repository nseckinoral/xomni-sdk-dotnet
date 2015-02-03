using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using Moq.Protected;
using System.Threading;
using Newtonsoft.Json;
using XOMNI.SDK.Public.Test.Helpers;
using XOMNI.SDK.Public.Exceptions;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.PII;
using XOMNI.SDK.Public.Models.OmniPlay;

namespace XOMNI.SDK.Public.Test.Fixtures
{
    public abstract class BaseClientFixture<TClient> where TClient : BaseClient
    {
        const string userName = "testUser";
        const string password = "testPass";
        const string serviceUri = "http://test.apistaging.xomni.com";
        const string authorizationHeaderKey = "Authorization";
        const string versionHeaderKey = "Accept";
        const string piiTokenHeaderKey = "PIIToken";
        const string xomniVersionPrefix= "application/vnd.xomni";

        private TClient GetClientWithHandlers(IEnumerable<DelegatingHandler> handlers, User piiUser = null, OmniSession omniSession = null)
        {
            var clientContext = new ClientContext(userName, password, serviceUri, handlers);
            
            if (piiUser != null)
            {
                clientContext.PIIUser = piiUser;
            }
            
            if (omniSession != null)
            {
                clientContext.OmniSession = omniSession;
            }

            return clientContext.Of<TClient>();
        }

        private TClient GetClientWithHandler(DelegatingHandler handler, User piiUser = null, OmniSession omniSession = null)
        {
            return GetClientWithHandlers(new[] { handler }, piiUser, omniSession);
        }

        protected TClient InitalizeMockedClient(HttpResponseMessage mockedHttpResponseMessage = null, Action<HttpRequestMessage, CancellationToken> testCallback = null, User piiUser = null, OmniSession omniSession = null)
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

            return GetClientWithHandler(handler.Object, piiUser, omniSession);
        }

        protected async Task ResponseParseTestAsync<TResponse>(Func<TClient, Task<TResponse>> actAsync, HttpResponseMessage mockedHttpResponseMessage, string validAPIResponseJson, User piiUser = null, OmniSession omniSession = null)
        {
            var mockedClient = InitalizeMockedClient(mockedHttpResponseMessage, piiUser: piiUser, omniSession: omniSession);

            var actualResponse = await actAsync(mockedClient);

            AssertExtensions.AreDeeplyEqual(JsonConvert.DeserializeObject<TResponse>(validAPIResponseJson), actualResponse);
        }

        protected async Task HttpMethodTestAsync(Func<TClient, Task> actAsync, HttpMethod expectedHttpMethod, User piiUser = null, OmniSession omniSession = null)
        {
            Action<HttpRequestMessage, CancellationToken> testCallback = (req, can) =>
            {
                Assert.AreEqual(expectedHttpMethod, req.Method);
            };

            var mockedClient = InitalizeMockedClient(testCallback: testCallback, piiUser: piiUser, omniSession: omniSession);

            await actAsync(mockedClient);
        }

        protected async Task UriTestAsync(Func<TClient, Task> actAsync, string expectedUri, User piiUser = null, OmniSession omniSession = null)
        {
            Action<HttpRequestMessage, CancellationToken> testCallback = (req, can) =>
            {
                Assert.AreEqual(expectedUri, req.RequestUri.PathAndQuery);
            };

            var mockedClient = InitalizeMockedClient(testCallback: testCallback, piiUser: piiUser, omniSession: omniSession);

            await actAsync(mockedClient);
        }

        protected async Task APIExceptionResponseTestAsync(Func<TClient, Task> actAsync, HttpResponseMessage mockedHttpResponseMessage, ExceptionResult expectedExceptionResult, User piiUser = null, OmniSession omniSession = null)
        {
            var mockedClient = InitalizeMockedClient(mockedHttpResponseMessage, piiUser: piiUser, omniSession: omniSession);

            try
            {
                await actAsync(mockedClient);
                Assert.Fail("SDK must raise an exception in this case.");
            }
            catch (XOMNIPublicAPIException ex)
            {
                AssertExtensions.AreDeeplyEqual(expectedExceptionResult, ex.ApiExceptionResult);
            }
        }

        protected async Task SDKExceptionResponseTestAsync(Func<TClient, Task> actAsync, Exception expectedException, User piiUser = null, OmniSession omniSession = null)
        {
            var mockedClient = InitalizeMockedClient(piiUser: piiUser, omniSession: omniSession);

            try
            {
                await actAsync(mockedClient);
                Assert.Fail("SDK must raise an exception in this case.");
            }
            catch (Exception ex)
            {
                AssertExtensions.AreDeeplyEqual(expectedException, ex);
            }
        }

        protected async Task DefaultRequestHeadersTestAsync(Func<TClient, Task> actAsync, User piiUser = null, OmniSession omniSession = null)
        {
            Action<HttpRequestMessage, CancellationToken> testCallback = (req, can) =>
            {
                Assert.AreEqual(req.Headers.GetValues(authorizationHeaderKey).First(), "Basic dGVzdFVzZXI6dGVzdFBhc3M=");
                Assert.AreEqual(req.Headers.GetValues(versionHeaderKey).Where(t => t.StartsWith(xomniVersionPrefix)).First(), "application/vnd.xomni.api-v3_0");
            };

            var mockedClient = InitalizeMockedClient(testCallback: testCallback, piiUser: piiUser, omniSession: omniSession);

            await actAsync(mockedClient);
        }
    }
}
