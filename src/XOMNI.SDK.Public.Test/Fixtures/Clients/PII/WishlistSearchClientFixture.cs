using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients.PII;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.PII;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.PII
{
    [TestClass]
    public class WishlistSearchClientFixture : BaseClientFixture<WishlistSearchClient>
    {
        const string validAPIResponseForPostAsync = @"{
            'Data': [
                'fe6dc962-b646-48f0-8fcc-0b9d98ea9664',
                '771f4923-b0db-42c6-9728-a630def1841e',
                '8009c2c0-1627-40e9-9a3f-18ecfb330d3a'
            ]
        } ";

        const string validAPIRequest = @"{
            'Location':{
                'Longitude':41.034973,
                'Latitude':28.992459
            },
           'TimeInterval':20,
           'MaxDistance':1.0
        }";

        readonly WishlistSearchRequest sampleWishlistSearchRequest = new WishlistSearchRequest()
        {
            Location = new Location()
            {
                Longitude = 41.034973,
                Latitude = 28.992459,

            },
            TimeInterval = 20,
            MaxDistance = 1.0
        };

        readonly Location invalidLatitudeLocation = new Location()
        {
            Latitude = 98,
            Longitude = 28.992459
        };

        readonly Location invalidLongitudeLocation = new Location()
        {
            Latitude = 41.034973,
            Longitude = -256
        };

        #region PostAsync
        [TestMethod, TestCategory("WishlistSearchClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (WishlistSearchClient p) => p.PostAsync(sampleWishlistSearchRequest),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponseForPostAsync)
                },
                validAPIResponseForPostAsync
            );
        }

        [TestMethod, TestCategory("WishlistSearchClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncRequestParseTest()
        {
            await base.RequestParseTestAsync<ShoppingCartSearchRequest>(
                (WishlistSearchClient p) => p.PostAsync(sampleWishlistSearchRequest));
        }

        [TestMethod, TestCategory("WishlistSearchClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (WishlistSearchClient p) => p.PostAsync(sampleWishlistSearchRequest),
                HttpMethod.Post
                );
        }

        [TestMethod, TestCategory("WishlistSearchClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (WishlistSearchClient p) => p.PostAsync(sampleWishlistSearchRequest),
              string.Format("/pii/wishlistsearch"));
        }

        [TestMethod, TestCategory("WishlistSearchClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (WishlistSearchClient c) => c.PostAsync(null),
              new ArgumentNullException("searchRequest can not be null."));

            await base.SDKExceptionResponseTestAsync(
                (WishlistSearchClient p) => p.PostAsync(new WishlistSearchRequest()
                {
                    Location = invalidLatitudeLocation
                }),

            new ArgumentOutOfRangeException("Latitude", 98, string.Format("{0} must be in range ({1} - {2}).", "Latitude", -90, 90))
            );

            await base.SDKExceptionResponseTestAsync(
               (WishlistSearchClient p) => p.PostAsync(new WishlistSearchRequest()
               {
                   Location = invalidLongitudeLocation
               }),

            new ArgumentOutOfRangeException("Longitude", -256, string.Format("{0} must be in range ({1} - {2}).", "Longitude", -180, 180))
            );

            await base.SDKExceptionResponseTestAsync(
               (WishlistSearchClient p) => p.PostAsync(new WishlistSearchRequest()
               {
                   Location = new Location()
                   {
                       Latitude = 41.034973,
                       Longitude = 28.992459,

                   },
                   TimeInterval = -12,
                   MaxDistance = 1.0
               }),

            new ArgumentOutOfRangeException("TimeInterval", -12, string.Format("{0} must be in range ({1} - {2}).", "TimeInterval", 0, 30))
            );

            await base.SDKExceptionResponseTestAsync(
               (WishlistSearchClient p) => p.PostAsync(new WishlistSearchRequest()
               {
                   Location = new Location()
                   {
                       Latitude = 41.034973,
                       Longitude = 28.992459,

                   },
                   TimeInterval = 20,
                   MaxDistance = 5
               }),

            new ArgumentOutOfRangeException("MaxDistance", 5, string.Format("{0} must be in range ({1} - {2}).", "MaxDistance", 0, 1))
            );
        }

        [TestMethod, TestCategory("WishlistSearchClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (WishlistSearchClient p) => p.PostAsync(sampleWishlistSearchRequest));
        }

        #endregion
    }
}
