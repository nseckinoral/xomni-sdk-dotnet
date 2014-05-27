using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Social
{
    public enum SocialInteractionStatusType
    {
        Ready = 1,
        Retry,
        Succeed,
        Failed,
        Removed,
        TokenExpired,
        PermissionRequired,
        AppRemoved
    }
}
