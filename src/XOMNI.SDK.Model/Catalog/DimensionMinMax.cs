﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Catalog
{
    public class DimensionMinMax : MinMax<double?>
    {
        public int DimensionTypeId { get; set; }
        public string DimensionTypeDescription { get; set; }
    }
}
