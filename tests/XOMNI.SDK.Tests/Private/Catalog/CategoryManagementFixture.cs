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

namespace XOMNI.SDK.Tests.Private.Catalog
{
    [TestClass]
    public class CategoryManagementFixture : CatalogAssetBaseFixture
    {
        XOMNI.SDK.Private.Catalog.CategoryManagement categoryBusiness = null;

        public override async void Init()
        {
            base.Init();
            categoryBusiness = new XOMNI.SDK.Private.Catalog.CategoryManagement();
        }

        [TestInitialize]
        public void Initialize()
        {
            sampleCategoryId = CreateSampleCategory().Result.Id;
        }

        [TestCleanup]
        public void CleanUp()
        {
            categoryBusiness.DeleteCategoryAsync(sampleCategoryId).Wait();
        }

        private int sampleCategoryId;
        public override int relatedId
        {
            get { return sampleCategoryId; }
        }

        public override SDK.Private.Catalog.IAssetRelation CatalogAssetBaseBusiness
        {
            get { return categoryBusiness; }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.CategoryManagement")]
        public async Task PostGetUpdateDeleteCategoryDocumentRelationTest()
        {
            await base.PostGetUpdateDeleteDocumentRelationTest();
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.CategoryManagement")]
        public async Task PostGetUpdateDeleteCategoryVideoRelationTest()
        {
            await base.PostGetUpdateDeleteVideoRelationTest();
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.CategoryManagement")]
        public async Task PostGetUpdateDeleteCategoryImageRelationTest()
        {
            await base.PostGetUpdateDeleteImageRelationTest();
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.CategoryManagement")]
        public async Task AddCategoryMetadataAsyncTest()
        {
            string testMetadataKey = Guid.NewGuid().ToString();
            string testMetadataValue = Guid.NewGuid().ToString();
            var createdMetadata = await categoryBusiness.AddMetadataAsync(sampleCategoryId, testMetadataKey, testMetadataValue);

            Assert.AreEqual(sampleCategoryId, createdMetadata.CategoryId, "Category ids did not match");
            Assert.AreEqual(testMetadataKey, createdMetadata.Key, "Metdata keys did not match");
            Assert.AreEqual(testMetadataValue, createdMetadata.Value, "Metadata values did not match");

            try
            {
                await categoryBusiness.AddMetadataAsync(int.MaxValue, testMetadataKey, testMetadataValue);
                Assert.Fail("Bad request exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk.
            }

            try
            {
                await categoryBusiness.AddMetadataAsync(sampleCategoryId, testMetadataKey, testMetadataValue);
                Assert.Fail("Conflict exception should have been returned from sdk");
            }
            catch (ConflictException)
            {
                //Conflict exception should have been returned from sdk
            }

            try
            {
                await categoryBusiness.AddMetadataAsync(sampleCategoryId, null, null);
                Assert.Fail("Argument null exception should have been returned from sdk");
            }
            catch (ArgumentNullException)
            {
                //Argument null exception should have been returned from sdk
            }

            await categoryBusiness.DeleteMetadataAsync(createdMetadata.CategoryId, createdMetadata.Key);
        }


        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.CategoryManagement")]
        public async Task GetAllCategoryMetadataAsyncTest()
        {
            List<Metadata> createdMetadata = new List<Metadata>();
            for (int i = 1; i <= 5; i++)
            {
                var metadata = await categoryBusiness.AddMetadataAsync(sampleCategoryId, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
                createdMetadata.Add(metadata);
            }

            List<Metadata> fetchedMetadata = await categoryBusiness.GetAllMetadataAsync(sampleCategoryId);

            Assert.IsTrue(fetchedMetadata.TrueForAll(q => createdMetadata.Select(x => x.Key).Contains(q.Key) && createdMetadata.Select(x => x.Value).Contains(q.Value)), "Created and fetched metadata lists did not match.");

            try
            {
                await categoryBusiness.GetAllMetadataAsync(int.MaxValue);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            foreach (var metadata in fetchedMetadata)
            {
                await categoryBusiness.DeleteMetadataAsync(sampleCategoryId, metadata.Key);
            }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.CategoryManagement")]
        public async Task UpdateCategoryMetadataAsyncTest()
        {
            string testMetadataKey = Guid.NewGuid().ToString();
            string testMetadataValue = Guid.NewGuid().ToString();
            var createdMetadata = await categoryBusiness.AddMetadataAsync(sampleCategoryId, testMetadataKey, testMetadataValue);
            string newTestMetadataValue = Guid.NewGuid().ToString();

            var updatedMetadata = await categoryBusiness.UpdateMetadataAsync(createdMetadata.CategoryId, createdMetadata.Key, newTestMetadataValue);

            Assert.AreEqual(createdMetadata.CategoryId, updatedMetadata.CategoryId, "Category ids should have been same");
            Assert.AreEqual(updatedMetadata.Key, updatedMetadata.Key, "Metadata keys should have been same");
            Assert.AreEqual(newTestMetadataValue, updatedMetadata.Value, "Metadata values should have been same");

            try
            {
                await categoryBusiness.UpdateMetadataAsync(int.MaxValue, createdMetadata.Key, newTestMetadataValue);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            await categoryBusiness.DeleteMetadataAsync(updatedMetadata.CategoryId, updatedMetadata.Key);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.CategoryManagement")]
        public async Task DeleteCategoryMetadataAsyncTest()
        {
            string testMetadataKey = Guid.NewGuid().ToString();
            string testMetadataValue = Guid.NewGuid().ToString();
            var createdMetadata = await categoryBusiness.AddMetadataAsync(sampleCategoryId, testMetadataKey, testMetadataValue);

            await categoryBusiness.DeleteMetadataAsync(createdMetadata.CategoryId, createdMetadata.Key);

            try
            {
                var list = await categoryBusiness.GetAllMetadataAsync(createdMetadata.CategoryId);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            try
            {
                await categoryBusiness.DeleteMetadataAsync(createdMetadata.CategoryId, createdMetadata.Key);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.CategoryManagement")]
        public async Task ClearCategoryMetadataAsyncTest()
        {
            List<CategoryMetaData> categoryMetadata = new List<CategoryMetaData>();

            for (int i = 0; i < 5; i++)
            {
                string testMetadataKey = Guid.NewGuid().ToString();
                string testMetadataValue = Guid.NewGuid().ToString();
                var createdMetadata = await categoryBusiness.AddMetadataAsync(sampleCategoryId, testMetadataKey, testMetadataValue);
                categoryMetadata.Add(createdMetadata);
            }
            var allMetadata = await categoryBusiness.GetAllMetadataAsync(sampleCategoryId);

            Assert.IsTrue(allMetadata.Count > 0, "Total category metadata count should have been greater than 0");

            await categoryBusiness.ClearMetadataAsync(sampleCategoryId);

            try
            {
                await categoryBusiness.GetAllMetadataAsync(sampleCategoryId);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            try
            {
                await categoryBusiness.ClearMetadataAsync(int.MaxValue);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.CategoryManagement")]
        public async Task AddCategoryAsyncTest()
        {
            var category = new Model.Private.Catalog.Category()
            {
                ShortDescription = Guid.NewGuid().ToString(),
                LongDescription = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString()
            };

            var addedCategory = await categoryBusiness.AddCategoryAsync(category);
            CheckCategories(category, addedCategory);

            var childCategory = new Model.Private.Catalog.Category()
            {
                ParentCategoryId = addedCategory.Id,
                Name = Guid.NewGuid().ToString(),
                LongDescription = Guid.NewGuid().ToString(),
                ShortDescription = Guid.NewGuid().ToString(),
            };

            var addedChildCategory = await categoryBusiness.AddCategoryAsync(childCategory);
            CheckCategories(childCategory, addedChildCategory);

            var categories = await categoryBusiness.GetCategoryAsync(addedCategory.Id);

            Assert.IsTrue(categories.SubCategoryCount == 1, "SubcategoryCount should have been 1");

            try
            {
                await categoryBusiness.AddCategoryAsync(category);
                Assert.Fail("Conflict exception should have been returned from sdk");
            }
            catch (ConflictException)
            {
                //Conflict exception should have been returned from sdk
            }

            try
            {
                category.ParentCategoryId = int.MaxValue;
                await categoryBusiness.AddCategoryAsync(category);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            await categoryBusiness.DeleteCategoryAsync(addedChildCategory.Id);
            await categoryBusiness.DeleteCategoryAsync(addedCategory.Id);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.CategoryManagement")]
        public async Task UpdateCategoryAsyncTest()
        {
            var category = new Model.Private.Catalog.Category()
            {
                ShortDescription = Guid.NewGuid().ToString(),
                LongDescription = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString()
            };
            var addedCategory = await categoryBusiness.AddCategoryAsync(category);
            CheckCategories(category, addedCategory);

            var category2 = new Model.Private.Catalog.Category()
            {
                ShortDescription = Guid.NewGuid().ToString(),
                LongDescription = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString()
            };
            var addedCategory2 = await categoryBusiness.AddCategoryAsync(category2);
            CheckCategories(category2, addedCategory2);

            addedCategory.ShortDescription = Guid.NewGuid().ToString();
            addedCategory.LongDescription = Guid.NewGuid().ToString();
            addedCategory.Name = Guid.NewGuid().ToString();
            addedCategory.ParentCategoryId = addedCategory2.Id;

            var updatedCategory = await categoryBusiness.UpdateCategoryAsync(addedCategory);
            CheckCategories(addedCategory, updatedCategory);

            try
            {
                addedCategory.ParentCategoryId = int.MaxValue;
                await categoryBusiness.UpdateCategoryAsync(addedCategory);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            int id = addedCategory.Id;
            try
            {
                addedCategory.ParentCategoryId = null;
                addedCategory.Id = int.MaxValue;
                await categoryBusiness.UpdateCategoryAsync(addedCategory);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            addedCategory.Id = id;
            await categoryBusiness.DeleteCategoryAsync(addedCategory.Id);
            await categoryBusiness.DeleteCategoryAsync(addedCategory2.Id);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.CategoryManagement")]
        public async Task DeleteCategoryAsyncTest()
        {
            var category = new Model.Private.Catalog.Category()
            {
                ShortDescription = Guid.NewGuid().ToString(),
                LongDescription = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString()
            };
            var addedCategory = await categoryBusiness.AddCategoryAsync(category);
            CheckCategories(category, addedCategory);

            var category2 = new Model.Private.Catalog.Category()
            {
                ShortDescription = Guid.NewGuid().ToString(),
                LongDescription = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString(),
                ParentCategoryId = addedCategory.Id,
            };
            var addedCategory2 = await categoryBusiness.AddCategoryAsync(category2);
            CheckCategories(category2, addedCategory2);

            try
            {
                await categoryBusiness.DeleteCategoryAsync(addedCategory.Id);
                Assert.Fail("Conflict exception should have been returned from sdk");
            }
            catch (ConflictException)
            {
                //Conflict exception should have been returned from sdk
            }

            await categoryBusiness.DeleteCategoryAsync(addedCategory2.Id);
            await categoryBusiness.DeleteCategoryAsync(addedCategory.Id);

            try
            {
                await categoryBusiness.GetCategoryAsync(addedCategory.Id);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            try
            {
                await categoryBusiness.DeleteCategoryAsync(int.MaxValue);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.CategoryManagement")]
        public async Task GetCategoryAsyncTest()
        {
            var category = new Model.Private.Catalog.Category()
            {
                ShortDescription = Guid.NewGuid().ToString(),
                LongDescription = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString()
            };
            var addedCategory = await categoryBusiness.AddCategoryAsync(category);
            CheckCategories(category, addedCategory);

            var category2 = new Model.Private.Catalog.Category()
            {
                ShortDescription = Guid.NewGuid().ToString(),
                LongDescription = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString(),
                ParentCategoryId = addedCategory.Id
            };
            var addedCategory2 = await categoryBusiness.AddCategoryAsync(category2);
            CheckCategories(category2, addedCategory2);

            category = await categoryBusiness.GetCategoryAsync(addedCategory.Id);
            CheckCategories(addedCategory, category);

            Assert.IsTrue(category.SubCategoryCount == 1, "SubCategoryCount should have beem 1");

            category = await categoryBusiness.GetCategoryAsync(addedCategory2.Id);
            CheckCategories(addedCategory2, category);

            Assert.IsTrue(category.SubCategoryCount == 0, "SubCategoryCount should have beem 1");

            await categoryBusiness.DeleteCategoryAsync(addedCategory2.Id);
            await categoryBusiness.DeleteCategoryAsync(addedCategory.Id);

            try
            {
                await categoryBusiness.GetCategoryAsync(int.MaxValue);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.CategoryManagement")]
        public async Task GetCategoryTreeAsyncTest()
        {
            List<Model.Private.Catalog.Category> childCategories = new List<Model.Private.Catalog.Category>();
            var category = new Model.Private.Catalog.Category()
            {
                ShortDescription = Guid.NewGuid().ToString(),
                LongDescription = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString()
            };
            var addedCategory = await categoryBusiness.AddCategoryAsync(category);
            CheckCategories(category, addedCategory);

            for (int i = 0; i < 5; i++)
            {
                var category2 = new Model.Private.Catalog.Category()
                {
                    ShortDescription = Guid.NewGuid().ToString(),
                    LongDescription = Guid.NewGuid().ToString(),
                    Name = Guid.NewGuid().ToString(),
                    ParentCategoryId = addedCategory.Id
                };
                var addedCategory2 = await categoryBusiness.AddCategoryAsync(category2);
                CheckCategories(category2, addedCategory2);
                childCategories.Add(addedCategory2);
            }

            var categoryTree = await categoryBusiness.GetCategoryTreeAsync();

            Assert.IsTrue(categoryTree.Categories.Count > 0, "Category count should have been greater than 0");

            var categoryTreeItem = categoryTree.Categories.Where(x => x.Id == addedCategory.Id).SingleOrDefault();
            CheckCategoryTreeItems(addedCategory, categoryTreeItem);

            Assert.IsTrue(categoryTreeItem.CategoryTreeItems.Count == 5, "Child category count should have been 5");

            for (int i = 0; i < 5; i++)
            {
                CheckCategoryTreeItems(childCategories[i], categoryTreeItem.CategoryTreeItems[i]);
            }

            for (int i = 0; i < 5; i++)
            {
                await categoryBusiness.DeleteCategoryAsync(childCategories[i].Id);
            }
            await categoryBusiness.DeleteCategoryAsync(addedCategory.Id);
        }

        public void CheckCategories(Category expected, Category actual)
        {
            Assert.IsTrue(actual.Id > 0, "Category ids must be greater than 0");
            Assert.AreEqual(expected.Name, actual.Name, "Category Names did not match");
            Assert.AreEqual(expected.ParentCategoryId, actual.ParentCategoryId, "Category ParentCategoryIds did not match");
            Assert.AreEqual(expected.LongDescription, actual.LongDescription, "Category LongDescriptions did not match");
            Assert.AreEqual(expected.ShortDescription, actual.ShortDescription, "Category ShortDescriptions did not match");
        }

        public void CheckCategoryTreeItems(Category expected, CategoryTreeItem actual)
        {
            Assert.IsTrue(actual.Id > 0, "Category ids must be greater than 0");
            Assert.AreEqual(expected.Name, actual.Name, "Category Names did not match");
            Assert.AreEqual(expected.LongDescription, actual.LongDescription, "Category LongDescriptions did not match");
            Assert.AreEqual(expected.ShortDescription, actual.ShortDescription, "Category ShortDescriptions did not match");
        }



        public async Task<Category> CreateSampleCategory()
        {
            return await categoryBusiness.AddCategoryAsync(new Model.Private.Catalog.Category
            {
                Name = Guid.NewGuid().ToString(),
                LongDescription = Guid.NewGuid().ToString(),
                ShortDescription = Guid.NewGuid().ToString()
            });
        }
    }
}
