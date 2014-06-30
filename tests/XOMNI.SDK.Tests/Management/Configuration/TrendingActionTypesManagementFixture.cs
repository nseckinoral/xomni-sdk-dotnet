using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Tests.Management.Configuration
{
    [TestClass]
    public class TrendingActionTypesManagementFixture : SDKFixtureBase
    {
        XOMNI.SDK.Management.Configuration.TrendingActionTypesManagement trendingActionTypesManagement = null;

        public override void Init()
        {
            base.Init();
            trendingActionTypesManagement = new SDK.Management.Configuration.TrendingActionTypesManagement();
        }


        [TestMethod]
        [TestCategory("SDK.Management.Configuration"), TestCategory("Integration"), TestCategory("SDK.Management.Configuration.TrendingActionTypesManagement")]
        public async Task GetUpdateSettingsAsyncTest()
        {
            var exSettings = await trendingActionTypesManagement.GetAsync();

            var settings = await trendingActionTypesManagement.GetAsync();

            var rnd = new Random();
            foreach (var item in settings)
            {
                item.ImpactValue = rnd.Next(0, 100) + rnd.NextDouble();
            }

            var updatedSettings = await trendingActionTypesManagement.UpdateAsync(settings);

            foreach (var item in updatedSettings)
            {
                var exSettingItem = settings.Where(t => t.Id == item.Id).First();
                CompareSettings(item, exSettingItem);
            }

            updatedSettings = await trendingActionTypesManagement.UpdateAsync(exSettings);

            foreach (var item in updatedSettings)
            {
                var exSettingItem = exSettings.Where(t => t.Id == item.Id).First();
                CompareSettings(item, exSettingItem);
            }
        }

        private void CompareSettings(Model.Management.Configuration.TrendingActionTypeValue expectedSettings, Model.Management.Configuration.TrendingActionTypeValue actualSettings)
        {
            Assert.AreEqual(expectedSettings.Id, actualSettings.Id, "Id did not match");
            Assert.AreEqual(expectedSettings.ImpactValue, actualSettings.ImpactValue, "ImpactValue did not match");
            Assert.AreEqual(expectedSettings.Description, actualSettings.Description, "Description did not match");
        }
    }
}
