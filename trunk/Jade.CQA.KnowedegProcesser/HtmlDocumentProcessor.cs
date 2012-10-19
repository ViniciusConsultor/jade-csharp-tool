using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jade.CQA.Robot;
using Jade.CQA.Robot.Extensions;
using Jade.CQA.Robot.Utils;
using System.Net;
using HtmlAgilityPack;
using System.IO;
using Jade.CQA.Robot.Interfaces;
using System.Text.RegularExpressions;
using Jade.CQA.KnowedegProcesser.Extensions;
using Jade.CQA.Model;
using Jade.CQA.Robot.Extensions;
using System.Globalization;

namespace Jade.CQA.KnowedegProcesser
{
    public interface ISubstitution
    {
        string Substitute(string original, CrawlStep crawlStep);
    }

    /// <summary>
    /// Class for filtering content, for example you might wan't to exclude partial
    /// link contained in a speciel part of a html page from beeing followed.
    /// Or maybe exclude part of a textual content
    /// And replacecontent based regex
    /// </summary>
    public abstract class ContentCrawlerRules
    {
        #region Readonly & Static Fields

        /// <summary>
        /// </summary>
        private readonly Dictionary<string, string> m_FilterLinksRules;

        /// <summary>
        /// </summary>
        private readonly Dictionary<string, string> m_FilterTextRules;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentCrawlerRules"/> class. 
        /// </summary>
        protected ContentCrawlerRules()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentCrawlerRules"/> class. 
        /// </summary>
        /// <param name="filterTextRules">
        /// The filter text rules.
        /// </param>
        /// <param name="filterLinksRules">
        /// The filter links rules.
        /// </param>
        protected ContentCrawlerRules(Dictionary<string, string> filterTextRules, Dictionary<string, string> filterLinksRules)
        {
            m_FilterTextRules = filterTextRules;
            m_FilterLinksRules = filterLinksRules;
        }

        #endregion

        #region Instance Properties

        public IEnumerable<ISubstitution> Substitutions { get; set; }

        /// <summary>
        /// Gets a value indicating whether Has Link Strip Rules.
        /// </summary>
        /// <value>
        /// The has rules.
        /// </value>
        protected bool HasLinkStripRules
        {
            get { return !m_FilterLinksRules.IsNull() && m_FilterLinksRules.Count > 0; }
        }

        /// <summary>
        /// Gets a value indicating whether HasTextStripRules.
        /// </summary>
        /// <value>
        /// The has rules.
        /// </value>
        protected bool HasTextStripRules
        {
            get { return !m_FilterTextRules.IsNull() && m_FilterTextRules.Count > 0; }
        }

        protected bool HasSubstitutionRules
        {
            get { return !Substitutions.IsNull(); }
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// </summary>
        /// <param name="content">
        /// The content.
        /// </param>
        /// <returns>
        /// </returns>
        protected string StripLinks(string content)
        {
            return StripByRules(m_FilterLinksRules, content);
        }

        /// <summary>
        /// </summary>
        /// <param name="content">
        /// The content.
        /// </param>
        /// <returns>
        /// </returns>
        protected string StripText(string content)
        {
            return StripByRules(m_FilterTextRules, content);
        }

        protected string Substitute(string original, CrawlStep crawlStep)
        {
            return HasSubstitutionRules
                ? Substitutions.Aggregate(original, (current, substitution) => substitution.Substitute(current, crawlStep))
                : original;
        }

        #endregion

        #region Class Methods

        /// <summary>
        /// Basically strips everything between the start marker and the end marker
        /// The start marker is the Key in the Dictionary<string, string>, the end marker is the Value
        /// </summary>
        /// <param name="rules">
        /// </param>
        /// <param name="content">
        /// </param>
        /// <returns>
        /// </returns>
        private static string StripByRules(Dictionary<string, string> rules, string content)
        {
            if (rules.IsNull() || content.IsNullOrEmpty())
            {
                return content;
            }

            foreach (KeyValuePair<string, string> k in rules)
            {
                string key = Regex.Escape(k.Key);
                string value = Regex.Escape(k.Value);
                string pattern = "({0})(.*?)({1})".FormatWith(key, value);
                const RegexOptions options = RegexOptions.IgnoreCase |
                    RegexOptions.Singleline | RegexOptions.CultureInvariant | RegexOptions.Compiled;
                content = Regex.Replace(content, pattern, string.Empty, options);
            }

            return content;
        }

        #endregion
    }

    public class HtmlDocumentProcessor : ContentCrawlerRules, IPipelineStep
    {
        #region Constructors

        public HtmlDocumentProcessor()
            : this(null, null)
        {
        }

        public HtmlDocumentProcessor(Dictionary<string, string> filterTextRules,
            Dictionary<string, string> filterLinksRules)
            : base(filterTextRules, filterLinksRules)
        {
        }

        #endregion

        #region Instance Methods

        protected virtual string NormalizeLink(string baseUrl, string link)
        {
            return link.NormalizeUrl(baseUrl);
        }

        #endregion

        #region IPipelineStep Members

        public virtual void Process(Crawler crawler, PropertyBag propertyBag)
        {
            AspectF.Define.
                NotNull(crawler, "crawler").
                NotNull(propertyBag, "propertyBag");

            if (propertyBag.StatusCode != HttpStatusCode.OK)
            {
                return;
            }

            if (!IsHtmlContent(propertyBag.ContentType))
            {
                return;
            }

            HtmlDocument htmlDoc = new HtmlDocument
            {
                OptionAddDebuggingAttributes = false,
                OptionAutoCloseOnEnd = true,
                OptionFixNestedTags = true,
                OptionReadEncoding = true
            };
            using (Stream reader = propertyBag.GetResponse())
            {
                Encoding documentEncoding = htmlDoc.DetectEncoding(reader);
                reader.Seek(0, SeekOrigin.Begin);
                if (!documentEncoding.IsNull())
                {
                    htmlDoc.Load(reader, documentEncoding, true);
                }
                else
                {
                    htmlDoc.Load(reader, true);
                }
            }

            string originalContent = htmlDoc.DocumentNode.OuterHtml;
            if (HasTextStripRules || HasSubstitutionRules)
            {
                string content = StripText(originalContent);
                content = Substitute(content, propertyBag.Step);
                using (TextReader tr = new StringReader(content))
                {
                    htmlDoc.Load(tr);
                }
            }

            propertyBag["HtmlDoc"].Value = htmlDoc;

            HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes("//title");
            // Extract Title
            if (!nodes.IsNull())
            {
                propertyBag.Title = string.Join(";", nodes.
                    Select(n => n.InnerText).
                    ToArray()).Trim();
            }

            // Extract Meta Data
            nodes = htmlDoc.DocumentNode.SelectNodes("//meta[@content and @name]");
            if (!nodes.IsNull())
            {
                propertyBag["Meta"].Value = (
                    from entry in nodes
                    let name = entry.Attributes["name"]
                    let content = entry.Attributes["content"]
                    where !name.IsNull() && !name.Value.IsNullOrEmpty() && !content.IsNull() && !content.Value.IsNullOrEmpty()
                    select name.Value + ": " + content.Value).ToArray();
            }

            // Extract text
            propertyBag.Text = htmlDoc.ExtractText().Trim();
            if (HasLinkStripRules || HasTextStripRules)
            {
                string content = StripLinks(originalContent);
                using (TextReader tr = new StringReader(content))
                {
                    htmlDoc.Load(tr);
                }
            }

            string baseUrl = propertyBag.ResponseUri.GetLeftPart(UriPartial.Path);

            // Extract Head Base
            nodes = htmlDoc.DocumentNode.SelectNodes("//head/base[@href]");
            if (!nodes.IsNull())
            {
                baseUrl =
                    nodes.
                    Select(entry => new { entry, href = entry.Attributes["href"] }).
                        Where(@t => !@t.href.IsNull() && !@t.href.Value.IsNullOrEmpty() &&
                            Uri.IsWellFormedUriString(@t.href.Value, UriKind.RelativeOrAbsolute)).
                    Select(@t => @t.href.Value).
                    AddToEnd(baseUrl).
                    FirstOrDefault();
            }

            // Extract Links
            DocumentWithLinks links = htmlDoc.GetLinks();
            // 只采集链接
            //foreach (string link in links.Links.Union(links.References))
            foreach (string link in links.References)
            {

                if (link.IsNullOrEmpty())
                {
                    continue;
                }

                string decodedLink = ExtendedHtmlUtility.HtmlEntityDecode(link);
                string normalizedLink = NormalizeLink(baseUrl, decodedLink);
                if (normalizedLink.IsNullOrEmpty())
                {
                    continue;
                }

                crawler.AddStep(new Uri(normalizedLink), propertyBag.Step.Depth + 1,
                    propertyBag.Step, new Dictionary<string, object>
						{
							{"OriginalUrl", link},
							{"OriginalReferrerUrl", propertyBag.ResponseUri}
						});
            }
        }

        #endregion

        #region Class Methods

        private static bool IsHtmlContent(string contentType)
        {
            return contentType.StartsWith("text/html", StringComparison.OrdinalIgnoreCase);
        }

        #endregion
    }

    public class BadiduDocumentProcessor : HtmlDocumentProcessor
    {

        public string GetHtml(string url)
        {
            WebClient client = new WebClient();
            return client.DownloadString(url);
        }

        public override void Process(Crawler crawler, PropertyBag propertyBag)
        {
            base.Process(crawler, propertyBag);

            var htmlDoc = (HtmlDocument)propertyBag["HtmlDoc"].Value;
            var html = htmlDoc.DocumentNode.OuterHtml;
            // 用户
            if (propertyBag.OriginalUrl.Contains("/p/"))
            {
                /*
                姓名：
//*[@id="1000001"]/div[2]/div[1]/h2

采纳率：//*[@id="1000003"]/div[2]/ul/li[1]/b

回答数：//*[@id="1000003"]/div[2]/ul/li[2]/b

被赞同数：//*[@id="1000003"]/div[2]/ul/li[3]/b

擅长领域：
 //*[@id="1000003"]/div[3]/ul
                */

                var user = new User()
                {
                    KnowedgeType = KnowedgeType.BaiduZhidao
                };





                // html = html.Substring("\"tplContent\":\"", "});");

                var result = html.SubstringAll("<b class=zhidao-basic-num>", "<\\/b>");

                if (result.Count == 6)
                {
                    //html = html.Replace("\\x22", "\"");
                    user.AdoptionRate = double.Parse(result[0].Replace("%", ""));
                    // <li class=first> <span>回答采纳率<\/span> <b class=zhidao-basic-num>0%<\/b>  <li> <span>回答数<\/span> <b class=zhidao-basic-num>18<\/b>  <li> <span>回答被赞同数<\/span> <b class=zhidao-basic-num>3<\/b>  <li> <span>经验值<\/span> <b class=zhidao-basic-num>95<\/b>  <li> <span>财富值<\/span> <b class=zhidao-basic-num>90<\/b>  <li> <span>提问数<\/span> <b class=zhidao-basic-num>1<\/b>
                    user.AnwserCount = int.Parse(result[1]);
                    user.AdoptionCount = int.Parse(result[2]);
                }
                var area = html.Substring("<label>擅长领域：<\\/label>", "<\\/ul>").HtmToTxt().Replace("\\", "").Trim();
                user.ExpertArea = area;

                user.UserStage = html.Substring("<h2 class=\\x22headline yahei\\x22>他的知道形象<\\/h2>", "<\\/div>").HtmToTxt().Trim();
                //Console.WriteLine(html);

                user.UserName = html.Substring("<title>", "的百度个人主页</title>");

                Console.WriteLine(user.ToString());
                //File.WriteAllText("1.html", string.Format("<html><body>{0}</body></html>", html));

                //    UserName = htmlDoc.ExtractData("//*[@id=\"1000001\"]/div[2]/div[1]/h2"),
                //    AdoptionRate = double.Parse(htmlDoc.ExtractData("//*[@id=\"1000003\"]/div[2]/ul/li[1]/b").Trim()),
                //    AdoptionCount = int.Parse(htmlDoc.ExtractData("//*[@id=\"1000003\"]/div[2]/ul/li[3]/b").Trim()),
                //    AnwserCount = int.Parse(htmlDoc.ExtractData("//*[@id=\"1000003\"]/div[2]/ul/li[2]/b").Trim()),
                //    ExpertArea = htmlDoc.ExtractData("//*[@id=\"1000003\"]/div[3]/ul"),
                //};

            }
            else if (propertyBag.OriginalUrl.Contains("/question/"))
            {
                var question = new Question();
                question.KnowedgeType = KnowedgeType.BaiduZhidao;
                question.Title = html.Substring("<title>", "_百度知道");

                var time = htmlDoc.ExtractData("//div[@id=\"question-box\"]/div[2]/div[1]/div[1]/div[1]/div[1]/span[1]");
                // 2009-1-23 18:34
                question.CreateTime = ParseDatetime(time); ;
                question.Content = htmlDoc.ExtractData("//pre[@id=\"question-content\"]").Trim();
                question.Category = htmlDoc.ExtractData("//div[@id=\"body\"]/div[1]").Trim();
                question.Id = propertyBag.OriginalUrl.Substring("question/", ".html");
                question.Url = propertyBag.OriginalUrl;
                question.ViewCount = GetHtml("http://cp.zhidao.baidu.com/v.php?q=" + question.Id + "&callback=");
                Console.WriteLine(question.ToString());
            }
        }

        private static DateTime ParseDatetime(string time)
        {
            DateTime createTime = DateTime.Now;
            if (time.Contains("分钟前"))
            {
                time = time.Replace("分钟前", "").Trim();
                createTime.AddMinutes(-int.Parse(time));
            }
            else
            {
                if (time.Contains("今天"))
                    time = time.Replace("今天", DateTime.Now.ToString("yyyy-MM-dd"));

                //createTime = DateTime.ParseExact(time, "y-M-d H:m", null);

                string[] DateTimeList = { 
                            "yyyy-M-d HH:mm", 
                            "yyyy-MM-dd HH:mm" 
                        };

                createTime = DateTime.ParseExact(time,
                                                  DateTimeList,
                                                  CultureInfo.InvariantCulture,
                                                  DateTimeStyles.AllowWhiteSpaces
                                                  );
            }
            return createTime;
        }
    }
}
