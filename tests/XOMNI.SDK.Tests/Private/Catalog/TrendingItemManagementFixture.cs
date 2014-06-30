using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XOMNI.Data.Model.Tenant.Catalog;
using XOMNI.SDK.Management.Configuration;
using XOMNI.SDK.Model.Private.Catalog;
using XOMNI.SDK.Private.Catalog;

namespace XOMNI.SDK.Tests.Private.Catalog
{
    [TestClass]
    public class TrendingItemManagementFixture : SDKFixtureBase
    {
        private TrendingItemManagement trendingItemClient;

        public override void Init()
        {
            base.Init();
            trendingItemClient = new TrendingItemManagement();
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.TrendingItemManagement")]
        public async Task ShouldGetSpecifiedTopTrendingItemsWithoutActionDetailsTest()
        {
            // Arrange
            int top = 5;
            RemoveAllPopularityRecords();
            for (int i = 0; i < 10; i++)
            {
                await CreateSamplePopularityRecords();
            }

            // Act
            IEnumerable<TrendingItemDto> trendingItems =  await trendingItemClient.GetTrendingItemsAsync(top);

            // Assert
            Assert.AreEqual(top, trendingItems.Count());
            Assert.IsTrue(trendingItems.First().ItemPopularityRecords == null || trendingItems.First().ItemPopularityRecords.Any() == false);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.TrendingItemManagement")]
        public async Task ShouldGetSpecifiedTopTrendingItemsWithActionDetailsTest()
        {
            // Arrange
            int top = 5;
            RemoveAllPopularityRecords();
            for (int i = 0; i < 10; i++)
            {
                await CreateSamplePopularityRecords();
            }

            // Act
            IEnumerable<TrendingItemDto> trendingItems = await trendingItemClient.GetTrendingItemsAsync(top, true);

            // Assert
            Assert.AreEqual(top, trendingItems.Count());
            Assert.IsTrue(trendingItems.First().ItemPopularityRecords != null || trendingItems.First().ItemPopularityRecords.Any() == true);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.TrendingItemManagement")]
        public async Task ShouldGetSpecifiedTopTrendingItemsByBrandIdWithoutActionDetailsTest()
        {
            // Arrange
            int top = 5;
            RemoveAllPopularityRecords();
            var addedBrand = await new BrandManagementFixture().CreateSampleBrand();
            for (int i = 0; i < 10; i++)
            {
                var item = await CreateSampleItem(addedBrand.Id);
                CreateSamplePopularityRecords(item);
            }

            // Act
            IEnumerable<TrendingItemDto> trendingItems = await trendingItemClient.GetTrendingItemsByBrandIdAsync(top, addedBrand.Id);

            // Assert
            Assert.AreEqual(top, trendingItems.Count());
            Assert.IsTrue(trendingItems.First().ItemPopularityRecords == null || trendingItems.First().ItemPopularityRecords.Any() == false);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.TrendingItemManagement")]
        public async Task ShouldGetSpecifiedTopTrendingItemsByBrandIdWithActionDetailsTest()
        {
            // Arrange
            int top = 5;
            RemoveAllPopularityRecords();
            var addedBrand = await new BrandManagementFixture().CreateSampleBrand();
            for (int i = 0; i < 10; i++)
            {
                var item = await CreateSampleItem(addedBrand.Id);
                CreateSamplePopularityRecords(item);
            }

            // Act
            IEnumerable<TrendingItemDto> trendingItems = await trendingItemClient.GetTrendingItemsByBrandIdAsync(top, addedBrand.Id, true);

            // Assert
            Assert.AreEqual(top, trendingItems.Count());
            Assert.IsTrue(trendingItems.First().ItemPopularityRecords != null && trendingItems.First().ItemPopularityRecords.Any() == true);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.TrendingItemManagement")]
        public async Task ShouldGetSpecifiedTopTrendingItemsByStoreIdWithoutActionDetailsTest()
        {
            // Arrange
            int top = 5;
            RemoveAllPopularityRecords();
            StoreManagement storeManagement = new StoreManagement();
            Model.Management.Configuration.Store store = await storeManagement.AddAsync(GetValidStore());
            for (int i = 0; i < 10; i++)
            {
                await CreateSamplePopularityRecords(store.Id);
            }

            // Act
            IEnumerable<TrendingItemDto> trendingItems = await trendingItemClient.GetTrendingItemsByStoreIdAsync(top, store.Id);

            // Assert
            Assert.AreEqual(top, trendingItems.Count());
            Assert.IsTrue(trendingItems.First().ItemPopularityRecords == null || trendingItems.First().ItemPopularityRecords.Any() == false);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.TrendingItemManagement")]
        public async Task ShouldGetSpecifiedTopTrendingItemsByStoreIdWithActionDetailsTest()
        {
            // Arrange
            int top = 5;
            RemoveAllPopularityRecords();
            StoreManagement storeManagement = new StoreManagement();
            Model.Management.Configuration.Store store = await storeManagement.AddAsync(GetValidStore());
            for (int i = 0; i < 10; i++)
            {
                await CreateSamplePopularityRecords(store.Id);
            }

            // Act
            IEnumerable<TrendingItemDto> trendingItems = await trendingItemClient.GetTrendingItemsByStoreIdAsync(top, store.Id, true);

            // Assert
            Assert.AreEqual(top, trendingItems.Count());
            Assert.IsTrue(trendingItems.First().ItemPopularityRecords != null && trendingItems.First().ItemPopularityRecords.Any() == true);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.TrendingItemManagement")]
        public async Task ShouldGetSpecifiedTopTrendingItemsByStoreAndBrandIdWithoutActionDetailsTest()
        {
            // Arrange
            int top = 5;
            RemoveAllPopularityRecords();
            StoreManagement storeManagement = new StoreManagement();
            var addedBrand = await new BrandManagementFixture().CreateSampleBrand();
            Model.Management.Configuration.Store store = await storeManagement.AddAsync(GetValidStore());

            for (int i = 0; i < 10; i++)
            {
                var item = await CreateSampleItem(addedBrand.Id);
                CreateSamplePopularityRecords(item, store.Id);
            }

            // Act
            IEnumerable<TrendingItemDto> trendingItems = await trendingItemClient.GetTrendingItemsByStoreAndBrandIdAsync(top, store.Id, addedBrand.Id);

            // Assert
            Assert.AreEqual(top, trendingItems.Count());
            Assert.IsTrue(trendingItems.First().ItemPopularityRecords == null || trendingItems.First().ItemPopularityRecords.Any() == false);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.TrendingItemManagement")]
        public async Task ShouldGetSpecifiedTopTrendingItemsByStoreAndBrandIdWithActionDetailsTest()
        {
            // Arrange
            int top = 5;
            RemoveAllPopularityRecords();
            StoreManagement storeManagement = new StoreManagement();
            var addedBrand = await new BrandManagementFixture().CreateSampleBrand();
            Model.Management.Configuration.Store store = await storeManagement.AddAsync(GetValidStore());

            for (int i = 0; i < 10; i++)
            {
                var item = await CreateSampleItem(addedBrand.Id);
                CreateSamplePopularityRecords(item, store.Id);
            }

            // Act
            IEnumerable<TrendingItemDto> trendingItems = await trendingItemClient.GetTrendingItemsByStoreAndBrandIdAsync(top, store.Id, addedBrand.Id, true);

            // Assert
            Assert.AreEqual(top, trendingItems.Count());
            Assert.IsTrue(trendingItems.First().ItemPopularityRecords != null && trendingItems.First().ItemPopularityRecords.Any() == true);
        }

        // private helpers

        private async Task<Model.Private.Catalog.Item> CreateSampleItem(int brandId)
        {
            var addedCategory = await new CategoryManagementFixture().CreateSampleCategory();
            var addedItem = await new ItemManagement().AddAsync(new Model.Private.Catalog.Item
            {
                Name = Guid.NewGuid().ToString(),
                Title = Guid.NewGuid().ToString(),
                ShortDescription = Guid.NewGuid().ToString(),
                InStock = true,
                Model = Guid.NewGuid().ToString(),
                LikeCount = new Random().Next(0, 100),
                LongDescription = Guid.NewGuid().ToString(),
                UUID = Guid.NewGuid().ToString(),
                PublicWebLink = Guid.NewGuid().ToString(),
                SKU = new Random().Next(0, 100000).ToString(),
                Rating = new Random().Next(0, 5),
                RFID = Guid.NewGuid().ToString(),
                BrandId = brandId,
                CategoryId = addedCategory.Id
            });

            return addedItem;
        }

        private async Task<Model.Private.Catalog.Item> CreateSamplePopularityRecords(int? storeId = null)
        {
            var addedBrand = await new BrandManagementFixture().CreateSampleBrand();
            Model.Private.Catalog.Item item = await CreateSampleItem(addedBrand.Id);
            CreateSamplePopularityRecords(item, storeId);

            return item;
        }

        private void CreateSamplePopularityRecords(Model.Private.Catalog.Item item, int? storeId = null)
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                double timeImpact = random.NextDouble() * 15F;
                double actionImpact = random.NextDouble() * 15F;

                TestTenantDbContext.Value.ItemPopularityRecords.Add(new XOMNI.Data.Model.Tenant.Catalog.ItemPopularityRecord
                {
                    ItemId = item.Id,
                    StoreId = storeId,
                    ActionType = GetRandomActionType(),
                    TotalTimeImpactValue = timeImpact,
                    TotalActionTypeImpactValue = actionImpact,
                    TotalActionCount = 50,
                    TotalValue = timeImpact + actionImpact
                });
            }

            TestTenantDbContext.Value.SaveChanges();
        }

        private void RemoveAllPopularityRecords()
        {
            IEnumerable<ItemPopularityRecord> records = TestTenantDbContext.Value.ItemPopularityRecords.ToList();
            foreach (var record in records)
            {
                TestTenantDbContext.Value.ItemPopularityRecords.Remove(record);
            }

            TestTenantDbContext.Value.SaveChanges();
        }

        private Model.Management.Configuration.Store GetValidStore()
        {
            return new Model.Management.Configuration.Store
            {
                Address = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Location = new Model.Location(42.33D, 34.21D),
                Name = Guid.NewGuid().ToString()
            };
        }

        private PopularityActionType GetRandomActionType()
        {
            Array values = Enum.GetValues(typeof(PopularityActionType));
            Random random = new Random();
            PopularityActionType randomPopularityActionType = (PopularityActionType)values.GetValue(random.Next(values.Length));

            return randomPopularityActionType;
        }
    }
}