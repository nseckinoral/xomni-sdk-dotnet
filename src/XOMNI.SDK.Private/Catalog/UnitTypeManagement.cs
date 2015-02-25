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
    public class UnitTypeManagement : BaseCRUDPSkipTakeManagement<Model.Catalog.UnitType>
    {
        private UnitType apiAccess;

        protected override CRUDPApiAccessBase<Model.Catalog.UnitType> CRUDPApiAccess
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
