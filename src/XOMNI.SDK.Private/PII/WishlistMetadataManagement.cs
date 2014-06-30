using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;

namespace XOMNI.SDK.Private.PII
{
    public class WishlistMetadataManagement : ManagementBase
    {
        private XOMNI.SDK.Private.ApiAccess.PII.WishlistMetadata wishlistMetadata;
        public WishlistMetadataManagement()
        {
            wishlistMetadata = new ApiAccess.PII.WishlistMetadata();
        }
        public Task<List<Model.Private.PII.WishlistMetadata>> GetAllMetadataAsync(Guid wishlistUniqueKey)
        {
            return wishlistMetadata.GetAllMetadataAsync(wishlistUniqueKey, this.ApiCredential);
        }
        public Task<Model.Private.PII.WishlistMetadata> AddMetadataAsync(Model.Private.PII.WishlistMetadata wishlistMetadata)
        {
            return this.wishlistMetadata.AddMetadataAsync(wishlistMetadata, this.ApiCredential);
        }
        public Task<Model.Private.PII.WishlistMetadata> UpdateMetadataAsync(Model.Private.PII.WishlistMetadata wishlistMetadata)
        {
            return this.wishlistMetadata.UpdateMetadataAsync(wishlistMetadata, this.ApiCredential);
        }
        public Task DeleteMetadataAsync(Guid wishlistUniqueKey, string metadataKey)
        {
            return this.wishlistMetadata.DeleteMetadataAsync(wishlistUniqueKey, metadataKey, this.ApiCredential);
        }
        public Task ClearMetadataAsync(Guid wishlistUniqueKey)
        {
            return this.wishlistMetadata.ClearMetadataAsync(wishlistUniqueKey, this.ApiCredential);
        }
    }
}