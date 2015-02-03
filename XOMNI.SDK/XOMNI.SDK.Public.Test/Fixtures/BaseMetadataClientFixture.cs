using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;

namespace XOMNI.SDK.Public.Test.Fixtures
{
    public class BaseMetadataClientFixture<TClient> : BaseClientFixture<TClient> where TClient : BaseClient
    {
        protected async Task MetadataResponseParseTestAsync(Func<TClient, Task<ApiResponse<List<Metadata>>>> actAsync, HttpResponseMessage mockedHttpResponseMessage, string validAPIResponseJson)
        {
            await base.ResponseParseTestAsync<ApiResponse<List<Metadata>>>(actAsync, mockedHttpResponseMessage, validAPIResponseJson);
        }
    }
}
