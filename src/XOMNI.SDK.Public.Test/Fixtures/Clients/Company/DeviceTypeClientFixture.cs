using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients.Company;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.Company
{
    [TestClass]
    public class DeviceTypeClientFixture : BaseClientFixture<DeviceTypesClient>
    {
        protected const string validAPIResponse = @"{
             'Data':{
              'Results':[
                 {
                    'Id':1,
                    'Description':'InStore'
                 },
                 {
                    'Id':2,
                    'Description':'Consumer'
                 }
              ],
              'TotalCount':2
           }
        }";

        protected readonly HttpResponseMessage validHttpResponseMessage = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK,
            Content = new MockedJsonContent(validAPIResponse)
        };

        [TestMethod, TestCategory("DeviceTypesClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (DeviceTypesClient c) => c.GetAsync(1, 1)
            );
        }

        [TestMethod, TestCategory("DeviceTypesClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (DeviceTypesClient c) => c.GetAsync(1, 1),
                HttpMethod.Get
                );
        }

        [TestMethod, TestCategory("DeviceTypesClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (DeviceTypesClient p) => p.GetAsync(1, 1),
              string.Format("/company/devicetypes?skip={0}&take={1}", 1, 1));
        }

        [TestMethod, TestCategory("DeviceTypesClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (DeviceTypesClient p) => p.GetAsync(-1, 1),
              new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", "skip", 0)));

            await base.SDKExceptionResponseTestAsync(
              (DeviceTypesClient p) => p.GetAsync(1, 0),
              new ArgumentOutOfRangeException("take", 0, string.Format("{0} must be in range ({1} - {2}).", "take", 1, 1000)));
        }

        [TestMethod, TestCategory("DeviceTypesClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (DeviceTypesClient p) => p.GetAsync(1, 1));
        }

    }
}
