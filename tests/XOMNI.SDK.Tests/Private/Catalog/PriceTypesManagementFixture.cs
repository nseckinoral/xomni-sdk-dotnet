using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Private.Catalog;

namespace XOMNI.SDK.Tests.Private.Catalog
{
    [TestClass]
    public class PriceTypeManagementFixture : BaseCRUDManagementFixture<Model.Catalog.PriceType>
    {
        private ItemManagement itemBusiness = null;
        XOMNI.SDK.Model.Private.Catalog.Item createdItem;

        public override void Init()
        {
            base.Init();
            itemBusiness = new ItemManagement();

            var createdPriceTypeId = CrudManagement.AddAsync(GetValidEntityModel()).Result.Id;

            createdItem = itemBusiness.AddAsync(new Model.Private.Catalog.Item
            {
                Name = Guid.NewGuid().ToString(),
                Title = Guid.NewGuid().ToString(),
                ShortDescription = Guid.NewGuid().ToString(),
                InStock = true,
                Prices = new List<Model.Private.Catalog.Price>
                {
                    new XOMNI.SDK.Model.Private.Catalog.Price
                    {
                        PriceTypeId = createdPriceTypeId,
                        DiscountPrice = 30,
                        NormalPrice=40
                    }
                }
            }).Result;
        }

        [TestCleanup]
        public override void Cleanup()
        {
            base.Cleanup();
            itemBusiness.DeleteAsync(createdItem.Id).Wait();
            CrudManagement.DeleteAsync(createdItem.Prices.First().PriceTypeId).Wait();
        }

        public PriceTypeManagement priceTypeManagement;
        public override BaseCRUDSkipTakeManagement<Model.Catalog.PriceType> CrudManagement
        {
            get
            {
                if (priceTypeManagement == null)
                {
                    priceTypeManagement = new PriceTypeManagement();
                }
                return priceTypeManagement;
            }
        }

        public override Model.Catalog.PriceType GetBadEntityModel()
        {
            return new Model.Catalog.PriceType() { Description = string.Empty.PadLeft(100, '1') };
        }

        public override int GetNotFoundEntityId()
        {
            return 9999999;
        }

        public override Model.Catalog.PriceType GetValidEntityModel()
        {
            return new Model.Catalog.PriceType()
            {
                PriceTypeSymbol = Guid.NewGuid().ToString().Substring(0, 5),
                Description = Guid.NewGuid().ToString()
            };
        }

        public override int GetInUseEntityId()
        {
            return createdItem.Prices.First().PriceTypeId;
        }
        public int NewAddedEntityId = 0;

        public override void CheckNewAddedEntity(Model.Catalog.PriceType newEntityModel, Model.Catalog.PriceType oldEntityModel)
        {
            Assert.IsTrue(newEntityModel.Id > 0, "Price type id should have been greater than 0");
            Assert.AreEqual(newEntityModel.Description, oldEntityModel.Description, "Price type Description field should have been same with created tag");
            Assert.AreEqual(newEntityModel.PriceTypeSymbol, oldEntityModel.PriceTypeSymbol, "Price type Symbol field should have been same with created tag");

            NewAddedEntityId = newEntityModel.Id;
        }

        public override int GetMeYourNewFuckingEntityIdIWillDelete()
        {
            return NewAddedEntityId;
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.PriceTypeManagement")]
        public async Task PostGetUpdateDeletePriceTypeTest()
        {
            await base.CRUDTest();
        }
    }
}
