using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace FullerHelpers
{
    public static class LocationExtensions
    {

        public static bool ViewExists(string name, ControllerContext context)
        {
            ViewEngineResult result = ViewEngines.Engines.FindView(context, name, null);
            return (result.View != null);
        }

        public static string GetControllerFromRoute(string routeName)
        {
            RouteBase route = RouteTable.Routes[routeName];
            return ((Route)route).Defaults["Controller"].ToString();
        }

        public static string GetActionFromRoute(string routeName)
        {
            RouteBase route = RouteTable.Routes[routeName];
            return ((Route)route).Defaults["Action"].ToString();
        }

        public static bool IsParentOfCurrentRoute(this RequestContext context, string parentRouteName)
        {
            if (parentRouteName.ToLower() != "backend")
            {
                try
                {
                    string currentRouteUrl = context.RouteData.Route.GetVirtualPath(context, context.RouteData.Values).VirtualPath.ToLower();
                    string parentRouteUrl = ("Backend/" + parentRouteName).ToLower();
                    if (currentRouteUrl.Contains(parentRouteUrl))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool IsCurrentRoute(this RequestContext context, String areaName)
        {
            return context.IsCurrentRoute(areaName, null, null);
        }

        public static bool IsCurrentRoute(this RequestContext context, String areaName, String controllerName)
        {
            return context.IsCurrentRoute(areaName, controllerName, null);
        }

        public static bool IsCurrentRoute(this RequestContext context, String areaName, String controllerName, params String[] actionNames)
        {
            var routeData = context.RouteData;
            var routeArea = routeData.DataTokens["area"] as String;
            var current = false;

            if (((String.IsNullOrEmpty(routeArea) && String.IsNullOrEmpty(areaName)) || (routeArea == areaName)) && ((String.IsNullOrEmpty(controllerName)) || (routeData.GetRequiredString("controller") == controllerName)) &&
                ((actionNames == null) || actionNames.Contains(routeData.GetRequiredString("action"))))
            {
                current = true;
            }

            return current;
        }

        public static string CurrentActionName(this HtmlHelper helper )
        {
            System.Web.Routing.RouteData routeData = helper.ViewContext.RouteData;
            return routeData.GetRequiredString("action").ToString();
        }

        public static string CurrentControllerName(this HtmlHelper helper)
        {
            System.Web.Routing.RouteData routeData = helper.ViewContext.RouteData;
            return routeData.GetRequiredString("controller").ToString();
        }
    }
}