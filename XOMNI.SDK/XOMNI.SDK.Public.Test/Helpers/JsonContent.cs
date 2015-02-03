using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Public.Test.Helpers
{
    public class MockedJsonContent : HttpContent
    {
        private readonly string jsonContent;
        public MockedJsonContent(string jsonContent)
        {
            this.jsonContent = jsonContent;
            base.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }

        protected override bool TryComputeLength(out long length)
        {
            length = -1L;
            return false;
        }

        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            var bytes = Encoding.UTF8.GetBytes(jsonContent);
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}
