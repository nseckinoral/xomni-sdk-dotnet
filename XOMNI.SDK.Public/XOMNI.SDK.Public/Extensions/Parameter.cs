using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Public.Extensions
{
    public class Parameter<T>
    {
        public T Value { get; private set; }
        public string ArgName { get; private set; }
        public Parameter(T value, string argName)
        {
            Value = value;
            ArgName = argName;
        }
    }
}
