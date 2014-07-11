using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Exception;
using XOMNI.SDK.Model;
using XOMNI.SDK.Model.Management.Configuration;

namespace XOMNI.SDK.Tests.Management.Configuration
{
    [TestClass]
    public class ImageSizeProfileManagementFixture : SDKFixtureBase
    {
        XOMNI.SDK.Management.Configuration.ImageSizeProfileManagement imageSizeProfileBusiness = null;

        public override void Init()
        {
            base.Init();
            imageSizeProfileBusiness = new SDK.Management.Configuration.ImageSizeProfileManagement();
        }

        [TestMethod]
        [TestCategory("SDK.Management.Configuration"), TestCategory("Integration"), TestCategory("SDK.Management.Configuration.ImageSizeProfileManagement")]
        public async Task AddImageSizeProfileAsyncTest()
        {
            var profile = CreateSampleProfile();
            var addedProfile = await imageSizeProfileBusiness.AddAsync(profile);
            CompareProfiles(profile, addedProfile);
            try
            {
                await imageSizeProfileBusiness.AddAsync(profile);
                Assert.Fail("Conflict exception should have been returned.");
            }
            catch (ConflictException)
            {
                //OK!
            }
            var getProfile = await imageSizeProfileBusiness.GetAsync(addedProfile.Id);
            CompareProfiles(addedProfile, getProfile, true);
            await imageSizeProfileBusiness.DeleteAsync(addedProfile.Id);
        }

        [TestMethod]
        [TestCategory("SDK.Management.Configuration"), TestCategory("Integration"), TestCategory("SDK.Management.Configuration.ImageSizeProfileManagement")]
        public async Task DeleteImageSizeProfileAsyncTest()
        {
            var profile = CreateSampleProfile();
            var addedProfile = await imageSizeProfileBusiness.AddAsync(profile);
            CompareProfiles(profile, addedProfile);
            try
            {
                await imageSizeProfileBusiness.DeleteAsync(int.MaxValue);
                Assert.Fail("Not Found exception should have been returned.");
            }
            catch (NotFoundException)
            {
                //OK!
            }

            await imageSizeProfileBusiness.DeleteAsync(addedProfile.Id);

            try
            {
                await imageSizeProfileBusiness.GetAsync(addedProfile.Id);
                Assert.Fail("Not Found exception should have been returned.");
            }
            catch (NotFoundException)
            {

            }
        }

        [TestMethod]
        [TestCategory("SDK.Management.Configuration"), TestCategory("Integration"), TestCategory("SDK.Management.Configuration.ImageSizeProfileManagement")]
        public async Task GetImageSizeProfileAsyncTest()
        {
            var profile = CreateSampleProfile();
            var addedProfile = await imageSizeProfileBusiness.AddAsync(profile);
            CompareProfiles(profile, addedProfile);
            var getProfileResponse = await imageSizeProfileBusiness.GetAsync(addedProfile.Id);
            CompareProfiles(addedProfile, getProfileResponse, true);
            CompareProfiles(getProfileResponse);
            try
            {
                await imageSizeProfileBusiness.GetAsync(int.MaxValue);
                Assert.Fail("Not Found exception should have been returned.");
            }
            catch (NotFoundException)
            {

            }

            await imageSizeProfileBusiness.DeleteAsync(addedProfile.Id);
        }

        [TestMethod]
        [TestCategory("SDK.Management.Configuration"), TestCategory("Integration"), TestCategory("SDK.Management.Configuration.ImageSizeProfileManagement")]
        public async Task GetAllImageSizeProfileAsyncTest()
        {
            int totalProfileCount = 0;
            CountedCollectionContainer<ImageSizeProfile> profiles = null;
            try
            {
                profiles = await imageSizeProfileBusiness.GetAllAsync(0, 1000);
                totalProfileCount = profiles.TotalCount;
            }
            catch (NotFoundException)
            { }
            var profile = CreateSampleProfile();
            var addedProfile = await imageSizeProfileBusiness.AddAsync(profile);
            CompareProfiles(profile, addedProfile);
            profiles = await imageSizeProfileBusiness.GetAllAsync(0, 1000);

            Assert.AreEqual(totalProfileCount + 1, profiles.TotalCount, "Total Counts did not match");

            profiles.Results.ForEach(p => CompareProfiles(p));

            try
            {
                await imageSizeProfileBusiness.GetAllAsync(totalProfileCount, 10);
            }
            catch (NotFoundException)
            {
                //OK!   
            }
            await imageSizeProfileBusiness.DeleteAsync(addedProfile.Id);
        }

        private void CompareProfiles(ImageSizeProfile profile, ImageSizeProfile addedProfile, bool compareIds = false)
        {
            Assert.AreEqual(profile.Height, addedProfile.Height, "Height information did not match");
            Assert.AreEqual(profile.Width, addedProfile.Width, "Width information did not match");
            Assert.IsTrue(addedProfile.Id > 0, "Id field of added profiled shoul hava a valid id");
            if (compareIds)
            {
                Assert.AreEqual(profile.Id, addedProfile.Id, "Id information did not match");
            }
        }

        private void CompareProfiles(ImageSizeProfile profile)
        {
            Assert.IsTrue(profile.Id > 0, "Id field of added profiled shoul hava a valid value");
            Assert.IsTrue(profile.Height > 0, "Height field of added profiled shoul hava a valid value");
            Assert.IsTrue(profile.Width > 0, "Width field of added profiled shoul hava a valid value");
        }

        private ImageSizeProfile CreateSampleProfile()
        {
            Random rnd = new Random();
            ImageSizeProfile profile = new ImageSizeProfile()
            {
                Height = rnd.Next(500),
                Width = rnd.Next(500)
            };

            return profile;
        }
    }
}
