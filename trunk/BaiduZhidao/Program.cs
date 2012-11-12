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
using Jade.CQA.KnowedegProcesser.DataSave;
using System.Diagnostics;
using System.Linq.Expressions;
//using MbnApi;

namespace BaiduZhidao
{
    public static class TextWriterExtensions
    {
        #region Class Methods

        public static void WriteLine(this TextWriter writer, ConsoleColor color, string format, params object[] args)
        {
            AspectF.Define.
                NotNull(writer, "writer").
                NotNull(format, "format");

            Console.ForegroundColor = color;
            writer.WriteLine(format, args);
            Console.ResetColor();
        }

        #endregion
    }

    class Program
    {
        static Regex ProxyExp = new Regex(@"(\d+\.\d+\.\d+\.\d+)\s+(\d+)");

        public static string GetHtml(string url, WebProxy proxy = null)
        {
            WebClient client = new WebClient();
            if (proxy != null)
            {
                client.Proxy = proxy;
            }
            return client.DownloadString(url);
        }

        public static void getProxy()
        {
            var listUrls = new string[] { "http://sooip.cn/QQdailiIP/", "http://sooip.cn/QQdailiIP/", "http://sooip.cn/zuixindaili/" };
            var proxyes = new List<string>();
            foreach (var listUrl in listUrls)
            {
                var list = GetHtml(listUrl);

                var regex = new Regex("href=\"(/zuixindaili/[^\"]+)\"");

                var listPages = regex.Matches(list);

                foreach (Match listPage in listPages)
                {
                    try
                    {
                        var html = GetHtml("http://sooip.cn" + listPage.Groups[1].Value);
                        var results = ProxyExp.Matches(html);
                        foreach (Match match in results)
                        {
                            if (!proxyes.Contains(match.Groups[1].Value))
                            {
                                proxyes.Add(match.Groups[1].Value);
                                new Thread(new ParameterizedThreadStart(yanzhen)).Start(new ProxyModel
                                {
                                    IP = match.Groups[1].Value,
                                    Port = int.Parse(match.Groups[2].Value)
                                });
                            }
                            //yanzhen(match.Groups[1].Value, int.Parse(match.Groups[2].Value));
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        public static List<ProxyModel> Proxyes = new List<ProxyModel>();

        static object locker = new object();

        public static void yanzhen(object o)
        {
            ProxyModel model = (ProxyModel)o;
            var str = model.IP;
            //Console.WriteLine("验证" + str + "中");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            try
            {
                WebProxy proxyObject = new WebProxy(str, model.Port);//str为IP地址 port为端口号
                HttpWebRequest Req = (HttpWebRequest)WebRequest.Create("http://zhidao.baidu.com/question/3911114.html");
                Req.Proxy = proxyObject; //设置代理 
                HttpWebResponse Resp = (HttpWebResponse)Req.GetResponse();
                Encoding code = Encoding.GetEncoding("gb2312");
                using (StreamReader sr = new StreamReader(Resp.GetResponseStream(), code))
                {
                    if (sr != null)
                    {
                        try
                        {
                            str = sr.ReadToEnd();
                            if (str.Contains("百度知道"))
                            {

                                Proxyes.Add(model);
                                timer.Stop();

                                if (timer.Elapsed.TotalSeconds < 1)
                                {
                                    Console.WriteLine(model.IP + "验证成功,耗时" + timer.Elapsed.TotalSeconds);
                                    lock (locker)
                                    {
                                        File.WriteAllText("proxy.txt", string.Join("\r\n", Proxyes.Select(p => p.IP + " " + p.Port).ToArray()));
                                    }
                                }
                            }
                        }
                        catch
                        {
                            //Console.WriteLine(model.IP + "验证失败！");
                        }
                        finally
                        {
                            sr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine(model.IP + "验证失败！");
            }
        }
        public static int start = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Start"]);

        public static int end = int.Parse(System.Configuration.ConfigurationManager.AppSettings["End"]);

        public static string GetTaskUrl()
        {
            lock (locker)
            {
                if (start > end)
                {
                    File.WriteAllText("index.bin", start.ToString());
                    return string.Format("http://zhidao.baidu.com/question/{0}.html", start--);
                }
                return "";
            }
        }

        public static int proxyIndex = 0;

        public static WebProxy GetProxy()
        {
            lock (locker)
            {
                if (Proxyes.Count > 0)
                {
                    if (proxyIndex < Proxyes.Count)
                    {
                        return new WebProxy(Proxyes[proxyIndex].IP, Proxyes[proxyIndex++].Port);
                    }
                    else
                    {
                        proxyIndex = 0;
                        return new WebProxy(Proxyes[proxyIndex].IP, Proxyes[proxyIndex++].Port);
                    }
                }
                return null;
            }
        }

        public static int ThreadCount = 0;

        public static int ErrorSleep = int.Parse(System.Configuration.ConfigurationManager.AppSettings["ErrorSleep"]);

        public static int NomalSleep = int.Parse(System.Configuration.ConfigurationManager.AppSettings["NomalSleep"]);

        public static int MaxThread = int.Parse(System.Configuration.ConfigurationManager.AppSettings["MaxThread"]);

        public static int Count = 0;

        static Stopwatch timer;

        #region mbnAPI
        //class to keep global variables
        //class Global
        //{
        //    public static IMbnRadio g_IMbnRadio = null;
        //}

        ////implement the required IMbnXXXEvents
        //class RadioEventsSink : IMbnRadioEvents
        //{
        //    public RadioEventsSink() { }
        //    public void OnRadioStateChange(IMbnRadio newInterface)
        //    {

        //    }

        //    public void OnSetSoftwareRadioStateComplete(IMbnRadio newInterface, uint requestID, int Status)
        //    {
        //        Global.g_IMbnRadio = newInterface;
        //    }
        //}
        #endregion

        static void Main(string[] args)
        {
            ParameterExpression paraLeft = Expression.Parameter(typeof(int), "a");
            ParameterExpression paraRight = Expression.Parameter(typeof(int), "b");

            BinaryExpression binaryLeft = Expression.Multiply(paraLeft, paraRight);
            ConstantExpression conRight = Expression.Constant(2, typeof(int));

            BinaryExpression binaryBody = Expression.Add(binaryLeft, conRight);

            LambdaExpression lambda =
                Expression.Lambda<Func<int, int, int>>(binaryBody, paraLeft, paraRight);

            Console.WriteLine(lambda.ToString());


            //Console.Read();

            Expression<Func<FetchResult, bool>> where = (t) => t.Question.Url != "";

            Console.WriteLine(Never.ExpressionProvider.ToSql(where));

            #region mbnAPI
            //MbnConnectionManager mbnConnMgr =
            //new MbnConnectionManager();
            //IMbnConnectionManager connMgr =
            //(IMbnConnectionManager)mbnConnMgr;

            //try
            //{
            //    // enumerate the connections using GetConnections   
            //    IMbnConnection[] arrConn =
            //    (IMbnConnection[])connMgr.GetConnections();


            //    foreach (IMbnConnection conn in arrConn)
            //    {
            //        uint requestId;
            //        conn.Connect(MBN_CONNECTION_MODE.MBN_CONNECTION_MODE_PROFILE, "",out requestId);
            //        Console.WriteLine("Connection ID = " + conn.ConnectionID);
            //    }
            //}

            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    throw e;
            //}
            #endregion


            //getProxy();

            timer = new Stopwatch();
            timer.Start();

            //int start = 493326325;

            if (System.IO.File.Exists("index.bin"))
            {
                start = int.Parse(System.IO.File.ReadAllText("index.bin"));
            }

            for (var i = 0; i < MaxThread; i++)
            {
                new Thread(DoWork).Start();

                Thread.Sleep(1000);
                //DoWork();
            }

            //DoWork(false);
            // new Thread(DoWork).Start();

            Console.ReadLine();
            //while (start > end)
            //{
            //    try
            //    {

            //    }
            //    catch (Exception ex)
            //    {
            //        Console.Write(ex.Message);
            //        Console.WriteLine();
            //    }
            //    finally
            //    {
            //        start--;
            //        File.WriteAllText("index.bin", start.ToString());
            //        Thread.Sleep(NomalSleep);
            //    }
            //}
        }

        private static void DoWork(object state = null)
        {
            while (true)
            {
                var useProxy = state != null;

                try
                {
                    var url = GetTaskUrl();

                    if (url == "")
                    {
                        break;
                    }


                    WebProxy proxy = useProxy ? GetProxy() : null;

                    var html = useProxy ? GetHtml(url, proxy) : GetHtml(url);

                    BadiduProcessor procesor = new BadiduProcessor();

                    var result = procesor.Fetch(html, start.ToString(), proxy);

                    Console.Out.WriteLine(ConsoleColor.DarkYellow, "Url: {0}", url);

                    if (html.Contains("您的访问出错了"))
                    {
                        Console.WriteLine("访问出错了,暂停1000s");
                        // todo 重拨号
                        Thread.Sleep(ErrorSleep);
                        continue;
                    }

                    var fetchResult = result;
                    if (fetchResult != null)
                    {

                        if (fetchResult.Question != null && fetchResult.Question.Title != "")
                        {
                            CQASaver.SaveFetchResult(fetchResult);

                            Count++;

                            Console.WriteLine("已累积抓取" + Count + " " + timer.Elapsed.ToString());

                            if (fetchResult.User == null)
                            {
                                Console.Out.WriteLine(ConsoleColor.DarkGreen, "问题：{0}", fetchResult.Question.Title);
                            }
                            else
                            {
                                Console.Out.WriteLine(ConsoleColor.DarkGreen, "用户：{0}", fetchResult.User.ToString());
                            }
                        }
                        else
                        {
                        }

                    }
                    Console.Out.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (!useProxy)
                    {
                        //Thread.Sleep(NomalSleep);
                    }
                }
            }
        }
    }

    public class BadiduProcessor
    {
        public static Regex IdRegex = new Regex("(\\d+)\\.html");

        public static Dictionary<string, bool> UserCache = new Dictionary<string, bool>();


        public static string GetHtml(string url, WebProxy proxy = null)
        {
            WebClient client = new WebClient();
            if (proxy != null)
            {
                client.Proxy = proxy;
            }
            return client.DownloadString(url);
        }

        public FetchResult Fetch(string html, string id, WebProxy proxy)
        {

            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            //(HtmlDocument)propertyBag["HtmlDoc"].Value;
            htmlDoc.LoadHtml(html);

            return ExtractQuestion(htmlDoc, html, id, proxy);

        }

        static bool isUser3G = false;


        ///// <summary>
        ///// 重新连接网络
        ///// </summary>
        //private static void ReConnectNetWork()
        //{
        //    if (!isUser3G)
        //    {
        //        Console.WriteLine("访问出错了， 暂停30分钟。。。");

        //        // 暂停30分钟
        //        Thread.Sleep(1000 * 60 * 30);
        //    }
        //    else
        //    {
        //        RASDisplay ras = new RASDisplay();
        //        Console.WriteLine("等待重拨号中。。。");
        //        ras.Disconnect();
        //        Thread.Sleep(10000);
        //        Console.WriteLine("重新拨号中。。。");
        //        ras.Connect("3G");
        //        Thread.Sleep(1000);
        //        IPAddress[] arrIPAddresses = Dns.GetHostAddresses(Dns.GetHostName());
        //        foreach (IPAddress ip in arrIPAddresses)
        //        {
        //            if (ip.AddressFamily.Equals(AddressFamily.InterNetwork))
        //            {
        //                Console.WriteLine("新ip" + ip.ToString());
        //            }
        //        }
        //    }
        //}

        //        private static void ExtractUser(string html)
        //        {
        //            /*
        //            姓名：
        ////*[@id="1000001"]/div[2]/div[1]/h2

        //采纳率：//*[@id="1000003"]/div[2]/ul/li[1]/b

        //回答数：//*[@id="1000003"]/div[2]/ul/li[2]/b

        //被赞同数：//*[@id="1000003"]/div[2]/ul/li[3]/b

        //擅长领域：
        ////*[@id="1000003"]/div[3]/ul
        //            */

        //            var user = new User()
        //            {
        //                KnowedgeType = KnowedgeType.BaiduZhidao
        //            };

        //            // html = html.Substring("\"tplContent\":\"", "});");

        //            var result = html.SubstringAll("<b class=zhidao-basic-num>", "<\\/b>");

        //            if (result.Count == 6)
        //            {
        //                //html = html.Replace("\\x22", "\"");
        //                user.AdoptionRate = double.Parse(result[0].Replace("%", ""));
        //                // <li class=first> <span>回答采纳率<\/span> <b class=zhidao-basic-num>0%<\/b>  <li> <span>回答数<\/span> <b class=zhidao-basic-num>18<\/b>  <li> <span>回答被赞同数<\/span> <b class=zhidao-basic-num>3<\/b>  <li> <span>经验值<\/span> <b class=zhidao-basic-num>95<\/b>  <li> <span>财富值<\/span> <b class=zhidao-basic-num>90<\/b>  <li> <span>提问数<\/span> <b class=zhidao-basic-num>1<\/b>
        //                user.AnwserCount = int.Parse(result[1]);
        //                user.AdoptionCount = int.Parse(result[2]);
        //            }
        //            var area = html.Substring("<label>擅长领域：<\\/label>", "<\\/ul>").HtmToTxt().Replace("\\", "").Trim();
        //            user.ExpertArea = area;

        //            user.UserStage = html.Substring("<h2 class=\\x22headline yahei\\x22>他的知道形象<\\/h2>", "<\\/div>").HtmToTxt().Trim();
        //            //Console.WriteLine(html);

        //            user.UserName = html.Substring("<title>", "的百度个人主页</title>");

        //            Console.WriteLine(user.ToString());
        //        }

        private FetchResult ExtractQuestion(HtmlDocument htmlDoc, string html, string id, WebProxy proxy)
        {

            // User

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
            question.Id = id;
            question.Url = "http://zhidao.baidu.com/question/" + id + ".html";
            question.ViewCount = int.Parse(GetHtml("http://cp.zhidao.baidu.com/v.php?q=" + question.Id + "&callback=", proxy).Trim());
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
                    + string.Join(",", answerIds.Select(a => "{%22thread_id%22:" + a + ",%22reply_id%22:0,%22query_mask%22:999}").ToArray())
                    + "]&callback=bd__cbs__ds972m";

                //bd__cbs__ds972m({"res":[{"err_no":0,"err_msg":"success","total_count":"47","thread_id":2458732005,"reply_id":0},{"err_no":0,"err_msg":"success","total_count":"4","thread_id":2458558657,"reply_id":0},{"err_no":0,"err_msg":"success","total_count":"1","thread_id":2458568821,"reply_id":0}]})

                var regex = new Regex("total_count\":\"(\\d+)\"");

                var commentApi = GetHtml(commentUrl, proxy);
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

            var userLinks = htmlDoc.DocumentNode.SelectNodes("//a[starts-with(@href,'http://www.baidu.com/p/')]");

            // "<a alog-action=\"qb-username\" log=\"replyer.username.click\" href=\"http://www.baidu.com/p/一帆风顺h3?from=zhidao\" target=\"_blank\" uid=\"ae48d2bbb7abb7e7cbb368339b1b\" uname=\"一帆风顺h3\" class=\"user-name\">一帆风顺h3</a>"
            if (userLinks != null && userLinks.Count > 0)
            {
                // 分析用户
                foreach (HtmlNode userLink in userLinks)
                {
                    var userName = userLink.InnerText;
                    if (!UserCache.ContainsKey(userName) && !CQASaver.IsUserExist(userName))
                    {
                        var url = userLink.Attributes["href"].Value;

                        var userHtml = Program.GetHtml(url, proxy);

                        var user = ExtractUser(userHtml);

                        CQASaver.SaveFetchResult(user);

                        UserCache.Add(userName, true);
                    }
                }
            }

            var fetchResult = new FetchResult
            {
                Question = question,
                QuestionAnswer = questionAndAnswer,
                Answers = anwsers
            };


            return fetchResult;

        }

        private static FetchResult ExtractUser(string html)
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

            FetchResult fetch = new FetchResult();
            fetch.User = user;
            return fetch;
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
