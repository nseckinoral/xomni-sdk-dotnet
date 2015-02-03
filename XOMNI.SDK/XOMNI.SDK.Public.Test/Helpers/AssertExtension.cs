using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Public.Test.Helpers
{
    public static class AssertExtensions
    {
        static readonly CompareLogic defaultCompareLogic = new CompareLogic();
        static readonly CompareLogic exceptionCompareLogic = new CompareLogic(new ComparisonConfig {
         
        });

        public static void AreDeeplyEqual<T>(T expected, T actual)
        {
            var compareResult = defaultCompareLogic.Compare(expected, actual);
            if (!compareResult.AreEqual)
            {
                Assert.Fail("Two objects properties must be same." + compareResult.DifferencesString);
            }
        }

        public static void AreDeeplyEqual(Exception expected, Exception actual)
        {
            Assert.AreEqual(expected.GetType(), actual.GetType());
            Assert.AreEqual(expected.Message, actual.Message);
        }
    }
}
