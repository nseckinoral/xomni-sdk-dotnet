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
    public class DocumentManagementFixture : SDKFixtureBase
    {
        XOMNI.SDK.Private.Catalog.DocumentManagement documentBusiness = null;
        private ItemManagementFixture itemManagementFixture;

        private string sampleDocumentFileName;
        private int sampleDocumentId;
        private int sampleItemId;

        public override void Init()
        {
            base.Init();
            documentBusiness = new XOMNI.SDK.Private.Catalog.DocumentManagement();
            itemManagementFixture = new ItemManagementFixture();

            sampleItemId = itemManagementFixture.CreateSampleItem().Result.Id;
            sampleDocumentId = CreateAssetForItem().Result;
        }

        public async Task<int> CreateAssetForItem()
        {
            sampleDocumentFileName = Guid.NewGuid().ToString();
            int tempAssetId = await new XOMNI.SDK.Tests.Private.Asset.TemporaryStorageManagementFixture().UploadAndCommitAsync(sampleDocumentFileName);

            var relation = new XOMNI.SDK.Model.Asset.AssetRelation()
            {
                IsDefault = true,
                TempAssetId = tempAssetId,
                ContentMimeType = "applicaton/test"
            };

            return (await new XOMNI.SDK.Private.Catalog.ItemManagement().RelateDocumentAsync(sampleItemId, relation)).AssetId;
        }

        public async Task DeleteItemAndAsset()
        {
            await new XOMNI.SDK.Tests.Private.Asset.TemporaryStorageManagementFixture().DeleteAsync(sampleDocumentFileName);
            await new XOMNI.SDK.Private.Catalog.ItemManagement().UnrelateDocumentAsync(sampleItemId, sampleDocumentId);
            await itemManagementFixture.DeleteItemBrandCategoryByItemId(sampleItemId);
        }

        [TestCleanup]
        public void Cleanup()
        {
            DeleteItemAndAsset().Wait();
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.DocumentManagement")]
        public async Task AddDocumentMetadataAsyncTest()
        {
            string testMetadataKey = Guid.NewGuid().ToString();
            string testMetadataValue = Guid.NewGuid().ToString();
            var createdMetadata = await documentBusiness.AddMetadataAsync(sampleDocumentId, testMetadataKey, testMetadataValue);

            Assert.AreEqual(sampleDocumentId, createdMetadata.AssetId, "Document ids did not match");
            Assert.AreEqual(testMetadataKey, createdMetadata.Key, "Metadata keys did not match");
            Assert.AreEqual(testMetadataValue, createdMetadata.Value, "Metadata values did not match");

            try
            {
                await documentBusiness.AddMetadataAsync(int.MaxValue, testMetadataKey, testMetadataValue);
                Assert.Fail("Bad request exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk.
            }

            try
            {
                await documentBusiness.AddMetadataAsync(sampleDocumentId, testMetadataKey, testMetadataValue);
                Assert.Fail("Conflict exception should have been returned from sdk");
            }
            catch (ConflictException)
            {
                //Conflict exception should have been returned from sdk
            }

            try
            {
                await documentBusiness.AddMetadataAsync(sampleDocumentId, null, null);
                Assert.Fail("Argument null exception should have been returned from sdk");
            }
            catch (ArgumentNullException)
            {
                //Argument null exception should have been returned from sdk
            }

            await documentBusiness.DeleteMetadataAsync(createdMetadata.AssetId, createdMetadata.Key);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.DocumentManagement")]
        public async Task GetAllDocumentMetadataAsyncTest()
        {
            List<Metadata> createdMetadata = new List<Metadata>();
            for (int i = 1; i <= 3; i++)
            {
                var metadata = await documentBusiness.AddMetadataAsync(sampleDocumentId, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
                createdMetadata.Add(metadata);
            }

            List<Metadata> fetchedMetadata = await documentBusiness.GetAllMetadataAsync(sampleDocumentId);

            Assert.IsTrue(fetchedMetadata.TrueForAll(q => createdMetadata.Select(x => x.Key).Contains(q.Key) && createdMetadata.Select(x => x.Value).Contains(q.Value)), "Created and fetched metadata lists did not match.");

            try
            {
                await documentBusiness.GetAllMetadataAsync(int.MaxValue);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            foreach (var metadata in fetchedMetadata)
            {
                await documentBusiness.DeleteMetadataAsync(sampleDocumentId, metadata.Key);
            }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.DocumentManagement")]
        public async Task UpdateDocumentMetadataAsyncTest()
        {
            string testMetadataKey = Guid.NewGuid().ToString();
            string testMetadataValue = Guid.NewGuid().ToString();
            var createdMetadata = await documentBusiness.AddMetadataAsync(sampleDocumentId, testMetadataKey, testMetadataValue);
            string newTestMetadataValue = Guid.NewGuid().ToString();

            var updatedMetadata = await documentBusiness.UpdateMetadataAsync(createdMetadata.AssetId, createdMetadata.Key, newTestMetadataValue);

            Assert.AreEqual(createdMetadata.AssetId, updatedMetadata.AssetId, "AssetIds should have been same");
            Assert.AreEqual(updatedMetadata.Key, updatedMetadata.Key, "Metadata keys should have been same");
            Assert.AreEqual(newTestMetadataValue, updatedMetadata.Value, "Metadata values should have been same");

            try
            {
                await documentBusiness.UpdateMetadataAsync(int.MaxValue, createdMetadata.Key, newTestMetadataValue);
                Assert.Fail("Not found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not found exception should have been returned from sdk
            }

            try
            {
                await documentBusiness.UpdateMetadataAsync(int.MaxValue, createdMetadata.Key, newTestMetadataValue);
                Assert.Fail("Not found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not found exception should have been returned from sdk
            }

            await documentBusiness.DeleteMetadataAsync(updatedMetadata.AssetId, updatedMetadata.Key);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.DocumentManagement")]
        public async Task DeleteDocumentMetadataAsyncTest()
        {
            string testMetadataKey = Guid.NewGuid().ToString();
            string testMetadataValue = Guid.NewGuid().ToString();
            var createdMetadata = await documentBusiness.AddMetadataAsync(sampleDocumentId, testMetadataKey, testMetadataValue);

            await documentBusiness.DeleteMetadataAsync(createdMetadata.AssetId, createdMetadata.Key);

            try
            {
                await documentBusiness.GetAllMetadataAsync(createdMetadata.AssetId);
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            try
            {
                await documentBusiness.DeleteMetadataAsync(createdMetadata.AssetId, createdMetadata.Key);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.DocumentManagement")]
        public async Task ClearDocumentMetadataAsyncTest()
        {
            int previousMetadataCount = 0;
            try
            {
                previousMetadataCount = (await documentBusiness.GetAllMetadataAsync(sampleDocumentId)).Count;
            }
            catch
            {

            }

            for (int i = 0; i < 3; i++)
            {
                await documentBusiness.AddMetadataAsync(sampleDocumentId, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            }

            var metadataList = await documentBusiness.GetAllMetadataAsync(sampleDocumentId);

            Assert.AreEqual(3 + previousMetadataCount, metadataList.Count, "Total Asset Metadata count should have been 3");

            await documentBusiness.ClearMetadataAsync(sampleDocumentId);

            try
            {
                await documentBusiness.GetAllMetadataAsync(sampleDocumentId);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            try
            {
                await documentBusiness.ClearMetadataAsync(int.MaxValue);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }
        }
    }
}
