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
    public class DynamicAttributeTypeManagement : BaseCRUDManagement<XOMNI.SDK.Model.Private.Catalog.DynamicAttributeType>
    {
        private DynamicAttributeType dynamicAttributeTypeApiAccess;
        protected override Core.ApiAccess.CRUDApiAccessBase<Model.Private.Catalog.DynamicAttributeType> ApiAccess
        {
            get
            {
                return new ApiAccess.Catalog.DynamicAttributeType(); 
            }
        }
    }
}
