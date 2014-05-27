using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Catalog
{
    public abstract class BaseItemSearchResult
    {
        public List<DynamicAttribute> DynamicNavigation { get; set; }
        public StaticNavigation StaticNavigation { get; set; }
    }
}
