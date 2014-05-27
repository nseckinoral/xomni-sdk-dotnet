using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Private.Metering.Log
{
    public class ShoppingCartByCreatedDateMeteringLog : BaseMeteringLog
    {
        public string ShoppingCartName { get; set; }
        public bool IsPublic { get; set; }
        public string OwnerName { get; set; }
        public string OwnerUserName { get; set; }
        public int OwnerUserTypeId { get; set; }
        public string OwnerUserTypeDescription { get; set; }
        public int ApiUserId { get; set; }
        public string CreatedApiUsername { get; set; }
        public int? StoredId { get; set; }
        public string StoreName { get; set; }
        public Guid UniqueKey { get; set; }
    }
}
