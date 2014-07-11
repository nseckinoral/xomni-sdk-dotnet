using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Tests.Private.Metering.Log.MeteringEntities
{
    public class AddedWishlistItemMeteringEntity : BaseMeteringEntity
    {
        public Guid UniqueKey { get; set; }
        public int WishlistId { get; set; }
        public string AddedWishlistName { get; set; }
        public string BluetoothId { get; set; }
        public Guid WishlistUniqueKey { get; set; }
        public int ItemId { get; set; }
        public string ItemTitle { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public int? AddedStoreId { get; set; }
        public string AddedStoreName { get; set; }
        public string WishlistOwnerName { get; set; }
        public string WishlistOwnerUserName { get; set; }
        public int WishlistOwnerUserTypeId { get; set; }
        public string WishlistOwnerUserTypeDescription { get; set; }
        public int ApiUserId { get; set; }
        public string ApiUsername { get; set; }
        public bool WishlistIsPublic { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public string BrandName { get; set; }


        public AddedWishlistItemMeteringEntity(DateTime meteringDate)
            : base(meteringDate)
        {

        }
        public AddedWishlistItemMeteringEntity()
        {

        }
    }
}
