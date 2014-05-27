using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Social
{
    public class SocialComment : SocialContent
    {
        public int TargetPostId { get; set; }
        public int TargetCommentId { get; set; }

        public SocialComment()
        {
            AvailablePlatforms = new List<SocialInteractionStatus>();
        }
    }
}
