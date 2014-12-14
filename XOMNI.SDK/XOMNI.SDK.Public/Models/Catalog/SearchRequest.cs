using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Public.Models.Catalog
{
    public class SearchRequest
    {
        public object DefaultItemId { get; set; }
        public object RFID { get; set; }
        public object UUID { get; set; }
        public object Name { get; set; }
        public object SKU { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public object Model { get; set; }
        public object Title { get; set; }
        public int MinWidth { get; set; }
        public int MaxWidth { get; set; }
        public object MinHeight { get; set; }
        public object MaxHeight { get; set; }
        public object MinWeigth { get; set; }
        public object MaxWeigth { get; set; }
        public object MinDepth { get; set; }
        public object MaxDepth { get; set; }
        public int DimensionTypeId { get; set; }
        public object WeightTypeId { get; set; }
        public object MinPrice { get; set; }
        public object MaxPrice { get; set; }
        public int TagId { get; set; }
        public object DelimitedDynamicAttributeValues { get; set; }
        public bool IncludeOnlyMasterItems { get; set; }
        public object TagQuery { get; set; }
        public bool IncludePassiveItems { get; set; }
    }

}
