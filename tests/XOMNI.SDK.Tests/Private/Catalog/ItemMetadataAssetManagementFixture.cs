using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model;
using XOMNI.SDK.Model.Asset;
using XOMNI.SDK.Model.Catalog;
using XOMNI.SDK.Core.Exception;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Private.Catalog;

namespace XOMNI.SDK.Tests.Private.Catalog
{
    [TestClass]
    public class ItemMetadataAssetManagementFixture : CatalogAssetBaseFixture
    {
        XOMNI.SDK.Private.Catalog.ItemManagement itemBusiness = null;
        private ItemManagementFixture itemManagementFixture = null;

        public override void Init()
        {
            base.Init();
            itemBusiness = new XOMNI.SDK.Private.Catalog.ItemManagement();
            itemManagementFixture = new ItemManagementFixture();

            sampleItemId = itemManagementFixture.CreateSampleItem().Result.Id;
        }

        [TestCleanup]
        public void CleanUp()
        {
            itemManagementFixture.DeleteItemBrandCategoryByItemId(sampleItemId).Wait();
        }

        private int sampleItemId;
        public override int relatedId
        {
            get { return sampleItemId; }
        }

        public override SDK.Private.Catalog.IAssetRelation CatalogAssetBaseBusiness
        {
            get { return itemBusiness; }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.ItemManagement")]
        public async Task PostGetUpdateDeleteItemDocumentRelationTest()
        {
            await base.PostGetUpdateDeleteDocumentRelationTest();
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.ItemManagement")]
        public async Task PostGetUpdateDeleteItemVideoRelationTest()
        {
            await base.PostGetUpdateDeleteVideoRelationTest();
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.ItemManagement")]
        public async Task PostGetUpdateDeleteItemImageRelationTest()
        {
            await base.PostGetUpdateDeleteImageRelationTest();
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.ItemManagement")]
        public async Task AddItemMetadataAsyncTest()
        {
            string testMetadataKey = Guid.NewGuid().ToString();
            string testMetadataValue = Guid.NewGuid().ToString();
            var createdMetadata = await itemBusiness.AddMetadataAsync(sampleItemId, testMetadataKey, testMetadataValue);

            Assert.AreEqual(sampleItemId, createdMetadata.ItemId, "Item ids did not match");
            Assert.AreEqual(testMetadataKey, createdMetadata.Key, "Metadata keys did not match");
            Assert.AreEqual(testMetadataValue, createdMetadata.Value, "Metadata values did not match");

            try
            {
                await itemBusiness.AddMetadataAsync(int.MaxValue, testMetadataKey, testMetadataValue);
                Assert.Fail("Bad request exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk.
            }

            try
            {
                await itemBusiness.AddMetadataAsync(sampleItemId, testMetadataKey, testMetadataValue);
                Assert.Fail("Conflict exception should have been returned from sdk");
            }
            catch (ConflictException)
            {
                //Conflict exception should have been returned from sdk
            }

            try
            {
                await itemBusiness.AddMetadataAsync(sampleItemId, null, null);
                Assert.Fail("Argument null exception should have been returned from sdk");
            }
            catch (ArgumentNullException)
            {
                //Argument null exception should have been returned from sdk
            }

            await itemBusiness.DeleteMetadataAsync(createdMetadata.ItemId, createdMetadata.Key);
        }


        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.ItemManagement")]
        public async Task GetAllItemMetadataAsyncTest()
        {
            List<Metadata> createdMetadata = new List<Metadata>();
            for (int i = 1; i <= 5; i++)
            {
                var metadata = await itemBusiness.AddMetadataAsync(sampleItemId, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
                createdMetadata.Add(metadata);
            }

            List<Metadata> fetchedMetadata = await itemBusiness.GetAllMetadataAsync(sampleItemId);

            Assert.IsTrue(fetchedMetadata.TrueForAll(q => createdMetadata.Select(x => x.Key).Contains(q.Key) && createdMetadata.Select(x => x.Value).Contains(q.Value)), "Created and fetched metadata lists did not match.");

            try
            {
                await itemBusiness.GetAllMetadataAsync(int.MaxValue);
                Assert.Fail("Bad request exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            foreach (var metadata in fetchedMetadata)
            {
                await itemBusiness.DeleteMetadataAsync(sampleItemId, metadata.Key);
            }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.ItemManagement")]
        public async Task UpdateItemMetadataAsyncTest()
        {
            string testMetadataKey = Guid.NewGuid().ToString();
            string testMetadataValue = Guid.NewGuid().ToString();
            var createdMetadata = await itemBusiness.AddMetadataAsync(sampleItemId, testMetadataKey, testMetadataValue);
            string newTestMetadataValue = Guid.NewGuid().ToString();

            var updatedMetadata = await itemBusiness.UpdateMetadataAsync(createdMetadata.ItemId, createdMetadata.Key, newTestMetadataValue);

            Assert.AreEqual(createdMetadata.ItemId, updatedMetadata.ItemId, "Item ids should have been same");
            Assert.AreEqual(updatedMetadata.Key, updatedMetadata.Key, "Metadata keys should have been same");
            Assert.AreEqual(newTestMetadataValue, updatedMetadata.Value, "Metadata values should have been same");

            try
            {
                await itemBusiness.UpdateMetadataAsync(int.MaxValue, createdMetadata.Key, newTestMetadataValue);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            await itemBusiness.DeleteMetadataAsync(updatedMetadata.ItemId, updatedMetadata.Key);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.ItemManagement")]
        public async Task DeleteItemMetadataAsyncTest()
        {
            string testMetadataKey = Guid.NewGuid().ToString();
            string testMetadataValue = Guid.NewGuid().ToString();
            var createdMetadata = await itemBusiness.AddMetadataAsync(sampleItemId, testMetadataKey, testMetadataValue);

            await itemBusiness.DeleteMetadataAsync(createdMetadata.ItemId, createdMetadata.Key);

            try
            {
                await itemBusiness.GetAllMetadataAsync(createdMetadata.ItemId);
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            try
            {
                await itemBusiness.DeleteMetadataAsync(createdMetadata.ItemId, createdMetadata.Key);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.ItemManagement")]
        public async Task ClearItemMetadataAsyncTest()
        {
            int previousMetadataCount = 0;
            try
            {
                previousMetadataCount = (await itemBusiness.GetAllMetadataAsync(sampleItemId)).Count;
            }
            catch
            {

            }

            for (int i = 0; i < 3; i++)
            {
                await itemBusiness.AddMetadataAsync(sampleItemId, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            }

            var metadataList = await itemBusiness.GetAllMetadataAsync(sampleItemId);

            Assert.AreEqual(3 + previousMetadataCount, metadataList.Count, "Total Item Metadata count should have been 3");

            await itemBusiness.ClearMetadataAsync(sampleItemId);

            try
            {
                await itemBusiness.GetAllMetadataAsync(sampleItemId);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            try
            {
                await itemBusiness.ClearMetadataAsync(int.MaxValue);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.ItemManagement")]
        public async Task AddItemRelationAsyncTest()
        {
            List<int> relatedItemIds = new List<int>();

            for (int i = 1; i <= 3; i++)
            {
                var item = await itemManagementFixture.CreateSampleItem();
                relatedItemIds.Add(item.Id);
            }

            await itemBusiness.AddItemRelationAsync(sampleItemId, relatedItemIds, Model.Catalog.ItemRelationDirection.OneWay);
            var relatedItems = await itemBusiness.GetRelatedItemsAsync(sampleItemId);

            Assert.AreEqual(relatedItemIds.Count, relatedItems.Count, "Related Item Counts did not match ");

            CollectionAssert.AreEquivalent(relatedItemIds, relatedItems, "Related Item ids did not match");

            for (int i = 0; i < relatedItems.Count; i++)
            {
                await itemBusiness.DeleteItemRelationAsync(sampleItemId, relatedItemIds[i], Model.Catalog.ItemRelationDirection.OneWay);
            }

            //Test two way relation

            var relatedItemIds2 = new List<int>() { relatedItemIds[0] };
            await itemBusiness.AddItemRelationAsync(sampleItemId, relatedItemIds2, Model.Catalog.ItemRelationDirection.TwoWay);

            relatedItems = await itemBusiness.GetRelatedItemsAsync(sampleItemId);

            CollectionAssert.AreEquivalent(relatedItemIds2, relatedItems, "Related Item ids did not match");

            relatedItems = await itemBusiness.GetRelatedItemsAsync(relatedItemIds2[0]);

            CollectionAssert.AreEquivalent(new List<int> { sampleItemId }, relatedItems, "Related item ids did not match");

            for (int i = 0; i < relatedItems.Count; i++)
            {
                await itemBusiness.DeleteItemRelationAsync(sampleItemId, relatedItemIds2[i], Model.Catalog.ItemRelationDirection.OneWay);
            }

            try
            {
                await itemBusiness.AddItemRelationAsync(int.MaxValue, relatedItemIds2, ItemRelationDirection.TwoWay);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            try
            {
                await itemBusiness.AddItemRelationAsync(sampleItemId, new List<int> { int.MaxValue }, ItemRelationDirection.TwoWay);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            await itemBusiness.ClearRelatedItemsAsync(sampleItemId, ItemRelationDirection.TwoWay);

            foreach (var itemId in relatedItemIds)
            {
                await itemManagementFixture.DeleteItemBrandCategoryByItemId(itemId);
            }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.ItemManagement")]
        public async Task DeleteItemRelationAsyncTest()
        {
            int relatedItemId = (await itemManagementFixture.CreateSampleItem()).Id;

            await itemBusiness.AddItemRelationAsync(sampleItemId, new List<int> { relatedItemId }, ItemRelationDirection.TwoWay);

            var relatedItems = await itemBusiness.GetRelatedItemsAsync(sampleItemId);

            Assert.IsTrue(relatedItems.Count > 0, "Related items count should be greater than 1");

            await itemBusiness.DeleteItemRelationAsync(sampleItemId, relatedItemId, ItemRelationDirection.OneWay);

            relatedItems = await itemBusiness.GetRelatedItemsAsync(relatedItemId);

            Assert.IsTrue(relatedItems.Any(x => x == sampleItemId), "Related item collection should contain sampleItemId");

            await itemBusiness.DeleteItemRelationAsync(relatedItemId, sampleItemId, ItemRelationDirection.TwoWay);

            try
            {
                await itemBusiness.DeleteItemRelationAsync(int.MaxValue, sampleItemId, ItemRelationDirection.TwoWay);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            try
            {
                await itemBusiness.DeleteItemRelationAsync(sampleItemId, int.MaxValue, ItemRelationDirection.TwoWay);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            await itemManagementFixture.DeleteItemBrandCategoryByItemId(relatedItemId);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.ItemManagement")]
        public async Task GetRelatedItemsAsyncTest()
        {
            int relatedItemId = (await itemManagementFixture.CreateSampleItem()).Id;
            var relatedItemIds = new List<int> { relatedItemId };

            await itemBusiness.AddItemRelationAsync(sampleItemId, relatedItemIds, ItemRelationDirection.TwoWay);

            var relatedItems = await itemBusiness.GetRelatedItemsAsync(sampleItemId);

            CollectionAssert.AreEquivalent(relatedItemIds, relatedItems, "Related items did not match");

            relatedItems = await itemBusiness.GetRelatedItemsAsync(relatedItemId);

            CollectionAssert.AreEquivalent(new List<int> { sampleItemId }, relatedItems, "Related items did not match");

            await itemBusiness.DeleteItemRelationAsync(sampleItemId, relatedItemId, ItemRelationDirection.TwoWay);

            try
            {
                await itemBusiness.GetRelatedItemsAsync(int.MaxValue);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            await itemManagementFixture.DeleteItemBrandCategoryByItemId(relatedItemId);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.ItemManagement")]
        public async Task ClearRelatedItemsAsyncTest()
        {
            int relatedItemId = (await itemManagementFixture.CreateSampleItem()).Id;
            var relatedItemIds = new List<int> { relatedItemId };
            await itemBusiness.AddItemRelationAsync(sampleItemId, relatedItemIds, ItemRelationDirection.TwoWay);
            var relatedItems = await itemBusiness.GetRelatedItemsAsync(sampleItemId);

            CollectionAssert.AreEquivalent(relatedItemIds, relatedItems, "Related items did not match");

            await itemBusiness.ClearRelatedItemsAsync(sampleItemId, ItemRelationDirection.OneWay);

            try
            {
                relatedItems = await itemBusiness.GetRelatedItemsAsync(sampleItemId);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            relatedItems = await itemBusiness.GetRelatedItemsAsync(relatedItemId);

            CollectionAssert.AreEquivalent(new List<int> { sampleItemId }, relatedItems, "Related items did not match");

            await itemBusiness.ClearRelatedItemsAsync(sampleItemId, ItemRelationDirection.TwoWay);

            try
            {
                relatedItems = await itemBusiness.GetRelatedItemsAsync(relatedItemId);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            await itemBusiness.ClearRelatedItemsAsync(sampleItemId, ItemRelationDirection.TwoWay);
            await itemManagementFixture.DeleteItemBrandCategoryByItemId(relatedItemId);
        }
    }
}
