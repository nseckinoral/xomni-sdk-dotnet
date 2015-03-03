using KellermanSoftware.CompareNetObjects;
using KellermanSoftware.CompareNetObjects.TypeComparers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Public.Test.Helpers.CustomComparers
{
    public class ExceptionTypeComparer : BaseTypeComparer
    {
        public ExceptionTypeComparer(RootComparer comparer)
            : base(comparer)
        {

        }

        public override void CompareType(CompareParms parms)
        {
            Assert.AreEqual(parms.Object1.GetType(), parms.Object2.GetType());
            Assert.AreEqual((parms.Object1 as Exception).Message, (parms.Object2 as Exception).Message);
        }

        public override bool IsTypeMatch(Type type1, Type type2)
        {
            return typeof(Exception).IsAssignableFrom(type1) && typeof(Exception).IsAssignableFrom(type2);
        }
    }
}
