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
    public class TrendingItemClientFixture : BaseClientFixture<TrendingItemClient>
    {
        #region GetAsync
        protected const string validAPIResponse = @"{  
       'Data':[  
          {  
             'Id':1,
             'Title':'Sample Product Title',
             'Name':'Sample Product Name',
             'SKU':'12421442124213',
             'TotalPoint':627.12,
             'ItemPopularityRecords':[  
                {  
                   'StoreId':2,
                   'ActionType':'ItemView',
                   'TotalTimeImpactValue':156.23,
                   'TotalActionTypeImpactValue':679.21,
                   'TotalValue':835.44,
                   'TotalActionCount':78
                }
             ]
          }
       ]
    }";
        
        protected readonly HttpResponseMessage validHttpResponseMessage = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK,
            Content = new MockedJsonContent(validAPIResponse)
        };

        [TestMethod, TestCategory("TrendingItemClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (TrendingItemClient c) => c.GetAsync(1, true),
                validHttpResponseMessage,
                validAPIResponse
                );
        }

        [TestMethod, TestCategory("TrendingItemClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (TrendingItemClient c) => c.GetAsync(1, true),
                HttpMethod.Get
                );
        }

        [TestMethod, TestCategory("TrendingItemClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (TrendingItemClient c) => c.GetAsync(1, true),
              string.Format("/catalog/trendingitems?top={0}&includeActionDetails={1}", 1, true));
        }

        [TestMethod, TestCategory("TrendingItemClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (TrendingItemClient c) => c.GetAsync(-1, true),
              new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", "top", 1)));

        }

        [TestMethod, TestCategory("TrendingItemClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (TrendingItemClient c) => c.GetAsync(1, true));
        }
        #endregion

        #region GetByStoreAsync

        protected const string validAPIResponseForGetByStoreAsync = @"{
            'Data': [
                {
                    'Id': 1,
                    'Title': 'Sample Product Title',
                    'Name': 'Sample Product Name',
                    'SKU': '12421442124213',
                    'TotalPoint': 627.12,
                    'ItemPopularityRecords': [
                        {
                            'StoreId': 2,
                            'ActionType': 'ItemView',
                            'TotalTimeImpactValue': 156.23,
                            'TotalActionTypeImpactValue': 679.21,
                            'TotalValue': 835.44,
                            'TotalActionCount': 78
                        }
                    ]
                }
            ]
        }";

        protected readonly HttpResponseMessage validHttpResponseMessageForGetByStoreAsync = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK,
            Content = new MockedJsonContent(validAPIResponseForGetByStoreAsync)
        };

        [TestMethod, TestCategory("TrendingItemClient"), TestCategory("GetByStoreAsync"), TestCategory("HTTP.GET")]
        public async Task GetForByStoreAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (TrendingItemClient c) => c.GetByStoreAsync(1, 1, true),
                validHttpResponseMessageForGetByStoreAsync,
                validAPIResponseForGetByStoreAsync
                );
        }

        [TestMethod, TestCategory("TrendingItemClient"), TestCategory("GetByStoreAsync"), TestCategory("HTTP.GET")]
        public async Task GetForByStoreAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (TrendingItemClient c) => c.GetByStoreAsync(1, 1, true),
                HttpMethod.Get
                );
        }

        [TestMethod, TestCategory("TrendingItemClient"), TestCategory("GetByStoreAsync"), TestCategory("HTTP.GET")]
        public async Task GetForByStoreAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (TrendingItemClient c) => c.GetByStoreAsync(1, 1, true),
              string.Format("/catalog/trendingitems?top={0}&storeId={1}&includeActionDetails={2}", 1, 1, true));
        }

        [TestMethod, TestCategory("TrendingItemClient"), TestCategory("GetByStoreAsync"), TestCategory("HTTP.GET")]
        public async Task GetForByStoreAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (TrendingItemClient c) => c.GetByStoreAsync(-1, 1, true),
              new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", "top", 1)));

            await base.SDKExceptionResponseTestAsync(
              (TrendingItemClient c) => c.GetByStoreAsync(1, -1, true),
              new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", "storeId", 1)));
        }

        [TestMethod, TestCategory("TrendingItemClient"), TestCategory("GetByStoreAsync"), TestCategory("HTTP.GET")]
        public async Task GetForByStoreAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (TrendingItemClient c) => c.GetByStoreAsync(1, 1, true));
        }
        #endregion

        #region GetByBrandAsync

        protected const string validAPIResponseForGetByBrandAsync = @"{
            'Data': [
                {
                    'Id': 1,
                    'Title': 'Sample Product Title',
                    'Name': 'Sample Product Name',
                    'SKU': '12421442124213',
                    'TotalPoint': 627.12,
                    'ItemPopularityRecords': [
                        {
                            'StoreId': 2,
                            'ActionType': 'ItemView',
                            'TotalTimeImpactValue': 156.23,
                            'TotalActionTypeImpactValue': 679.21,
                            'TotalValue': 835.44,
                            'TotalActionCount': 78
                        }
                    ]
                }
            ]
        } ";

        protected readonly HttpResponseMessage validHttpResponseMessageForGetByBrandAsync = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK,
            Content = new MockedJsonContent(validAPIResponseForGetByBrandAsync)
        };

        [TestMethod, TestCategory("TrendingItemClient"), TestCategory("GetByBrandAsync"), TestCategory("HTTP.GET")]
        public async Task GetForByBrandAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (TrendingItemClient c) => c.GetByBrandAsync(1, 1, true),
                validHttpResponseMessageForGetByBrandAsync,
                validAPIResponseForGetByBrandAsync
                );
        }

        [TestMethod, TestCategory("TrendingItemClient"), TestCategory("GetByBrandAsync"), TestCategory("HTTP.GET")]
        public async Task GetForByBrandAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (TrendingItemClient c) => c.GetByBrandAsync(1, 1, true),
                HttpMethod.Get
                );
        }

        [TestMethod, TestCategory("TrendingItemClient"), TestCategory("GetByBrandAsync"), TestCategory("HTTP.GET")]
        public async Task GetForByBrandAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (TrendingItemClient c) => c.GetByBrandAsync(1, 1, true),
              string.Format("/catalog/trendingitems?top={0}&brandId={1}&includeActionDetails={2}", 1, 1, true));
        }

        [TestMethod, TestCategory("TrendingItemClient"), TestCategory("GetByBrandAsync"), TestCategory("HTTP.GET")]
        public async Task GetForByBrandAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (TrendingItemClient p) => p.GetByBrandAsync(-1, 1, true),
              new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", "top", 1)));

            await base.SDKExceptionResponseTestAsync(
              (TrendingItemClient p) => p.GetByBrandAsync(1, -1, true),
              new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", "brandId", 1)));
        }

        [TestMethod, TestCategory("TrendingItemClient"), TestCategory("GetByBrandAsync"), TestCategory("HTTP.GET")]
        public async Task GetForByBrandAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (TrendingItemClient c) => c.GetByBrandAsync(1, 1, true));
        }
        #endregion

        #region GetByBrandAndStoreAsync

        protected const string validAPIResponseForGetByBrandAndStoreAsync = @"{
            'Data': [
                {
                    'Id': 1,
                    'Title': 'Sample Product Title',
                    'Name': 'Sample Product Name',
                    'SKU': '12421442124213',
                    'TotalPoint': 627.12,
                    'ItemPopularityRecords': [
                        {
                            'StoreId': 2,
                            'ActionType': 'ItemView',
                            'TotalTimeImpactValue': 156.23,
                            'TotalActionTypeImpactValue': 679.21,
                            'TotalValue': 835.44,
                            'TotalActionCount': 78
                        }
                    ]
                }
            ]
        }";

        protected readonly HttpResponseMessage validHttpResponseMessageForGetByBrandAndStoreAsync = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK,
            Content = new MockedJsonContent(validAPIResponseForGetByBrandAndStoreAsync)
        };

        [TestMethod, TestCategory("TrendingItemClient"), TestCategory("GetByBrandAndStoreAsync"), TestCategory("HTTP.GET")]
        public async Task GetForByBrandAndStoreAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (TrendingItemClient c) => c.GetByBrandAndStoreAsync(1, 1, 1, true),
                validHttpResponseMessageForGetByBrandAndStoreAsync,
                validAPIResponseForGetByBrandAndStoreAsync
                );
        }

        [TestMethod, TestCategory("TrendingItemClient"), TestCategory("GetByBrandAndStoreAsync"), TestCategory("HTTP.GET")]
        public async Task GetForByBrandAndStoreAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (TrendingItemClient c) => c.GetByBrandAndStoreAsync(1, 1, 1, true),
                HttpMethod.Get
                );
        }

        [TestMethod, TestCategory("TrendingItemClient"), TestCategory("GetByBrandAndStoreAsync"), TestCategory("HTTP.GET")]
        public async Task GetForByBrandAndStoreAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (TrendingItemClient c) => c.GetByBrandAndStoreAsync(1, 1, 1, true),
              string.Format("/catalog/trendingitems?top={0}&brandId={1}&storeId={2}&includeActionDetails={3}", 1, 1, 1, true));
        }

        [TestMethod, TestCategory("TrendingItemClient"), TestCategory("GetByBrandAndStoreAsync"), TestCategory("HTTP.GET")]
        public async Task GetForByBrandAndStoreAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (TrendingItemClient c) => c.GetByBrandAndStoreAsync(-1, 1, 1, true),
              new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", "top",1)));

            await base.SDKExceptionResponseTestAsync(
              (TrendingItemClient c) => c.GetByBrandAndStoreAsync(1, -1, 1, true),
              new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", "brandId", 1)));

            await base.SDKExceptionResponseTestAsync(
              (TrendingItemClient c) => c.GetByBrandAndStoreAsync(1, 1, -1, true),
              new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", "storeId", 1)));
        
        }

        [TestMethod, TestCategory("TrendingItemClient"), TestCategory("GetByBrandAndStoreAsync"), TestCategory("HTTP.GET")]
        public async Task GetForByBrandAndStoreAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (TrendingItemClient c) => c.GetByBrandAndStoreAsync(1, 1, 1, true));
        }
        #endregion

    }
}
