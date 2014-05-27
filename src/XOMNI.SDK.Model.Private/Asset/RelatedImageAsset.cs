using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Private.Asset
{
    public class RelatedImageAsset : RelatedAsset
    {
        public List<ResizedAsset> ResizedAssets { get; set; }
        public bool Resizeable { get; set; }
    }
}
