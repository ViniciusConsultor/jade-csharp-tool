using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HFBBS.Model;

namespace HFBBS
{
    public class ExtractUrl
    {
        public static List<string> ParseUrlFromParameter(string originalUrl)
        {
            List<string> urls;

            int firstSymbo = originalUrl.IndexOf("<");
            int lastSymbo = originalUrl.IndexOf(">", firstSymbo == -1 ? 0 : firstSymbo);

            if (lastSymbo > firstSymbo && firstSymbo > -1)
            {
                string[] parameters = originalUrl.Substring(firstSymbo + 1, lastSymbo - firstSymbo - 1).Split(',');
                decimal startValue = Convert.ToDecimal(parameters[0]);
                decimal endValue = Convert.ToDecimal(parameters[1]);
                decimal increment = Convert.ToDecimal(parameters[2]);
                bool addZero = Convert.ToBoolean(parameters[3]);
                bool isDesc = Convert.ToBoolean(parameters[4]);
                string urlSymbolicHolder = "[*]";
                string symbolicUrl = originalUrl.Replace(originalUrl.Substring(firstSymbo, lastSymbo - firstSymbo + 1), urlSymbolicHolder);
                urls = ParseUrlFromParameter(
                                symbolicUrl,
                                urlSymbolicHolder,
                                startValue,
                                endValue,
                                increment,
                                addZero,
                                isDesc);
            }
            else
            {
                urls = new List<string>();
                urls.Add(originalUrl);
            }
            return urls;
        }

        public static List<string> ParseUrlFromParameter(string symbolicUrl, string urlSymbolicHolder, decimal startValue, decimal endValue, decimal increment, bool addZero, bool isDesc)
        {
            List<string> urls = new List<string>();

            decimal current;
            string symbolicValue = string.Empty;

            if (!isDesc)
            {
                for (current = startValue; current <= endValue; current += increment)
                {
                    if (addZero)
                    {
                        int length = Convert.ToInt32(endValue).ToString().Length - Convert.ToInt32(current).ToString().Length;
                        for (int i = 0; i < length; i++)
                        {
                            symbolicValue += "0";
                        }
                    }
                    symbolicValue += current.ToString();
                    urls.Add(symbolicUrl.Replace(urlSymbolicHolder, symbolicValue));
                    symbolicValue = string.Empty;
                }
            }
            else
            {
                for (current = endValue; current >= startValue; current -= increment)
                {
                    if (addZero)
                    {
                        int length = Convert.ToInt32(endValue).ToString().Length - Convert.ToInt32(current).ToString().Length;
                        for (int i = 0; i < length; i++)
                        {
                            symbolicValue += "0";
                        }
                    }
                    symbolicValue += current.ToString();
                    urls.Add(symbolicUrl.Replace(urlSymbolicHolder, symbolicValue));
                    symbolicValue = string.Empty;
                }
            }
            return urls;
        }

        public static List<string> ExtractAccurateUrl(
            string sourceUrl, string html,
            string fetchStartSymbolic, string fetchEndSymbolic,
            string urlInclude,
            string urlExclude, string endTrim,
            List<string> urlTrims
            )
        {
            html = ExtractHtml(html, fetchStartSymbolic, fetchEndSymbolic);

            List<string> urls = UrlPicker.GetHtmlLinks(html);

            RepairUrls(sourceUrl, urlInclude, urlExclude, urls);

            return urls;
        }

        public static void RepairUrls(string sourceUrl, string urlInclude, string urlExclude, List<string> urls)
        {

            int count = urls.Count;
            bool checkUrlInclude = !string.IsNullOrEmpty(urlInclude);
            bool checkUrlExclude = !string.IsNullOrEmpty(urlExclude);

            Regex includeRegex = null;

            if (urlInclude != null && urlInclude.Contains("(*)"))
            {
                includeRegex = new Regex(urlInclude.Replace(".", "\\.").Replace("(*)", "(.*)"));
            }

            if (urlExclude == null)
                urlExclude = string.Empty;

            var urlExcludes = urlExclude.Split(',');

            for (int i = 0; i < count; i++)
            {
                if (string.IsNullOrEmpty(urls[i]))
                    continue;

                urls[i] = RepairUrl(sourceUrl, urls[i]);

                #region MyRegion

                if (checkUrlInclude || checkUrlExclude)
                {
                    bool remove = false;
                    if (checkUrlInclude && checkUrlExclude)
                    {
                        remove = includeRegex == null ? (urls[i].IndexOf(urlInclude) == -1) : includeRegex.Match(urls[i]).Length == 0;
                        if (!remove)
                        {
                            foreach (var urlexlude in urlExcludes)
                            {
                                remove = urls[i].IndexOf(urlexlude) > -1;
                                if (remove)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else if (checkUrlInclude)
                    {
                        //  必须包含
                        remove = includeRegex == null ? (urls[i].IndexOf(urlInclude) == -1) : includeRegex.Match(urls[i]).Length == 0;

                    }
                    else if (checkUrlExclude)
                    {
                        foreach (var urlexlude in urlExcludes)
                        {
                            remove = urls[i].IndexOf(urlexlude) != -1;
                            if (remove)
                            {
                                break;
                            }
                        }
                    }

                    if (remove)
                    {
                        urls.RemoveAt(i);
                        i--;
                        count--;
                    }
                }
                #endregion
            }
        }

        private static string ExtractHtml(string html, string fetchStartSymbolic, string fetchEndSymbolic)
        {
            int startIndex = -1;
            int endIndex = -1;

            if (!string.IsNullOrEmpty(fetchStartSymbolic))
            {
                startIndex = html.IndexOf(fetchStartSymbolic);
            }
            if (!string.IsNullOrEmpty(fetchEndSymbolic))
            {
                endIndex = html.IndexOf(fetchEndSymbolic, startIndex == -1 ? 0 : startIndex);
            }

            if (endIndex > startIndex && startIndex > -1)
            {
                //Start And End
                html = html.Substring(startIndex, endIndex - startIndex + 1);
            }
            else if (endIndex > startIndex && startIndex == -1)
            {
                //Just End.
                html = html.Substring(0, endIndex + 1);
            }
            else if (endIndex == -1 && startIndex > -1)
            {
                //Just Start
                html = html.Substring(startIndex);
            }
            return html;
        }



        public static List<string> GetLinks(HtmlAgilityPack.HtmlNode node)
        {
            var links = node.SelectNodes("//a");
            return links.Where(l => l.Attributes["href"] != null).Select(l => l.Attributes["href"].Value.ToString()).ToList();
        }

        private static string html2TextPattern =
@"(?<script><script[^>]*?>.*?</script>)|(?<style><style>.*?</style>)|(?<comment><!--.*?-->)" +
@"|(?<html>(?!<ps|(<p>)|(<img)|(<br)|(strong))" +   //保留的html标记前缀,<a>,<p>,<img><br><STRONG>
   @"<[^>]+>)" + // HTML标记
@"|(?<quot>&(quot|#34);)" + // 符号: "
@"|(?<amp>&(amp|#38);)" + // 符号: &
@"|(?<end>(?!(</strong)|(</p>))</[^>]+>)" +        //HTML闭合标签 保留</A>,</STRONG>,</P>
@"|(?<iexcl>&(iexcl|#161);)" + // 符号: (char)161
@"|(?<cent>&(cent|#162);)" + // 符号: (char)162
@"|(?<pound>&(pound|#163);)" + // 符号: (char)163
@"|(?<copy>&(copy|#169);)" + // 符号: (char)169
@"|(?<others>&(d+);)"; // 符号: 其他

        public static string NoHTML(string Htmlstring) //去除HTML标记  
        {
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled;
            //删除脚本  
            Htmlstring = Regex.Replace(Htmlstring, html2TextPattern, "", options);

            if (!Htmlstring.ToLower().Contains("<p>"))
            {
                Htmlstring = "<P>" + Htmlstring + "</P>";
            }

            return Htmlstring;
        }


        public static List<string> ExtractAccurateUrl(SiteRule siteRule, string html, string sourceUrl)
        {

            var result = ExtractDataFromHtml(html, siteRule.ListXPath, siteRule.ListXMLPathSelectType, siteRule.ListXMLPathType);
            RepairUrls(sourceUrl, siteRule.IncludePart, siteRule.ExcludePart, result);
            return result;
        }



        /// <summary>
        /// 使用xpath从html提取内容
        /// </summary>
        /// <param name="html"></param>
        /// <param name="xpath"></param>
        /// <param name="selectType"></param>
        /// <param name="pathType"></param>
        /// <returns></returns>
        public static List<string> ExtractDataFromHtml(string html, string xpath, XMLPathSelectType selectType, XMLPathType pathType)
        {

            var result = new List<string>();
            if (xpath == "")
            {
                return result;
            }

            try
            {
                HtmlAgilityPack.HtmlDocument HtmlDoc = new HtmlAgilityPack.HtmlDocument();
                //html = html.ToLower();
                if (!html.Contains("</BODY") && !html.Contains("</body"))
                {
                    html += "</body>";
                }
                html = html.Replace("<tbody>", "").Replace("</tbody>", "").Replace("<TBODY>", "").Replace("</TBODY>", "");
                xpath = xpath.Replace("/tbody[1]", "");
                var body = new Regex("<body[^>]*>[\\s\\S]+</body>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                html = body.Match(html).Value;
                HtmlDoc.LoadHtml(html);
                var nodes = HtmlDoc.DocumentNode.SelectNodes(xpath);
                if (nodes != null)
                {
                    if (selectType == XMLPathSelectType.Multiple)
                    {
                        foreach (HtmlAgilityPack.HtmlNode node in nodes)
                        {
                            switch (pathType)
                            {
                                case XMLPathType.Href:
                                    result.Add(node.Attributes["href"].Value.ToString());
                                    break;
                                case XMLPathType.InnerHtml:
                                    result.Add(node.InnerHtml);
                                    break;
                                case XMLPathType.InnerText:
                                    result.Add(node.InnerText);
                                    break;
                                case XMLPathType.InnerLinks:
                                    result.AddRange(GetLinks(node));
                                    break;
                                case XMLPathType.InnerTextWithPic:
                                    result.Add(NoHTML(node.InnerHtml));
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (nodes.Count > 0)
                        {
                            var node = nodes[0];
                            switch (pathType)
                            {
                                case XMLPathType.Href:
                                    if (node.Attributes["href"] != null)
                                        result.Add(node.Attributes["href"].Value.ToString());
                                    break;
                                case XMLPathType.InnerHtml:
                                    result.Add(node.InnerHtml);
                                    break;
                                case XMLPathType.InnerText:
                                    result.Add(node.InnerText);
                                    break;
                                case XMLPathType.InnerLinks:
                                    result.AddRange(GetLinks(node));
                                    break;
                                case XMLPathType.InnerTextWithPic:
                                    result.Add(NoHTML(node.InnerHtml));
                                    break;
                            }
                        }

                    }
                }
            }
            catch
            {
            }
            return result;
        }

        public static List<string> ExtractAccurateRssUrl(List<string> urls, string urlInclude, string urlExclude)
        {
            bool checkUrlInclude = !string.IsNullOrEmpty(urlInclude);
            bool checkUrlExclude = !string.IsNullOrEmpty(urlExclude);
            int count = urls.Count;

            if (checkUrlInclude || checkUrlExclude)
            {
                for (int i = 0; i < count; i++)
                {
                    bool matched = false;
                    if (checkUrlInclude)
                    {
                        if (urls[i].IndexOf(urlInclude) == -1)
                            matched = true;
                        else if (urls.IndexOf(urlExclude) != -1)
                            matched = true;
                    }
                    if (matched)
                    {
                        urls.RemoveAt(i);
                        i--;
                        count--;
                    }
                }
            }
            return urls;
        }

        public static string RepairUrl(string baseUrl, string originalUrl)
        {
            try
            {
                Uri originalUri;
                Uri baseUri = new Uri(baseUrl);
                Uri resultUri;

                if (Uri.TryCreate(baseUri, originalUrl, out resultUri))
                {
                    return resultUri.OriginalString;
                }

                if (Uri.TryCreate(originalUrl, UriKind.RelativeOrAbsolute, out originalUri))
                {
                    if (originalUri.Scheme != "about")
                    {
                        return originalUrl;
                    }
                }



                string ieBlank = "about:blank";
                string threeSplit = "///";

                if (originalUrl.StartsWith(ieBlank))
                {
                    originalUrl = originalUrl.Remove(0, ieBlank.Length);
                }
                if (originalUrl.IndexOf(threeSplit) > -1)
                {
                    originalUrl = originalUrl.Remove(0, originalUrl.IndexOf(threeSplit) + 2);
                }

                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}