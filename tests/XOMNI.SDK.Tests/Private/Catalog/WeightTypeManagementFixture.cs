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
    public class WeightTypeManagementFixture : BaseCRUDManagementFixture<Model.Catalog.WeightType>
    {
        private ItemManagement itemBusiness = null;
        XOMNI.SDK.Model.Private.Catalog.Item createdItem;

        public override void Init()
        {
            base.Init();
            itemBusiness = new ItemManagement();

            var createdWeightTypeId = CrudManagement.AddAsync(GetValidEntityModel()).Result.Id;

            createdItem = itemBusiness.AddAsync(new Model.Private.Catalog.Item
            {
                Name = Guid.NewGuid().ToString(),
                Title = Guid.NewGuid().ToString(),
                ShortDescription = Guid.NewGuid().ToString(),
                InStock = true,
                Weights = new List<Model.Private.Catalog.Weight>
                {
                    new XOMNI.SDK.Model.Private.Catalog.Weight
                    {
                        Value=20,
                        WeightTypeId = createdWeightTypeId
                    }
                }
            }).Result;
        }

        [TestCleanup]
        public override void Cleanup()
        {
            base.Cleanup();
            itemBusiness.DeleteAsync(createdItem.Id).Wait();
            CrudManagement.DeleteAsync(createdItem.Weights.First().WeightTypeId).Wait();
        }

        public WeightTypeManagement weightTypeManagement;
        public override BaseCRUDSkipTakeManagement<Model.Catalog.WeightType> CrudManagement
        {
            get
            {
                if (weightTypeManagement == null)
                {
                    weightTypeManagement = new SDK.Private.Catalog.WeightTypeManagement();
                }

                return weightTypeManagement;
            }
        }

        public override Model.Catalog.WeightType GetBadEntityModel()
        {
            return new Model.Catalog.WeightType() { Description = string.Empty.PadLeft(513, '1') };
        }

        public override int GetNotFoundEntityId()
        {
            return 9999999;
        }

        public override Model.Catalog.WeightType GetValidEntityModel()
        {
            return new Model.Catalog.WeightType() { Description = Guid.NewGuid().ToString() };
        }

        public override int GetInUseEntityId()
        {
            return createdItem.Weights.First().WeightTypeId;
        }

        public int NewAddedEntityId = 0;

        public override void CheckNewAddedEntity(Model.Catalog.WeightType newEntityModel, Model.Catalog.WeightType oldEntityModel)
        {
            Assert.IsTrue(newEntityModel.Id > 0, "WeightType id should have been greater than 0");
            Assert.AreEqual(newEntityModel.Description, oldEntityModel.Description, "WeightType Description field should have been same with created tag");

            NewAddedEntityId = newEntityModel.Id;
        }

        public override int GetMeYourNewFuckingEntityIdIWillDelete()
        {
            return NewAddedEntityId;
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.WeightTypeManagement")]
        public async Task PostGetUpdateDeleteWeightTypeTest()
        {
            await base.CRUDTest(); 
        }
    }
}
