using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jade.Model;
using Jade.BLL;
using System.Threading;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;
using Jade.Model.MySql;
using Jade.DAL;
using System.Net;
using System.Text.RegularExpressions;

namespace Jade
{
    public class CacheObject
    {
        static CacheObject()
        {
            RuleManager = new RuleManager();
            Rules = RuleManager.GetSiteRules();
            Categories = RuleManager.GetCategories();
            RunningTasks = new List<RunningTask>();
            DownloadDataDAL = DatabaseFactory.Instance.CreateDAL();
        }
        static MyWebRequest webRequset;
        public static MyWebRequest WebRequset
        {
            get
            {
                if (webRequset == null)
                {
                    webRequset = new MyWebRequest();
                }
                return webRequset;
            }
        }

        public static string Cookie = "";
        public static bool IsDebug = false;

        public static MainForm MainForm { get; set; }

        public static Dictionary<string, DockContent> MdiDict = new Dictionary<string, DockContent>();

        public static NewsDAL NewsDAL = new NewsDAL();

        public static RuleManager RuleManager { get; set; }

        /// <summary>
        /// 下载数据DAL
        /// </summary>
        public static IDownloadDataDAL DownloadDataDAL { get; set; }

        static DraftBoxForm draftForm;

        /// <summary>
        /// 是否已登录
        /// </summary>
        public static bool IsLognIn
        {
            get;
            set;
        }

        static User currentUser;
        public static User CurrentUser
        {
            get
            {
                if (currentUser == null)
                {
                    currentUser = new User
                    {
                        Id = Jade.Properties.Settings.Default.UserId,
                        Name = Jade.Properties.Settings.Default.Name,
                        UserName = Jade.Properties.Settings.Default.UserName,
                        Password = Jade.Properties.Settings.Default.UserPassword
                    };
                }

                return currentUser;
            }

            set
            {
                currentUser = value;
            }
        }

        //public static DraftBoxForm DraftForm
        //{
        //    get
        //    {
        //        if (draftForm == null || draftForm.IsDisposed)
        //        {
        //            draftForm = new DraftBoxForm();
        //            MainForm.AddDock(draftForm, DockState.Document);
        //        }

        //        if (draftForm.DockPanel == null)
        //        {
        //            MainForm.AddDock(draftForm, DockState.Document);
        //        }

        //        return draftForm;
        //    }
        //}

        //static ContentManageForm navForm;
        //public static ContentManageForm NavForm
        //{
        //    get
        //    {
        //        if (navForm == null || navForm.IsDisposed)
        //        {
        //            navForm = new ContentManageForm();
        //        }
        //        if (navForm.DockPanel == null)
        //        {
        //            MainForm.AddDock(navForm, DockState.DockLeft);
        //        }
        //        return navForm;
        //    }
        //    set
        //    {
        //        navForm = value;
        //    }
        //}

        static WelcomeForm welForm;
        public static WelcomeForm WelcomeForm
        {
            get
            {
                if (welForm == null || welForm.IsDisposed)
                {
                    welForm = new WelcomeForm();
                }
                //if (welForm.DockPanel == null)
                //{
                //    MainForm.AddDock(welForm, DockState.Document);
                //}
                return welForm;
            }
            set
            {
                welForm = value;
            }
        }
        public static string IconDir
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "\\Pic";
            }
        }

        static ContentEditForm editForm;

        public static ContentEditForm ContentForm
        {
            get
            {
                if (editForm == null || editForm.IsDisposed)
                {
                    editForm = new ContentEditForm();
                }
                return editForm;
            }
        }

        public static List<SiteRule> Rules
        {
            get;
            set;
        }

        public static List<Category> Categories
        {
            get;
            set;
        }

        public static List<RunningTask> RunningTasks
        {
            get;
            set;
        }
    }

    public class RunningTask
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string UrlCount { get; set; }
        public string ContentCount { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public TaskRunner runner { get; set; }
        public SiteRule Rule { get; set; }

        public System.Timers.Timer timer;

        public void StarTimer()
        {
            if (timer == null)
            {
                timer = new System.Timers.Timer(Rule.AutoRunInterval * 60 * 1000);
                timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            }
            else
            {
                timer.Stop();
            }
            timer.Start();
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (runner != null)
            {
                StartWork();
            }
        }

        public void StartWork()
        {
            new Thread(runner.Start).Start();
        }

        public void StopWork()
        {
            runner.Stop();
        }

        public void StopTimer()
        {
            if (timer != null)
            {
                timer.Stop();
            }
        }
    }

    public enum TaskStatus
    {
        运行中,
        停止,
        休眠
    }

    //Number,FileName,TotalSize,Progress,Url
    public class DownloadFile
    {
        public int TaskId { get; set; }
        public int Number { get; set; }
        public string FileName { get; set; }
        public int TotalSize { get; set; }
        public double Progress { get; set; }

        public double Speed { get; set; }
        public string Url { get; set; }
        public 文件状态 Status { get; set; }

        public string GetLocalFilePath()
        {
            var taskDir = AppDomain.CurrentDomain.BaseDirectory + "\\Pic\\" + TaskId;
            if (!Directory.Exists(taskDir))
            {
                Directory.CreateDirectory(taskDir);
            }
            return taskDir + "\\" + FileName;
        }
    }

    public enum 文件状态
    {
        排队中 = 0,
        下载数据中 = 5,
        下载失败 = 6,
        下载失败_文件不存在404 = 7,
        下载失败_禁止访问403 = 8,
        已完成下载 = 9
    }

    /// <summary>
    /// 文件下载完毕
    /// </summary>
    public class FileDownloadFinishedArgs : EventArgs
    {
        public 文件状态 状态
        {
            get;
            set;
        }

        public DownloadFile File
        {
            get;
            set;
        }

        public FileDownloadFinishedArgs(DownloadFile file, 文件状态 status)
        {
            this.File = file;
            this.状态 = status;
        }
    }
    public delegate void Change(object sender, System.EventArgs e);

    public class RunningTaskCollection : List<RunningTask>
    {
        /// <summary>
        /// 数据变化
        /// </summary>
        public event Change OnChange;

        static RunningTaskCollection instance;

        /// <summary>
        /// 唯一实例
        /// </summary>
        public static RunningTaskCollection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RunningTaskCollection();
                    instance.Add(new RunningTask { TaskName = "test0", Status = TaskStatus.运行中, StartTime = DateTime.Now, EndTime = DateTime.MaxValue });
                }
                return instance;
            }
        }

        void NotifyChange()
        {
            if (this.OnChange != null)
            {
                this.OnChange(this, new EventArgs());
            }
        }

        public void AddTask(RunningTask task)
        {
            this.Add(task);
            this.NotifyChange();
        }

        public void Update()
        {
            this.NotifyChange();
        }

        public void TaskFinish(RunningTask task)
        {
            if (task.Status == TaskStatus.休眠)
            {
                // 休眠
                task.StarTimer();
            }

            this.NotifyChange();
        }
    }

    public class DownloadFileCollection : List<DownloadFile>
    {
        /// <summary>
        /// 数据变化
        /// </summary>
        public event Change OnChange;

        public int MaxDownloadThread = 20;

        int currentCount = 0;

        static DownloadFileCollection instance;

        public bool IsRunning
        {
            get;
            set;
        }

        /// <summary>
        /// 唯一实例
        /// </summary>
        public static DownloadFileCollection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DownloadFileCollection();
                    instance.IsRunning = true;
                    new Thread(instance.DoTask).Start();
                }
                return instance;
            }
        }

        public List<DownloadFile> GetDownloadFiles(int taskId)
        {
            lock (this)
            {
                return this.Where(d => d.TaskId == taskId).ToList();
            }
        }

        void NotifyChange()
        {
            if (this.OnChange != null)
            {
                this.OnChange(this, new EventArgs());
            }
        }

        public void AddFile(DownloadFile file)
        {
            this.Add(file);
            this.NotifyChange();
        }

        void DoTask()
        {
            while (IsRunning)
            {
                if (currentCount < MaxDownloadThread)
                {
                    lock (this)
                    {
                        var file = this.Find(f => f.Status == 文件状态.排队中);
                        if (file != null)
                        {
                            currentCount++;
                            var downloader = new Downloader(file);
                            downloader.OnDownloadProcess += new Downloader.DownloadProcess(downloader_OnDownloadProcess);
                            downloader.OnDownLoadComplete += new Downloader.DownLoadComplete(downloader_OnDownLoadComplete);
                            downloader.Start();
                        }
                    }
                }
                else
                {
                    Thread.Sleep(2000);
                }
            }
        }

        void downloader_OnDownLoadComplete(object sender, FileDownloadFinishedArgs e)
        {
            sender = null;
            currentCount--;
            this.NotifyChange();
        }

        void downloader_OnDownloadProcess(object sender, Downloader.DownloadEventArgs e)
        {
            this.NotifyChange();
        }

        public void Update()
        {
            this.NotifyChange();
        }

    }

    /// <summary>
    /// MSP请求
    /// </summary>
    public class MyWebRequest : IDisposable
    {
        public MyWebRequest(string url = "http://msp.iflytek.com/index.htm")
        {
            this.Url = url;
        }

        /// <summary>
        /// 服务器地址
        /// </summary>
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// 文本协议头
        /// </summary>
        private string contentType = "application/x-www-form-urlencoded";


        /// <summary>
        /// 混杂协议头
        /// </summary>
        private string multipart = "multipart/mixed;boundary=---------boundary string";

        /// <summary>
        /// 内容类型
        /// </summary>
        public string ContentType
        {
            get { return contentType; }
            set { contentType = value; }
        }

        private string boundary = "---------boundary string";

        /// <summary>
        /// 分隔符
        /// </summary>
        public string Boundary
        {
            get { return boundary; }
            set { boundary = value; }
        }

        /// <summary>
        /// 请求数据
        /// </summary>
        public RequestPostData RequestData
        {
            get;
            set;
        }

        string endcoingName = "gb2312";

        /// <summary>
        /// 内容编码(计算boundary的Content-length时使用)，默认gb2312
        /// </summary>
        public string EncodingName
        {
            get
            {
                return endcoingName;
            }
            set
            {
                endcoingName = value;
            }
        }

        protected HttpWebResponse _myHttpWebResponse = null;

        public string Accept
        {
            get;
            set;
        }

        /// <summary>
        /// 获取请求的Post数据
        /// </summary>
        /// <returns></returns>
        public string GetPostData()
        {
            if (RequestData.IsMultipart)
            {
                List<string> postData = new List<string>();
                string boundary = "--" + this.Boundary;
                postData.Add(boundary);
                foreach (PostDataItem post in RequestData.PostDatas)
                {
                    postData.Add(string.Format("Content-type:{0}", post.ContentType));
                    postData.Add(string.Format("Content-length:{0}", Encoding.GetEncoding(EncodingName).GetBytes(post.Data).Length));
                    postData.Add(string.Empty);
                    postData.Add(post.Data);
                    postData.Add(boundary);
                }
                var postDataArray = postData.ToArray();
                postDataArray[postDataArray.Length - 1] += "--";
                return String.Join("\r\n", postDataArray);
            }
            else
            {
                return RequestData.PostDatas[0].Data;
            }
        }

        /// <summary>
        /// 响应信息
        /// </summary>
        public string ResponseMessage
        {
            get;
            set;
        }


        public string Cookie
        {
            get;
            set;
        }

        /// <summary>
        /// 解析后的响应信息字典
        /// </summary>
        public Dictionary<string, string> ResponseDictionary
        {
            get;
            set;
        }

        private void GetKeyValueDictionFromResponse()
        {
            var results = ResponseMessage.Split('&');
            ResponseDictionary = new Dictionary<string, string>();
            foreach (var result in results)
            {
                var keyvaluepair = result.Split(new string[] { "=" }, 2, StringSplitOptions.RemoveEmptyEntries);
                if (keyvaluepair.Length == 2)
                {
                    ResponseDictionary.Add(keyvaluepair[0], keyvaluepair[1]);
                }
            }
        }

        /// <summary>
        /// POST数据
        /// </summary>
        /// <returns>是否成功</returns> 
        public string Post()
        {
            System.Net.ServicePointManager.Expect100Continue = false;
            var request = (HttpWebRequest)WebRequest.Create(this.Url);
            request.Headers[HttpRequestHeader.Cookie] = this.Cookie;
            if (this.RequestData.IsMultipart)
            {
                request.ContentType = this.multipart;
            }
            else
            {
                request.ContentType = this.ContentType;
            }
            string postData = this.GetPostData();

            Console.WriteLine("请求数据如下:");

            Console.WriteLine(postData);

            byte[] buffer = Encoding.GetEncoding(this.EncodingName).GetBytes(postData);

            request.Method = "POST";
            request.AllowWriteStreamBuffering = true;
            request.ContentLength = buffer.Length;
            request.Accept = "*/*";
            request.KeepAlive = true;
            // 获取请求stream
            Stream requestStream = request.GetRequestStream();
            // 写入post数据
            requestStream.Write(buffer, 0, buffer.Length);
            // 关闭流
            requestStream.Close();
            // 获取响应
            _myHttpWebResponse = (HttpWebResponse)request.GetResponse();
            // 获取响应流
            var responseStream = _myHttpWebResponse.GetResponseStream();
            var sr = new StreamReader(responseStream, Encoding.GetEncoding(EncodingName));
            GetCookie();
            ResponseMessage = sr.ReadToEnd();
            // GetKeyValueDictionFromResponse();
            return ResponseMessage;

        }

        public string Get()
        {
            System.Net.ServicePointManager.Expect100Continue = false;
            var request = (HttpWebRequest)WebRequest.Create(this.Url);
            request.Headers[HttpRequestHeader.Cookie] = this.Cookie;
            request.Method = "GET";
            request.AllowWriteStreamBuffering = true;
            request.Accept = "*/*";
            request.KeepAlive = true;
            // 获取响应
            _myHttpWebResponse = (HttpWebResponse)request.GetResponse();
            // 获取响应流
            var responseStream = _myHttpWebResponse.GetResponseStream();
            var sr = new StreamReader(responseStream, Encoding.GetEncoding(EncodingName));
            GetCookie();
            ResponseMessage = sr.ReadToEnd();
            // GetKeyValueDictionFromResponse();
            return ResponseMessage;
        }

        private void GetCookie()
        {
            if (_myHttpWebResponse.Headers[HttpResponseHeader.SetCookie] != null)
            {
                var regex = new Regex(@"expires=\w+, \d+-\w+-\d+ \d+:\d+:\d+ GMT;*");
                this.Cookie = _myHttpWebResponse.Headers[HttpResponseHeader.SetCookie].Replace("path=/,", "").Replace("path=/", "");
                this.Cookie = regex.Replace(Cookie, "");
            }
        }

        ~MyWebRequest()
        {
            this.Dispose();
        }

        #region IDisposable 成员

        public void Dispose()
        {
            if (_myHttpWebResponse != null)
            {
                _myHttpWebResponse.Close();
                _myHttpWebResponse = null;
            }
        }

        #endregion
    }

    /// <summary>
    /// 请求Post的数据集合
    /// </summary>
    public class RequestPostData
    {
        /// <summary>
        /// 数据集合
        /// </summary>
        public List<PostDataItem> PostDatas
        {
            get;
            set;
        }

        /// <summary>
        /// 是否是Multipart
        /// </summary>
        public bool IsMultipart
        {
            get
            {
                return this.PostDatas.Count > 1;
            }
        }

        public void AddPost()
        {
        }
    }

    /// <summary>
    /// POST 数据片段
    /// </summary>
    public class PostDataItem
    {
        public string Data
        {
            get;
            set;
        }

        public string ContentType
        {
            get;
            set;
        }
    }

    public class User
    {
        public string Id { get; set; }

        public string Name
        {
            get;
            set;
        }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
