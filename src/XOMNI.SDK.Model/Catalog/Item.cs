using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Catalog
{
    public class Item : ItemStaticProperties
    {
        public List<DynamicAttribute> DynamicAttributes { get; set; }

        public Item()
        {
            DynamicAttributes = new List<DynamicAttribute>();
        }
    }
}
