using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Social
{
    public class SocialPost : SocialContent
    {
        public List<SocialComment> Comments { get; set; }
        public SocialPost()
        {
            Comments = new List<SocialComment>();
            AvailablePlatforms = new List<SocialInteractionStatus>();
        }
    }
}
