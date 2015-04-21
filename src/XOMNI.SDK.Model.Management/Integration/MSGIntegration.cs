using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Management.Integration
{
    public class MSGIntegration
    {
        public string Email { get; set; }
        public string SsoUrl { get; set; }
        public string SubscriptionKey { get; set; }
        public IEnumerable<string> Endpoints { get; set; }
    }
}
