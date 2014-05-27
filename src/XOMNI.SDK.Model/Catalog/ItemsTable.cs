using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Catalog
{
    public class ItemCompareTable
    {
        public List<CompareTableRow> TableRows { get; set; }
    }

    public class CompareTableRow
    {
        public List<CompareTableCell> Cells { get; set; }
    }

    public class CompareRowHeader
    {
        public string Header { get; set; }
    }

    public class CompareTableCell
    {
        public string Value { get; set; }
    }

    public enum ComparableStaticColumns
    {
        Name, 
        RFID,
        UUID,
        SKU,
        Model,
        Title,
        ShortDescription,
        LongDescription,
        InStock,
        Rating,
        LikeCount,
        UnitTypeName
    }
}
