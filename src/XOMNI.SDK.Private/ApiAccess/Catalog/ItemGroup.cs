using System.Collections.Generic;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.ApiAccess.Catalog
{
    public class ItemGroup : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/items/{0}/group"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return SingleOperationBaseUrl; }
        }

        public Task GroupItemsAsync(int defaultItemId, IEnumerable<int> variantItemIds, ApiBasicCredential credential)
        {
            string uri = GenerateUrl(string.Format(SingleOperationBaseUrl, defaultItemId));
            return HttpProvider.PostAsync(uri, variantItemIds, credential);
        }

        #region low level methods

        public XOMNIRequestMessage CreateGroupItemsRequest(int defaultItemId, IEnumerable<int> variantItemIds, ApiBasicCredential credential)
        {
            string uri = GenerateUrl(string.Format(SingleOperationBaseUrl, defaultItemId));
            return new XOMNIRequestMessage(HttpProvider.CreatePostRequest(uri, credential, variantItemIds));
        }

        #endregion
    }
}
