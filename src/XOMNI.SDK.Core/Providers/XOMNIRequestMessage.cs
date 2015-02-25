using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace XOMNI.SDK.Core.Providers
{
    public class XOMNIRequestMessage
    {
        internal HttpRequestMessage requestMessage;
        internal HttpStatusCode expectedStatusCode;

        public XOMNIRequestMessage(HttpRequestMessage requestMessage, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            this.requestMessage = requestMessage;
            this.expectedStatusCode = expectedStatusCode;
        }
    }

    public class XOMNIRequestMessage<T> : XOMNIRequestMessage
    {
        public XOMNIRequestMessage(HttpRequestMessage requestMessage, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
            : base(requestMessage, expectedStatusCode)
        {

        }
        
    }
}
