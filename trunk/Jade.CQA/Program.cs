﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Jade.CQA.Robot;
using Jade.CQA.Robot.Extensions;
using Jade.CQA.Robot.Services;
using Jade.CQA.Robot.Interfaces;
using System.Text.RegularExpressions;
using System.Net;
using Jade.CQA.KnowedegProcesser;
using System.Globalization;
using System.IO;
using Jade.CQA.Robot.Utils;
using System.Threading;
using Jade.CQA.Model;
using Jade.CQA.KnowedegProcesser.DataSave;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net.Sockets;

namespace Jade.CQA
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

    internal class DumperStep : IPipelineStep
    {
        #region IPipelineStep Members

        public static Regex IdRegex = new Regex("(\\d+)\\.html");

        public static int Count = 0;

        /// <summary>
        /// </summary>
        /// <param name = "crawler">
        /// 	The crawler.
        /// </param>
        /// <param name = "propertyBag">
        /// 	The property bag.
        /// </param>
        public void Process(Crawler crawler, PropertyBag propertyBag)
        {
            CultureInfo contentCulture = (CultureInfo)propertyBag["LanguageCulture"].Value;
            string cultureDisplayValue = "N/A";
            if (!contentCulture.IsNull())
            {
                cultureDisplayValue = contentCulture.DisplayName;
            }

            lock (this)
            {
                Console.Out.WriteLine(ConsoleColor.DarkYellow, "Url: {0}", propertyBag.Step.Uri);
                //Console.Out.WriteLine(ConsoleColor.DarkGreen, "\tContent type: {0}", propertyBag.ContentType);
                //Console.Out.WriteLine(ConsoleColor.DarkGreen, "\tContent length: {0}",
                //    propertyBag.Text.IsNull() ? 0 : propertyBag.Text.Length);
                Console.Out.WriteLine(ConsoleColor.DarkGreen, "Depth: {0} ThreadId: {1} Thread Count: {2} Download Time:{3}s", propertyBag.Step.Depth, Thread.CurrentThread.ManagedThreadId, crawler.ThreadsInUse, propertyBag.DownloadTime.TotalSeconds);
                //Console.Out.WriteLine(ConsoleColor.DarkGreen, "\tCulture: {0}", cultureDisplayValue);

                var fetchResult = (FetchResult)propertyBag["fetchResult"].Value;
                if (fetchResult != null)
                {
                    // CQASaver.SaveFetchResult(fetchResult);

                    Count++;

                    Console.WriteLine("已累积抓取" + Count + "，耗时" + crawler.ElapsedTime.ToString());

                    if (fetchResult.User == null)
                    {
                        Console.Out.WriteLine(ConsoleColor.DarkGreen, "问题：{0}", fetchResult.Question.Title);
                        //Console.Out.WriteLine(ConsoleColor.Red, "{0}", "问题与答案：");
                        // Console.Out.WriteLine(ConsoleColor.DarkGreen, "{0}", fetchResult.QuestionAnswer);
                        // Console.Out.WriteLine(ConsoleColor.Red, "{0}", "答案：");
                        //foreach (var anwser in fetchResult.Answers)
                        //{
                        //    Console.Out.WriteLine(ConsoleColor.DarkGreen, "{0}", anwser);
                        //}
                    }
                    else
                    {
                        Console.Out.WriteLine(ConsoleColor.DarkGreen, "用户：{0}", fetchResult.User.ToString());
                    }
                }
                Console.Out.WriteLine();
            }
        }

        #endregion
    }



    internal class BaiduUrlFilter : IFilter
    {

        #region IFilter 成员

        public bool Match(Uri uri, CrawlStep referrer)
        {
            if (uri.AbsoluteUri == "http://zhidao.baidu.com/")
            {
                return true;
            }

            if (uri.AbsoluteUri.Contains("#"))
            {
                return false;
            }
            if (
                uri.AbsoluteUri.Contains("/question/")
                || uri.AbsoluteUri.Contains("/browse/") || uri.AbsoluteUri.Contains("/p/")
                )
            {
                return true;
            }
            return false;
        }

        #endregion
    }

    class Program
    {
        static Regex ProxyExp = new Regex(@"(\d+\.\d+\.\d+\.\d+)\s+(\d+)");

        public static string GetHtml(string url)
        {
            WebClient client = new WebClient();
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

        public static IFilter[] ExtensionsToSkip = new[]
			{
				(RegexFilter)new Regex(@"(\.jpg|\.css|\.js|\.gif|\.jpeg|\.png|\.ico)",
					RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase)
            };

        public static IFilter[] ExtensionsMustContain = new[]
			{
				new BaiduUrlFilter()
            };
        [DllImport("wininet.dll")]
        private extern static bool InternetAutodial(int dwFlags, System.IntPtr hwndParent);

        [DllImport("wininet.dll")]
        private extern static bool InternetAutodialHangup(int dwReserved);

        static IPAddress[] GetAddresses(AddressFamily af)
        {
            System.Net.IPHostEntry _IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            return (from i in _IPHostEntry.AddressList where i.AddressFamily == af select i).ToArray();
        }

        public static IPEndPoint BindIPEndPointCallback(ServicePoint servicePoint, IPEndPoint remoteEndPoint, int retryCount)
        {
            List<IPEndPoint> ipep = new List<IPEndPoint>();
            foreach (var i in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (var ua in i.GetIPProperties().UnicastAddresses)
                    ipep.Add(new IPEndPoint(ua.Address, 0));
            }
            return new IPEndPoint(ipep[1].Address, ipep[1].Port);
        }

        public static IPEndPoint BindIPEndPointCallback2(ServicePoint servicePoint, IPEndPoint remoteEndPoint, int retryCount)
        {
            Console.WriteLine("BindIPEndpoint called");
            return new IPEndPoint(IPAddress.Parse("192.168.28.75"), 0);
        }

        public static IPEndPoint BindIPEndPointCallback3(ServicePoint servicePoint, IPEndPoint remoteEndPoint, int retryCount)
        {
            Console.WriteLine("BindIPEndpoint called");
            return new IPEndPoint(IPAddress.Parse("36.4.196.164"), 0);
        }


        /// <summary>
        /// 是否启用proxy
        /// </summary>
        static bool userProxy = false;

        static void Main(string[] args)
        {

            // testip();


            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            if (userProxy)
            {
                Console.Out.WriteLine("获取代理中....");

                getProxy();

                Console.Out.WriteLine("等待5秒开始抓取");

                Thread.Sleep(5000);
            }

            //if (File.Exists("proxy.txt"))
            //{
            //    Proxyes.AddRange(File.ReadAllLines("proxy.txt").ToList().Select(l =>
            //    {
            //        var lines = l.Split(' ');
            //        return new ProxyModel { IP = lines[0], Port = int.Parse(lines[1]) };
            //    }));
            //}
            //else
            //{
            //Console.Out.WriteLine("获取代理中....");
            //getProxy();

            //Console.Read();
            //}

            // Remove limits from Service Point Manager
            ServicePointManager.MaxServicePoints = 999999;
            ServicePointManager.DefaultConnectionLimit = 999999;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            ServicePointManager.CheckCertificateRevocationList = true;
            ServicePointManager.EnableDnsRoundRobin = true;

            Console.Out.WriteLine("CQA Crawler");

            StartCrawler();
        }

        private static void testip()
        {

            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader sr;
            string str;

            request = (HttpWebRequest)WebRequest.Create("http://iframe.ip138.com/ic.asp");
            request.KeepAlive = false;
            request.ServicePoint.BindIPEndPointDelegate = new BindIPEndPoint(BindIPEndPointCallback3);
            request.ServicePoint.ConnectionLeaseTimeout = 0;
            response = (HttpWebResponse)request.GetResponse();
            sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312"));
            str = sr.ReadToEnd();
            Console.WriteLine(str);
            test1();
        }

        private static void test1()
        {
            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader sr;
            string str;
            request = (HttpWebRequest)WebRequest.Create("http://iframe.ip138.com/ic.asp");
            request.KeepAlive = false;
            request.ServicePoint.BindIPEndPointDelegate = new BindIPEndPoint(BindIPEndPointCallback2);
            request.ServicePoint.ConnectionLeaseTimeout = 0;
            response = (HttpWebResponse)request.GetResponse();
            sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312"));
            str = sr.ReadToEnd();
            Console.WriteLine(str);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject);
            Console.ReadLine();
        }

        private static void StartCrawler()
        {
            using (Crawler c = new Crawler(new Uri("http://zhidao.baidu.com"),
                new BadiduDocumentProcessor(), new DumperStep()
                )// Process html)
            {
                IsUserProxy = userProxy,
                //Proxyes = Proxyes.Select(p => new WebProxy(p.IP, p.Port)).ToList(),
                // Custom step to visualize crawl

                DownloadRetryCount = 0,
                MaximumThreadCount = 20,
                MaximumCrawlDepth = 8,
                UserAgent = "Sogou web spider/3.0(+http://www.sogou.com/docs/help/webmasters.htm#07)",
                //IncludeFilter = Program.ExtensionsMustContain
                //ExcludeFilter = Program.ExtensionsToSkip,
            })
            {
                c.CrawlFinished += new EventHandler<Robot.Event.CrawlFinishedEventArgs>(c_CrawlFinished);
                // Begin crawl
                c.Crawl();
            }
        }

        static void c_CrawlFinished(object sender, Robot.Event.CrawlFinishedEventArgs e)
        {
            StartCrawler();
        }
    }
}
