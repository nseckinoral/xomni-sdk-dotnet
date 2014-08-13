using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Management.ApiAccess.Company;
using XOMNI.SDK.Model.Management.Company;

namespace XOMNI.SDK.Management.Company
{
    public class DeviceTypeManagement : BaseCRUDSkipTakeManagement<DeviceType>
    {
        protected override Core.ApiAccess.CRUDApiAccessBase<DeviceType> ApiAccess
        {
            get { return new DeviceTypes(); }
        }
    }
}
