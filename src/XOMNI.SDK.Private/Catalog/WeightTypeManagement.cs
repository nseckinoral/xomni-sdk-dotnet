using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Private.ApiAccess.Catalog;

namespace XOMNI.SDK.Private.Catalog
{
    public class WeightTypeManagement : BaseCRUDSkipTakeManagement<Model.Catalog.WeightType>
    {
        private WeightType apiAccess;

        protected override CRUDApiAccessBase<Model.Catalog.WeightType> ApiAccess
        {
            get
            {
                if (apiAccess == null)
                {
                    apiAccess = new ApiAccess.Catalog.WeightType();
                }

                return apiAccess;
            }
        }
    }
}
