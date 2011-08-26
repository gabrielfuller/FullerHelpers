using System.Web;
using System.Web.Routing;

namespace FullerHelpers
{
    public static class URLHelpers
    {
        public static string StandardRoute(string routeName)
        {
            var values = new RouteValueDictionary();
            var path = RouteTable.Routes.GetVirtualPath(
                null,
                routeName,
                values);
            return path.VirtualPath;
        }

        public static string baseUrl()
        {
            HttpContext app = HttpContext.Current;

            string security = "";
            //Because the Web Server is behing a Load Balncer at Rackspace, 
            //I have to detect SSL/Https:// in a different way; I am 
            //detecting here and editing the currentURL since .Net 
            //will never see the Https://
            string HTTP_CLUSTER_HTTPS = app.Request.ServerVariables["HTTP_CLUSTER_HTTPS"];

            string currentRoot = HttpContext.Current.Request.Url.ToString().ToLower();
            if (currentRoot.Contains("thekylesteam.com"))
            {
                if (HTTP_CLUSTER_HTTPS == "on")
                {
                    security = "https://";
                }
                else
                {
                    security = "http://";
                }
            }
            else
            {
                security = "http://";
            }
            string serverName = HttpContext.Current.Request.ServerVariables["SERVER_NAME"];

            string port = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
            if (port == null || port == "80")
                port = "";
            else
                port = ":" + port;

            string appPath = HttpContext.Current.Request.ApplicationPath.ToString();
            string baseUrl = security + serverName + port + appPath;
            try
            {
                if (baseUrl.Substring((baseUrl.Length - 2), (baseUrl.Length - 1)) == "//")
                {
                    baseUrl = baseUrl.TrimEnd('/');
                }
            }
            catch
            {

            }
            int LastCharIndex = baseUrl.Length - 1;
            if (baseUrl[LastCharIndex].ToString() != "/")
            {
                baseUrl += "/";
            }
            return baseUrl;
        }
    }
}
