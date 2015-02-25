using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.ApiAccess.Catalog.ItemDynamicAttribute
{
    public class DynamicAttribute : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/items/{0}/dynamicattributes"; }
        }

        internal Task<List<Model.Catalog.DynamicAttribute>> UpdateItemDynamicAttributesAsync(int itemId, List<Model.Catalog.DynamicAttribute> dynamicAttributeList, ApiBasicCredential credential)
        {
            return HttpProvider.PutAsync<List<Model.Catalog.DynamicAttribute>>(GenerateUrl(string.Format(ListOperationBaseUrl, itemId)), dynamicAttributeList, credential);
        }

        #region low level methods
        internal XOMNIRequestMessage<List<Model.Catalog.DynamicAttribute>> CreateUpdateItemDynamicAttributesRequest(int itemId, List<Model.Catalog.DynamicAttribute> dynamicAttributeList, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<List<Model.Catalog.DynamicAttribute>>(HttpProvider.CreatePutRequest(GenerateUrl(string.Format(ListOperationBaseUrl, itemId)), credential, dynamicAttributeList));
        }

        #endregion low level methods
    }
}
