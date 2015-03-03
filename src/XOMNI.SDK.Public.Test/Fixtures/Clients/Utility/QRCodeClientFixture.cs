using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients.Utility;
using XOMNI.SDK.Public.Models.Utility;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.Utility
{
    [TestClass]

    public class QRCodeClientFixture : BaseClientFixture<QRCodeClient>
    {
        [TestMethod, TestCategory("QRCodeClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            var validAPIResponse = new byte[] { 1, 2, 3 };
            var validAPIContent = new ByteArrayContent(validAPIResponse);
            validAPIContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");

            HttpResponseMessage validHttpResponseMessage = new HttpResponseMessage()
            {
                Content = validAPIContent,
                StatusCode = HttpStatusCode.OK
            };

            await base.ResponseParseTestAsync(
                (QRCodeClient c) => c.GetAsync(20, "test"),
                validHttpResponseMessage,
                validAPIResponse
            );
        }

        [TestMethod, TestCategory("QRCodeClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (QRCodeClient c) => c.GetAsync(20, "test"),
                HttpMethod.Get
                );
        }

        [TestMethod, TestCategory("QRCodeClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (QRCodeClient c) => c.GetAsync(20, "test", ErrorCorrectionLevel.High),
              string.Format("/utils/qrcode?data=test&moduleSize=20&errorCorrectionLevel=High")
            );

            await base.UriTestAsync(
              (QRCodeClient c) => c.GetAsync(20, "test"),
              string.Format("/utils/qrcode?data=test&moduleSize=20&errorCorrectionLevel=Quartile")
            );
        }

        [TestMethod, TestCategory("QRCodeClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncSDKExceptionTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (QRCodeClient c) => c.GetAsync(0, "test"),
                new ArgumentException("moduleSize must be greater than or equal to 1.")
            );

            await base.SDKExceptionResponseTestAsync(
               (QRCodeClient c) => c.GetAsync(1, null),
               new ArgumentException("data can not be empty or null.")
           );
        }

        [TestMethod, TestCategory("QRCodeClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (QRCodeClient c) => c.GetAsync(20, "test")
            );
        }
    }
}
