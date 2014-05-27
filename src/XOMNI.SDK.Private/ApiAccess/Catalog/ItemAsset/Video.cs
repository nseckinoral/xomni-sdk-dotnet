using XOMNI.SDK.Private.ApiAccess.Catalog;

namespace XOMNI.SDK.Private.ApiAccess.Catalog.ItemAsset
{
    internal class Video : CatalogAssetBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/items/{0}/video"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/items/{0}/video"; }
        }
    }
}
