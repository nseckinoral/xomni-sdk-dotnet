using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Private.Catalog;

namespace XOMNI.SDK.Tests.Private.Catalog
{
    [TestClass]
    public class DynamicAttributeManagementFixture : SDKFixtureBase
    {
        private SDK.Private.Catalog.DynamicAttributeManagement dynamicAttributeManagement = null;

        private ItemManagementFixture itemManagementFixture = null;

        private List<Model.Catalog.DynamicAttribute> SampleDynamicAttributes = new List<Model.Catalog.DynamicAttribute>
        {
            new Model.Catalog.DynamicAttribute{TypeName="Color",Value="Black"},
            new Model.Catalog.DynamicAttribute{TypeName="Size",Value="XXXXXXS"},
            new Model.Catalog.DynamicAttribute{TypeName="Style",Value="Free Style"}
        };

        public override void Init()
        {
            base.Init();
            dynamicAttributeManagement = new SDK.Private.Catalog.DynamicAttributeManagement();
            itemManagementFixture = new ItemManagementFixture();
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.DynamicAttributeManagement")]
        public async Task GetDynamicAttributeByIdAsyncTest()
        {
            try
            {
                await dynamicAttributeManagement.GetByAttributeIdAsync(99999);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (SDK.Core.Exception.NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            var createdItem = await CreateItem();
            Assert.AreEqual(createdItem.DynamicAttributes.Count, SampleDynamicAttributes.Count, "Dynamic Attribute Lists count did not match.");

            foreach (var item in createdItem.DynamicAttributes)
            {
                var dynamicAttributeList = await dynamicAttributeManagement.GetByAttributeIdAsync(item.TypeId);
                Assert.IsTrue(dynamicAttributeList.Count > 0, "Dynamic Attribute Lists count must be greater than 0");

                foreach (var dynamicAttribute in dynamicAttributeList)
                {
                    CheckDynamicAttribute(dynamicAttribute);
                }
            }

            await itemManagementFixture.DeleteItemBrandCategoryByItemId(createdItem.Id);
        }

        public async Task<Model.Private.Catalog.Item> CreateItem()
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
                CategoryId = addedCategory.Id,
                DynamicAttributes = SampleDynamicAttributes
            });

            return addedItem;
        }

        public void CheckDynamicAttribute(Model.Catalog.DynamicAttribute dynamicAttribute)
        {
            Assert.IsTrue(dynamicAttribute.TypeId != default(int), "DynamicAttributeTypeId could not be zero.");
            Assert.IsTrue(!string.IsNullOrEmpty(dynamicAttribute.TypeName), "DynamicAttributeTypeName could not be null or empty.");
            Assert.IsTrue(dynamicAttribute.TypeValueId != default(int), "DynamicAttributeTypeValueId could not be zero.");
            Assert.IsTrue(!string.IsNullOrEmpty(dynamicAttribute.Value), "DynamicAttributeType Value could not be null or empty.");
        }
    }
}
