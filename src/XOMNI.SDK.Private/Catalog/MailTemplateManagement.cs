using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Core.Management;

namespace XOMNI.SDK.Private.Catalog
{
    public class MailTemplateManagement : BaseCRUDPSkipTakeManagement<Model.Private.Catalog.MailTemplate>
    {
        protected override Core.ApiAccess.CRUDPApiAccessBase<Model.Private.Catalog.MailTemplate> CRUDPApiAccess
        {
            get { return new ApiAccess.Catalog.MailTemplate(); }
        }
    }
}
