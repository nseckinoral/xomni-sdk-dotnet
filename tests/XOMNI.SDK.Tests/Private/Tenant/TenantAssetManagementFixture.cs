using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Private.Tenant;
using XOMNI.SDK.Tests.Private.Catalog;

namespace XOMNI.SDK.Tests.Private.Tenant
{
    [TestClass]
    public class TenantAssetManagementFixture : BaseCRUDManagementFixture<Model.Private.Tenant.TenantAsset>
    {
        public override bool CheckConflictedEntity
        {
            get
            {
                return false;
            }
        }

        public override Core.Management.BaseCRUDSkipTakeManagement<Model.Private.Tenant.TenantAsset> CrudManagement
        {
            get { return new TenantAssetManagement(); }
        }

        public override Model.Private.Tenant.TenantAsset GetBadEntityModel()
        {
            return new Model.Private.Tenant.TenantAsset();
        }

        public override int GetNotFoundEntityId()
        {
            return int.MaxValue;
        }

        private Model.Private.Tenant.TenantAsset validEntity = null;
        private Model.Private.Tenant.TenantAsset createdEntity = null;

        public override Model.Private.Tenant.TenantAsset GetValidEntityModel()
        {
            validEntity = new Model.Private.Tenant.TenantAsset()
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

        public override void CheckNewAddedEntity(Model.Private.Tenant.TenantAsset newEntityModel, Model.Private.Tenant.TenantAsset oldEntityModel)
        {
            createdEntity = newEntityModel;
            Assert.IsTrue(newEntityModel.Id > 0, "Id must be greater than zero.");
            Assert.AreEqual(newEntityModel.FileName, oldEntityModel.FileName, "File name did not match.");
            Assert.AreEqual(newEntityModel.MimeType, oldEntityModel.MimeType, "File name did not match.");
            Assert.IsTrue(!string.IsNullOrEmpty(newEntityModel.PublicUrl), "Public url must not be null");


            //byte[] fileBody = null;
            //WebClient wc = new WebClient();
            //using (Stream st = wc.OpenRead(newEntityModel.PublicUrl))
            //{
            //    using (MemoryStream ms = new MemoryStream())
            //    {
            //        st.CopyToAsync(ms);
            //        fileBody = ms.ToArray();
            //    }
            //}
            //Assert.AreEqual(Encoding.UTF8.GetString(fileBody), "armut", "File name did not match.");

        }

        public override int GetMeYourNewFuckingEntityIdIWillDelete()
        {
            return createdEntity.Id;
        }

        public override void CheckUpdatedEntity(Model.Private.Tenant.TenantAsset newEntityModel, Model.Private.Tenant.TenantAsset oldEntityModel)
        {
            Assert.AreEqual(newEntityModel.Id, oldEntityModel.Id, "Updated entity id did not match.");
            Assert.AreEqual(newEntityModel.FileName, oldEntityModel.FileName, "File name did not match.");
            Assert.AreEqual(newEntityModel.MimeType, oldEntityModel.MimeType, "File name did not match.");
            Assert.IsTrue(!string.IsNullOrEmpty(newEntityModel.PublicUrl), "Public url must not be null");
            //Assert.AreEqual(newEntityModel.PublicUrl, oldEntityModel.PublicUrl, "Public Url did not match.");


            //byte[] fileBody = null;
            //WebClient wc = new WebClient();
            //using (Stream st = wc.OpenRead(newEntityModel.PublicUrl))
            //{
            //    using (MemoryStream ms = new MemoryStream())
            //    {
            //        st.CopyToAsync(ms);
            //        fileBody = ms.ToArray();
            //    }
            //}
            //Assert.AreEqual(Encoding.UTF8.GetString(fileBody), "elma", "File name did not match.");
        }

        public override Model.Private.Tenant.TenantAsset GetEntityForUpdate()
        {
            validEntity.Id = createdEntity.Id;
            validEntity.FileBody = Encoding.UTF8.GetBytes("elma");
            return validEntity;
        }


        [TestMethod]
        [TestCategory("SDK.Private.Tenant"), TestCategory("Integration"), TestCategory("SDK.Private.TenantAsset.TenantAssetManagement")]
        public async Task PostGetUpdateDeleteTenantAssetTest()
        {
            await base.CRUDTest();
        }
    }
}
