using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Asset
{
    public class AssetRelationMapping
    {
        public int AssetId { get; set; }
        public int RelatedId { get; set; }
        public bool IsDefault { get; set; }
    }
}
