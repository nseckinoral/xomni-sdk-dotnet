using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model;
using XOMNI.SDK.Model.Asset;
using XOMNI.SDK.Private.ApiAccess.Catalog;

namespace XOMNI.SDK.Private.Catalog
{
    public class DocumentManagement : BaseAssetManagement
    {
        public DocumentManagement()
            : base(new DocumentMetadata())
        {

        }
    }
}
