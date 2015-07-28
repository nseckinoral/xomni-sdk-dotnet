using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients.Company;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.Company
{
    [TestClass]
    public class StoreClientFixture : BaseClientFixture<StoreClient>
    {
        const string validAPIResponseForGetAsync = @"{
           'Data':{
              'Results':[
                 {
                    'Id':25,
                    'Description':'Test Store 1 Description',
                    'Location':{
                       'Longitude':41.034973,
                       'Latitude':28.992459
                    },
                    'Name':'Test Store 1',
                    'Address':'Test Store 1 Detailed Address'
                 },
                 {
                    'Id':26,
                    'Description':'Test Store 2 Description',
                    'Location':{
                       'Longitude':41.034948,
                       'Latitude':28.992024
                    },
                    'Name':'Test Store 2',
                    'Address':'Test Store 2 Detailed Address'
                 }
              ],
              'TotalCount':4
           }
        }";

        readonly Location location = new Location()
        {
            Latitude = 28.970034,
            Longitude = 41.038473
        };

        #region GetAsync

        [TestMethod, TestCategory("StoreClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (StoreClient p) => p.GetAsync(location,1,1,1));
        }

        [TestMethod, TestCategory("StoreClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (StoreClient p) => p.GetAsync(location, 1, 1, 1),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("StoreClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (StoreClient p) => p.GetAsync(location, 1, 1, 1),
              "/company/stores?locationInfo=41.038473;28.970034&searchDistance=1&skip=1&take=1");
        }

        [TestMethod, TestCategory("StoreClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (StoreClient p) => p.GetAsync(location, 1, 1, 1),
              notFoundHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("StoreClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncLocationInfoNullTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (StoreClient p) => p.GetAsync(null, 1, 1, 1),
                new ArgumentNullException("locationInfo can not be null."),
                piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("StoreClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncLocationInfoPropertyRangeTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (StoreClient p) => p.GetAsync(new Location() 
                {
                    Latitude = 91,
                    Longitude = 50
                }, 1, 1, 1),
                new ArgumentOutOfRangeException("Latitude", 91, string.Format("{0} must be in range ({1} - {2}).", "Latitude", -90, 90)),
                piiUser: piiUser
            );

            await base.SDKExceptionResponseTestAsync(
                 (StoreClient p) => p.GetAsync(new Location()
                 {
                     Latitude = 90,
                     Longitude = 182
                 }, 1, 1, 1),
                 new ArgumentOutOfRangeException("Longitude", 182, string.Format("{0} must be in range ({1} - {2}).", "Longitude", -180, 180)),
                 piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("StoreClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncSearchDistanceTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (StoreClient p) => p.GetAsync(location,2,1,1),
                new ArgumentOutOfRangeException("searchDistance", 2, string.Format("{0} must be in range ({1} - {2}).", "searchDistance", 0, 1)),
                piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("StoreClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncSkipTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (StoreClient p) => p.GetAsync(location, 1, -1, 1),
                new ArgumentException("skip must be greater than or equal to 0."),
                piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("StoreClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncTakeTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (StoreClient p) => p.GetAsync(location, 1, 1, 0),
                new ArgumentOutOfRangeException("take", 0, string.Format("{0} must be in range ({1} - {2}).", "take", 1, 1000)),
                piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("StoreClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (StoreClient p) => p.GetAsync(location, 1, 1, 1),
              badRequestHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("StoreClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (StoreClient p) => p.GetAsync(location, 1, 1, 1));
        }
        #endregion
    }

}
