using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Private.PII
{
    public class PIIUser : XOMNI.SDK.Model.PII.BasePIIUser
    {
        public int Id { get; set; }
        public int PIIUserTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int InitiatedSocialLikeCount { get; set; }
    }
}
