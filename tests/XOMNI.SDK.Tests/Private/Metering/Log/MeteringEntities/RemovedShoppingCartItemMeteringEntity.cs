using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Tests.Private.Metering.Log.MeteringEntities
{
    public class RemovedShoppingCartItemMeteringEntity : BaseMeteringEntity
    {
        public Guid UniqueKey { get; set; }
        public int ShoppingCartId { get; set; }
        public string RemovedShoppingCartName { get; set; }
        public string BluetoothId { get; set; }
        public Guid ShoppingCartUniqueKey { get; set; }
        public int ItemId { get; set; }
        public string ItemTitle { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public int? RemovedStoreId { get; set; }
        public string RemovedStoreName { get; set; }
        public string ShoppingCartOwnerName { get; set; }
        public string ShoppingCartOwnerUserName { get; set; }
        public int ShoppingCartOwnerUserTypeId { get; set; }
        public string ShoppingCartOwnerUserTypeDescription { get; set; }
        public int ApiUserId { get; set; }
        public string ApiUsername { get; set; }
        public bool ShoppingCartIsPublic { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public string BrandName { get; set; }


        public RemovedShoppingCartItemMeteringEntity(DateTime meteringDate)
            : base(meteringDate)
        {

        }

        public RemovedShoppingCartItemMeteringEntity()
        {

        }
    }
}
