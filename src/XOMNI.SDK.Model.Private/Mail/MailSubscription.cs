using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Private.Mail
{
    public class MailSubscription
    {
        public string PIIName { get; set; }
        public MailSubscriptionStatus StatusId { get; set; }
        public MailSubscriptionPurposeType PurposeTypeId { get; set; }
        public bool IsSubscribable { get; set; }
    }
}
