using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model
{
    public class DebugInfo
    {
        public string AuthenticationSchema { get; set; }
        public string ApiVersion { get; set; }
        public string ApiUserName { get; set; }
        public string ApiUserPassword { get; set; }
        public string ApiUserFirstLastName { get; set; }
        public string TenantUserName { get; set; }
        public string TenantUserPassword { get; set; }
        public string TenantUserFirstLastName { get; set; }
        public string TenantHostName { get; set; }
        public Dictionary<string,object> PIICollection { get; set; }
    }
}
