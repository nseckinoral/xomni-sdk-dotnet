using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Private.Metering.Log
{
    public class ItemLikeMeteringLog : BaseMeteringLog
    {
        public string TargetPlatform { get; set; }
        public int TargetPostId { get; set; }
        public int RelatedItemId { get; set; }
        public List<int> KnownPIIUserIds { get; set; }
        public List<SocialPlatformProfileMeteringLog> UnknownUserProfiles { get; set; }
        public int LikeCount { get; set; }
    }
}
