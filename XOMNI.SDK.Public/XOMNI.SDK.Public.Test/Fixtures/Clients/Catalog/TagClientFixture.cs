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
    public class TagClientFixture : BaseClientFixture <TagClient>
    {
        protected const string validAPIResponse = @"{
     'Data': {
        'Results': [
            {
                'Id': 1,
                'Name': 'Sample Tag 0',
                'Description': 'Sample Tag O Description',
                'TagMetadata': [
                    {
                        'Key': 'tagmetadatakey0',
                        'Value': 'tagmetadatavalue0'
                    },
                    {
                        'Key': 'tagmetadatakey1',
                        'Value': 'tagmetadatavalue1'
                    },
                    {
                        'Key': 'tagmetadatakey3',
                        'Value': 'tagmetadatavalue3'
                    },
                ]
            },
            {
                'Id': 2,
                'Name': 'Sample Tag 1',
                'Description': 'Sample Tag 1 Description',
                'TagMetadata': [
                    {
                        'Key': 'tagmetadatakey0',
                        'Value': 'tagmetadatavalue0'
                    },
                    {
                        'Key': 'tagmetadatakey1',
                        'Value': 'tagmetadatavalue1'
                    },
                    {
                        'Key': 'tagmetadatakey6',
                        'Value': 'tagmetadatavalue6'
                    },
                ]
            }
        ],
        'TotalCount': 100
    }
        }";

        #region GetAsync
        protected readonly HttpResponseMessage validHttpResponseMessage = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK,
            Content = new MockedJsonContent(validAPIResponse)
        };

        [TestMethod, TestCategory("TagClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (TagClient c) => c.GetAsync(1,1, false),
                validHttpResponseMessage,
                validAPIResponse
                );
        }
        [TestMethod, TestCategory("TagClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (TagClient c) => c.GetAsync(1,1, false),
                HttpMethod.Get
                );
        }
        [TestMethod, TestCategory("TagClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (TagClient p) => p.GetAsync(1, 1, false),
              string.Format("/catalog/tag?skip={0}&take={1}&includeMetadata={2}",1,1,false));
        }
        [TestMethod, TestCategory("TagClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (TagClient p) => p.GetAsync(1, 1, false),
              badRequestHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("TagClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (TagClient p) => p.GetAsync(-1, 1, false),
              new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", "skip", 0)));
        
            await base.SDKExceptionResponseTestAsync(
              (TagClient p) => p.GetAsync(1, 0, false),
              new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", "take", 1)));
        }
        
        [TestMethod, TestCategory("TagClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (TagClient p) => p.GetAsync( 1, 1, false));
        }
        #endregion
    }
}
