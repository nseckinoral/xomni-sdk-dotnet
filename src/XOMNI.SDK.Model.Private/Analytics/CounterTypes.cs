using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Private.Analytics
{
    public enum CounterTypes
    {
        WishlistByCreatedDate = 1,
        WishlistByLastAccessedDate,
        AddedWishlistItem,
        RemovedWishlistItem,
        ShoppingCartByCreatedDate,
        ShoppingCartByLastAccessedDate,
        AddedShoppingCartItem,
        RemovedShoppingCartItem,
        ItemView,
        ItemLike,
        ItemShare,
        ItemShareResponse,
        ItemShareInteraction,
        OmniShare,
        OmniShareFromCustomerDeviceToCustomerDevice,
        OmniShareFromCustomerDeviceToInStoreDevice,
        OmniShareFromInStoreDeviceToCustomerDevice,
        OmniShareFromInStoreDeviceToInStoreDevice,
        TrendingItem,
        /// <summary>
        /// Client value can only be used in client analytics methods.
        /// </summary>
        Client,
    }
}
