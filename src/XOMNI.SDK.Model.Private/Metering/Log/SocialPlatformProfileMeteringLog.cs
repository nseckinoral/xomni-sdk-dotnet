using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Private.Metering.Log
{
    public class SocialPlatformProfileMeteringLog
    {
        public string Id { get; set; }
        public virtual string PhotoUrl { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
