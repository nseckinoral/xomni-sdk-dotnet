using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.PII
{
    public class WishlistMetadataManagement : ManagementBase
    {
        private XOMNI.SDK.Private.ApiAccess.PII.WishlistMetadata wishlistMetadataApiAccess;
        public WishlistMetadataManagement()
        {
            wishlistMetadataApiAccess = new ApiAccess.PII.WishlistMetadata();
        }
        public Task<List<Model.Private.PII.WishlistMetadata>> GetAllMetadataAsync(Guid wishlistUniqueKey)
        {
            return wishlistMetadataApiAccess.GetAllMetadataAsync(wishlistUniqueKey, this.ApiCredential);
        }
        public Task<Model.Private.PII.WishlistMetadata> AddMetadataAsync(Model.Private.PII.WishlistMetadata wishlistMetadata)
        {
            return this.wishlistMetadataApiAccess.AddMetadataAsync(wishlistMetadata, this.ApiCredential);
        }
        public Task<Model.Private.PII.WishlistMetadata> UpdateMetadataAsync(Model.Private.PII.WishlistMetadata wishlistMetadata)
        {
            return this.wishlistMetadataApiAccess.UpdateMetadataAsync(wishlistMetadata, this.ApiCredential);
        }
        public Task DeleteMetadataAsync(Guid wishlistUniqueKey, string metadataKey)
        {
            return this.wishlistMetadataApiAccess.DeleteMetadataAsync(wishlistUniqueKey, metadataKey, this.ApiCredential);
        }
        public Task ClearMetadataAsync(Guid wishlistUniqueKey)
        {
            return this.wishlistMetadataApiAccess.ClearMetadataAsync(wishlistUniqueKey, this.ApiCredential);
        }

        #region Low Level Methods

        public XOMNIRequestMessage<Model.Private.PII.WishlistMetadata> CreateGetAllMetadataRequest(Guid wishlistUniqueKey)
        {
            return wishlistMetadataApiAccess.CreateGetAllMetadataRequest(wishlistUniqueKey, ApiCredential);
        }
        public XOMNIRequestMessage<Model.Private.PII.WishlistMetadata> CreateAddMetadataRequest(Model.Private.PII.WishlistMetadata wishlistMetadata)
        {
            return wishlistMetadataApiAccess.CreateAddMetadataRequest(wishlistMetadata, ApiCredential);
        }
        public XOMNIRequestMessage<Model.Private.PII.WishlistMetadata> CreateUpdateMetadataRequest(Model.Private.PII.WishlistMetadata wishlistMetadata)
        {
            return wishlistMetadataApiAccess.CreateUpdateMetadataRequest(wishlistMetadata, ApiCredential);
        }
        public XOMNIRequestMessage CreateDeleteMetadataRequest(Guid wishlistUniqueKey, string metadataKey)
        {
            return wishlistMetadataApiAccess.CreateDeleteMetadataRequest(wishlistUniqueKey, metadataKey, ApiCredential);
        }
        public XOMNIRequestMessage CreateClearMetadataRequest(Guid wishlistUniqueKey)
        {
            return wishlistMetadataApiAccess.CreateClearMetadataRequest(wishlistUniqueKey, ApiCredential);
        }
        #endregion
    }
}