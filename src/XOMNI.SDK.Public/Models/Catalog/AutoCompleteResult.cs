﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Public.Models.Catalog
{
    public class AutoCompleteResult
    {
        public string SearchTerm { get; set; }
        public AutoCompleteSearchType SearchType { get; set; }
        public List<AutoCompleteResultItem> Results { get; set; }
    }
}
