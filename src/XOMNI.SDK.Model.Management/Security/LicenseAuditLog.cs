using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Management.Security
{
    public class LicenseAuditLog
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string CreatedApiUserName { get; set; }
        public string DeletedApiUserName { get; set; }
    }
}
