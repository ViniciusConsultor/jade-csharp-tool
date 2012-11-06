﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jade.Model;
using System.Threading;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Reflection;
using Jade.BLL;

namespace Jade
{

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
                            //currentCount++;
                            //var downloader = new Downloader(file);
                            //downloader.OnDownloadProcess += new Downloader.DownloadProcess(downloader_OnDownloadProcess);
                            //downloader.OnDownLoadComplete += new Downloader.DownLoadComplete(downloader_OnDownLoadComplete);
                            //downloader.Start();
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


        /// <summary> 
        /// 上传图片文件 
        /// </summary> 
        /// <param name="url">提交的地址</param> 
        /// <param name="poststr">发送的文本串   比如：user=eking&pass=123456  param> 
        /// <param name="fileformname">文本域的名称  比如：name="file"，那么fileformname=file  param> 
        /// <param name="filepath">上传的文件路径  比如： c:\12.jpg param> 
        /// <param name="cookie">cookie数据</param> 
        /// <param name="refre">头部的跳转地址</param> 
        /// <returns></returns> 
        public string UploadImage(string poststr, string filepath, string imageType = "image/jpeg")
        {
            System.Net.ServicePointManager.Expect100Continue = false;
            var gb2312 = Encoding.GetEncoding("gb2312");
            var webrequest = (HttpWebRequest)WebRequest.Create(this.Url);
            webrequest.Headers[HttpRequestHeader.Cookie] = this.Cookie;
            // webrequest.Headers.Remove(HttpRequestHeader.Referer);
            //webrequest.Headers.Add(HttpRequestHeader.Referer, "http://newscms.house365.com/newCMS/news/addpic.php?parent_channel_id=8000000&bjq=");

            string boundary = "----------" + DateTime.Now.Ticks.ToString("x");
            // boundary
            //string boundary = "----------------------------7dc1571c41816";

            // 创建request对象 
            //HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url); 
            webrequest.ContentType = "multipart/form-data; boundary=" + boundary;
            webrequest.Method = "POST";
            webrequest.AllowWriteStreamBuffering = true;
            webrequest.Accept = "*/*";
            webrequest.KeepAlive = true;

            var postStream = new MemoryStream();

            // 构造发送数据
            StringBuilder sb = new StringBuilder();

            // 文本域的数据，将user=eking&pass=123456  格式的文本域拆分 ，然后构造 
            foreach (string c in poststr.Split('&'))
            {
                string[] item = c.Split('=');
                if (item.Length != 2)
                {
                    break;
                }
                string name = item[0];
                string value = item[1];
                sb.Append("--" + boundary);
                sb.Append("\r\n");
                sb.Append("Content-Disposition: form-data; name=\"" + name + "\"");
                sb.Append("\r\n\r\n");
                sb.Append(value);
                sb.Append("\r\n");

            }

            //var fileField = "--" + boundary + "\r\n";
            //fileField += "Content-Disposition: form-data; name=\"filename\"; filename=\"" + Path.GetFileName(filepath) + "\"\r\n";
            //fileField += "Content-Type: " + imageType + "\r\n\r\n";
            //var  b = Encoding.Default.GetBytes(fileField);
            //postStream.Write(b, 0, b.Length);


            // 文件域的数据
            sb.Append("--" + boundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"filename\"; filename=\"" + new FileInfo(filepath).Name + "\"");
            sb.Append("\r\n");

            sb.Append("Content-Type: ");
            sb.Append(imageType);
            sb.Append("\r\n\r\n\0");

            string postHeader = sb.ToString();
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(postHeader);

            //构造尾部数据 
            byte[] boundaryBytes =
            Encoding.ASCII.GetBytes("--" + boundary + "");

            FileStream fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            long length = postHeaderBytes.Length + fileStream.Length + boundaryBytes.Length;
            webrequest.ContentLength = length;

            Stream requestStream = webrequest.GetRequestStream();

            // 输入头部数据 
            requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);

            // 输入文件流数据 
            byte[] buffer = new Byte[checked((uint)Math.Min(4096, (int)fileStream.Length))];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                requestStream.Write(buffer, 0, bytesRead);

            // 输入尾部数据 
            requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);

            // 获取响应
            _myHttpWebResponse = (HttpWebResponse)webrequest.GetResponse();
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