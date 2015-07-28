using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients.Analytics;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Analytics;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.Analytics
{
    [TestClass]
    public class ClientSideAnalyticsClientFixture : BaseClientFixture<ClientSideAnalyticsClient>
    {
        const string validAPIRequestJson = @"
            [
                {  
                    'CounterName':'Sample CounterName',
                    'CreatedDate':'2015-02-25T11:13:10.582049+02:00',
                    'Value':1,
                    'DataBag':'Sample DataBag'
                }
            ]
        ";

        readonly List<ClientLog> sampleClientLog = new List<ClientLog>()
        {
            new ClientLog()
            {
                CounterName = "Sample CounterName",
                CreatedDate = DateTime.Parse("2015-02-25T11:13:10.582049+02:00"),
                DataBag = "Sample DataBag",
                Value = 1
            }
        };

        #region PostAsync

        [TestMethod, TestCategory("ClientSideAnalyticsClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncRequestParseTest()
        {
            Expression<Func<ClientSideAnalyticsClient, Task>> actExpression = (ClientSideAnalyticsClient c) => c.PostAsync(sampleClientLog);
            await base.RequestParseTestAsync<List<ClientLog>>(actExpression);
        }

        [TestMethod, TestCategory("ClientSideAnalyticsClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (ClientSideAnalyticsClient c) => c.PostAsync(sampleClientLog), HttpMethod.Post);
        }

        [TestMethod, TestCategory("ClientSideAnalyticsClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (ClientSideAnalyticsClient c) => c.PostAsync(sampleClientLog), "/analytics/clientlogs");
        }

        [TestMethod, TestCategory("ClientSideAnalyticsClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (ClientSideAnalyticsClient p) => p.PostAsync(null),
              new ArgumentNullException(string.Format("{0} can not be null.", "clientLogs")));

            await base.SDKExceptionResponseTestAsync(
              (ClientSideAnalyticsClient p) => p.PostAsync(new List<ClientLog>()
                  {
                      new ClientLog()
                      {
                          CounterName = "",
                          Value = 1
                      }
                  }),
              new ArgumentException(string.Format("{0} can not be empty or null.", "CounterName")));

            await base.SDKExceptionResponseTestAsync(
             (ClientSideAnalyticsClient p) => p.PostAsync(new List<ClientLog>()
                 {
                     new ClientLog()
                     {
                         CounterName = "CounterName",
                         Value = -4
                     }
                 }),
            new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", "Value", 1)));
        }

        [TestMethod, TestCategory("ClientSideAnalyticsClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (ClientSideAnalyticsClient p) => p.PostAsync(sampleClientLog));
        }

        [TestMethod, TestCategory("ClientSideAnalyticsClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (ClientSideAnalyticsClient c) => c.PostAsync(sampleClientLog),
              badRequestHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("ClientSideAnalyticsClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncNotImplementedTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotImplemented;

            await base.APIExceptionResponseTestAsync(
              (ClientSideAnalyticsClient c) => c.PostAsync(sampleClientLog),
              notImplementedHttpResponseMessage,
              expectedExceptionResult);
        }

        #endregion
    }
}
