using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model.Catalog;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Common;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.ApiAccess.Catalog
{
    internal sealed class RelatedItems : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/relatedItem"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/relatedItems"; }
        }

        public Task<List<int>> GetByItemIdAsync(int itemId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("itemId", itemId.ToString());
            return HttpProvider.GetAsync<List<int>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

        public Task DeleteRelationAsync(int itemId, int relatedItemId, ItemRelationDirection direction, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("itemId", itemId.ToString());
            additionalParameters.Add("relateditemId", relatedItemId.ToString());
            additionalParameters.Add("direction", direction.ToString());
            return HttpProvider.DeleteAsync(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential);
        }

        public Task AddRelationAsync(int itemId, List<int> relatedItems, ItemRelationDirection direction, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("itemId", itemId.ToString());
            additionalParameters.Add("direction", direction.ToString());
            return HttpProvider.PostAsync<List<int>>(GenerateUrl(SingleOperationBaseUrl, additionalParameters), relatedItems, credential);
        }

        public Task ClearRelatedItemsAsync(int itemId, ItemRelationDirection direction, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("itemId", itemId.ToString());
            additionalParameters.Add("direction", direction.ToString());
            return HttpProvider.DeleteAsync(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }
    }
}
