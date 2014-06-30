using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Tests.Private.Auth
{
    [TestClass]
    public class PrincipalManagementFixture : SDKFixtureBase
    {
        private SDK.Private.Auth.PrincipalManagement principalManagement = null;
        private SDK.Management.Security.PrivateApiUserManagement privateApiUserManagement = null;

        public override void Init()
        {
            base.Init();
            principalManagement = new SDK.Private.Auth.PrincipalManagement();
            privateApiUserManagement = new SDK.Management.Security.PrivateApiUserManagement();
        }

        [TestMethod]
        [TestCategory("SDK.Private.Auth"), TestCategory("Integration"), TestCategory("SDK.Private.Auth.PrincipalManagement")]
        public async Task GetPrincipalAyncTest()
        {
            #region Login created api user and call api
            XOMNI.SDK.Model.Management.Security.ApiUser apiUser = new Model.Management.Security.ApiUser
            {
                Name = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString(),
                Username = Guid.NewGuid().ToString()
            };

            int apiUserId = (await privateApiUserManagement.AddAsync(apiUser)).Id;
            principalManagement.SetApiCredentials(new Core.ApiAccess.ApiBasicCredential(apiUser.Username, apiUser.Password));
            var principal = await principalManagement.GetPrincipalAsync();

            Assert.AreEqual(apiUser.Name, principal.ApiUserFirstLastName, "First and last names didn't match");
            Assert.AreEqual(apiUser.Username, principal.ApiUserName, "Usernames didn't match");
            Assert.IsTrue(principal.ApiUserRights.Any(q => q.Description.Contains("PrivateAPI")), "Principal's user righs collection didn't have PrivateAPI item");
            #endregion

            #region Login unknown api user and call api
            principalManagement.SetApiCredentials(new Core.ApiAccess.ApiBasicCredential(Guid.NewGuid().ToString(), Guid.NewGuid().ToString()));

            try
            {
                principal = await principalManagement.GetPrincipalAsync();
                Assert.Fail("Unauthorized exception should have been returned from sdk");
            }
            catch (SDK.Core.Exception.UnauthorizedException)
            {
            }
            #endregion

            await privateApiUserManagement.DeleteAsync(apiUserId);
        }

    }
}
