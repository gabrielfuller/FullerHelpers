using System;
using System.Configuration;

namespace FullerHelpers
{
    public static class NumberHelpers
    {
        public static decimal GetAppSettingValueDecimal(string key, decimal defaultValue)
        {
            try
            {
                return Convert.ToDecimal(ConfigurationManager.AppSettings[key].ToString());
            }
            catch
            {
                return defaultValue;
            }
        }

        public static int GetAppSettingValueInt(string key, int defaultValue)
        {
            try
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings[key].ToString());
            }
            catch
            {
                return defaultValue;
            }
        }

        public enum NumberType
        {
            Even,
            Odd
        }

        public static NumberType GetNumberType(int num)
        {
            if (num % 2 == 0)
            {
                return NumberType.Even;
            }
            else
            {
                return NumberType.Odd;
            }
        }

        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
