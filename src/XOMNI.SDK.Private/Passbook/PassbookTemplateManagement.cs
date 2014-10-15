using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;

namespace XOMNI.SDK.Private.Passbook
{
    public class PassbookTemplateManagement : BaseCRUDPSkipTakeManagement<XOMNI.SDK.Model.Private.Passbook.PassbookTemplate>
    {
        private XOMNI.SDK.Private.ApiAccess.Passbook.PassbookTemplate passbookTemplateApi;

        protected override Core.ApiAccess.CRUDPApiAccessBase<Model.Private.Passbook.PassbookTemplate> CRUDPApiAccess
        {
            get
            {
                if (passbookTemplateApi == null)
                {
                    passbookTemplateApi = new ApiAccess.Passbook.PassbookTemplate(); 
                }

                return passbookTemplateApi;
            }
        }
    }
}
