using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Core.Common;

namespace XOMNI.SDK.Core.ApiAccess
{
    public abstract class ApiAccessBase
    {
        protected abstract string SingleOperationBaseUrl { get; }
        protected abstract string ListOperationBaseUrl { get; }

        protected virtual string GenerateUrl(string baseUrl, System.Collections.Generic.Dictionary<string, string> additionalQueryString = null)
        {
            string schema = Configuration.Configuration.UseHttps ? Constants.HttpsUriFormat : Constants.HttpUriFormat;
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat(schema, Configuration.Configuration.Host);
            builder.Append(baseUrl);

            if (additionalQueryString != null)
            {
                builder.Append("?");
                foreach (var key in additionalQueryString.Keys)
                {
                    builder.AppendFormat("{0}={1}", Uri.EscapeUriString(key), Uri.EscapeUriString(additionalQueryString[key]));
                    builder.Append("&");
                }
            }

            return builder.ToString().TrimEnd('&');
        }
    }
}
