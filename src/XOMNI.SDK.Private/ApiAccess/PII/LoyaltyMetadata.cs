using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model.Private.PII;

namespace XOMNI.SDK.Private.ApiAccess.PII
{
    internal class LoyaltyMetadata : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/pii/loyaltymetadata"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/pii/loyaltymetadata"; }
        }

        public Task<LoyaltyUserMetadata> AddMetadataAsync(LoyaltyUserMetadata loyaltyUserMetadata, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync<LoyaltyUserMetadata>(GenerateUrl(SingleOperationBaseUrl), loyaltyUserMetadata, credential);
        }

        public Task DeleteMetadataAsync(int loyaltyUserId, string metadataKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("loyaltyUserId", loyaltyUserId.ToString());
            additionalParameters.Add("metadataKey", metadataKey);

            return HttpProvider.DeleteAsync(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential);
        }

        public Task ClearMetadataAsync(int loyaltyUserId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("loyaltyUserId", loyaltyUserId.ToString());

            return HttpProvider.DeleteAsync(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

        public Task<List<LoyaltyUserMetadata>> GetAllMetadataAsync(int loyaltyUserId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("loyaltyUserId", loyaltyUserId.ToString());
            return HttpProvider.GetAsync<List<LoyaltyUserMetadata>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

        public Task<LoyaltyUserMetadata> UpdateMetadataAsync(LoyaltyUserMetadata loyaltyUserMetadata, ApiBasicCredential credential)
        {
            return HttpProvider.PutAsync<LoyaltyUserMetadata>(GenerateUrl(SingleOperationBaseUrl), loyaltyUserMetadata, credential);
        }
    }
}
