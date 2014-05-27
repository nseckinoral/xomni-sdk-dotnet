using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Catalog
{
    public class ItemDynamicProperties : BaseItem
    {
        public int Id { get; set; }
        public List<DynamicAttribute> DynamicAttributes { get; set; }

        public ItemDynamicProperties()
        {
            DynamicAttributes = new List<DynamicAttribute>();
        }
    }
}
