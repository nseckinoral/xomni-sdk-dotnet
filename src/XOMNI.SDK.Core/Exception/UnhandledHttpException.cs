using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace XOMNI.SDK.Core.Exception
{
    public class UnhandledHttpException : ExceptionBase
    {
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
