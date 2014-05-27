using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model;
using XOMNI.SDK.Model.Catalog;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.ApiAccess.Catalog
{
    internal class Tag : CRUDApiAccessBase<Model.Catalog.Tag>
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/tag/{0}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/tags"; }
        }
    }
}
