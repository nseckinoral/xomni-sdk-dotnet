using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Private.Catalog
{
    public class DynamicAttributeType : SDK.Model.Catalog.DynamicAttributeType
    {
        public DynamicAttributeTypeOptions Options { get; set; }
        public string DataType { get; set; }
    }
}
