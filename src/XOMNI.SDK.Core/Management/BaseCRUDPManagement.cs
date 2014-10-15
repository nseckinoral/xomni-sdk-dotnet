using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Core.ApiAccess;

namespace XOMNI.SDK.Core.Management
{
    public abstract class BaseCRUDPManagement<T> : BaseCRUDManagement<T>
    {

        protected override CRUDApiAccessBase<T> ApiAccess
        {
            get { return CRUDPApiAccess; }
        }

        protected abstract CRUDPApiAccessBase<T> CRUDPApiAccess { get; }

    }
}
