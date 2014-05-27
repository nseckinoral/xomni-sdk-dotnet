using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Model;
using XOMNI.SDK.Private.ApiAccess.Catalog;

namespace XOMNI.SDK.Private.Catalog
{
    public class DynamicAttributeTypeManagement : ManagementBase
    {
        private DynamicAttributeType dynamicAttributeTypeApiAccess;

        public DynamicAttributeTypeManagement()
        {
            dynamicAttributeTypeApiAccess = new DynamicAttributeType();
        }

        public Task<CountedCollectionContainer<SDK.Model.Catalog.DynamicAttributeType>> GetAllDynamicAttributeTypesAsync(int skip, int take)
        {
            return dynamicAttributeTypeApiAccess.GetAllDynamicAttributeTypesAsync(skip, take, this.ApiCredential);
        }
    }
}
