using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model;

namespace XOMNI.SDK.Private.ApiAccess.Catalog
{
    public class DynamicAttributeType : CRUDApiAccessBase<Model.Private.Catalog.DynamicAttributeType>
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/dynamicattributetype"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/dynamicattributetypes"; }
        }

        //public Task<CountedCollectionContainer<SDK.Model.Catalog.DynamicAttributeType>> GetAllDynamicAttributeTypesAsync(int skip, int take, ApiBasicCredential credential)
        //{
        //    Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
        //    additionalParameters.Add("skip", skip.ToString());
        //    additionalParameters.Add("take", take.ToString());

        //    return HttpProvider.GetAsync<CountedCollectionContainer<SDK.Model.Catalog.DynamicAttributeType>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        //}
    }
}
