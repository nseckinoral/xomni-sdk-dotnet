using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Tests.Private.Metering.Log.MeteringEntities
{
    public class WishlistByCreatedDateMeteringEntity : BaseMeteringEntity
    {
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public int WishlistOwnerUserId { get; set; }
        public string WishlistOwnerName { get; set; }
        public string WishlistOwnerUserName { get; set; }
        public int WishlistOwnerUserTypeId { get; set; }
        public string WishlistOwnerUserTypeDescription { get; set; }
        public int ApiUserId { get; set; }
        public string ApiUsername { get; set; }
        public int? StoredId { get; set; }
        public string StoreName { get; set; }
        public Guid UniqueKey { get; set; }

        public WishlistByCreatedDateMeteringEntity()
        {

        }

        public WishlistByCreatedDateMeteringEntity(DateTime createdDate)
            : base(createdDate)
        {

        }
    }
}
