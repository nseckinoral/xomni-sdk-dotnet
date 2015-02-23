using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients.OmniPlay;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.OmniPlay;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.OmniPlay
{
    [TestClass]
    public class OmniTicketClientFixture : BaseClientFixture<OmniTicketClient>
    {
        const string validAPIResponseForGetAndGetTicketAsync = @"{
            'Data': {
                'Ticket': 'Pbda570b0-cf86-4c86-830c-ac9445faf208'
            }
        }";

        const string validAPIResponseForGetSessionAsync = @"{
	        'Data': [{
		        'PIISession': {
			        'SessionGuid': 'Pbda570b0-cf86-4c86-830c-ac9445faf208'
		        },
		        'PIISession': {
			        'SessionGuid': 'Pbda570b0-cf86-4c86-830c-ac9445faf208'
		        }
	        }]
        }";

        const string validAPIResponseForPostSessionAsync = @"{
            'Data': {
                'SessionGuid': 'bda570b0-cf86-4c86-830c-ac9445faf208'
            }
        }";

        const string validAPIResponseForPostImportAsync = @"{
            'Data': {
                'WishlistUniqueKey': 'bda570b0-cf86-4c86-830c-ac9445faf208'
            }
        }";

        readonly OmniTicket sampleTicket = new OmniTicket()
        {
            Ticket = Guid.Parse(uniqeId)
        };

        readonly WishlistImportRequest sampleWishlistImportRequest = new WishlistImportRequest()
        {
            OmniTicket = Guid.Parse(uniqeId),
            GpsLocation = new Location()
            {
                Latitude = 23.32,
                Longitude = 34,
            }
        };

        #region GetTicketAsync

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("GetTicketAsync"), TestCategory("HTTP.GET")]
        public async Task GetTicketAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (OmniTicketClient c) => c.GetTicketAsync(),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponseForGetAndGetTicketAsync)
                },
                validAPIResponseForGetAndGetTicketAsync,piiUser:piiUser
                );
        }
    
        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("GetTicketAsync"), TestCategory("HTTP.GET")]
        public async Task GetTicketAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (OmniTicketClient c) => c.GetTicketAsync(),
                HttpMethod.Get,piiUser:piiUser
                );
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("GetTicketAsync"), TestCategory("HTTP.GET")]
        public async Task GetTicketAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (OmniTicketClient c) => c.GetTicketAsync(),
              string.Format("/omniplay/pii/ticket"),piiUser:piiUser);
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("GetTicketAsync"), TestCategory("HTTP.GET")]
        public async Task GetTicketAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (OmniTicketClient c) => c.GetTicketAsync(),piiUser:piiUser);
        }

        #endregion

        #region GetSessionAsync

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("GetSessionAsync"), TestCategory("HTTP.GET")]
        public async Task GetSessionAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (OmniTicketClient c) => c.GetSessionAsync(),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponseForGetSessionAsync)
                }
                ,
                validAPIResponseForGetSessionAsync, piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("GetSessionAsync"), TestCategory("HTTP.GET")]
        public async Task GetSessionAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (OmniTicketClient c) => c.GetSessionAsync(),
                HttpMethod.Get, piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("GetSessionAsync"), TestCategory("HTTP.GET")]
        public async Task GetSessionAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (OmniTicketClient c) => c.GetSessionAsync(),
              string.Format("/omniplay/pii/session"), piiUser: piiUser);
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("GetSessionAsync"), TestCategory("HTTP.GET")]
        public async Task GetSessionAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (OmniTicketClient c) => c.GetSessionAsync(), piiUser: piiUser);
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("GetSessionAsync"), TestCategory("HTTP.GET")]
        public async Task GetSessionAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (OmniTicketClient c) => c.GetSessionAsync(),
              notFoundHttpResponseMessage,
              expectedExceptionResult, piiUser: piiUser
              );
        }

        #endregion

        #region DeleteAsync

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (OmniTicketClient c) => c.DeleteAsync(),
                HttpMethod.Delete,piiUser:piiUser);
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (OmniTicketClient c) => c.DeleteAsync(),
              "/omniplay/pii/session", piiUser: piiUser);
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (OmniTicketClient c) => c.DeleteAsync(), piiUser: piiUser);
        }

        #endregion

        #region GetAsync

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (OmniTicketClient c) => c.GetAsync(Guid.Parse(uniqeId)),
                new HttpResponseMessage(HttpStatusCode.OK) 
                {
                    Content = new MockedJsonContent(validAPIResponseForGetAndGetTicketAsync)
                }
                ,
                validAPIResponseForGetAndGetTicketAsync,piiUser:piiUser
                );
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (OmniTicketClient c) => c.GetAsync(Guid.Parse(uniqeId)),
                HttpMethod.Get,piiUser:piiUser 
                );
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (OmniTicketClient c) => c.GetAsync(Guid.Parse(uniqeId)),
              string.Format("/omniplay/wishlist/ticket?wishlistUniqueKey={0}",uniqeId),piiUser:piiUser);
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (OmniTicketClient c) => c.GetAsync(Guid.Parse(uniqeId)),piiUser:piiUser);
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (OmniTicketClient c) => c.GetAsync(Guid.Parse(uniqeId)),
              notFoundHttpResponseMessage,
              expectedExceptionResult,piiUser:piiUser
              );
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncForbiddenTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.Forbidden;

            await base.APIExceptionResponseTestAsync(
              (OmniTicketClient c) => c.GetAsync(Guid.Parse(uniqeId)),
              forbiddenHttpResponseMessage,
              expectedExceptionResult, piiUser: piiUser
              );
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (OmniTicketClient c) => c.GetAsync(Guid.Parse(uniqeId)),
              badRequestHttpResponseMessage,
              expectedExceptionResult, piiUser: piiUser
              );
        }

        #endregion

        #region PostSessionAsync
        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("PostSessionAsync"), TestCategory("HTTP.POST")]
        public async Task PostSessionAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (OmniTicketClient c) => c.PostSessionAsync(sampleTicket),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponseForPostSessionAsync)
                },
                validAPIResponseForPostSessionAsync, piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("PostSessionAsync"), TestCategory("HTTP.POST")]
        public async Task PostSessionAsyncRequestParseTest()
        {
            string validRequest = @"{
             'Ticket': '9ead1d3d-28c1-4dc4-b99e-3542401c9f77'
            }";
            await base.RequestParseTestAsync<OmniTicket>(
                (OmniTicketClient c) => c.PostSessionAsync(sampleTicket),
                validRequest
                , piiUser: piiUser);
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("PostSessionAsync"), TestCategory("HTTP.POST")]
        public async Task PostSessionAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (OmniTicketClient c) => c.PostSessionAsync(sampleTicket),
                HttpMethod.Post, piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("PostSessionAsync"), TestCategory("HTTP.POST")]
        public async Task PostSessionAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (OmniTicketClient p) => p.PostSessionAsync(sampleTicket),
              "/omniplay/pii/session", piiUser: piiUser);
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("PostSessionAsync"), TestCategory("HTTP.POST")]
        public async Task PostSessionAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (OmniTicketClient p) => p.PostSessionAsync(sampleTicket), piiUser: piiUser);
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("PostSessionAsync"), TestCategory("HTTP.POST")]
        public async Task PostSessionAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (OmniTicketClient p) => p.PostSessionAsync(sampleTicket),
              badRequestHttpResponseMessage,
              expectedExceptionResult, piiUser: piiUser);
        }
        #endregion

        #region PostImportAsync
        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("PostImportAsync"), TestCategory("HTTP.POST")]
        public async Task PostImportAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (OmniTicketClient c) => c.PostImportAsync(sampleWishlistImportRequest),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponseForPostImportAsync)
                },
                validAPIResponseForPostImportAsync, piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("PostImportAsync"), TestCategory("HTTP.POST")]
        public async Task PostImportAsyncRequestParseTest()
        {
            string validRequest = @"{
                'OmniTicket': '9ead1d3d-28c1-4dc4-b99e-3542401c9f77',
                'GpsLocation': {
                    'Longitude': 35.6885,
                    'Latitude': -67.44767
                }
            }";
            await base.RequestParseTestAsync<OmniTicket>(
                (OmniTicketClient c) => c.PostImportAsync(sampleWishlistImportRequest),
                validRequest,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("PostImportAsync"), TestCategory("HTTP.POST")]
        public async Task PostImportAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (OmniTicketClient c) => c.PostImportAsync(sampleWishlistImportRequest),
                HttpMethod.Post, piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("PostImportAsync"), TestCategory("HTTP.POST")]
        public async Task PostImportAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (OmniTicketClient p) => p.PostImportAsync(sampleWishlistImportRequest),
              "/pii/wishlist/import", piiUser: piiUser);
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("PostImportAsync"), TestCategory("HTTP.POST")]
        public async Task PostImportAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (OmniTicketClient p) => p.PostImportAsync(sampleWishlistImportRequest), piiUser: piiUser);
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("PostImportAsync"), TestCategory("HTTP.POST")]
        public async Task PostImportAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (OmniTicketClient p) => p.PostImportAsync(new WishlistImportRequest()
                {
                    OmniTicket = Guid.Parse(uniqeId),
                    GpsLocation = new Location()
                    {
                        Latitude = 112,
                        Longitude = 32
                    }
                }),
                new ArgumentOutOfRangeException("Latitude", 112, string.Format("{0} must be in range ({1} - {2}).", "Latitude", -90, 90))
                , piiUser: piiUser);

            await base.SDKExceptionResponseTestAsync(
                (OmniTicketClient p) => p.PostImportAsync(new WishlistImportRequest()
                {
                    OmniTicket = Guid.Parse(uniqeId),
                    GpsLocation = new Location()
                    {
                        Latitude = 23,
                        Longitude = -566
                    }
                }),
                  new ArgumentOutOfRangeException("Longitude", -566, string.Format("{0} must be in range ({1} - {2}).", "Longitude", -180, 180))
                , piiUser: piiUser);
        }

        [TestMethod, TestCategory("OmniTicketClient"), TestCategory("PostImportAsync"), TestCategory("HTTP.POST")]
        public async Task PostImportAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (OmniTicketClient p) => p.PostImportAsync(sampleWishlistImportRequest),
              badRequestHttpResponseMessage,
              expectedExceptionResult, piiUser: piiUser);
        }


        #endregion

    }
}
