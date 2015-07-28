using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients.Social;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.Social
{
    [TestClass]
    public class ProfileClientFixture : BaseClientFixture<ProfileClient>
    {
        #region GetAsync

        [TestMethod, TestCategory("ProfileClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetPoliciesAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (ProfileClient c) => c.GetAsync(),
                piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("ProfileClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (ProfileClient c) => c.GetAsync(),
                HttpMethod.Get,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("ProfileClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (ProfileClient c) => c.GetAsync(),
              "/social/profiles",
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("ProfileClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (ProfileClient c) => c.GetAsync(),
              notFoundHttpResponseMessage,
              expectedExceptionResult,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("ProfileClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncSDKExceptionTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (ProfileClient c) => c.GetAsync(),
                new ArgumentException("User/OmniSession")
            );
        }

        [TestMethod, TestCategory("ProfileClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (ProfileClient c) => c.GetAsync(),
                piiUser: piiUser);
        }

        #endregion
    }
}
