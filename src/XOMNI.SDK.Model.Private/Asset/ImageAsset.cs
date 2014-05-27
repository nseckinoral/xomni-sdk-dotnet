using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Private.Asset
{
    public class ImageAsset : Asset
    {
        public bool Resizeable { get; set; }
        public IEnumerable<ResizedAsset> ResizedAssets { get; set; }
    }
}
