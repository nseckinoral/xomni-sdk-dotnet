using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Private.ApiAccess.Catalog;

namespace XOMNI.SDK.Private.Catalog
{
    public class DynamicAttributeManagement : ManagementBase
    {
        private DynamicAttribute dynamicAttributeApiAccess;

        public DynamicAttributeManagement()
        {
            dynamicAttributeApiAccess = new DynamicAttribute();
        }

        public Task<List<SDK.Model.Catalog.DynamicAttribute>> GetByAttributeIdAsync(int attributeId)
        {
            return dynamicAttributeApiAccess.GetByAttributeIdAsync(attributeId,this.ApiCredential);
        }
    }
}
