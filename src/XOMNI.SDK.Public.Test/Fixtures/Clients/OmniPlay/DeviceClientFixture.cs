using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients.OmniPlay;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.OmniPlay
{
    [TestClass]
    public class DeviceClientFixture : BaseClientFixture<DeviceClient>
    {
        const string validAPIResponse = @"{
	        'Data': [{
		        'OmniTicket': 'Pbda570b0-cf86-4c86-830c-ac9445faf208',
		        'PIIDisplayName': 'Gokhan Gulbiz',
		
	        },
	        {
		        'OmniTicket': 'Pbda570b0-cf86-4c86-830c-ac9445faf208',
		        'PIIDisplayName': 'Gokhan Gulbiz',
		
	        }]
        }";

        #region GetIncomingsAsync

        [TestMethod, TestCategory("OmniPlay.DeviceClient"), TestCategory("GetIncomingsAsync"), TestCategory("HTTP.GET")]
        public async Task GetIncomingsAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (DeviceClient c) => c.GetIncomingsAsync("1"),
                new HttpResponseMessage(HttpStatusCode.OK) 
                { 
                    Content = new MockedJsonContent(validAPIResponse)
                },
                validAPIResponse
            );
        }

        [TestMethod, TestCategory("OmniPlay.DeviceClient"), TestCategory("GetIncomingsAsync"), TestCategory("HTTP.GET")]
        public async Task GetIncomingsAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (DeviceClient c) => c.GetIncomingsAsync("1"),
                HttpMethod.Get
                );
        }

        [TestMethod, TestCategory("OmniPlay.DeviceClient"), TestCategory("GetIncomingsAsync"), TestCategory("HTTP.GET")]
        public async Task GetIncomingsAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (DeviceClient c) => c.GetIncomingsAsync("1"),
              notFoundHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("OmniPlay.DeviceClient"), TestCategory("GetIncomingsAsync"), TestCategory("HTTP.GET")]
        public async Task GetIncomingsAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (DeviceClient c) => c.GetIncomingsAsync("1"),
              string.Format("/omniplay/devices/{0}/incoming", "1"));
        }

        [TestMethod, TestCategory("OmniPlay.DeviceClient"), TestCategory("GetIncomingsAsync"), TestCategory("HTTP.GET")]
        public async Task GetIncomingsAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (DeviceClient c) => c.GetIncomingsAsync(""),
              new ArgumentException(string.Format("{0} can not be empty or null.", "deviceId")));

            await base.SDKExceptionResponseTestAsync(
              (DeviceClient c) => c.GetIncomingsAsync(null),
              new ArgumentException(string.Format("{0} can not be empty or null.", "deviceId")));
        }

        [TestMethod, TestCategory("OmniPlay.DeviceClient"), TestCategory("GetIncomingsAsync"), TestCategory("HTTP.GET")]
        public async Task GetIncomingsAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (DeviceClient c) => c.GetIncomingsAsync("1"));
        }
        #endregion

        #region SubscribeToDevice

        [TestMethod, TestCategory("OmniPlay.DeviceClient"), TestCategory("GetIncomingsAsync"), TestCategory("HTTP.GET")]
        public async Task SubscribeToDeviceNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (DeviceClient c) => c.SubscribeToDevice("1"),
              notFoundHttpResponseMessage,
              expectedExceptionResult,piiUser:piiUser);
        }

        [TestMethod, TestCategory("OmniPlay.DeviceClient"), TestCategory("SubscribeToDevice"), TestCategory("HTTP.POST")]
        public async Task SubscribeToDeviceHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (DeviceClient c) => c.SubscribeToDevice("1"),
                HttpMethod.Post, piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("OmniPlay.DeviceClient"), TestCategory("SubscribeToDevice"), TestCategory("HTTP.POST")]
        public async Task SubscribeToDeviceUriCheckTest()
        {
            await base.UriTestAsync(
              (DeviceClient c) => c.SubscribeToDevice("1"),
              string.Format("/omniplay/devices/{0}", "1"), piiUser: piiUser);
        }

        [TestMethod, TestCategory("OmniPlay.DeviceClient"), TestCategory("SubscribeToDevice"), TestCategory("HTTP.POST")]
        public async Task SubscribeToDeviceParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (DeviceClient c) => c.SubscribeToDevice(""),
              new ArgumentException(string.Format("{0} can not be empty or null.", "deviceId")), piiUser: piiUser);

            await base.SDKExceptionResponseTestAsync(
              (DeviceClient c) => c.SubscribeToDevice(null),
              new ArgumentException(string.Format("{0} can not be empty or null.", "deviceId")), piiUser: piiUser);
        }

        [TestMethod, TestCategory("OmniPlay.DeviceClient"), TestCategory("SubscribeToDevice"), TestCategory("HTTP.POST")]
        public async Task SubscribeToDeviceDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (DeviceClient c) => c.SubscribeToDevice("1"), piiUser: piiUser);
        }
        #endregion
    }
}
