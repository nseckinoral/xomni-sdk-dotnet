using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Model.Private.PII;
using XOMNI.SDK.Private.ApiAccess.PII;

namespace XOMNI.SDK.Private.PII
{
    public class LoyaltyManagement : BaseCRUDSkipTakeManagement<SDK.Model.Private.PII.LoyaltyUser>
    {
        private LoyaltyMetadata loyaltyMetadataApi;
        protected override Core.ApiAccess.CRUDApiAccessBase<Model.Private.PII.LoyaltyUser> ApiAccess
        {
            get { return new ApiAccess.PII.Loyalty(); }
        }

        public LoyaltyManagement()
        {
            loyaltyMetadataApi = new LoyaltyMetadata();
        }

        public Task<LoyaltyUserMetadata> AddMetadataAsync(int loyaltyUserId, string metadataKey, string metadataValue)
        {
            var metadata = CreateLoyaltyUserMetadata(loyaltyUserId, metadataKey, metadataValue);
            return loyaltyMetadataApi.AddMetadataAsync(metadata, this.ApiCredential);
        }

        public Task DeleteMetadataAsync(int loyaltyUserId, string metadataKey)
        {
            if (String.IsNullOrEmpty(metadataKey))
            {
                throw new ArgumentNullException("metadataKey");
            }
            return loyaltyMetadataApi.DeleteMetadataAsync(loyaltyUserId, metadataKey, this.ApiCredential);
        }

        public Task ClearMetadataAsync(int loyaltyUserId)
        {
            return loyaltyMetadataApi.ClearMetadataAsync(loyaltyUserId, this.ApiCredential);
        }

        public Task<List<LoyaltyUserMetadata>> GetAllMetadataAsync(int loyaltyUserId)
        {
            return loyaltyMetadataApi.GetAllMetadataAsync(loyaltyUserId, this.ApiCredential);
        }

        public Task<LoyaltyUserMetadata> UpdateMetadataAsync(int loyaltyUserId, string metadataKey, string updatedMetadataValue)
        {
            var metadata = CreateLoyaltyUserMetadata(loyaltyUserId, metadataKey, updatedMetadataValue);
            return loyaltyMetadataApi.UpdateMetadataAsync(metadata, this.ApiCredential);
        }

        private LoyaltyUserMetadata CreateLoyaltyUserMetadata(int loyaltyUserId, string metadataKey, string metadataValue)
        {
            if (String.IsNullOrEmpty(metadataKey))
            {
                throw new ArgumentNullException("metadataKey");
            }
            LoyaltyUserMetadata metadata = new LoyaltyUserMetadata()
            {
                LoyaltyUserId = loyaltyUserId,
                Key = metadataKey,
                Value = metadataValue
            };
            return metadata;
        }
    }
}
