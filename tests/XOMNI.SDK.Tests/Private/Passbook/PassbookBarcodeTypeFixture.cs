using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Private.Passbook;

namespace XOMNI.SDK.Tests.Private.Passbook
{
    [TestClass]
    public class PassbookBarcodeTypeFixture : SDKFixtureBase
    {
        private PassbookBarcodeTypeManagement barcodeTypeManagement = null;
        public override void Init()
        {
            base.Init();
            barcodeTypeManagement = new PassbookBarcodeTypeManagement();
        }

        [TestMethod]
        [TestCategory("SDK.Private.Passbook"), TestCategory("Integration"), TestCategory("SDK.Private.Passbook.PassbookBarcodeTypeManagement")]
        public async Task GetAsyncTest()
        {
            var barcodeTypes = await barcodeTypeManagement.GetAll();

            foreach (var type in barcodeTypes)
            {
                Assert.IsFalse(String.IsNullOrEmpty(type.Value), "Barcode type name is null or empty");
            }
        }
    }
}
