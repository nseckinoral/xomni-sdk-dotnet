using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Private.ApiAccess.Catalog;

namespace XOMNI.SDK.Private.Catalog
{
    public class DimensionTypeManagement : BaseCRUDSkipTakeManagement<Model.Catalog.DimensionType>
    {
        private DimensionType apiAccess;
        protected override CRUDApiAccessBase<Model.Catalog.DimensionType> ApiAccess
        {
            get
            {
                if (apiAccess == null)
                {
                    apiAccess = new DimensionType();
                }

                return apiAccess;
            }
        }
    }
}
