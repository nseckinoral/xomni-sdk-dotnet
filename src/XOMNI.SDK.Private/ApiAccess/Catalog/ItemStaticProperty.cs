using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model;

namespace XOMNI.SDK.Private.ApiAccess.Catalog
{
    public class ItemStaticProperty : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/itemstaticproperties/{0}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/itemstaticproperties"; }
        }

        public Task<CountedCollectionContainer<Model.Private.Catalog.ItemStaticProperty>> GetAllAsync(int skip, int take, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("skip", skip.ToString());
            additionalParameters.Add("take", take.ToString());
            return HttpProvider.GetAsync<CountedCollectionContainer<Model.Private.Catalog.ItemStaticProperty>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

        public Task<Model.Private.Catalog.ItemStaticProperty> GetAsync(string propertyName, ApiBasicCredential credential)
        {
            return HttpProvider.GetAsync<Model.Private.Catalog.ItemStaticProperty>(GenerateUrl(String.Format(SingleOperationBaseUrl, propertyName)), credential);
        }

        public Task<Model.Private.Catalog.ItemStaticProperty> UpdateAsync(Model.Private.Catalog.ItemStaticProperty property, ApiBasicCredential credential)
        {
            return HttpProvider.PutAsync<Model.Private.Catalog.ItemStaticProperty>(GenerateUrl(ListOperationBaseUrl), property, credential);
        }
    }
}
