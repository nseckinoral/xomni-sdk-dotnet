using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model;
using XOMNI.SDK.Core.Exception;
using XOMNI.SDK.Core.Management;

namespace XOMNI.SDK.Tests.Private.Catalog
{
    [TestClass]
    public class TagManagementFixture : BaseCRUDManagementFixture<Model.Catalog.Tag>
    {
        public override BaseCRUDSkipTakeManagement<Model.Catalog.Tag> CrudManagement
        {
            get { return new SDK.Private.Catalog.TagManagement(); }
        }

        public override Model.Catalog.Tag GetBadEntityModel()
        {
            return new Model.Catalog.Tag()
            {
                Description = Guid.NewGuid().ToString()
            };
        }

        public override int GetNotFoundEntityId()
        {
            return 999999;
        }

        public override Model.Catalog.Tag GetValidEntityModel()
        {
            return new Model.Catalog.Tag()
            {
                Description = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString()
            };
        }

        public override int GetInUseEntityId()
        {
            return 0;
        }

        private int NewTagId = 0;
        public override void CheckNewAddedEntity(Model.Catalog.Tag newEntityModel, Model.Catalog.Tag oldEntityModel)
        {
            NewTagId = newEntityModel.Id;
            Assert.IsTrue(newEntityModel.Id > 0, "Tag id should have been greater than 0");
            Assert.AreEqual(newEntityModel.Description, oldEntityModel.Description, "Description field should have been same with created tag");
            Assert.AreEqual(newEntityModel.Name, oldEntityModel.Name, "Name field should have been same with created tag");
        }

        public override int GetMeYourNewFuckingEntityIdIWillDelete()
        {
            return NewTagId;
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.TagManagement")]
        public async Task PostGetUpdateDeleteTagTest()
        {
            await base.CRUDTest();
        }

        public async Task<XOMNI.SDK.Model.Catalog.Tag> CreateSampleTag()
        {
            return await CrudManagement.AddAsync(new Model.Catalog.Tag
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString()
            });
        }
    }
}
