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
    public class DynamicAttributeClientFixture : BaseClientFixture<DynamicAttributeClient>
    {
        #region Arrange
        const string validAPIResponseForDynamicAttributeTypes = @"{
            'Data': {
                'Results': [
                    {
                        'Id': 1,
                        'Description': 'Color'
                    },
                    {
                        'Id': 2,
                        'Description': 'Size'
                    },
                    {
                        'Id': 3,
                        'Description': 'Style'
                    }
                ],
                'TotalCount': 12
            }
        }"; 

        const string validAPIResponseForDynamicAttributes = @"{
            'Data': {
                'Results': [
                    {
                        'TypeId': 1,
                        'TypeValueId': 1,
                        'Value': 'Red',
                        'TypeName': 'Color'
                    },
                    {
                        'TypeId': 1,
                        'TypeValueId': 2,
                        'Value': 'Blue',
                        'TypeName': 'Color'
                    },
                    {
                        'TypeId': 1,
                        'TypeValueId': 3,
                        'Value': 'Green',
                        'TypeName': 'Color'
                    },
                    {
                        'TypeId': 2,
                        'TypeValueId': 4,
                        'Value': 'M',
                        'TypeName': 'Size'
                    },
                    {
                        'TypeId': 2,
                        'TypeValueId': 5,
                        'Value': 'L',
                        'TypeName': 'Size'
                    },
                    {
                        'TypeId': 2,
                        'TypeValueId': 6,
                        'Value': 'XL',
                        'TypeName': 'Size'
                    },
                    {
                        'TypeId': 3,
                        'TypeValueId': 7,
                        'Value': 'A',
                        'TypeName': 'Style'
                    },
                    {
                        'TypeId': 3,
                        'TypeValueId': 8,
                        'Value': 'B',
                        'TypeName': 'Style'
                    },
                    {
                        'TypeId': 2,
                        'TypeValueId': 9,
                        'Value': 'S',
                        'TypeName': 'Size'
                    }
                ],
                'TotalCount': 9
            }
        }";

        
        
        const string validAPIResponse = @"{
            'Data': [
                {
                    'TypeId': 2,
                    'TypeValueId': 4,
                    'Value': 'M',
                    'TypeName': 'Size'
                },
                {
                    'TypeId': 2,
                    'TypeValueId': 5,
                    'Value': 'L',
                    'TypeName': 'Size'
                },
                {
                    'TypeId': 2,
                    'TypeValueId': 6,
                    'Value': 'XL',
                    'TypeName': 'Size'
                },
                {
                    'TypeId': 2,
                    'TypeValueId': 9,
                    'Value': 'S',
                    'TypeName': 'Size'
                }
            ]
        }";
        #endregion

        #region GetDynamicAttributeTypesAsync

        [TestMethod, TestCategory("DynamicAttributeClient"), TestCategory("GetDynamicAttributeTypesAsync"), TestCategory("HTTP.GET")]
        public async Task GetDynamicAttributeTypesAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (DynamicAttributeClient c) => c.GetDynamicAttributeTypesAsync(1, 1),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponseForDynamicAttributeTypes)
                },
                validAPIResponseForDynamicAttributeTypes
            );
        }

        [TestMethod, TestCategory("DynamicAttributeClient"), TestCategory("GetDynamicAttributeTypesAsync"), TestCategory("HTTP.GET")]
        public async Task GetDynamicAttributeTypesAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (DynamicAttributeClient c) => c.GetDynamicAttributeTypesAsync(1, 2),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("DynamicAttributeClient"), TestCategory("GetDynamicAttributeTypesAsync"), TestCategory("HTTP.GET")]
        public async Task GetDynamicAttributeTypesAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (DynamicAttributeClient c) => c.GetDynamicAttributeTypesAsync(1, 2),
              "/catalog/dynamicattributetypes?skip=1&take=2");
        }

        [TestMethod, TestCategory("DynamicAttributeClient"), TestCategory("GetDynamicAttributeTypesAsync"), TestCategory("HTTP.GET")]
        public async Task GetDynamicAttributeTypesAsyncSkipTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (DynamicAttributeClient c) => c.GetDynamicAttributeTypesAsync(-1, 2),
                new ArgumentException("skip must be greater than or equal to 0.")
            );
        }

        [TestMethod, TestCategory("DynamicAttributeClient"), TestCategory("GetDynamicAttributeTypesAsync"), TestCategory("HTTP.GET")]
        public async Task GetDynamicAttributeTypesAsyncTakeTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (DynamicAttributeClient c) => c.GetDynamicAttributeTypesAsync(1, 0),
                new ArgumentException("take must be greater than or equal to 1.")
            );
        }

        [TestMethod, TestCategory("DynamicAttributeClient"), TestCategory("GetDynamicAttributeTypesAsync"), TestCategory("HTTP.GET")]
        public async Task GetDynamicAttributeTypesAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (DynamicAttributeClient c) => c.GetDynamicAttributeTypesAsync(1, 2),
              notFoundHttpResponseMessage,
              expectedExceptionResult
            );
        }
        #endregion

        #region GetDynamicAttributesAsync
        
        [TestMethod, TestCategory("DynamicAttributeClient"), TestCategory("GetDynamicAttributesAsync"), TestCategory("HTTP.GET")]
        public async Task GetDynamicAttributesAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (DynamicAttributeClient c) => c.GetDynamicAttributesAsync(1, 2),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponseForDynamicAttributes)
                },
                validAPIResponseForDynamicAttributes
            );
        }

        [TestMethod, TestCategory("DynamicAttributeClient"), TestCategory("GetDynamicAttributesAsync"), TestCategory("HTTP.GET")]
        public async Task GetDynamicAttributesAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (DynamicAttributeClient c) => c.GetDynamicAttributesAsync(1, 2),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("DynamicAttributeClient"), TestCategory("GetDynamicAttributesAsync"), TestCategory("HTTP.GET")]
        public async Task GetDynamicAttributesAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (DynamicAttributeClient c) => c.GetDynamicAttributesAsync(1, 2),
              "/catalog/dynamicattributes?skip=1&take=2");
        }

        [TestMethod, TestCategory("DynamicAttributeClient"), TestCategory("GetDynamicAttributesAsync"), TestCategory("HTTP.GET")]
        public async Task GetDynamicAttributesAsyncSkipTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (DynamicAttributeClient c) => c.GetDynamicAttributesAsync(-1, 2),
                new ArgumentException("skip must be greater than or equal to 0.")
            );
        }

        [TestMethod, TestCategory("DynamicAttributeClient"), TestCategory("GetDynamicAttributesAsync"), TestCategory("HTTP.GET")]
        public async Task GetDynamicAttributesAsyncTakeTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (DynamicAttributeClient c) => c.GetDynamicAttributesAsync(1, 0),
                new ArgumentException("take must be greater than or equal to 1.")
            );
        }

        [TestMethod, TestCategory("DynamicAttributeClient"), TestCategory("GetDynamicAttributesAsync"), TestCategory("HTTP.GET")]
        public async Task GetDynamicAttributesAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (DynamicAttributeClient c) => c.GetDynamicAttributesAsync(1, 2),
              badRequestHttpResponseMessage,
              expectedExceptionResult
            );
        }
        #endregion

        #region GetAsync

        [TestMethod, TestCategory("DynamicAttributeClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (DynamicAttributeClient c) => c.GetAsync(1),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponse)
                },
                validAPIResponse
            );
        }

        [TestMethod, TestCategory("DynamicAttributeClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (DynamicAttributeClient c) => c.GetAsync(1),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("DynamicAttributeClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (DynamicAttributeClient c) => c.GetAsync(1),
              "/catalog/dynamicattributes/1");
        }

        [TestMethod, TestCategory("DynamicAttributeClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (DynamicAttributeClient c) => c.GetAsync(1),
              badRequestHttpResponseMessage,
              expectedExceptionResult
            );
        }

        [TestMethod, TestCategory("DynamicAttributeClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (DynamicAttributeClient c) => c.GetAsync(1)
            );
        }

        [TestMethod, TestCategory("DynamicAttributeClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncdynamicAttributeTypeIdTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (DynamicAttributeClient c) => c.GetAsync(-1),
                new ArgumentException("dynamicAttributeTypeId must be greater than or equal to 1.")
            );
        }

        #endregion
    }
}
