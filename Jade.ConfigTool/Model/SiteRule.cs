using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;

namespace Jade.Model
{
    /// <summary>
    /// 任务规则
    /// </summary>
    public class SiteRule : Jade.ConfigTool.Model.HtmlFecter, XmlDatabase.Core.IXmlStoreItem, Jade.IUrlFilter
    {
        /// <summary>
        /// 创建默认规则
        /// </summary>
        /// <returns></returns>
        public static SiteRule CreateDefaultRule()
        {
            var rule = new SiteRule()
            {
                ColumnUrlSelector = new UrlSelector(),
                ContentUrlSelector = new UrlSelector(),
                LisPageUrlSelector = new UrlSelector(),
                ListPagePagerUrlSelector = new UrlSelector()
            };

            rule.ItemRules.AddRange(new List<ItemRule>() { 
                new ItemRule() {
                CloumnName = "Title",
                ItemName="标题",
                FetchType = ItemFetchType.XPath,
                IsDownloadPic = false,
                XMLPathType = XMLPathType.InnerText,
                XPath="//h1",
                AnotherXPath="//title",
                XMLPathSelectType = XMLPathSelectType.OnlyOne      
                },  new ItemRule() {
                CloumnName = "SubTitle",
                ItemName="副标题",
                FetchType = ItemFetchType.XPath,
                IsDownloadPic = false,
                XPath="",
                },  new ItemRule() {
                CloumnName = "Keywords",
                ItemName="关键字",
                FetchType = ItemFetchType.XPath,
                IsDownloadPic = false,
                XPath="",  
                }, 
              new ItemRule() {
                CloumnName = "Source",
                ItemName="来源",
                FetchType = ItemFetchType.XPath,
                IsDownloadPic = false,
                XMLPathType = XMLPathType.InnerText,
                XPath="",
                XMLPathSelectType = XMLPathSelectType.OnlyOne      
                }, new ItemRule() {
                CloumnName = "Time",
                ItemName="时间",
                FetchType = ItemFetchType.UserDiy,
                IsDownloadPic = false,
               DiyType= UserDiyType.Datetime,
               DateTimeFormatString="yyyy-MM-dd hh:mm"
                }, new ItemRule() {
                CloumnName = "Content",
                ItemName="内容",
                FetchType = ItemFetchType.XPath,
                IsDownloadPic = true,
                XMLPathType = XMLPathType.InnerTextWithPic,
                XPath="//body",
                XMLPathSelectType = XMLPathSelectType.OnlyOne      
                }, new ItemRule() {
                CloumnName = "Summary",
                ItemName="摘要",
                FetchType = ItemFetchType.XPath,
                IsDownloadPic = false,
                XMLPathType = XMLPathType.InnerText,
                XPath="//h1",
                XMLPathSelectType = XMLPathSelectType.OnlyOne      
                }, new ItemRule() {
                CloumnName = "Other",
                ItemName="其他",
                FetchType = ItemFetchType.XPath,
                IsDownloadPic = false,
                XMLPathType = XMLPathType.InnerText,
                XPath="",
                XMLPathSelectType = XMLPathSelectType.OnlyOne      
                }
            });
            return rule;
        }

        /// <summary>
        /// 分类ID
        /// </summary>
        public int CategoryID { get; set; }

        public SiteRule()
        {
            this.IndexPage = "";
            this.SiteExractMode = Model.SiteExractMode.ListContent;
            this.CategoryID = 0;
            this.Cookie = "";
            this.Encoding = "gb2312";
            this.ExcludePart = "";
            this.ForTestUrl = "";
            this.HttpMethod = "GET";
            this.HttpPostData = "";
            this.IncludePart = "";
            this.ItemRules = new List<ItemRule>();
            this.ListEncoding = "gb2312";
            this.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; 4399Box.1272; 4399Box.1272)";
            this.TableName = "NewsTab";
            this.Depth = 1;
            this.ListPageType = Model.ListPageType.Html;
            this.EnableAutoRun = false;
            this.AutoRunInterval = 60;
            this.IconImage = "favicon.ico";
            ColumnUrlSelector = new UrlSelector();
            ContentUrlSelector = new UrlSelector();
            LisPageUrlSelector = new UrlSelector();
            ListPagePagerUrlSelector = new UrlSelector();
        }

        public SiteExractMode SiteExractMode
        {
            get;
            set;
        }

        /// <summary>
        /// 索引页面
        /// </summary>
        public string IndexPage
        {
            get;
            set;
        }

        /// <summary>
        /// 栏页面
        /// </summary>
        public string CloumnPage
        {
            get;
            set;
        }

        /// <summary>
        /// 栏页面
        /// </summary>
        public string ListPage
        {
            get;
            set;
        }

        /// <summary>
        /// 是否强制拥有同一域名
        /// </summary>
        public bool WithSameDomain
        {
            get;
            set;
        }


        /// <summary>
        /// 栏目XPATH(选择栏目的xpath)
        /// </summary>
        public UrlSelector ColumnUrlSelector
        {
            get;
            set;
        }

        /// <summary>
        /// 列表页XPATH(在首页或者栏目页面选择列表页面的xpath)
        /// </summary>
        public UrlSelector LisPageUrlSelector
        {
            get;
            set;
        }

        /// <summary>
        /// 列表页分页链接
        /// </summary>
        public UrlSelector ListPagePagerUrlSelector
        {
            get;
            set;
        }

        /// <summary>
        /// 内容页面选择器
        /// </summary>
        public UrlSelector ContentUrlSelector
        {
            get;
            set;
        }

        /// <summary>
        /// 图标
        /// </summary>
        public string IconImage
        {
            get;
            set;
        }

        /// <summary>
        /// 编码ID
        /// </summary>
        public int SiteRuleId
        {
            get;
            set;
        }

        /// <summary>
        /// 站点名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 列表页类型
        /// </summary>
        public ListPageType ListPageType
        {
            get;
            set;
        }

        /// <summary>
        /// 自定义内容页地址
        /// </summary>
        public string DiyContentPageUrl
        {
            get;
            set;
        }

        ///// <summary>
        ///// 网页编码
        ///// </summary>
        //public string Encoding
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// GET OR POST
        ///// </summary>
        //public string HttpMethod
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// POST 数据
        ///// </summary>
        //public string HttpPostData
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// Cookie数据
        ///// </summary>
        //public string Cookie
        //{
        //    get;
        //    set;
        //}


        /// <summary>
        /// 深度(1 所给的页面为列表页  2所给的页面为主业，采集到得页面时列表页）
        /// </summary>
        public int Depth
        {
            get;
            set;
        }

        //public string UserAgent
        //{
        //    get;
        //    set;
        //}


        //public string Referer
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// 测试页URL
        /// </summary>
        public string ForTestUrl
        {
            get;
            set;
        }

        ///// <summary>
        ///// 列表页编码
        ///// </summary>
        //public string ListEncoding
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// 规则
        /// </summary>
        public List<ItemRule> ItemRules
        {
            get;
            set;
        }


        /// <summary>
        /// 存储的数据表
        /// </summary>
        public string TableName { get; set; }


        /// <summary>
        /// 是否自动运行
        /// </summary>
        public bool EnableAutoRun
        {
            get;
            set;
        }

        /// <summary>
        /// 自动运行时间间隔
        /// </summary>
        public int AutoRunInterval
        {
            get;
            set;
        }

        #region IXmlStoreItem 成员

        public object GetPrimaryKey()
        {
            return this.SiteRuleId;
        }

        #endregion

        #region IUrlFilter 成员

        public string IncludePart
        {
            get;
            set;
        }

        public string ExcludePart
        {
            get;
            set;
        }

        #endregion

        public UrlSet ProcessUrlSet(UrlSet set, UrlSelector selector, bool processContent = true, bool remainListPage = false)
        {
            var result = new UrlSet();
            if (remainListPage)
            {
                result.ListPages.AddRange(set.ListPages);
            }
            if (processContent)
            {
                result.ContetnPages.AddRange(set.ContetnPages);
                // 内容页自定义项目
                if (!string.IsNullOrEmpty(selector.ContentPageUrlSelector.DiyContentPageUrl))
                {
                    string[] urls = selector.ContentPageUrlSelector.DiyContentPageUrl.Split(new string[] { BaseConfig.UrlSeparator }, StringSplitOptions.RemoveEmptyEntries);
                    if (urls != null && urls.Length > 0)
                    {
                        foreach (string url in urls)
                        {
                            result.ContetnPages.AddRange(ExtractUrl.ParseUrlFromParameter(url));
                        }
                    }
                }
            }

            // 列表页自定义项目
            if (!string.IsNullOrEmpty(selector.DiyContentPageUrl))
            {
                string[] urls = selector.DiyContentPageUrl.Split(new string[] { BaseConfig.UrlSeparator }, StringSplitOptions.RemoveEmptyEntries);
                if (urls != null && urls.Length > 0)
                {
                    foreach (string url in urls)
                    {
                        result.ListPages.AddRange(ExtractUrl.ParseUrlFromParameter(url));
                    }
                }
            }


            // 处理列表页
            foreach (var listUrl in set.ListPages)
            {
                var html = this.FetchListPageHtml(listUrl);

                // 选取listPage
                selector.XPathList.ForEach(xpath =>
                {
                    result.ListPages.AddRange(selector.RepairUrls(xpath.ExtractDataFromHtml(html), listUrl).Distinct().Where(u => !result.ListPages.Contains(u)));
                });

                if (processContent)
                {
                    // 添加内容页
                    selector.ContentPageUrlSelector.XPathList.ForEach(xpath =>
                    {
                        result.ContetnPages.AddRange(selector.RepairUrls(xpath.ExtractDataFromHtml(html), listUrl).Distinct().Where(u => !result.ContetnPages.Contains(u)));
                    });
                }

            }
            return result;
        }

        /// <summary>
        /// 获取列表页面集合
        /// </summary>
        /// <returns></returns>
        public UrlSet ProcessUrlSelector()
        {
            var result = SiteExractMode == Model.SiteExractMode.ListContent ? new UrlSet() { ListPages = new List<string> { this.Referer } } : new UrlSet() { ListPages = new List<string> { this.IndexPage } };

            switch (this.SiteExractMode)
            {
                case SiteExractMode.HomeColumnListContent:
                    result = ProcessUrlSet(result, this.ColumnUrlSelector);
                    result = ProcessUrlSet(result, this.LisPageUrlSelector);
                    break;
                case SiteExractMode.HomeListContent:
                    result = ProcessUrlSet(result, this.ColumnUrlSelector);
                    break;
            }
            ProcessUrlSet(new UrlSet(), this.ListPagePagerUrlSelector);
            ProcessUrlSet(new UrlSet(), this.ContentUrlSelector);
            return result;
        }

        /// <summary>
        ///  获取内容页
        /// </summary>
        /// <returns></returns>
        public List<string> GetContetPages()
        {
            var set = this.ProcessUrlSelector();

            // 处理最后的列表页
            return set.ContetnPages;
        }

    }


    /// <summary>
    /// Url 选择器
    /// </summary>
    public class UrlSelector : IUrlFilter
    {
        public UrlSelector()
        {
            this.ExcludePart = "#,javascript";
            XPathList = new List<XPath>();
        }

        /// <summary>
        /// 所包含的XPATH
        /// </summary>
        public List<XPath> XPathList { get; set; }

        /// <summary>
        /// 必须包含
        /// </summary>
        public string IncludePart { get; set; }

        /// <summary>
        /// 不包含
        /// </summary>
        public string ExcludePart { get; set; }

        /// <summary>
        /// 自定义内容页地址
        /// </summary>
        public string DiyContentPageUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 内容页选择器（在首页，栏目页，列表页都有内容页）
        /// </summary>
        public UrlSelector ContentPageUrlSelector
        {
            get;
            set;
        }

        /// <summary>
        /// 修复URL
        /// </summary>
        /// <param name="urls"></param>
        /// <param name="sourceUrl"></param>
        /// <returns></returns>
        public List<string> RepairUrls(List<string> urls, string sourceUrl)
        {
            ExtractUrl.RepairUrls(sourceUrl, this.IncludePart, this.ExcludePart, urls);
            return urls;
        }
    }


    public class TaskRunner
    {
        public UrlSet ProcessUrlSet(UrlSet set, UrlSelector selector)
        {
            var result = new UrlSet();
            result.ContetnPages.AddRange(set.ContetnPages);

            // 内容页自定义项目
            if (!string.IsNullOrEmpty(selector.ContentPageUrlSelector.DiyContentPageUrl))
            {
                string[] urls = selector.ContentPageUrlSelector.DiyContentPageUrl.Split(new string[] { BaseConfig.UrlSeparator }, StringSplitOptions.RemoveEmptyEntries);
                if (urls != null && urls.Length > 0)
                {
                    foreach (string url in urls)
                    {
                        result.ContetnPages.AddRange(ExtractUrl.ParseUrlFromParameter(url));
                    }
                }
            }

            // 列表页自定义项目
            if (!string.IsNullOrEmpty(selector.DiyContentPageUrl))
            {
                string[] urls = selector.DiyContentPageUrl.Split(new string[] { BaseConfig.UrlSeparator }, StringSplitOptions.RemoveEmptyEntries);
                if (urls != null && urls.Length > 0)
                {
                    foreach (string url in urls)
                    {
                        result.ListPages.AddRange(ExtractUrl.ParseUrlFromParameter(url));
                    }
                }
            }

            // 处理列表页
            foreach (var listUrl in set.ListPages)
            {
                var html = this.Rule.FetchListPageHtml(listUrl);

                // 选取listPage
                selector.XPathList.ForEach(xpath =>
                {
                    result.ListPages.AddRange(xpath.ExtractDataFromHtml(html).Distinct().Where(u => !result.ListPages.Contains(u)));
                });

                // 添加内容页
                selector.ContentPageUrlSelector.XPathList.ForEach(xpath =>
                {
                    result.ContetnPages.AddRange(xpath.ExtractDataFromHtml(html).Distinct().Where(u => !result.ContetnPages.Contains(u)));
                });

            }
            return result;
        }


        /// <summary>
        /// 获取列表页面集合
        /// </summary>
        /// <returns></returns>
        public UrlSet ProcessUrlSelector()
        {
            var result = new UrlSet();

            switch (this.Rule.SiteExractMode)
            {
                case SiteExractMode.ListContent:
                    return ProcessUrlSet(new UrlSet(), this.Rule.ListPagePagerUrlSelector);
                case SiteExractMode.HomeColumnListContent:
                    result = ProcessUrlSet(result, this.Rule.ColumnUrlSelector);
                    result = ProcessUrlSet(result, this.Rule.LisPageUrlSelector);
                    result = ProcessUrlSet(result, this.Rule.ListPagePagerUrlSelector);
                    return result;
                case SiteExractMode.HomeListContent:
                default:
                    result = ProcessUrlSet(result, this.Rule.ColumnUrlSelector);
                    result = ProcessUrlSet(result, this.Rule.ListPagePagerUrlSelector);
                    return result;
            }
        }

        public SiteRule Rule { get; set; }

        public ILog Logger { get; set; }


        public event TaskStateChange StateChange;

        public List<DownloadFile> DownloadFiles { get; set; }

        public List<string> OldUrls = new List<string>();

        public Dictionary<string, string> DownloadedPics = new Dictionary<string, string>();

        public int TotalLinks
        {
            get;
            set;
        }

        public string Status
        {
            get;
            private set;
        }

        bool isRunning = false;

        public TaskRunner(SiteRule rule, ILog logger)
        {
            Rule = rule;
            Logger = logger;
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            isForceStop = true;

            if (this.StateChange != null)
            {
                this.StateChange(this, new TaskRunnerEventArgs(new RunnerState
                {
                    CurrentCount = 100,
                    StepName = "采集完成",
                    TotalCount = 100
                }));
            }

        }

        bool isForceStop = false;

        public void Start()
        {
            if (!isRunning)
            {
                isRunning = true;

                Status = "正在启动";

                Logger.Info("[" + Rule.Name + "] 正在初始化配置,请稍等...");

                List<Uri> urls = new List<Uri>();

                //ExtractUrls(urls);


                if (urls.Count > 0)
                {
                    //DownloadDetail(urls);
                }
                else
                {
                    this.Logger.Error("[" + Rule.Name + "] 没有采集到新网址，采集完成！");
                }

                if (this.StateChange != null)
                {
                    this.StateChange(this, new TaskRunnerEventArgs(new RunnerState
                    {
                        CurrentCount = 100,
                        StepName = "采集完成",
                        TotalCount = 100
                    }));
                }

                // 
                isRunning = false;
                this.Logger.Success("[" + Rule.Name + "] 采集完成");
            }
        }

        //private void DownloadDetail(List<Uri> urls)
        //{
        //    var item = Rule;
        //    var total = urls.Count;
        //    var index = 0;

        //    if (CacheObject.IsTest)
        //        Logger.Error("[" + Rule.Name + "] 开始采集，试用版本只能采集50条");

        //    var taskImageDir = AppDomain.CurrentDomain.BaseDirectory + "\\Pic\\" + this.Rule.SiteRuleId;

        //    var max = CacheObject.IsTest ? Math.Min(50, urls.Count) : urls.Count;

        //    //foreach (var url in urls)
        //    for (var i = 0; i < max; i++)
        //    {
        //        var url = urls[i];
        //        if (!isForceStop)
        //        {
        //            var html = HtmlPicker.VisitUrl(
        //                                    url,
        //                                     item.HttpMethod,
        //                                               null,
        //                                               string.IsNullOrEmpty(item.Referer) ? null : item.Referer,
        //                                           string.IsNullOrEmpty(item.Cookie) ? null : Utility.GetCookies(item.Cookie),
        //                                           string.IsNullOrEmpty(item.UserAgent) ? null : item.UserAgent,
        //                                           string.IsNullOrEmpty(item.HttpPostData) ? null : item.HttpPostData,
        //                                               System.Text.Encoding.GetEncoding(item.Encoding));

        //            var data = CacheObject.DownloadDataDAL.Get(url.AbsoluteUri);
        //            if (data == null)
        //            {
        //                continue;
        //            }
        //            data.IsDownload = true;
        //            foreach (var itemRule in item.ItemRules)
        //            {
        //                IFetcher fetcher = new FetchItem(itemRule);
        //                var result = fetcher.Fetch(html);
        //                if (result == null)
        //                {
        //                    result = "";
        //                }
        //                switch (itemRule.CloumnName)
        //                {
        //                    case "Title":
        //                        data.Title = result;
        //                        //File.AppendAllText("user.txt", result);
        //                        break;
        //                    case "Summary":
        //                        data.Summary = result;
        //                        break;
        //                    case "Other":
        //                        data.Other = result;
        //                        break;
        //                    case "Content":
        //                        // todo 分析图片
        //                        if (itemRule.IsDownloadPic)
        //                        {
        //                            //
        //                            var pics = UrlPicker.GetImagesUrls(ref result, taskImageDir);

        //                            foreach (var key in pics)
        //                            {
        //                                var imageUrl = key.Key;
        //                                if (!imageUrl.Contains("http://"))
        //                                {
        //                                    imageUrl = ExtractUrl.RepairUrl(url.AbsoluteUri, imageUrl);
        //                                }
        //                                if (!this.DownloadedPics.ContainsKey(imageUrl))
        //                                {
        //                                    this.DownloadedPics.Add(imageUrl, key.Value);
        //                                    DownloadFile file = new DownloadFile()
        //                                    {
        //                                        TaskId = Rule.SiteRuleId,
        //                                        FileName = key.Value,
        //                                        Url = imageUrl,
        //                                        Progress = 0,
        //                                        TotalSize = 0,
        //                                        Number = DownloadFileCollection.Instance.GetDownloadFiles(Rule.SiteRuleId).Count + 1
        //                                    };
        //                                    DownloadFileCollection.Instance.AddFile(file);
        //                                }
        //                            }
        //                        }
        //                        data.Content = result;
        //                        break;
        //                    case "Time":
        //                        data.CreateTime = result;
        //                        break;
        //                    case "Source":
        //                        data.Source = result;
        //                        break;
        //                    case "SubTitle":
        //                        data.SubTitle = result;
        //                        //File.AppendAllText("item.txt", result);
        //                        break;
        //                    case "Keywords":
        //                        data.Keywords = result;
        //                        break;
        //                }
        //                //this.tbxResult.Text += string.Format("【{0}】: {1}\r\n", itemRule.ItemName, result);
        //            }
        //            DataSaver.Update(data);
        //            Logger.Success("[" + Rule.Name + "] 成功采集并更新数据到数据库【" + data.Title + "】");
        //            index++;

        //            this.RunningTaskModel.ContentCount = index + "/" + urls.Count;
        //            RunningTaskCollection.Instance.Update();

        //            if (this.StateChange != null)
        //            {
        //                this.StateChange(this, new TaskRunnerEventArgs(new RunnerState
        //                {
        //                    CurrentCount = index,
        //                    StepName = "采集内容",
        //                    TotalCount = total
        //                }));
        //            }
        //        }
        //        else
        //        {
        //            return;
        //        }
        //    }
        //}

        int picIndex = 0;

        private void CheckExtractUrlIsAvailable(List<string> seedUlrs, out List<Uri> urls)
        {

            urls = new List<Uri>();
            foreach (string sourceUrl in seedUlrs)
            {
                List<string> sourceUrls = new List<string>();
                try
                {
                    sourceUrls = ExtractUrl.ParseUrlFromParameter(sourceUrl);
                }
                catch
                {
                }
                foreach (string extractUrl in sourceUrls)
                {
                    Uri uri;
                    if (Uri.TryCreate(extractUrl, UriKind.Absolute, out uri))
                    {
                        urls.Add(uri);
                    }
                }
            }
        }

    }


    public class RunnerState
    {
        public string StepName { get; set; }

        public int TotalCount { get; set; }

        public int CurrentCount { get; set; }
    }

    /// <summary>
    /// 任务状态改变
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void TaskStateChange(object sender, TaskRunnerEventArgs e);

    public class TaskRunnerEventArgs : EventArgs
    {
        public RunnerState CurrentState
        {
            get;
            set;
        }

        public TaskRunnerEventArgs(RunnerState state)
        {
            CurrentState = state;
        }
    }

    /// <summary>
    /// 文件下载器（根据提供的DownloadFile，下载DownloadFile中URL地址)
    /// </summary>
    public partial class Downloader
    {
        public DownloadFile result;

        public delegate void DownLoadComplete(object sender, FileDownloadFinishedArgs e);

        public event DownLoadComplete OnDownLoadComplete;

        /// <summary>
        /// 下载状态变化委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DownloadStateChange(object sender, System.EventArgs e);

        /// <summary>
        /// 下载状态变化事件
        /// </summary>
        public event DownloadStateChange OnDownloadStateChange;


        public Downloader(DownloadFile result)
        {
            this.result = result;
        }

        DateTime LastTime = DateTime.Now;

        long lastByte = 0;

        public void Start()
        {
            Thread thread = new Thread(StartDownload);
            thread.Start();
        }


        delegate void Update();

        int currentIndex = 0;

        public void StartDownload()
        {
            try
            {
                //LoggerManager.Logger.ShowMsg("{0}-{1} 下载数据中 ", result.TaskName, result.Name);

                this.result.Status = 文件状态.下载数据中;

                #region 下载文件


                // 判断是否存在Flv文件，如果存在就不需要再下载了
                if (!File.Exists(result.GetLocalFilePath()))
                {

                    try
                    {
                        DownloadUrl(result.Url, result.GetLocalFilePath());
                    }
                    catch (Exception ex)
                    {
                        //LoggerManager.Logger.LogException(ex);

                    }
                }


                #endregion

                //LoggerManager.Logger.ShowMsg("{0}-{1} 已完成下载 ", result.TaskName, result.Name);
                // ffmpeg -i yourinput.flv -vn -acodec pcm_u8  output.wav
                this.result.Status = 文件状态.已完成下载;
                OnDownLoadComplete(this, new FileDownloadFinishedArgs(this.result, 文件状态.已完成下载));
                return;
            }
            catch (Exception ex)
            {
                //LoggerManager.Logger.ShowMsg("{0}-{1} 下载失败 ", result.TaskName, result.Name);
                //LoggerManager.Logger.LogException(ex);
                this.result.Status = 文件状态.下载失败;
                OnDownLoadComplete(this, new FileDownloadFinishedArgs(this.result, 文件状态.下载失败));
                return;
            }
        }


        /// <summary>
        /// 最大超时时间5分钟
        /// </summary>
        static double TimeOut = new TimeSpan(0, 0, 5, 0, 0).TotalMilliseconds;

        void DownloadUrl(string url, string name)
        {
            DownloadFile(url, name);
        }

        public delegate void DownloadProcess(object sender, DownloadEventArgs e);

        public event DownloadProcess OnDownloadProcess;

        public class DownloadEventArgs : EventArgs
        {
            /// <summary>
            /// 已下载百分比
            /// </summary>
            public float Current
            {
                get;
                set;
            }

            /// <summary>
            /// 已下载总量
            /// </summary>
            public long TotalDownloadedByte
            {
                get;
                set;
            }

            public double Speed
            {
                get;
                set;
            }

            public DownloadEventArgs(float current, long totalDownloadedByte, double speed)
                : base()
            {
                Current = current;
                TotalDownloadedByte = totalDownloadedByte;
                Speed = speed;
            }
        }

        int ErrorTime = 0;

        /// <summary>        
        /// 下载文件        
        /// </summary>        
        /// <param name="URL">下载文件地址</param>       
        /// <param name="Filename">下载后的存放地址</param>        
        /// <param name="Prog">用于显示的进度条</param>        
        public void DownloadFile(string URL, string filename)
        {
            try
            {
                long offset = 0;

                int tryTime = 0;

                bool isFinsh = false;


                while (tryTime < 1 && !isFinsh)
                {
                    System.IO.Stream so = null;
                    try
                    {

                        System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                        Myrq.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";

                        // 断点续传
                        if (offset != 0 && File.Exists(filename))
                        {
                            Myrq.AddRange((int)offset);
                        }

                        System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();

                        var totalBytes = myrp.ContentLength;

                        this.result.TotalSize += (Int32)totalBytes;
                        this.result.Status = 文件状态.下载数据中;

                        System.IO.Stream st = myrp.GetResponseStream();


                        long totalDownloadedByte = 0;

                        if (File.Exists(filename))
                        {
                            so = new System.IO.FileStream(filename, System.IO.FileMode.Append);
                            totalDownloadedByte += so.Length;
                        }
                        else
                        {
                            so = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                        }

                        byte[] by = new byte[1024];
                        int osize = st.Read(by, 0, (int)by.Length);
                        while (osize > 0)
                        {
                            totalDownloadedByte = osize + totalDownloadedByte;
                            System.Windows.Forms.Application.DoEvents();
                            so.Write(by, 0, osize);

                            var current = DateTime.Now;

                            // 2s 计算一次
                            if ((current - LastTime).TotalSeconds > 1)
                            {
                                var speed = (totalDownloadedByte - lastByte) / ((current - LastTime).TotalSeconds * 1024);

                                LastTime = current;
                                lastByte = totalDownloadedByte;
                                this.result.Progress = (int)(totalDownloadedByte * 100 / totalBytes);
                                this.result.Speed = speed;

                                offset = totalDownloadedByte;

                                OnDownloadProcess(this, new DownloadEventArgs(totalDownloadedByte * 100 / totalBytes, totalDownloadedByte, speed));
                            }

                            osize = st.Read(by, 0, (int)by.Length);
                        }
                        so.Close();
                        st.Close();
                        this.result.Progress = 100;
                        this.result.Status = 文件状态.已完成下载;

                        isFinsh = true;

                        return;
                    }
                    catch (System.Exception ex)
                    {

                        //throw;
                        //LoggerManager.Logger.LogException(ex);

                        if (ex.Message.Contains("404") || ex.Message.Contains("403"))
                        {
                            this.result.Progress = 100;
                            this.result.Speed = 0;
                            if (ex.Message.Contains("404"))
                                this.result.Status = 文件状态.下载失败_文件不存在404;
                            else if (ex.Message.Contains("403"))
                                this.result.Status = 文件状态.下载失败_禁止访问403;
                            return;
                        }

                        tryTime++;

                        // 超过3次 失败
                        if (tryTime > 3)
                        {
                            this.result.Progress = 100;
                            this.result.Speed = 0;
                            this.result.Status = 文件状态.下载失败;
                            return;
                        }
                    }
                    finally
                    {
                        if (so != null)
                            // 关闭文件
                            so.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                //LoggerManager.Logger.LogException(ex);
            }
        }
    }

    /// <summary>
    /// URL 集合
    /// </summary>
    public class UrlSet
    {
        public UrlSet()
        {
            ListPages = new List<string>();
            ContetnPages = new List<string>();
        }

        public List<string> ListPages { get; set; }

        public List<string> ContetnPages { get; set; }
    }

    /// <summary>
    /// XPath 对象
    /// </summary>
    [Serializable]
    public class XPath
    {
        /// <summary>
        /// XPATH
        /// </summary>
        public string XPathString { get; set; }

        /// <summary>
        /// 选择类型 （单选、多选）
        /// </summary>
        public XMLPathSelectType XMLPathSelectType
        {
            get;
            set;
        }

        /// <summary>
        /// 取值类型
        /// </summary>
        public XMLPathType XMLPathType
        {
            get;
            set;
        }

        /// <summary>
        /// 从html中提取数据
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public List<string> ExtractDataFromHtml(string html)
        {
            return ExtractUrl.ExtractDataFromHtml(html, this.XPathString, this.XMLPathSelectType, this.XMLPathType);
        }


    }

    /// <summary>
    /// XPATH取值类型【InnerText，InnerLinks】
    /// </summary>
    [Serializable]
    public enum XMLPathType
    {
        InnerText,
        InnerTextWithPic,
        InnerLinks,
        InnerHtml,
        Href
    }

    /// <summary>
    /// XPATH选择类型  单选还是多选
    /// </summary>
    [Serializable]
    public enum XMLPathSelectType
    {
        OnlyOne,
        Multiple
    }

    /// <summary>
    /// 条目规则
    /// </summary>
    [Serializable]
    public class ItemRule
    {

        /// <summary>
        /// 多相匹配
        /// </summary>
        public bool MulityMatch { get; set; }

        /// <summary>
        /// 替换XPath
        /// </summary>
        public string AnotherXPath { get; set; }

        /// <summary>
        /// 采集方式
        /// </summary>
        public ItemFetchType FetchType { get; set; }

        /// <summary>
        /// XPATH
        /// </summary>
        public string XPath { get; set; }

        /// <summary>
        /// XPATH类型
        /// </summary>
        public XMLPathType XMLPathType { get; set; }

        /// <summary>
        /// XPATH选择类型
        /// </summary>
        public XMLPathSelectType XMLPathSelectType { get; set; }

        /// <summary>
        /// 条目名称
        /// </summary>
        public string ItemName
        {
            get;
            set;
        }

        /// <summary>
        /// 存储名称
        /// </summary>
        public string CloumnName
        {
            get;
            set;
        }
        public string StartTarget
        {
            get;
            set;
        }

        public string EndTarget
        {
            get;
            set;
        }

        /// <summary>
        /// 正则
        /// </summary>
        public string RegexText
        {
            get;
            set;
        }



        /// <summary>
        /// 是否过滤文本
        /// </summary>
        public bool IsExtractText
        {
            get;
            set;
        }

        /// <summary>
        /// 是否下载图片
        /// </summary>
        public bool IsDownloadPic { get; set; }

        /// <summary>
        /// 是否识别分页
        /// </summary> 
        public bool IdentifyPage
        {
            get;
            set;
        }

        /// <summary>
        /// 分页开始标记
        /// </summary>
        public string PageStart
        {
            get;
            set;
        }

        /// <summary>
        /// 分页结束标记
        /// </summary>
        public string PageEnd
        {
            get;
            set;
        }

        public string PageXPath { get; set; }

        /// <summary>
        /// 替换字符串
        /// </summary>
        public string ReplaceString
        {
            get;
            set;
        }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public UserDiyType DiyType { get; set; }


        /// <summary>
        /// 时间格式字符串
        /// </summary>
        public string DateTimeFormatString { get; set; }

    }

    [Serializable]
    public enum ItemFetchType
    {
        XPath = 0,
        FromHTML = 1,
        FromRegex = 2,
        UserDiy = 3
    }

    [Serializable]
    public enum UserDiyType
    {
        DefaultValue = 0,
        Datetime = 1
    }

    [Serializable]
    public enum ListPageType
    {
        Html = 0,
        RSS = 1
    }

    /// <summary>
    /// 网站采集模式
    /// </summary>
    [Serializable]
    public enum SiteExractMode
    {
        /// <summary>
        /// 传统 列表-内容页
        /// </summary>
        ListContent = 0,

        /// <summary>
        /// 首页-栏目页-列表页
        /// </summary>
        HomeColumnListContent = 1,

        /// <summary>
        /// 首页-列表页
        /// </summary>
        HomeListContent = 2
    }
}
