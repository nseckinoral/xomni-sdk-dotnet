using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Public.Extensions
{
    public static class ValidatorExtension
    {
        public static Parameter<T> IsNotNull<T>(this Parameter<T> item) where T : class
        {
            if (item.Value == null)
            {
                throw new ArgumentNullException(string.Format("{0} can not be null.", item.ArgName));
            }
            return item;
        }

        public static Parameter<Nullable<double>> IsNotNull(this Parameter<Nullable<double>> item)
        {
            if(!item.Value.HasValue)
            {
                throw new ArgumentException(string.Format("{0} can not be null.", item.ArgName));
            }
            return item;
        }

        public static Parameter<string> IsNotNullOrEmpty(this Parameter<string> item)
        {
            if (string.IsNullOrEmpty(item.Value))
            {
                throw new ArgumentException(string.Format("{0} can not be empty or null.", item.ArgName));
            }
            return item;
        }
        public static Parameter<string> Contains(this Parameter<string> item, char character)
        {
            IsNotNullOrEmpty(item);

            if (!item.Value.Contains(character))
            {
                throw new ArgumentException(string.Format("{0} must be include ';' character.", item.ArgName));
            }
            return item;
        }

        public static Parameter<int> InRange(this Parameter<int> item, int minBound, int maxBound)
        {
            if (item.Value < minBound || maxBound < item.Value)
            {
                throw new ArgumentOutOfRangeException(string.Format("{0} must be in range ({1} - {2}).", item.ArgName, minBound, maxBound));
            }
            return item;
        }

        public static Parameter<double> InRange(this Parameter<double> item, double minBound, double maxBound)
        {
            if (item.Value < minBound || maxBound < item.Value)
            {
                throw new ArgumentOutOfRangeException(string.Format("{0} must be in range ({1} - {2}).", item.ArgName, minBound, maxBound));
            }
            return item;
        }

        public static Parameter<int> IsGreaterThanOrEqual(this Parameter<int> item, int bound)
        {
            if (item.Value < bound)
            {
                throw new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", item.ArgName, bound));
            }
            return item;
        }

    }
}
