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
    public class CommentClientFixture : BaseClientFixture<CommentClient>
    {

        #region arrange

        const string validSocialCommentRequest = @"{
                'TargetCommentId':5,
                'Content':'This is an another sample comment.'
        }";

        const string validSocialPostRequest = @"{
            'TargetPostId':'5',
            'Content':'This is a sample comment'
        }";

        const string validAPIResponseForPostAndDeleteAsync = @"{
            'Data':{
                'TargetPostId':16,
                'TargetCommentId':5,
                'Id':15,
                'CreatedDate':'2013-08-14T14:40:01.3508349+03:00',
                'Content':'This is an another sample comment.',
                'RelatedItemId':5,
                'AvailablePlatforms':[
                   {
                       'Platform':'Facebook',
                       'Status':'Succeed',
                       'Author':'Test User',
                       'AuthorPictureUrl':'http://graph.facebook.com/100005333233573/picture'
                   }
                ]
            }
        }";

        const string validAPIResponseForGetPoliciesAsync = @"{
          'Data': {
            'MaxContentLength': 112,
            'ShortenedUrlLength': 23,
            'RepliedToTwitterAlias': 'xomni_cloud'
          }
        }";

        readonly HttpResponseMessage validHttpResponseMessageForPostAndDeleteAsync = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK,
            Content = new MockedJsonContent(validAPIResponseForPostAndDeleteAsync)
        };

        readonly SocialCommentToCommentRequest sampleCommentToCommentRequest = new SocialCommentToCommentRequest()
        {
            Content = "This is an another sample comment.",
            TargetCommentId = 5
        };

        readonly SocialCommentToPostRequest sampleCommentToPostRequest = new SocialCommentToPostRequest()
        {
            Content = "This is a sample comment",
            TargetPostId = 5
        };

        #endregion

        #region PostAsync - CommentToComment
        [TestMethod, TestCategory("CommentClient"), TestCategory("PostRequestCommentToCommentAsync"), TestCategory("HTTP.POST")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (CommentClient c) => c.PostCommentAsync(sampleCommentToCommentRequest),
                    validHttpResponseMessageForPostAndDeleteAsync,
                    validAPIResponseForPostAndDeleteAsync,
                    piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("PostRequestCommentToCommentAsync"), TestCategory("HTTP.POST")]
        public async Task PostRequestCommentToCommentAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (CommentClient c) => c.PostCommentAsync(sampleCommentToCommentRequest),
                HttpMethod.Post,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("PostRequestCommentToCommentAsync"), TestCategory("HTTP.POST")]
        public async Task PostRequestCommentToCommentAsyncSerializeTest()
        {
            await base.RequestParseTestAsync<SocialCommentToCommentRequest>(
                (CommentClient c) => c.PostCommentAsync(sampleCommentToCommentRequest),
                validSocialCommentRequest,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("PostRequestCommentToCommentAsync"), TestCategory("HTTP.POST")]
        public async Task PostRequestCommentToCommentAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (CommentClient c) => c.PostCommentAsync(sampleCommentToCommentRequest),
              "/social/comment",
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("PostRequestCommentToCommentAsync"), TestCategory("HTTP.POST")]
        public async Task PostRequestCommentToCommentAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (CommentClient c) => c.PostCommentAsync(sampleCommentToCommentRequest),
              notFoundHttpResponseMessage,
              expectedExceptionResult,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("PostRequestCommentToCommentAsync"), TestCategory("HTTP.POST")]
        public async Task PostRequestCommentToCommentAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (CommentClient c) => c.PostCommentAsync(sampleCommentToCommentRequest),
              badRequestHttpResponseMessage,
              expectedExceptionResult,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("PostRequestCommentAsync"), TestCategory("HTTP.POST")]
        public async Task PostRequestCommentToCommentAsyncSDKExceptionTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (CommentClient c) => c.PostCommentAsync(sampleCommentToCommentRequest),
                new ArgumentException("User/OmniSession")
            );
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("PostRequestCommentToCommentAsync"), TestCategory("HTTP.POST")]
        public async Task PostRequestCommentToCommentAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (CommentClient c) => c.PostCommentAsync(sampleCommentToCommentRequest),
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("PostRequestCommentToCommentAsync"), TestCategory("HTTP.POST")]
        public async Task PostRequestCommentToCommentAsyncTargetCommentIdValidTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (CommentClient c) => c.PostCommentAsync(new SocialCommentToCommentRequest()
                {
                    TargetCommentId = -1,
                    Content = "TestContent"
                }),
                new ArgumentException("TargetCommentId must be greater than or equal to 1."),
                piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("PostRequestCommentToCommentAsync"), TestCategory("HTTP.POST")]
        public async Task PostRequestCommentToCommentAsyncContentNullTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (CommentClient c) => c.PostCommentAsync(new SocialCommentToCommentRequest()
                {
                    TargetCommentId = 1,
                    Content = null
                }),
                new ArgumentException("Content can not be empty or null."),
                piiUser: piiUser
            );
        }
        #endregion

        #region PostAsync - CommentToPost
        [TestMethod, TestCategory("CommentClient"), TestCategory("PostRequestCommentToPostAsync"), TestCategory("HTTP.POST")]
        public async Task PostRequestCommentToPostAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (CommentClient c) => c.PostCommentAsync(sampleCommentToPostRequest),
                    validHttpResponseMessageForPostAndDeleteAsync,
                    validAPIResponseForPostAndDeleteAsync,
                    piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("PostRequestCommentToPostAsync"), TestCategory("HTTP.POST")]
        public async Task PostRequestCommentToPostAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (CommentClient c) => c.PostCommentAsync(sampleCommentToPostRequest),
                HttpMethod.Post,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("PostRequestCommentToPostAsync"), TestCategory("HTTP.POST")]
        public async Task PostRequestCommentToPostAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (CommentClient c) => c.PostCommentAsync(sampleCommentToPostRequest),
              "/social/comment",
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("PostRequestCommentToPostAsync"), TestCategory("HTTP.POST")]
        public async Task PostRequestCommentToPostAsyncSerializeTest()
        {
            await base.RequestParseTestAsync<SocialCommentToCommentRequest>(
                (CommentClient c) => c.PostCommentAsync(sampleCommentToPostRequest),
                validSocialPostRequest,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("PostRequestCommentToPostAsync"), TestCategory("HTTP.POST")]
        public async Task PostRequestCommentToPostAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (CommentClient c) => c.PostCommentAsync(sampleCommentToPostRequest),
              notFoundHttpResponseMessage,
              expectedExceptionResult,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("PostRequestCommentToPostAsync"), TestCategory("HTTP.POST")]
        public async Task PostRequestCommentToPostAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (CommentClient c) => c.PostCommentAsync(sampleCommentToPostRequest),
              badRequestHttpResponseMessage,
              expectedExceptionResult,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("PostRequestCommentToPostAsync"), TestCategory("HTTP.POST")]
        public async Task PostRequestCommentToPostAsyncSDKExceptionTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (CommentClient c) => c.PostCommentAsync(sampleCommentToPostRequest),
                new ArgumentException("User/OmniSession")
            );
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("PostRequestCommentToPostAsync"), TestCategory("HTTP.POST")]
        public async Task PostRequestCommentToPostAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (CommentClient c) => c.PostCommentAsync(sampleCommentToPostRequest),
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("PostRequestCommentToPostAsync"), TestCategory("HTTP.POST")]
        public async Task PostRequestCommentToPostAsyncTargetPostIdValidTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (CommentClient c) => c.PostCommentAsync(new SocialCommentToPostRequest()
                {
                    TargetPostId = -1,
                    Content = "Test"
                }),
                new ArgumentException("TargetPostId must be greater than or equal to 1."),
                piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("PostRequestCommentToPostAsync"), TestCategory("HTTP.POST")]
        public async Task PostRequestCommentToPostAsyncContentNullTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (CommentClient c) => c.PostCommentAsync(new SocialCommentToPostRequest()
                {
                    TargetPostId = 1,
                    Content = null
                }),
                new ArgumentException("Content can not be empty or null."),
                piiUser: piiUser
            );
        }
        #endregion

        #region GetPoliciesAsync

        [TestMethod, TestCategory("CommentClient"), TestCategory("GetPoliciesAsync"), TestCategory("HTTP.GET")]
        public async Task GetPoliciesAsyncResponseParseTest()
        {        
            await base.ResponseParseTestAsync(
                (CommentClient c) => c.GetPoliciesAsync(targetPostId: 1),
                    new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new MockedJsonContent(validAPIResponseForGetPoliciesAsync)
                    },
                    validAPIResponseForGetPoliciesAsync,
                    piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("GetPoliciesAsync"), TestCategory("HTTP.GET")]
        public async Task GetPoliciesAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (CommentClient c) => c.GetPoliciesAsync(targetPostId: 1),
                HttpMethod.Get,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("GetPoliciesAsync"), TestCategory("HTTP.GET")]
        public async Task GetPoliciesAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (CommentClient c) => c.GetPoliciesAsync(targetPostId: 1),
              "/social/comment/policies?targetPostId=1",
                piiUser: piiUser);

            await base.UriTestAsync(
                (CommentClient c) => c.GetPoliciesAsync(targetCommentId: 1),
                "/social/comment/policies?targetCommentId=1",
                piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("GetPoliciesAsync"), TestCategory("HTTP.GET")]
        public async Task GetPoliciesAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (CommentClient c) => c.GetPoliciesAsync(targetPostId: 1),
              notFoundHttpResponseMessage,
              expectedExceptionResult,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("GetPoliciesAsync"), TestCategory("HTTP.GET")]
        public async Task GetPoliciesAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
                (CommentClient c) => c.GetPoliciesAsync(targetCommentId: 1),
              badRequestHttpResponseMessage,
              expectedExceptionResult,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("GetPoliciesAsync"), TestCategory("HTTP.GET")]
        public async Task GetPoliciesAsyncSDKExceptionTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (CommentClient c) => c.GetPoliciesAsync(targetPostId: 1),
                new ArgumentException("User/OmniSession")
            );
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("GetPoliciesAsync"), TestCategory("HTTP.GET")]
        public async Task GetPoliciesAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (CommentClient c) => c.GetPoliciesAsync(targetPostId: 1),
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("GetPoliciesAsync"), TestCategory("HTTP.GET")]
        public async Task GetPoliciesAsyncTargetPostIdTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (CommentClient c) => c.GetPoliciesAsync(targetPostId: -1),
                new ArgumentException("targetPostId must be greater than or equal to 1."),
                piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("GetPoliciesAsync"), TestCategory("HTTP.GET")]
        public async Task GetPoliciesAsyncTargetCommentIdTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (CommentClient c) => c.GetPoliciesAsync(targetCommentId: -2),
                new ArgumentException("targetCommentId must be greater than or equal to 1."),
                piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("GetPoliciesAsync"), TestCategory("HTTP.GET")]
        public async Task GetPoliciesAsyncOptionalParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (CommentClient c) => c.GetPoliciesAsync(targetPostId:1,targetCommentId: 2),
                new ArgumentException("You can not pass targetPostId and targetCommentId at the same time."),
                piiUser: piiUser
            );
        }

        #endregion

        #region DeleteAsync

        [TestMethod, TestCategory("CommentClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (CommentClient c) => c.DeleteAsync(1),
                    validHttpResponseMessageForPostAndDeleteAsync,
                    validAPIResponseForPostAndDeleteAsync,
                    piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (CommentClient c) => c.DeleteAsync(1),
                HttpMethod.Delete,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (CommentClient c) => c.DeleteAsync(1),
              "/social/comment/1",
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (CommentClient c) => c.DeleteAsync(1),
              notFoundHttpResponseMessage,
              expectedExceptionResult,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncSDKExceptionTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (CommentClient c) => c.DeleteAsync(1),
                new ArgumentException("User/OmniSession")
            );
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (CommentClient c) => c.DeleteAsync(1),
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("CommentClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncCommentIdValidTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (CommentClient c) => c.DeleteAsync(-1),
                new ArgumentException("commentId must be greater than or equal to 1."),
                piiUser: piiUser
            );
        }

        #endregion

    }
}
