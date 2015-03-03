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
    public class ItemInStoreMetadataClientFixture : BaseClientFixture<ItemInStoreMetadataClient>
    {

        #region arrenge

        protected const string validAPIResponse = @"{
            'Data': [
                {
                    'Key': 'imagemetadatakey0',
                    'Value': 'imagemetadatavalue0',
                    'StoreId':1
                },
                {
                    'Key': 'imagemetadatakey1',
                    'Value': 'imagemetadatavalue1',
                    'StoreId':1
                }
            ]
        }";

        protected readonly HttpResponseMessage validHttpResponseMessage = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK,
            Content = new MockedJsonContent(validAPIResponse)
        };



        #endregion

        [TestMethod, TestCategory("ItemInStoreMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (ItemInStoreMetadataClient l) => l.GetAsync(1, 1, 1),
                validHttpResponseMessage,
                validAPIResponse
            );
        }

        [TestMethod, TestCategory("ItemInStoreMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1, 1, 1),
                HttpMethod.Get
            );
        }

        [TestMethod, TestCategory("ItemInStoreMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (ItemInStoreMetadataClient c) => c.GetAsync(1, 1, 1),
              string.Format("/catalog/items/{0}/storemetadata?skip={1}&take={2}&companyWide={3}", 1, 1, 1, false));

            await base.UriTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1, 1, 1, key: "key", value: "value"),
              string.Format("/catalog/items/{0}/storemetadata?key={1}&value={2}&skip={3}&take={4}&companyWide={5}", 1, "key", "value", 1, 1, false));

            await base.UriTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1, 1, 1, keyPrefix: "key", companyWide: true),
              string.Format("/catalog/items/{0}/storemetadata?keyPrefix={1}&skip={2}&take={3}&companyWide={4}", 1, "key", 1, 1, true));
        }

        [TestMethod, TestCategory("ItemInStoreMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncOptionalParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1, 1, 1, key: "key"),
                new ArgumentException("value can not be empty or null.")
                );

            await base.SDKExceptionResponseTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1, 1, 1, value: "value"),
                new ArgumentException("key can not be empty or null.")
                );

            await base.SDKExceptionResponseTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1, 1, 1, key: "key", value: "value", keyPrefix: "keyPrefix"),
                new ArgumentException("Key and keyPrefix parameters cannot be sent at the same time in a metadata query.")
                );
        }

        [TestMethod, TestCategory("ItemInStoreMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (ItemInStoreMetadataClient c) => c.GetAsync(1, 1, 1),
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
                (ItemInStoreMetadataClient c) => c.GetAsync(1, 1, 1),
                badRequestHttpResponseMessage,
                expectedExceptionResult);
        }

        [TestMethod, TestCategory("ItemInStoreMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncSDKExceptionTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(0, 1, 1),
                new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", "id", 1)));

            await base.SDKExceptionResponseTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1, -1, 1),
                new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", "skip", 0)));

            await base.SDKExceptionResponseTestAsync(
               (ItemInStoreMetadataClient c) => c.GetAsync(1, 1, 0),
               new ArgumentOutOfRangeException("take", 0, string.Format("{0} must be in range ({1} - {2}).", "take", 1, 1000)));
        }

        [TestMethod, TestCategory("ItemInStoreMetadataClient"), TestCategory("GetImageMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1, 1, 1));
        }
    }
}
