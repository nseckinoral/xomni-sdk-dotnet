using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model;

namespace XOMNI.SDK.Private.ApiAccess.Catalog
{
    public class DynamicAttributeType : CRUDApiAccessBase<Model.Private.Catalog.DynamicAttributeType>
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/dynamicattributetypes/{0}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/dynamicattributetypes"; }
        }
    }
}
