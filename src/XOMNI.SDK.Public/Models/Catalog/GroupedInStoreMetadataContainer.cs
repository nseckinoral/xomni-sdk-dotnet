using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Models.Company;

namespace XOMNI.SDK.Public.Models.Catalog
{
    public class GroupedInStoreMetadataContainer : Store
    {
        public List<InStoreMetadata> Metadata { get; set; }
    }
}
