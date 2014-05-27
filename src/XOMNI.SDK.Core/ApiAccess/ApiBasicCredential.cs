using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Core.ApiAccess
{
    public class ApiBasicCredential
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public ApiBasicCredential(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
