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
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.Catalog
{
    [TestClass]
    public class ItemAssetClientFixture : BaseClientFixture<ItemAssetClient>
    {

        #region Arrange
        const string validAPIResponse = @"{
            'Data': [
                {
                    'AssetMetadata': [
                        {
                            'Key': 'assetmetadatakey1',
                            'Value': 'assetmetadatavalue1'
                        },
                        {
                            'Key': 'assetmetadatakey2',
                            'Value': 'assetmetadatavalue2'
                        }
                    ],
                    'AssetId': 4,
                    'AssetUrl': 'https://xomni.blob.core.windows.net/images/ec741f00-b9bf-49c8-a618-33e419695717',
                    'IsDefault': false,
                    'ResizedAssets':[
                      {
                          'ImageSizeProfile':{
                              'Id':1,
                              'Height':100,
                              'Width':200
                          },
                          'AssetUrl':'http://xomni.blob.core.windows.net/resizedassets/test-resizedasset'
                      }
                   ],
                },
                {
                    'AssetMetadata': [
                        {                    
                            'Key': 'assetmetadatakey1',
                            'Value': 'assetmetadatavalue1'
                        },
                        {
                            'Key': 'assetmetadatakey5',
                            'Value': 'assetmetadatavalue5'
                        }
                    ],
                    'AssetId': 5,
                    'AssetUrl': ' https://xomni.blob.core.windows.net/images/bd0b8aba-3194-4e73-93d8-f5a2c6832d7f',
                    'IsDefault': true,
	         'ResizedAssets':null,
                }
            ]
        } ";

        readonly HttpResponseMessage validHttpResponseMessage = new HttpResponseMessage()
        {
            Content = new MockedJsonContent(validAPIResponse),
            StatusCode = HttpStatusCode.OK
        };
        #endregion

        #region GetImagesAsync
        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetImagesAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (ItemAssetClient c) => c.GetImagesAsync(1, null, null, Models.Catalog.AssetDetailType.None)
            );
        }

        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetImagesAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (ItemAssetClient c) => c.GetImagesAsync(1),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetImagesAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (ItemAssetClient c) => c.GetImagesAsync(1),
              "/catalog/items/1/images?assetDetail=4");
        }

        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetImagesAsyncUriWithOptionalCheckTest()
        {
            await base.UriTestAsync(
                (ItemAssetClient c) => c.GetImagesAsync(1, metadataKey: "key", metadataValue: "value"),
              "/catalog/items/1/images?metadataKey=key&metadataValue=value&assetDetail=4");
        }

        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetImagesAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (ItemAssetClient c) => c.GetImagesAsync(1),
              notFoundHttpResponseMessage,
              expectedExceptionResult
            );
        }

        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetImagesAsyncAssetIdTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (ItemAssetClient c) => c.GetImagesAsync(-1),
                new ArgumentException("itemId must be greater than or equal to 1.")
            );
        }

        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetImagesAsyncOptionalParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (ItemAssetClient c) => c.GetImagesAsync(1, metadataKey: "Key"),
                new ArgumentException("metadataValue can not be empty or null."));

            await base.SDKExceptionResponseTestAsync(
                (ItemAssetClient c) => c.GetImagesAsync(1, metadataValue: "Value"),
                new ArgumentException("metadataKey can not be empty or null."));
        }

        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetImagesAsyncHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (ItemAssetClient c) => c.GetImagesAsync(1)
            );
        }
        #endregion

        #region GetVideosAsync
        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetVideosAsync"), TestCategory("HTTP.GET")]
        public async Task GetVidesAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (ItemAssetClient c) => c.GetVideosAsync(1, null, null, Models.Catalog.AssetDetailType.None)
            );
        }

        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetVideosAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideosAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (ItemAssetClient c) => c.GetVideosAsync(1),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetVideosAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideosAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (ItemAssetClient c) => c.GetVideosAsync(1),
              "/catalog/items/1/videos?assetDetail=4");
        }

        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideosAsyncUriWithOptionalParameterCheckTest()
        {
            await base.UriTestAsync(
                (ItemAssetClient c) => c.GetVideosAsync(1, metadataKey: "key", metadataValue: "value"),
              "/catalog/items/1/videos?metadataKey=key&metadataValue=value&assetDetail=4");
        }

        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetVideosAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideosAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (ItemAssetClient c) => c.GetVideosAsync(1),
              notFoundHttpResponseMessage,
              expectedExceptionResult
            );
        }

        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetVideosAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideosAsyncAssetIdTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (ItemAssetClient c) => c.GetVideosAsync(-1),
                new ArgumentException("itemId must be greater than or equal to 1.")
            );
        }

        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetVideosAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideosAsyncOptionalParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (ItemAssetClient c) => c.GetVideosAsync(1, metadataKey: "Key"),
                new ArgumentException("metadataValue can not be empty or null."));

            await base.SDKExceptionResponseTestAsync(
                (ItemAssetClient c) => c.GetVideosAsync(1, metadataValue: "Value"),
                new ArgumentException("metadataKey can not be empty or null."));
        }

        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetVideosAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideosAsyncHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (ItemAssetClient c) => c.GetVideosAsync(1)
            );
        }
        #endregion

        #region GetDocumentRelationAsync
        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetDocumentRelationAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentRelationAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (ItemAssetClient c) => c.GetDocumentrelationAsync(1, null, null, Models.Catalog.AssetDetailType.None)
            );
        }

        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetDocumentRelationAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentMetadataAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (ItemAssetClient c) => c.GetDocumentrelationAsync(1),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetDocumentRelationAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentRelationAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (ItemAssetClient c) => c.GetDocumentrelationAsync(1),
              "/catalog/documentrelation?itemId=1&assetDetail=4");
        }

        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentRelationAsyncUriWithOptionalCheckTest()
        {
            await base.UriTestAsync(
                (ItemAssetClient c) => c.GetDocumentrelationAsync(1, metadataKey: "key", metadataValue: "value"),
              "/catalog/documentrelation?itemId=1&metadataKey=key&metadataValue=value&assetDetail=4");
        }

        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetDocumentRelationAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentRelationAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (ItemAssetClient c) => c.GetDocumentrelationAsync(1),
              notFoundHttpResponseMessage,
              expectedExceptionResult
            );
        }

        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetDocumentRelationAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentRelationAsyncAssetIdTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (ItemAssetClient c) => c.GetDocumentrelationAsync(-1),
                new ArgumentException("itemId must be greater than or equal to 1.")
            );
        }

        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetDocumentRelationAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentRelationAsyncOptionalParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (ItemAssetClient c) => c.GetDocumentrelationAsync(1, metadataKey: "Key"),
                new ArgumentException("metadataValue can not be empty or null."));

            await base.SDKExceptionResponseTestAsync(
                (ItemAssetClient c) => c.GetDocumentrelationAsync(1, metadataValue: "Value"),
                new ArgumentException("metadataKey can not be empty or null."));
        }

        [TestMethod, TestCategory("ItemAssetClient"), TestCategory("GetDocumentRelationAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentRelationAsyncHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (ItemAssetClient c) => c.GetDocumentrelationAsync(1)
            );
        }
        #endregion
    }
}
