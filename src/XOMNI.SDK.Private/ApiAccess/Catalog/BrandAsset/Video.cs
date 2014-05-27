using XOMNI.SDK.Private.ApiAccess.Catalog;

namespace XOMNI.SDK.Private.ApiAccess.Catalog.BrandAsset
{
    internal class Video : CatalogAssetBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/brands/{0}/video"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/brands/{0}/video"; }
        }
    }
}
