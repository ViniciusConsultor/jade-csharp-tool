using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Jade.Model;
using Sgml;
using System.IO;
using System.Xml;

namespace Jade
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
            var links = node.SelectNodes(".//a[@href]");
            return links.Select(l => l.Attributes["href"].Value.ToString()).ToList();
        }


        /// <summary>
        /// 从html获取链接
        /// </summary>
        /// <param name="html"></param>
        /// <param name="containText">链接文本包含的</param>
        /// <returns></returns>
        public static List<HtmlAgilityPack.HtmlNode> GetLinkNodes(string html, params string[] texts)
        {
            HtmlAgilityPack.HtmlDocument HtmlDoc = new HtmlAgilityPack.HtmlDocument();
            HtmlDoc.LoadHtml(html);
            var links = HtmlDoc.DocumentNode.SelectNodes("//a[@href]");
            return links.Where(l => l.InnerText != null && texts.Contains(l.InnerText)).ToList();
        }

        //(?<script><script[^>]*?>.*?</script>)|(?<style><style[^>]*>.*?</style>)|(?<comment><!--.*?-->)

        //(?<script><script[^>]*?>.*?</script>)|(?<style><style[^>]*>.*?</style>)|(?<comment><!--.*?-->)(?<html>(?!<ps|(<[/]?p[^>]*>)|(<img[^>]*>)|(<[/]?center[^>]*>)|(<br)|(<[/]?strong))<[^>]+>)
        private static string html2TextPattern =
@"(?<script><script[^>]*?>.*?</script>)|(?<style><style[^>]*>.*?</style>)|(?<comment><!--.*?-->)" +
@"|(?<html>(?!(<p[^>]*>)|(<img[^>]*>)|(<[/]?center[^>]*>)|(<br[/]?>)|(<[/]?strong>))<[^>]+>)|(\s+)" +   //保留的html标记前缀,<a>,<p>,<img><br><STRONG>
//   @"<[^>]+>)" + // HTML标记
@"|(?<quot>&(quot|#34);)" + // 符号: "
@"|(?<amp>&(amp|#38);)" + // 符号: &
@"|(?<end>(?!(</strong)|(</p>))</[^>]+>)" +        //HTML闭合标签 保留</A>,</STRONG>,</P>
@"|(?<iexcl>&(iexcl|#161);)" + // 符号: (char)161
@"|(?<cent>&(cent|#162);)" + // 符号: (char)162
@"|(?<pound>&(pound|#163);)" + // 符号: (char)163
@"|(?<copy>&(copy|#169);)" + // 符号: (char)169
@"|(?<others>&(d+);)"; // 符号: 其他

        private static string removeNoUsedHtml = @"(?<script><script[^>]*?>.*?</script>)|(?<style><style[^>]*>.*?</style>)|(?<comment><!--.*?-->)"; // 符号: 其他

        public static string NoHTML(string Htmlstring) //去除HTML标记  
        {
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled;
            //删除脚本  
            Htmlstring = Regex.Replace(Htmlstring, html2TextPattern, "", options);

            return RepairHtml(Htmlstring);
        }

        /// <summary>
        /// 修复html
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string RepairHtml(string html)
        {

            var ps = html.Split(new string[] { "<p>", "</p>", "<P>", "</P>", "<BR/>", "<br/>", "<br>", "<BR>", "<br />", "<BR />" }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();

            foreach (var p in ps)
            {
                var pragrah = p.Trim();
                
                if (!string.IsNullOrEmpty(pragrah))
                {
                    if (!pragrah.Contains("<img"))
                    {                        
                        // 小标题
                        if (pragrah.Length < 15 && !pragrah.Contains("，") && !pragrah.Contains("。"))
                        {
                            sb.AppendFormat("<p style='text-indent: 28px;'><strong>{0}</strong></p>", pragrah);
                        }
                        else
                        {
                            sb.AppendFormat("<p style='text-indent: 28px;'>{0}</p>", pragrah);
                        }
                    }
                    else
                    {
                        sb.Append(pragrah);
                    }
                }
            }
            return sb.ToString();
        }


        public static List<string> ExtractAccurateUrl(SiteRule siteRule, string html, string sourceUrl)
        {

            var result = ExtractDataFromHtml(html, siteRule.ListXPath, siteRule.ListXMLPathSelectType, siteRule.ListXMLPathType);
            RepairUrls(sourceUrl, siteRule.IncludePart, siteRule.ExcludePart, result);
            return result;
        }

        static string RemoveXml(string html)
        {
            var regex = new System.Text.RegularExpressions.Regex("<\\?xml[^>]+>", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Compiled);
            var notValidTag = new System.Text.RegularExpressions.Regex("<\\w+\\:\\w+>", System.Text.RegularExpressions.RegexOptions.Compiled);
            var tbody = new System.Text.RegularExpressions.Regex("<[/]*tbody>", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Compiled);
            var notused = new System.Text.RegularExpressions.Regex("(?<script><script[^>]*?>.*?</script>)|(?<style><style[^>]*>.*?</style>)|(?<comment><!--.*?-->)", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
            html = regex.Replace(html, "");
            html = notValidTag.Replace(html, "");
            html = tbody.Replace(html, "");
            html = notused.Replace(html, "");
            return html;
        }

        static string RemoveScriptStyleComment(string html)
        {
            var notused = new System.Text.RegularExpressions.Regex("(?<script><script[^>]*?>.*?</script>)|(?<style><style[^>]*>.*?</style>)|(?<comment><!--.*?-->)", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
            return notused.Replace(html, "");
        }

        public static string SgmlTranslate(string input)
        {
            input = RemoveXml(input);
            var reader = new SgmlReader();
            reader.DocType = "HTML";
            reader.WhitespaceHandling = WhitespaceHandling.None;
            reader.CaseFolding = Sgml.CaseFolding.ToLower;
            reader.InputStream = new StringReader(input);

            var output = new StringWriter();
            var writer = new XmlTextWriter(output);
            writer.Formatting = Formatting.Indented;

            while (reader.Read())
            {
                try
                {
                    if (reader.NodeType != XmlNodeType.Whitespace
                        && reader.NodeType != XmlNodeType.XmlDeclaration
                        && reader.NodeType != XmlNodeType.CDATA
                        && reader.NodeType != XmlNodeType.Comment)
                    {

                        if (reader.NodeType == XmlNodeType.Attribute)
                        {
                            writer.WriteNode(reader, true);
                            continue;
                        }

                        writer.WriteNode(reader, true);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            writer.Close();
            return output.ToString().Replace("xmlns=\"http://www.w3.org/1999/xhtml\"", "");
        }

        /// <summary>
        /// 使用xpath从html提取内容
        /// </summary>
        /// <param name="html"></param>
        /// <param name="xpath"></param>
        /// <param name="selectType"></param>
        /// <param name="pathType"></param>
        /// <returns></returns>
        public static List<string> ExtractDataFromHtml(string html, string xpath, XMLPathSelectType selectType, XMLPathType pathType, string anotherXPath = "")
        {

            var result = new List<string>();
            if (xpath == "" || html == "")
            {
                return result;
            }

            try
            {

                html = SgmlTranslate(html);

                //var oldHtml = html;

                //html = html.ToLower();
                if (!html.Contains("</BODY") && !html.Contains("</body"))
                {
                    html += "</body>";
                }
                //html = html.Replace("<tbody>", "").Replace("</tbody>", "").Replace("<TBODY>", "").Replace("</TBODY>", "");

                xpath = xpath.Replace("/tbody[1]", "");

                //var body = new Regex("<html[^>]*>.*?</html>", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);

                //html = body.Match(html).Value;

                //if (html == "")
                //{
                //    html = oldHtml;
                //}

                // check html
                var checkRegex = new Regex("<body[^>]*>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                var checkResults = checkRegex.Matches(html);
                if (checkResults.Count > 1)
                {
                    html = "<html>" + html.Substring(checkResults[checkResults.Count - 1].Index);
                }

                //File.WriteAllText("html.xml", html);

                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(html);

                    var findNodes = doc.SelectNodes(xpath);

                    // 替换XPATH
                    if ((findNodes == null || findNodes.Count == 0) && anotherXPath != "")
                    {
                        findNodes = doc.SelectNodes(anotherXPath.Replace("/tbody[1]", ""));
                    }

                    if (findNodes != null)
                    {
                        if (selectType == XMLPathSelectType.Multiple)
                        {
                            foreach (XmlNode node in findNodes)
                            {
                                switch (pathType)
                                {
                                    case XMLPathType.Href:
                                        if (node.Attributes["href"] != null && !node.Attributes["href"].Value.Contains("#"))
                                            result.Add(node.Attributes["href"].Value.ToString());
                                        break;
                                    case XMLPathType.InnerHtml:
                                        result.Add(node.InnerXml);
                                        break;
                                    case XMLPathType.InnerText:
                                        result.Add(node.InnerText.Trim());
                                        break;
                                    case XMLPathType.InnerLinks:
                                        var links = node.SelectNodes(".//a");
                                        foreach (XmlNode link in links)
                                        {
                                            if (link.Attributes["href"] != null && !link.Attributes["href"].Value.Contains("#"))
                                                result.Add(link.Attributes["href"].Value);
                                        }
                                        break;
                                    case XMLPathType.InnerTextWithPic:
                                        result.Add(NoHTML(node.InnerXml).Trim());
                                        break;
                                }
                            }
                        }
                        else
                        {
                            if (findNodes.Count > 0)
                            {
                                var node = findNodes[0];
                                switch (pathType)
                                {
                                    case XMLPathType.Href:
                                        if (node.Attributes["href"] != null && !node.Attributes["href"].Value.Contains("#"))
                                            result.Add(node.Attributes["href"].Value.ToString());
                                        break;
                                    case XMLPathType.InnerHtml:
                                        result.Add(node.InnerXml.Trim());
                                        break;
                                    case XMLPathType.InnerText:
                                        result.Add(node.InnerText.Trim());
                                        break;
                                    case XMLPathType.InnerLinks:
                                        var links = node.SelectNodes(".//a");
                                        foreach (XmlNode link in links)
                                        {
                                            if (link.Attributes["href"] != null && !link.Attributes["href"].Value.Contains("#"))
                                                result.Add(link.Attributes["href"].Value);
                                        }
                                        break;
                                    case XMLPathType.InnerTextWithPic:
                                        result.Add(NoHTML(node.InnerXml).Trim());
                                        break;
                                }
                            }

                        }
                    }

                    return result;
                }
                catch
                {

                    HtmlAgilityPack.HtmlDocument HtmlDoc = new HtmlAgilityPack.HtmlDocument();
                    //HtmlDoc.OptionAutoCloseOnEnd = true;
                    HtmlDoc.OptionFixNestedTags = true;
                    HtmlDoc.OptionOutputAsXml = true;
                    HtmlDoc.LoadHtml(html);
                    var nodes = HtmlDoc.DocumentNode.SelectNodes(xpath);

                    // 替换XPATH
                    if (nodes == null && anotherXPath != "")
                    {
                        nodes = HtmlDoc.DocumentNode.SelectNodes(anotherXPath.Replace("/tbody[1]", ""));
                    }

                    if (nodes != null)
                    {
                        if (selectType == XMLPathSelectType.Multiple)
                        {
                            foreach (HtmlAgilityPack.HtmlNode node in nodes)
                            {
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
                                        result.Add(node.InnerText.Trim());
                                        break;
                                    case XMLPathType.InnerLinks:
                                        result.AddRange(GetLinks(node));
                                        break;
                                    case XMLPathType.InnerTextWithPic:
                                        result.Add(NoHTML(node.InnerHtml).Trim());
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
                                        result.Add(node.InnerText.Trim());
                                        break;
                                    case XMLPathType.InnerLinks:
                                        result.AddRange(GetLinks(node));
                                        break;
                                    case XMLPathType.InnerTextWithPic:
                                        result.Add(NoHTML(node.InnerHtml).Trim());
                                        break;
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                if (originalUrl.StartsWith("javas"))
                {
                    return string.Empty; ;
                }

                originalUrl = originalUrl.Replace("&amp;", "&");

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