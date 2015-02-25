using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Private.Analytics.Log
{
    public class WishlistByLastAccessedDateAnalyticsLog : BaseAnalyticsLog
    {
        public string WishlistName { get; set; }
        public bool IsPublic { get; set; }
        public string WishlistOwnerName { get; set; }
        public string WishlistOwnerUserName { get; set; }
        public int WishlistOwnerUserTypeId { get; set; }
        public string WishlistOwnerUserTypeDescription { get; set; }
        public int ApiUserId { get; set; }
        public string ApiUsername { get; set; }
        public int? StoredId { get; set; }
        public string StoreName { get; set; }
        public Guid WishlistUniqueKey { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public int WishlistOwnerUserId { get; set; }
    }
}
