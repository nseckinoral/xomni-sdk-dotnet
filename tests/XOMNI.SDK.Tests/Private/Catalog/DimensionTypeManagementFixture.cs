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
    public class DimensionTypeManagementFixture : BaseCRUDManagementFixture<Model.Catalog.DimensionType>
    {
        public DimensionTypeManagement dimensionTypeManagement;
        private ItemManagement itemBusiness = null;
        XOMNI.SDK.Model.Private.Catalog.Item createdItem;

        public override void Init()
        {
            base.Init();
            itemBusiness = new ItemManagement();

            var createdDimensionTypeId = CrudManagement.AddAsync(GetValidEntityModel()).Result.Id;

            createdItem = itemBusiness.AddAsync(new Model.Private.Catalog.Item
            {
                Name = Guid.NewGuid().ToString(),
                Title = Guid.NewGuid().ToString(),
                ShortDescription = Guid.NewGuid().ToString(),
                InStock = true,
                Dimensions = new List<Model.Private.Catalog.Dimension>
                {
                    new XOMNI.SDK.Model.Private.Catalog.Dimension
                    {
                        DimensionTypeId = createdDimensionTypeId,
                        Depth = 22.34,
                        Height=12.56,
                        Width=94.32
                    }
                }
            }).Result;
        }

        [TestCleanup]
        public override void Cleanup()
        {
            base.Cleanup();
            itemBusiness.DeleteAsync(createdItem.Id).Wait();
            CrudManagement.DeleteAsync(createdItem.Dimensions.First().DimensionTypeId).Wait();
        }

        public override BaseCRUDSkipTakeManagement<Model.Catalog.DimensionType> CrudManagement
        {
            get
            {
                if (dimensionTypeManagement == null)
                {
                    dimensionTypeManagement = new SDK.Private.Catalog.DimensionTypeManagement();
                }

                return dimensionTypeManagement;
            }
        }

        public override Model.Catalog.DimensionType GetBadEntityModel()
        {
            return new Model.Catalog.DimensionType() { Description = string.Empty.PadLeft(513, '1') };
        }

        public override int GetNotFoundEntityId()
        {
            return 9999999;
        }

        public override Model.Catalog.DimensionType GetValidEntityModel()
        {
            return new Model.Catalog.DimensionType() { Description = Guid.NewGuid().ToString() };
        }

        public override int GetInUseEntityId()
        {
            return createdItem.Dimensions.First().DimensionTypeId;
        }

        public int NewAddedEntityId = 0;

        public override void CheckNewAddedEntity(Model.Catalog.DimensionType newEntityModel, Model.Catalog.DimensionType oldEntityModel)
        {
            Assert.IsTrue(newEntityModel.Id > 0, "Dimension Type  id should have been greater than 0");
            Assert.AreEqual(newEntityModel.Description, oldEntityModel.Description, "Dimension Type Description field should have been same with created tag");
            NewAddedEntityId = newEntityModel.Id;
        }

        public override int GetMeYourNewFuckingEntityIdIWillDelete()
        {
            return NewAddedEntityId;
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.DimensionTypeManagement")]
        public async Task PostGetUpdateDeleteDimensionTypeTest()
        {
            await base.CRUDTest();
        }
    }
}
