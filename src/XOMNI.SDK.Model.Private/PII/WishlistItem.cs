using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Private.PII
{
    public class WishlistItem : XOMNI.SDK.Model.PII.BaseWishlistItem
    {
        public int Id { get; set; }
        public Location LastSeenLocation { get; set; }
    }
}
