using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model;
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

        public Task<CountedCollectionContainer<Model.Private.Catalog.ItemStaticProperty>> GetAllAsync(int skip, int take)
        {
            return itemStaticPropertyApi.GetAllAsync(skip, take, this.ApiCredential);
        }

        public Task<Model.Private.Catalog.ItemStaticProperty> GetAsync(string propertyName)
        {
            return itemStaticPropertyApi.GetAsync(propertyName, this.ApiCredential);
        }

        //public Task<Model.Private.Catalog.ItemStaticProperty> UpdateAsync(Model.Private.Catalog.ItemStaticProperty property)
        //{
        //    return itemStaticPropertyApi.UpdateAsync(property, this.ApiCredential);
        //}

        #region low level methods

        public XOMNIRequestMessage<CountedCollectionContainer<Model.Private.Catalog.ItemStaticProperty>> CreateGetAllRequest(int skip, int take)
        {
            return itemStaticPropertyApi.CreateGetAllRequest(skip, take, this.ApiCredential);
        }

        public XOMNIRequestMessage<Model.Private.Catalog.ItemStaticProperty> CreateGetRequest(string propertyName)
        {
            return itemStaticPropertyApi.CreateGetRequest(propertyName, this.ApiCredential);
        }

        //public XOMNIRequestMessage<Model.Private.Catalog.ItemStaticProperty> CreateUpdateRequest(Model.Private.Catalog.ItemStaticProperty property)
        //{
        //    return itemStaticPropertyApi.CreateUpdateRequest(property, this.ApiCredential);
        //}
        #endregion
    }
}
