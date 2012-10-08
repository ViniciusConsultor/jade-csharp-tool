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

            if (this.EndTag != null)
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

            var result = "";

            if (CurrentItemRule != null)
            {
                switch (CurrentItemRule.FetchType)
                {
                    case ItemFetchType.XPath:
                        var xpathResult = ExtractUrl.ExtractDataFromHtml(fetchStuff, CurrentItemRule.XPath, CurrentItemRule.XMLPathSelectType, CurrentItemRule.XMLPathType);
                        result = string.Join(" ", xpathResult.ToArray());
                        break;
                    case ItemFetchType.UserDiy:
                        if (CurrentItemRule.DiyType == UserDiyType.Datetime)
                        {
                            result = DateTime.Now.ToString(CurrentItemRule.DateTimeFormatString);
                        }
                        else
                        {
                            result = CurrentItemRule.DefaultValue;
                        }
                        break;
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
                        result = regexResult;
                        break;
                }

            }

            if (CurrentItemRule.FetchType == ItemFetchType.FromHTML)
            {
                result = SubString(fetchStuff, this.StartTag.Replace("\r\n", ""), this.EndTag.Replace("\r\n", ""));

                if (string.IsNullOrEmpty(result))
                {
                    return result;
                }
                //if (this.TrimHtml)
                //{
                if (CurrentItemRule.ItemName == "ÄÚÈÝ")
                {
                    result =ExtractUrl.NoHTML(result);
                }
                //}

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
            }

            if (!string.IsNullOrEmpty(result))
            {
                if (!string.IsNullOrEmpty(this.ReplaceString))
                {
                    var replaces = this.ReplaceString.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                    foreach (var replace in replaces)
                    {
                        if (replace != "")
                            result = result.Replace(replace, string.Empty);
                    }
                }
            }

            return result;
        }


        int GetStartIndex(string fetchStuff, out int endIndex)
        {
            var startIndex = -1;
            endIndex = -1;
            if (startTags != null)
            {
                var i = 0;
                foreach (var start in startTags)
                {
                    startIndex = fetchStuff.IndexOf(start);
                    if (startIndex > -1)
                    {
                        endIndex = fetchStuff.IndexOf(start, startIndex + start.Length);
                        break;
                    }
                }
            }
            return startIndex;
        }

        int GetEndIndex(int startIndex, string fetchStuff, out int index)
        {
            var endIndex = -1;
            index = 0;
            if (startTags != null)
            {
                var i = 0;
                foreach (var start in endTags)
                {
                    endIndex = fetchStuff.IndexOf(start, startIndex);
                    if (endIndex > -1)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
            }
            return endIndex;
        }


        private string SubString(string fetchStuff, string startTag, string endTag)
        {
            string result = "";

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
                bool isEnd = false;

                startIndex = -1;
                endIndex = -1;

                var lastIndex = 0;
                while (!isEnd)
                {
                    string start = "";
                    string end = "";
                    if (startTags != null)
                    {
                        foreach (var tag in startTags)
                        {
                            startIndex = fetchStuff.IndexOf(tag, lastIndex);
                            if (startIndex > -1)
                            {
                                start = tag;
                                lastIndex = startIndex + start.Length;
                                break;
                            }
                        }
                    }

                    //  endIndex = fetchStuff.IndexOf(start, startIndex + start.Length);

                    //startIndex = this.GetStartIndex(fetchStuff, out endIndex);

                    if (startIndex == -1)
                        isEnd = true;
                    else
                    {
                        if (endTags != null)
                        {
                            foreach (var tag in endTags)
                            {
                                endIndex = fetchStuff.IndexOf(tag, lastIndex);
                                if (endIndex > -1)
                                {
                                    end = tag;
                                    lastIndex = endIndex + end.Length;
                                    break;
                                }
                            }
                        }

                        //endIndex = this.GetEndIndex(startIndex, fetchStuff, out eindex);

                        if (endIndex == -1)
                        {
                            isEnd = true;
                            //result = fetchStuff.Substring(startIndex + startTag.Length);
                        }
                        else if (endIndex < startIndex)
                        {
                            isEnd = true;
                        }
                        else
                        {
                            result += fetchStuff.Substring(startIndex + start.Length, endIndex - startIndex - start.Length) + " ";
                        }
                    }
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
