using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Core.ApiAccess;

namespace XOMNI.SDK.Private.ApiAccess.Catalog
{
    internal class DimensionType : CRUDApiAccessBase<Model.Catalog.DimensionType>
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/dimensiontype/{0}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/dimensiontypes"; }
        }
    }
}
