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

        public async Task<LoyaltyUserMetadata> AddMetadataAsync(LoyaltyUserMetadata loyaltyUserMetadata, ApiBasicCredential credential)
        {
            return await HttpProvider.PostAsync<LoyaltyUserMetadata>(GenerateUrl(SingleOperationBaseUrl), loyaltyUserMetadata, credential);
        }

        public async Task DeleteMetadataAsync(int loyaltyUserId, string metadataKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("loyaltyUserId", loyaltyUserId.ToString());
            additionalParameters.Add("metadataKey", metadataKey);

            await HttpProvider.DeleteAsync(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential);
        }

        public async Task ClearMetadataAsync(int loyaltyUserId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("loyaltyUserId", loyaltyUserId.ToString());

            await HttpProvider.DeleteAsync(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

        public async Task<List<LoyaltyUserMetadata>> GetAllMetadataAsync(int loyaltyUserId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("loyaltyUserId", loyaltyUserId.ToString());
            List<LoyaltyUserMetadata> loyaltyMetadataList = await HttpProvider.GetAsync<List<LoyaltyUserMetadata>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
            return loyaltyMetadataList;
        }

        public async Task<LoyaltyUserMetadata> UpdateMetadataAsync(LoyaltyUserMetadata loyaltyUserMetadata, ApiBasicCredential credential)
        {
            return await HttpProvider.PutAsync<LoyaltyUserMetadata>(GenerateUrl(SingleOperationBaseUrl), loyaltyUserMetadata, credential);
        }
    }
}
