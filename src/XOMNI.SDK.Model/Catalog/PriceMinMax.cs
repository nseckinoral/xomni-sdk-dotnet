using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Catalog
{
    public class PriceMinMax : MinMax<double?>
    {
        public int CurrencyId { get; set; }
        public string CurrencySymbol { get; set; }
    }
}
