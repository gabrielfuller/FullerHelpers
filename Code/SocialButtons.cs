using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FullerHelpers
{
    public static class SocialButtons
    {
        private static string GetFontValue(FacebookLikeFont font)
        {
            if (font == FacebookLikeFont.Arial)
            {
                return "arial";
            }
            else if (font == FacebookLikeFont.LucidaGrande)
            {
                return "lucida grande";
            }
            else if (font == FacebookLikeFont.SegoeUI)
            {
                return "segoe ui";
            }
            else if (font == FacebookLikeFont.Tahoma)
            {
                return "tahoma";
            }
            else if (font == FacebookLikeFont.TrebuchetMS)
            {
                return "trebuchet ms";
            }
            else if (font == FacebookLikeFont.Verdana)
            {
                return "verdana";
            }
            return "";
        }

        public static MvcHtmlString CreateFacebookLikeButton(this HtmlHelper htmlHelper, string href, int width, int height, bool showFaces)
        {
            return CreateFacebookLikeButton(htmlHelper, href, width, height, showFaces, true, FacebookLikeLayout.Standard, FacebookLikeFont.Arial, FacebookLikeColorScheme.Light, FacebookLikeAction.Like);
        }

        public static MvcHtmlString CreateFacebookLikeButton(this HtmlHelper htmlHelper, string href, int width, int height, bool showFaces,bool send,
            FacebookLikeLayout layout, FacebookLikeFont font, FacebookLikeColorScheme colorScheme, FacebookLikeAction action)
        {
            string src = "";
            string widthValue = CalculateWidth(layout, width).ToString();
            string heightValue = CalculateHeight(layout, height).ToString();
            string layoutValue = layout.ToString().ToLower();
            string fontValue = GetFontValue(font);
            string actionValue = action.ToString().ToLower();
            string colorSchemeValue = colorScheme.ToString().ToLower();
            string showFacesValue = showFaces.ToString().ToLower();

            StringBuilder sb = new StringBuilder();
            sb.Append("http://www.facebook.com/plugins/like.php?app_id=225243224169155&href=");
            sb.Append(href + "&");
            if (send == true)
            {
                sb.Append("send=true&");
            }
            else
            {
                sb.Append("send=false&");
            }
            sb.Append("height=" + heightValue + "&");
            sb.Append("width=" + widthValue + "&");
            sb.Append("layout=" + layoutValue + "&");
            sb.Append("show_faces=" + showFacesValue + "&");
            sb.Append("action=" + actionValue + "&");
            sb.Append("colorscheme=" + colorSchemeValue + "&");
            sb.Append("font=" + fontValue);
            src = sb.ToString();

            TagBuilder iframe = new TagBuilder("iframe");
            iframe.Attributes["src"] = src;
            iframe.Attributes["scrolling"] = "no";
            iframe.Attributes["frameborder"] = "0";
            iframe.Attributes["style"] = "border:none; overflow:hidden; width:" + widthValue + "px; height:" + heightValue + "px;";
            iframe.Attributes["allowTransparency"] = "true";

            return MvcHtmlString.Create(iframe.ToString());
        }

        private static int CalculateWidth(FacebookLikeLayout layout, int currentWidth)
        {
            if (layout == FacebookLikeLayout.Standard)
            {
                if (currentWidth < 225)
                    throw new Exception("FacebookLikeButton's width with the " + layout.ToString() + " cannot be " + currentWidth + ".  Please change to 225 or greater.");
            }
            else if (layout == FacebookLikeLayout.Button_Count)
            {
                if (currentWidth < 90)
                    throw new Exception("FacebookLikeButton's width with the " + layout.ToString() + " cannot be " + currentWidth + ".  Please change to 90 or greater.");
            }
            else if (layout == FacebookLikeLayout.Box_Count)
            {
                if (currentWidth < 55)
                    throw new Exception("FacebookLikeButton's width with the " + layout.ToString() + " cannot be " + currentWidth + ".  Please change to 55 or greater.");
            }
            return currentWidth;
        }

        private static int CalculateHeight(FacebookLikeLayout layout, int currentHeight)
        {
            if (layout == FacebookLikeLayout.Standard)
            {
                if (currentHeight < 35)
                    throw new Exception("FacebookLikeButton's height with the " + layout.ToString() + " cannot be " + currentHeight + ".  Please change to 35 or greater.");
            }
            else if (layout == FacebookLikeLayout.Button_Count)
            {
                if (currentHeight != 20)
                    throw new Exception("FacebookLikeButton's height with the " + layout.ToString() + " cannot be " + currentHeight + ".  Please change to 20.");
            }
            else if (layout == FacebookLikeLayout.Box_Count)
            {
                if (currentHeight != 65)
                    throw new Exception("FacebookLikeButton's height with the " + layout.ToString() + " cannot be " + currentHeight + ".  Please change to 65.");
            }
            return currentHeight;
        }


        public static MvcHtmlString TweetThis(this HtmlHelper htmlHelper, string DisplayText, string Url, string TextToTweet, string Via, string languageCode)
        {
            var tag = new TagBuilder("a");
            tag.Attributes["target"] = "_blank";
            string href = "http://twitter.com/share?";
            href += "url=" + HttpUtility.UrlEncode(Url);
            href += "&lang=" + HttpUtility.UrlEncode(languageCode);
            href += "&text=" + HttpUtility.UrlEncode(TextToTweet);
            href += "&via=" + HttpUtility.UrlEncode(Via);
            tag.Attributes["href"] = href;
            tag.InnerHtml = DisplayText;
            return MvcHtmlString.Create(tag.ToString());
        }

        public static MvcHtmlString GooglePlus1(this HtmlHelper htmlHelper,string Url, GooglePlusButtonLayout Layout)
        {
            var tag = new TagBuilder("g:plusone");
            tag.Attributes["href"] = Url;
            return MvcHtmlString.Create(tag.ToString());
        }

    }

    public enum GooglePlusLanguage
    {
        English,
        Spanish
    }

    public enum GooglePlusButtonLayout
    {
        Small,
        Standard,
        Medium,
        Tall
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
