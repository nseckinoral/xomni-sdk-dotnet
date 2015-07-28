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
    public class TokenClientFixture : BaseClientFixture<TokenClient>
    {
        const string validAPIResponseForGetAsync = @"{  
           'Data':{  
              'oauth_token':'15882569-PzAP1SWdkK8bltXreVsgr9EeYr1bJjl50jGlNnOFo',
              'oauth_token_secret':'YAo0ENafYSMAi3z3PHhqW9M48PSdAV3xY2Yd91I2MNmOo'
           }
        }";

        const string validAPIResponseForPostAsync = @"{  
           'Data':{  
'access_token':'CAAGVVMuW7ZBIBAJFMFs2e2tYlhK9HiaUbFhzYHUA2nn2O1MHBfFZC7MbZAM2zN621HCEZAoZBjfmeizVLgaAH4o59VNFwsXUkeZAFqomKzQZA0JCWavUuJ5epv447HT9dPwa0bKNe31WHKCA4zAHKrNMjK99H9izAFIxxflgehWyjdysI3HNzvI8ApL6KkUX5IZD'
           }
        }";

        #region GetAsync

        [TestMethod, TestCategory("TokenClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (TokenClient t) => t.GetAsync(SocialPlatformType.Facebook),
                piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("TokenClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (TokenClient t) => t.GetAsync(SocialPlatformType.Facebook),
                HttpMethod.Get,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("TokenClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (TokenClient t) => t.GetAsync(SocialPlatformType.Facebook),
              "/social/token/facebook",
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("TokenClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (TokenClient t) => t.GetAsync(SocialPlatformType.Facebook),
              notFoundHttpResponseMessage,
              expectedExceptionResult,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("TokenClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncSDKExceptionTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (TokenClient t) => t.GetAsync(SocialPlatformType.Facebook),
                new ArgumentException("User/OmniSession")
            );
        }

        [TestMethod, TestCategory("TokenClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (TokenClient t) => t.GetAsync(SocialPlatformType.Facebook),
                piiUser: piiUser);
        }

        #endregion

        #region PostAsync
        [TestMethod, TestCategory("TokenClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (TokenClient p) => p.PostAsync(SocialPlatformType.Facebook, "token", null, null),
                    piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("TokenClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (TokenClient p) => p.PostAsync(SocialPlatformType.Facebook, "token"),
                HttpMethod.Post,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("TokenClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (TokenClient p) => p.PostAsync(SocialPlatformType.Facebook, "token"),
              "/social/token/facebook",
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("TokenClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (TokenClient p) => p.PostAsync(SocialPlatformType.Facebook, "token"),
              notFoundHttpResponseMessage,
              expectedExceptionResult,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("TokenClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (TokenClient p) => p.PostAsync(SocialPlatformType.Facebook, "token"),
              badRequestHttpResponseMessage,
              expectedExceptionResult,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("TokenClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncNotImplementedTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotImplemented;

            await base.APIExceptionResponseTestAsync(
              (TokenClient p) => p.PostAsync(SocialPlatformType.Facebook, "token"),
              notImplementedHttpResponseMessage,
              expectedExceptionResult,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("TokenClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (TokenClient p) => p.PostAsync(SocialPlatformType.Facebook, "token"),
                piiUser: piiUser);
        }


        [TestMethod, TestCategory("TokenClient"), TestCategory("PostRequestCommentToPostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncSDKExceptionTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (TokenClient p) => p.PostAsync(SocialPlatformType.Facebook, token: "token"),
              new ArgumentException("User/OmniSession")
            );

            await base.SDKExceptionResponseTestAsync(
                (TokenClient p) => p.PostAsync(SocialPlatformType.Facebook, token: ""),
                new ArgumentException("token can not be empty or null."),
                piiUser: piiUser
            );

            await base.SDKExceptionResponseTestAsync(
                (TokenClient p) => p.PostAsync(SocialPlatformType.Facebook),
               new ArgumentException("token can not be empty or null."),
               piiUser: piiUser
           );

            await base.SDKExceptionResponseTestAsync(
                (TokenClient p) => p.PostAsync(SocialPlatformType.Facebook, token: "token", oauthToken: "oauthToken"),
                 new ArgumentException("You can not pass token and oauthToken/oauthVerifier at the same time."),
                 piiUser: piiUser
             );

            await base.SDKExceptionResponseTestAsync(
               (TokenClient p) => p.PostAsync(SocialPlatformType.Twitter),
               new ArgumentException("oauthToken can not be empty or null."),
               piiUser: piiUser
           );

            await base.SDKExceptionResponseTestAsync(
                (TokenClient p) => p.PostAsync(SocialPlatformType.Twitter, oauthToken: ""),
                   new ArgumentException("oauthToken can not be empty or null."),
                   piiUser: piiUser
               );

            await base.SDKExceptionResponseTestAsync(
                (TokenClient p) => p.PostAsync(SocialPlatformType.Twitter, oauthToken: "oauthToken"),
                 new ArgumentException("oauthVerifier can not be empty or null."),
                 piiUser: piiUser
            );

            await base.SDKExceptionResponseTestAsync(
                (TokenClient p) => p.PostAsync(SocialPlatformType.Twitter, token: "token", oauthToken: "oauthToken", oauthVerifier: "oauthVerifier"),
                 new ArgumentException("You can not pass oauthToken/oauthVerifier and token at the same time."),
                 piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("TokenClient"), TestCategory("PostRequestCommentToPostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncTokenEmptyTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (TokenClient p) => p.PostAsync(SocialPlatformType.Facebook, ""),
                new ArgumentException("token can not be empty or null."),
                piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("TokenClient"), TestCategory("PostRequestCommentToPostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncRequestParseTest()
        {
            string sampleFacebookRequest = @"{'access_token':'token'}";

            string sampleTwitterRequest = @"{'oauth_token' : 'oauthToken','oauth_verifier':'oauthVerifier'}";

            await base.RequestParseTestAsync<Dictionary<string, string>>(
                (TokenClient t) => t.PostAsync(SocialPlatformType.Facebook, "token", null, null),
                 piiUser: piiUser
             );

            await base.RequestParseTestAsync<Dictionary<string, string>>(
                (TokenClient t) => t.PostAsync(SocialPlatformType.Twitter, null, "oauthToken", "oauthVerifier"),
                piiUser: piiUser
            );
        }
        #endregion
    }
}
