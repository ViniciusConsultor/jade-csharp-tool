using System;
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
                Console.Out.WriteLine(ConsoleColor.Gray, "Url: {0}", propertyBag.Step.Uri);
                //Console.Out.WriteLine(ConsoleColor.DarkGreen, "\tContent type: {0}", propertyBag.ContentType);
                //Console.Out.WriteLine(ConsoleColor.DarkGreen, "\tContent length: {0}",
                //    propertyBag.Text.IsNull() ? 0 : propertyBag.Text.Length);
                Console.Out.WriteLine(ConsoleColor.DarkGreen, "\tDepth: {0}", propertyBag.Step.Depth);
                //Console.Out.WriteLine(ConsoleColor.DarkGreen, "\tCulture: {0}", cultureDisplayValue);
                //Console.Out.WriteLine(ConsoleColor.DarkGreen, "\tThreadId: {0}", Thread.CurrentThread.ManagedThreadId);
                //Console.Out.WriteLine(ConsoleColor.DarkGreen, "\tThread Count: {0}", crawler.ThreadsInUse);

                var fetchResult = (FetchResult)propertyBag["fetchResult"].Value;
                if (fetchResult != null)
                {
                    CQASaver.SaveFetchResult(fetchResult);

                    if (fetchResult.User == null)
                    {
                        Console.Out.WriteLine(ConsoleColor.Red, "{0}", "问题：");
                        Console.Out.WriteLine(ConsoleColor.DarkGreen, "{0}", fetchResult.Question.Title);
                        Cache.filter.AddContentPage(fetchResult.Question.Id);
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
        public static IFilter[] ExtensionsToSkip = new[]
			{
				(RegexFilter)new Regex(@"(\.jpg|\.css|\.js|\.gif|\.jpeg|\.png|\.ico)",
					RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase)
            };

        public static IFilter[] ExtensionsMustContain = new[]
			{
				new BaiduUrlFilter()
            };

        static void Main(string[] args)
        {
            //WebDownloaderV2 downloader = new WebDownloaderV2();
            //var result = downloader.Download(new CrawlStep(new Uri("http://www.baidu.com"), 0), null, DownloadMethod.GET);
            //Console.WriteLine(result.Text);
            //Console.ReadLine();
            // Remove limits from Service Point Manager
            ServicePointManager.MaxServicePoints = 999999;
            ServicePointManager.DefaultConnectionLimit = 999999;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            ServicePointManager.CheckCertificateRevocationList = true;
            ServicePointManager.EnableDnsRoundRobin = true;

            Console.Out.WriteLine("Simple crawl demo");

            // Setup crawler to crawl http://ncrawler.codeplex.com
            // with 1 thread adhering to robot rules, and maximum depth
            // of 2 with 4 pipeline steps:
            //	* Step 1 - The Html Processor, parses and extracts links, text and more from html
            //  * Step 2 - Processes PDF files, extracting text
            //  * Step 3 - Try to determine language based on page, based on text extraction, using google language detection
            //  * Step 4 - Dump the information to the console, this is a custom step, see the DumperStep class
            using (Crawler c = new Crawler(new Uri("http://zhidao.baidu.com"),
                new BadiduDocumentProcessor(), new DumperStep()
                )// Process html)
            {
                // Custom step to visualize crawl
                MaximumThreadCount = 1,
                MaximumCrawlDepth = 10,
                UserAgent = "Sogou web spider/3.0(+http://www.sogou.com/docs/help/webmasters.htm#07)",
                IncludeFilter = Program.ExtensionsMustContain
                //ExcludeFilter = Program.ExtensionsToSkip,
            })
            {
                // Begin crawl
                c.Crawl();
            }
        }
    }
}

