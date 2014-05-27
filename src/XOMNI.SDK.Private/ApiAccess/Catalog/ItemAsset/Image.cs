using XOMNI.SDK.Private.ApiAccess.Catalog;

namespace XOMNI.SDK.Private.ApiAccess.Catalog.ItemAsset
{
    internal class Image : CatalogAssetBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/items/{0}/image"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/items/{0}/image"; }
        }
    }
}
