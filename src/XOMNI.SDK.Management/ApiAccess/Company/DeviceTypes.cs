using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Model.Management.Company;

namespace XOMNI.SDK.Management.ApiAccess.Company
{
    internal class DeviceTypes : CRUDApiAccessBase<DeviceType>
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/management/company/devicetypes/{0}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/management/company/devicetypes"; }
        }
    }
}
