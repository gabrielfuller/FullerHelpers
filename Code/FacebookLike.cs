using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;

namespace FullerHelpers
{
    public static class FacebookLike
    {
        public static MvcHtmlString GetHtml(this HtmlHelper htmlHelper, string href, int width, int height, bool showFaces, FacebookLikeLayout layout, FacebookLikeFont font, FacebookLikeColorScheme colorScheme, FacebookLikeAction action)
        {
            /*
             <iframe 
             * src="http://www.facebook.com/plugins/like.php?app_id=225243224169155&amp;
             *      href=http%3A%2F%2Fwww.yahoo.com&amp;
             *      send=false&amp;
             *      layout=standard&amp;
             *      width=450&amp;
             *      show_faces=true&amp;
             *      action=like&amp;
             *      colorscheme=light&amp;
             *      font=arial&amp;
             *      height=80" 
            *      scrolling="no" 
            *      frameborder="0" 
            *      style="border:none; overflow:hidden; width:450px; height:80px;" 
            *      allowTransparency="true">
             </iframe>*/
            StringBuilder src = new StringBuilder();
            src.Append("http://www.facebook.com/plugins/like.php?app_id=225243224169155&amp;href=");
            src.Append(HttpUtility.UrlEncode(href) + "&amp;");
            src.Append("send=false&amp;");
            src.Append("layout=" + layout.ToString().ToLower() + "&amp;");
            src.Append("show_faces=" + showFaces.ToString().ToLower() + "&amp;");
            src.Append("action=" + action.ToString().ToLower() + "&amp;");
            src.Append("colorscheme=" + colorScheme.ToString().ToLower() + "&amp;");
            src.Append("font=" + font.ToString().ToLower() + "&amp;");
            src.Append("height=" + height.ToString().ToLower());

            TagBuilder iframe = new TagBuilder("iframe");
            iframe.Attributes["src"] = src.ToString();
            iframe.Attributes["scrolling"] = "no";
            iframe.Attributes["frameborder"] = "0";
            iframe.Attributes["style"] = "border:none; overflow:hidden; width:450px; height:80px;";
            iframe.Attributes["allowTransparency"] = "true";

            return MvcHtmlString.Create(iframe.ToString());
        }


        public enum FacebookLikeLayout
        {
            Standard,
            Button_Count,
            Box_Count
        }

        public enum FacebookLikeAction
        {
            Like,
            Recommend
        }

        public enum FacebookLikeFont
        {
            Arial,
            LucidaGrande,
            SegoeUI,
            Tahoma,
            TrebuchetMS,
            Verdana
        }

        public enum FacebookLikeColorScheme
        {
            Light,
            Dark
        }
    }
}
