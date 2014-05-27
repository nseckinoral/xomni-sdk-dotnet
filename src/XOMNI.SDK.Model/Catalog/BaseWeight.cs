using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Catalog
{
    public abstract class BaseWeight
    {
        public int WeightTypeId { get; set; }
        public string WeightTypeDescription { get; set; }
        public double? Value { get; set; }
    }
}
