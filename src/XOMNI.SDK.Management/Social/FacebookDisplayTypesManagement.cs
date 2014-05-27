using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;

namespace XOMNI.SDK.Management.Social
{
    public class FacebookDisplayTypesManagement : ManagementBase
    {
        private XOMNI.SDK.Management.ApiAccess.Social.FacebookDisplayTypes facebookDisplayTypesApi;

        /// <summary>
        /// Default constructor
        /// </summary>
        public FacebookDisplayTypesManagement()
        {
            facebookDisplayTypesApi = new ApiAccess.Social.FacebookDisplayTypes();
        }

        /// <summary>
        /// Returns a collection of valid facebook auth page display types
        /// </summary>
        /// <returns>a collection of valid facebook auth page display types</returns>
        public Task<IDictionary<int, string>> GetFacebookDisplayTypesAsync()
        {
            return facebookDisplayTypesApi.GetAsync(this.ApiCredential);
        }
    }
}
