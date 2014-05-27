using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Private.Catalog
{
    public class Category : Model.Catalog.Category
    {
    }

    //Used to return a full tree of categories.
    public class CategoryTree : Model.Catalog.CategoryTree<CategoryTreeItem>
    {
    }

    //Used to list a full tree of categories.
    public class CategoryTreeItem : Model.Catalog.CategoryTreeItem
    {
        public List<CategoryTreeItem> CategoryTreeItems { get; set; }
    }
}
