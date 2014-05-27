using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Public.PII
{
    public class WishlistItemInfo
    {
        public List<Metadata> CategoryMetadata { get; set; }
        public Model.Catalog.BaseItem Item { get; set; }
        public string BluetoothId { get; set; }
        public DateTime DateAdded { get; set; }
        public Guid UniqueKey { get; set; }
    }
}
