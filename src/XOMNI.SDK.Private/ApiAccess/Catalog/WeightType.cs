using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Core.ApiAccess;

namespace XOMNI.SDK.Private.ApiAccess.Catalog
{
    internal class WeightType : CRUDApiAccessBase<Model.Catalog.WeightType>
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/weighttype/{0}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/weighttypes"; }
        }
    }
}
