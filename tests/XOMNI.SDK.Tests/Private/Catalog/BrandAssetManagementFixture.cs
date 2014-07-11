using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model.Asset;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Private.Catalog;

namespace XOMNI.SDK.Tests.Private.Catalog
{
    [TestClass]
    public class BrandAssetManagementFixture : CatalogAssetBaseFixture
    {
        private BrandManagement brandBusiness = null;
        private BrandManagementFixture brandManagementFixture = null;

        public override void Init()
        {
            base.Init();
            brandBusiness = new BrandManagement();
            brandManagementFixture = new BrandManagementFixture();

            sampleBrandId = brandManagementFixture.CreateSampleBrand().Result.Id;
        }

        [TestCleanup]
        public void CleanUp()
        {
            brandBusiness.DeleteAsync(sampleBrandId).Wait();
        }

        private int sampleBrandId = 0;
        public override int relatedId
        {
            get { return sampleBrandId; }
        }

        public override SDK.Private.Catalog.IAssetRelation CatalogAssetBaseBusiness
        {
            get { return brandBusiness; }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.BrandManagement")]
        public async Task PostGetUpdateDeleteBrandDocumentRelationTest()
        {
            await base.PostGetUpdateDeleteDocumentRelationTest();
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.BrandManagement")]
        public async Task PostGetUpdateDeleteBrandVideoRelationTest()
        {
            await base.PostGetUpdateDeleteVideoRelationTest();
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.BrandManagement")]
        public async Task PostGetUpdateDeleteBrandImageRelationTest()
        {
            await base.PostGetUpdateDeleteImageRelationTest();
        }
    }
}
