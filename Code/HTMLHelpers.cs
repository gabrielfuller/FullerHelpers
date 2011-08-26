using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace FullerHelpers
{
    public static class HTMLHelpers
    {
        private static RequestContext RequestContext
        {
            get
            {
                HttpContextBase context = new HttpContextWrapper(HttpContext.Current);
                return new RequestContext(context, RouteTable.Routes.GetRouteData(context));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="html"></param>
        /// <param name="searchstring"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static MvcHtmlString FlickrBomb(this HtmlHelper html, string searchstring, int width, int height, string cssClass)
        {
            var tag = new TagBuilder("img");
            tag.Attributes["width"] = width + "px";
            tag.Attributes["height"] = height + "px";
            tag.Attributes["src"] = "flickr://" + searchstring;
            tag.AddCssClass(cssClass);
            return MvcHtmlString.Create(tag.ToString());
        }


        public static MvcHtmlString CreateEmailLink(this HtmlHelper HTML, string linkText, string emailLink)
        {
            var tag = new TagBuilder("a");
            tag.Attributes["href"] = emailLink;
            tag.InnerHtml = linkText;
            return MvcHtmlString.Create(tag.ToString());
        }

        public static MvcHtmlString ActionMenuItem(this HtmlHelper htmlHelper, String linkText, String routeName)
        {
            var item = ActionMenuItem(htmlHelper, linkText, routeName, null, null);
            return MvcHtmlString.Create(item.ToString());
        }

        public static MvcHtmlString ActionMenuItem(this HtmlHelper htmlHelper, string linkText, string routeName, string htmlID, string cssClass)
        {
            var tag = new TagBuilder("li");
            string
                controller = LocationExtensions.GetControllerFromRoute(routeName),
                action = LocationExtensions.GetActionFromRoute(routeName);
            var IsCurrentRoute = htmlHelper.ViewContext.RequestContext.IsCurrentRoute(null, controller, action);
            var IsParentOfCurrentRoute = htmlHelper.ViewContext.RequestContext.IsParentOfCurrentRoute(routeName);
            if (IsCurrentRoute || IsParentOfCurrentRoute)
            {
                tag.AddCssClass("active");
            }

            if (!String.IsNullOrEmpty(cssClass))
            {
                tag.AddCssClass(cssClass);
            }
            if (!String.IsNullOrEmpty(htmlID))
            {
                tag.Attributes["id"] = htmlID;
            }

            tag.InnerHtml = htmlHelper.RouteLink(linkText, routeName, null).ToString();

            return MvcHtmlString.Create(tag.ToString());
        }

        

        public static MvcHtmlString ActionMenuItem(this HtmlHelper htmlHelper, String linkText, String routeName, object routeValues)
        {
            var tag = new TagBuilder("li");
            string
                controller = LocationExtensions.GetControllerFromRoute(routeName),
                action = LocationExtensions.GetActionFromRoute(routeName);
            if (htmlHelper.ViewContext.RequestContext.IsCurrentRoute(null, controller, action))
            {
                tag.AddCssClass("active");
            }

            tag.InnerHtml = htmlHelper.RouteLink(linkText, routeName, routeValues).ToString();

            return MvcHtmlString.Create(tag.ToString());
        }

        public static MvcHtmlString GetNoItemsInGridMessage(this HtmlHelper htmlHelper, string ItemName)
        {
            string message = "There are no " + ItemName + " to show.";

            TagBuilder outer = new TagBuilder("div");
            outer.AddCssClass("outer-rounded-box-bold");

            TagBuilder inner = new TagBuilder("div");
            inner.AddCssClass("simple-rounded-box sidebarMenu");
            inner.InnerHtml = message;

            outer.InnerHtml += inner.ToString();

            string html = outer.ToString();
            return MvcHtmlString.Create(html);
        }

        public static MvcHtmlString GetPageHeader(this HtmlHelper htmlHelper, string PageTitle, string[] UserRoles, string OrganizationName, 
            bool CreateSearchForm, bool UserIsOrgAdmin)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div><div class=\"pageTitle\"><h2>" + PageTitle);
            if (UserIsOrgAdmin)
            {
                sb.Append(" for " + OrganizationName);
            }
            sb.Append("</h2></div>");

            if (CreateSearchForm == true)
            {
                sb.Append("<div class=\"SearchContainer\"><form method=\"get\">");
                var form = htmlHelper.BeginForm("Index", "User", FormMethod.Get);
                using (htmlHelper.BeginForm("Index", "User", FormMethod.Get))
                {
                    //sb.Append(htmlHelper.Label("Search").ToHtmlString());
                    sb.Append(htmlHelper.TextBox("search", RequestContext.HttpContext.Request.QueryString["search"], new { @class = "defaultText", title = "Search"}).ToHtmlString());
                    sb.Append("<button type=\"submit\" class=\"form-button\"><span>Search</span></button>");
                }
                sb.Append("</form>");
                sb.Append("</div>");
            }
            sb.Append("</div>");
            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString DisplayMessage(string messageText, DisplayMessageType type)
        {
            TagBuilder tag = new TagBuilder("div");
            tag.AddCssClass("message");
            tag.AddCssClass(type.ToString().ToLower());
            tag.InnerHtml = messageText;
            return MvcHtmlString.Create(tag.ToString());
        }
    } 
}