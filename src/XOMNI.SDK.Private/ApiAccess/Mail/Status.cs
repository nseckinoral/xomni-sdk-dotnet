using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model.Private.Mail;

namespace XOMNI.SDK.Private.ApiAccess.Mail
{
    public class Status : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/mail/subscription/{0}/status"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        public Task<MailSubscription> GetAsync(string emailAddress, ApiBasicCredential credential)
        {
            return HttpProvider.GetAsync<MailSubscription>(string.Format(SingleOperationBaseUrl, emailAddress), credential);
        }

        public Task PutAsync(string emailAddress, MailSubscriptionStatus subscriptionStatus, ApiBasicCredential credential)
        {
            return HttpProvider.PutAsync(string.Format(SingleOperationBaseUrl, emailAddress), new { StatusId = (int)subscriptionStatus}, credential);
        }

        public XOMNIRequestMessage<MailSubscription> CreateGetRequest(string emailAddress, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<MailSubscription>(HttpProvider.CreateGetRequest(string.Format(SingleOperationBaseUrl, emailAddress), credential));
        }

        public XOMNIRequestMessage CreatePutRequest(string emailAddress, MailSubscriptionStatus subscriptionStatus, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage(HttpProvider.CreatePutRequest(string.Format(SingleOperationBaseUrl, emailAddress), credential, new { StatusId = (int)subscriptionStatus }));
        }
    }
}
