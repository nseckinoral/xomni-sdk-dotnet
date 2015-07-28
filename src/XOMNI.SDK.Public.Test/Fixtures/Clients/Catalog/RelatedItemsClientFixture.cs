using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients.Catalog;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.Catalog
{
    [TestClass]
    public class RelatedItemsClientFixture : BaseClientFixture<RelatedItemsClient>
    {
        #region GetAsync
   
        [TestMethod, TestCategory("RelatedItemsClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (RelatedItemsClient c) => c.GetAsync(1)
            );
        }

        [TestMethod, TestCategory("RelatedItemsClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (RelatedItemsClient c) => c.GetAsync(1),
                HttpMethod.Get
                );
        }

        [TestMethod, TestCategory("RelatedItemsClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (RelatedItemsClient p) => p.GetAsync(1),
              string.Format("/catalog/relatedItems?itemId={0}", 1));
        }

        [TestMethod, TestCategory("RelatedItemsClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (RelatedItemsClient c) => c.GetAsync(1),
              badRequestHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("RelatedItemsClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (RelatedItemsClient c) => c.GetAsync(1),
              notFoundHttpResponseMessage,
              expectedExceptionResult
            );
        }

        [TestMethod, TestCategory("RelatedItemsClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (RelatedItemsClient p) => p.GetAsync(-1),
              new ArgumentException(string.Format("itemId must be greater than or equal to 1.")));
        }

        #endregion
    }
}
