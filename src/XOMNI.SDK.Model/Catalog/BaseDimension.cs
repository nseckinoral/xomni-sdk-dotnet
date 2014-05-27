using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Catalog
{
    public abstract class BaseDimension
    {
        public int DimensionTypeId { get; set; }
        public string DimensionDescription { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public double? Depth { get; set; }

        public virtual string ToString()
        {
            return this.Depth + "x" + this.Width + "x" + this.Height;
        }
    }
}
