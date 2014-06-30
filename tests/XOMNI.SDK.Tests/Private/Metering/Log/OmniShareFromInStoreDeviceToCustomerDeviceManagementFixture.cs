﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Tests.Private.Metering.Log.MeteringEntities;

namespace XOMNI.SDK.Tests.Private.Metering.Log
{
    [TestClass]
    public class OmniShareFromInStoreDeviceToCustomerDeviceManagementFixture : BaseMeteringManagementFixture
    {
        protected override Model.Private.Metering.CounterTypes CounterType
        {
            get { return Model.Private.Metering.CounterTypes.OmniShareFromInStoreDeviceToCustomerDevice; }
        }

        protected override Type SampleMeteringLogType
        {
            get { return typeof(OmniShareMeteringEntity); }
        }

        [TestMethod]
        [TestCategory("SDK.Private.Metering.Log"), TestCategory("Integration"), TestCategory("SDK.Private.Metering.Log.OmniShareFromInStoreDeviceToCustomerDeviceMeteringManagement")]
        public async Task GetAllAsyncTest()
        {
            await this.InternalGetAllAsyncTest();
        }
    }
}
