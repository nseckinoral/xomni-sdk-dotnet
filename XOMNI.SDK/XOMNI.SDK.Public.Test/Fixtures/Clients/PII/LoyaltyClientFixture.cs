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
using XOMNI.SDK.Public.Models.OmniPlay;
using XOMNI.SDK.Public.Models.PII;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.PII
{
    [TestClass]
    public class LoyaltyClientFixture : BaseClientFixture<LoyaltyClient>
    {
        protected const string validAPIResponse = @"{
            'Data': {
                'AvailablePoints': 28.847555258938836,
                'StreetAddress1': '244dbc92-5802-4150-809c-b8d52d519ac0',
                'StreetAddress2': 'e5186f65-50c8-491a-b50b-cf13bd56313a',
                'City': '1e25cadb-f91c-4059-a85b-0b6de0fffce8',
                'State': '2236aaeb-2245-4989-a494-6dd120c9959d',
                'Zip': '60364ddc-4',
                'PhoneNumber': '6c2ba8fd-1a3b-4061-9438-f216ee6fd0c7',
                'EMailAddress': '5b91c22b-640f-4385-b9dd-a5077eb382d7',
                'Gender': 'Male',
                'DateOfBirth': null,
                'UserName': '72426d72-d963-43a0-8fe4-7ea6874b8529',
                'Password': 'aa1c9b20-51d6-47a9-87a8-d7c9260c9263',
                'Name': '997fa7e4-01f9-4288-bdb2-16559b5b078f',
                'PIIUserType': 'Loyalty'
            }
        }";

        protected readonly HttpResponseMessage validHttpResponseMessage = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK,
            Content = new MockedJsonContent(validAPIResponse)
        };

        [TestMethod, TestCategory("LoyaltyClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync<ApiResponse<LoyaltyUser>>(
                (LoyaltyClient c) => c.GetAsync(),
                validHttpResponseMessage,
                validAPIResponse,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("LoyaltyClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (LoyaltyClient c) => c.GetAsync(),
                HttpMethod.Get,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("LoyaltyClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
                (LoyaltyClient c) => c.GetAsync(),
                "/pii/loyalty",
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("LoyaltyClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUnauthorizedTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.Unauthorized;

            await base.APIExceptionResponseTestAsync(
                (LoyaltyClient c) => c.GetAsync(),
                unauthorizedHttpResponseMessage,
                expectedExceptionResult,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("LoyaltyClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (LoyaltyClient c) => c.GetAsync(),
                piiUser: piiUser);
        }

    }
}
