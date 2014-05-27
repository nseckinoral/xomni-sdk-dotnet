using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Core.Exception
{
    public abstract class ExceptionBase : System.Exception
    {
        public Guid IdentifierGuid { get; set; }
        public long IdentifierTick { get; set; }
        public string FriendlyDescription { get; set; }

        public static T Create<T>(string json) where T : ExceptionBase
        {
            dynamic exception = Activator.CreateInstance<T>();

            try
            {
                var errorResponse = JObject.Parse(json);
                exception.IdentifierGuid = Guid.Parse(errorResponse.Value<string>("IdentifierGuid"));
                exception.IdentifierTick = errorResponse.Value<long>("IdentifierTick");
                exception.FriendlyDescription = errorResponse.Value<string>("FriendlyDescription");
            }
            catch (System.Exception)
            {

            }
            return exception;
        }
    }
}
