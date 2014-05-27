using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Social
{
    public class SocialPlatformProfile
    {
        public string Platform { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string AvatarUrl { get; set; }
        public string SocialPlatformTokenStatus { get; set; }
    }
}
