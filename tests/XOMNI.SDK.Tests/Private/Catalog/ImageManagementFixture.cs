using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model;
using XOMNI.SDK.Core.Exception;

namespace XOMNI.SDK.Tests.Private.Catalog
{
    [TestClass]
    public class ImageManagementFixture : SDKFixtureBase
    {
        XOMNI.SDK.Private.Catalog.ImageManagement imageBusiness = null;
        private ItemManagementFixture itemManagementFixture;

        private string sampleImageFileName;
        private int sampleImageId;
        private int sampleItemId;

        public override void Init()
        {
            base.Init();
            imageBusiness = new XOMNI.SDK.Private.Catalog.ImageManagement();
            itemManagementFixture = new ItemManagementFixture();

            sampleItemId = itemManagementFixture.CreateSampleItem().Result.Id;
            sampleImageId = CreateAssetForItem().Result;

        }

        public async Task<int> CreateAssetForItem()
        {
            sampleImageFileName = Guid.NewGuid().ToString();
            int tempAssetId = await new XOMNI.SDK.Tests.Private.Asset.TemporaryStorageManagementFixture().UploadAndCommitAsync(sampleImageFileName);

            var relation = new XOMNI.SDK.Model.Asset.AssetRelation()
            {
                IsDefault = true,
                TempAssetId = tempAssetId,
                ContentMimeType = "applicaton/test"
            };

            return (await new XOMNI.SDK.Private.Catalog.ItemManagement().RelateImageAsync(sampleItemId, relation)).AssetId;
        }

        public async Task DeleteItemAndAsset()
        {
            await new XOMNI.SDK.Tests.Private.Asset.TemporaryStorageManagementFixture().DeleteAsync(sampleImageFileName);
            await new XOMNI.SDK.Private.Catalog.ItemManagement().UnrelateImageAsync(sampleItemId, sampleImageId);
            await itemManagementFixture.DeleteItemBrandCategoryByItemId(sampleItemId);
        }

        [TestCleanup]
        public void Cleanup()
        {
            DeleteItemAndAsset().Wait();
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.ImageManagement")]
        public async Task AddImageMetadataAsyncTest()
        {
            string testMetadataKey = Guid.NewGuid().ToString();
            string testMetadataValue = Guid.NewGuid().ToString();
            var createdMetadata = await imageBusiness.AddMetadataAsync(sampleImageId, testMetadataKey, testMetadataValue);

            Assert.AreEqual(sampleImageId, createdMetadata.AssetId, "Image ids did not match");
            Assert.AreEqual(testMetadataKey, createdMetadata.Key, "Metadata keys did not match");
            Assert.AreEqual(testMetadataValue, createdMetadata.Value, "Metadata values did not match");

            try
            {
                await imageBusiness.AddMetadataAsync(int.MaxValue, testMetadataKey, testMetadataValue);
                Assert.Fail("Bad request exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk.
            }

            try
            {
                await imageBusiness.AddMetadataAsync(sampleImageId, testMetadataKey, testMetadataValue);
                Assert.Fail("Conflict exception should have been returned from sdk");
            }
            catch (ConflictException)
            {
                //Conflict exception should have been returned from sdk
            }

            try
            {
                await imageBusiness.AddMetadataAsync(sampleImageId, null, null);
                Assert.Fail("Argument null exception should have been returned from sdk");
            }
            catch (ArgumentNullException)
            {
                //Argument null exception should have been returned from sdk
            }

            await imageBusiness.DeleteMetadataAsync(createdMetadata.AssetId, createdMetadata.Key);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.ImageManagement")]
        public async Task GetAllImageMetadataAsyncTest()
        {
            List<Metadata> createdMetadata = new List<Metadata>();
            for (int i = 1; i <= 3; i++)
            {
                var metadata = await imageBusiness.AddMetadataAsync(sampleImageId, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
                createdMetadata.Add(metadata);
            }

            List<Metadata> fetchedMetadata = await imageBusiness.GetAllMetadataAsync(sampleImageId);

            Assert.IsTrue(fetchedMetadata.TrueForAll(q => createdMetadata.Select(x => x.Key).Contains(q.Key) && createdMetadata.Select(x => x.Value).Contains(q.Value)), "Created and fetched metadata lists did not match.");

            try
            {
                await imageBusiness.GetAllMetadataAsync(int.MaxValue);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            foreach (var metadata in fetchedMetadata)
            {
                await imageBusiness.DeleteMetadataAsync(sampleImageId, metadata.Key);
            }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.ImageManagement")]
        public async Task UpdateImageMetadataAsyncTest()
        {
            string testMetadataKey = Guid.NewGuid().ToString();
            string testMetadataValue = Guid.NewGuid().ToString();
            var createdMetadata = await imageBusiness.AddMetadataAsync(sampleImageId, testMetadataKey, testMetadataValue);
            string newTestMetadataValue = Guid.NewGuid().ToString();

            var updatedMetadata = await imageBusiness.UpdateMetadataAsync(createdMetadata.AssetId, createdMetadata.Key, newTestMetadataValue);

            Assert.AreEqual(createdMetadata.AssetId, updatedMetadata.AssetId, "AssetIds should have been same");
            Assert.AreEqual(updatedMetadata.Key, updatedMetadata.Key, "Metadata keys should have been same");
            Assert.AreEqual(newTestMetadataValue, updatedMetadata.Value, "Metadata values should have been same");

            try
            {
                await imageBusiness.UpdateMetadataAsync(int.MaxValue, createdMetadata.Key, newTestMetadataValue);
                Assert.Fail("Not found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not found exception should have been returned from sdk
            }

            try
            {
                await imageBusiness.UpdateMetadataAsync(int.MaxValue, createdMetadata.Key, newTestMetadataValue);
                Assert.Fail("Not found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not found exception should have been returned from sdk
            }

            await imageBusiness.DeleteMetadataAsync(updatedMetadata.AssetId, updatedMetadata.Key);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.ImageManagement")]
        public async Task DeleteImageMetadataAsyncTest()
        {
            string testMetadataKey = Guid.NewGuid().ToString();
            string testMetadataValue = Guid.NewGuid().ToString();
            var createdMetadata = await imageBusiness.AddMetadataAsync(sampleImageId, testMetadataKey, testMetadataValue);

            await imageBusiness.DeleteMetadataAsync(createdMetadata.AssetId, createdMetadata.Key);

            try
            {
                await imageBusiness.GetAllMetadataAsync(createdMetadata.AssetId);
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            try
            {
                await imageBusiness.DeleteMetadataAsync(createdMetadata.AssetId, createdMetadata.Key);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.ImageManagement")]
        public async Task ClearImageMetadataAsyncTest()
        {
            int previousMetadataCount = 0;
            try
            {
                previousMetadataCount = (await imageBusiness.GetAllMetadataAsync(sampleImageId)).Count;
            }
            catch
            {

            }

            for (int i = 0; i < 3; i++)
            {
                await imageBusiness.AddMetadataAsync(sampleImageId, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            }

            var metadataList = await imageBusiness.GetAllMetadataAsync(sampleImageId);

            Assert.AreEqual(3 + previousMetadataCount, metadataList.Count, "Total Asset Metadata count should have been 3");

            await imageBusiness.ClearMetadataAsync(sampleImageId);

            try
            {
                await imageBusiness.GetAllMetadataAsync(sampleImageId);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            try
            {
                await imageBusiness.ClearMetadataAsync(int.MaxValue);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }
        }
    }
}
