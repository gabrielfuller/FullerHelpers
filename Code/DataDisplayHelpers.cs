using System;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FullerHelpers
{
    public static class DataDisplayHelpers
    {
        public static MvcHtmlString WebgridPagingInformation(this HtmlHelper htmlHelper, int PageIndex, int RowsPerPage, int objectCount, string SingleObjectName, string PluralObjectName)
        {
            int PageCount = (objectCount % RowsPerPage == 0 ? objectCount / RowsPerPage : (objectCount / RowsPerPage) + 1);
            if (objectCount == 0)
            {
                return System.Web.Mvc.MvcHtmlString.Create("");
            }
            else
            {
                TagBuilder pageInfo = new TagBuilder("p");
                pageInfo.AddCssClass("pagingInfo");

                string item1, item2;

                if (PageCount == 1)
                {
                    item1 = ((PageIndex * RowsPerPage) + 1).ToString();
                    item2 = (((PageIndex * RowsPerPage) + 1) + (objectCount % RowsPerPage) - 1).ToString();
                }
                else
                {
                    var currentPage = PageIndex;
                    if (currentPage == PageCount)
                    {
                        item1 = ((PageIndex * RowsPerPage) + 1).ToString();
                        item2 = (((PageIndex * RowsPerPage) + 1) + (objectCount % RowsPerPage) - 0).ToString();
                    }
                    else
                    {
                        item1 = ((PageIndex * RowsPerPage) + 1).ToString();
                        var lastNumber = ((PageIndex * RowsPerPage) + RowsPerPage);
                        item2 = (lastNumber > objectCount ? objectCount : lastNumber).ToString();
                    }
                }
                pageInfo.InnerHtml += item1 + " - " + item2;

                string modelName = (objectCount == 1 ? SingleObjectName : PluralObjectName);
                pageInfo.InnerHtml += " of " + objectCount + " " + modelName;
                return MvcHtmlString.Create(pageInfo.ToString());
            }
        }

        private static string AppendQuerystringToLink(MvcHtmlString str, NameValueCollection qStrings)
        {
            string link = "?";
            foreach (var key in qStrings.AllKeys)
            {
                link += "&" + key + "=" + qStrings[key];
            }
            
            return MvcHtmlString.Create(str + link).ToHtmlString();
        }

        private static string CreateLink(string LinkText, string routeName, object routeValues)
        {
            TagBuilder tag = new TagBuilder("a");

            UrlHelper urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            string url = urlHelper.RouteUrl(routeName, routeValues);
            string link = "";
            if (qStrings.Count > 0)
            {
                link = "?";
                int counter = 0;
                foreach (var key in qStrings.AllKeys)
                {
                    if (counter != 0)
                    {
                        link += "&";
                    }
                    if (key.Length > 0 && qStrings[key].Length > 0)
                    {
                        link += key + "=" + qStrings[key];
                    }
                    counter++;
                }
            }
            tag.Attributes["href"] = url + link;
            tag.SetInnerText(LinkText);
            return MvcHtmlString.Create(tag.ToString()).ToHtmlString();
        }

        private static NameValueCollection qStrings { get; set; }
        private static HtmlHelper htmlHelper { get; set; }

        /// <summary>
        /// Returns the data pager and paging information
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="currentPage"></param>
        /// <param name="rowsPerPage"></param>
        /// <param name="totalRecords"></param>
        /// <param name="routeName"></param>
        /// <param name="singleObjectName"></param>
        /// <param name="pluralObjectName"></param>
        /// <returns></returns>
        public static MvcHtmlString Pager(this HtmlHelper helper, int currentPage, int rowsPerPage, int totalRecords, string routeName, string singleObjectName, string pluralObjectName)
        {
            var pager = Pager(helper, currentPage, rowsPerPage, totalRecords, routeName);
            var info = WebgridPagingInformation(helper, currentPage, rowsPerPage, totalRecords, singleObjectName, pluralObjectName);
            return MvcHtmlString.Create(pager.ToHtmlString() + info.ToHtmlString());
        }

        /// <summary>
        /// Returns the data pager without any paging information
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="currentPage"></param>
        /// <param name="rowsPerPage"></param>
        /// <param name="totalRecords"></param>
        /// <param name="routeName"></param>
        /// <returns></returns>
        public static MvcHtmlString Pager(this HtmlHelper helper, int currentPage, int rowsPerPage, int totalRecords, string routeName)
        {

            var wrapper = new TagBuilder("div");
            wrapper.AddCssClass("itemPager");

            StringBuilder sb1 = new StringBuilder();
            //url.RouteUrl(routeName, new { page = currentPage })
            //LinkExtensions.RouteLink(helper, "Previous", routeName, new { page = 1 })

            qStrings = HttpContext.Current.Request.QueryString;
            htmlHelper = helper;

            if (!(totalRecords <= rowsPerPage))
            {
                int seed = currentPage % rowsPerPage == 0 ? currentPage : currentPage - (currentPage % rowsPerPage);

                if (currentPage > 0)
                    sb1.AppendLine(CreateLink("Previous",routeName, new { page = currentPage }));

                if (currentPage - rowsPerPage >= 0)
                    sb1.AppendLine(CreateLink("...", routeName,  new { page = (currentPage - rowsPerPage) + 1 }));

                for (int i = seed; i <= Math.Round((totalRecords / rowsPerPage) + 0.5) && i < (seed + rowsPerPage); i++)
                {
                    int itemNumber = i + 1;
                    sb1.AppendLine(CreateLink(itemNumber.ToString(), routeName,  new { page = itemNumber }));
                }

                if (currentPage + rowsPerPage <= (Math.Round((totalRecords / rowsPerPage) + 0.5) - 1))
                    sb1.AppendLine(CreateLink("...", routeName,  new { page = (currentPage + rowsPerPage) + 1 }));

                if (currentPage <= (Math.Round((totalRecords / rowsPerPage) + 0.5) - 1))
                    sb1.AppendLine(CreateLink("Next", routeName,  new { page = currentPage + 2 }));
            }

            wrapper.InnerHtml += sb1.ToString();
            return MvcHtmlString.Create(wrapper.ToString());
        }
    }
}
