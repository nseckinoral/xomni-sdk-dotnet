using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Management.Configuration;
using XOMNI.SDK.Tests.Management.Security;
using XOMNI.SDK.Tests.Private.Catalog;

namespace XOMNI.SDK.Tests.Management.Configuration
{
    [TestClass]
    public class StoreManagementFixture : BaseCRUDManagementFixture<Model.Management.Configuration.Store>
    {
        private LicenseManagementFixture licenseManagementFixture = null;
        private XOMNI.SDK.Model.Management.Security.License createdLicense = null;

        public override void Init()
        {
            base.Init();
            licenseManagementFixture = new LicenseManagementFixture();

            int createdStoreId = CrudManagement.AddAsync(GetValidEntityModel()).Result.Id;

            var validLicenseModel = licenseManagementFixture.GetValidEntityModel();
            validLicenseModel.StoreId = createdStoreId;
            createdLicense = licenseManagementFixture.CrudManagement.AddAsync(validLicenseModel).Result;
        }

        [TestCleanup]
        public override async void Cleanup()
        {
            base.Cleanup();
            await licenseManagementFixture.CrudManagement.DeleteAsync(createdLicense.Id);
            await CrudManagement.DeleteAsync(createdLicense.StoreId.Value);
        }

        private StoreManagement storeManagement;
        public override Core.Management.BaseCRUDSkipTakeManagement<Model.Management.Configuration.Store> CrudManagement
        {
            get 
            {
                if (storeManagement == null)
                {
                    storeManagement = new StoreManagement();
                }
                return storeManagement;
            }
        }

        public override Model.Management.Configuration.Store GetBadEntityModel()
        {
            return new Model.Management.Configuration.Store()
            {
                Name = string.Empty
            };
        }

        public override int GetNotFoundEntityId()
        {
            return int.MaxValue;
        }

        public override Model.Management.Configuration.Store GetValidEntityModel()
        {
            return new Model.Management.Configuration.Store()
            {
                Address = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Location=new Model.Location(42.33D, 34.21D),
                Name=Guid.NewGuid().ToString()
            };
        }

        public override int GetInUseEntityId()
        {
            return createdLicense.StoreId.Value;
        }

        public int NewAddedEntityId = 0;

        public override void CheckNewAddedEntity(Model.Management.Configuration.Store newEntityModel, Model.Management.Configuration.Store oldEntityModel)
        {
            Assert.IsTrue(newEntityModel.Id > 0, "Store entity id should has been greater than 0");
            Assert.AreEqual(newEntityModel.Licenses.Count, oldEntityModel.Licenses.Count, "Store entity AssignedUsers count should be same with created list's count");
            Assert.AreEqual(newEntityModel.Address, oldEntityModel.Address, "Store entity 'Address' field should be same with created field");
            Assert.AreEqual(newEntityModel.Description, oldEntityModel.Description, "Store entity 'Description' field should be same with created field");
            Assert.AreEqual(newEntityModel.Location.Latitude, oldEntityModel.Location.Latitude, "Store entity 'Latitude' field should be same with created field");
            Assert.AreEqual(newEntityModel.Location.Longitude, oldEntityModel.Location.Longitude, "Store entity 'Longitude' field should be same with created field");
            Assert.AreEqual(newEntityModel.Name, oldEntityModel.Name, "Store entity 'Name' field should be same with created field");

            NewAddedEntityId = newEntityModel.Id;
        }
        
        public override int GetMeYourNewFuckingEntityIdIWillDelete()
        {
            return NewAddedEntityId;
        }

        [TestMethod]
        [TestCategory("SDK.Management.Configuration"), TestCategory("Integration"), TestCategory("SDK.Management.Configuration.StoreManagement")]
        public async Task PostGetUpdateDeleteStoreTest()
        {
            await base.CRUDTest();
        }

       
    }
}
