﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Private.Analytics.Log
{
    public class ItemLikeAnalyticsLog : BaseAnalyticsLog
    {
        public string TargetPlatform { get; set; }
        public int TargetPostId { get; set; }
        public int RelatedItemId { get; set; }
        public List<int> KnownPIIUserIds { get; set; }
        public List<SocialPlatformProfileAnalyticsLog> UnknownUserProfiles { get; set; }
        public int LikeCount { get; set; }
    }
}
