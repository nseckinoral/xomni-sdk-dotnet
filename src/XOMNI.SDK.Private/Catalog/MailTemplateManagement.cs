using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Core.Management;

namespace XOMNI.SDK.Private.Catalog
{
    public class MailTemplateManagement : BaseCRUDSkipTakeManagement<Model.Private.Catalog.MailTemplate>
    {
        protected override Core.ApiAccess.CRUDApiAccessBase<Model.Private.Catalog.MailTemplate> ApiAccess
        {
            get { return new ApiAccess.Catalog.MailTemplate(); }
        }
    }
}
