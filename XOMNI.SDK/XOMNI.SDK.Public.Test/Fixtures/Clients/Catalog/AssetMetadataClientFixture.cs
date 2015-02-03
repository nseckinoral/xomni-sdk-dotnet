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
using XOMNI.SDK.Public.Exceptions;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients
{
    [TestClass]
    public class AssetMetadataClientFixture : BaseMetadataClientFixture<AssetMetadataClient>
    {
        #region arrenge

        const string notFoundResponse = @"{
            'IdentifierGuid':'7358fe16-3925-4951-9a77-fca4f9e167b0',
            'IdentifierTick':635585478999549713,
            'FriendlyDescription':'Asset or related metadata is not found.'
        }";
        
        const string validAPIResponse = @"{
            'Data': [
                {
                    'Key': 'imagemetadatakey0',
                    'Value': 'imagemetadatavalue0'
                },
                {
                    'Key': 'imagemetadatakey1',
                    'Value': 'imagemetadatavalue1'
                }
            ]
        }";
        
        readonly HttpResponseMessage validHttpResponseMessage = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK,
            Content = new MockedJsonContent(validAPIResponse)
        };

        readonly HttpResponseMessage notFoundHttpResponseMessage = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.NotFound,
            Content = new MockedJsonContent(notFoundResponse)
        };

        #endregion

        #region GetImageMetadataAsync
        [TestMethod, TestCategory("AssetMetadataClient"), TestCategory("GetImageMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetImageMetadataAsyncResponseParseTest()
        {
            await base.MetadataResponseParseTestAsync(
                (AssetMetadataClient c) => c.GetImageMetadataAsync(1),
                validHttpResponseMessage,
                validAPIResponse
            );
        }

        [TestMethod, TestCategory("AssetMetadataClient"), TestCategory("GetImageMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetImageMetadataAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (AssetMetadataClient c) => c.GetImageMetadataAsync(1),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("AssetMetadataClient"), TestCategory("GetImageMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetImageMetadataAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (AssetMetadataClient c) => c.GetImageMetadataAsync(1),
              "/catalog/imagemetadata?assetId=1");
        }

        [TestMethod, TestCategory("AssetMetadataClient"), TestCategory("GetImageMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetImageMetadataAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(notFoundResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (AssetMetadataClient c) => c.GetImageMetadataAsync(1),
              notFoundHttpResponseMessage,
              expectedExceptionResult
            );
        }

        [TestMethod, TestCategory("AssetMetadataClient"), TestCategory("GetImageMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetImageMetadataAsyncParameterMalformedTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (AssetMetadataClient c) => c.GetImageMetadataAsync(-1),
                new ArgumentException("assetId must be greater than or equal to zero")
            );
        }

        [TestMethod, TestCategory("AssetMetadataClient"), TestCategory("GetImageMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetImageMetadataAsyncHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (AssetMetadataClient c) => c.GetImageMetadataAsync(1)
            );
        }
        #endregion

        #region GetVideoMetadataAsync
        [TestMethod, TestCategory("AssetMetadataClient"), TestCategory("GetVideoMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideoMetadataAsyncResponseParseTest()
        {
            await base.MetadataResponseParseTestAsync(
                (AssetMetadataClient c) => c.GetVideoMetadataAsync(1),
                validHttpResponseMessage,
                validAPIResponse
            );
        }

        [TestMethod, TestCategory("AssetMetadataClient"), TestCategory("GetVideoMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideoMetadataAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (AssetMetadataClient c) => c.GetVideoMetadataAsync(1),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("AssetMetadataClient"), TestCategory("GetVideoMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideoMetadataAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (AssetMetadataClient c) => c.GetVideoMetadataAsync(1),
              "/catalog/videometadata?assetId=1");
        }

        [TestMethod, TestCategory("AssetMetadataClient"), TestCategory("GetVideoMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideoMetadataAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(notFoundResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (AssetMetadataClient c) => c.GetVideoMetadataAsync(1),
              notFoundHttpResponseMessage,
              expectedExceptionResult
            );
        }

        [TestMethod, TestCategory("AssetMetadataClient"), TestCategory("GetVideoMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideoMetadataAsyncParameterMalformedTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (AssetMetadataClient c) => c.GetVideoMetadataAsync(-1),
                new ArgumentException("assetId must be greater than or equal to zero")
            );
        }

        [TestMethod, TestCategory("AssetMetadataClient"), TestCategory("GetVideoMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideoMetadataAsyncHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (AssetMetadataClient c) => c.GetVideoMetadataAsync(1)
            );
        }
        #endregion

        #region GetDocumentMetadataAsync
        [TestMethod, TestCategory("AssetMetadataClient"), TestCategory("GetDocumentMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentMetadataAsyncResponseParseTest()
        {
            await base.MetadataResponseParseTestAsync(
                (AssetMetadataClient c) => c.GetDocumentMetadataAsync(1),
                validHttpResponseMessage,
                validAPIResponse
            );
        }

        [TestMethod, TestCategory("AssetMetadataClient"), TestCategory("GetDocumentMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentMetadataAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (AssetMetadataClient c) => c.GetDocumentMetadataAsync(1),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("AssetMetadataClient"), TestCategory("GetDocumentMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentMetadataAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (AssetMetadataClient c) => c.GetDocumentMetadataAsync(1),
              "/catalog/documentmetadata?assetId=1");
        }

        [TestMethod, TestCategory("AssetMetadataClient"), TestCategory("GetDocumentMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentMetadataAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(notFoundResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (AssetMetadataClient c) => c.GetDocumentMetadataAsync(1),
              notFoundHttpResponseMessage,
              expectedExceptionResult
            );
        }

        [TestMethod, TestCategory("AssetMetadataClient"), TestCategory("GetDocumentMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentMetadataAsyncParameterMalformedTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (AssetMetadataClient c) => c.GetDocumentMetadataAsync(-1),
                new ArgumentException("assetId must be greater than or equal to zero")
            );
        }

        [TestMethod, TestCategory("AssetMetadataClient"), TestCategory("GetDocumentMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentMetadataAsyncHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (AssetMetadataClient c) => c.GetDocumentMetadataAsync(1)
            );
        }
        #endregion
    }
}
