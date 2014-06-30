using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Management.Storage;
using XOMNI.SDK.Tests.Private.Catalog;

namespace XOMNI.SDK.Tests.Management.Storage
{
    [TestClass]
    public class AssetManagementFixture : BaseCRUDManagementFixture<Model.Management.Storage.Asset>
    {
        public override bool CheckConflictedEntity
        {
            get
            {
                return false;
            }
        }

        public override Core.Management.BaseCRUDSkipTakeManagement<Model.Management.Storage.Asset> CrudManagement
        {
            get { return new AssetManagement(); }
        }

        public override Model.Management.Storage.Asset GetBadEntityModel()
        {
            return new Model.Management.Storage.Asset();
        }

        public override int GetNotFoundEntityId()
        {
            return int.MaxValue;
        }

        private Model.Management.Storage.Asset validEntity = null;
        private Model.Management.Storage.Asset createdEntity = null;
        
        public override Model.Management.Storage.Asset GetValidEntityModel()
        {
            validEntity = new Model.Management.Storage.Asset()
            {
                FileBody = Encoding.UTF8.GetBytes("armut"),
                MimeType = "applicaton/test",
                FileName = Guid.NewGuid().ToString()
            };

            return validEntity;
        }

        public override int GetInUseEntityId()
        {
            return 0;
        }

        public override void CheckNewAddedEntity(Model.Management.Storage.Asset newEntityModel, Model.Management.Storage.Asset oldEntityModel)
        {
            createdEntity = newEntityModel;
            Assert.IsTrue(newEntityModel.Id > 0, "Id must be greater than zero.");
            Assert.AreEqual(newEntityModel.FileName, oldEntityModel.FileName, "File name did not match.");
            Assert.AreEqual(newEntityModel.MimeType, oldEntityModel.MimeType, "File name did not match.");
            var tenantAsset = CrudManagement.GetByIdAsync(newEntityModel.Id).Result;
            Assert.AreEqual(Encoding.UTF8.GetString(tenantAsset.FileBody), "armut", "File name did not match.");
        }

        public override int GetMeYourNewFuckingEntityIdIWillDelete()
        {
            return createdEntity.Id;
        }

        public override void CheckUpdatedEntity(Model.Management.Storage.Asset newEntityModel, Model.Management.Storage.Asset oldEntityModel)
        {
            Assert.AreEqual(newEntityModel.Id, oldEntityModel.Id,"Updated entity id did not match.");
            Assert.AreEqual(newEntityModel.FileName, oldEntityModel.FileName, "File name did not match.");
            Assert.AreEqual(newEntityModel.MimeType, oldEntityModel.MimeType, "File name did not match.");
            var tenantAsset = CrudManagement.GetByIdAsync(newEntityModel.Id).Result;
            Assert.AreEqual(Encoding.UTF8.GetString(tenantAsset.FileBody), "elma", "File name did not match."); 
        }

        public override Model.Management.Storage.Asset GetEntityForUpdate()
        {
            validEntity.Id = createdEntity.Id;
            validEntity.FileBody = Encoding.UTF8.GetBytes("elma");
            return validEntity;
        }


        [TestMethod]
        [TestCategory("SDK.Management.Storage"), TestCategory("Integration"), TestCategory("SDK.Management.Storage.AssetManagement")]
        public async Task PostGetUpdateDeleteTenantAssetTest()
        {
            await base.CRUDTest();
        }
    }
}
