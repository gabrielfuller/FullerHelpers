using System;
using System.Collections.Specialized;
using System.Web;

namespace FullerHelpers
{
    public static class QuerystringHelpers
    {
        public static int? GetIntValue(NameValueCollection qStrings, string item)
        {
            int? returnValue = null;
            try
            {
                return Convert.ToInt32(HttpUtility.UrlDecode(qStrings[item].ToString()));
            }
            catch
            {
                return null;
            }
        }

        public static string GetStringValue(NameValueCollection qStrings, string item)
        {
            try
            {
                return HttpUtility.UrlDecode(qStrings[item].ToString());
            }
            catch
            {
                return null;
            }
        }
    }
}
