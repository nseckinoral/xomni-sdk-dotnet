using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Public.PII
{
    public class WishlistMergeRequest
    {
        public Guid SessionGuid { get; set; }
        public Guid WishlistUniqueKey { get; set; }
        public WishlistMergeType WishlistMergeType { get; set; }
        public Location GpsLocation { get; set; }
    }
}
