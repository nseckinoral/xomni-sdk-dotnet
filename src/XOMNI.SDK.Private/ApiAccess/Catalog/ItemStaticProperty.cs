using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

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

        public Task<List<Model.Private.Catalog.ItemStaticProperty>> GetAllAsync(ApiBasicCredential credential)
        {
            return HttpProvider.GetAsync<List<Model.Private.Catalog.ItemStaticProperty>>(GenerateUrl(ListOperationBaseUrl), credential);
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
