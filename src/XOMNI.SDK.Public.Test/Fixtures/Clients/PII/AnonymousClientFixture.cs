using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients.PII;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.PII;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.PII
{
    [TestClass]
    public class AnonymousClientFixture : BaseClientFixture<AnonymousClient>
    {
        const string validAPIResponse = @"{
            'Data': {
                'UserName': 'ba07168f-1c41-4299-81e8-52a72718798d',
                'Password': 'dd5cb105-68f9-401b-9dfb-4ff85aa112ef',
                'Name': null,
                'PIIUserType': 'Anonymous'
            }
        }";

        const string validRequestJson = @"{
            'UserName':'ba07168f-1c41-4299-81e8-52a72718798d',
            'Name':null
        }";

        readonly AnonymousUserRequest anonymousUserRequest = new AnonymousUserRequest()
        {
            Name = null,
            UserName = "ba07168f-1c41-4299-81e8-52a72718798d"
        };

        #region PostAsync

        [TestMethod, TestCategory("AnonymousClient"), TestCategory("PostAsync"), TestCategory("HTTP.GET")]
        public async Task PostAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (AnonymousClient c) => c.PostAsync(anonymousUserRequest)
            );
        }

        [TestMethod, TestCategory("AnonymousClient"), TestCategory("PostAsync"), TestCategory("HTTP.GET")]
        public async Task PostAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (AnonymousClient c) => c.PostAsync(anonymousUserRequest),
                HttpMethod.Post);
        }

        [TestMethod, TestCategory("AnonymousClient"), TestCategory("PostAsync"), TestCategory("HTTP.GET")]
        public async Task PostAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (AnonymousClient c) => c.PostAsync(anonymousUserRequest),
              "/pii/anonymous");
        }

        [TestMethod, TestCategory("AnonymousClient"), TestCategory("PostAsync"), TestCategory("HTTP.GET")]
        public async Task PostAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (AnonymousClient c) => c.PostAsync(anonymousUserRequest),
              badRequestHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("AnonymousClient"), TestCategory("PostAsync"), TestCategory("HTTP.GET")]
        public async Task PostAsyncConflictTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.Conflict;

            await base.APIExceptionResponseTestAsync(
              (AnonymousClient c) => c.PostAsync(anonymousUserRequest),
              conflictHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("AnonymousClient"), TestCategory("PostAsync"), TestCategory("HTTP.GET")]
        public async Task PostAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (AnonymousClient c) => c.PostAsync(anonymousUserRequest));
        }

        [TestMethod, TestCategory("AnonymousClient"), TestCategory("PostAsync"), TestCategory("HTTP.GET")]
        public async Task PostAsyncRequestBodyTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (AnonymousClient c) => c.PostAsync(anonymousUserRequest));
        }

        [TestMethod, TestCategory("AnonymousClient"), TestCategory("PostAsync"), TestCategory("HTTP.GET")]
        public async Task PostAsyncUserNameTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (AnonymousClient c) => c.PostAsync(new AnonymousUserRequest()
                    {
                        UserName = null,
                        Name = null
                    }),
                new ArgumentException("UserName can not be empty or null.")
            );

            await base.SDKExceptionResponseTestAsync(
                (AnonymousClient c) => c.PostAsync(new AnonymousUserRequest()
                {
                    UserName = "",
                    Name = null
                }),
                new ArgumentException("UserName can not be empty or null.")
            );
        }

        #endregion
    }
}
