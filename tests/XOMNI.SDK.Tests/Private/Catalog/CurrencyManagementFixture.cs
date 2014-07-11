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
    public class CurrencyManagementFixture : BaseCRUDManagementFixture<Model.Catalog.Currency>
    {
        private ItemManagement itemBusiness = null;
        XOMNI.SDK.Model.Private.Catalog.Item createdItem;

        public override void Init()
        {
            base.Init();
            itemBusiness = new ItemManagement();

            var createdCurrencyId = CrudManagement.AddAsync(GetValidEntityModel()).Result.Id;

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
                        CurrencyId = createdCurrencyId,
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
            CrudManagement.DeleteAsync(createdItem.Prices.First().CurrencyId).Wait();
        }

        public CurrencyManagement currencyManagement;
        public override BaseCRUDSkipTakeManagement<Model.Catalog.Currency> CrudManagement
        {
            get
            {
                if (currencyManagement == null)
                {
                    currencyManagement = new CurrencyManagement();
                }
                return currencyManagement;
            }
        }

        public override Model.Catalog.Currency GetBadEntityModel()
        {
            return new Model.Catalog.Currency() { Description  = string.Empty.PadLeft(100, '1') };
        }

        public override int GetNotFoundEntityId()
        {
            return 9999999;
        }

        public override Model.Catalog.Currency GetValidEntityModel()
        {
            return new Model.Catalog.Currency()
            {
                 CurrencySymbol = Guid.NewGuid().ToString().Substring(0,5),
                 Description = Guid.NewGuid().ToString()
            };
        }

        public override int GetInUseEntityId()
        {
            return createdItem.Prices.First().CurrencyId;
        }
        public int NewAddedEntityId = 0;

        public override void CheckNewAddedEntity(Model.Catalog.Currency newEntityModel, Model.Catalog.Currency oldEntityModel)
        {
            Assert.IsTrue(newEntityModel.Id > 0, "Currency id should have been greater than 0");
            Assert.AreEqual(newEntityModel.Description, oldEntityModel.Description, "Currency Description field should have been same with created tag");
            Assert.AreEqual(newEntityModel.CurrencySymbol, oldEntityModel.CurrencySymbol, "Currency Symbol field should have been same with created tag");

            NewAddedEntityId = newEntityModel.Id;
        }

        public override int GetMeYourNewFuckingEntityIdIWillDelete()
        {
            return NewAddedEntityId;
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.CurrencyManagement")]
        public async Task PostGetUpdateDeleteCurrencyTest()
        {
            await base.CRUDTest();
        }
    }
}
