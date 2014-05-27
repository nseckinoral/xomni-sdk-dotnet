using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Core.Common;

namespace XOMNI.SDK.Core.Configuration
{
    public class Configuration
    {
        internal static ConfigurationInitializer Initializer { get; set; }

        static Configuration()
        {
            Initializer = new ConfigurationInitializer();
        }

        public static void SetConfigurationPublisher(Func<string, string> publisher)
        {
            Initializer.SetConfigurationPublisher(publisher);
        }

        public static string Host
        {
            get
            {
                return Initializer.GetConfigValue<string>(Constants.HostConfigKey);
            }
        }

        public static bool UseHttps
        {
            get
            {
                return Initializer.GetConfigValue<bool>(Constants.UseHttpsConfigKey);
            }
        }


        public static string Version
        {
            get
            {
                return Initializer.GetConfigValue<string>(Constants.ApiVersionConfigKey);
            }
        }

        public static string ApiUsername
        {
            get
            {
                var retVal = string.Empty;
                try
                {
                    retVal = Initializer.GetConfigValue<string>(Constants.ApiUsername);
                }
                catch
                {
                }

                return retVal;
            }
        }

        public static string ApiPassword
        {
            get
            {
                var retVal = string.Empty;
                try
                {
                    retVal = Initializer.GetConfigValue<string>(Constants.ApiPassword);
                }
                catch
                {
                }

                return retVal;
            }
        }

        public static int DefaultPageSize
        {
            get
            {
                return Initializer.GetConfigValue<int>(Constants.DefaultPageSize);
            }
        }
    }
}
