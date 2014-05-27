using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Core.Configuration
{
    internal sealed class ConfigurationInitializer
    {
        private Func<string, string> ConfigurationPublisher { get; set; }

        public void SetConfigurationPublisher(Func<string, string> configurationPublisher)
        {
            if (configurationPublisher == null)
            {
                throw new ArgumentNullException("configurationPublisher");
            }

            ConfigurationPublisher = configurationPublisher;
        }

        public T GetConfigValue<T>(string configName)
        {
            T value = default(T);
            string configValue = String.Empty;

            if (ConfigurationPublisher != null)
            {
                configValue = ConfigurationPublisher(configName);
            }
            else
            {
                throw new ArgumentNullException("ConfigurationPublisher");
            }

            if (String.IsNullOrEmpty(configValue))
                throw new ArgumentNullException(configName);
            else
                value = (T)Convert.ChangeType(configValue, typeof(T), CultureInfo.InvariantCulture);

            return value;
        }
    }
}
