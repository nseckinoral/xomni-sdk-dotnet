using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Private.Metering.Log
{
    public class AddedShoppingCartItemMeteringLog : BaseMeteringLog
    {
        public Guid UniqueKey { get; set; }
        public int ShoppingCartId { get; set; }
        public string AddedShoppingCartName { get; set; }
        public string BluetoothId { get; set; }
        public Guid ShoppingCartUniqueKey { get; set; }
        public int ItemId { get; set; }
        public string ItemTitle { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public int? AddedStoreId { get; set; }
        public string AddedStoreName { get; set; }
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
        public int Quantity { get; set; }
    }
}
