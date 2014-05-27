using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Management.Configuration
{
    public class Settings
    {
        /// <summary>
        /// Type of Facebook authorization page.
        /// </summary>
        public int FacebookDisplayType { get; set; }

        /// <summary>
        /// Unique id of the facebook application.
        /// </summary>
        public string FacebookApplicationId { get; set; }

        /// <summary>
        /// Uri of the web page where facebook redirects when the authorization process is completed.
        /// </summary>
        public string FacebookRedirectUri { get; set; }

        /// <summary>
        /// Unique application secret key for the facebook application.
        /// </summary>
        public string FacebookApplicationSecretKey { get; set; }

        /// <summary>
        /// Indicates if asset APIs should return CDN endpoints or regular endpoints.
        /// </summary>
        public bool IsCDNEnabled { get; set; }

        /// <summary>
        /// Base url of the CDN endpoint.
        /// </summary>
        public string CDNUrl { get; set; }

        /// <summary>
        /// Cache expiration time for the CDN nodes.
        /// </summary>
        public int CacheExpirationTime { get; set; }

        /// <summary>
        /// Indicates if passbook functionality is enabled.
        /// </summary>
        public bool IsPassbookEnabled { get; set; }

        /// <summary>
        /// Required field by Apple (See Apple Documentation) 
        /// </summary>
        public string PassbookPassTypeIdentifier { get; set; }

        /// <summary>
        /// Asset id of the passbook WWDRCA certificate. (See Asset API Documentation) Required field by Apple (See Apple Documentation)
        /// </summary>
        public int PassbookWWDRCACertificateTenantAssetId { get; set; }

        /// <summary>
        /// Asset id of the passbook certificate. (See Asset API Documentation) Required field by Apple (See Apple Documentation)
        /// </summary>
        public int PassbookCertificateTenantAssetId { get; set; }

        /// <summary>
        /// Certificate Password Required field by Apple (See Apple Documentation)
        /// </summary>
        public string PassbookCertificatePassword { get; set; }

        /// <summary>
        /// Apple Team Identifier Required field by Apple (See Apple Documentation)
        /// </summary>
        public string PassbookTeamIdentifier { get; set; }

        /// <summary>
        /// Organization Name for Passbook Required field by Apple (See Apple Documentation)
        /// </summary>
        public string PassbookOrganizationName { get; set; }

        /// <summary>
        /// Time impact value for calculating trending items.
        /// </summary>
        public double PopularityTimeImpactValue { get; set; }
    }
}
