using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Tests.Management.Social
{
    [TestClass]
    public class FacebookDisplayTypesManagementFixture : SDKFixtureBase
    {
        private XOMNI.SDK.Management.Social.FacebookDisplayTypesManagement facebookDisplayTypesManagement = null;

        public override void Init()
        {
            base.Init();
            facebookDisplayTypesManagement = new SDK.Management.Social.FacebookDisplayTypesManagement();
        }

        [TestMethod]
        [TestCategory("SDK.Management.Social"), TestCategory("Integration"), TestCategory("SDK.Management.Social.FacebookDisplayTypesManagement")]
        public async Task GetFacebookDisplayTypesAsyncTest()
        {
            var displayTypes = await facebookDisplayTypesManagement.GetFacebookDisplayTypesAsync();
            CompareToEnum(displayTypes);
        }

        private void CompareToEnum(IDictionary<int, string> actual)
        {
            Assert.IsTrue(actual.Count > 0, "Dictionary count must greather than 0");
            var enumType = typeof(Wrapper.Facebook.Enums.DisplayType);

            foreach (int key in Enum.GetValues(enumType))
            {
                string value = Enum.GetName(enumType, key);

                if (!actual.Any(q => q.Key == key && q.Value == value))
                {
                    Assert.Fail("Enum and Dictionary didn't have the same item!");
                }
                else
                {
                    actual.Remove(key);
                }
            }

            Assert.IsTrue(actual.Count == 0, "Dictionary count must be equals 0 after deleting item!");
        }
    }
}