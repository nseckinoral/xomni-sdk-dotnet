using KellermanSoftware.CompareNetObjects;
using KellermanSoftware.CompareNetObjects.TypeComparers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Test.Helpers.CustomComparers;

namespace XOMNI.SDK.Public.Test.Helpers
{
    public static class AssertExtensions
    {
        static readonly CompareLogic customCompareLogic = new CompareLogic(new ComparisonConfig
        {
            CustomComparers = new List<BaseTypeComparer>
            {
                new ExceptionTypeComparer(new RootComparer())
            }
        });

        public static void AreDeeplyEqual<T>(T expected, T actual)
        {
            var compareResult = customCompareLogic.Compare(expected, actual);
            if (!compareResult.AreEqual)
            {
                Assert.Fail("Two objects properties must be same." + compareResult.DifferencesString);
            }
        }
    }
}
