﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Catalog
{
    public class ItemStaticProperties : BaseItem
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
        public int? ItemStatusId { get; set; }
        public int? CategoryId { get; set; }
        public bool InStock { get; set; }
        public string PublicWebLink { get; set; }
        public int? DefaultItemId { get; set; }
        public int? BrandId { get; set; }
        public int? UnitTypeId { get; set; }
        public string UnitTypeName { get; set; }
        public string UnitTypeCode { get; set; }
        public bool HasVariants { get; set; }
    }
}
