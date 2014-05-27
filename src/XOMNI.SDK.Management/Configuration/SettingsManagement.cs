using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model.Management.Configuration;
using XOMNI.SDK.Core.Management;

namespace XOMNI.SDK.Management.Configuration
{
    /// <summary>
    /// Manages settings
    /// </summary>
    public class SettingsManagement : ManagementBase
    {
        private XOMNI.SDK.Management.ApiAccess.Configuration.Settings tenantSettingsApi;

        /// <summary>
        /// Default constructor
        /// </summary>
        public SettingsManagement()
        {
            tenantSettingsApi = new ApiAccess.Configuration.Settings();
        }

        /// <summary>
        /// To fetch all of the settings.
        /// </summary>
        /// <returns>Current settings</returns>
        public async Task<Settings> GetSettingsAsync()
        {
            return await tenantSettingsApi.GetAsync(this.ApiCredential);
        }

        /// <summary>
        /// To update all of the settings
        /// </summary>
        /// <param name="tenantSettings">Settings to be updated</param>
        /// <returns>Updated settings</returns>
        public async Task<Settings> UpdateSettingsAsync(Settings tenantSettings)
        {
            return await tenantSettingsApi.UpdateAsync(tenantSettings, this.ApiCredential);
        }
    }
}
