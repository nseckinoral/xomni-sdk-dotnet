using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Private.ApiAccess.Catalog;

namespace XOMNI.SDK.Private.Catalog
{
    public class VideoManagement : BaseAssetManagement
    {
        public VideoManagement()
            : base(new VideoMetadata())
        {

        }
    }
}
