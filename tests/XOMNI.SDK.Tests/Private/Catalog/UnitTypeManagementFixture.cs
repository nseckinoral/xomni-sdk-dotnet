using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Exception;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Private;

namespace XOMNI.SDK.Tests.Private.Catalog
{
    [TestClass]
    public class UnitTypeManagementFixture : BaseCRUDManagementFixture<Model.Catalog.UnitType>
    {
        private XOMNI.SDK.Private.Catalog.ItemManagement itemBusiness = null;
        XOMNI.SDK.Model.Private.Catalog.Item createdItem;

        public override void Init()
        {
            base.Init();
            itemBusiness = new SDK.Private.Catalog.ItemManagement();

            var createdUnitTypeId = CrudManagement.AddAsync(GetValidEntityModel()).Result.Id;

            createdItem = itemBusiness.AddAsync(new Model.Private.Catalog.Item
            {
                Name = Guid.NewGuid().ToString(),
                Title = Guid.NewGuid().ToString(),
                ShortDescription = Guid.NewGuid().ToString(),
                InStock = true,
                UnitTypeId = createdUnitTypeId
            }).Result;
        }

        [TestCleanup]
        public override void Cleanup()
        {
            base.Cleanup();
            itemBusiness.DeleteAsync(createdItem.Id).Wait();
            CrudManagement.DeleteAsync(createdItem.UnitTypeId.Value).Wait();
        }

        public SDK.Private.Catalog.UnitTypeManagement unitTypeManagement;
        public override BaseCRUDSkipTakeManagement<Model.Catalog.UnitType> CrudManagement
        {
            get
            {
                if (unitTypeManagement == null)
                {
                    unitTypeManagement = new SDK.Private.Catalog.UnitTypeManagement();
                }

                return unitTypeManagement;
            }
        }

        public override Model.Catalog.UnitType GetBadEntityModel()
        {
            return new Model.Catalog.UnitType()
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                UnitCode = Guid.NewGuid().ToString()
            };
        }

        public override int GetNotFoundEntityId()
        {
            return 99999999;
        }

        public override Model.Catalog.UnitType GetValidEntityModel()
        {
            return new Model.Catalog.UnitType()
            {
                Name = Guid.NewGuid().ToString().Substring(0, 8),
                Description = Guid.NewGuid().ToString().Substring(0, 8),
                UnitCode = Guid.NewGuid().ToString().Substring(0, 8)
            };
        }

        public override int GetInUseEntityId()
        {
            return createdItem.UnitTypeId.Value;
        }

        public int NewAddedEntityId = 0;
        public override void CheckNewAddedEntity(Model.Catalog.UnitType newEntityModel, Model.Catalog.UnitType oldEntityModel)
        {
            Assert.AreEqual(newEntityModel.Name, oldEntityModel.Name, "Unit Type names did not match");
            Assert.AreEqual(newEntityModel.Description, oldEntityModel.Description, "Unit Type descriptions did not match");
            Assert.AreEqual(newEntityModel.UnitCode, oldEntityModel.UnitCode, "Unit Type unit codes did not match");
            Assert.IsTrue(newEntityModel.Id > 0, "Unit Type id should have been greater than 0");
            NewAddedEntityId = newEntityModel.Id;
        }

        public override int GetMeYourNewFuckingEntityIdIWillDelete()
        {
            return NewAddedEntityId;
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.UnitTypeManagement")]
        public async Task PostGetUpdateDeleteUnitTypeTest()
        {
            await base.CRUDTest();
        }
    }
}
