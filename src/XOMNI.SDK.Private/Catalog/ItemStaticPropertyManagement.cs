using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Model.Catalog;

namespace XOMNI.SDK.Private.Catalog
{
    public class ItemStaticPropertyManagement : ManagementBase
    {
        private readonly ApiAccess.Catalog.ItemStaticProperty itemStaticPropertyApi;

        public ItemStaticPropertyManagement()
        {
            itemStaticPropertyApi = new ApiAccess.Catalog.ItemStaticProperty();
        }

        public Task<List<Model.Private.Catalog.ItemStaticProperty>> GetAllAsync()
        {
            return itemStaticPropertyApi.GetAllAsync(this.ApiCredential);
        }

        public Task<Model.Private.Catalog.ItemStaticProperty> GetAsync(string propertyName)
        {
            return itemStaticPropertyApi.GetAsync(propertyName, this.ApiCredential);
        }

        public Task<Model.Private.Catalog.ItemStaticProperty> UpdateAsync(Model.Private.Catalog.ItemStaticProperty property)
        {
            return itemStaticPropertyApi.UpdateAsync(property, this.ApiCredential);
        }
    }
}
