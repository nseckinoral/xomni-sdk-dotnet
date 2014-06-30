using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Tests.Management.Social
{
    //[TestClass]
    //public class FacebookResponseTypesManagementFixture : SDKFixtureBase
    //{
    //    private XOMNI.SDK.Management.Social.FacebookResponseTypesManagement facebookResponseTypesManagement = null;

    //    public override void Init()
    //    {
    //        base.Init();
    //        facebookResponseTypesManagement = new SDK.Management.Social.FacebookResponseTypesManagement();
    //    }

    //    [TestMethod]
    //    [TestCategory("SDK.Management.System"), TestCategory("Integration"), TestCategory("SDK.Management.System.FacebookResponseTypesManagement")]
    //    public async Task GetFacebookResponseTypesAsyncTest()
    //    {
    //        var responseTypes = await facebookResponseTypesManagement.GetFacebookResponseTypesAsync();
    //        CompareToEnum(responseTypes);
    //    }

    //    private void CompareToEnum(IDictionary<int, string> actual)
    //    {
    //        Assert.IsTrue(actual.Count > 0, "Dictionary count must greather than 0");
    //        var enumType = typeof(Wrapper.Facebook.Enums.ResponseType);

    //        foreach (int key in Enum.GetValues(enumType))
    //        {
    //            string value = Enum.GetName(enumType, key);

    //            if (!actual.Any(q => q.Key == key && q.Value == value))
    //            {
    //                Assert.Fail("Enum and Dictionary didn't have the same item!");
    //            }
    //            else
    //            {
    //                actual.Remove(key);
    //            }
    //        }

    //        Assert.IsTrue(actual.Count == 0, "Dictionary count must be equals 0 after deleting item!");
    //    }
    //}
}
