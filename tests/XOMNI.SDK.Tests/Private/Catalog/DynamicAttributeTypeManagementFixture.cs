using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Tests.Private.Catalog
{
    [TestClass]
    public class DynamicAttributeTypeManagementFixture : SDKFixtureBase
    {
        private SDK.Private.Catalog.DynamicAttributeTypeManagement dynamicAttributeTypeManagement = null;
        private DynamicAttributeManagementFixture dynamicAttributeManagementFixture = null;
        private ItemManagementFixture itemManagementFixture = null;

        public int Skip { get; set; }
        public int Take { get; set; }

        public override void Init()
        {
            base.Init();
            Skip = 0;
            Take = 100;
            dynamicAttributeTypeManagement = new SDK.Private.Catalog.DynamicAttributeTypeManagement();
            itemManagementFixture = new ItemManagementFixture();
            dynamicAttributeManagementFixture = new DynamicAttributeManagementFixture();
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.DynamicAttributeTypeManagement")]
        public async Task GetAllDynamicAttributeTypeAsyncTest()
        {
            var createdItem = await dynamicAttributeManagementFixture.CreateItem();

            var dynamicAttributeTypes = await dynamicAttributeTypeManagement.GetAllAsync(Skip, Take);
            Assert.IsTrue(dynamicAttributeTypes.TotalCount > 1, "Total dynamic attribute type count did not match.");

            foreach (var item in dynamicAttributeTypes.Results)
            {
                Assert.IsTrue(item.Id != default(int), "DynamicAttributeTypeId could not be zero.");
                Assert.IsTrue(!string.IsNullOrEmpty(item.Description), "DynamicAttributeType Description could not be null or empty.");
            }

            //Cleaning dynamic attributes
            await itemManagementFixture.DeleteItemBrandCategoryByItemId(createdItem.Id);
        }
    }
}
