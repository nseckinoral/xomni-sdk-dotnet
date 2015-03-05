using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Public.Models.Catalog
{
    public class ItemSearchRequest : SearchRequest
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public OrderedProperty? OrderedPropertyName { get; set; }
        public OrderByType? OrderBy { get; set; }
        public virtual bool IncludeStaticNavigation { get; set; }
        public virtual bool IncludeDynamicNavigation { get; set; }
        public List<int> ItemIds { get; set; }
    }
}
