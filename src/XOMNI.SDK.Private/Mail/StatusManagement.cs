using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model.Private.Mail;
using XOMNI.SDK.Private.ApiAccess.Mail;

namespace XOMNI.SDK.Private.Mail
{
    public class StatusManagement : ManagementBase
    {
        private readonly Status mailStatusApiAccess = new Status();

        public Task<MailSubscription> GetAsync(string emailAddress)
        {
            return mailStatusApiAccess.GetAsync(emailAddress, this.ApiCredential);
        }

        public Task PutAsync(string emailAddress, MailSubscriptionStatus subscriptionStatus)
        {
            return mailStatusApiAccess.PutAsync(emailAddress, subscriptionStatus, this.ApiCredential);
        }

        public XOMNIRequestMessage<MailSubscription> CreateGetRequest(string emailAddress)
        {
            return mailStatusApiAccess.CreateGetRequest(emailAddress, this.ApiCredential);
        }

        public XOMNIRequestMessage CreatePutRequest(string emailAddress, MailSubscriptionStatus subscriptionStatus)
        {
            return mailStatusApiAccess.CreatePutRequest(emailAddress, subscriptionStatus, this.ApiCredential);            
        }
    }
}
