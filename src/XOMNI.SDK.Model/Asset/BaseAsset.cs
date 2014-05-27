using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Asset
{
    public abstract class BaseAsset
    {
        public int AssetId { get; set; }
        public string AssetUrl { get; set; }
    }
}
