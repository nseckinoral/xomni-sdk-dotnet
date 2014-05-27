using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model.Asset;

namespace XOMNI.SDK.Model.Private.Asset
{
    public class Asset : BaseAsset
    {
        public string ContentMimeType { get; set; }
        public string OriginalFilename { get; set; }
    }
}
