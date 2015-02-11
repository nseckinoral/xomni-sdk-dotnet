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
using System.Net;

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

        protected const string genericErrorResponse = @"{
            'IdentifierGuid':'7358fe16-3925-4951-9a77-fca4f9e167b0',
            'IdentifierTick':635585478999549713,
            'FriendlyDescription':'Generic error friendly description.'
        }";
        
        protected readonly HttpResponseMessage notFoundHttpResponseMessage = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.NotFound,
            Content = new MockedJsonContent(genericErrorResponse)
        };

        protected readonly HttpResponseMessage unauthorizedHttpResponseMessage = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.Unauthorized,
            Content = new MockedJsonContent(genericErrorResponse)
        };

        protected readonly HttpResponseMessage notImplementedHttpResponseMessage = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.NotImplemented,
            Content = new MockedJsonContent(genericErrorResponse)
        };

        protected readonly HttpResponseMessage badRequestHttpResponseMessage = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Content = new MockedJsonContent(genericErrorResponse)
        };

        protected readonly HttpResponseMessage conflictHttpResponseMessage = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.Conflict,
            Content = new MockedJsonContent(genericErrorResponse)
        };

        protected readonly User piiUser = new User
        {
            UserName = "testPiiUser",
            Password = "testPiiPassword"
        };

        protected readonly OmniSession omniSession = new OmniSession
        {
            SessionGuid = Guid.NewGuid()
        };

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

        protected async Task ResponseParseTestAsync(Func<TClient, Task<byte[]>> actAsync, HttpResponseMessage mockedHttpResponseMessage, byte[] validAPIResponseByteArray, User piiUser = null, OmniSession omniSession = null)
        {
            var mockedClient = InitalizeMockedClient(mockedHttpResponseMessage, piiUser: piiUser, omniSession: omniSession);
            var actualResponse = await actAsync(mockedClient);

            AssertExtensions.AreDeeplyEqual(validAPIResponseByteArray, actualResponse);
        }

        protected async Task RequestParseTestAsync<TRequest>(Func<TClient,Task> actAsync, string validAPIRequestJson, User piiUser = null, OmniSession omniSession = null)
        {
            Action<HttpRequestMessage, CancellationToken> testCallback = (req, can) =>
            {
                var actualRequest = req.Content.ReadAsAsync<TRequest>().Result;
                AssertExtensions.AreDeeplyEqual(JsonConvert.DeserializeObject<TRequest>(validAPIRequestJson), actualRequest);
            };

            var mockedClient = InitalizeMockedClient(testCallback: testCallback, piiUser: piiUser, omniSession: omniSession);
            await actAsync(mockedClient);
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
            bool exceptionRaised = true;
            
            try
            {
                await actAsync(mockedClient);
                exceptionRaised = false;
            }
            catch (XOMNIPublicAPIException ex)
            {
                AssertExtensions.AreDeeplyEqual(expectedExceptionResult, ex.ApiExceptionResult);
            }
            if (!exceptionRaised)
            {
                Assert.Fail("Expected exception is not raised.");
            }
        }

        protected async Task SDKExceptionResponseTestAsync(Func<TClient, Task> actAsync, Exception expectedException, User piiUser = null, OmniSession omniSession = null)
        {
            var mockedClient = InitalizeMockedClient(piiUser: piiUser, omniSession: omniSession);
            bool exceptionRaised = true;

            try
            {
                await actAsync(mockedClient);
                exceptionRaised = false;
            }
            catch (Exception ex)
            {
                AssertExtensions.AreDeeplyEqual(expectedException, ex);
            }

            if (!exceptionRaised)
            {
                Assert.Fail("Expected exception is not raised.");
            }
        }

        protected async Task DefaultRequestHeadersTestAsync(Func<TClient, Task> actAsync, User piiUser = null, OmniSession omniSession = null)
        {
            Action<HttpRequestMessage, CancellationToken> testCallback = (req, can) =>
            {
                Assert.AreEqual(req.Headers.GetValues(authorizationHeaderKey).First(), "Basic dGVzdFVzZXI6dGVzdFBhc3M=");
                Assert.AreEqual(req.Headers.GetValues(versionHeaderKey).Where(t => t.StartsWith(xomniVersionPrefix)).First(), "application/vnd.xomni.api-v3_0");

                if (piiUser != null)
                {
                    var piiToken = req.Headers.GetValues(piiTokenHeaderKey).First();
                    Assert.IsNotNull(piiToken);

                    var piiTokenArray = Encoding.UTF8.GetString(Convert.FromBase64String(piiToken)).Split(';');
                    var piiUserName = piiTokenArray[0].Split(':')[1];
                    var piiPassword = piiTokenArray[1].Split(':')[1];

                    Assert.AreEqual(piiUser.UserName,  piiUserName);
                    Assert.AreEqual(piiUser.Password,  piiPassword);
                }

                if (omniSession != null)
                {
                    var piiToken = req.Headers.GetValues(piiTokenHeaderKey).First();
                    Assert.IsNotNull(piiToken);

                    var sessionGuid = Guid.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(piiToken)).Split(':')[1]);

                    Assert.AreEqual(omniSession.SessionGuid, sessionGuid);
                }
            };

            var mockedClient = InitalizeMockedClient(testCallback: testCallback, piiUser: piiUser, omniSession: omniSession);

            await actAsync(mockedClient);
        }
    }
}
