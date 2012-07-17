using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Jade.Model;

namespace Jade
{
    public interface IFetcher
    {
        string Fetch(string fetchStuff);
        string Fetch(string fetchStuff, bool repeat);
    }

    public static class BaseConfig
    {
        public const string UrlSeparator = "@@";
        public const string UrlTrimItemSeparator = "$$";
    }

    public class FetchItem : IFetcher
    {
        public string ItemName;
        public string StartTag;
        public string EndTag;
        public bool IsUseRegex;
        public string RegexText;
        public bool TrimHtml = false;
        public List<HtmlTagType> HtmlTagCleanerList;
        public bool IsIdentifyPage = false;
        public string PageStart;
        public string PageEnd;
        public string ReplaceString;

        private List<HtmlTagType> BuildHtmlTagCleanerList(string htmlTrim)
        {
            if (string.IsNullOrEmpty(htmlTrim)) return null;
            List<HtmlTagType> list;

            list = HtmlTagCaching.Get(htmlTrim);

            if (list != null) return list;

            string[] trims = htmlTrim.Split(new string[] { BaseConfig.UrlTrimItemSeparator }, StringSplitOptions.RemoveEmptyEntries);
            if (trims == null || trims.Length == 0) return null;

            list = new List<HtmlTagType>(trims.Length);
            foreach (string item in trims)
            {
                HtmlTagType tagType = 0;
                if (HtmlTagTypeCreater.TryCreate(int.Parse(item), ref tagType))
                {
                    list.Add(tagType);
                }
            }

            HtmlTagCaching.Add(htmlTrim, list);

            return list;
        }

        public ItemRule CurrentItemRule { get; set; }


        public FetchItem(ItemRule rule)
        {
            CurrentItemRule = rule;
            this.ItemName = rule.ItemName;
            this.StartTag = rule.StartTarget;
            this.EndTag = rule.EndTarget;
            this.RegexText = rule.RegexText;
            // this.HtmlTagCleanerList = BuildHtmlTagCleanerList(rule.HtmlTrim);
            this.TrimHtml = rule.IsExtractText;
            this.IsIdentifyPage = rule.IdentifyPage;
            this.PageStart = rule.PageStart;
            this.PageEnd = rule.PageEnd;
            this.ReplaceString = rule.ReplaceString;

            if (this.StartTag != null)
            {
                this.startTags = this.StartTag.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
            }

            if (this.endTags != null)
            {
                this.endTags = this.EndTag.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public FetchItem(string itemName, string startTag, string endTag, bool isUseRegex, string regexText, bool trim, bool identifyPage, string pageStart, string pageEnd, List<HtmlTagType> htmlTagCleanerList, string replaceString)
        {
            this.ItemName = itemName;
            this.StartTag = startTag;
            this.EndTag = endTag;
            this.IsUseRegex = isUseRegex;
            this.RegexText = regexText;
            this.HtmlTagCleanerList = htmlTagCleanerList;
            this.TrimHtml = trim;
            this.IsIdentifyPage = identifyPage;
            this.PageStart = pageStart;
            this.PageEnd = pageEnd;
            this.ReplaceString = replaceString;
            this.startTags = this.StartTag.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
            this.endTags = this.EndTag.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
        }

        public FetchItem(string itemName, string startTag, string endTag, bool isUseRegex, string regexText, bool trim, bool identifyPage, string pageStart, string pageEnd, List<HtmlTagType> htmlTagCleanerList)
        {
            this.ItemName = itemName;
            this.StartTag = startTag;
            this.EndTag = endTag;
            this.IsUseRegex = isUseRegex;
            this.RegexText = regexText;
            this.HtmlTagCleanerList = htmlTagCleanerList;
            this.TrimHtml = trim;
            this.IsIdentifyPage = identifyPage;
            this.PageStart = pageStart;
            this.PageEnd = pageEnd;
            this.startTags = this.StartTag.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
            this.endTags = this.EndTag.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
        }

        public FetchItem(string itemName, string startTag, string endTag, bool isUseRegex, string regexText, bool trim, List<HtmlTagType> htmlTagCleanerList)
        {
            this.ItemName = itemName;
            this.StartTag = startTag;
            this.EndTag = endTag;
            this.IsUseRegex = isUseRegex;
            this.RegexText = regexText;
            this.HtmlTagCleanerList = htmlTagCleanerList;
            this.TrimHtml = trim;
            this.startTags = this.StartTag.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
            this.endTags = this.EndTag.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
        }

        public FetchItem(string itemName, string startTag, string endTag, bool isUseRegex, string regexText, List<HtmlTagType> htmlTagCleanerList)
        {
            this.ItemName = itemName;
            this.StartTag = startTag;
            this.EndTag = endTag;
            this.IsUseRegex = isUseRegex;
            this.RegexText = regexText;
            this.HtmlTagCleanerList = htmlTagCleanerList;
            this.startTags = this.StartTag.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
            this.endTags = this.EndTag.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
        }

        string[] startTags = null;
        string[] endTags = null;

        public string HtmToTxt(string input)
        {
            input = new Regex(@"(?m)<script[^>]*>(\w|\W)*?</script[^>]*>", RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(input, "");
            input = new Regex(@"(?m)<style[^>]*>(\w|\W)*?</style[^>]*>", RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(input, "");
            input = new Regex(@"(?m)<select[^>]*>(\w|\W)*?</select[^>]*>", RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(input, "");
            //input = new Regex(@"(?m)<a[^>]*>(\w|\W)*?</a[^>]*>", RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(input, "");
            Regex objReg = new System.Text.RegularExpressions.Regex("(<[^>]+?>)| ", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            input = objReg.Replace(input, "");
            Regex objReg2 = new System.Text.RegularExpressions.Regex("(\\s)+", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            input = objReg2.Replace(input, " ");
            return input.Replace("&nbsp;", " ");
        }

        List<string> alreadyLoadedpages = new List<string>();

        public string Fetch(string fetchStuff)
        {

            if (CurrentItemRule != null)
            {
                switch (CurrentItemRule.FetchType)
                {
                    case ItemFetchType.XPath:
                        var xpathResult = ExtractUrl.ExtractDataFromHtml(fetchStuff, CurrentItemRule.XPath, CurrentItemRule.XMLPathSelectType, CurrentItemRule.XMLPathType);
                        return string.Join("", xpathResult.ToArray());
                    case ItemFetchType.UserDiy:
                        if (CurrentItemRule.DiyType == UserDiyType.Datetime)
                        {
                            return DateTime.Now.ToString(CurrentItemRule.DateTimeFormatString);
                        }
                        else
                        {
                            return CurrentItemRule.DefaultValue;
                        }
                    case ItemFetchType.FromRegex:
                        var regex = new Regex(CurrentItemRule.RegexText, RegexOptions.Multiline | RegexOptions.IgnoreCase);
                        var matches = regex.Matches(fetchStuff);

                        var regexResult = "";
                        if (matches.Count > 0)
                        {
                            foreach (Match m in matches)
                            {
                                regexResult += m.Groups["content"].Value;
                            }
                        }
                        return regexResult;
                }

            }

            if (string.IsNullOrEmpty(fetchStuff))
            {
                return string.Empty;
            }

            string result = SubString(fetchStuff, this.StartTag.Replace("\r\n", ""), this.EndTag.Replace("\r\n", ""));

            if (string.IsNullOrEmpty(result))
            {
                return result;
            }

            if (!string.IsNullOrEmpty(this.ReplaceString))
            {
                var replaces = this.ReplaceString.Split(new string[] { "@@@" }, StringSplitOptions.None);
                foreach (var replace in replaces)
                {
                    var rules = replace.Split(new string[] { "==>" }, 2, StringSplitOptions.None);
                    if (rules.Length == 2)
                    {
                        result = result.Replace(rules[0], rules[1]);
                    }
                }
            }

            if (this.TrimHtml)
            {
                result = this.HtmToTxt(result);
            }

            if (this.HtmlTagCleanerList != null)
            {
                HtmlCleanerGenerator generator = new HtmlCleanerGenerator();
                foreach (HtmlTagType htmlTag in this.HtmlTagCleanerList)
                {
                    IHtmlTagCleaner cleaner = generator.GenerateCleaner(htmlTag);
                    if (cleaner != null)
                    {
                        result = cleaner.CleanHtmlTag(result);
                    }
                }
            }

            return result;
        }


        int GetStartIndex(string fetchStuff, out int index)
        {
            var startIndex = -1;
            index = 0;
            if (startTags != null)
            {
                var i = 0;
                foreach (var start in startTags)
                {
                    startIndex = fetchStuff.IndexOf(start);
                    if (startIndex > -1)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
            }
            return startIndex;
        }

        int GetEndIndex(int startIndex, string fetchStuff, out int index)
        {
            var endIndex = -1;
            fetchStuff = fetchStuff.Substring(startIndex);
            index = 0;
            if (startTags != null)
            {
                var i = 0;
                foreach (var start in endTags)
                {
                    endIndex = fetchStuff.IndexOf(start);
                    if (endIndex > -1)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
            }
            return endIndex + startIndex;
        }


        private string SubString(string fetchStuff, string startTag, string endTag)
        {
            string result;

            if (this.IsUseRegex)
            {
                Regex regex = new Regex(RegexText);
                if (!regex.IsMatch(fetchStuff))
                    result = string.Empty;
                else
                    result = regex.Match(fetchStuff).Value;
            }
            else
            {
                int startIndex, endIndex;

                var sindex = 0;
                var eindex = 0;

                startIndex = this.GetStartIndex(fetchStuff, out sindex);

                if (startIndex == -1)
                    return string.Empty;

                endIndex = this.GetEndIndex(startIndex, fetchStuff, out eindex);

                if (endIndex == -1)
                {
                    return string.Empty;
                    //result = fetchStuff.Substring(startIndex + startTag.Length);
                }
                else if (endIndex < startIndex)
                {
                    result = string.Empty;
                }
                else
                {
                    result = fetchStuff.Substring(startIndex + startTags[sindex].Length, endIndex - startIndex - startTags[sindex].Length);
                }
            }
            return result;
        }


        public string Fetch(string fetchStuff, bool repeat)
        {
            StringBuilder txt = new StringBuilder();
            string newresult = null;
            while (!string.IsNullOrEmpty((newresult = this.Fetch(fetchStuff))))
            {
                txt.AppendLine(newresult);
                var outIndex = 0;
                var startIndex = this.GetStartIndex(fetchStuff, out outIndex);
                if (startIndex == 0)
                {
                    break;
                }
                var endIndex = this.GetEndIndex(startIndex, fetchStuff, out outIndex);
                if (endIndex == -1)
                {
                    break;
                }
                fetchStuff = fetchStuff.Substring(endIndex + endTags[outIndex].Length);
            }
            return txt.ToString();

            //string newresult = "";
            //var endTag = this.EndTag.Replace("\r\n", "");

            //var start = fetchStuff.IndexOf(this.StartTag);

            //if (start > -1)
            //{
            //    fetchStuff = fetchStuff.Substring(start);

            //    var lastIndex = fetchStuff.IndexOf(endTag);

            //    if (lastIndex != -1)
            //    {
            //        fetchStuff = fetchStuff.Substring(lastIndex + endTag.Length);

            //        while (!string.IsNullOrEmpty((newresult = this.Fetch(fetchStuff))))
            //        {
            //            result += newresult;
            //            start = fetchStuff.IndexOf(this.StartTag);
            //            if (start > -1)
            //            {
            //                fetchStuff = fetchStuff.Substring(start);
            //                lastIndex = fetchStuff.IndexOf(endTag);
            //                if (lastIndex != -1)
            //                {
            //                    fetchStuff = fetchStuff.Substring(lastIndex + endTag.Length);
            //                    var startIndex = fetchStuff.IndexOf(this.StartTag);
            //                    if (startIndex == -1)
            //                    {
            //                        break;
            //                    }
            //                }
            //                else
            //                {
            //                    break;
            //                }
            //            }
            //            else
            //            {
            //                break;
            //            }
            //        }
            //    }
            //}
            //return result;
        }
    }
}
