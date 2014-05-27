using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model.Asset;

namespace XOMNI.SDK.Model.Public.Asset
{
    public class Asset : BaseAsset
    {
        public IEnumerable<Metadata> AssetMetadata { get; set; }
    }
}
