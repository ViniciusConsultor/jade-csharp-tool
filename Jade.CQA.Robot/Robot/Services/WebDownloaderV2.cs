using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;

using Jade.CQA.Robot.Event;
using Jade.CQA.Robot.Extensions;
using Jade.CQA.Robot.Interfaces;
using Jade.CQA.Robot.Utils;

namespace Jade.CQA.Robot.Services
{

    public enum DownloadMethod
    {
        GET,
        POST,
        HEAD,
    }

    public class WebDownloaderV2 : IWebDownloader
    {
        #region Constants

        private const uint DefaultDownloadBufferSize = 50 * 1024;

        #endregion

        #region Fields

        private CookieContainer m_CookieContainer;

        #endregion

        #region Instance Properties

        private CookieContainer CookieContainer
        {
            get { return m_CookieContainer ?? (m_CookieContainer = new CookieContainer()); }
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// 	设置默认参数
        /// </summary>
        /// <param name = "request"></param>
        protected virtual void SetDefaultRequestProperties(HttpWebRequest request)
        {
            request.AllowAutoRedirect = true;
            request.UserAgent = UserAgent;
            request.Accept = "*/*";
            request.KeepAlive = true;
            request.Pipelined = true;
            if (ConnectionTimeout.HasValue)
            {
                request.Timeout = Convert.ToInt32(ConnectionTimeout.Value.TotalMilliseconds);
            }

            if (ReadTimeout.HasValue)
            {
                request.ReadWriteTimeout = Convert.ToInt32(ReadTimeout.Value.TotalMilliseconds);
            }

            if (UseCookies)
            {
                request.CookieContainer = CookieContainer;
            }
        }

        private void DownloadAsync<T>(RequestState<T> requestState, Exception exception)
        {
            if (!exception.IsNull() && RetryWaitDuration.HasValue)
            {
                Thread.Sleep(RetryWaitDuration.Value);
            }

            if (requestState.Retry-- > 0)
            {
                requestState.Clean();
                requestState.Request = (HttpWebRequest)WebRequest.Create(requestState.CrawlStep.Uri);
                requestState.Request.Method = requestState.Method.ToString();
                if (this.Proxy != null)
                {
                    requestState.Request.Proxy = this.Proxy;
                }
                SetDefaultRequestProperties(requestState.Request);
                //异步调用并不是要减少线程的开销, 它的主要目的是让调用方法的主线程不需要同步等待在这个函数调用上, 从而可以让主线程继续执行它下面的代码.
                //与此同时, 系统会通过从ThreadPool中取一个线程来执行,帮助我们将我们要写/读的数据发送到网卡.
                IAsyncResult asyncResult = requestState.Request.BeginGetResponse(null, requestState);
                asyncResult.FromAsync((ia, isTimeout) =>
                {
                    // 超时
                    if (isTimeout)
                    {
                        // 重试下载
                        DownloadAsync(requestState, new TimeoutException("Connection Timeout"));
                    }
                    else
                    {
                        // 读取成功
                        ResponseCallback<T>(ia);
                    }
                }, ConnectionTimeout);
            }
            else
            {
                requestState.CallComplete(null, exception);
            }
        }

        /// <summary>
        /// 	Gets or Sets a value indicating if cookies will be stored.
        /// </summary>
        private PropertyBag DownloadInternalSync(CrawlStep crawlStep, CrawlStep referrer, DownloadMethod method)
        {
            PropertyBag result = null;
            Exception ex = null;
            using (ManualResetEvent resetEvent = new ManualResetEvent(false))
            {
                DownloadAsync<object>(crawlStep, referrer, method,
                    state =>
                    {
                        if (state.Exception.IsNull())
                        {
                            result = state.PropertyBag;
                            if (!result.GetResponse.IsNull())
                            {
                                using (Stream response = result.GetResponse())
                                {
                                    byte[] data;
                                    if (response is MemoryStream)
                                    {
                                        data = ((MemoryStream)response).ToArray();
                                    }
                                    else
                                    {
                                        using (MemoryStream copy = response.CopyToMemory())
                                        {
                                            data = copy.ToArray();
                                        }
                                    }

                                    result.GetResponse = () => new MemoryStream(data);
                                }
                            }
                        }
                        else
                        {
                            ex = state.Exception;
                        }

                        resetEvent.Set();
                    }, null, null);

                resetEvent.WaitOne();
            }

            if (!ex.IsNull())
            {
                throw new Exception("Error write downloading {0}".FormatWith(crawlStep.Uri), ex);
            }

            return result;
        }

        /// <summary>
        /// 结果回调
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="asynchronousResult"></param>
        private void ResponseCallback<T>(IAsyncResult asynchronousResult)
        {
            RequestState<T> requestState = (RequestState<T>)asynchronousResult.AsyncState;
            try
            {
                HttpWebRequest myHttpWebRequest = requestState.Request;
                HttpWebResponse response = (HttpWebResponse)myHttpWebRequest.EndGetResponse(asynchronousResult);

                uint downloadBufferSize = DownloadBufferSize.HasValue
                    ? DownloadBufferSize.Value
                    : DefaultDownloadBufferSize;
                requestState.ResponseBuffer = new MemoryStreamWithFileBackingStore((int)response.ContentLength,
                    MaximumDownloadSizeInRam.HasValue ? MaximumDownloadSizeInRam.Value : int.MaxValue,
                    (int)downloadBufferSize);

                // Read the response into a Stream object. 
                Stream responseStream = response.GetResponseStream();
                responseStream.CopyToStreamAsync(requestState.ResponseBuffer,
                    (source, dest, exception) =>
                    {
                        if (exception.IsNull())
                        {
                            CallComplete(requestState, response);
                        }
                        else
                        {
                            DownloadAsync(requestState, exception);
                        }
                    },
                    bd =>
                    {
                        if (!requestState.DownloadProgress.IsNull())
                        {
                            requestState.DownloadProgress(new DownloadProgressEventArgs
                            {
                                Referrer = requestState.Referrer,
                                Step = requestState.CrawlStep,
                                BytesReceived = bd,
                                TotalBytesToReceive = (uint)response.ContentLength,
                                DownloadTime = requestState.DownloadTimer.Elapsed,
                            });
                        }
                    },
                    downloadBufferSize, MaximumContentSize, ReadTimeout);
            }
            catch (WebException webException)
            {
                HttpWebResponse response = (HttpWebResponse)webException.Response;
                CallComplete(requestState, response);
            }
            catch (Exception e)
            {
                DownloadAsync(requestState, e);
            }
        }

        #endregion

        #region IWebDownloader Members

        public int? RetryCount { get; set; }
        public TimeSpan? RetryWaitDuration { get; set; }
        public TimeSpan? ConnectionTimeout { get; set; }
        public uint? MaximumContentSize { get; set; }
        public uint? MaximumDownloadSizeInRam { get; set; }
        public uint? DownloadBufferSize { get; set; }
        public TimeSpan? ReadTimeout { get; set; }
        public bool UseCookies { get; set; }
        public string UserAgent { get; set; }

        public PropertyBag Download(CrawlStep crawlStep, CrawlStep referrer, DownloadMethod method)
        {
            return DownloadInternalSync(crawlStep, referrer, method);
        }

        public void DownloadAsync<T>(CrawlStep crawlStep, CrawlStep referrer, DownloadMethod method,
            Action<RequestState<T>> completed, Action<DownloadProgressEventArgs> progress,
            T state)
        {
            AspectF.Define.
                NotNull(crawlStep, "crawlStep").
                NotNull(completed, "completed");

            if (UserAgent.IsNullOrEmpty())
            {
                UserAgent = "Mozilla/5.0";
            }

            RequestState<T> requestState = new RequestState<T>
            {
                DownloadTimer = Stopwatch.StartNew(),
                Complete = completed,
                CrawlStep = crawlStep,
                Referrer = referrer,
                State = state,
                DownloadProgress = progress,
                Retry = RetryCount.HasValue ? RetryCount.Value + 1 : 1,
                Method = method,
            };

            DownloadAsync(requestState, null);
        }

        #endregion

        #region Class Methods

        private static void CallComplete<T>(RequestState<T> requestState, HttpWebResponse response)
        {
            if (response != null)
            {
                requestState.CallComplete(
                    new PropertyBag
                    {
                        Step = requestState.CrawlStep,
                        CharacterSet = response.CharacterSet,
                        ContentEncoding = response.ContentEncoding,
                        ContentType = response.ContentType,
                        Headers = response.Headers,
                        IsMutuallyAuthenticated = response.IsMutuallyAuthenticated,
                        IsFromCache = response.IsFromCache,
                        LastModified = response.LastModified,
                        Method = response.Method,
                        ProtocolVersion = response.ProtocolVersion,
                        ResponseUri = response.ResponseUri,
                        Server = response.Server,
                        StatusCode = response.StatusCode,
                        StatusDescription = response.StatusDescription,
                        GetResponse = requestState.ResponseBuffer.IsNull()
                            ? (Func<Stream>)(() => new MemoryStream())
                            : requestState.ResponseBuffer.GetReaderStream,
                        DownloadTime = requestState.DownloadTimer.Elapsed,
                    }, null);
            }
            else
            {
                requestState.CallComplete(
                    new PropertyBag
                    {
                        Step = requestState.CrawlStep,
                        CharacterSet = string.Empty,
                        ContentEncoding = null,
                        ContentType = null,
                        Headers = null,
                        IsMutuallyAuthenticated = false,
                        IsFromCache = false,
                        LastModified = DateTime.Now,
                        Method = string.Empty,
                        ProtocolVersion = null,
                        ResponseUri = null,
                        Server = string.Empty,
                        StatusCode = HttpStatusCode.Forbidden,
                        StatusDescription = string.Empty,
                        GetResponse = requestState.ResponseBuffer.IsNull()
                            ? (Func<Stream>)(() => new MemoryStream())
                            : requestState.ResponseBuffer.GetReaderStream,
                        DownloadTime = requestState.DownloadTimer.Elapsed,
                    }, null);
            }
        }

        #endregion

        #region IWebDownloader 成员


        public WebProxy Proxy
        {
            get;
            set;
        }

        #endregion
    }
}