using System.Text.RegularExpressions;

namespace FullerHelpers
{
    public class RegexConstants
    {
        public static Regex Email = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", RegexOptions.CultureInvariant);
        public static Regex CreditCard = new Regex(@"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$");
        //public static Regex USCurrency = new Regex(@"^\(\d{1,3}(\,\d{3})*|(\d+))(\.\d{2})?");
        //public static Regex Percentage = new Regex(@"^(0*100{1,1}\.?((?<=\.)0*))|(^0*\d{0,2}\.?((?<=\.)\d*)?%?)");


        /// <summary>
        /// Password must be at least 8 characters in length and have one Uppercase letter
        /// </summary>
        public static Regex Password = new Regex(@"^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*s).*$");


        /// <summary>
        /// Username must be 8-30 alhpa-numeric characters in length, 
        /// and start with a letter. It can have dashes, underscores and periods
        /// but only if followed by at least 2 alhpa-numeric characters.
        /// </summary>
        public static Regex Username = new Regex(@"^(?=.{8,30}$)[A-Za-z]{1,}[._-]?[A-Za-z0-9]{2,}$");
    }
}