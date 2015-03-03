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
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.PII
{
    [TestClass]
    public class WishlistPassbookClientFixture : BaseClientFixture<WishlistPassbookClient>
    {
        const string validAPIResponse = @"{
            'Data': 'AQID'
        }";

    #region GetAsync

        [TestMethod, TestCategory("WishlistPassbookClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            var samplewishlistUniqueKey = Guid.NewGuid();

            await base.ResponseParseTestAsync(
                (WishlistPassbookClient c) => c.GetAsync(samplewishlistUniqueKey, "test"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponse)
                },
                validAPIResponse,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("WishlistPassbookClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            var samplewishlistUniqueKey = Guid.NewGuid();

            await base.HttpMethodTestAsync(
                (WishlistPassbookClient c) => c.GetAsync(samplewishlistUniqueKey, "test"),
                HttpMethod.Get,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("WishlistPassbookClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            var samplewishlistUniqueKey = Guid.NewGuid();

            await base.UriTestAsync(
              (WishlistPassbookClient c) => c.GetAsync(samplewishlistUniqueKey, "test"),
              string.Format("/pii/wishlist/{0}/passbook?templateName={1}", samplewishlistUniqueKey, "test"),
              piiUser: piiUser);
        }

        [TestMethod, TestCategory("WishlistPassbookClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            var samplewishlistUniqueKey = Guid.NewGuid();

            await base.APIExceptionResponseTestAsync(
              (WishlistPassbookClient c) => c.GetAsync(samplewishlistUniqueKey, "test"),
              notFoundHttpResponseMessage,
              expectedExceptionResult,
              piiUser: piiUser);
        }

        [TestMethod, TestCategory("WishlistPassbookClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            var samplewishlistUniqueKey = Guid.NewGuid();

            await base.APIExceptionResponseTestAsync(
              (WishlistPassbookClient c) => c.GetAsync(samplewishlistUniqueKey, "test"),
              badRequestHttpResponseMessage,
              expectedExceptionResult,
              piiUser : piiUser);
        }

        [TestMethod, TestCategory("WishlistPassbookClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncParameterTest()
        {
            var samplewishlistUniqueKey = Guid.NewGuid();

            await base.SDKExceptionResponseTestAsync(
              (WishlistPassbookClient c) => c.GetAsync(samplewishlistUniqueKey, null),
              new ArgumentException("templateName can not be empty or null."),
              piiUser: piiUser);
        }
    #endregion
    }
}
