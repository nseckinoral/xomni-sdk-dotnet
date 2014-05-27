using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Core.ApiAccess;

namespace XOMNI.SDK.Core.Management
{
    public abstract class ManagementBase : IApiBasicCredential
    {
        private ApiBasicCredential apiCredential;
        public ApiBasicCredential ApiCredential
        {
            get
            {
                var username = Configuration.Configuration.ApiUsername;
                var password = Configuration.Configuration.ApiPassword;

                if (apiCredential != null)
                {
                    username = apiCredential.Username;
                    password = apiCredential.Password;
                }

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    throw new ArgumentException("Api Credentials not set.");
                }
                return new ApiBasicCredential(username, password);
            }
            set
            {
                apiCredential = value;
            }
        }

        /// <summary>
        /// Sets credentials 
        /// </summary>
        /// <param name="apiBasicCredential">API Basic auth credentials</param>
        public virtual void SetApiCredentials(ApiBasicCredential apiBasicCredential)
        {
            ApiCredential = apiBasicCredential;
        }
    }
}
