using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HFBBS.Model;
using HFBBS.BLL;
using System.Threading;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;

namespace HFBBS
{
    public class CacheObject
    {
        static CacheObject()
        {
            BLL = new RuleManager();
            Rules = BLL.GetSiteRules();
            Categories = BLL.GetCategories();
            RunningTasks = new List<RunningTask>();
        }

        public static Form1 MainForm { get; set; }

        public static Dictionary<string, DockContent> MdiDict = new Dictionary<string, DockContent>();

        public static RuleManager BLL { get; set; }
        static DraftBoxForm draftForm;
        public static DraftBoxForm DraftForm
        {
            get
            {
                if (draftForm == null)
                {
                    draftForm = new DraftBoxForm();
                    MainForm.AddDock(draftForm, DockState.Document);
                }

                if (draftForm.DockPanel == null)
                {
                    MainForm.AddDock(draftForm, DockState.Document);
                }

                return draftForm;
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
                    MainForm.AddDock(editForm, DockState.Document);
                }

                if (editForm.DockPanel == null)
                {
                    MainForm.AddDock(editForm, DockState.Document);
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
            return taskDir + FileName;
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
                    instance.Add(new RunningTask { TaskName = "test" });
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
    }

    public class DownloadFileCollection : List<DownloadFile>
    {
        /// <summary>
        /// 数据变化
        /// </summary>
        public event Change OnChange;

        public int MaxDownloadThread = 5;

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
            return this.Where(d => d.TaskId == taskId).ToList();
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
}
