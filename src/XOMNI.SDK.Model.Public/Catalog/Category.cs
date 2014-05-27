using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Public.Catalog
{
    public class Category : Model.Catalog.Category
    {
    }

    public class CategoryV1_1 : Model.Catalog.Category
    {
        public IEnumerable<XOMNI.SDK.Model.Public.Asset.Asset> ImageAssets { get; set; }
        public IEnumerable<XOMNI.SDK.Model.Public.Asset.Asset> DocumentAssets { get; set; }
        public IEnumerable<XOMNI.SDK.Model.Public.Asset.Asset> VideoAssets { get; set; }
    }

    //Used to return a full tree of categories.
    public class CategoryTree : Model.Catalog.CategoryTree<CategoryTreeItem>
    {
    }

    //Used to return a full tree of categories.
    public class CategoryTreeV1_1 : Model.Catalog.CategoryTree<CategoryTreeItemV1_1>
    {
    }

    //Used to list a full tree of categories.
    public class CategoryTreeItem : Model.Catalog.CategoryTreeItem
    {
        public List<CategoryTreeItem> CategoryTreeItems { get; set; }
    }

    public class CategoryTreeItemV1_1 : Model.Catalog.CategoryTreeItem
    {
        public List<CategoryTreeItemV1_1> CategoryTreeItems { get; set; }

        public IEnumerable<XOMNI.SDK.Model.Public.Asset.Asset> ImageAssets { get; set; }
        public IEnumerable<XOMNI.SDK.Model.Public.Asset.Asset> DocumentAssets { get; set; }
        public IEnumerable<XOMNI.SDK.Model.Public.Asset.Asset> VideoAssets { get; set; }
    }
}
