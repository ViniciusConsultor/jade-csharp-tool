using System;

using Jade.CQA.Robot.Event;
using Jade.CQA.Robot.Services;
using System.Net;

namespace Jade.CQA.Robot.Interfaces
{

    /// <summary>
    /// Web下载器接口
    /// </summary>
    public interface IWebDownloader
    {
        #region Instance Properties

        /// <summary>
        /// 超时时间
        /// </summary>
        TimeSpan? ConnectionTimeout { get; set; }

        /// <summary>
        /// 下载buffer大小
        /// </summary>
        uint? DownloadBufferSize { get; set; }

        /// <summary>
        /// 最大内容长度
        /// </summary>
        uint? MaximumContentSize { get; set; }

        /// <summary>
        /// 最大内存容量
        /// </summary>
        uint? MaximumDownloadSizeInRam { get; set; }

        /// <summary>
        /// 读取超时时间
        /// </summary>
        TimeSpan? ReadTimeout { get; set; }

        /// <summary>
        /// 重试次数
        /// </summary>
        int? RetryCount { get; set; }

        /// <summary>
        /// 重试时间
        /// </summary>
        TimeSpan? RetryWaitDuration { get; set; }

        /// <summary>
        /// 是否使用Cookie
        /// </summary>
        bool UseCookies { get; set; }

        /// <summary>
        /// 使用的UserAgent头
        /// </summary>
        string UserAgent { get; set; }

        /// <summary>
        /// 代理
        /// </summary>
        WebProxy Proxy { get; set; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="crawlStep">当前步骤</param>
        /// <param name="referrer">上一步</param>
        /// <param name="method">请求方法</param>
        /// <returns></returns>
        PropertyBag Download(CrawlStep crawlStep, CrawlStep referrer, DownloadMethod method);

        /// <summary>
        /// 异步下载
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="crawlStep"></param>
        /// <param name="referrer"></param>
        /// <param name="method"></param>
        /// <param name="completed"></param>
        /// <param name="progress"></param>
        /// <param name="state"></param>
        void DownloadAsync<T>(CrawlStep crawlStep, CrawlStep referrer, DownloadMethod method,
            Action<RequestState<T>> completed, Action<DownloadProgressEventArgs> progress, T state);

        #endregion
    }
}