using System;
using System.Diagnostics;
using System.Net;

using Jade.CQA.Robot.Event;
using Jade.CQA.Robot.Services;
using Jade.CQA.Robot.Utils;

namespace Jade.CQA.Robot
{
    /// <summary>
    /// 请求状态
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RequestState<T>
    {
        #region Instance Properties

        /// <summary>
        /// 采集步骤
        /// </summary>
        public CrawlStep CrawlStep { get; set; }

        /// <summary>
        /// 执行异常
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// 下载方式
        /// </summary>
        public DownloadMethod Method { get; set; }

        /// <summary>
        /// 请求结果
        /// </summary>
        public PropertyBag PropertyBag { get; set; }

        /// <summary>
        /// 引用步骤
        /// </summary>
        public CrawlStep Referrer { get; set; }

        /// <summary>
        /// 结束
        /// </summary>
        public Action<RequestState<T>> Complete { private get; set; }

        /// <summary>
        /// 下载中
        /// </summary>
        public Action<DownloadProgressEventArgs> DownloadProgress { get; set; }

        /// <summary>
        /// 下载计时器
        /// </summary>
        public Stopwatch DownloadTimer { get; set; }

        /// <summary>
        /// web请求
        /// </summary>
        public HttpWebRequest Request { get; set; }

        /// <summary>
        /// 响应buffer
        /// </summary>
        public MemoryStreamWithFileBackingStore ResponseBuffer { get; set; }

        /// <summary>
        /// 重试次数
        /// </summary>
        public int Retry { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public T State { get; set; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// 执行完成操作
        /// </summary>
        /// <param name="propertyBag"></param>
        /// <param name="exception"></param>
        public void CallComplete(PropertyBag propertyBag, Exception exception)
        {
            Clean();

            PropertyBag = propertyBag;
            Exception = exception;
            Complete(this);
        }

        /// <summary>
        /// 清理
        /// </summary>
        public void Clean()
        {
            if (ResponseBuffer != null)
            {
                ResponseBuffer.FinishedWriting();
                ResponseBuffer = null;
            }
        }

        #endregion
    }
}