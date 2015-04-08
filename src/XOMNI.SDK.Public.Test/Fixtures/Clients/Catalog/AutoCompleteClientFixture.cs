using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients.Catalog;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Catalog;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.Catalog
{
    [TestClass]
    public class AutoCompleteClientFixture : BaseClientFixture<AutoCompleteClient>
    {
        const string validAPIResponse = @"{
            'Data': {
                'SearchTerm': 'br',
                'SearchType': 'All',                
                'Results': [
                    {
                        'Id': 1,
                        'SearchType': 'Brand',
                        'FullText': 'Brand 1'
                    },
                    {
                        'Id': 2,
                        'SearchType': 'Brand',
                        'FullText': 'Brand 2'
                    },
                    {
                        'Id': 3,
                        'SearchType': 'Brand',
                        'FullText': 'Brand 3'
                    },
                    {
                        'Id': 4,
                        'SearchType': 'Brand',
                        'FullText': 'Brand 4'
                    }
                ]
            }
        }";

        #region GetAsync
        [TestMethod, TestCategory("AutoCompleteClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (AutoCompleteClient c) => c.GetAsync(AutoCompleteSearchType.All, "Test", 2, true),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponse)
                },
                validAPIResponse
            );
        }

        [TestMethod, TestCategory("AutoCompleteClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (AutoCompleteClient c) => c.GetAsync(AutoCompleteSearchType.All, "Test", 2, true),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("AutoCompleteClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (AutoCompleteClient c) => c.GetAsync(AutoCompleteSearchType.All, "Test", 2, true),
              "/catalog/autocomplete/All?searchTerm=Test&top=2&includeOnlyMasterItems=True");
        }

        [TestMethod, TestCategory("AutoCompleteClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (AutoCompleteClient c) => c.GetAsync(AutoCompleteSearchType.All, "Test", 2, true),
              badRequestHttpResponseMessage,
              expectedExceptionResult
            );
        }

        [TestMethod, TestCategory("AutoCompleteClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncSearchTermTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (AutoCompleteClient c) => c.GetAsync(AutoCompleteSearchType.All, null, 2, true),
                new ArgumentException("searchTerm can not be empty or null.")
            );

            await base.SDKExceptionResponseTestAsync(
                (AutoCompleteClient c) => c.GetAsync(AutoCompleteSearchType.All, "", 2, true),
                new ArgumentException("searchTerm can not be empty or null.")
            );

            await base.SDKExceptionResponseTestAsync(
                (AutoCompleteClient c) => c.GetAsync(AutoCompleteSearchType.All, "aa", 2, true),
                new ArgumentOutOfRangeException("searchTerm length", 2, string.Format("{0} must be in range ({1} - {2}).", "searchTerm length", 3, 25))
            );

            await base.SDKExceptionResponseTestAsync(
                (AutoCompleteClient c) => c.GetAsync(AutoCompleteSearchType.All, new string(Enumerable.Repeat('a', 30).ToArray()), 2, true),
                new ArgumentOutOfRangeException("searchTerm length", 30, string.Format("{0} must be in range ({1} - {2}).", "searchTerm length", 3, 25))
            );
        }

        [TestMethod, TestCategory("AutoCompleteClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncTopTest()
        {
            await base.SDKExceptionResponseTestAsync(
                 (AutoCompleteClient c) => c.GetAsync(AutoCompleteSearchType.All, "aaa", 0, true),
                 new ArgumentOutOfRangeException("top", 0, string.Format("{0} must be in range ({1} - {2}).", "top", 1, 100))
             );

            await base.SDKExceptionResponseTestAsync(
                (AutoCompleteClient c) => c.GetAsync(AutoCompleteSearchType.All, "aaa", 320, true),
                new ArgumentOutOfRangeException("top", 320, string.Format("{0} must be in range ({1} - {2}).", "top", 1, 100))
            );
        }

        [TestMethod, TestCategory("AutoCompleteClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (AutoCompleteClient c) => c.GetAsync(AutoCompleteSearchType.All, "Test", 2, true)
            );
        }
        #endregion
    }
}
