using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Private.Analytics.Log
{
    public class ShoppingCartByLastAccessedDateAnalyticsLog : BaseAnalyticsLog
    {
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public string ShoppingCartOwnerName { get; set; }
        public string ShoppingCartOwnerUserName { get; set; }
        public int ShoppingCartOwnerUserTypeId { get; set; }
        public string ShoppingCartOwnerUserTypeDescription { get; set; }
        public int ApiUserId { get; set; }
        public string ApiUsername { get; set; }
        public int? StoredId { get; set; }
        public string StoreName { get; set; }
        public Guid UniqueKey { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public int ShoppingCartOwnerUserId { get; set; }
    }
}
