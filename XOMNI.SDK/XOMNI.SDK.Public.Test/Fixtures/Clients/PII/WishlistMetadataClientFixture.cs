using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients.PII;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.OmniPlay;
using XOMNI.SDK.Public.Models.PII;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.PII
{
    [TestClass]
    public class WishlistMetadataClientFixture : BaseMetadataClientFixture<WishlistMetadataClient>
    {
        readonly User piiUser = new User
        {
            UserName = "testPiiUser",
            Password = "testPiiPassword"
        };

        readonly OmniSession omniSession = new OmniSession
        {
            SessionGuid = Guid.NewGuid()
        };


        [TestMethod, TestCategory("WishlistMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.MetadataResponseParseTestAsync(
                (WishlistMetadataClient c) => c.GetAsync(Guid.NewGuid()),
                validHttpResponseMessage,
                validAPIResponse
            );
        }

        [TestMethod, TestCategory("WishlistMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (WishlistMetadataClient c) => c.GetAsync(Guid.NewGuid()),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("WishlistMetadataClient"), TestCategory("GetImageMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            var sampleWishlistGuid = Guid.NewGuid();
            await base.UriTestAsync(
              (WishlistMetadataClient c) => c.GetAsync(sampleWishlistGuid),
              string.Format("/pii/wishlistmetadata?wishlistUniqueKey={0}", sampleWishlistGuid));
        }

        [TestMethod, TestCategory("WishlistMetadataClient"), TestCategory("GetImageMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (WishlistMetadataClient c) => c.GetAsync(Guid.NewGuid()),
              notFoundHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("WishlistMetadataClient"), TestCategory("GetImageMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncSDKExceptionTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (WishlistMetadataClient c) => c.GetAsync(Guid.Empty),
                new ArgumentOutOfRangeException("wishlistUniqueKey")
            );
        }

        [TestMethod, TestCategory("WishlistMetadataClient"), TestCategory("GetImageMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (WishlistMetadataClient c) => c.GetAsync(Guid.NewGuid())
            );
        }
    }
}
