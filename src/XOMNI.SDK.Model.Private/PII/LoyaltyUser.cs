using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Private.PII
{
    public class LoyaltyUser : XOMNI.SDK.Model.PII.LoyaltyUser
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PIIUserTypeId { get; set; }
        public int InitiatedSocialLikeCount { get; set; }
    }
}
