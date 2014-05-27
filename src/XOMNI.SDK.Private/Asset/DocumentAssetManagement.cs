using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Private.ApiAccess.Asset;

namespace XOMNI.SDK.Private.Asset
{
    public class DocumentAssetManagement : AssetManagement
    {
        internal override ApiAccess.AssetBase AssetApi
        {
            get { return new Documents(); }
        }
    }
}
