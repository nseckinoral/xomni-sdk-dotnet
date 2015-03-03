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

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.Catalog
{
    [TestClass]
    public class TagMetadataClientFixture : BaseMetadataClientFixture<TagMetadataClient>
    {
        #region GetAsync
        
        [TestMethod, TestCategory("TagMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.MetadataResponseParseTestAsync(
                (TagMetadataClient t) => t.GetAsync(1),
                validHttpResponseMessage,
                validAPIResponse
            );
        }

        [TestMethod, TestCategory("TagMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (TagMetadataClient t) => t.GetAsync(1),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("TagMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (TagMetadataClient t) => t.GetAsync(1),
              "/catalog/tagmetadata?tagId=1");
        }

        [TestMethod, TestCategory("TagMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (TagMetadataClient t) => t.GetAsync(1),
              notFoundHttpResponseMessage,
              expectedExceptionResult
            );
        }

        [TestMethod, TestCategory("TagMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (TagMetadataClient t) => t.GetAsync(1),
              badRequestHttpResponseMessage,
              expectedExceptionResult
            );
        }

        [TestMethod, TestCategory("TagMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncParameterMalformedTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (TagMetadataClient t) => t.GetAsync(-1),
                new ArgumentException("tagId must be greater than or equal to 1.")
            );
        }

        [TestMethod, TestCategory("TagMetadataClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (TagMetadataClient t) => t.GetAsync(1)
            );
        }
        #endregion
    }
}
