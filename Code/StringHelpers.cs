using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace FullerHelpers
{
    public static class StringHelpers
    {
        public static string ToQueryString(this NameValueCollection nvc)
        {
            return "?" + string.Join("&", Array.ConvertAll(nvc.AllKeys, key => string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(nvc[key]))));
        }

        public static class HtmlSanitizer
        {

            /// <summary>
            /// A regex that matches things that look like a HTML tag after HtmlEncoding to &#DECIMAL; notation. Microsoft AntiXSS 3.0 can be used to preform this. Splits the input so we can get discrete
            /// chunks that start with &#60; and ends with either end of line or &#62;
            /// </summary>
            private static readonly Regex _tags = new Regex(@"&\#60;(?!&\#62;).+?(&\#62;|$)", RegexOptions.Singleline | RegexOptions.ExplicitCapture | RegexOptions.Compiled);


            /// <summary>
            /// A regex that will match tags on the whitelist, so we can run them through 
            /// HttpUtility.HtmlDecode
            /// FIXME - Could be improved, since this might decode &#60; etc in the middle of
            /// an a/link tag (i.e. in the text in between the opening and closing tag)
            /// </summary>

            private static readonly Regex _whitelist = new Regex(@"
                ^&\#60;(&\#47;)? (a|b(lockquote)?|code|em|h(1|2|3)|i|li|ol|p(re)?|s(ub|up|trong|trike)?|ul)&\#62;$
                |^&\#60;(b|h)r\s?(&\#47;)?&\#62;$
                |^&\#60;a(?!&\#62;).+?&\#62;$",
              RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace |
              RegexOptions.ExplicitCapture | RegexOptions.Compiled);

            /// <summary>
            /// HtmlDecode any potentially safe HTML tags from the provided HtmlEncoded HTML input using 
            /// a whitelist based approach, leaving the dangerous tags Encoded HTML tags
            /// </summary>
            public static string Sanitize(string html)
            {
                Match tag;
                MatchCollection tags = _tags.Matches(html);

                // iterate through all HTML tags in the input
                for (int i = tags.Count - 1; i > -1; i--)
                {
                    tag = tags[i];
                    string tagname = tag.Value.ToLowerInvariant();

                    if (_whitelist.IsMatch(tagname))
                    {
                        // If we find a tag on the whitelist, run it through 
                        // HtmlDecode, and re-insert it into the text
                        string safeHtml = HttpUtility.HtmlDecode(tag.Value);
                        html = html.Remove(tag.Index, tag.Length);
                        html = html.Insert(tag.Index, safeHtml);
                    }
                }
                return html;
            }
        }

        public static string GetAppSettingValueString(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
        public static int GetAppSettingValueInt(string key)
        {
            try
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings[key].ToString());
            }
            catch
            {
                return 0;
            }
        }

        public static string GetDomainNameFromEmailAddress(string emailAddress)
        {
            string domainName = emailAddress.Substring(emailAddress.LastIndexOf('@') + 1);
            return domainName;
        }

        public static string[] ConvertMultilineTextToEmails(string textToConvert)
        {
            string[] lines = ConvertMultilineTextToStringArray(textToConvert);
            string emailRegex = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

            ArrayList list = new ArrayList();

            foreach (string s in lines)
            {
                if (Regex.IsMatch(s, emailRegex))
                {
                    string email = s;
                    if (Regex.IsMatch(email, "\r\n"))
                        email = email.Replace("\r\n", "");
                    else if (Regex.IsMatch(s, "\r"))
                        email = email.Replace("\r", "");
                    else if (Regex.IsMatch(email, "\n"))
                        email = email.Replace("\n", "");
                    list.Add(email);
                }
            }
            return (string[])list.ToArray(typeof(string));
        }
        public static string[] ConvertMultilineTextToStringArray(string textToConvert)
        {
            return Regex.Split(textToConvert, @"\n");
        }
        public static string CreateLink(string oldLink)
        {
            string link = oldLink;
            link = link.Trim();
            string[] replace = { " ", "_" };
            foreach (string c in replace)
            {
                link = link.Replace(c, "-");
            }

            char[] remove = {'~','`','!','@','#','$',
            '%','^','&','*','(',')','=','+','[','{',']','}','|','\\',
            ':',';','\'','\"','<',',','>','.','?','/','”','“','.'};
            foreach (char c in remove)
            {
                link = link.Replace(c.ToString(), string.Empty);
            }
            foreach (Match m in Regex.Matches(link, @"[-]{2,999}"))
            {
                link = link.Replace(m.ToString(), "-");
            }
            link = link.Trim(new char[] { '-' });
            link = link.ToLower();
            return link;
        }
        public static string RemoveWhitespaceWithSplit(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            inputString = inputString.Trim();
            string[] parts = inputString.Split(new char[] { ' ', '\n', '\t', '\r', '\f', '\v' }, StringSplitOptions.RemoveEmptyEntries);
            int size = parts.Length;
            for (int i = 0; i < size; i++)
            {
                sb.AppendFormat("{0} ", parts[i]);
            }
            return sb.ToString();
        }
        public static string RemoveAllNonAlphaNumericCharacters(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            inputString = inputString.Trim();
            string[] parts = inputString.Split(new char[] {'~','`','!','@','#','$',
            '%','^','&','*','(',')','_','-','=','+','[','{',']','}','|','\\',
            ':',';','\'','\"','<',',','>','.','?','/','”','“','.'},
                StringSplitOptions.RemoveEmptyEntries);
            int size = parts.Length;
            for (int i = 0; i < size; i++)
            {
                sb.AppendFormat("{0} ", parts[i]);
            }
            return sb.ToString();
        }
        public static string DuplicateFileNameFixer(string location, string fileName, string fileType)
        {
            FileInfo fileInfo = new FileInfo(location + fileName);
            if (fileInfo != null)
            {
                //rename the current file
                fileName = fileName.Replace("." + fileType, "");
                fileName = fileName + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour +
                    DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + "." + fileType;
            }
            return fileName;
        }
        public static string CreateContinuousString(string oldLink)
        {
            string link = oldLink;
            link = link.Trim();
            string[] remove = { " ", "_", "(", ")" };

            foreach (string c in remove)
            {
                link = link.Replace(c, "-");
            }
            return link;
        }
        public static string[] ExtractKeywords(string TextToSearch)
        {
            TextToSearch = TextToSearch.ToLower();
            foreach (string word in OverUsedWords())
            {
                Regex thisWord = new Regex(@"\b(" + word + @")\b");
                MatchCollection matches = thisWord.Matches(thisWord.ToString());
                foreach (Match m in matches)
                {
                    string match = m.ToString();
                    TextToSearch = Regex.Replace(TextToSearch, thisWord.ToString(), string.Empty);
                }
            }
            //find only full words
            Regex words = new Regex(@"\b([a-z]*)\b");
            MatchCollection wordMatches = words.Matches(TextToSearch);
            StringBuilder sb = new StringBuilder();
            foreach (Match m in wordMatches)
            {
                sb.Append(m.Value);
                sb.Append('|');
            }
            string strMatches = sb.ToString();
            char[] toRemove = { '|' };
            return strMatches.Split(toRemove, StringSplitOptions.RemoveEmptyEntries);
        }
        private static string[] OverUsedWords()
        {
            string[] overUsedWords = {   "a", "an", "the", "and", "of", "i", "to", "is", "in", "with", "for", "as", "that", "on", "at", "this", "my", "was", "our", "it", "you", "we", "1", 
                                     "2", "3", "4", "5", "6", "7", "8", "9", "0", "10", "about", "after", "all", "almost", "along", "also", "amp", "another", "any", "are", "area", "around", 
                                     "available", "back", "be", "because", "been", "being", "best", "better", "big", "bit", "both", "but", "by", "c", "came", "can", "capable", "control", 
                                     "could", "course", "d", "dan", "day", "decided", "did", "didn", "different", "div", "do", "doesn", "don", "down", "drive", "e", "each", "easily", "easy", "edition", "end", "enough", "even", "every", 
                                     "example", "few", "find", "first", "found", "from", "get", "go", "going", "good", "got", "gt", "had", "hard", "has", "have", "he", "her", "here", "how", "if", "into", "isn", "just", "know", "last", 
                                     "left", "li", "like", "little", "ll", "long", "look", "lot", "lt", "m", "made", "make", "many", "mb", "me", "menu", "might", "mm", "more", "most", "much", "name", "nbsp", "need", "new", "no", "not", 
                                     "now", "number", "off", "old", "one", "only", "or", "original", "other", "out", "over", "part", 
                                     "place", "point", "pretty", "probably", "problem", "put", "quite", "quot", "r", "re", "really", 
                                     "results", "right", "s", "same", "saw", "see", "set", "several", "she", "sherree", "should", "since", 
                                     "size", "small", "so", "some", "something", "special", "still", "stuff", "such", "sure", "system", "t", "take", "than", "their", "them", "then", "there", 
                                     "these", "they", "thing", "things", "think", "those", "though", "through", "time", "today", "together", "too", 
                                     "took", "two", "up", "us", "use", "used", "using", "ve", "very", "want", "way", "well", "went", "were", "what", "when", "where", "which", "while", "white", "who", "will", "would", "your"};
            return overUsedWords;
        }
        public static string TruncateString(string textString, int WordsToGet, string postTruncateText, bool RemoveTags)
        {
            StringBuilder sb = new StringBuilder();

            if (RemoveTags == true)
            {
                textString = Regex.Replace(textString, @"<(.|\n)*?>", string.Empty);
                string[] wordArray = textString.Split(' ');
                return ExtractData(wordArray, WordsToGet, postTruncateText, sb);
            }
            else
            {
                string[] wordArray = textString.Split(' ');
                return ExtractData(wordArray, WordsToGet, postTruncateText, sb);
            }
        }
        private static string ExtractData(string[] wordArray, int WordsToGet, string postTruncateText, StringBuilder sb)
        {
            for (int x = 0; x < WordsToGet && x < wordArray.Length; x++)
            {
                sb.Append(wordArray[x]);
                if (x == (WordsToGet - 1))
                    sb.Append(postTruncateText);
                sb.Append(" ");
            }
            return sb.ToString().Trim();
        }
        public static string TruncateStringByChars(string textString, int charsToGet, string postTruncateText)
        {
            StringBuilder sb = new StringBuilder();
            int charCount = textString.Length;
            for (int x = 0; x < charsToGet && x < charCount; x++)
            {
                sb.Append(textString[x]);
                if (x == (charsToGet - 1))
                    sb.Append(postTruncateText);
                sb.Append(" ");
            }
            return sb.ToString().Trim();
        }
        public static string RemoveCharsFromString(string inputString, char[] charsToRemove)
        {
            StringBuilder sb = new StringBuilder();
            inputString = inputString.Trim();
            string[] parts = inputString.Split(charsToRemove, StringSplitOptions.RemoveEmptyEntries);
            int size = parts.Length;
            for (int i = 0; i < size; i++)
            {
                sb.AppendFormat("{0}", parts[i]);
            }
            return sb.ToString();
        }
        public static string CreateRandomAlphaNumericSequence(int PasswordLength)
        {
            String _allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ1234567890";
            Byte[] randomBytes = new Byte[PasswordLength];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;

            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)randomBytes[i] % allowedCharCount];
            }

            return new string(chars);
        }
        public static class ConversionHelpers
        {
            public static decimal ConvertStringToDecimal(string str)
            {
                str = RemoveCharsFromString(str, new char[] { '$', ',', ' ', '%' });
                try
                {
                    return Convert.ToDecimal(str);
                }
                catch
                {
                    return 0;
                }
            }

            public static int ConvertStringToInt(string str)
            {
                try
                {
                    return Convert.ToInt32(str);
                }
                catch
                {
                    return 0;
                }
            }

            public static string ExtractPhoneNumber(string oldPhone)
            {
                char[] charsToRemove = new char[] { '(', ')', ' ', '-' };
                return RemoveCharsFromString(oldPhone, charsToRemove);
            }

            public static decimal GetDecimalFromPercentageString(string text)
            {
                char[] charsToRemove = new char[] { '%' };
                return Convert.ToDecimal(RemoveCharsFromString(text, charsToRemove));
            }
        }
    }
}