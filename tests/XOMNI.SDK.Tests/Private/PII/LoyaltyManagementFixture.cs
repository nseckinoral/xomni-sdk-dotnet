using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Exception;
using XOMNI.SDK.Model.Private.PII;
using XOMNI.SDK.Private.PII;
using XOMNI.SDK.Tests.Private.Catalog;

namespace XOMNI.SDK.Tests.Private.PII
{
    [TestClass]
    public class LoyaltyManagementFixture : BaseCRUDManagementFixture<Model.Private.PII.LoyaltyUser>
    {
        private LoyaltyManagement loyaltyBusiness { get { return (LoyaltyManagement)this.CrudManagement; } }

        public override Core.Management.BaseCRUDSkipTakeManagement<Model.Private.PII.LoyaltyUser> CrudManagement
        {
            get { return new LoyaltyManagement(); }
        }

        public override Model.Private.PII.LoyaltyUser GetBadEntityModel()
        {
            return new Model.Private.PII.LoyaltyUser()
            {
                AvailablePoints = new Random().NextDouble() * 34.5,
                City = Guid.NewGuid().ToString(),
                EMailAddress = Guid.NewGuid().ToString(),
                Gender = "Male",
                Name = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString(),
                PhoneNumber = Guid.NewGuid().ToString(),
                State = Guid.NewGuid().ToString(),
                StreetAddress1 = Guid.NewGuid().ToString(),
                StreetAddress2 = Guid.NewGuid().ToString(),
                Zip = Guid.NewGuid().ToString().Substring(0, 10)
            };
        }

        public override int GetNotFoundEntityId()
        {
            return 99999;
        }

        public override Model.Private.PII.LoyaltyUser GetValidEntityModel()
        {
            return new Model.Private.PII.LoyaltyUser()
            {
                AvailablePoints = new Random().NextDouble() * 34.5,
                City = Guid.NewGuid().ToString(),
                EMailAddress = Guid.NewGuid().ToString(),
                Gender = "Male",
                Name = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString(),
                PhoneNumber = Guid.NewGuid().ToString(),
                State = Guid.NewGuid().ToString(),
                StreetAddress1 = Guid.NewGuid().ToString(),
                StreetAddress2 = Guid.NewGuid().ToString(),
                UserName = Guid.NewGuid().ToString(),
                Zip = Guid.NewGuid().ToString().Substring(0, 10)
            };
        }

        public override int GetInUseEntityId()
        {
            return 0;
        }

        private int newLoyalityId = 0;
        public override void CheckNewAddedEntity(Model.Private.PII.LoyaltyUser newEntityModel, Model.Private.PII.LoyaltyUser oldEntityModel)
        {
            newLoyalityId = newEntityModel.Id;
            Assert.IsTrue(newEntityModel.Id > 0, "Tag id should have been greater than 0");
            Assert.AreEqual(newEntityModel.UserName, oldEntityModel.UserName, "UserName Field did not matched");
            Assert.AreEqual(newEntityModel.Password, oldEntityModel.Password, "Password Field did not matched");
            Assert.AreEqual(newEntityModel.Name, oldEntityModel.Name, "Name Field did not matched");
            Assert.AreEqual(newEntityModel.AvailablePoints, oldEntityModel.AvailablePoints, "AvailablePoints Field did not matched");
            Assert.AreEqual(newEntityModel.StreetAddress1, oldEntityModel.StreetAddress1, "StreetAddress1 Field did not matched");
            Assert.AreEqual(newEntityModel.StreetAddress2, oldEntityModel.StreetAddress2, "StreetAddress2 Field did not matched");
            Assert.AreEqual(newEntityModel.City, oldEntityModel.City, "City Field did not matched");
            Assert.AreEqual(newEntityModel.State, oldEntityModel.State, "State Field did not matched");
            Assert.AreEqual(newEntityModel.Zip, oldEntityModel.Zip, "Zip Field did not matched");
            Assert.AreEqual(newEntityModel.PhoneNumber, oldEntityModel.PhoneNumber, "PhoneNumber Field did not matched");
            Assert.AreEqual(newEntityModel.EMailAddress, oldEntityModel.EMailAddress, "EMailAddress Field did not matched");
            Assert.AreEqual(newEntityModel.Gender, oldEntityModel.Gender, "Gender Field did not matched");
            Assert.AreEqual(newEntityModel.DateOfBirth, oldEntityModel.DateOfBirth, "DateOfBirth Field did not matched");
        }

        public override int GetMeYourNewFuckingEntityIdIWillDelete()
        {
            return newLoyalityId;
        }

        [TestMethod]
        [TestCategory("SDK.Private.PII"), TestCategory("Integration"), TestCategory("SDK.Private.PII.LoyaltyManagement")]
        public async Task PostGetUpdateDeleteLoyaltyTest()
        {
            await base.CRUDTest();
        }

        [TestInitialize]
        public void Initialize()
        {
            sampleLoyaltyUserId = loyaltyBusiness.AddAsync(GetValidEntityModel()).Result.Id;
        }

        [TestCleanup]
        public void CleanUp()
        {
            loyaltyBusiness.DeleteAsync(sampleLoyaltyUserId).Wait(); ;
        }

        private int sampleLoyaltyUserId;

        [TestMethod]
        [TestCategory("SDK.Private.PII"), TestCategory("Integration"), TestCategory("SDK.Private.PII.LoyaltyManagement")]
        public async Task AddLoyaltyUserMetadataAsyncTest()
        {
            string testMetadataKey = Guid.NewGuid().ToString();
            string testMetadataValue = Guid.NewGuid().ToString();
            var createdMetadata = await loyaltyBusiness.AddMetadataAsync(sampleLoyaltyUserId, testMetadataKey, testMetadataValue);

            Assert.AreEqual(sampleLoyaltyUserId, createdMetadata.LoyaltyUserId, "Category ids did not match");
            Assert.AreEqual(testMetadataKey, createdMetadata.Key, "Metdata keys did not match");
            Assert.AreEqual(testMetadataValue, createdMetadata.Value, "Metadata values did not match");

            try
            {
                await loyaltyBusiness.AddMetadataAsync(int.MaxValue, testMetadataKey, testMetadataValue);
                Assert.Fail("Bad request exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk.
            }

            try
            {
                await loyaltyBusiness.AddMetadataAsync(sampleLoyaltyUserId, testMetadataKey, testMetadataValue);
                Assert.Fail("Conflict exception should have been returned from sdk");
            }
            catch (ConflictException)
            {
                //Conflict exception should have been returned from sdk
            }

            try
            {
                await loyaltyBusiness.AddMetadataAsync(sampleLoyaltyUserId, null, null);
                Assert.Fail("Argument null exception should have been returned from sdk");
            }
            catch (ArgumentNullException)
            {
                //Argument null exception should have been returned from sdk
            }

            await loyaltyBusiness.DeleteMetadataAsync(createdMetadata.LoyaltyUserId, createdMetadata.Key);
        }

        [TestMethod]
        [TestCategory("SDK.Private.PII"), TestCategory("Integration"), TestCategory("SDK.Private.PII.LoyaltyManagement")]
        public async Task GetAllLoyaltyUserMetadataAsyncTest()
        {
            List<LoyaltyUserMetadata> loyaltyUserMetadata = new List<LoyaltyUserMetadata>();

            for (int i = 0; i < 5; i++)
            {
                string testMetadataKey = Guid.NewGuid().ToString();
                string testMetadataValue = Guid.NewGuid().ToString();
                var createdMetadata = await loyaltyBusiness.AddMetadataAsync(sampleLoyaltyUserId, testMetadataKey, testMetadataValue);
                loyaltyUserMetadata.Add(createdMetadata);
            }
            List<LoyaltyUserMetadata> allMetadata = await loyaltyBusiness.GetAllMetadataAsync(sampleLoyaltyUserId);

            foreach (var metadata in loyaltyUserMetadata)
            {
                if (!allMetadata.Any(x => x.Key == metadata.Key && x.Value == metadata.Value))
                {
                    Assert.Fail("Collections are not equal");
                }
            }

            try
            {
                await loyaltyBusiness.GetAllMetadataAsync(int.MaxValue);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }
        }

        [TestMethod]
        [TestCategory("SDK.Private.PII"), TestCategory("Integration"), TestCategory("SDK.Private.PII.LoyaltyManagement")]
        public async Task UpdateLoyaltyUserMetadataAsyncTest()
        {
            string testMetadataKey = Guid.NewGuid().ToString();
            string testMetadataValue = Guid.NewGuid().ToString();
            var createdMetadata = await loyaltyBusiness.AddMetadataAsync(sampleLoyaltyUserId, testMetadataKey, testMetadataValue);
            string newTestMetadataValue = Guid.NewGuid().ToString();

            var updatedMetadata = await loyaltyBusiness.UpdateMetadataAsync(createdMetadata.LoyaltyUserId, createdMetadata.Key, newTestMetadataValue);

            Assert.AreEqual(createdMetadata.LoyaltyUserId, updatedMetadata.LoyaltyUserId, "Category ids should have been same");
            Assert.AreEqual(updatedMetadata.Key, updatedMetadata.Key, "Metadata keys should have been same");
            Assert.AreEqual(newTestMetadataValue, updatedMetadata.Value, "Metadata values should have been same");

            try
            {
                await loyaltyBusiness.UpdateMetadataAsync(int.MaxValue, createdMetadata.Key, newTestMetadataValue);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            await loyaltyBusiness.DeleteMetadataAsync(updatedMetadata.LoyaltyUserId, updatedMetadata.Key);
        }

        [TestMethod]
        [TestCategory("SDK.Private.PII"), TestCategory("Integration"), TestCategory("SDK.Private.PII.LoyaltyManagement")]
        public async Task DeleteLoyaltyUserMetadataAsyncTest()
        {
            string testMetadataKey = Guid.NewGuid().ToString();
            string testMetadataValue = Guid.NewGuid().ToString();
            var createdMetadata = await loyaltyBusiness.AddMetadataAsync(sampleLoyaltyUserId, testMetadataKey, testMetadataValue);

            await loyaltyBusiness.DeleteMetadataAsync(createdMetadata.LoyaltyUserId, createdMetadata.Key);

            try
            {
                var list = await loyaltyBusiness.GetAllMetadataAsync(createdMetadata.LoyaltyUserId);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            try
            {
                await loyaltyBusiness.DeleteMetadataAsync(createdMetadata.LoyaltyUserId, createdMetadata.Key);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }
        }

        [TestMethod]
        [TestCategory("SDK.Private.PII"), TestCategory("Integration"), TestCategory("SDK.Private.PII.LoyaltyManagement")]
        public async Task ClearLoyaltyUserMetadataAsyncTest()
        {
            List<LoyaltyUserMetadata> categoryMetadata = new List<LoyaltyUserMetadata>();

            for (int i = 0; i < 5; i++)
            {
                string testMetadataKey = Guid.NewGuid().ToString();
                string testMetadataValue = Guid.NewGuid().ToString();
                var createdMetadata = await loyaltyBusiness.AddMetadataAsync(sampleLoyaltyUserId, testMetadataKey, testMetadataValue);
                categoryMetadata.Add(createdMetadata);
            }
            var allMetadata = await loyaltyBusiness.GetAllMetadataAsync(sampleLoyaltyUserId);

            Assert.IsTrue(allMetadata.Count > 0, "Total category metadata count should have been greater than 0");

            await loyaltyBusiness.ClearMetadataAsync(sampleLoyaltyUserId);

            try
            {
                await loyaltyBusiness.GetAllMetadataAsync(sampleLoyaltyUserId);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }

            try
            {
                await loyaltyBusiness.ClearMetadataAsync(int.MaxValue);
                Assert.Fail("Not Found exception should have been returned from sdk");
            }
            catch (NotFoundException)
            {
                //Not Found exception should have been returned from sdk
            }
        }

    }
}
