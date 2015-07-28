﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class BrandAssetClientFixture : BaseClientFixture<BrandAssetClient>
    {
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

        #region GetImagesAsync

        [TestMethod, TestCategory("BrandAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetImagesAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (BrandAssetClient b) => b.GetImagesAsync(1, null, null, Models.Catalog.AssetDetailType.None)
            );
        }

        [TestMethod, TestCategory("BrandAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetImagesAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (BrandAssetClient b) => b.GetImagesAsync(1),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("BrandAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetImagesAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (BrandAssetClient b) => b.GetImagesAsync(1),
              "/catalog/brands/1/images?assetDetail=4");

            await base.UriTestAsync(
                (BrandAssetClient b) => b.GetImagesAsync(1, metadataKey: "Key", metadataValue: "Value"),
                "/catalog/brands/1/images?metadataKey=Key&metadataValue=Value&assetDetail=4");
        }

        [TestMethod, TestCategory("BrandAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetImagesAsyncOptionalParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (BrandAssetClient b) => b.GetImagesAsync(1, metadataKey: "Key"),
                new ArgumentException("metadataValue can not be empty or null."));

            await base.SDKExceptionResponseTestAsync(
                (BrandAssetClient b) => b.GetImagesAsync(1, metadataValue: "Value"),
                new ArgumentException("metadataKey can not be empty or null."));
        }

        [TestMethod, TestCategory("BrandAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetImagesAsyncBrandIdTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (BrandAssetClient b) => b.GetImagesAsync(0, metadataKey: "Key"),
                new ArgumentException("brandId must be greater than or equal to 1."));

        }

        [TestMethod, TestCategory("BrandAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetImagesAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (BrandAssetClient b) => b.GetImagesAsync(1),
              notFoundHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("BrandAssetClient"), TestCategory("GetImagesAsync"), TestCategory("HTTP.GET")]
        public async Task GetImagesAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (BrandAssetClient b) => b.GetImagesAsync(1));
        }
        #endregion

        #region GetVideosAsync

        [TestMethod, TestCategory("BrandAssetClient"), TestCategory("GetVideosAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideosAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (BrandAssetClient b) => b.GetVideosAsync(1, null, null, Models.Catalog.AssetDetailType.None)
            );
        }

        [TestMethod, TestCategory("BrandAssetClient"), TestCategory("GetVideosAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideosAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (BrandAssetClient b) => b.GetVideosAsync(1),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("BrandAssetClient"), TestCategory("GetVideosAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideosAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (BrandAssetClient b) => b.GetVideosAsync(1),
              "/catalog/brands/1/videos?assetDetail=4");

            await base.UriTestAsync(
                (BrandAssetClient b) => b.GetVideosAsync(1, metadataKey: "Key", metadataValue: "Value"),
                "/catalog/brands/1/videos?metadataKey=Key&metadataValue=Value&assetDetail=4");
        }

        [TestMethod, TestCategory("BrandAssetClient"), TestCategory("GetVideosAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideosAsyncOptionalParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (BrandAssetClient b) => b.GetVideosAsync(1, metadataKey: "Key"),
                new ArgumentException("metadataValue can not be empty or null."));

            await base.SDKExceptionResponseTestAsync(
                (BrandAssetClient b) => b.GetVideosAsync(1, metadataValue: "Value"),
                new ArgumentException("metadataKey can not be empty or null."));
        }

        [TestMethod, TestCategory("BrandAssetClient"), TestCategory("GetVideosAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideosAsyncBrandIdTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (BrandAssetClient b) => b.GetVideosAsync(0, metadataKey: "Key"),
                new ArgumentException("brandId must be greater than or equal to 1."));
        }

        [TestMethod, TestCategory("BrandAssetClient"), TestCategory("GetVideosAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideosAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (BrandAssetClient b) => b.GetVideosAsync(1),
              notFoundHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("BrandAssetClient"), TestCategory("GetVideosAsync"), TestCategory("HTTP.GET")]
        public async Task GetVideosAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (BrandAssetClient b) => b.GetVideosAsync(1));
        }
        #endregion

        #region GetDocumentsAsync

        [TestMethod, TestCategory("BrandAssetClient"), TestCategory("GetDocumentsAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentsAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (BrandAssetClient b) => b.GetDocumentsAsync(1, null, null, Models.Catalog.AssetDetailType.None)
            );
        }

        [TestMethod, TestCategory("BrandAssetClient"), TestCategory("GetDocumentsAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentsAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (BrandAssetClient b) => b.GetDocumentsAsync(1),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("BrandAssetClient"), TestCategory("GetDocumentsAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentsAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (BrandAssetClient b) => b.GetDocumentsAsync(1),
              "/catalog/brands/1/documents?assetDetail=4");

            await base.UriTestAsync(
                (BrandAssetClient b) => b.GetDocumentsAsync(1, metadataKey: "Key", metadataValue: "Value"),
                "/catalog/brands/1/documents?metadataKey=Key&metadataValue=Value&assetDetail=4");
        }

        [TestMethod, TestCategory("BrandAssetClient"), TestCategory("GetDocumentsAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentsAsyncOptionalParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (BrandAssetClient b) => b.GetDocumentsAsync(1, metadataKey: "Key"),
                new ArgumentException("metadataValue can not be empty or null."));

            await base.SDKExceptionResponseTestAsync(
                (BrandAssetClient b) => b.GetDocumentsAsync(1, metadataValue: "Value"),
                new ArgumentException("metadataKey can not be empty or null."));
        }

        [TestMethod, TestCategory("BrandAssetClient"), TestCategory("GetVideosAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentsAsyncBrandIdTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (BrandAssetClient b) => b.GetDocumentsAsync(0, metadataKey: "Key"),
                new ArgumentException("brandId must be greater than or equal to 1."));
        }

        [TestMethod, TestCategory("BrandAssetClient"), TestCategory("GetDocumentsAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentsAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (BrandAssetClient b) => b.GetDocumentsAsync(1),
              notFoundHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("BrandAssetClient"), TestCategory("GetDocumentsAsync"), TestCategory("HTTP.GET")]
        public async Task GetDocumentsAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (BrandAssetClient b) => b.GetDocumentsAsync(1));
        }
        #endregion
    }
}
