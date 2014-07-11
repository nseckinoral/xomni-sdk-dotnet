using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Management.Security;
using XOMNI.SDK.Tests.Private.Catalog;

namespace XOMNI.SDK.Tests.Management.Security
{
    [TestClass]
    public class PrivateApiUserManagementFixture : BaseCRUDManagementFixture<Model.Management.Security.ApiUser>
    {
        public override Core.Management.BaseCRUDSkipTakeManagement<Model.Management.Security.ApiUser> CrudManagement
        {
            get { return new PrivateApiUserManagement(); }
        }

        public override Model.Management.Security.ApiUser GetBadEntityModel()
        {
            return new Model.Management.Security.ApiUser();
        }

        public override int GetNotFoundEntityId()
        {
            return 999999999;
        }

        public override Model.Management.Security.ApiUser GetValidEntityModel()
        {
            return new Model.Management.Security.ApiUser()
            {
                Name = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString(),
                Username = Guid.NewGuid().ToString()
            };
        }

        public override int GetInUseEntityId()
        {
            return 0;
        }

        int NewAddedEntityId = 0;

        public override void CheckNewAddedEntity(Model.Management.Security.ApiUser newEntityModel, Model.Management.Security.ApiUser oldEntityModel)
        {
            Assert.IsTrue(newEntityModel.Id > 0, "Id must be greater than 0");
            Assert.AreEqual(newEntityModel.Username, oldEntityModel.Username, "Username did not match.");
            Assert.AreEqual(newEntityModel.Name, oldEntityModel.Name, "Name did not match");
            Assert.AreEqual(newEntityModel.Password, oldEntityModel.Password, "Password did not match");
            Assert.AreEqual(newEntityModel.StoreId, oldEntityModel.StoreId, "StoreId did not match");
            Assert.AreEqual(newEntityModel.IsPublic(), false, "Api Security must not have public right.");
            Assert.AreEqual(newEntityModel.IsPrivate(), true, "Api Security must have private right.");
            Assert.AreEqual(newEntityModel.IsManagement(), false, "Api Security must not have management right.");

            NewAddedEntityId = newEntityModel.Id;
        }

        public override int GetMeYourNewFuckingEntityIdIWillDelete()
        {
            return NewAddedEntityId;
        }

        [TestMethod]
        [TestCategory("SDK.Management.Security"), TestCategory("Integration"), TestCategory("SDK.Management.Security.PrivateApiUserManagement")]
        public async Task PostGetUpdateDeletePrivateApiUserTest()
        {
            await base.CRUDTest();
        }
    }
}
