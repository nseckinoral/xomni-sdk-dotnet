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
    public class ShoppingCartPassbookClientFixture : BaseClientFixture<ShoppingCartPassbookClient>
    {
        const string validAPIResponse = @"{
            'Data': 'AQID'
        }";

        #region GetAsync

        [TestMethod, TestCategory("ShoppingCartPassbookClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (ShoppingCartPassbookClient c) => c.GetAsync(Guid.NewGuid(), "test"),
                piiUser:piiUser);
        }

        [TestMethod, TestCategory("ShoppingCartPassbookClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (ShoppingCartPassbookClient c) => c.GetAsync(Guid.NewGuid(), "test"),
                HttpMethod.Get,
                piiUser : piiUser);
        }

        [TestMethod, TestCategory("ShoppingCartPassbookClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            var sampleShoppingCartUniqueKey = Guid.NewGuid();
            await base.UriTestAsync(
              (ShoppingCartPassbookClient c) => c.GetAsync(sampleShoppingCartUniqueKey, "test"),
              string.Format("/pii/shoppingcart/{0}/passbook?templateName={1}", sampleShoppingCartUniqueKey, "test"),
              piiUser : piiUser);
        }

        [TestMethod, TestCategory("ShoppingCartPassbookClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (ShoppingCartPassbookClient c) => c.GetAsync(Guid.NewGuid(), "test"),
              notFoundHttpResponseMessage,
              expectedExceptionResult,
              piiUser : piiUser);
        }

        [TestMethod, TestCategory("ShoppingCartPassbookClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncForbiddenTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.Forbidden;

            await base.APIExceptionResponseTestAsync(
              (ShoppingCartPassbookClient c) => c.GetAsync(Guid.NewGuid(), "test"),
              forbiddenHttpResponseMessage,
              expectedExceptionResult,
              piiUser : piiUser);
        }

        [TestMethod, TestCategory("ShoppingCartPassbookClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncParameterTest()
        {
            var sampleShoppingCartUniqueKey = Guid.NewGuid();

            await base.SDKExceptionResponseTestAsync(
              (ShoppingCartPassbookClient c) => c.GetAsync(sampleShoppingCartUniqueKey, null),
              new ArgumentException("templateName can not be empty or null."),
              piiUser : piiUser);
        }
        #endregion
    }
}
