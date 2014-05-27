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

        public async Task<LoyaltyUserMetadata> AddMetadataAsync(int loyaltyUserId, string metadataKey, string metadataValue)
        {
            var metadata = CreateLoyaltyUserMetadata(loyaltyUserId, metadataKey, metadataValue);
            var createdMetadata = await loyaltyMetadataApi.AddMetadataAsync(metadata, this.ApiCredential);
            return createdMetadata;
        }

        public async Task DeleteMetadataAsync(int loyaltyUserId, string metadataKey)
        {
            if (String.IsNullOrEmpty(metadataKey))
            {
                throw new ArgumentNullException("metadataKey");
            }
            await loyaltyMetadataApi.DeleteMetadataAsync(loyaltyUserId, metadataKey, this.ApiCredential);
        }

        public async Task ClearMetadataAsync(int loyaltyUserId)
        {
            await loyaltyMetadataApi.ClearMetadataAsync(loyaltyUserId, this.ApiCredential);
        }

        public async Task<List<LoyaltyUserMetadata>> GetAllMetadataAsync(int loyaltyUserId)
        {
            List<LoyaltyUserMetadata> categoryMetadataList = await loyaltyMetadataApi.GetAllMetadataAsync(loyaltyUserId, this.ApiCredential);
            return categoryMetadataList;
        }

        public async Task<LoyaltyUserMetadata> UpdateMetadataAsync(int loyaltyUserId, string metadataKey, string updatedMetadataValue)
        {
            var metadata = CreateLoyaltyUserMetadata(loyaltyUserId, metadataKey, updatedMetadataValue);
            LoyaltyUserMetadata updatedMetadata = await loyaltyMetadataApi.UpdateMetadataAsync(metadata, this.ApiCredential);
            return updatedMetadata;
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
