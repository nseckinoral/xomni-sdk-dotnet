using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Tests.Extensions
{
    public static class DateTimeExtensions
    {
        public static int GetWeekOfYear(this DateTime datetime)
        {
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(datetime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}
