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
    public class VideoManagementFixture : SDKFixtureBase
    {
        XOMNI.SDK.Private.Catalog.VideoManagement videoBusiness = null;
        private ItemManagementFixture itemManagementFixture;

        private string sampleVideoFileName;
        private int sampleVideoId;
        private int sampleItemId;

        public override void Init()
        {
            base.Init();
            videoBusiness = new XOMNI.SDK.Private.Catalog.VideoManagement();
            itemManagementFixture = new ItemManagementFixture();

            sampleItemId = itemManagementFixture.CreateSampleItem().Result.Id;
            sampleVideoId = CreateAssetForItem().Result;
        }

        public async Task<int> CreateAssetForItem()
        {
            sampleVideoFileName = Guid.NewGuid().ToString();
            int tempAssetId = await new XOMNI.SDK.Tests.Private.Asset.TemporaryStorageManagementFixture().UploadAndCommitAsync(sampleVideoFileName);

            var relation = new XOMNI.SDK.Model.Asset.AssetRelation()
            {
                IsDefault = true,
                TempAssetId = tempAssetId,
                ContentMimeType = "applicaton/test"
            };

            return (await new XOMNI.SDK.Private.Catalog.ItemManagement().RelateVideoAsync(sampleItemId, relation)).AssetId;
        }

        public async Task DeleteItemAndAsset()
        {
            await new XOMNI.SDK.Tests.Private.Asset.TemporaryStorageManagementFixture().DeleteAsync(sampleVideoFileName);
            await new XOMNI.SDK.Private.Catalog.ItemManagement().UnrelateVideoAsync(sampleItemId, sampleVideoId);
            await itemManagementFixture.DeleteItemBrandCategoryByItemId(sampleItemId);
        }

        [TestCleanup]
        public void Cleanup()
        {
            DeleteItemAndAsset().Wait();
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.VideoManagement")]
        public async Task AddVideoMetadataAsyncTest()
        {
            string testMetadataKey = Guid.NewGuid().ToString();
            string testMetadataValue = Guid.NewGuid().ToString();
            var createdMetadata = await videoBusiness.AddMetadataAsync(sampleVideoId, testMetadataKey, testMetadataValue);

            Assert.AreEqual(sampleVideoId, createdMetadata.AssetId, "Video ids did not match");
            Assert.AreEqual(testMetadataKey, createdMetadata.Key, "Metadata keys did not match");
            Assert.AreEqual(testMetadataValue, createdMetadata.Value, "Metadata values did not match");

            try
            {
                await videoBusiness.AddMetadataAsync(int.MaxValue, testMetadataKey, testMetadataValue);
                Assert.Fail("Bad request exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk.
            }

            try
            {
                await videoBusiness.AddMetadataAsync(sampleVideoId, testMetadataKey, testMetadataValue);
                Assert.Fail("Conflict exception should have been returned from sdk");
            }
            catch (ConflictException)
            {
                //Conflict exception should have been returned from sdk
            }

            try
            {
                await videoBusiness.AddMetadataAsync(sampleVideoId, null, null);
                Assert.Fail("Argument null exception should have been returned from sdk");
            }
            catch (ArgumentNullException)
            {
                //Argument null exception should have been returned from sdk
            }

            await videoBusiness.DeleteMetadataAsync(createdMetadata.AssetId, createdMetadata.Key);
        }


        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.VideoManagement")]
        public async Task GetAllVideoMetadataAsyncTest()
        {
            List<Metadata> createdMetadata = new List<Metadata>();
            for (int i = 1; i <= 3; i++)
            {
                var metadata = await videoBusiness.AddMetadataAsync(sampleVideoId, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
                createdMetadata.Add(metadata);
            }

            List<Metadata> fetchedMetadata = await videoBusiness.GetAllMetadataAsync(sampleVideoId);

            Assert.IsTrue(fetchedMetadata.TrueForAll(q => createdMetadata.Select(x => x.Key).Contains(q.Key) && createdMetadata.Select(x => x.Value).Contains(q.Value)), "Created and fetched metadata lists did not match.");

            try
            {
                await videoBusiness.GetAllMetadataAsync(int.MaxValue);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            foreach (var metadata in fetchedMetadata)
            {
                await videoBusiness.DeleteMetadataAsync(sampleVideoId, metadata.Key);
            }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.VideoManagement")]
        public async Task UpdateVideoMetadataAsyncTest()
        {
            string testMetadataKey = Guid.NewGuid().ToString();
            string testMetadataValue = Guid.NewGuid().ToString();
            var createdMetadata = await videoBusiness.AddMetadataAsync(sampleVideoId, testMetadataKey, testMetadataValue);
            string newTestMetadataValue = Guid.NewGuid().ToString();

            var updatedMetadata = await videoBusiness.UpdateMetadataAsync(createdMetadata.AssetId, createdMetadata.Key, newTestMetadataValue);

            Assert.AreEqual(createdMetadata.AssetId, updatedMetadata.AssetId, "AssetIds should have been same");
            Assert.AreEqual(updatedMetadata.Key, updatedMetadata.Key, "Metadata keys should have been same");
            Assert.AreEqual(newTestMetadataValue, updatedMetadata.Value, "Metadata values should have been same");

            try
            {
                await videoBusiness.UpdateMetadataAsync(int.MaxValue, createdMetadata.Key, newTestMetadataValue);
                Assert.Fail("Not found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not found exception should have been returned from sdk
            }

            try
            {
                await videoBusiness.UpdateMetadataAsync(int.MaxValue, createdMetadata.Key, newTestMetadataValue);
                Assert.Fail("Not found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not found exception should have been returned from sdk
            }

            await videoBusiness.DeleteMetadataAsync(updatedMetadata.AssetId, updatedMetadata.Key);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.VideoManagement")]
        public async Task DeleteVideoMetadataAsyncTest()
        {
            string testMetadataKey = Guid.NewGuid().ToString();
            string testMetadataValue = Guid.NewGuid().ToString();
            var createdMetadata = await videoBusiness.AddMetadataAsync(sampleVideoId, testMetadataKey, testMetadataValue);

            await videoBusiness.DeleteMetadataAsync(createdMetadata.AssetId, createdMetadata.Key);

            try
            {
                await videoBusiness.GetAllMetadataAsync(createdMetadata.AssetId);
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            try
            {
                await videoBusiness.DeleteMetadataAsync(createdMetadata.AssetId, createdMetadata.Key);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.VideoManagement")]
        public async Task ClearVideoMetadataAsyncTest()
        {
            int previousMetadataCount = 0;
            try
            {
                previousMetadataCount = (await videoBusiness.GetAllMetadataAsync(sampleVideoId)).Count;
            }
            catch
            {

            }

            for (int i = 0; i < 3; i++)
            {
                await videoBusiness.AddMetadataAsync(sampleVideoId, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            }

            var metadataList = await videoBusiness.GetAllMetadataAsync(sampleVideoId);

            Assert.AreEqual(3 + previousMetadataCount, metadataList.Count, "Total Asset Metadata count should have been 3");

            await videoBusiness.ClearMetadataAsync(sampleVideoId);

            try
            {
                await videoBusiness.GetAllMetadataAsync(sampleVideoId);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            try
            {
                await videoBusiness.ClearMetadataAsync(int.MaxValue);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }
        }
    }
}
