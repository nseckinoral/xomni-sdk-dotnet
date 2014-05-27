using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Model.Catalog;

namespace XOMNI.SDK.Model.Private.Catalog
{
    public class ItemSearchResponse : Model.Catalog.Item
    {
        public List<Tag> Tags { get; set; }
        public List<Price> Prices { get; set; }
        public List<Weight> Weights { get; set; }
        public List<Dimension> Dimensions { get; set; }
        public List<SDK.Model.Private.Asset.Asset> ImageAssets { get; set; }
        public List<SDK.Model.Private.Asset.Asset> VideoAssets { get; set; }
        public List<SDK.Model.Private.Asset.Asset> DocumentAssets { get; set; }

        public ItemSearchResponse()
        {
            Prices = new List<Price>();
            Tags = new List<Tag>();
            Weights = new List<Weight>();
            Dimensions = new List<Dimension>();
        }
    }
}
