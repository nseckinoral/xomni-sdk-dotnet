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
    public class LicenseManagementFixture : BaseCRUDManagementFixture<Model.Management.Security.License>
    {
        public override Core.Management.BaseCRUDSkipTakeManagement<Model.Management.Security.License> CrudManagement
        {
            get { return new LicenseManagement(); }
        }

        public override Model.Management.Security.License GetBadEntityModel()
        {
            return new Model.Management.Security.License();
        }

        public override int GetNotFoundEntityId()
        {
            return 999999999;
        }

        public override Model.Management.Security.License GetValidEntityModel()
        {
            return new Model.Management.Security.License()
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

        public override void CheckNewAddedEntity(Model.Management.Security.License newEntityModel, Model.Management.Security.License oldEntityModel)
        {
            Assert.IsTrue(newEntityModel.Id > 0, "Id must be greater than 0");
            Assert.AreEqual(newEntityModel.Username, oldEntityModel.Username, "Username did not match.");
            Assert.AreEqual(newEntityModel.Name, oldEntityModel.Name, "Name did not match");
            Assert.AreEqual(newEntityModel.Password, oldEntityModel.Password, "Password did not match");
            Assert.AreEqual(newEntityModel.StoreId, oldEntityModel.StoreId, "StoreId did not match");

            NewAddedEntityId = newEntityModel.Id;
        }

        public override int GetMeYourNewFuckingEntityIdIWillDelete()
        {
            return NewAddedEntityId;
        }

        [TestMethod]
        [TestCategory("SDK.Management.Security"), TestCategory("Integration"), TestCategory("SDK.Management.Security.LicenseManagement")]
        public async Task PostGetUpdateDeleteLicenseTest()
        {
            await base.CRUDTest();
        }

        [TestMethod]
        [TestCategory("SDK.Management.Security"), TestCategory("Integration"), TestCategory("SDK.Management.Security.LicenseManagement")]
        public async Task UnassignedStoreUserTest()
        {
            var unassignedUsers = await ((LicenseManagement)CrudManagement).GetUnassignedLicences();
            var initialUnassignedUserCount = unassignedUsers.Count;

            var unassignedNewUser = await CrudManagement.AddAsync(GetValidEntityModel());
            
            unassignedUsers = await ((LicenseManagement)CrudManagement).GetUnassignedLicences();
            var lateUnassignedUserCount = unassignedUsers.Count;

            Assert.AreEqual(initialUnassignedUserCount + 1, lateUnassignedUserCount, "Unassigned users count did not match.");

            await CrudManagement.DeleteAsync(unassignedNewUser.Id);
        }


        [TestMethod]
        [TestCategory("SDK.Management.Security"), TestCategory("Integration"), TestCategory("SDK.Management.Security.LicenseManagement")]
        public async Task LicenseAuditLogTest()
        {
            var licenseManagmenet = ((LicenseManagement)CrudManagement);

            var initialAuditLogs = await licenseManagmenet.GetAuditLogsAsync(0, 10);

            var validEntityModel = GetValidEntityModel();
            validEntityModel = await licenseManagmenet.AddAsync(validEntityModel);
            await licenseManagmenet.DeleteAsync(validEntityModel.Id);

            var currentAuditLogs = await licenseManagmenet.GetAuditLogsAsync(0, 10);

            Assert.AreEqual(initialAuditLogs.TotalCount + 1, currentAuditLogs.TotalCount, "Audit logs count did not match.");

            var auditLogsForDetailledCheck = await licenseManagmenet.GetAuditLogsAsync(currentAuditLogs.TotalCount-1, 1);

            Assert.AreEqual(1, auditLogsForDetailledCheck.Results.Count, "Audit logs count for last operation did not match.");

            var auditLogCreatedDeletedLicense = auditLogsForDetailledCheck.Results[0];

            Assert.AreEqual(validEntityModel.Username, auditLogCreatedDeletedLicense.Username, "User name did not match in audit logs.");
        }
    }
}
