using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Private.Auth
{
    public class Principal
    {
        public string ApiUserName { get; set; }
        public string ApiUserEncryptedPassword { get; set; }
        public string ApiUserFirstLastName { get; set; }
        public List<SDK.Model.User.BaseApiUserRight> ApiUserRights { get; set; }
    }
}
