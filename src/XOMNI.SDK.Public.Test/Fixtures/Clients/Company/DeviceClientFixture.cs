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
    public class DeviceClientFixture : BaseClientFixture<DeviceClient>
    {
        #region ArrangeForGetAsyncByLocation

        const string validAPIResponseForGetByLocationAsync = @"{
           'Data':[
              {
                 'DeviceTypeId':1,
                 'DeviceTypeDescription':'InStore',
                 'ExpirationDate':null,
                 'DeviceId':'18b808c3-d3ef-4fc3-a3c6-c773d3fd2b8f',
                 'Description':'Test Device 1',
                 'Metadata':[
                    {
                       'Key':'Sample metadata key 1',
                       'Value':'Sample metadata value 3'
                    },
                    {
                       'Key':'Sample metadata key 2',
                       'Value':'Sample metadata value 2'
                    },
                    {
                       'Key':'Sample metadata key 3',
                       'Value':'Sample metadata value 3'
                    }
                 ]
              },
              {
                 'DeviceTypeId':1,
                 'DeviceTypeDescription':'InStore',
                 'ExpirationDate':null,
                 'DeviceId':'ed4c7d90-1f7d-46fe-8db1-76812e26aa94',
                 'Description':'Test Device 2',
                 'Metadata':[
                    {
                       'Key':'Sample metadata key 1',
                       'Value':'Sample metadata value 3'
                    },
                    {
                       'Key':'Sample metadata key 2',
                       'Value':'Sample metadata value 2'
                    },
                    {
                       'Key':'Sample metadata key 3',
                       'Value':'Sample metadata value 3'
                    }
                 ]
              },
              {
                 'DeviceTypeId':1,
                 'DeviceTypeDescription':'InStore',
                 'ExpirationDate':'2014-08-08T12:56:46.217',
                 'DeviceId':'7f83fd6f-0ff8-4a21-b6df-e6da6562b500',
                 'Description':'Test Device 3',
                 'Metadata':[
                    {
                       'Key':'Sample metadata key 1',
                       'Value':'Sample metadata value 3'
                    },
                    {
                       'Key':'Sample metadata key 2',
                       'Value':'Sample metadata value 2'
                    },
                    {
                       'Key':'Sample metadata key 3',
                       'Value':'Sample metadata value 3'
                    }
                 ]
              }
           ]
        }";
        #endregion

        #region ArrangeForGetAsyncByLicense

        const string validAPIResponseGetByLicenseAsync = @"{
           'Data':[
              {
                 'DeviceTypeId':1,
                 'DeviceTypeDescription':'InStore',
                 'ExpirationDate':null,
                 'DeviceId':'18b808c3-d3ef-4fc3-a3c6-c773d3fd2b8f',
                 'Description':'Test Device 1',
                 'Metadata':[
                    {
                       'Key':'Sample metadata key 1',
                       'Value':'Sample metadata value 3'
                    },
                    {
                       'Key':'Sample metadata key 2',
                       'Value':'Sample metadata value 2'
                    },
                    {
                       'Key':'Sample metadata key 3',
                       'Value':'Sample metadata value 3'
                    }
                 ]
              },
              {
                 'DeviceTypeId':1,
                 'DeviceTypeDescription':'InStore',
                 'ExpirationDate':null,
                 'DeviceId':'ed4c7d90-1f7d-46fe-8db1-76812e26aa94',
                 'Description':'Test Device 2',
                 'Metadata':[
                    {
                       'Key':'Sample metadata key 1',
                       'Value':'Sample metadata value 3'
                    },
                    {
                       'Key':'Sample metadata key 2',
                       'Value':'Sample metadata value 2'
                    },
                    {
                       'Key':'Sample metadata key 3',
                       'Value':'Sample metadata value 3'
                    }
                 ]
              },
              {
                 'DeviceTypeId':1,
                 'DeviceTypeDescription':'InStore',
                 'ExpirationDate':'2014-08-08T12:56:46.217',
                 'DeviceId':'7f83fd6f-0ff8-4a21-b6df-e6da6562b500',
                 'Description':'Test Device 3',
                 'Metadata':[
                    {
                       'Key':'Sample metadata key 1',
                       'Value':'Sample metadata value 3'
                    },
                    {
                       'Key':'Sample metadata key 2',
                       'Value':'Sample metadata value 2'
                    },
                    {
                       'Key':'Sample metadata key 3',
                       'Value':'Sample metadata value 3'
                    }
                 ]
              }
           ]
        }";

        #endregion

        #region ArrangeForPostAsync

        const string validAPIResponsePostAsync = @"{
           'Data':{
              'DeviceId':'e4ded600-5faa-46fa-b7d9-7dde44725dfa',
              'Description':'Test Device',
              'DeviceTypeId':1,
              'DeviceTypeDescription':'Kiosk',
              'ExpirationDate':'2014-11-19T15:17:17.2730996+02:00',
              'Metadata':[
              ]
           }
        }";

        #endregion

        #region ArrangeForPatchAsync

        const string validAPIRequestPatchAsync = @"{
                    'Description': 'description',
	        }";
        const string validAPIResponsePatchAsync = @"{
	        'Data': {
                    'DeviceId': 1121,
                    'DeviceTypeId': 21,
                    'DeviceTypeDescription': 'device type description',
                    'Description': 'sample description',
                    'ExpirationDate': '2012-02-18T00:54:06.8447642Z'
	        }
        }";

        readonly Device sampleDevice = new Device()
        {
            DeviceId = uniqueId,
            Description = "sampleDescription",
            DeviceTypeId = 1,
            ExpirationDate = DateTime.Parse("2014-11-19T15:14:57.2212844+02:00")
        };

        readonly Location sampleLocation = new Location()
        {
            Latitude = 28.970034,
            Longitude = 41.038473
        };

        const string validAPIRequest = @"{
          'DeviceId': '597edb28-7244-4fd7-a298-5be276de4f65',
          'Description': 'Test Device',
          'DeviceTypeId': 1,
          'ExpirationDate': '2014-11-19T15:14:57.2212844+02:00'
        }";

        #endregion

        #region DeleteAsync

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (DeviceClient c) => c.DeleteAsync("0"),
                HttpMethod.Delete
                );
        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncUriCheckTest()
        {
            await base.UriTestAsync(
                (DeviceClient c) => c.DeleteAsync("0"),
                string.Format("/company/devices/{0}", "0"));
        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (DeviceClient c) => c.DeleteAsync(""),
              new ArgumentException("deviceId can not be empty or null."));

            await base.SDKExceptionResponseTestAsync(
              (DeviceClient c) => c.DeleteAsync(null),
              new ArgumentException("deviceId can not be empty or null."));

        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (DeviceClient c) => c.DeleteAsync("0"));
        }
        #endregion

        #region GetAsync By Location

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetByLocationAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (DeviceClient c) => c.GetAsync(1, sampleLocation, 1, "test", "test", false)
            );
        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetByLocationAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (DeviceClient c) => c.GetAsync(1, sampleLocation, 1, "test", "test", false),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetByLocationAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (DeviceClient c) => c.GetAsync(1, sampleLocation),
               string.Format("/company/stores/{0}/Devices?searchDistance={1}&includeMetadata={2}", sampleLocation.GetFormattedLocation(), 1, false));

            await base.UriTestAsync(
              (DeviceClient c) => c.GetAsync(1, sampleLocation, deviceTypeId: 1),
               string.Format("/company/stores/{0}/Devices?searchDistance={1}&deviceTypeId={2}&includeMetadata={3}", sampleLocation.GetFormattedLocation(), 1, 1, false));

            await base.UriTestAsync(
              (DeviceClient c) => c.GetAsync(1, sampleLocation, deviceTypeId: 1, metadataKey: "key", metadataValue: "value"),
               string.Format("/company/stores/{0}/Devices?searchDistance={1}&deviceTypeId={2}&metadataKey={3}&metadataValue={4}&includeMetadata={5}", sampleLocation.GetFormattedLocation(), 1, 1, "key", "value", false));

            await base.UriTestAsync(
              (DeviceClient c) => c.GetAsync(1, sampleLocation, deviceTypeId: 1, metadataKey: "key", metadataValue: "value", includeMetadata: true),
               string.Format("/company/stores/{0}/Devices?searchDistance={1}&deviceTypeId={2}&metadataKey={3}&metadataValue={4}&includeMetadata={5}", sampleLocation.GetFormattedLocation(), 1, 1, "key", "value", true));
        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetByLocationAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (DeviceClient c) => c.GetAsync(1, sampleLocation, 1, "test", "test", false),
              notFoundHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetByLocationAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (DeviceClient c) => c.GetAsync(-3, sampleLocation),
              new ArgumentOutOfRangeException("searchDistance", -3, string.Format("{0} must be in range ({1} - {2}).", "searchDistance", 0, 1)));

            await base.SDKExceptionResponseTestAsync(
              (DeviceClient c) => c.GetAsync(1, sampleLocation, deviceTypeId: -3),
              new ArgumentException(string.Format("{0} must be greater than or equal to 1.", "deviceTypeId")));

            await base.SDKExceptionResponseTestAsync(
              (DeviceClient c) => c.GetAsync(1, sampleLocation, metadataKey: "key"),
              new ArgumentException(string.Format("{0} can not be empty or null.", "metadataValue")));

            await base.SDKExceptionResponseTestAsync(
              (DeviceClient c) => c.GetAsync(1, sampleLocation, metadataValue: "value"),
              new ArgumentException(string.Format("{0} can not be empty or null.", "metadataKey")));

            await base.SDKExceptionResponseTestAsync(
              (DeviceClient c) => c.GetAsync(1, null, metadataKey: "key", metadataValue: "value"),
              new ArgumentNullException(string.Format("{0} can not be null.", "gpsLocation")));

        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetByLocationAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (DeviceClient c) => c.GetAsync(1, sampleLocation, 1, "test", "test", false),
              badRequestHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetByLocationAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
              (DeviceClient c) => c.GetAsync(1, sampleLocation, 1, "test", "test", false));
        }
        #endregion

        #region GetAsync By License

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetByLicenseAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (DeviceClient c) => c.GetAsync(1, "test", "test", false)
            );
        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetByLicenseAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (DeviceClient c) => c.GetAsync(1, "test", "test", false),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetByLicenseAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (DeviceClient c) => c.GetAsync(),
              string.Format("/company/stores/devices?includeMetadata={1}", 1, false));

            await base.UriTestAsync(
              (DeviceClient c) => c.GetAsync(deviceTypeId: 1),
              string.Format("/company/stores/devices?deviceTypeId={1}&includeMetadata={2}", 1, 1, false));

            await base.UriTestAsync(
              (DeviceClient c) => c.GetAsync(deviceTypeId: 1, metadataKey: "key", metadataValue: "value"),
              string.Format("/company/stores/devices?deviceTypeId={1}&metadataKey={2}&metadataValue={3}&includeMetadata={4}", 1, 1, "key", "value", false));

            await base.UriTestAsync(
              (DeviceClient c) => c.GetAsync(deviceTypeId: 1, metadataKey: "key", metadataValue: "value", includeMetadata: true),
              string.Format("/company/stores/devices?deviceTypeId={1}&metadataKey={2}&metadataValue={3}&includeMetadata={4}", 1, 1, "key", "value", true));
        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetByLicenseAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (DeviceClient c) => c.GetAsync(deviceTypeId: -3),
              new ArgumentException(string.Format("{0} must be greater than or equal to 1.", "deviceTypeId")));

            await base.SDKExceptionResponseTestAsync(
              (DeviceClient c) => c.GetAsync(metadataKey: "key"),
              new ArgumentException(string.Format("{0} can not be empty or null.", "metadataValue")));

            await base.SDKExceptionResponseTestAsync(
              (DeviceClient c) => c.GetAsync(metadataValue: "value"),
              new ArgumentException(string.Format("{0} can not be empty or null.", "metadataKey")));
        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetByLicenseAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (DeviceClient p) => p.GetAsync(1, "test", "test", false),
              notFoundHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetByLicenseAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (DeviceClient p) => p.GetAsync(1, "test", "test", false));
        }

        #endregion

        #region PostAsync

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (DeviceClient p) => p.PostAsync(sampleDevice)
            );
        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (DeviceClient p) => p.PostAsync(sampleDevice),
                HttpMethod.Post
                );
        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (DeviceClient p) => p.PostAsync(sampleDevice),
              string.Format("/company/devices"));
        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (DeviceClient p) => p.PostAsync(null),
              new ArgumentNullException(string.Format("{0} can not be null.", "device")));

            await base.SDKExceptionResponseTestAsync(
              (DeviceClient p) => p.PostAsync(new Device()),
              new ArgumentException(string.Format("{0} can not be empty or null.", "deviceId")));

            await base.SDKExceptionResponseTestAsync(
              (DeviceClient p) => p.PostAsync(new Device() { DeviceId = Guid.NewGuid().ToString() }),
              new ArgumentException(string.Format("{0} can not be empty or null.", "description")));

            await base.SDKExceptionResponseTestAsync(
              (DeviceClient p) => p.PostAsync(new Device() { DeviceId = Guid.NewGuid().ToString(), Description = Guid.NewGuid().ToString(), DeviceTypeId = 0 }),
              new ArgumentException(string.Format("{0} must be greater than or equal to 1.", "deviceTypeId")));
        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (DeviceClient p) => p.PostAsync(sampleDevice));
        }

        #endregion

        #region PatchAsync

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("PatchAsync"), TestCategory("HTTP.PATCH")]
        public async Task PatchAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (DeviceClient c) => c.PatchAsync("1", sampleDevice)
            );
        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("PatchAsync"), TestCategory("HTTP.PATCH")]
        public async Task PatchAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (DeviceClient c) => c.PatchAsync("1", sampleDevice),
                new HttpMethod("PATCH")
                );
        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("PatchAsync"), TestCategory("HTTP.PATCH")]
        public async Task PatchAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (DeviceClient c) => c.PatchAsync("1", sampleDevice),
              string.Format("/company/devices/{0}", "1"));
        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("PatchAsync"), TestCategory("HTTP.PATCH")]
        public async Task PatchAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (DeviceClient c) => c.PatchAsync("1", sampleDevice),
              notFoundHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("PatchAsync"), TestCategory("HTTP.PATCH")]
        public async Task PatchAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (DeviceClient c) => c.PatchAsync("", sampleDevice),
              new ArgumentException(string.Format("{0} can not be empty or null.", "deviceId")));

            await base.SDKExceptionResponseTestAsync(
              (DeviceClient c) => c.PatchAsync(null, sampleDevice),
              new ArgumentException(string.Format("{0} can not be empty or null.", "deviceId")));

            await base.SDKExceptionResponseTestAsync(
              (DeviceClient c) => c.PatchAsync("1", null),
              new ArgumentNullException(string.Format("{0} can not be null.", "particularDeviceInfo")));

            await base.SDKExceptionResponseTestAsync(
              (DeviceClient c) => c.PatchAsync("1", new { param = "param" }),
              new ArgumentException("'param' parameter(s) invalid for device patch."));

            await base.SDKExceptionResponseTestAsync(
              (DeviceClient c) => c.PatchAsync("1", null),
              new ArgumentNullException("particularDeviceInfo can not be null."));

            await base.SDKExceptionResponseTestAsync(
              (DeviceClient c) => c.PatchAsync("1", new { }),
              new ArgumentException("Device patch must be containt at least a property."));
        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("PatchAsync"), TestCategory("HTTP.PATCH")]
        public async Task PatchAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (DeviceClient c) => c.PatchAsync("1", sampleDevice));
        }

        [TestMethod, TestCategory("Company.DeviceClient"), TestCategory("PatchAsync"), TestCategory("HTTP.PATCH")]
        public async Task PatchAsyncRequestParseTest()
        {
            await base.RequestParseTestAsync<Device>(
                (DeviceClient c) => c.PatchAsync("1", new { Description = "description" })
            );
        }

        #endregion

    }
}