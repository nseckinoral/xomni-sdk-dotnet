using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients.Company;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Company;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.Company
{
    [TestClass]
    public class StoreStorageClientFixture : BaseClientFixture<StoreStorageClient>
    {
        #region Arrange
        const string validAPIResponseForGetAsync = @"{  
           'Data':[  
              {  
                 'StoreId':'1',
                 'Key':'SampleKey',
                 'Value':'SampleValue',
                 'IsPublic':true,
                 'TimeStamp': ''
              },
              {  
                 'StoreId':'1',
                 'Key':'SampleKey1',
                 'Value':'SampleValue',
                 'IsPublic':true,
                 'TimeStamp': ''
              }
           ]
        }";

        const string validAPIResponseAndRequestForPostAsync = @"{  
           'Data':{  
              'StoreId':'1',
              'Key':'SampleKey11',
              'Value':'SampleValue',
              'IsPublic':true,
              'TimeStamp': null
           }
        }";

        const string validAPIResponseAndRequestForPutAsync = @"{  
           'Data':{                
              'StoreId':'1',
              'Key':'SampleKey11',
              'Value':'SampleValue',
              'IsPublic':true,
              'TimeStamp': ''
           }
        }";

        const string validAPIRequest = @"{  
           'StoreId':'1',
           'Key':'SampleKey',
           'Value':'SampleValue',
           'IsPublic':true
        }";

        readonly StoreStorageItem sampleStoreStorageItem = new StoreStorageItem()
        {
            StoreId = 1,
            Key = "SampleKey",
            Value = "SampleValue",
            IsPublic = true,
            TimeStamp = new byte[] { 1, 2, 3 }
        };

        #endregion

        #region GetAsync

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (StoreStorageClient c) => c.GetAsync(0, null)
            );
        }

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (StoreStorageClient c) => c.GetAsync(),
                HttpMethod.Get
            );
        }

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
               (StoreStorageClient p) => p.GetAsync(),
               string.Format("/company/stores/{0}/storage", "current"));

            await base.UriTestAsync(
               (StoreStorageClient p) => p.GetAsync(0),
               string.Format("/company/stores/{0}/storage", "current"));

            await base.UriTestAsync(
              (StoreStorageClient p) => p.GetAsync(1),
              string.Format("/company/stores/{0}/storage", "1"));

            await base.UriTestAsync(
                (StoreStorageClient p) => p.GetAsync(key: "key"),
               string.Format("/company/stores/{0}/storage?key={1}", "current", "key"));

            await base.UriTestAsync(
                (StoreStorageClient p) => p.GetAsync(0, key: "key"),
               string.Format("/company/stores/{0}/storage?key={1}", "current", "key"));

            await base.UriTestAsync(
                (StoreStorageClient p) => p.GetAsync(1, key: "key"),
               string.Format("/company/stores/{0}/storage?key={1}", "1", "key"));
        }

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (StoreStorageClient p) => p.GetAsync(-1, key: "key"),
              new ArgumentException("storeId must be greater than or equal to 0."));
        }

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (StoreStorageClient p) => p.GetAsync());
        }

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncGenericAPIErrorTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (StoreStorageClient p) => p.GetAsync(),
              notFoundHttpResponseMessage,
              expectedExceptionResult);
        }

        #endregion

        #region PostAsync
        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (StoreStorageClient c) => c.PostAsync(sampleStoreStorageItem)
            );
        }

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncRequestParseTest()
        {
            await base.RequestParseTestAsync<DeviceStorageItem>(
                (StoreStorageClient c) => c.PostAsync(sampleStoreStorageItem));
        }

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (StoreStorageClient c) => c.PostAsync(sampleStoreStorageItem),
                HttpMethod.Post
                );
        }

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (StoreStorageClient p) => p.PostAsync(sampleStoreStorageItem),
              string.Format("/company/stores/{0}/storage", sampleStoreStorageItem.StoreId));
        }

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncParameterTest()
        {
            sampleStoreStorageItem.StoreId = -1;
            await base.SDKExceptionResponseTestAsync(
              (StoreStorageClient p) => p.PostAsync(sampleStoreStorageItem),
              new ArgumentException("StoreId must be greater than or equal to 0."));

            await base.SDKExceptionResponseTestAsync(
              (StoreStorageClient p) => p.PostAsync(null),
              new ArgumentNullException("storageItem can not be null."));
        }

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (StoreStorageClient p) => p.PostAsync(sampleStoreStorageItem));
        }

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncGenericAPIErrorTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (StoreStorageClient p) => p.PostAsync(sampleStoreStorageItem),
              notFoundHttpResponseMessage,
              expectedExceptionResult);
        }

        #endregion

        #region PutAsync
        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("PutAsync"), TestCategory("HTTP.POST")]
        public async Task PutAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (StoreStorageClient c) => c.PutAsync(sampleStoreStorageItem)
            );
        }


        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PutAsyncRequestParseTest()
        {
            await base.RequestParseTestAsync<DeviceStorageItem>(
                (StoreStorageClient c) => c.PutAsync(sampleStoreStorageItem));
        }

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("PutAsync"), TestCategory("HTTP.POST")]
        public async Task PutAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (StoreStorageClient c) => c.PutAsync(sampleStoreStorageItem),
                HttpMethod.Put
                );
        }

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("PutAsync"), TestCategory("HTTP.POST")]
        public async Task PutAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (StoreStorageClient p) => p.PutAsync(sampleStoreStorageItem),
              string.Format("/company/stores/{0}/storage", sampleStoreStorageItem.StoreId));
        }

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("PutAsync"), TestCategory("HTTP.POST")]
        public async Task PutAsyncParameterTest()
        {
            sampleStoreStorageItem.StoreId = -1;
            await base.SDKExceptionResponseTestAsync(
              (StoreStorageClient p) => p.PutAsync(sampleStoreStorageItem),
              new ArgumentException("StoreId must be greater than or equal to 0."));

            sampleStoreStorageItem.StoreId = 1;
            sampleStoreStorageItem.TimeStamp = null;
            await base.SDKExceptionResponseTestAsync(
              (StoreStorageClient p) => p.PutAsync(sampleStoreStorageItem),
              new ArgumentNullException("TimeStamp can not be null."));

            await base.SDKExceptionResponseTestAsync(
              (StoreStorageClient p) => p.PutAsync(null),
              new ArgumentNullException("storageItem can not be null."));
        }

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("PutAsync"), TestCategory("HTTP.POST")]
        public async Task PutAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (StoreStorageClient p) => p.PutAsync(sampleStoreStorageItem));
        }

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("PutAsync"), TestCategory("HTTP.POST")]
        public async Task PutAsyncGenericAPIErrorTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (StoreStorageClient p) => p.PutAsync(sampleStoreStorageItem),
              notFoundHttpResponseMessage,
              expectedExceptionResult);
        }

        #endregion

        #region DeleteAsync

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (StoreStorageClient c) => c.DeleteAsync(),
                HttpMethod.Delete
                );
        }

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncUriCheckTest()
        {
            await base.UriTestAsync(
                (StoreStorageClient p) => p.DeleteAsync(key: "key"),
              string.Format("/company/stores/{0}/storage?key={1}", "current", "key"));

            await base.UriTestAsync(
                (StoreStorageClient p) => p.DeleteAsync(),
                string.Format("/company/stores/{0}/storage", "current"));


            await base.UriTestAsync(
                (StoreStorageClient p) => p.DeleteAsync(1),
                string.Format("/company/stores/{0}/storage", "1"));

        }

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (StoreStorageClient p) => p.DeleteAsync(-1),
              new ArgumentException("storeId must be greater than or equal to 0."));
        }

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (StoreStorageClient p) => p.DeleteAsync());
        }

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncGenericAPIErrorTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (StoreStorageClient p) => p.DeleteAsync(),
              notFoundHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("StoreStorageClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncForbiddenTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.Forbidden;

            await base.APIExceptionResponseTestAsync(
              (StoreStorageClient p) => p.DeleteAsync(),
              forbiddenHttpResponseMessage,
              expectedExceptionResult);
        }
        #endregion
    }
}
