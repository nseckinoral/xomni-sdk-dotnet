using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Catalog
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int SubCategoryCount { get; set; }

        public IEnumerable<Metadata> CategoryMetadata { get; set; }
        public int? ParentCategoryId { get; set; }
        public string ParentCategoryName { get; set; }

    }

    //Used to return a full tree of categories.
    public class CategoryTree<T> where T : CategoryTreeItem
    {
        public List<T> Categories { get; set; }
    }

    //Used to list a full tree of categories.
    public class CategoryTreeItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public List<Metadata> CategoryMetadata { get; set; }
    }
}
