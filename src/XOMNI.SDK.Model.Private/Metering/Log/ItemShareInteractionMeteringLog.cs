using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Private.Metering.Log
{
    public class ItemShareInteractionMeteringLog : BaseMeteringLog
    {
        public int TargetPostId { get; set; }
        public int RelatedItemId { get; set; }
        public string Content { get; set; }
        public int TargetCommentId { get; set; }
    }
}
