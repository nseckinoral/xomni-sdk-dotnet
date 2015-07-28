using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                  'Metadata': [
                    {
                      'Key': 'inv_instock',
                      'Value': 'true'
                    },
                    {
                      'Key': 'inv_stockvalue',
                      'Value': '10'
                    }
                  ],
                  'Id': 1,
                  'Description': 'New York Store',
                  'Location': {
                    'Longitude': 10.0,
                    'Latitude': 10.0
                  },
                  'Name': 'New York Store',
                  'Address': '5th avenue'
                },
                {
                  'Metadata': [
                    {
                      'Key': 'inv_instock',
                      'Value': 'false'
                    },
                    {
                      'Key': 'inv_stockvalue',
                      'Value': '0'
                    }
                  ],
                  'Id': 2,
                  'Description': 'Seattle Store',
                  'Location': {
                    'Longitude': 5.0,
                    'Latitude': 5.0
                  },
                  'Name': 'Seattle Store',
                  'Address': 'Redmond'
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
                (ItemInStoreMetadataClient l) => l.GetAsync(1, null, null, null, false,null, null)
            );
        }

        [TestMethod, TestCategory("ItemInStoreMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1),
                HttpMethod.Get
            );
        }

        [TestMethod, TestCategory("ItemInStoreMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (ItemInStoreMetadataClient c) => c.GetAsync(1),
              string.Format("/catalog/items/{0}/storemetadata?companyWide={1}", 1, false));

            await base.UriTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1, key: "key", value: "value"),
              string.Format("/catalog/items/{0}/storemetadata?companyWide={1}&key={2}&value={3}", 1, false, "key", "value"));

            await base.UriTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1, keyPrefix: "key", companyWide: true),
              string.Format("/catalog/items/{0}/storemetadata?companyWide={1}&keyPrefix={2}", 1, true, "key"));

            var location = new Location()
            {
                Longitude = 10,
                Latitude = 20
            };

            await base.UriTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1, keyPrefix: "key", companyWide: true, location: location, searchDistance: 5),
              string.Format(CultureInfo.InvariantCulture.NumberFormat, "/catalog/items/{0}/storemetadata?companyWide={1}&longitude={2}&latitude={3}&searchDistance={4}&keyPrefix={5}", 1, true, location.Longitude, location.Latitude, 5, "key"));
        }

        [TestMethod, TestCategory("ItemInStoreMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncOptionalParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1, key: "key"),
                new ArgumentException("value can not be empty or null.")
                );

            await base.SDKExceptionResponseTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1, value: "value"),
                new ArgumentException("key can not be empty or null.")
                );

            await base.SDKExceptionResponseTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1, key: "key", value: "value", keyPrefix: "keyPrefix"),
                new ArgumentException("Key and keyPrefix parameters cannot be sent at the same time in a metadata query.")
                );

            await base.SDKExceptionResponseTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1, keyPrefix: "keyPrefix", companyWide: true, location: new Location()),
                new ArgumentException("searchDistance can not be null.")
                );

            var location = new Location();
            location.Longitude = 200;
            await base.SDKExceptionResponseTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1, keyPrefix: "keyPrefix", companyWide: true, location: location),
               new ArgumentOutOfRangeException("Location.longitude", 200, string.Format("{0} must be in range ({1} - {2}).", "Location.longitude", -180, 180))
                );

            location.Longitude = 150;
            location.Latitude = 150;
            await base.SDKExceptionResponseTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1, keyPrefix: "keyPrefix", companyWide: true, location: location),
               new ArgumentOutOfRangeException("Location.latitude", 150, string.Format("{0} must be in range ({1} - {2}).", "Location.latitude", -90, 90))
                );

        }

        [TestMethod, TestCategory("ItemInStoreMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (ItemInStoreMetadataClient c) => c.GetAsync(1),
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
                (ItemInStoreMetadataClient c) => c.GetAsync(1),
                badRequestHttpResponseMessage,
                expectedExceptionResult);
        }

        [TestMethod, TestCategory("ItemInStoreMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncSDKExceptionTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(0),
                new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", "id", 1)));
        }

        [TestMethod, TestCategory("ItemInStoreMetadataClient"), TestCategory("GetImageMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (ItemInStoreMetadataClient c) => c.GetAsync(1));
        }
    }
}
