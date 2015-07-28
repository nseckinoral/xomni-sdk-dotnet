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
    public class CategoryAssetClientFixture: BaseClientFixture<CategoryAssetClient>
    {
       const string validAPIResponseForGetAsync = @"{
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

        #region GetImagesAsync

        [TestMethod, TestCategory("CategoryAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
       public async Task GetImagesAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (CategoryAssetClient b) => b.GetImagesAsync(1, null, null, Models.Catalog.AssetDetailType.None));
        }

        [TestMethod, TestCategory("CategoryAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetImagesAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (CategoryAssetClient b) => b.GetImagesAsync(1),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("CategoryAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetImagesAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (CategoryAssetClient b) => b.GetImagesAsync(1),
              "/catalog/categories/1/images?assetDetail=4");

            await base.UriTestAsync(
                (CategoryAssetClient b) => b.GetImagesAsync(1, metadataKey: "Key",metadataValue:"Value"),
                "/catalog/categories/1/images?metadataKey=Key&metadataValue=Value&assetDetail=4");
        }

        [TestMethod, TestCategory("CategoryAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetImagesAsyncOptionalParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (CategoryAssetClient b) => b.GetImagesAsync(1, metadataKey: "Key"),
                new ArgumentException("metadataValue can not be empty or null."));

            await base.SDKExceptionResponseTestAsync(
                (CategoryAssetClient b) => b.GetImagesAsync(1, metadataValue: "Value"),
                new ArgumentException("metadataKey can not be empty or null."));
        }

        [TestMethod, TestCategory("CategoryAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetImagesAsyncCategoryIdTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (CategoryAssetClient b) => b.GetImagesAsync(0, metadataKey: "Key"),
                new ArgumentException("categoryId must be greater than or equal to 1."));
        }

        [TestMethod, TestCategory("CategoryAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetImagesAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (CategoryAssetClient b) => b.GetImagesAsync(1),
              notFoundHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("CategoryAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetImagesAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (CategoryAssetClient b) => b.GetImagesAsync(1));
        }
        #endregion

        #region GetVideosAsync

        [TestMethod, TestCategory("CategoryAssetClient"), TestCategory("GetVideosAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideosAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (CategoryAssetClient b) => b.GetVideosAsync(1, null, null, Models.Catalog.AssetDetailType.None));
        }

        [TestMethod, TestCategory("CategoryAssetClient"), TestCategory("GetVideosAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideosAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (CategoryAssetClient b) => b.GetVideosAsync(1),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("CategoryAssetClient"), TestCategory("GetVideosAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideosAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (CategoryAssetClient b) => b.GetVideosAsync(1),
              "/catalog/categories/1/videos?assetDetail=4");

            await base.UriTestAsync(
                (CategoryAssetClient b) => b.GetVideosAsync(1, metadataKey: "Key", metadataValue: "Value"),
                "/catalog/categories/1/videos?metadataKey=Key&metadataValue=Value&assetDetail=4");
        }

        [TestMethod, TestCategory("CategoryAssetClient"), TestCategory("GetVideosAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideosAsyncOptionalParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (CategoryAssetClient b) => b.GetVideosAsync(1, metadataKey: "Key"),
                new ArgumentException("metadataValue can not be empty or null."));

            await base.SDKExceptionResponseTestAsync(
                (CategoryAssetClient b) => b.GetVideosAsync(1, metadataValue: "Value"),
                new ArgumentException("metadataKey can not be empty or null."));
        }

        [TestMethod, TestCategory("CategoryAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideosAsyncCategoryIdTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (CategoryAssetClient b) => b.GetVideosAsync(0, metadataKey: "Key"),
                new ArgumentException("categoryId must be greater than or equal to 1."));
        }

        [TestMethod, TestCategory("CategoryAssetClient"), TestCategory("GetVideosAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideosAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (CategoryAssetClient b) => b.GetVideosAsync(1),
              notFoundHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("CategoryAssetClient"), TestCategory("GetVideosAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideosAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (CategoryAssetClient b) => b.GetVideosAsync(1));
        }
        #endregion

        #region GetDocumentsAsync

        [TestMethod, TestCategory("CategoryAssetClient"), TestCategory("GetDocumentsAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentsAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (CategoryAssetClient b) => b.GetDocumentsAsync(1, null, null, Models.Catalog.AssetDetailType.None)
            );
        }

        [TestMethod, TestCategory("CategoryAssetClient"), TestCategory("GetDocumentsAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentsAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (CategoryAssetClient b) => b.GetDocumentsAsync(1),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("CategoryAssetClient"), TestCategory("GetDocumentsAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentsAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (CategoryAssetClient b) => b.GetDocumentsAsync(1),
              "/catalog/categories/1/documents?assetDetail=4");

            await base.UriTestAsync(
                (CategoryAssetClient b) => b.GetDocumentsAsync(1, metadataKey: "Key", metadataValue: "Value"),
                "/catalog/categories/1/documents?metadataKey=Key&metadataValue=Value&assetDetail=4");
        }

        [TestMethod, TestCategory("CategoryAssetClient"), TestCategory("GetDocumentsAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentsAsyncOptionalParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (CategoryAssetClient b) => b.GetDocumentsAsync(1, metadataKey: "Key"),
                new ArgumentException("metadataValue can not be empty or null."));

            await base.SDKExceptionResponseTestAsync(
                (CategoryAssetClient b) => b.GetDocumentsAsync(1, metadataValue: "Value"),
                new ArgumentException("metadataKey can not be empty or null."));
        }

        [TestMethod, TestCategory("CategoryAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentsAsyncCategoryIdTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (CategoryAssetClient b) => b.GetDocumentsAsync(0, metadataKey: "Key"),
                new ArgumentException("categoryId must be greater than or equal to 1."));
        }

        [TestMethod, TestCategory("CategoryAssetClient"), TestCategory("GetDocumentsAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentsAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (CategoryAssetClient b) => b.GetDocumentsAsync(1),
              notFoundHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("CategoryAssetClient"), TestCategory("GetDocumentsAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentsAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (CategoryAssetClient b) => b.GetDocumentsAsync(1));
        }
        #endregion
    }
}
