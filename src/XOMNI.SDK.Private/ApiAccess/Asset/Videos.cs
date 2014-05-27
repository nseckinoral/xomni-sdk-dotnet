using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Private.ApiAccess.Asset
{
    internal class Videos : AssetBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/asset/videos"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/asset/videos"; }
        }
    }
}
