using System.Globalization;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace Jade.CQA.Robot.Extensions
{
    public static class StringExtensions
    {
        #region Class Methods

        public static string FormatWith(this string source, params object[] parameters)
        {
            return string.Format(CultureInfo.InvariantCulture, source, parameters);
        }

        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        public static string Substring(this string source, string startTag, string endTag)
        {
            return string.Join(" ", SubstringAll(source, startTag, endTag).ToArray());
        }
        public static string HtmToTxt(this string input)
        {
            input = new Regex(@"(?m)<script[^>]*>(\w|\W)*?</script[^>]*>", RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(input, "");
            input = new Regex(@"(?m)<style[^>]*>(\w|\W)*?</style[^>]*>", RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(input, "");
            input = new Regex(@"(?m)<select[^>]*>(\w|\W)*?</select[^>]*>", RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(input, "");
            //input = new Regex(@"(?m)<a[^>]*>(\w|\W)*?</a[^>]*>", RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(input, "");
            Regex objReg = new System.Text.RegularExpressions.Regex("(<[^>]+?>)|", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            input = objReg.Replace(input, "");
            //Regex objReg2 = new System.Text.RegularExpressions.Regex("(\\s)+", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            //input = objReg2.Replace(input, " ");
            return input.Replace("&nbsp;", " ");
        }
        public static List<string> SubstringAll(this string source, string startTag, string endTag)
        {
            string key = Regex.Escape(startTag);
            string value = Regex.Escape(endTag);
            string pattern = "({0})(.*?)({1})".FormatWith(key, value);
            var matchResult = new Regex(pattern).Matches(source);
            var result = new List<string>();

            if (matchResult.Count > 0)
            {
                foreach (Match match in matchResult)
                {
                    result.Add(match.Groups[2].Value);
                }
            }
            return result;
        }
        #endregion
    }
}