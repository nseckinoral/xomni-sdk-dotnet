using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Private.Mail
{
    public enum MailSubscriptionStatus
    {
        Subscribed = 1,
        Unsubscribed,
        UnsubscribedLimitReached,
        Bounced
    }
}
