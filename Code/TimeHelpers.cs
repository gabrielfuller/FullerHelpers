using System;

namespace FullerHelpers
{
    public static class TimeHelpers
    {
        public static string GetTimeOfDayGreeting()
        {
            int hourOfDay = DateTime.Now.Hour;
            if (hourOfDay > 0 && hourOfDay < 12)
            {
                return "Good Morning";
            }
            else if (hourOfDay >= 12 && hourOfDay < 18)
            {
                return "Good Afternoon";
            }
            else
            {
                return "Good Evening";
            }
        }

        public static string[] MonthNames = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
    }
}
