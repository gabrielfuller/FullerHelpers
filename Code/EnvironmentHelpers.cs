using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace FullerHelpers
{
    public static class EnvironmentHelpers
    {

        /// <summary>
        /// Determines if the user is authorized to use the website based on IPAddress
        /// The IPAddresses are stored in the Web.Config full under the key: SiteSettings.ApprovedIPAddresses
        /// </summary>
        public static bool IsAuthorized(bool isLocal)
        {
            try
            {
                if (isLocal)
                    return true;

                string MyIPAddress = EnvironmentHelpers.MyIPAddress();
                string[] ApprovedIPAddresses =
                    ConfigurationManager.AppSettings["SiteSettings.ApprovedIPAddresses"].ToString().Split(',');
                var data = from c in ApprovedIPAddresses where c.ToLower() == MyIPAddress select c;
                if (data.Count() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static string MachineName = System.Environment.MachineName.ToString();

        public static bool IsOnThisServer(string ServerName, string ServerIPAddress)
        {
            if (ServerName.ToLower() == MachineName.ToLower() && ServerIPAddress.ToLower() == MyIPAddress().ToLower())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsOnEasyOptionsServer()
        {
            return EnvironmentHelpers.IsOnThisServer("EasyOptions", "184.106.77.172");
        }

        public static string MyIPAddress()
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }
    }
}
