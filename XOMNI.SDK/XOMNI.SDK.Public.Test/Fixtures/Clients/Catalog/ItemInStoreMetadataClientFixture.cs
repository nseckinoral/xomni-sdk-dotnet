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

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.Catalog
{
    [TestClass]
    public class ItemInStoreMetadataClientFixture : BaseMetadataClientFixture<ItemInStoreMetadataClient>
    {
        [TestMethod, TestCategory("ItemInStoreMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.MetadataResponseParseTestAsync(
                (ItemInStoreMetadataClient l) => l.GetAsync(1, "Test", "Test", 1, 1),
                validHttpResponseMessage,
                validAPIResponse
            );
        }

        [TestMethod, TestCategory("ItemInStoreMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1, "Test", "Test", 1, 1),
                HttpMethod.Get
            );
        }

        [TestMethod, TestCategory("ItemInStoreMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (ItemInStoreMetadataClient c) => c.GetAsync(1, "Test", "Test", 1, 1),
              string.Format("/catalog/items/{0}/storemetadata?key={1}&value={2}&skip={3}&take={4}", 1, "Test", "Test", 1, 1));
        }

        [TestMethod, TestCategory("ItemInStoreMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (ItemInStoreMetadataClient c) => c.GetAsync(1, "Test", "Test", 1, 1),
              notFoundHttpResponseMessage,
              expectedExceptionResult
              );
        }

        [TestMethod, TestCategory("ItemInStoreMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1, "Test", "Test", 1, 1),
                badRequestHttpResponseMessage,
                expectedExceptionResult);
        }

        [TestMethod, TestCategory("ItemInStoreMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncSDKExceptionTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(-1, "Test", "Test", 1, 1),
                new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", "id", 1)));

            await base.SDKExceptionResponseTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1, "Test", "Test", -1, 1),
                new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", "skip", 0)));

            await base.SDKExceptionResponseTestAsync(
               (ItemInStoreMetadataClient c) => c.GetAsync(1, "Test", "Test", 1, 0),
               new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", "take", 1)));
        }

        [TestMethod, TestCategory("ItemInStoreMetadataClient"), TestCategory("GetImageMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1, "Test", "Test", 1, 1));
        }
    }
}
