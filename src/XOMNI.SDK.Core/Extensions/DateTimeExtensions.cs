using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static int GetWeekOfYear(this DateTime datetime)
        {
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(datetime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static double ToOADate(this DateTime dt)
        {
            return TicksToOADate(dt, dt.Ticks);
        }

        public static double TicksToOADate(this DateTime dt, long value)
        {
            if (value == 0)
            {
                return 0.0;
            }
            if (value < 864000000000L)
            {
                value += 599264352000000000L;
            }
            if (value < 31241376000000000L)
            {
                throw new OverflowException("Arg_OleAutDateInvalid");
            }
            long num = (value - 599264352000000000L) / 10000;
            if (num < 0)
            {
                long num2 = num % 86400000;
                if (num2 == 0)
                {
                    goto IL_78;
                }
                num -= (86400000 + num2) * 2;
            }
        IL_78:
            return (double)num / 86400000.0;
        }
    }
}
