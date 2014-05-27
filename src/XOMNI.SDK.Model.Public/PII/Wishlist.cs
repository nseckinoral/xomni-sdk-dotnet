using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Public.PII
{
    public class Wishlist : XOMNI.SDK.Model.PII.BaseWishList
    {
        public List<WishlistItemInfo> WishlistItems { get; set; }
        public Location LastSeenLocation { get; set; }
        public bool IsPublic { get; set; }
    }
}
