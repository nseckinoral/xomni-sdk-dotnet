using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.OmniPlay;
using XOMNI.SDK.Public.Models.PII;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures
{
    public class BaseMetadataClientFixture<TClient> : BaseClientFixture<TClient> where TClient : BaseClient
    {
        #region arrenge

        protected const string validAPIResponse = @"{
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

        protected readonly HttpResponseMessage validHttpResponseMessage = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK,
            Content = new MockedJsonContent(validAPIResponse)
        };

  

        #endregion

        protected async Task MetadataResponseParseTestAsync(Func<TClient, Task<ApiResponse<List<Metadata>>>> actAsync, HttpResponseMessage mockedHttpResponseMessage, string validAPIResponseJson, User piiUser = null, OmniSession omniSession = null)
        {
            await base.ResponseParseTestAsync<ApiResponse<List<Metadata>>>(actAsync, mockedHttpResponseMessage, validAPIResponseJson, piiUser, omniSession);
        }
    }
}
