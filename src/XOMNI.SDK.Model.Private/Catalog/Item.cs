using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model.Catalog;

namespace XOMNI.SDK.Model.Private.Catalog
{
    public class Item : BaseItem
    {
        public int Id { get; set; }
        public string RFID { get; set; }
        public string UUID { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public double? Rating { get; set; }
        public int? LikeCount { get; set; }
        public virtual DateTime? DateAdded { get; set; }
        public virtual DateTime? DateModified { get; set; }
        public int? ItemStatusId { get; set; }
        public int? CategoryId { get; set; }
        public bool InStock { get; set; }
        public string PublicWebLink { get; set; }
        public int? DefaultItemId { get; set; }
        public int? BrandId { get; set; }
        public int? UnitTypeId { get; set; }
        public List<DynamicAttribute> DynamicAttributes { get; set; }
        public List<Price> Prices { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Weight> Weights { get; set; }
        public List<Dimension> Dimensions { get; set; }
        public List<Metadata> Metadata { get; set; }

        public Item()
        {
            DynamicAttributes = new List<DynamicAttribute>();
            Prices = new List<Price>();
            Tags = new List<Tag>();
            Weights = new List<Weight>();
            Dimensions = new List<Dimension>();
            Metadata = new List<Metadata>();
        }
    }
}
