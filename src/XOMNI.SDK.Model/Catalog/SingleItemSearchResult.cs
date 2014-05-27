using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Catalog
{
    public class SingleItemSearchResult<T> : BaseItemSearchResult where T : BaseItem
    {
        public T Item { get; set; }
    }
}
