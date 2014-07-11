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
    public class BrandManagementFixture : BaseCRUDManagementFixture<Model.Catalog.Brand>
    {
        private ItemManagementFixture itemManagementFixture = null;
        XOMNI.SDK.Model.Private.Catalog.Item createdItem;

        public override void Init()
        {
            base.Init();
            itemManagementFixture = new ItemManagementFixture();
        }

        [TestInitialize]
        public void Initialize()
        {
            //The following line use ItemManagementFixture, and that both use BrandManagementFixture.
            //If call from Init (constructor) method, it causes an infinite looping.
            createdItem = itemManagementFixture.CreateSampleItem().Result;
        }

        [TestCleanup]
        public override void Cleanup()
        {
            base.Cleanup();
            itemManagementFixture.DeleteItemBrandCategoryByItemId(createdItem.Id).Wait();
        }

        public BrandManagement brandManagement;
        public override BaseCRUDSkipTakeManagement<Model.Catalog.Brand> CrudManagement
        {
            get
            {
                if (brandManagement == null)
                {
                    brandManagement = new BrandManagement();
                }
                return brandManagement;
            }
        }

        public override Model.Catalog.Brand GetBadEntityModel()
        {
            return new Model.Catalog.Brand();
        }

        public override int GetNotFoundEntityId()
        {
            return 9999999;
        }

        public override Model.Catalog.Brand GetValidEntityModel()
        {
            return new Model.Catalog.Brand() { Name = Guid.NewGuid().ToString() };
        }

        public override int GetInUseEntityId()
        {
            return createdItem.BrandId.Value;
        }

        public int NewAddedEntityId = 0;

        public override void CheckNewAddedEntity(Model.Catalog.Brand newEntityModel, Model.Catalog.Brand oldEntityModel)
        {
            Assert.AreEqual(newEntityModel.Name, oldEntityModel.Name, "Brand description did not match.");
            Assert.IsTrue(newEntityModel.Id > 0, "Brand Id could not be less than 1");

            NewAddedEntityId = newEntityModel.Id;
        }

        public override int GetMeYourNewFuckingEntityIdIWillDelete()
        {
            return NewAddedEntityId;
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.BrandManagement")]
        public async Task PostGetUpdateDeleteBrandTest()
        {
            await base.CRUDTest();
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.BrandManagement")]
        public async Task GetByCategoryIdTest()
        {
            try
            {
                await ((BrandManagement)CrudManagement).GetByCategoryIdAsync(99999, 0, 20);
                Assert.Fail("Bad Request exception should have been returned from sdk");
            }
            catch (SDK.Core.Exception.BadRequestException)
            {
                //Bad Request exception should have been returned from sdk
            }

            var brands = await brandManagement.GetByCategoryIdAsync(createdItem.CategoryId.Value, 0, 20);
            Assert.IsTrue(brands.TotalCount > 0, "GetBrands did not return correct TotalCount"); 
        }

        public async Task<Model.Catalog.Brand> CreateSampleBrand()
        {
            return await CrudManagement.AddAsync(new Model.Catalog.Brand
            {
                Name = Guid.NewGuid().ToString()
            });
        }
    }
}
