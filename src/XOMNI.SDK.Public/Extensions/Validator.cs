using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Public.Extensions
{
    public static class Validator
    {
        public static Parameter<T> For<T>(T item, string argName)
        {
            return new Parameter<T>(item, argName);
        }
    }
}
