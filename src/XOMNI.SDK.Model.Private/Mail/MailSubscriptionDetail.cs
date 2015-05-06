using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Private.Mail
{
    public class MailSubscription
    {
        public string PIIFirstLastName { get; set; }
        public MailSubscriptionStatus SubscriptionStatusId { get; set; }
        public MailSubscriptionPurposeTypeEnum PurposeTypeId { get; set; }
        public bool Subscribable { get; set; }
    }
}
