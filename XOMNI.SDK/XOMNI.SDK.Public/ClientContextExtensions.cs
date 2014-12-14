using System;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Clients.PII;
using XOMNI.SDK.Public.Clients.Utility;
using XOMNI.SDK.Public.Clients.Catalog;
using XOMNI.SDK.Public.Clients.OmniPlay;
using XOMNI.SDK.Public.Clients.Social;

namespace XOMNI.SDK.Public
{
    public static class ClientContextExtensions
    {
        //TODO: Rename : GetLoyaltiesClient
        public static LoyaltyClient GetLoyaltyClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<LoyaltyClient>(() => new LoyaltyClient(apiClientContext.HttpClient));
        }

        public static LoyaltyMetadataClient GetLoyaltyMetadataClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<LoyaltyMetadataClient>(() => new LoyaltyMetadataClient(apiClientContext.HttpClient));
        }

        public static WishlistClient GetWishlistClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<WishlistClient>(() => new WishlistClient(apiClientContext.HttpClient));
        }

        public static WishlistItemClient GetWishlistItemClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<WishlistItemClient>(() => new WishlistItemClient(apiClientContext.HttpClient));
        }

        public static WishlistSearchClient GetWishlistSearchClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<WishlistSearchClient>(() => new WishlistSearchClient(apiClientContext.HttpClient));
        }

        public static WishlistPassbookClient GetWishlistPassbookClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<WishlistPassbookClient>(() => new WishlistPassbookClient(apiClientContext.HttpClient));
        }

        public static ShoppingCartClient GetShoppingCartClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<ShoppingCartClient>(() => new ShoppingCartClient(apiClientContext.HttpClient));
        }

        public static ShoppingCartItemClient GetShoppingCartItemClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<ShoppingCartItemClient>(() => new ShoppingCartItemClient(apiClientContext.HttpClient));
        }

        public static ShoppingCartSearchClient GetShoppingCartSearchClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<ShoppingCartSearchClient>(() => new ShoppingCartSearchClient(apiClientContext.HttpClient));
        }

        public static ShoppingCartPassbookClient GetShoppingCartPassbookClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<ShoppingCartPassbookClient>(() => new ShoppingCartPassbookClient(apiClientContext.HttpClient));
        }

        public static AnonymousClient GetAnonymousClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<AnonymousClient>(() => new AnonymousClient(apiClientContext.HttpClient));
        }

        public static QRCodeClient GetQRCodeClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<QRCodeClient>(() => new QRCodeClient(apiClientContext.HttpClient));
        }

        public static CategoryClient GetCategoryClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<CategoryClient>(() => new CategoryClient(apiClientContext.HttpClient));
        }

        public static CategoryMetadataClient GetCategoryMetadataClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<CategoryMetadataClient>(() => new CategoryMetadataClient(apiClientContext.HttpClient));
        }

        public static CategoryAssetClient GetCategoryAssetClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<CategoryAssetClient>(() => new CategoryAssetClient(apiClientContext.HttpClient));
        }

        public static BrandClient GetBrandClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<BrandClient>(() => new BrandClient(apiClientContext.HttpClient));
        }

        public static BrandAssetClient GetBrandAssetClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<BrandAssetClient>(() => new BrandAssetClient(apiClientContext.HttpClient));
        }

        public static TagClient GetTagClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<TagClient>(() => new TagClient(apiClientContext.HttpClient));
        }

        public static TagMetadataClient GetTagMetadataClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<TagMetadataClient>(() => new TagMetadataClient(apiClientContext.HttpClient));
        }

        public static AutoCompleteClient GetAutoCompleteClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<AutoCompleteClient>(() => new AutoCompleteClient(apiClientContext.HttpClient));
        }

        public static RelatedItemsClient GetRelatedItemsClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<RelatedItemsClient>(() => new RelatedItemsClient(apiClientContext.HttpClient));
        }

        public static AssetMetadataClient GetAssetMetadataClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<AssetMetadataClient>(() => new AssetMetadataClient(apiClientContext.HttpClient));
        }

        public static DynamicAttributeClient GetDynamicAttributeClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<DynamicAttributeClient>(() => new DynamicAttributeClient(apiClientContext.HttpClient));
        }

        public static TrendingItemClient GetTrendingItemClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<TrendingItemClient>(() => new TrendingItemClient(apiClientContext.HttpClient));
        }

        public static ItemClient GetItemClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<ItemClient>(() => new ItemClient(apiClientContext.HttpClient));
        }

        public static ItemAssetClient GetItemAssetClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<ItemAssetClient>(() => new ItemAssetClient(apiClientContext.HttpClient));
        }

        public static ItemMetadataClient GetItemMetadataClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<ItemMetadataClient>(() => new ItemMetadataClient(apiClientContext.HttpClient));
        }

        public static ItemCompareClient GetItemCompareClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<ItemCompareClient>(() => new ItemCompareClient(apiClientContext.HttpClient));
        }

        public static DeviceClient GetDeviceClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<DeviceClient>(() => new DeviceClient(apiClientContext.HttpClient));
        }

        public static OmniTicketClient GetOmniTicketClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<OmniTicketClient>(() => new OmniTicketClient(apiClientContext.HttpClient));
        }

        public static PollingClient GetPollingClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<PollingClient>(() => new PollingClient(apiClientContext.HttpClient));
        }

        public static AuthorizationURLClient GetAuthorizationURLClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<AuthorizationURLClient>(() => new AuthorizationURLClient(apiClientContext.HttpClient));
        }

        public static TokenClient GetTokenClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<TokenClient>(() => new TokenClient(apiClientContext.HttpClient));
        }

        public static PostClient GetPostClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<PostClient>(() => new PostClient(apiClientContext.HttpClient));
        }

        public static CommentClient GetCommentClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<CommentClient>(() => new CommentClient(apiClientContext.HttpClient));
        }

        public static ProfileClient GetProfileClient(this ClientContext apiClientContext)
        {
            return apiClientContext.GetClient<ProfileClient>(() => new ProfileClient(apiClientContext.HttpClient));
        }

        internal static TClient GetClient<TClient>(this ClientContext apiClientContext, Func<TClient> valueFactory)
        {
            return (TClient)apiClientContext.Clients.GetOrAdd(typeof(TClient), k => valueFactory());
        }
    }
}
