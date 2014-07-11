using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Exception;
using XOMNI.SDK.Model;
using XOMNI.SDK.Model.Catalog;
using XOMNI.SDK.Model.Private.Passbook;
using XOMNI.SDK.Model.Private.Tenant;
using XOMNI.SDK.Private.Catalog;

namespace XOMNI.SDK.Tests.Private.Passbook
{
    [TestClass]
    public class PassbookTemplateManagementFixture : SDKFixtureBase
    {
        SDK.Private.Passbook.PassbookTemplateManagement passbookTemplateManagement = null;
        SDK.Private.Tenant.TenantAssetManagement assetManagement = null;
        CurrencyManagement currencyManagement = null;
        TenantAsset iconImage, iconRetinaImage, logoImage, logoRetinaImage, stripImage, stripRetinaImage;
        Currency sampleCurrency = null;
        public override void Init()
        {
            base.Init();
            passbookTemplateManagement = new SDK.Private.Passbook.PassbookTemplateManagement();
            currencyManagement = new CurrencyManagement();
            assetManagement = new SDK.Private.Tenant.TenantAssetManagement();
            iconImage = UploadAsset(@"TestAssets/icon.png").Result;
            iconRetinaImage = UploadAsset(@"TestAssets/icon@2x.png").Result;
            logoImage = UploadAsset(@"TestAssets/logo.png").Result;
            logoRetinaImage = UploadAsset(@"TestAssets/logo@2x.png").Result;
            stripImage = UploadAsset(@"TestAssets/strip.png").Result;
            stripRetinaImage = UploadAsset(@"TestAssets/strip@2x.png").Result;
            sampleCurrency = currencyManagement.AddAsync(new Currency()
                {
                    CurrencySymbol = "test",
                    Description = "test",
                }).Result;
        }

        [TestCleanup]
        public override void Cleanup()
        {
            base.Cleanup();
            DeleteAsset(iconImage).Wait();
            DeleteAsset(iconRetinaImage).Wait();
            DeleteAsset(logoImage).Wait();
            DeleteAsset(logoRetinaImage).Wait();
            DeleteAsset(stripImage).Wait();
            DeleteAsset(stripRetinaImage).Wait();
            DeleteCurrency(sampleCurrency).Wait();
        }

        private Task DeleteCurrency(Currency sampleCurrency)
        {
            return currencyManagement.DeleteAsync(sampleCurrency.Id);
        }

        private Task DeleteAsset(TenantAsset asset)
        {
            return assetManagement.DeleteAsync(asset.Id);
        }

        private async Task<TenantAsset> UploadAsset(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                byte[] buffer = new byte[fs.Length];
                await fs.WriteAsync(buffer, 0, buffer.Length);
                TenantAsset asset = new TenantAsset()
                {
                    FileName = Guid.NewGuid().ToString(),
                    FileBody = buffer,
                    MimeType = "image/jpeg",
                };
                return await assetManagement.AddAsync(asset);
            }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Passbook"), TestCategory("Integration"), TestCategory("SDK.Private.Passbook.PassbookTemplateManagement")]
        public async Task AddAsyncTest()
        {
            var request = CreateSampleRequest();
            var response = await passbookTemplateManagement.AddAsync(request);
            CompareRequestAndResponse(request, response);
            try
            {
                await passbookTemplateManagement.AddAsync(request);
                Assert.Fail("Bad request exception should have been thrown");
            }
            catch (BadRequestException)
            { // OK! 
            }
            try
            {
                request = CreateSampleRequest();
                request.IconImageAssetId = int.MaxValue;
                await passbookTemplateManagement.AddAsync(request);
                Assert.Fail("Bad request exception should have been thrown");
            }
            catch (BadRequestException)
            {//OK!
            }

            try
            {
                request = CreateSampleRequest();
                request.CurrencyId = int.MaxValue;
                await passbookTemplateManagement.AddAsync(request);
                Assert.Fail("Bad request exception should have been thrown");
            }
            catch (BadRequestException)
            {//OK!
            }

            await passbookTemplateManagement.DeleteAsync(response.Id);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Passbook"), TestCategory("Integration"), TestCategory("SDK.Private.Passbook.PassbookTemplateManagement")]
        public async Task UpdateAsyncTest()
        {
            TenantAsset testImage = UploadAsset(@"TestAssets/strip.png").Result;
            Currency testCurrency = currencyManagement.AddAsync(new Currency()
                {
                    CurrencySymbol = "test2",
                    Description = "test1",
                }).Result;
            int iconImageAssetId = 0;
            var request = CreateSampleRequest();
            var response = await passbookTemplateManagement.AddAsync(request);
            var request2 = CreateSampleRequest();
            var response2 = await passbookTemplateManagement.AddAsync(request2);
            CompareRequestAndResponse(request, response);
            request.Id = response.Id;
            string uniqueName = request.UniqueName;
            request.BackFieldLabel1 = Guid.NewGuid().ToString();
            request.BackFieldLabel2 = Guid.NewGuid().ToString();
            request.BackFieldLabel3 = Guid.NewGuid().ToString();
            request.BackFieldPlaceholder1 = Guid.NewGuid().ToString();
            request.BackFieldPlaceholder2 = Guid.NewGuid().ToString();
            request.BackFieldPlaceholder3 = Guid.NewGuid().ToString();
            request.BackgroundColor = Guid.NewGuid().ToString();
            request.BarcodeMessageFormat = Guid.NewGuid().ToString();
            request.BarcodeType = 2;
            request.Description = Guid.NewGuid().ToString();
            request.ForegroundColor = Guid.NewGuid().ToString();
            request.FormatVersion = "2";
            request.PassbookBodyFormat = Guid.NewGuid().ToString();
            request.LogoText = Guid.NewGuid().ToString();
            request.Name = Guid.NewGuid().ToString();
            request.PassbookAssociatedStoreIdentifier = 2;
            request.SupressStripShine = false;
            request.UniqueName = Guid.NewGuid().ToString();
            request.IconImageAssetId = testImage.Id;
            request.IconRetinaImageAssetId = testImage.Id;
            request.LogoImageAssetId = testImage.Id;
            request.LogoRetinaImageAssetId = testImage.Id;
            request.StripImageAssetId = testImage.Id;
            request.StripRetinaImageAssetId = testImage.Id;
            request.CurrencyId = testCurrency.Id;
            response = await passbookTemplateManagement.UpdateAsync(request);
            CompareRequestAndResponse(request, response);
            try
            {
                request.UniqueName = response2.UniqueName;
                await passbookTemplateManagement.UpdateAsync(request);
                Assert.Fail("Bad request exception should have been thrown");
            }
            catch (BadRequestException)
            { // OK! 
            }
            try
            {
                request.UniqueName = uniqueName;
                iconImageAssetId = request.IconImageAssetId;
                request.IconImageAssetId = int.MaxValue;
                await passbookTemplateManagement.UpdateAsync(request);
                Assert.Fail("Bad request exception should have been thrown");
            }
            catch (BadRequestException)
            {//OK!
            }

            try
            {
                request.IconImageAssetId = iconImageAssetId;
                request.CurrencyId = int.MaxValue;
                await passbookTemplateManagement.UpdateAsync(request);
                Assert.Fail("Bad request exception should have been thrown");
            }
            catch (BadRequestException)
            {//OK!
            }

            await passbookTemplateManagement.DeleteAsync(response.Id);
            await passbookTemplateManagement.DeleteAsync(response2.Id);
            await currencyManagement.DeleteAsync(testCurrency.Id);
            await assetManagement.DeleteAsync(testImage.Id);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Passbook"), TestCategory("Integration"), TestCategory("SDK.Private.Passbook.PassbookTemplateManagement")]
        public async Task GetByIdAsyncTest()
        {
            var request = CreateSampleRequest();
            var response = await passbookTemplateManagement.AddAsync(request);
            CompareRequestAndResponse(request, response);
            var getResponse = await passbookTemplateManagement.GetAsync(response.Id);
            CompareRequestAndResponse(request, getResponse);

            try
            {
                await passbookTemplateManagement.GetAsync(int.MaxValue);
                Assert.Fail("Not Found exception should have been thrown");
            }
            catch (NotFoundException)
            {

            }
            await passbookTemplateManagement.DeleteAsync(response.Id);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Passbook"), TestCategory("Integration"), TestCategory("SDK.Private.Passbook.PassbookTemplateManagement")]
        public async Task DeleteAsyncTest()
        {
            var request = CreateSampleRequest();
            var response = await passbookTemplateManagement.AddAsync(request);
            CompareRequestAndResponse(request, response);
            await passbookTemplateManagement.DeleteAsync(response.Id);

            try
            {
                await passbookTemplateManagement.DeleteAsync(int.MaxValue);
                Assert.Fail("Not Found exception should have been thrown");
            }
            catch (NotFoundException)
            {

            }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Passbook"), TestCategory("Integration"), TestCategory("SDK.Private.Passbook.PassbookTemplateManagement")]
        public async Task GetAllAsyncTest()
        {
            int totalTemplateCount = 0;
            CountedCollectionContainer<PassbookTemplate> templates = null;
            try
            {
                templates = await passbookTemplateManagement.GetAllAsync(0, 1000);
                totalTemplateCount = templates.TotalCount;
            }
            catch (NotFoundException)
            { }
            var request = CreateSampleRequest();
            var response = await passbookTemplateManagement.AddAsync(request);
            CompareRequestAndResponse(request, response);
            templates = await passbookTemplateManagement.GetAllAsync(0, 1000);
            Assert.AreEqual(totalTemplateCount + 1, templates.TotalCount, "Total Counts did not match");

            try
            {
                await passbookTemplateManagement.GetAllAsync(totalTemplateCount, 10);
            }
            catch (NotFoundException)
            {
                //OK!   
            }
            await passbookTemplateManagement.DeleteAsync(response.Id);
        }

        private PassbookTemplateRequest CreateSampleRequest()
        {
            PassbookTemplateRequest request = new PassbookTemplateRequest()
            {
                BackFieldLabel1 = Guid.NewGuid().ToString(),
                BackFieldLabel2 = Guid.NewGuid().ToString(),
                BackFieldLabel3 = Guid.NewGuid().ToString(),
                BackFieldPlaceholder1 = Guid.NewGuid().ToString(),
                BackFieldPlaceholder2 = Guid.NewGuid().ToString(),
                BackFieldPlaceholder3 = Guid.NewGuid().ToString(),
                BackgroundColor = Guid.NewGuid().ToString(),
                BarcodeMessageFormat = Guid.NewGuid().ToString(),
                BarcodeType = 1,
                Description = Guid.NewGuid().ToString(),
                ForegroundColor = Guid.NewGuid().ToString(),
                FormatVersion = "1",
                PassbookBodyFormat = Guid.NewGuid().ToString(),
                LogoText = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString(),
                PassbookAssociatedStoreIdentifier = 1,
                SupressStripShine = true,
                UniqueName = Guid.NewGuid().ToString(),
                IconImageAssetId = iconImage.Id,
                IconRetinaImageAssetId = iconRetinaImage.Id,
                LogoImageAssetId = logoImage.Id,
                LogoRetinaImageAssetId = logoRetinaImage.Id,
                StripImageAssetId = stripImage.Id,
                StripRetinaImageAssetId = stripRetinaImage.Id,
                CurrencyId = sampleCurrency.Id
            };
            return request;
        }

        private void CompareRequestAndResponse(PassbookTemplateRequest request, PassbookTemplate response)
        {
            Assert.AreEqual(request.BackFieldLabel1, response.BackFieldLabel1, "BackField1 did not match");
            Assert.AreEqual(request.BackFieldLabel2, response.BackFieldLabel2, "BackFieldLabel2 did not match");
            Assert.AreEqual(request.BackFieldLabel3, response.BackFieldLabel3, "BackFieldLabel3 did not match");
            Assert.AreEqual(request.BackFieldPlaceholder1, response.BackFieldPlaceholder1, "BackFieldPlaceholder2 did not match");
            Assert.AreEqual(request.BackFieldPlaceholder2, response.BackFieldPlaceholder2, "BackFieldPlaceholder2 did not match");
            Assert.AreEqual(request.BackFieldPlaceholder3, response.BackFieldPlaceholder3, "BackFieldPlaceholder3 did not match");
            Assert.AreEqual(request.BackgroundColor, response.BackgroundColor, "BackgroundColor did not match");
            Assert.AreEqual(request.BarcodeMessageFormat, response.BarcodeMessageFormat, "BarcodeMessageFormat did not match");
            Assert.AreEqual(request.BarcodeType, response.BarcodeType, "BarcodeType did not match");
            Assert.AreEqual(request.Description, response.Description, "Description did not match");
            Assert.AreEqual(request.ForegroundColor, response.ForegroundColor, "ForegroundColor did not match");
            Assert.AreEqual(request.FormatVersion, response.FormatVersion, "FormatVersion did not match");
            Assert.AreEqual(request.IconImageAssetId, response.IconImage.Id, "IconImageAssetId did not match");
            Assert.AreEqual(request.IconRetinaImageAssetId, response.IconRetinaImage.Id, "IconRetinaImageAssetId did not match");
            Assert.AreEqual(request.PassbookBodyFormat, response.PassbookBodyFormat, "PassbookBodyFormat did not match");
            Assert.AreEqual(request.LogoImageAssetId, response.LogoImage.Id, "LogoImageAssetId did not match");
            Assert.AreEqual(request.LogoRetinaImageAssetId, response.LogoRetinaImage.Id, "LogoRetinaImageAssetId did not match");
            Assert.AreEqual(request.LogoText, response.LogoText, "LogoText did not match");
            Assert.AreEqual(request.Name, response.Name, "Name did not match");
            Assert.AreEqual(request.PassbookAssociatedStoreIdentifier, response.PassbookAssociatedStoreIdentifier, "PassbookAssociatedStoreIdentifier did not match");
            Assert.AreEqual(request.StripImageAssetId, response.StripImage.Id, "StripImageAssetId did not match");
            Assert.AreEqual(request.StripRetinaImageAssetId, response.StripRetinaImage.Id, "StripRetinaImageAssetId did not match");
            Assert.AreEqual(request.SupressStripShine, response.SupressStripShine, "SupressStripShine did not match");
            Assert.AreEqual(request.UniqueName, response.UniqueName, "UniqueName did not match");
        }

        private Task AddSampleTemplateAsync()
        {
            PassbookTemplateRequest request = new PassbookTemplateRequest()
            {
                BackFieldLabel1 = Guid.NewGuid().ToString(),
                BackFieldLabel2 = Guid.NewGuid().ToString(),
                BackFieldLabel3 = Guid.NewGuid().ToString(),
                BackFieldPlaceholder1 = Guid.NewGuid().ToString(),
                BackFieldPlaceholder2 = Guid.NewGuid().ToString(),
                BackFieldPlaceholder3 = Guid.NewGuid().ToString(),
                BackgroundColor = Guid.NewGuid().ToString(),
                BarcodeMessageFormat = Guid.NewGuid().ToString(),
                BarcodeType = 1,
                Description = Guid.NewGuid().ToString(),
                ForegroundColor = Guid.NewGuid().ToString(),
                FormatVersion = "1",
                PassbookBodyFormat = Guid.NewGuid().ToString(),
                LogoText = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString(),
                PassbookAssociatedStoreIdentifier = 1,
                SupressStripShine = true,
                UniqueName = Guid.NewGuid().ToString(),
                IconImageAssetId = iconImage.Id,
                IconRetinaImageAssetId = iconRetinaImage.Id,
                LogoImageAssetId = logoImage.Id,
                LogoRetinaImageAssetId = logoRetinaImage.Id,
                StripImageAssetId = stripImage.Id,
                StripRetinaImageAssetId = stripRetinaImage.Id
            };

            return passbookTemplateManagement.AddAsync(request);
        }
    }
}
