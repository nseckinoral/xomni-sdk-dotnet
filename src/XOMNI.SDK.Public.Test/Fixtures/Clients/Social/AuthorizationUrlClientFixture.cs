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
using XOMNI.SDK.Public.Models.Social;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.Social
{
    [TestClass]
    public class AuthorizationUrlClientFixture : BaseClientFixture<AuthorizationURLClient>
    {

        const string validAPIResponse = @"{  
           'Data':'https://www.facebook.com/dialog/oauth?display=popup&client_id=219137448225465&redirect_uri=http://test.apistaging.xomni.com&scope=user_about_me,publish_stream,read_stream&response_type=token'
        }";

        #region GetAsync

        [TestMethod, TestCategory("AuthorizationURLClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetPoliciesAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (AuthorizationURLClient c) => c.GetAsync(SocialPlatformType.Facebook),
                piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("AuthorizationURLClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (AuthorizationURLClient c) => c.GetAsync(SocialPlatformType.Facebook),
                HttpMethod.Get,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("AuthorizationURLClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (AuthorizationURLClient c) => c.GetAsync(SocialPlatformType.Facebook),
              "/social/authurl/facebook",
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("AuthorizationURLClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (AuthorizationURLClient c) => c.GetAsync(SocialPlatformType.Facebook),
              notFoundHttpResponseMessage,
              expectedExceptionResult,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("AuthorizationURLClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsynNotImplementedTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotImplemented;

            await base.APIExceptionResponseTestAsync(
              (AuthorizationURLClient c) => c.GetAsync(SocialPlatformType.Facebook),
              notImplementedHttpResponseMessage,
              expectedExceptionResult,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("AuthorizationURLClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncSDKExceptionTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (AuthorizationURLClient c) => c.GetAsync(SocialPlatformType.Facebook),
                new ArgumentException("User/OmniSession")
            );
        }

        [TestMethod, TestCategory("AuthorizationURLClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (AuthorizationURLClient c) => c.GetAsync(SocialPlatformType.Facebook),
                piiUser: piiUser);
        }

        #endregion
    }
}
