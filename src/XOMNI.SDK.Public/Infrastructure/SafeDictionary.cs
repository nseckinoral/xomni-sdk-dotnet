using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Public.Infrastructure
{
    public class SafeDictionary<TKey, TValue>
    {
        private readonly object padlock = new object();
        private readonly Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
        public TValue this[TKey key]
        {
            get
            {
                lock (padlock)
                {
                    return dictionary[key];
                }
            }
            set
            {
                lock (padlock)
                {
                    dictionary[key] = value;
                }
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            lock (padlock)
            {
                return dictionary.TryGetValue(key, out value);
            }
        }

        public TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
        {
            TValue retVal = default(TValue);
            if (!this.TryGetValue(key, out retVal))
            {
                lock (padlock)
                {
                    retVal = valueFactory(key);
                    dictionary.Add(key, retVal);
                    return retVal;
                }

            }
            return retVal;
        }
    }
}
