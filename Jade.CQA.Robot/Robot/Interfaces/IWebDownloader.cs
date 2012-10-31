using System;

using Jade.CQA.Robot.Event;
using Jade.CQA.Robot.Services;
using System.Net;

namespace Jade.CQA.Robot.Interfaces
{

    /// <summary>
    /// Web�������ӿ�
    /// </summary>
    public interface IWebDownloader
    {
        #region Instance Properties

        /// <summary>
        /// ��ʱʱ��
        /// </summary>
        TimeSpan? ConnectionTimeout { get; set; }

        /// <summary>
        /// ����buffer��С
        /// </summary>
        uint? DownloadBufferSize { get; set; }

        /// <summary>
        /// ������ݳ���
        /// </summary>
        uint? MaximumContentSize { get; set; }

        /// <summary>
        /// ����ڴ�����
        /// </summary>
        uint? MaximumDownloadSizeInRam { get; set; }

        /// <summary>
        /// ��ȡ��ʱʱ��
        /// </summary>
        TimeSpan? ReadTimeout { get; set; }

        /// <summary>
        /// ���Դ���
        /// </summary>
        int? RetryCount { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        TimeSpan? RetryWaitDuration { get; set; }

        /// <summary>
        /// �Ƿ�ʹ��Cookie
        /// </summary>
        bool UseCookies { get; set; }

        /// <summary>
        /// ʹ�õ�UserAgentͷ
        /// </summary>
        string UserAgent { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        WebProxy Proxy { get; set; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="crawlStep">��ǰ����</param>
        /// <param name="referrer">��һ��</param>
        /// <param name="method">���󷽷�</param>
        /// <returns></returns>
        PropertyBag Download(CrawlStep crawlStep, CrawlStep referrer, DownloadMethod method);

        /// <summary>
        /// �첽����
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