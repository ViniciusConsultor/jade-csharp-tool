using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jade.Model;
using Jade.BLL;
using System.Threading;
using System.IO;
using Jade.Model.MySql;

namespace Jade
{
    public class TaskRunner
    {

        public SiteRule Rule { get; set; }

        public ILog Logger { get; set; }

        public DataSaverManager DataSaver { get; set; }

        public event TaskStateChange StateChange;

        public List<DownloadFile> DownloadFiles { get; set; }

        public List<string> OldUrls = new List<string>();

        public Dictionary<string, string> DownloadedPics = new Dictionary<string, string>();

        public int TotalLinks
        {
            get;
            set;
        }
        RunningTask runningTaskModel;
        public RunningTask RunningTaskModel
        {
            get
            {
                if (runningTaskModel == null)
                {
                    runningTaskModel = RunningTaskCollection.Instance.SingleOrDefault(r => r.TaskId == Rule.SiteRuleId);
                }

                if (runningTaskModel == null)
                {
                    runningTaskModel = new RunningTask
                    {
                        ContentCount = "0/0",
                        UrlCount = "0/0",
                        TaskId = Rule.SiteRuleId,
                        TaskName = Rule.Name,
                        Status = TaskStatus.运行中,
                        StartTime = DateTime.Now,
                        runner = this,
                        Rule = Rule,
                        EndTime = DateTime.MinValue
                    };
                    RunningTaskCollection.Instance.AddTask(this.runningTaskModel);
                }
                return runningTaskModel;
            }
            set
            {
                runningTaskModel = value;
            }
        }

        public string Status
        {
            get;
            private set;
        }

        bool isRunning = false;

        public TaskRunner(SiteRule rule, ILog logger, DataSaverManager dataSaver)
        {
            Rule = rule;
            Logger = logger;
            DataSaver = dataSaver;
            OldUrls = CacheObject.DownloadDataDAL.GetTaskUrls(rule.SiteRuleId);
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            isForceStop = true;
            this.RunningTaskModel.Status = TaskStatus.运行中;
            this.RunningTaskModel.StartTime = DateTime.Now;
            RunningTaskCollection.Instance.Update();

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
                this.RunningTaskModel.Status = TaskStatus.运行中;
                this.RunningTaskModel.StartTime = DateTime.Now;
                RunningTaskCollection.Instance.Update();

                isRunning = true;

                Status = "正在启动";

                Logger.Info("[" + Rule.Name + "] 正在初始化配置,请稍等...");

                List<Uri> urls = new List<Uri>();

                ExtractUrls(urls);


                this.RunningTaskModel.ContentCount = "0/" + urls.Count;
                RunningTaskCollection.Instance.Update();

                if (urls.Count > 0)
                {
                    DownloadDetail(urls);
                }
                else
                {
                    this.Logger.Error("[" + Rule.Name + "] 没有采集到新网址，采集完成！");
                }

                this.RunningTaskModel.EndTime = DateTime.Now;

                if (Rule.EnableAutoRun)
                {
                    this.RunningTaskModel.Status = TaskStatus.休眠;
                }
                else
                {
                    this.RunningTaskModel.Status = TaskStatus.停止;
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

                RunningTaskCollection.Instance.TaskFinish(RunningTaskModel);
                // 
                isRunning = false;
                this.Logger.Success("[" + Rule.Name + "] 采集完成");
            }
        }

        private void DownloadDetail(List<Uri> urls)
        {
            var item = Rule;
            var total = urls.Count;
            var index = 0;

            if (CacheObject.IsTest)
                Logger.Error("[" + Rule.Name + "] 开始采集，试用版本只能采集50条");

            var taskImageDir = AppDomain.CurrentDomain.BaseDirectory + "\\Pic\\" + this.Rule.SiteRuleId;

            var max = CacheObject.IsTest ? Math.Min(50, urls.Count) : urls.Count;

            //foreach (var url in urls)
            for (var i = 0; i < max; i++)
            {
                var url = urls[i];
                if (!isForceStop)
                {
                    var html = HtmlPicker.VisitUrl(
                                            url,
                                             item.HttpMethod,
                                                       null,
                                                       string.IsNullOrEmpty(item.Referer) ? null : item.Referer,
                                                   string.IsNullOrEmpty(item.Cookie) ? null : Utility.GetCookies(item.Cookie),
                                                   string.IsNullOrEmpty(item.UserAgent) ? null : item.UserAgent,
                                                   string.IsNullOrEmpty(item.HttpPostData) ? null : item.HttpPostData,
                                                       System.Text.Encoding.GetEncoding(item.Encoding));

                    var data = CacheObject.DownloadDataDAL.Get(url.AbsoluteUri);
                    if (data == null)
                    {
                        continue;
                    }
                    data.IsDownload = true;
                    foreach (var itemRule in item.ItemRules)
                    {
                        IFetcher fetcher = new FetchItem(itemRule);
                        var result = fetcher.Fetch(html);
                        if (result == null)
                        {
                            result = "";
                        }
                        switch (itemRule.CloumnName)
                        {
                            case "Title":
                                data.Title = result;
                                //File.AppendAllText("user.txt", result);
                                break;
                            case "Summary":
                                data.Summary = result;
                                break;
                            case "Other":
                                data.Other = result;
                                break;
                            case "Content":
                                // todo 分析图片
                                if (itemRule.IsDownloadPic)
                                {
                                    //
                                    var pics = UrlPicker.GetImagesUrls(ref result, taskImageDir);

                                    foreach (var key in pics)
                                    {
                                        var imageUrl = key.Key;
                                        if (!imageUrl.Contains("http://"))
                                        {
                                            imageUrl = ExtractUrl.RepairUrl(url.AbsoluteUri, imageUrl);
                                        }
                                        if (!this.DownloadedPics.ContainsKey(imageUrl))
                                        {
                                            this.DownloadedPics.Add(imageUrl, key.Value);
                                            DownloadFile file = new DownloadFile()
                                            {
                                                TaskId = Rule.SiteRuleId,
                                                FileName = key.Value,
                                                Url = imageUrl,
                                                Progress = 0,
                                                TotalSize = 0,
                                                Number = DownloadFileCollection.Instance.GetDownloadFiles(Rule.SiteRuleId).Count + 1
                                            };
                                            DownloadFileCollection.Instance.AddFile(file);
                                        }
                                    }
                                }
                                data.Content = result;
                                break;
                            case "Time":
                                data.CreateTime = result;
                                break;
                            case "Source":
                                data.Source = result;
                                break;
                            case "SubTitle":
                                data.SubTitle = result;
                                //File.AppendAllText("item.txt", result);
                                break;
                            case "Keywords":
                                data.Keywords = result;
                                break;
                        }
                        //this.tbxResult.Text += string.Format("【{0}】: {1}\r\n", itemRule.ItemName, result);
                    }
                    DataSaver.Update(data);
                    Logger.Success("[" + Rule.Name + "] 成功采集并更新数据到数据库【" + data.Title + "】");
                    index++;

                    this.RunningTaskModel.ContentCount = index + "/" + urls.Count;
                    RunningTaskCollection.Instance.Update();

                    if (this.StateChange != null)
                    {
                        this.StateChange(this, new TaskRunnerEventArgs(new RunnerState
                        {
                            CurrentCount = index,
                            StepName = "采集内容",
                            TotalCount = total
                        }));
                    }
                }
                else
                {
                    return;
                }
            }
        }

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

        private void ExtractUrls(List<Uri> urls)
        {

            var item = Rule;
            int i = 0;
            var startUrls = Rule.StartUrl.Split(new string[] { BaseConfig.UrlSeparator }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var startUris = new List<Uri>();
            CheckExtractUrlIsAvailable(startUrls, out startUris);

            while (true)
            {
                if (!isForceStop)
                {
                    if (i == startUris.Count)
                    {
                        break;
                    }

                    if (!string.IsNullOrEmpty(Rule.DiyContentPageUrl))
                    {
                        Logger.Info("[" + Rule.Name + "] 正在处理用户自定义内容页");

                        string[] dirBaseUrls = Rule.DiyContentPageUrl.Split(new string[] { BaseConfig.UrlSeparator }, StringSplitOptions.RemoveEmptyEntries);
                        List<string> dirUrls = new List<string>();
                        if (urls != null && dirBaseUrls.Length > 0)
                        {
                            foreach (string url in dirBaseUrls)
                            {
                                dirUrls.AddRange(ExtractUrl.ParseUrlFromParameter(url));
                            }
                        }
                        AddUrls(urls, dirUrls);
                    }

                    Logger.Info("[" + Rule.Name + "] 正在下载并分析1级第" + (i + 1) + "个网址" + startUris[i].AbsoluteUri);

                    var html = HtmlPicker.VisitUrl(startUris[i],
                                                       item.HttpMethod,
                                                       null,
                                                       string.IsNullOrEmpty(item.Referer) ? null : item.Referer,
                                                   string.IsNullOrEmpty(item.Cookie) ? null : Utility.GetCookies(item.Cookie),
                                                   string.IsNullOrEmpty(item.UserAgent) ? null : item.UserAgent,
                                                   string.IsNullOrEmpty(item.HttpPostData) ? null : item.HttpPostData,
                                                       System.Text.Encoding.GetEncoding(item.ListEncoding));
                    SetExtractUrl(item, html, startUris[i].AbsoluteUri, item.ListEncoding, urls);
                    i++;
                    if (this.StateChange != null)
                    {
                        this.StateChange(this, new TaskRunnerEventArgs(new RunnerState
                        {
                            CurrentCount = i,
                            StepName = "采集网址",
                            TotalCount = startUris.Count
                        }));
                    }
                    this.RunningTaskModel.UrlCount = i + "/" + startUris.Count;
                    RunningTaskCollection.Instance.Update();
                }
                else
                {
                    break;
                }
            }

            var unFinisedUrls = CacheObject.DownloadDataDAL.GetUnFetchedUrlList(Rule.SiteRuleId);
            unFinisedUrls.ForEach(u => urls.Add(new Uri(u)));
        }

        private void SetExtractUrl(
            SiteRule item,
            string html, string sourceUrl,
            string encoding, List<Uri> uris)
        {

            List<string> urls;

            if (Rule.ListPageType == ListPageType.Html)
            {
                if (Rule.ListFetchType == ItemFetchType.XPath)
                {
                    urls = ExtractUrl.ExtractAccurateUrl(Rule, html, sourceUrl);
                }
                else
                {
                    urls = ExtractUrl.ExtractAccurateUrl(sourceUrl, html, item.PageStartAt, item.PageEndAt, item.IncludePart, item.ExcludePart, "", new List<string>());
                }
            }
            else
                urls = ExtractUrl.ExtractAccurateRssUrl(RssPicker.GetRssLinks(html, Encoding.GetEncoding(encoding)), item.IncludePart, item.ExcludePart);

            AddUrls(uris, urls);
        }

        private void AddUrls(List<Uri> uris, List<string> urls)
        {
            foreach (string url in urls)
            {
                if (!url.Contains("javascript"))
                {
                    if (!OldUrls.Contains(url))
                    {
                        try
                        {
                            OldUrls.Add(url);
                            uris.Add(new Uri(url));
                            DataSaver.Add(DatabaseFactory.Instance.CreateDownloadData(url, Rule.SiteRuleId));
                            Logger.Success("[" + Rule.Name + "] 成功采集网址并保存到数据库中" + url);
                        }
                        catch(Exception ex)
                        {
                            Log4Log.Exception(url, ex);
                        }
                    }
                    else
                    {
                        Logger.Error("[" + Rule.Name + "] 发现重复网址" + url);
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
}
