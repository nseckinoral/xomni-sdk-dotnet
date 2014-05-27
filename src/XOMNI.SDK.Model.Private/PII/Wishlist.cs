using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Private.PII
{
    public class Wishlist : XOMNI.SDK.Model.PII.BaseWishList
    {
        public int Id { get; set; }
        public DateTime LastModificationDate { get; set; }
        public DateTime LastAccessDateTime { get; set; }
        public int LastAccessedApiUserId { get; set; }
        public List<WishlistItem> WishlistItems { get; set; }
        public Location LastSeenLocation { get; set; }
        public bool IsPublic { get; set; }
    }
}
