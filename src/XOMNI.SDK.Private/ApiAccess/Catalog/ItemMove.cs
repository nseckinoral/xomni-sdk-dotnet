using System.Collections.Generic;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.ApiAccess.Catalog
{
    public class ItemMove : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/items/{0}/move"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return SingleOperationBaseUrl; }
        }

        public Task MoveItemsAsync(int defaultItemId, IEnumerable<int> variantItemIds, ApiBasicCredential credential)
        {
            string uri = GenerateUrl(string.Format(SingleOperationBaseUrl, defaultItemId));
            return HttpProvider.PostAsync(uri, variantItemIds, credential);
        }

        #region low level methods

        public XOMNIRequestMessage CreateMoveItemsRequest(int defaultItemId, IEnumerable<int> variantItemIds, ApiBasicCredential credential)
        {
            string uri = GenerateUrl(string.Format(SingleOperationBaseUrl, defaultItemId));
            return new XOMNIRequestMessage(HttpProvider.CreatePostRequest(uri, credential, variantItemIds));
        }

        #endregion
    }
}