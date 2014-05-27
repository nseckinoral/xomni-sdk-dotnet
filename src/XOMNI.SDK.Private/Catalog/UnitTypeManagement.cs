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
    public class UnitTypeManagement : BaseCRUDSkipTakeManagement<Model.Catalog.UnitType>
    {
        private UnitType apiAccess;

        protected override CRUDApiAccessBase<Model.Catalog.UnitType> ApiAccess
        {
            get
            {
                if (apiAccess == null)
                {
                    apiAccess = new ApiAccess.Catalog.UnitType();
                }

                return apiAccess;
            }
        }

    }
}
