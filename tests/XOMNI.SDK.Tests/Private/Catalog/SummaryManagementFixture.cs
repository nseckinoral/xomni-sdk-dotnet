using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Tests.Private.Catalog
{
    [TestClass]
    public class SummaryManagementFixture : SDKFixtureBase
    {
        XOMNI.SDK.Private.Catalog.SummaryManagement summaryBusiness = null;
        XOMNI.SDK.Private.Catalog.BrandManagement brandBusiness = null;
        XOMNI.SDK.Private.Catalog.CategoryManagement categoryBusiness = null;

        public override void Init()
        {
            base.Init();
            summaryBusiness = new XOMNI.SDK.Private.Catalog.SummaryManagement();
            brandBusiness = new SDK.Private.Catalog.BrandManagement();
            categoryBusiness = new SDK.Private.Catalog.CategoryManagement();
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.SummaryManagement")]
        public async Task GetSummaryAsyncTest()
        {
            var summary = await summaryBusiness.GetAsync();

            Assert.IsTrue(summary.TotalActiveItemCount > -1, "Total Active Item Count should have been greater than 1");
            Assert.IsTrue(summary.TotalBrandCount > -1, "TotalBrandCount should have been greater than 1");
            Assert.IsTrue(summary.TotalCategoryCount > -1, "TotalCategoryCount should have been greater than 1");
            Assert.IsTrue(summary.TotalLicenceCount > -1, "TotalLicenceCount should have been greater than 1");
            Assert.IsTrue(summary.TotalPIIUserCount > -1, "TotalPIIUserCount should have been greater than 1");
            Assert.IsTrue(summary.TotalPrivateApiUserCount > -1, "TotalPrivateApiUserCount should have been greater than 1");
            Assert.IsTrue(summary.TotalStoreCount > -1, "TotalStoreCount should have been greater than 1");

            var category = await categoryBusiness.AddCategoryAsync(new Model.Private.Catalog.Category() { Name = Guid.NewGuid().ToString() });
            var brand = await brandBusiness.AddAsync(new Model.Catalog.Brand() { Name = Guid.NewGuid().ToString() });

            var newSummary = await summaryBusiness.GetAsync();

            Assert.AreEqual((summary.TotalBrandCount + 1), newSummary.TotalBrandCount, "TotalBrandCounts did not match");
            Assert.AreEqual((summary.TotalBrandCount + 1), newSummary.TotalBrandCount, "TotalCategoryCounts did not match");

            await categoryBusiness.DeleteCategoryAsync(category.Id);
            await brandBusiness.DeleteAsync(brand.Id);

            newSummary = await summaryBusiness.GetAsync();

            Assert.AreEqual(summary.TotalBrandCount, newSummary.TotalBrandCount, "TotalBrandCounts did not match");
            Assert.AreEqual(summary.TotalCategoryCount, newSummary.TotalCategoryCount, "TotalCategoryCounts did not match");

        }
    }
}
