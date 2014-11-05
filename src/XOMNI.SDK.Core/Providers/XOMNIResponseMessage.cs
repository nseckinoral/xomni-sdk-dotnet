using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Exception;

namespace XOMNI.SDK.Core.Providers
{
    public class XOMNIResponseMessage
    {
        public bool IsSucceed { get; private set; }
        public ExceptionBase Exception { get; private set; }

        public XOMNIResponseMessage(bool isSucceed, ExceptionBase exception)
        {
            this.IsSucceed = IsSucceed;
            this.Exception = exception;
        }

    }
    public class XOMNIResponseMessage<T> : XOMNIResponseMessage
    {
        public T Result { get; set; }

        public XOMNIResponseMessage(bool isSucceed, ExceptionBase exception, T result)
            : base(isSucceed, exception)
        {
            this.Result = result;
        }
    }
}
