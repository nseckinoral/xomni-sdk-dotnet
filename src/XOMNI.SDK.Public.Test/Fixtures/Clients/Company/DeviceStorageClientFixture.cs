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
    public class DeviceStorageClientFixture : BaseClientFixture<DeviceStorageClient>
    {

        #region Arrange
        const string validAPIResponseForGetAsync = @"{  
           'Data':[  
              {  
                 'DeviceId':'9ead1d3d-28c1-4dc4-b99e-3542401c9f77',
                 'Key':'SampleKey',
                 'Value':'SampleValue',
                 'IsPublic':true
              },
              {  
                 'DeviceId':'9ead1d3d-28c1-4dc4-b99e-3542401c9f77',
                 'Key':'SampleKey1',
                 'Value':'SampleValue',
                 'IsPublic':true
              }
           ]
        }";

        const string validAPIResponseAndRequestForPostAndPutAsync = @"{  
           'Data':{  
              'DeviceId':'9ead1d3d-28c1-4dc4-b99e-3542401c9f77',
              'Key':'SampleKey11',
              'Value':'SampleValue',
              'IsPublic':true
           }
        }";

        const string validAPIRequest = @"{  
           'DeviceId':'9ead1d3d-28c1-4dc4-b99e-3542401c9f77',
           'Key':'SampleKey',
           'Value':'SampleValue',
           'IsPublic':true
        }";

        readonly DeviceStorageItem sampleDeviceStorageItem = new DeviceStorageItem()
        {
            DeviceId = uniqueId,
            Key = "SampleKey",
            Value = "SampleValue",
            IsPublic = true
        };

        #endregion

        #region GetAsync

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (DeviceStorageClient c) => c.GetAsync("0", "key", false)
            );
        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (DeviceStorageClient c) => c.GetAsync("0", "key", false),
                HttpMethod.Get
                );
        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (DeviceStorageClient p) => p.GetAsync("0", "key", false),
              string.Format("/company/devices/{0}/storage?key={1}&delete={2}", "0", "key", false));

            await base.UriTestAsync(
                (DeviceStorageClient p) => p.GetAsync("0", delete: false),
                string.Format("/company/devices/{0}/storage?delete={1}", "0", false));

            await base.UriTestAsync(
              (DeviceStorageClient p) => p.GetAsync("0", delete: true),
              string.Format("/company/devices/{0}/storage?delete={1}", "0", true));

            await base.UriTestAsync(
               (DeviceStorageClient p) => p.GetAsync("0"),
               string.Format("/company/devices/{0}/storage?delete=False", "0"));
        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (DeviceStorageClient p) => p.GetAsync("", "key", false),
              new ArgumentException("deviceId can not be empty or null."));

            await base.SDKExceptionResponseTestAsync(
              (DeviceStorageClient p) => p.GetAsync(null, "key", false),
              new ArgumentException("deviceId can not be empty or null."));
        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (DeviceStorageClient p) => p.GetAsync("0", "key", false));
        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (DeviceStorageClient p) => p.GetAsync("0", "key", false),
              notFoundHttpResponseMessage,
              expectedExceptionResult);
        }

        #endregion

        #region PostAsync
        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (DeviceStorageClient c) => c.PostAsync(sampleDeviceStorageItem)
            );
        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncRequestParseTest()
        {
            await base.RequestParseTestAsync<DeviceStorageItem>(
                (DeviceStorageClient c) => c.PostAsync(sampleDeviceStorageItem), validAPIRequest);
        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (DeviceStorageClient c) => c.PostAsync(sampleDeviceStorageItem),
                HttpMethod.Post
                );
        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (DeviceStorageClient p) => p.PostAsync(sampleDeviceStorageItem),
              string.Format("/company/devices/{0}/storage", sampleDeviceStorageItem.DeviceId));
        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncParameterTest()
        {
            sampleDeviceStorageItem.DeviceId = String.Empty;
            await base.SDKExceptionResponseTestAsync(
              (DeviceStorageClient p) => p.PostAsync(sampleDeviceStorageItem),
              new ArgumentException("DeviceId can not be empty or null."));

            sampleDeviceStorageItem.DeviceId = null;
            await base.SDKExceptionResponseTestAsync(
              (DeviceStorageClient p) => p.PostAsync(sampleDeviceStorageItem),
              new ArgumentException("DeviceId can not be empty or null."));

            await base.SDKExceptionResponseTestAsync(
              (DeviceStorageClient p) => p.PostAsync(null),
              new ArgumentNullException("storageItem can not be null."));
        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (DeviceStorageClient p) => p.PostAsync(sampleDeviceStorageItem));
        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (DeviceStorageClient p) => p.PostAsync(sampleDeviceStorageItem),
              notFoundHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncConflictTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.Conflict;

            await base.APIExceptionResponseTestAsync(
              (DeviceStorageClient p) => p.PostAsync(sampleDeviceStorageItem),
              conflictHttpResponseMessage,
              expectedExceptionResult);
        }
        #endregion

        #region PutAsync
        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("PutAsync"), TestCategory("HTTP.POST")]
        public async Task PutAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync<ApiResponse<DeviceStorageItem>>(
                (DeviceStorageClient c) => c.PutAsync(sampleDeviceStorageItem),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponseAndRequestForPostAndPutAsync)
                },
                validAPIResponseAndRequestForPostAndPutAsync);
        }


        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PutAsyncRequestParseTest()
        {
            await base.RequestParseTestAsync<DeviceStorageItem>(
                (DeviceStorageClient c) => c.PutAsync(sampleDeviceStorageItem), validAPIRequest);
        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("PutAsync"), TestCategory("HTTP.POST")]
        public async Task PutAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (DeviceStorageClient c) => c.PutAsync(sampleDeviceStorageItem),
                HttpMethod.Put
                );
        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("PutAsync"), TestCategory("HTTP.POST")]
        public async Task PutAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (DeviceStorageClient p) => p.PutAsync(sampleDeviceStorageItem),
              string.Format("/company/devices/{0}/storage", sampleDeviceStorageItem.DeviceId));
        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("PutAsync"), TestCategory("HTTP.POST")]
        public async Task PutAsyncParameterTest()
        {
            sampleDeviceStorageItem.DeviceId = String.Empty;
            await base.SDKExceptionResponseTestAsync(
              (DeviceStorageClient p) => p.PutAsync(sampleDeviceStorageItem),
              new ArgumentException("DeviceId can not be empty or null."));

            sampleDeviceStorageItem.DeviceId = null;
            await base.SDKExceptionResponseTestAsync(
              (DeviceStorageClient p) => p.PutAsync(sampleDeviceStorageItem),
              new ArgumentException("DeviceId can not be empty or null."));

            await base.SDKExceptionResponseTestAsync(
              (DeviceStorageClient p) => p.PutAsync(null),
              new ArgumentNullException("storageItem can not be null."));
        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("PutAsync"), TestCategory("HTTP.POST")]
        public async Task PutAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (DeviceStorageClient p) => p.PutAsync(sampleDeviceStorageItem));
        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("PutAsync"), TestCategory("HTTP.POST")]
        public async Task PutAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (DeviceStorageClient p) => p.PutAsync(sampleDeviceStorageItem),
              notFoundHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("PutAsync"), TestCategory("HTTP.POST")]
        public async Task PutAsyncForbiddenTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.Forbidden;

            await base.APIExceptionResponseTestAsync(
              (DeviceStorageClient p) => p.PutAsync(sampleDeviceStorageItem),
              forbiddenHttpResponseMessage,
              expectedExceptionResult);
        }
        #endregion

        #region DeleteAsync

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (DeviceStorageClient c) => c.DeleteAsync("0", "key"),
                HttpMethod.Delete
                );
        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (DeviceStorageClient p) => p.DeleteAsync("0", "key"),
              string.Format("/company/devices/{0}/storage?key={1}", "0", "key"));

            await base.UriTestAsync(
                (DeviceStorageClient p) => p.DeleteAsync("0"),
                string.Format("/company/devices/{0}/storage", "0", false));

        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (DeviceStorageClient p) => p.DeleteAsync("", "key"),
              new ArgumentException("deviceId can not be empty or null."));

            await base.SDKExceptionResponseTestAsync(
              (DeviceStorageClient p) => p.DeleteAsync(null, "key"),
              new ArgumentException("deviceId can not be empty or null."));
        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (DeviceStorageClient p) => p.DeleteAsync("0", "key"));
        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (DeviceStorageClient p) => p.DeleteAsync("0", "key"),
              notFoundHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("DeviceStorageClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncForbiddenTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.Forbidden;

            await base.APIExceptionResponseTestAsync(
              (DeviceStorageClient p) => p.DeleteAsync("0"),
              forbiddenHttpResponseMessage,
              expectedExceptionResult);
        }
        #endregion
    }
}
