using XOMNI.SDK.Private.ApiAccess.Catalog;

namespace XOMNI.SDK.Private.ApiAccess.Catalog.BrandAsset
{
    internal class Document : CatalogAssetBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/brands/{0}/document"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/brands/{0}/document"; }
        }
    }
}
