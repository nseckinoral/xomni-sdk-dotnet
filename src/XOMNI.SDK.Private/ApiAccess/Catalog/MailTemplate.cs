using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Core.ApiAccess;

namespace XOMNI.SDK.Private.ApiAccess.Catalog
{
    public class MailTemplate : CRUDApiAccessBase<Model.Private.Catalog.MailTemplate>
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/mailtemplate/{0}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/mailtemplates"; }
        }
    }
}
