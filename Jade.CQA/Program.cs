using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jade.CQA
{
    class Program
    {
        static void Main(string[] args)
        {
            WebDownloaderV2 downloader = new WebDownloaderV2();
            var result = downloader.Download(new CrawlStep(new Uri("http://www.baidu.com"), 0), null, DownloadMethod.GET);
            Console.WriteLine(result.Text);
            Console.ReadLine();
        }
    }
}
