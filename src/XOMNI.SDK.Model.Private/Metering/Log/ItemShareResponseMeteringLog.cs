using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Private.Metering.Log
{
    public class ItemShareResponseMeteringLog : BaseMeteringLog
    {
        public int TargetPostId { get; set; }
        public string Content { get; set; }
        public string AuthorName { get; set; }
        public int SocialPlatformId { get; set; }
        public string PlatformDependentId { get; set; }
    }
}
