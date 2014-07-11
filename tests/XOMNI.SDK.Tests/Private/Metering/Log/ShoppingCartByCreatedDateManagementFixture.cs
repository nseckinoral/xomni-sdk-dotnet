using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Tests.Private.Metering.Log.MeteringEntities;

namespace XOMNI.SDK.Tests.Private.Metering.Log
{
    [TestClass]
    public class ShoppingCartByCreatedDateManagementFixture : BaseMeteringManagementFixture
    {
        protected override Model.Private.Metering.CounterTypes CounterType
        {
            get { return Model.Private.Metering.CounterTypes.ShoppingCartByCreatedDate; }
        }

        protected override Type SampleMeteringLogType
        {
            get { return typeof(ShoppingCartByCreatedDateMeteringEntity); }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Metering.Log"), TestCategory("Integration"), TestCategory("SDK.Private.Metering.Log.ShoppingCartByCreatedDateMeteringManagement")]
        public async Task GetAllAsyncTest()
        {
            await this.InternalGetAllAsyncTest();
        }
    }
}
