using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.ApiAccess.PII
{
    public class WishlistMetadata : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/pii/wishlistmetadata"; }
        }
        protected override string ListOperationBaseUrl
        {
            get { return "/private/pii/wishlistmetadata"; }
        }
        public async Task<List<Model.Private.PII.WishlistMetadata>> GetAllMetadataAsync(Guid wishlistUniqueKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>
            {
                {"wishlistUniqueKey", wishlistUniqueKey.ToString("D")}
            };
            List<Model.Private.PII.WishlistMetadata> loyaltyMetadataList =
                await HttpProvider.GetAsync<List<Model.Private.PII.WishlistMetadata>>(
                    GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
            return loyaltyMetadataList;
        }
        public async Task<Model.Private.PII.WishlistMetadata> AddMetadataAsync(Model.Private.PII.WishlistMetadata wishlistMetadata, ApiBasicCredential credential)
        {
            return await HttpProvider.PostAsync<Model.Private.PII.WishlistMetadata>(GenerateUrl(SingleOperationBaseUrl), wishlistMetadata, credential);
        }
        public async Task<Model.Private.PII.WishlistMetadata> UpdateMetadataAsync(Model.Private.PII.WishlistMetadata wishlistMetadata, ApiBasicCredential credential)
        {
            return await HttpProvider.PutAsync<Model.Private.PII.WishlistMetadata>(GenerateUrl(SingleOperationBaseUrl), wishlistMetadata, credential);
        }
        public async Task DeleteMetadataAsync(Guid wishlistUniqueKey, string metadataKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>
            {
                { "wishlistUniqueKey", wishlistUniqueKey.ToString("D") },
                { "metadataKey", metadataKey }
            };
            await HttpProvider.DeleteAsync(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential);
        }
        public async Task ClearMetadataAsync(Guid wishlistUniqueKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>
            {
                { "wishlistUniqueKey", wishlistUniqueKey.ToString("D") }
            };
            await HttpProvider.DeleteAsync(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }
    }
}