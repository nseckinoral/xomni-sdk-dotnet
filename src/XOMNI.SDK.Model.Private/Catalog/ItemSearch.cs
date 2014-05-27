using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Model.Private.Catalog;

namespace XOMNI.SDK.Model.Private.Catalog
{
    public class ItemSearch : Model.Catalog.ItemSearch
    {
    }

    public class ItemSearchPrivateSDK
    {
        public ItemSearchRequest SearchRequest { get; set; }
        public MultipleItemSearchResult SearchResult { get; set; }
    }

}
