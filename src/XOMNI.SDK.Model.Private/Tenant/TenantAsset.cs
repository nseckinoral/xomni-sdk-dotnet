using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Private.Tenant
{
    public class TenantAsset
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public byte[] FileBody { get; set; }
        public string PublicUrl { get; set; }
    }
}
