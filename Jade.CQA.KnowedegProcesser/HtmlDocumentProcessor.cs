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
using System.Threading;
using Jade.CQA.Robot.Services;
using System.Net.Sockets;

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

    public class Cache
    {
        public static SiteUrlFilter filter = new SiteUrlFilter("filter.bin");

        public static SiteUrlFilter wenwenFilter = new SiteUrlFilter("wenwenFilter.bin");
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

        public virtual bool IsAllowedUrl(string url)
        {
            return true;
        }

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

            // 300 ms
            //Thread.Sleep(100);

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
                if (!this.IsAllowedUrl(link))
                {
                    //Console.WriteLine("跳过" + link);
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
        public static Regex IdRegex = new Regex("(\\d+)\\.html");

        public override bool IsAllowedUrl(string url)
        {

            if (url.Contains("/question/")
                || url.Contains("/browse/") || url.Contains("/p/")
                )
            {
                //url = "http://zhidao.baidu.com/question/11921534.html"
                if (url.Contains("/question/"))
                {
                    url = IdRegex.Match(url).Groups[1].Value;
                    return !Cache.filter.IsContentPageExist(url, true);
                }
                return true;
            }
            return false;
        }

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
                ExtractUser(html);
            }
            else if (propertyBag.OriginalUrl.Contains("/question/"))
            {
                ExtractQuestion(propertyBag, htmlDoc, html);
            }
        }

        private static void ExtractUser(string html)
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
        }

        private void ExtractQuestion(PropertyBag propertyBag, HtmlDocument htmlDoc, string html)
        {
            if (html.Contains("您的访问出错了"))
            {
                Console.WriteLine("访问出错了");

                RASDisplay ras = new RASDisplay();
                Console.WriteLine("等待重拨号中。。。");
                ras.Disconnect();              
                Thread.Sleep(10000);
                Console.WriteLine("重新拨号中。。。");
                ras.Connect("3G");
                Thread.Sleep(1000);
                IPAddress[] arrIPAddresses = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress ip in arrIPAddresses)
                {
                    if (ip.AddressFamily.Equals(AddressFamily.InterNetwork))
                    {
                        Console.WriteLine("新ip" + ip.ToString());
                    }
                }

                //todo 重拨号
            }

            var question = new Question();
            question.KnowedgeType = KnowedgeType.BaiduZhidao;
            question.Title = html.Substring("<title>", "百度知道").Replace("_", "");

            ////*[@id="question-box"]/div[2]/div[1]/div/div/div/span[3]
            var time = htmlDoc.ExtractData("//div[@id=\"question-box\"]/div[2]/div[1]/div[1]/div[1]/div[1]/span[1]");
            // 2009-1-23 18:34

            if (time == "")
            {
                time = htmlDoc.ExtractData("//*[@id=\"question-box\"]/div[2]/div[1]/div/div/div/span[3]");
            }
            if (time != "")
            {
                question.CreateTime = ParseDatetime(time);
            }

            question.Content = htmlDoc.ExtractData("//pre[@id=\"question-content\"]").Trim();
            question.Category = htmlDoc.ExtractData("//div[@id=\"body\"]/div[1]").Trim();
            question.Id = propertyBag.OriginalUrl.Substring("question/", ".html");
            question.Url = propertyBag.OriginalUrl;
            question.ViewCount = int.Parse(GetHtml("http://cp.zhidao.baidu.com/v.php?q=" + question.Id + "&callback=").Trim());
            //Console.WriteLine(question.ToString());

            // 回复数目

            // http://comment.api.baidu.com/api?pid=iknow&tk=iknow&service=Comment&method=get_reply_count_batch&query_mask=999&data=
            //[{%22thread_id%22:2458732005,%22reply_id%22:0,%22query_mask%22:999},{%22thread_id%22:2458558657,%22reply_id%22:0,%22query_mask%22:999},{%22thread_id%22:2458568821,%22reply_id%22:0,%22query_mask%22:999}]
            //&callback=bd__cbs__ds972m

            // 答案id
            var anwsers = new List<Answer>();

            var answerIdsNodes = htmlDoc.DocumentNode.SelectNodes("//input[@name=\"threadId\"]");
            var answerIds = answerIdsNodes != null ? answerIdsNodes.Select(n => n.Attributes["value"].Value).ToList() : new List<string>();

            if (answerIds.Count != 0)
            {
                var commentUrl = "http://comment.api.baidu.com/api?pid=iknow&tk=iknow&service=Comment&method=get_reply_count_batch&query_mask=999&data=["
                    + string.Join(",", answerIds.Select(id => "{%22thread_id%22:" + id + ",%22reply_id%22:0,%22query_mask%22:999}").ToArray())
                    + "]&callback=bd__cbs__ds972m";

                //bd__cbs__ds972m({"res":[{"err_no":0,"err_msg":"success","total_count":"47","thread_id":2458732005,"reply_id":0},{"err_no":0,"err_msg":"success","total_count":"4","thread_id":2458558657,"reply_id":0},{"err_no":0,"err_msg":"success","total_count":"1","thread_id":2458568821,"reply_id":0}]})

                var regex = new Regex("total_count\":\"(\\d+)\"");

                var commentApi = GetHtml(commentUrl);
                var commentCounts = regex.Matches(commentApi);

                var userNames = htmlDoc.DocumentNode.SelectNodes("//input[@name=\"userName\"]").Select(n => n.Attributes["value"].Value).ToList();
                // 答案
                var bestAnswer = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='best-answer-panel']");

                var index = 0;



                if (bestAnswer != null)
                {
                    try
                    {
                        var answser = new Answer();
                        answser.KnowedgeType = KnowedgeType.BaiduZhidao;
                        answser.Content = htmlDoc.ExtractData("//pre[@id=\"best-answer-content\"]");
                        answser.CreateTime = ParseDatetime(bestAnswer.SelectSingleNode("./div[1]/div[1]/span").InnerText.Trim());


                        //answser.CommentCount = int.Parse(htmlDoc.ExtractData("//*[@id=\"best-answer-panel\"]/div[2]/div[1]/div/div/div/div[2]"));
                        answser.CommentCount = int.Parse(commentCounts[index].Groups[1].Value);
                        answser.AnswerId = answerIds[index];
                        answser.UserName = userNames[index];
                        answser.QuestionId = question.Id;
                        answser.IsBestAnwser = true;
                        anwsers.Add(answser);
                        question.Status = QuestionStatus.WithSatisfiedAnwser;
                        answser.Up = int.Parse(htmlDoc.ExtractData("//*[@id=\"best-answer-panel\"]/div[2]/div[1]/div/div/div/div[2]"));

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    index++;
                }

                var recommond = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='recommend-answer-panel']");
                if (recommond != null)
                {
                    try
                    {
                        var answser = new Answer();
                        answser.KnowedgeType = KnowedgeType.BaiduZhidao;

                        var contentNode = recommond.SelectSingleNode("./div[2]/div[1]/pre");
                        if (contentNode == null)
                        {
                            contentNode = recommond.SelectSingleNode("./div[2]/div[1]");
                        }
                        if (contentNode != null)
                        {
                            answser.Content = contentNode.InnerText;
                        }

                        ////*[@id="recommend-answer-panel"]/div[1]/div/span[3]
                        answser.CreateTime = ParseDatetime(htmlDoc.ExtractData("//*[@id=\"recommend-answer-panel\"]/div[1]/div/span[1]"));
                        var up = htmlDoc.ExtractData("//*[@id=\"recommend-answer-panel\"]/div[2]/div[1]/div/div/div/div[2]");
                        if (up == "")
                        {
                            up = htmlDoc.ExtractData("//div[@class=\"value-num value-num-fixed\"]").Trim();
                        }

                        try
                        {
                            if (up != "")
                            {
                                answser.Up = int.Parse(up);
                            }

                        }
                        catch
                        {
                        }

                        //answser.CommentCount = int.Parse(htmlDoc.ExtractData("//*[@id=\"best-answer-panel\"]/div[2]/div[1]/div/div/div/div[2]"));
                        answser.CommentCount = int.Parse(commentCounts[index].Groups[1].Value);
                        answser.AnswerId = answerIds[index];
                        answser.UserName = userNames[index];
                        answser.QuestionId = question.Id;
                        answser.IsBestAnwser = false;
                        answser.IsRecommendAnwser = true;
                        anwsers.Add(answser);
                        question.Status = QuestionStatus.WithRecommendedAnwser;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    index++;
                }

                var replyies = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"reply-panel\"]//div");

                if (replyies != null)
                {
                    foreach (var reply in replyies)
                    {
                        if (reply.Attributes["class"] != null && reply.Attributes["class"].Value.Contains("entry clf"))
                        {
                            try
                            {
                                var anwser = new Answer();
                                anwser.KnowedgeType = KnowedgeType.BaiduZhidao;
                                anwser.UserName = userNames[index];

                                var contentNode = reply.SelectSingleNode("./div/div[2]/pre");
                                if (contentNode == null)
                                {
                                    contentNode = reply.SelectSingleNode("./div//pre");
                                    if (contentNode == null)
                                    {
                                        contentNode = reply.SelectSingleNode("./div[@class='content']");
                                    }
                                }
                                if (contentNode != null)
                                {
                                    anwser.Content = contentNode.InnerText;
                                }
                                anwser.CreateTime = ParseDatetime(reply.SelectSingleNode("./div/div[1]/span[1]/text()").InnerText.Trim());
                                anwser.AnswerId = answerIds[index];
                                anwser.CommentCount = int.Parse(commentCounts[index].Groups[1].Value);
                                anwser.QuestionId = question.Id;
                                anwser.IsBestAnwser = false;

                                anwsers.Add(anwser);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            index++;
                        }
                    }
                }
            }
            // 获取相关问题

            var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@id='relative-panel']//li/a");
            var relativeQuestions = nodes != null ? nodes.Select(n => n.Attributes["href"].Value.Replace("/question/", "").Replace(".html", "")).ToList() : new List<string>();
            /*
             *  <li>
               <span class="details">2012-4-22</span>
                
                <a log="relative.title.click" href="/question/413824351.html" onclick="log.send(this.href,2033,{fr:'qrl',cid:'1040',index:3})" target="_blank">htc g12 为什么手机满电的，关机过了一个早上后电量只剩下30％，而...</a>
                
                
                
            </li>
             * */


            if (anwsers.Count > 0)
            {
                if (question.Status == QuestionStatus.NoAnswer)
                {
                    question.Status = QuestionStatus.WithRecommendedAnwser;
                }
            }

            var questionAndAnswer = new QuestionAnswer();
            questionAndAnswer.KnowedgeType = KnowedgeType.BaiduZhidao;
            questionAndAnswer.QuestionId = question.Id;
            questionAndAnswer.SatisfiedAnswerIds = anwsers.Where(a => a.IsBestAnwser).Select(a => a.AnswerId).ToList();
            questionAndAnswer.RecommendedAnswerIds = anwsers.Where(a => a.IsRecommendAnwser).Select(a => a.AnswerId).ToList();
            questionAndAnswer.RelatedQuestionIds = relativeQuestions;
            questionAndAnswer.AnswerIds = anwsers.Select(a => a.AnswerId).ToList();


            var fetchResult = new FetchResult
            {
                Question = question,
                QuestionAnswer = questionAndAnswer,
                Answers = anwsers
            };

            propertyBag["fetchResult"].Value = fetchResult;

        }

        private static DateTime ParseDatetime(string time)
        {
            DateTime createTime = DateTime.Now;
            int minutes = 0;
            if (time.Contains("分钟前"))
            {
                time = time.Replace("分钟前", "").Trim();
                createTime.AddMinutes(-int.Parse(time));
            }
            if (time.Contains("小时前"))
            {
                time = time.Replace("小时前", "").Trim();
                createTime.AddMinutes(-int.Parse(time) * 60);
            }
            else if (int.TryParse(time.Trim(), out minutes))
            {
                createTime.AddMinutes(-minutes);
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

                try
                {
                    createTime = DateTime.ParseExact(time,
                                                      DateTimeList,
                                                      CultureInfo.InvariantCulture,
                                                      DateTimeStyles.AllowWhiteSpaces
                                                      );
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return createTime;
        }
    }

    public class WenwenDocumentProcessor : HtmlDocumentProcessor
    {
        public static Regex IdRegex = new Regex("z/c(\\d+)\\.htm");

        public override bool IsAllowedUrl(string url)
        {
            // /z/ShowUser.e  /z/q /z/c
            if (
              url.Contains("/z/c") ||
              url.Contains("/z/q") ||
              url.Contains("/z/ShowUser.e")
                )
            {
                //url = "http://zhidao.baidu.com/question/11921534.html"
                if (url.Contains("/z/q"))
                {
                    url = IdRegex.Match(url).Groups[1].Value;
                    return !Cache.wenwenFilter.IsContentPageExist(url, false);
                }
                return true;
            }
            return false;
        }

        public string GetHtml(string url)
        {
            WebClient client = new WebClient();
            return client.DownloadString(url);
        }

        public override void Process(Crawler crawler, PropertyBag propertyBag)
        {
            base.Process(crawler, propertyBag);

            if (propertyBag.OriginalUrl != null)
            {
                var htmlDoc = (HtmlDocument)propertyBag["HtmlDoc"].Value;
                var html = htmlDoc.DocumentNode.OuterHtml;
                // 用户
                if (propertyBag.OriginalUrl.Contains("/z/ShowUser.e"))
                {
                    ExtractUser(html, htmlDoc);
                }
                else if (propertyBag.OriginalUrl.Contains("/z/q"))
                {
                    ExtractQuestion(propertyBag, htmlDoc, html);
                }
            }
        }

        private static void ExtractUser(string html, HtmlDocument htmlDoc)
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
                KnowedgeType = KnowedgeType.SosoWenwen
            };

            var total = new Regex("回答数：(\\d+)", RegexOptions.Compiled);
            var manyi = new Regex("满意数：(\\d+)", RegexOptions.Compiled);
            var AdoptionRate = new Regex("采纳率：(\\d+\\.\\d+)", RegexOptions.Compiled);

            var level = new Regex(@"lv_(\d+)\.gif", RegexOptions.Compiled);
            user.AdoptionRate = double.Parse(AdoptionRate.Match(html).Groups[1].Value);
            // <li class=first> <span>回答采纳率<\/span> <b class=zhidao-basic-num>0%<\/b>  <li> <span>回答数<\/span> <b class=zhidao-basic-num>18<\/b>  <li> <span>回答被赞同数<\/span> <b class=zhidao-basic-num>3<\/b>  <li> <span>经验值<\/span> <b class=zhidao-basic-num>95<\/b>  <li> <span>财富值<\/span> <b class=zhidao-basic-num>90<\/b>  <li> <span>提问数<\/span> <b class=zhidao-basic-num>1<\/b>
            user.AnwserCount = int.Parse(total.Match(html).Groups[1].Value);
            user.AdoptionCount = int.Parse(manyi.Match(html).Groups[1].Value);

            user.ExpertArea = htmlDoc.ExtractData("//*[@id=\"R\"]/table[2]/tr/td[3]/table[1]/tr/td/table//tr/td[2]/span/a");

            user.UserStage = level.Match(html).Groups[1].Value;

            user.UserName = htmlDoc.DocumentNode.SelectSingleNode("//title").InnerText.Trim().Replace("- 用户信息 - 搜搜问问", "");
            Console.WriteLine(user.ToString());
        }

        Regex dateTime = new Regex(@"\d{4}-\d+-\d+\s+\d+:\d+");

        private void ExtractQuestion(PropertyBag propertyBag, HtmlDocument htmlDoc, string html)
        {
            if (html.Contains("您的访问出错了"))
            {
                Console.WriteLine("访问出错了");

                Thread.Sleep(60 * 3600 * 1000);
            }

            var question = new Question();
            question.KnowedgeType = KnowedgeType.SosoWenwen;
            question.Title = htmlDoc.ExtractDataById("questionTitle");
            var time = htmlDoc.ExtractData("//span[@class='question_time']");
            if (time != "")
            {
                question.CreateTime = ParseDatetime(time);
            }
            question.Tags = htmlDoc.ExtractDataById("questionTag");

            question.Content = htmlDoc.ExtractDataById("questionContent");
            question.Category = htmlDoc.ExtractDataById("questionCategory").Trim();
            question.Id = propertyBag.OriginalUrl.Substring("/z/q", ".htm");
            question.Url = propertyBag.OriginalUrl;
            question.ViewCount = 0;
            //int.Parse(GetHtml("http://cp.zhidao.baidu.com/v.php?q=" + question.Id + "&callback=").Trim());
            //Console.WriteLine(question.ToString());

            // 回复数目

            // http://comment.api.baidu.com/api?pid=iknow&tk=iknow&service=Comment&method=get_reply_count_batch&query_mask=999&data=
            //[{%22thread_id%22:2458732005,%22reply_id%22:0,%22query_mask%22:999},{%22thread_id%22:2458558657,%22reply_id%22:0,%22query_mask%22:999},{%22thread_id%22:2458568821,%22reply_id%22:0,%22query_mask%22:999}]
            //&callback=bd__cbs__ds972m

            // 答案id
            var anwsers = new List<Answer>();


            var best = htmlDoc.DocumentNode.SelectSingleNode("//div[@class=\"sloved_answer\"]");
            if (best != null)
            {
                var answer = new Answer
                {
                    IsBestAnwser = true,
                    Content = htmlDoc.ExtractData("//div[@class=\"sloved_answer\"]/div[1]"),
                    KnowedgeType = KnowedgeType.SosoWenwen
                };

                var id = htmlDoc.DocumentNode.SelectSingleNode("//div[@class=\"sloved_answer\"]//div[2]//div[1]");
                if (id != null)
                {
                    try
                    {
                        answer.AnswerId = id.Attributes["id"].Value.Replace("solveDIV", "");
                        if (answer.AnswerId != "")
                        {
                            answer.Up = int.Parse(htmlDoc.ExtractDataById("solvedNum" + answer.AnswerId));
                            answer.Down = int.Parse(htmlDoc.ExtractDataById("notSolvedNum" + answer.AnswerId));
                        }
                    }
                    catch
                    {
                    }
                }

                var user = best.SelectSingleNode(".//div[@class='user_sign']/a[1]");
                if (user != null)
                {
                    answer.UserName = user.InnerText;
                }
                anwsers.Add(answer);
                question.Status = QuestionStatus.WithSatisfiedAnwser;
            }

            var default_answers = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class,'default_answe')]");
            if (default_answers != null)
            {
                foreach (HtmlNode defaultAnswer in default_answers)
                {
                    var answer = new Answer
                    {
                        IsBestAnwser = false,
                        KnowedgeType = KnowedgeType.SosoWenwen
                    };
                    var c = defaultAnswer.SelectSingleNode("./div[1]/pre");
                    if (c == null)
                    {
                        c = defaultAnswer.SelectSingleNode("./div[1]");
                    }
                    if (c != null)
                        answer.Content = c.InnerText;
                    var u = defaultAnswer.SelectSingleNode(".//div[class='user_sign']/a[1]");
                    if (u != null)
                    {
                        answer.UserName = u.InnerText;
                    }

                    var t = dateTime.Match(defaultAnswer.InnerText).Value;
                    if (t != "")
                    {
                        answer.CreateTime = ParseDatetime(t);
                    }

                }
            }


            var related = "http://wenwen.soso.com/z/async/Async.htm?id=Lion&qid=" + question.Id + "&rw=&r=0.7012521030846983&rightRegionRefactor=false&rnd=1351132790753";

            var relatedHtml = GetHtml(related);
            // 获取相关问题

            var relatedDoc = new HtmlDocument();
            relatedDoc.LoadHtml("<html><body>" + relatedHtml + "</body></html>");

            var nodes = relatedDoc.DocumentNode.SelectNodes("//ul[@id='relateQuestionBlock']//a[@href]");

            var rIdRegex = new Regex(@"/z/q(\d+)\.htm");

            // /z/q233400709.htm?sp=1002&amp;pid=ask.xgzs.lddj
            var relativeQuestions = nodes != null ?
                nodes.Select(n => rIdRegex.Match(n.Attributes["href"].Value).Groups[1].Value).ToList() :
                new List<string>();
            /*
             *  <li>
               <span class="details">2012-4-22</span>
                
                <a log="relative.title.click" href="/question/413824351.html" onclick="log.send(this.href,2033,{fr:'qrl',cid:'1040',index:3})" target="_blank">htc g12 为什么手机满电的，关机过了一个早上后电量只剩下30％，而...</a>
                
                
                
            </li>
             * */


            if (anwsers.Count > 0)
            {
                if (question.Status == QuestionStatus.NoAnswer)
                {
                    question.Status = QuestionStatus.NoSatisfiedAnwser; ;
                }
            }

            var questionAndAnswer = new QuestionAnswer();
            questionAndAnswer.KnowedgeType = KnowedgeType.BaiduZhidao;
            questionAndAnswer.QuestionId = question.Id;
            questionAndAnswer.SatisfiedAnswerIds = anwsers.Where(a => a.IsBestAnwser).Select(a => a.AnswerId).ToList();
            questionAndAnswer.RecommendedAnswerIds = anwsers.Where(a => a.IsRecommendAnwser).Select(a => a.AnswerId).ToList();
            questionAndAnswer.RelatedQuestionIds = relativeQuestions;
            questionAndAnswer.AnswerIds = anwsers.Select(a => a.AnswerId).ToList();


            var fetchResult = new FetchResult
            {
                Question = question,
                QuestionAnswer = questionAndAnswer,
                Answers = anwsers
            };

            propertyBag["fetchResult"].Value = fetchResult;

        }

        private static DateTime ParseDatetime(string time)
        {
            DateTime createTime = DateTime.Now;
            int minutes = 0;
            if (time.Contains("分钟前"))
            {
                time = time.Replace("分钟前", "").Trim();
                createTime.AddMinutes(-int.Parse(time));
            }
            if (time.Contains("小时前"))
            {
                time = time.Replace("小时前", "").Trim();
                createTime.AddMinutes(-int.Parse(time) * 60);
            }
            else if (int.TryParse(time.Trim(), out minutes))
            {
                createTime.AddMinutes(-minutes);
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

                try
                {
                    createTime = DateTime.ParseExact(time,
                                                      DateTimeList,
                                                      CultureInfo.InvariantCulture,
                                                      DateTimeStyles.AllowWhiteSpaces
                                                      );
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return createTime;
        }
    }
}
