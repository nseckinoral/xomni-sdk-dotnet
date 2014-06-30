using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model.Asset;

namespace XOMNI.SDK.Tests.Private.Asset
{
    [TestClass]
    public class AssetManagementFixture : SDKFixtureBase
    {
        private TemporaryStorageManagementFixture tempAssetBusiness = null;
        private XOMNI.SDK.Private.Catalog.BrandManagement relator = null;
        private XOMNI.SDK.Private.Asset.ImageAssetManagement imageAssetManagement = null;
        private XOMNI.SDK.Private.Asset.AssetManagement documentAssetManagement = null;
        private XOMNI.SDK.Private.Asset.AssetManagement videoAssetManagement = null;
        private XOMNI.SDK.Tests.Private.Catalog.BrandManagementFixture brandManagementFixture = null;

        int skip = 0;
        int take = 100;
        int sampleBrandId;

        public override void Init()
        {
            base.Init();
            tempAssetBusiness = new TemporaryStorageManagementFixture();
            relator = new SDK.Private.Catalog.BrandManagement();
            imageAssetManagement = new SDK.Private.Asset.ImageAssetManagement();
            documentAssetManagement = new SDK.Private.Asset.DocumentAssetManagement();
            videoAssetManagement = new SDK.Private.Asset.VideoAssetManagement();
            brandManagementFixture = new Catalog.BrandManagementFixture();

            sampleBrandId = brandManagementFixture.CreateSampleBrand().Result.Id;
        }

        [TestCleanup]
        public void Cleanup()
        {
            relator.DeleteAsync(sampleBrandId).Wait();
        }

        [TestMethod]
        [TestCategory("SDK.Private.Asset"), TestCategory("Integration"), TestCategory("SDK.Private.Asset.AssetManagement")]
        public async Task GetImageAssetsTest()
        {
            var assets = await imageAssetManagement.GetAssets(skip, take, null);

            var firstCount = assets.TotalCount;

            var tempFileName = Guid.NewGuid().ToString();
            var tempAssetId = await tempAssetBusiness.UploadAndCommitAsync(tempFileName);

            var newAssetRelation = await relator.RelateImageAsync(sampleBrandId,
                new Model.Asset.AssetRelation()
                {
                    ContentMimeType = "applicaton/test",
                    IsDefault = false,
                    TempAssetId = tempAssetId
                });

            var assets2 = await imageAssetManagement.GetAssets(skip, take, null);

            Assert.AreEqual(assets.TotalCount + 1, assets2.TotalCount, "Total asset count did not match.");

            await relator.UnrelateImageAsync(sampleBrandId, newAssetRelation.AssetId);
            await tempAssetBusiness.DeleteAsync(tempFileName);

            var assets3 = await imageAssetManagement.GetAssets(skip, take, null);
            Assert.AreEqual(assets.TotalCount + 1, assets3.TotalCount, "Total asset count did not match.");

            var assets4 = await imageAssetManagement.GetAssets(skip, take, "image");
            if (assets3.TotalCount > 0)
            {
                Assert.AreNotEqual(assets3.TotalCount, assets4.TotalCount, "Filtering is broken.");
            }

            var randomAssetName = assets3.Results[new Random().Next(0, assets3.Results.Count - 1)].OriginalFilename;
            var assets5 = await imageAssetManagement.GetAssets(skip, take, randomAssetName);
            Assert.IsTrue(assets5.TotalCount == 1, "Filtering is broken.");


            try
            {
                await imageAssetManagement.SetResizableFlag(newAssetRelation.AssetId);
                Assert.Fail("We can set resizable flag only for jpeg, jpg, png extensions.");
            }
            catch (SDK.Core.Exception.BadRequestException bEx)
            {
                //OK, expected.
            }

            tempFileName = Guid.NewGuid().ToString() + ".jpg";
            tempAssetId = await tempAssetBusiness.UploadAndCommitAsync(tempFileName);

            newAssetRelation = await relator.RelateImageAsync(sampleBrandId,
                new Model.Asset.AssetRelation()
                {
                    ContentMimeType = "applicaton/test",
                    IsDefault = false,
                    TempAssetId = tempAssetId
                });

            await imageAssetManagement.SetResizableFlag(newAssetRelation.AssetId);
            await imageAssetManagement.RemoveResizableFlag(newAssetRelation.AssetId);
            await relator.UnrelateImageAsync(sampleBrandId, newAssetRelation.AssetId);
            await tempAssetBusiness.DeleteAsync(tempFileName);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Asset"), TestCategory("Integration"), TestCategory("SDK.Private.Asset.AssetManagement")]
        public async Task GetDocumentAssetsTest()
        {
            var assets = await documentAssetManagement.GetAssets(skip, take, null);

            var firstCount = assets.TotalCount;

            var tempFileName = Guid.NewGuid().ToString();
            var tempAssetId = await tempAssetBusiness.UploadAndCommitAsync(tempFileName);

            var newAssetRelation = await relator.RelateDocumentAsync(sampleBrandId,
                new Model.Asset.AssetRelation()
                {
                    ContentMimeType = "applicaton/test",
                    IsDefault = false,
                    TempAssetId = tempAssetId
                });

            var assets2 = await documentAssetManagement.GetAssets(skip, take, null);

            Assert.AreEqual(assets.TotalCount + 1, assets2.TotalCount, "Total asset count did not match.");

            await relator.UnrelateDocumentAsync(sampleBrandId, newAssetRelation.AssetId);
            await tempAssetBusiness.DeleteAsync(tempFileName);

            var assets3 = await documentAssetManagement.GetAssets(skip, take, null);
            Assert.AreEqual(assets.TotalCount + 1, assets3.TotalCount, "Total asset count did not match.");

            var assets4 = await documentAssetManagement.GetAssets(skip, take, "document");
            if (assets3.TotalCount > 0)
            {
                Assert.AreNotEqual(assets3.TotalCount, assets4.TotalCount, "Filtering is broken.");
            }

            var randomAssetName = assets3.Results[new Random().Next(0, assets3.Results.Count - 1)].OriginalFilename;
            var assets5 = await documentAssetManagement.GetAssets(skip, take, randomAssetName);
            Assert.IsTrue(assets5.TotalCount == 1, "Filtering is broken.");
        }

        [TestMethod]
        [TestCategory("SDK.Private.Asset"), TestCategory("Integration"), TestCategory("SDK.Private.Asset.AssetManagement")]
        public async Task GetVideoAssetsTest()
        {
            var assets = await videoAssetManagement.GetAssets(skip, take, null);

            var firstCount = assets.TotalCount;

            var tempFileName = Guid.NewGuid().ToString();
            var tempAssetId = await tempAssetBusiness.UploadAndCommitAsync(tempFileName);

            var newAssetRelation = await relator.RelateVideoAsync(sampleBrandId,
                new Model.Asset.AssetRelation()
                {
                    ContentMimeType = "applicaton/test",
                    IsDefault = false,
                    TempAssetId = tempAssetId
                });

            var assets2 = await videoAssetManagement.GetAssets(skip, take, null);

            Assert.AreEqual(assets.TotalCount + 1, assets2.TotalCount, "Total asset count did not match.");

            await relator.UnrelateVideoAsync(sampleBrandId, newAssetRelation.AssetId);
            await tempAssetBusiness.DeleteAsync(tempFileName);

            var assets3 = await videoAssetManagement.GetAssets(skip, take, null);
            Assert.AreEqual(assets.TotalCount + 1, assets3.TotalCount, "Total asset count did not match.");

            var assets4 = await videoAssetManagement.GetAssets(skip, take, "video");
            if (assets3.TotalCount > 0)
            {
                Assert.AreNotEqual(assets3.TotalCount, assets4.TotalCount, "Filtering is broken.");
            }

            var randomAssetName = assets3.Results[new Random().Next(0, assets3.Results.Count - 1)].OriginalFilename;
            var assets5 = await videoAssetManagement.GetAssets(skip, take, randomAssetName);
            Assert.IsTrue(assets5.TotalCount == 1, "Filtering is broken.");
        }
    }
}
