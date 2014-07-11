using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Exception;
using XOMNI.SDK.Model.Management.Storage;

namespace XOMNI.SDK.Tests.Management.Configuration
{
    [TestClass]
    public class SettingManagementFixture : SDKFixtureBase
    {
        XOMNI.SDK.Management.Configuration.SettingsManagement tenantSettingBusiness = null;
        XOMNI.SDK.Management.Storage.AssetManagement tenantAssetBusiness = null;


        public override void Init()
        {
            base.Init();
            tenantSettingBusiness = new SDK.Management.Configuration.SettingsManagement();
            tenantAssetBusiness = new SDK.Management.Storage.AssetManagement();
        }

        public async Task<Asset> UploadCertificateAsset(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                byte[] buffer = new byte[fs.Length];
                await fs.WriteAsync(buffer, 0, buffer.Length);
                Asset asset = new Asset()
                {
                    FileName = Guid.NewGuid().ToString(),
                    FileBody = buffer,
                    MimeType = "application/certificatetest",
                };
                return await tenantAssetBusiness.AddAsync(asset);
            }
        }


        [TestMethod]
        [TestCategory("SDK.Management.Configuration"), TestCategory("Integration"), TestCategory("SDK.Management.Configuration.SettingManagement")]
        public async Task GetUpdateSettingsAsyncTest()
        {
            var passbookCertificate = await UploadCertificateAsset(@"TestAssets/passbook.pfx");
            var passbookWWDRCAcertificate = await UploadCertificateAsset(@"TestAssets/AppleWWDRCA.cer");


            var exSettings = await tenantSettingBusiness.GetSettingsAsync();

            var settings = await tenantSettingBusiness.GetSettingsAsync();
            settings.FacebookApplicationId = Guid.NewGuid().ToString();
            settings.FacebookApplicationSecretKey = Guid.NewGuid().ToString();
            settings.FacebookRedirectUri = Guid.NewGuid().ToString();
            settings.FacebookDisplayType = (int)Wrapper.Facebook.Enums.DisplayType.Popup;
            //settings.FacebookResponseType = (int)Wrapper.Facebook.Enums.ResponseType.Code;
            settings.IsCDNEnabled = true;
            settings.CDNUrl = Guid.NewGuid().ToString();
            settings.CacheExpirationTime = int.MaxValue;

            settings.IsPassbookEnabled = true;
            settings.PassbookPassTypeIdentifier = Guid.NewGuid().ToString();
            settings.PassbookWWDRCACertificateTenantAssetId = passbookWWDRCAcertificate.Id;
            settings.PassbookCertificateTenantAssetId = passbookCertificate.Id;
            settings.PassbookCertificatePassword = Guid.NewGuid().ToString();
            settings.PassbookTeamIdentifier = Guid.NewGuid().ToString();
            settings.PassbookOrganizationName = Guid.NewGuid().ToString();
            settings.PopularityTimeImpactValue = new Random().NextDouble();

            var updatedSettings = await tenantSettingBusiness.UpdateSettingsAsync(settings);

            CompareSettings(settings, updatedSettings);

            updatedSettings = await tenantSettingBusiness.UpdateSettingsAsync(exSettings);
            CompareSettings(exSettings, updatedSettings);

            updatedSettings.FacebookDisplayType = int.MaxValue;
            try
            {
                await tenantSettingBusiness.UpdateSettingsAsync(updatedSettings);
            }
            catch (BadRequestException bex)
            {

            }
            updatedSettings.FacebookDisplayType = (int)Wrapper.Facebook.Enums.DisplayType.Popup;
            //updatedSettings.FacebookResponseType = int.MaxValue;
            try
            {
                await tenantSettingBusiness.UpdateSettingsAsync(updatedSettings);
            }
            catch (BadRequestException bex)
            {

            }

            //updatedSettings.FacebookResponseType = int.MaxValue;
            updatedSettings.IsCDNEnabled = true;
            updatedSettings.CDNUrl = String.Empty;

            try
            {
                await tenantSettingBusiness.UpdateSettingsAsync(updatedSettings);
            }
            catch (BadRequestException bex)
            {

            }

            updatedSettings = await tenantSettingBusiness.UpdateSettingsAsync(exSettings);
            updatedSettings = await tenantSettingBusiness.GetSettingsAsync();
            CompareSettings(exSettings, updatedSettings);

            await tenantAssetBusiness.DeleteAsync(passbookCertificate.Id);
            await tenantAssetBusiness.DeleteAsync(passbookWWDRCAcertificate.Id);

        }

        private static void CompareSettings(Model.Management.Configuration.Settings expectedSettings, Model.Management.Configuration.Settings actualSettings)
        {
            Assert.AreEqual(expectedSettings.FacebookApplicationId, actualSettings.FacebookApplicationId, "FacebookApplicationId did not match");
            Assert.AreEqual(expectedSettings.FacebookApplicationSecretKey, actualSettings.FacebookApplicationSecretKey, "FacebookApplicationSecretKey did not match");
            Assert.AreEqual(expectedSettings.FacebookRedirectUri, actualSettings.FacebookRedirectUri, "FacebookRedirectUri did not match");
            Assert.AreEqual(expectedSettings.FacebookDisplayType, actualSettings.FacebookDisplayType, "FacebookDisplayType did not match");
            //Assert.AreEqual(expectedSettings.FacebookResponseType, actualSettings.FacebookResponseType, "FacebookResponseType did not match");
            Assert.AreEqual(expectedSettings.IsCDNEnabled, actualSettings.IsCDNEnabled, "IsCDNEnabled did not match");
            Assert.AreEqual(expectedSettings.CDNUrl, actualSettings.CDNUrl, "CDNUrl did not match");
            Assert.AreEqual(expectedSettings.CacheExpirationTime, actualSettings.CacheExpirationTime, "CacheExpirationTime did not match");
            Assert.AreEqual(expectedSettings.IsPassbookEnabled, actualSettings.IsPassbookEnabled, "IsPassbookEnabled did not match");
            Assert.AreEqual(expectedSettings.PassbookPassTypeIdentifier, actualSettings.PassbookPassTypeIdentifier, "ApplePassTypeIdentifier did not match");
            Assert.AreEqual(expectedSettings.PassbookWWDRCACertificateTenantAssetId, actualSettings.PassbookWWDRCACertificateTenantAssetId, "AppleWWDRCACertificatePath did not match");
            Assert.AreEqual(expectedSettings.PassbookCertificateTenantAssetId, actualSettings.PassbookCertificateTenantAssetId, "PassbookCertificatePath did not match");
            Assert.AreEqual(expectedSettings.PassbookCertificatePassword, actualSettings.PassbookCertificatePassword, "PassbookCertificatePassword did not match");
            Assert.AreEqual(expectedSettings.PassbookTeamIdentifier, actualSettings.PassbookTeamIdentifier, "PassbookTeamIdentifier did not match");
            Assert.AreEqual(expectedSettings.PassbookOrganizationName, actualSettings.PassbookOrganizationName, "OrganizationName did not match");
            Assert.AreEqual(expectedSettings.PopularityTimeImpactValue, actualSettings.PopularityTimeImpactValue, "PopularityTimeImpactValue did not match");

        }
    }
}
