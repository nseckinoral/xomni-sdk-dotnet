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
    public class ItemManagementFixture : BaseCRUDManagementFixture<Model.Private.Catalog.Item>
    {
        public override bool CheckConflictedEntity
        {
            get
            {
                return false;
            }
        }

        public override BaseCRUDSkipTakeManagement<Model.Private.Catalog.Item> CrudManagement
        {
            get { return new SDK.Private.Catalog.ItemManagement(); }
        }

        public override Model.Private.Catalog.Item GetBadEntityModel()
        {
            return new Model.Private.Catalog.Item()
            {
                BrandId = 9999999
            };
        }

        public override int GetNotFoundEntityId()
        {
            return 9999999;
        }

        public override Model.Private.Catalog.Item GetValidEntityModel()
        {
            var sampleItem = new Model.Private.Catalog.Item()
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
            };

            sampleItem.UnitTypeId = 3;
            sampleItem.BrandId = 1;
            sampleItem.CategoryId = 1;

            sampleItem.DynamicAttributes = new List<Model.Catalog.DynamicAttribute>()
            {
                new Model.Catalog.DynamicAttribute() { TypeName= "Color", Value = "Red" }, 
                new Model.Catalog.DynamicAttribute() { TypeName= "Size", Value = "XXXXXXXXL" }, 
                new Model.Catalog.DynamicAttribute() { TypeName= "Style", Value = "A Style" }
            };

            //sampleItem.Tags = new List<Model.Catalog.Tag>() 
            //{
            //    new Model.Catalog.Tag() { Id = 1, Name=" " },
            //    new Model.Catalog.Tag() { Id = 2, Name=" " },
            //    new Model.Catalog.Tag() { Id = 3, Name=" " }
            //};

            sampleItem.Weights = new List<Model.Private.Catalog.Weight>()
            {
                new Model.Private.Catalog.Weight() { WeightTypeId=1, Value=15},
            };

            sampleItem.Dimensions = new List<Model.Private.Catalog.Dimension>()
            {
                new Model.Private.Catalog.Dimension() { DimensionTypeId = 1, Depth = 50, Width = 60, Height = 70},
            };

            sampleItem.Prices = new List<Model.Private.Catalog.Price>()
            {
                new Model.Private.Catalog.Price() { PriceTypeId= 1, NormalPrice= 50 },
            };

            sampleItem.Metadata = new List<Metadata>()
            {
                new Metadata() { Key = Guid.NewGuid().ToString(), Value=Guid.NewGuid().ToString()},
                new Metadata() { Key = Guid.NewGuid().ToString(), Value=Guid.NewGuid().ToString()},
                new Metadata() { Key = Guid.NewGuid().ToString(), Value=Guid.NewGuid().ToString()}
            };

            return sampleItem;
        }

        public override int GetInUseEntityId()
        {
            return 0;
        }

        private int newItemId = 0;

        public override void CheckNewAddedEntity(Model.Private.Catalog.Item newEntityModel, Model.Private.Catalog.Item oldEntityModel)
        {
            Assert.IsTrue(newEntityModel.Id > 0, "ItemId must be greater than zero");
            Assert.AreEqual(newEntityModel.BrandId, oldEntityModel.BrandId, "BrandId field did not match");
            Assert.AreEqual(newEntityModel.CategoryId, oldEntityModel.CategoryId, "CategoryId field did not match");
            Assert.AreNotEqual(newEntityModel.DateAdded, default(DateTime), "DateAdded field should be different than default datettime");
            Assert.IsTrue(newEntityModel.Dimensions.Count > 0, "Dimensions count should be greater than 0");
            Assert.IsTrue(newEntityModel.DynamicAttributes.Count > 0, "DynamicAttributes count should be greater than 0");
            Assert.AreEqual(newEntityModel.InStock, oldEntityModel.InStock, "InStock field did not match");
            Assert.AreEqual(newEntityModel.LongDescription, oldEntityModel.LongDescription, "LongDescription field did not match");
            Assert.IsTrue(newEntityModel.Metadata.Count > 0, "Metadata count should be greater than 0");
            Assert.AreEqual(newEntityModel.Model, oldEntityModel.Model, "Model field did not match");
            Assert.AreEqual(newEntityModel.Name, oldEntityModel.Name, "Name field did not match");
            Assert.IsTrue(newEntityModel.Prices.Count > 0, "Prices count should be greater than 0");
            Assert.AreEqual(newEntityModel.PublicWebLink, oldEntityModel.PublicWebLink, "PublicWebLink field did not match");
            Assert.AreEqual(newEntityModel.Rating, oldEntityModel.Rating, "Rating field did not match");
            Assert.AreEqual(newEntityModel.RFID, oldEntityModel.RFID, "RFID field did not match");
            Assert.AreEqual(newEntityModel.ShortDescription, oldEntityModel.ShortDescription, "ShortDescription field did not match");
            Assert.AreEqual(newEntityModel.SKU, oldEntityModel.SKU, "SKU field did not match");
            Assert.AreEqual(newEntityModel.Title, oldEntityModel.Title, "Title field did not match");
            Assert.AreEqual(newEntityModel.UUID, oldEntityModel.UUID, "UUID field did not match");
            Assert.IsTrue(newEntityModel.Weights.Count > 0, "Weights count should be greater than 0");
            newItemId = newEntityModel.Id;
        }

        public override int GetMeYourNewFuckingEntityIdIWillDelete()
        {
            return newItemId;
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.ItemManagement")]
        public async Task PostGetUpdateDeleteItemTest()
        {
            try
            {
                //await base.CRUDTest();

                var retVal = await ((ItemManagement)CrudManagement).Search(new Model.Private.Catalog.ItemSearchRequest()
                {
                    //BrandId = 1,
                    IncludeDynamicNavigation = true,
                    IncludeItemStaticProperties = true,
                    IncludeItemDynamicProperties = true,
                    IncludeStaticNavigation = true,
                    Take = 100
                });

                var items = retVal.Items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Model.Private.Catalog.Item> CreateSampleItem()
        {
            var addedCategory = await new CategoryManagementFixture().CreateSampleCategory();

            var addedBrand = await new BrandManagementFixture().CreateSampleBrand();

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
                BrandId = addedBrand.Id,
                CategoryId = addedCategory.Id
            });

            return addedItem;
        }

        public async Task DeleteItemBrandCategoryByItemId(int itemId)
        {
            var item = await new ItemManagement().GetByIdAsync(itemId);
            await new ItemManagement().DeleteAsync(itemId);

            if (item.BrandId.HasValue)
            {
                await new BrandManagement().DeleteAsync(item.BrandId.Value);
            }

            if (item.CategoryId.HasValue)
            {
                await new CategoryManagement().DeleteCategoryAsync(item.CategoryId.Value);
            }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.ItemManagement")]
        public async Task UpdateItemPricesAsyncTest()
        {
            var sampleItem = await CreateSampleItem();
            ItemManagement itemManagement = new ItemManagement();
            PriceTypeManagement priceTypeManagement = new PriceTypeManagement();
            PriceType initialTestPriceType = null;
            PriceType testPriceType = null;

            Assert.IsNotNull(sampleItem.Prices, "Prices collection in an item could not be null.");

            bool createNewPriceType = false;
            try
            {
                var priceTypes = await priceTypeManagement.GetAllAsync(0, 10);
                initialTestPriceType = priceTypes.Results.FirstOrDefault();
            }
            catch (NotFoundException nex)
            {
                createNewPriceType = true;
            }

            if (createNewPriceType)
            {
                initialTestPriceType = await priceTypeManagement.AddAsync(new PriceType()
                    {
                        Description = "Initial Test Price Type",
                        PriceTypeSymbol = ":)"
                    });
            }

            testPriceType = await priceTypeManagement.AddAsync(new PriceType()
            {
                Description = "Test Price Type",
                PriceTypeSymbol = ":("
            });

            sampleItem.Prices.Add(new Model.Private.Catalog.Price()
                {
                    PriceTypeId = initialTestPriceType.Id,
                    DiscountPrice = 10,
                    ItemId = sampleItem.Id,
                    NormalPrice = 20,
                });

            sampleItem = await itemManagement.UpdateAsync(sampleItem);

            Assert.AreEqual(1, sampleItem.Prices.Count(), "Lenght of Prices collection should be 1");

            var price = sampleItem.Prices[0];

            Assert.AreEqual(initialTestPriceType.Id, price.PriceTypeId, "Price Type of the price should be initial price Type");
            Assert.AreEqual(10, price.DiscountPrice, "Discount price should be 10");
            Assert.AreEqual(20, price.NormalPrice, "Normal Price should be 20");

            sampleItem.Prices.Clear();
            sampleItem.Prices.Add(new Model.Private.Catalog.Price()
                {
                    PriceTypeId = testPriceType.Id,
                    DiscountPrice = 20,
                    NormalPrice = 30,
                    ItemId = sampleItem.Id
                });


            var prices = await itemManagement.UpdatePricesAsync(sampleItem.Id, sampleItem.Prices);

            Assert.AreEqual(1, prices.Count, "Length of result collection should be 1");
            Assert.AreEqual(testPriceType.Id, prices[0].PriceTypeId, "Price Type id should equal to testPriceType ");
            Assert.AreEqual(20, prices[0].DiscountPrice, "Discount price should be 20");
            Assert.AreEqual(30, prices[0].NormalPrice, "Normal price should be 30");
            Assert.AreEqual(sampleItem.Id, prices[0].ItemId, "Item id should be id of the sample item");

            prices = (await itemManagement.GetByIdAsync(sampleItem.Id)).Prices;

            Assert.AreEqual(1, prices.Count, "Length of result collection should be 1");
            Assert.AreEqual(testPriceType.Id, prices[0].PriceTypeId, "PriceType id should equal to testPriceType ");
            Assert.AreEqual(20, prices[0].DiscountPrice, "Discount price should be 20");
            Assert.AreEqual(30, prices[0].NormalPrice, "Normal price should be 30");
            Assert.AreEqual(sampleItem.Id, prices[0].ItemId, "Item id should be id of the sample item");

            try
            {
                //Check for invalid item ID
                prices = await itemManagement.UpdatePricesAsync(int.MaxValue, sampleItem.Prices);
            }
            catch (NotFoundException)
            {
                //OK
            }

            try
            {
                //Check for the invalid PriceType ID
                sampleItem.Prices[0].PriceTypeId = int.MaxValue;
                prices = await itemManagement.UpdatePricesAsync(sampleItem.Id, sampleItem.Prices);
            }
            catch (BadRequestException)
            {
                //OK
            }

            await itemManagement.DeleteAsync(sampleItem.Id);
            await priceTypeManagement.DeleteAsync(testPriceType.Id);
            if (createNewPriceType)
            {
                await priceTypeManagement.DeleteAsync(initialTestPriceType.Id);
            }

        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.ItemManagement")]
        public async Task UpdateItemDynamicAttributesAsyncTest()
        {
            var sampleItem = await CreateSampleItem();
            ItemManagement itemManagement = new ItemManagement();
            List<DynamicAttribute> dynamicAttributes = sampleItem.DynamicAttributes;
            dynamicAttributes.Add(new DynamicAttribute()
                {
                    TypeName = "test",
                    Value = "test"
                });
            dynamicAttributes.Add(new DynamicAttribute()
                {
                    TypeName = "test1",
                    Value = "test1"
                });
            var attributes = await itemManagement.UpdateDynamicAttributesAsync(sampleItem.Id, dynamicAttributes);

            CheckDynamicAttributes(attributes);

            Assert.AreEqual(dynamicAttributes.Count, attributes.Count, "Dynamic attribute collection counts should be same");
            Assert.IsTrue(attributes.Any(x => x.TypeName == "test" && x.Value == "test"), "Attribute list should contain newly added attributes");
            Assert.IsTrue(attributes.Any(x => x.TypeName == "test1" && x.Value == "test1"), "Attribute list should contain newly added attributes");

            dynamicAttributes.Clear();
            dynamicAttributes.Add(new DynamicAttribute()
                {
                    TypeName = "test",
                    Value = "test"
                });

            attributes = await itemManagement.UpdateDynamicAttributesAsync(sampleItem.Id, dynamicAttributes);
            CheckDynamicAttributes(attributes);
            Assert.AreEqual(dynamicAttributes.Count, attributes.Count, "Dynamic attribute collection counts should be same");
            Assert.IsTrue(attributes.Any(x => x.TypeName == "test" && x.Value == "test"), "Attribute list should contain newly added attributes");
            Assert.IsFalse(attributes.Any(x => x.TypeName == "test1" && x.Value == "test1"), "Attribute list should not contain deleted attributes");

            await itemManagement.DeleteAsync(sampleItem.Id);
        }

        private static void CheckDynamicAttributes(List<DynamicAttribute> attributes)
        {
            attributes.ForEach((attribute) =>
            {
                Assert.IsFalse(string.IsNullOrEmpty(attribute.TypeName), "Dynamic attribute type name shouldn't be null or empty");
                Assert.IsFalse(string.IsNullOrEmpty(attribute.Value), "Dynamic attribute type value shouldn't be null or empty");
                Assert.IsTrue(attribute.TypeId > 0, "Dynamic attribute type id should be greater than 0");
                Assert.IsTrue(attribute.TypeValueId > 0, "Dynamic attribute type value id should be greater than 0");
            });
        }
    }
}
