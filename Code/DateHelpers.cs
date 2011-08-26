using System;
using System.Globalization;
using System.Text;

namespace FullerHelpers
{
    public static class DateHelpers
    {
        public static string GetRFC822Date(DateTime date)
        {
            int offset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).Hours;
            string timeZone = "+" + offset.ToString().PadLeft(2, '0');

            if (offset < 0)
            {
                int i = offset * -1;
                timeZone = "-" + i.ToString().PadLeft(2, '0');
            }

            return date.ToString("ddd, dd MMM yyyy HH:mm:ss " + timeZone.PadRight(5, '0'));
        }

        public static string GetSerializedDate()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now.Year.ToString());
            sb.Append(DateTime.Now.Month.ToString());
            sb.Append(DateTime.Now.Day.ToString());
            sb.Append(DateTime.Now.Hour.ToString());
            sb.Append(DateTime.Now.Minute.ToString());
            sb.Append(DateTime.Now.Millisecond.ToString());
            return sb.ToString();
        }


        public static string[] GetMonthNames()
        {
            CultureInfo culture = System.Globalization.CultureInfo.CurrentUICulture;
            DateTimeFormatInfo info = culture.DateTimeFormat;
            return info.MonthNames;
        }

        public static string[] GetDaysOfTheWeek()
        {
            var WeekdayStart = DayOfWeek.Monday;
            CultureInfo culture = System.Globalization.CultureInfo.CurrentUICulture;
            DateTimeFormatInfo info = culture.DateTimeFormat;
            info.FirstDayOfWeek = WeekdayStart;
            return info.DayNames;
        }
        
        public static string[] GetDaysOfTheWeek(DayOfWeek WeekdayStart)
        {
            CultureInfo culture = System.Globalization.CultureInfo.CurrentUICulture;
            DateTimeFormatInfo info = culture.DateTimeFormat;
            var DayNames = info.DayNames;
            int FirstDayOfWeek = (int)WeekdayStart;
            string[] tempdays = new string[7];
            for (int i = 0; i <= DayNames.GetUpperBound(0); i++)
            {
                tempdays[i] = DayNames[(FirstDayOfWeek + i) % 7];
            }
            return tempdays;
        }

        



        public static string GetMonthName(int month, bool abbreviate, IFormatProvider provider)
        {
            DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(provider);
            if (abbreviate) return info.GetAbbreviatedMonthName(month);
            return info.GetMonthName(month);
        }

        public static string GetMonthName(int month, bool abbreviate)
        {
            return GetMonthName(month, abbreviate, null);
        }

        public static string GetMonthName(int month, IFormatProvider provider)
        {
            return GetMonthName(month, false, provider);
        }

        public static string GetMonthName(int month)
        {
            return GetMonthName(month, false, null);
        }


    }
}
