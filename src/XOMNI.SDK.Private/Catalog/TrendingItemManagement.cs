using System.Collections.Generic;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model.Private.Catalog;
using XOMNI.SDK.Private.ApiAccess.Catalog;

namespace XOMNI.SDK.Private.Catalog
{
    public class TrendingItemManagement : ManagementBase
    {
        private readonly TrendingItem trendingItemApiAccess;

        public TrendingItemManagement()
        {
            trendingItemApiAccess = new TrendingItem();
        }

        public Task<IEnumerable<TrendingItemDto>> GetTrendingItemsAsync(int top, bool includeActionDetails = false)
        {
            return trendingItemApiAccess.GetTrendingItemsAsync(top, ApiCredential, includeActionDetails);
        }

        public Task<IEnumerable<TrendingItemDto>> GetTrendingItemsByStoreIdAsync(int top, int storeId, bool includeActionDetails = false)
        {
            return trendingItemApiAccess.GetTrendingItemsByStoreIdAsync(top, storeId, ApiCredential, includeActionDetails);
        }

        public Task<IEnumerable<TrendingItemDto>> GetTrendingItemsByBrandIdAsync(int top, int brandId, bool includeActionDetails = false)
        {
            return trendingItemApiAccess.GetTrendingItemsByBrandIdAsync(top, brandId, ApiCredential, includeActionDetails);
        }

        public Task<IEnumerable<TrendingItemDto>> GetTrendingItemsByStoreAndBrandIdAsync(int top, int storeId, int brandId, bool includeActionDetails = false)
        {
            return trendingItemApiAccess.GetTrendingItemsByStoreAndBrandIdAsync(top, storeId, brandId, ApiCredential, includeActionDetails);
        }

        #region low level methods

        public XOMNIRequestMessage<IEnumerable<TrendingItemDto>> CreateGetTrendingItemsRequest(int top, bool includeActionDetails = false)
        {
            return trendingItemApiAccess.CreateGetTrendingItemsRequest(top, ApiCredential, includeActionDetails);
        }

        public XOMNIRequestMessage<IEnumerable<TrendingItemDto>> CreateGetTrendingItemsByStoreIdRequest(int top, int storeId, bool includeActionDetails = false)
        {
            return trendingItemApiAccess.CreateGetTrendingItemsByStoreIdRequest(top, storeId, ApiCredential, includeActionDetails);
        }

        public XOMNIRequestMessage<IEnumerable<TrendingItemDto>> CreateGetTrendingItemsByBrandIdRequest(int top, int brandId, bool includeActionDetails = false)
        {
            return trendingItemApiAccess.CreateGetTrendingItemsByBrandIdRequest(top, brandId, ApiCredential, includeActionDetails);
        }

        public XOMNIRequestMessage<IEnumerable<TrendingItemDto>> CreateGetTrendingItemsByStoreAndBrandIdRequest(int top, int storeId, int brandId, bool includeActionDetails = false)
        {
            return trendingItemApiAccess.CreateGetTrendingItemsByStoreAndBrandIdRequest(top, storeId, brandId, ApiCredential, includeActionDetails);
        }


        #endregion
    }
}