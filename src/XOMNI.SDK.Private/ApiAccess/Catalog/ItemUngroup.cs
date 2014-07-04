using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.ApiAccess.Catalog
{
    public class ItemUngroup : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/items/{0}/ungroup"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return SingleOperationBaseUrl; }
        }

        public Task UngroupItemsAsync(int defaultItemId, ApiBasicCredential credential)
        {
            string uri = GenerateUrl(string.Format(SingleOperationBaseUrl, defaultItemId));
            return HttpProvider.PostAsync(uri, null, credential);
        }
    }
}