using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Public.Models.Catalog
{
    public class ItemSearchResult<T>
    {
        public ItemSearchRequest SearchRequest { get; set; }
        public T SearchResult { get; set; }
    }
}
