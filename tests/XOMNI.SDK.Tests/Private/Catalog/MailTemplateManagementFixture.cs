using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;

namespace XOMNI.SDK.Tests.Private.Catalog
{
    [TestClass]
    public class MailTemplateManagementFixture : BaseCRUDManagementFixture<Model.Private.Catalog.MailTemplate>
    {
        public SDK.Private.Catalog.MailTemplateManagement mailTypeManagement;
        public override BaseCRUDSkipTakeManagement<Model.Private.Catalog.MailTemplate> CrudManagement
        {
            get
            {
                if (mailTypeManagement == null)
                {
                    mailTypeManagement = new SDK.Private.Catalog.MailTemplateManagement();
                }
                return mailTypeManagement;
            }
        }

        public override Model.Private.Catalog.MailTemplate GetBadEntityModel()
        {
            return new Model.Private.Catalog.MailTemplate();
        }

        public override int GetNotFoundEntityId()
        {
            return 99999;
        }

        public override Model.Private.Catalog.MailTemplate GetValidEntityModel()
        {
            return new Model.Private.Catalog.MailTemplate()
            {
                Name = Guid.NewGuid().ToString(),
                BodyTemplate = Guid.NewGuid().ToString(),
                ItemTemplate = Guid.NewGuid().ToString(),
                From = Guid.NewGuid().ToString(),
                Subject = Guid.NewGuid().ToString(),
            };
        }

        public override int GetInUseEntityId()
        {
            return 0;
        }

        private int newMailTemplateId = 0;
        public override void CheckNewAddedEntity(Model.Private.Catalog.MailTemplate newEntityModel, Model.Private.Catalog.MailTemplate oldEntityModel)
        {
            newMailTemplateId = newEntityModel.Id;
            Assert.IsTrue(newEntityModel.Id > 0, "MailTemplate id should have been greater than 0");
            Assert.AreEqual(newEntityModel.Name, oldEntityModel.Name, "Name Field did not matched");
            Assert.AreEqual(newEntityModel.BodyTemplate, oldEntityModel.BodyTemplate, "Content Field did not matched");
            Assert.AreEqual(newEntityModel.From, oldEntityModel.From, "From Field did not matched");
            Assert.AreEqual(newEntityModel.Subject, oldEntityModel.Subject, "Subject Field did not matched");
        }

        public override int GetMeYourNewFuckingEntityIdIWillDelete()
        {
            return newMailTemplateId;
        }

        [TestMethod]
        [TestCategory("SDK.Private.Catalog"), TestCategory("Integration"), TestCategory("SDK.Private.Catalog.MailTypeManagement")]
        public async Task PostGetUpdateDeleteMailTypeTest()
        {
            await base.CRUDTest();
        }
    }
}
