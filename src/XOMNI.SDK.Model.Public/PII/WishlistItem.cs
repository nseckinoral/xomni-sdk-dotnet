using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Public.PII
{
    public class WishlistItem : XOMNI.SDK.Model.PII.BaseWishlistItem
    {
        public Location LastSeenLocation { get; set; }
    }
}
