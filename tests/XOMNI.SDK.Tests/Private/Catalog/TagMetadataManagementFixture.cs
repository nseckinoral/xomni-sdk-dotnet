using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model;
using XOMNI.SDK.Core.Exception;
using XOMNI.SDK.Core.Management;

namespace XOMNI.SDK.Tests.Private.Catalog
{
    [TestClass]
    public class TagMetadataManagementFixture : SDKFixtureBase
    {
        XOMNI.SDK.Private.Catalog.TagManagement tagBusiness = null;
        private TagManagementFixture tagManagementFixture = null;

        public override void Init()
        {
            base.Init();
            tagBusiness = new XOMNI.SDK.Private.Catalog.TagManagement();
            tagManagementFixture = new TagManagementFixture();

            sampleTagId = tagManagementFixture.CreateSampleTag().Result.Id;
        }

        [TestCleanup]
        public void Cleanup()
        {
            tagBusiness.DeleteAsync(sampleTagId).Wait();
        }

        private int sampleTagId;

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.TagManagement")]
        public async Task AddTagMetadataAsyncTest()
        {
            string testMetadataKey = Guid.NewGuid().ToString();
            string testMetadataValue = Guid.NewGuid().ToString();
            var createdMetadata = await tagBusiness.AddMetadataAsync(sampleTagId, testMetadataKey, testMetadataValue);

            Assert.AreEqual(sampleTagId, createdMetadata.TagId, "Tag ids did not match");
            Assert.AreEqual(testMetadataKey, createdMetadata.Key, "Metadata keys did not match");
            Assert.AreEqual(testMetadataValue, createdMetadata.Value, "Metadata values did not match");

            try
            {
                await tagBusiness.AddMetadataAsync(int.MaxValue, testMetadataKey, testMetadataValue);
                Assert.Fail("Not found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk.
            }

            try
            {
                await tagBusiness.AddMetadataAsync(sampleTagId, testMetadataKey, testMetadataValue);
                Assert.Fail("Conflict exception should have been returned from sdk");
            }
            catch (ConflictException)
            {
                //Conflict exception should have been returned from sdk
            }

            try
            {
                await tagBusiness.AddMetadataAsync(sampleTagId, null, null);
                Assert.Fail("Argument null exception should have been returned from sdk");
            }
            catch (ArgumentNullException)
            {
                //Argument null exception should have been returned from sdk
            }

            await tagBusiness.DeleteMetadataAsync(createdMetadata.TagId, createdMetadata.Key);
        }


        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.TagManagement")]
        public async Task GetAllTagMetadataAsyncTest()
        {
            List<Metadata> createdMetadata = new List<Metadata>();
            for (int i = 1; i <= 5; i++)
            {
                var metadata = await tagBusiness.AddMetadataAsync(sampleTagId, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
                createdMetadata.Add(metadata);
            }

            List<Metadata> fetchedMetadata = await tagBusiness.GetAllMetadataAsync(sampleTagId);

            Assert.IsTrue(fetchedMetadata.TrueForAll(q => createdMetadata.Select(x => x.Key).Contains(q.Key) && createdMetadata.Select(x => x.Value).Contains(q.Value)), "Created and fetched metadata lists did not match.");

            try
            {
                await tagBusiness.GetAllMetadataAsync(int.MaxValue);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            foreach (var metadata in fetchedMetadata)
            {
                await tagBusiness.DeleteMetadataAsync(sampleTagId, metadata.Key);
            }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.TagManagement")]
        public async Task UpdateTagMetadataAsyncTest()
        {
            string testMetadataKey = Guid.NewGuid().ToString();
            string testMetadataValue = Guid.NewGuid().ToString();
            var createdMetadata = await tagBusiness.AddMetadataAsync(sampleTagId, testMetadataKey, testMetadataValue);
            string newTestMetadataValue = Guid.NewGuid().ToString();

            var updatedMetadata = await tagBusiness.UpdateMetadataAsync(createdMetadata.TagId, createdMetadata.Key, newTestMetadataValue);

            Assert.AreEqual(createdMetadata.TagId, updatedMetadata.TagId, "Tag ids should have been same");
            Assert.AreEqual(updatedMetadata.Key, updatedMetadata.Key, "Metadata keys should have been same");
            Assert.AreEqual(newTestMetadataValue, updatedMetadata.Value, "Metadata values should have been same");

            try
            {
                await tagBusiness.UpdateMetadataAsync(int.MaxValue, createdMetadata.Key, newTestMetadataValue);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            await tagBusiness.DeleteMetadataAsync(updatedMetadata.TagId, updatedMetadata.Key);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.TagManagement")]
        public async Task DeleteTagMetadataAsyncTest()
        {
            string testMetadataKey = Guid.NewGuid().ToString();
            string testMetadataValue = Guid.NewGuid().ToString();
            var createdMetadata = await tagBusiness.AddMetadataAsync(sampleTagId, testMetadataKey, testMetadataValue);

            await tagBusiness.DeleteMetadataAsync(createdMetadata.TagId, createdMetadata.Key);

            try
            {
                await tagBusiness.GetAllMetadataAsync(createdMetadata.TagId);
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            try
            {
                await tagBusiness.DeleteMetadataAsync(createdMetadata.TagId, createdMetadata.Key);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.TagManagement")]
        public async Task ClearTagMetadataAsyncTest()
        {
            int previousMetadataCount = 0;
            try
            {
                previousMetadataCount = (await tagBusiness.GetAllMetadataAsync(sampleTagId)).Count;
            }
            catch
            {

            }

            for (int i = 0; i < 3; i++)
            {
                await tagBusiness.AddMetadataAsync(sampleTagId, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            }

            var metadataList = await tagBusiness.GetAllMetadataAsync(sampleTagId);

            Assert.AreEqual(3 + previousMetadataCount, metadataList.Count, "Total Tag Metadata count should have been 3");

            await tagBusiness.ClearMetadataAsync(sampleTagId);

            try
            {
                await tagBusiness.GetAllMetadataAsync(sampleTagId);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            try
            {
                await tagBusiness.ClearMetadataAsync(int.MaxValue);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }
        }
    }
}
