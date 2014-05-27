using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Catalog
{
    public class MultipleItemSearchResult<T> : BaseItemSearchResult where T : BaseItem
    {
        public List<T> Items { get; set; }
        public int TotalItemCount { get; set; }
    }
}
