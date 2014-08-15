using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Private.Catalog
{
    [Flags]
    public enum DynamicAttributeTypeOptions : byte
    {
        NotInitialized = 0,
        Retrievable = 1,
        Filterable = 2,
        Searchable = 4,
        Facetable = 8,
        Sortable = 16,
    }
}
