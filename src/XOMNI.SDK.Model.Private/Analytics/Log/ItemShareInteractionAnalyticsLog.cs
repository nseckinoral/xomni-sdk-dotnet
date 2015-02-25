using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Private.Analytics.Log
{
    public class ItemShareInteractionAnalyticsLog : BaseAnalyticsLog
    {
        public int TargetPostId { get; set; }
        public int RelatedItemId { get; set; }
        public string Content { get; set; }
        public int TargetCommentId { get; set; }
    }
}
