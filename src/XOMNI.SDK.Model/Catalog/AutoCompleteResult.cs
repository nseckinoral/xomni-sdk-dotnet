using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Catalog
{
    public class AutoCompleteResult
    {
        public string SearchTerm { get; set; }
        public string SearchType { get; set; }
        public int TotalItemCount { get; set; }
        public int TotalBrandCount { get; set; }
        public int TotalCategoryCount { get; set; }
        public List<AutoCompleteResultItem> Results { get; set; }

        public AutoCompleteResult()
        {
            Results = new List<AutoCompleteResultItem>();
        }
    }
}
