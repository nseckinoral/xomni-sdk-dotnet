using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model.Catalog;

namespace XOMNI.SDK.Model.Public.Catalog
{
    public class ItemStaticProperties : Model.Catalog.ItemStaticProperties
    {
        public List<Tag> Tags { get; set; }
        public List<Price> Prices { get; set; }
        public List<Weight> Weights { get; set; }
        public List<Dimension> Dimensions { get; set; }
        public List<SDK.Model.Public.Asset.Asset> ImageAssets { get; set; }
        public List<SDK.Model.Public.Asset.Asset> VideoAssets { get; set; }
        public List<SDK.Model.Public.Asset.Asset> DocumentAssets { get; set; }


        public ItemStaticProperties()
        {
            Prices = new List<Price>();
            Tags = new List<Tag>();
            Weights = new List<Weight>();
            Dimensions = new List<Dimension>();
        }
    }
}
