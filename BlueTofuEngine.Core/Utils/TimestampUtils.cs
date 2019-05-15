using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core.Utils
{
    public static class TimestampUtils
    {
        public static int GetFromDate(DateTime date)
        {
            return (int)(date.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public static double GetFromDateLong(DateTime date)
        {
            return (date.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;
        }

        public static int GetFromNow()
        {
            return GetFromDate(DateTime.UtcNow);
        }
    }
}
