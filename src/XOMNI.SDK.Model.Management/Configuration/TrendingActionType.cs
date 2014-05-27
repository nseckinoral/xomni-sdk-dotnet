using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Management.Configuration
{
    public enum TrendingActionType : byte
    {
        SocialLike = 1,
        SocialShare = 2,
        ShoppingCartItemIInsert = 3,
        WishlistItemInsert = 4,
        ItemView = 5
    }
}
