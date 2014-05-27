using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Core.ApiAccess;

namespace XOMNI.SDK.Management.ApiAccess.Storage
{
    public class Assets : CRUDApiAccessBase<Model.Management.Storage.Asset>
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/management/storage/asset/{0}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/management/storage/assets"; }
        }
    }
}
