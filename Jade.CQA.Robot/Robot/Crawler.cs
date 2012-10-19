using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;

using Autofac;
using Autofac.Core;

using Jade.CQA.Robot.Extensions;
using Jade.CQA.Robot.Interfaces;
using Jade.CQA.Robot.Services;
using Jade.CQA.Robot.Utils;

namespace Jade.CQA.Robot
{
	public partial class Crawler : DisposableBase
	{
		#region Readonly & Static Fields

		protected readonly Uri m_BaseUri;

        /// <summary>
        /// IOC 容器
        /// </summary>
		private readonly ILifetimeScope m_LifetimeScope;

        /// <summary>
        /// 计数器（线程安全）
        /// </summary>
		private readonly ThreadSafeCounter m_ThreadInUse = new ThreadSafeCounter();
		private long m_VisitedCount;

		#endregion

		#region Fields

        /// <summary>
        /// 抓取历史
        /// </summary>
		protected ICrawlerHistory m_CrawlerHistory;

        /// <summary>
        /// 任务队列
        /// </summary>
		protected ICrawlerQueue m_CrawlerQueue;

        /// <summary>
        /// Log
        /// </summary>
		protected ILog m_Logger;

        /// <summary>
        /// Task 执行器
        /// </summary>
		protected ITaskRunner m_TaskRunner;

        /// <summary>
        /// web下载工厂
        /// </summary>
		protected Func<IWebDownloader> m_WebDownloaderFactory;

        /// <summary>
        /// 取消
        /// </summary>
		private bool m_Cancelled;

        /// <summary>
        /// 线程同步 通知一个或多个正在等待的线程已发生事件
        /// </summary>
		private ManualResetEvent m_CrawlCompleteEvent;

        /// <summary>
        /// 是否已停止
        /// </summary>
		private bool m_CrawlStopped;

        /// <summary>
        /// URL规则 （可以过滤URL）
        /// </summary>
		private ICrawlerRules m_CrawlerRules;

        /// <summary>
        /// 是否正在下载
        /// </summary>
		private bool m_Crawling;

        /// <summary>
        /// 下载错误数
        /// </summary>
		private long m_DownloadErrors;

        /// <summary>
        /// 计时器
        /// </summary>
		private Stopwatch m_Runtime;

        /// <summary>
        /// 一个爬虫单实例
        /// </summary>
		private bool m_OnlyOneCrawlPerInstance;

		#endregion

		#region Constructors

		/// <summary>
		/// 	爬虫构造器
		/// </summary>
		/// <param name = "crawlStart">入口页</param>
		/// <param name = "pipeline">管道步骤，可定义多个</param>
		public Crawler(Uri crawlStart, params IPipelineStep[] pipeline)
		{
			AspectF.Define.
				NotNull(crawlStart, "crawlStart").
				NotNull(pipeline, "pipeline");

            // 加载IOC容器
			m_LifetimeScope = CrawlerModule.Container.BeginLifetimeScope();
			m_BaseUri = crawlStart;
			MaximumCrawlDepth = null;
			AdhereToRobotRules = true;
			MaximumThreadCount = 1;
			Pipeline = pipeline;
			UriSensitivity = UriComponents.HttpRequestUrl;
			MaximumDownloadSizeInRam = 1024*1024;
			DownloadBufferSize = 50 * 1024;
		}

		#endregion

		#region Instance Methods

		/// <summary>
		/// 开始抓取流程
		/// </summary>
		public virtual void Crawl()
		{
			if (m_OnlyOneCrawlPerInstance)
			{
				throw new InvalidOperationException("Crawler instance cannot be reused");
			}

			m_OnlyOneCrawlPerInstance = true;

			Parameter[] parameters = new Parameter[]
				{
					new TypedParameter(typeof (Uri), m_BaseUri),
					new NamedParameter("crawlStart", m_BaseUri),
					new TypedParameter(typeof (Crawler), this),
				};
            // 队列
			m_CrawlerQueue = m_LifetimeScope.Resolve<ICrawlerQueue>(parameters);
			parameters = parameters.AddToEnd(new TypedParameter(typeof (ICrawlerQueue), m_CrawlerQueue)).ToArray();
			
            // 历史记录
            m_CrawlerHistory = m_LifetimeScope.Resolve<ICrawlerHistory>(parameters);
			parameters = parameters.AddToEnd(new TypedParameter(typeof (ICrawlerHistory), m_CrawlerHistory)).ToArray();
			
            // task
            m_TaskRunner = m_LifetimeScope.Resolve<ITaskRunner>(parameters);
			parameters = parameters.AddToEnd(new TypedParameter(typeof (ITaskRunner), m_TaskRunner)).ToArray();
            
            //log
			m_Logger = m_LifetimeScope.Resolve<ILog>(parameters);
			parameters = parameters.AddToEnd(new TypedParameter(typeof (ILog), m_Logger)).ToArray();

            // rules
			m_CrawlerRules = m_LifetimeScope.Resolve<ICrawlerRules>(parameters);
			m_Logger.Verbose("Crawl started @ {0}", m_BaseUri);
			m_WebDownloaderFactory = m_LifetimeScope.Resolve<Func<IWebDownloader>>();

			using (m_CrawlCompleteEvent = new ManualResetEvent(false))
			{
				m_Crawling = true;

                // 开启计时器
				m_Runtime = Stopwatch.StartNew();

				if (m_CrawlerQueue.Count > 0)
				{
					// Resume enabled
					ProcessQueue();
				}
				else
				{
					AddStep(m_BaseUri, 0);
				}

                // 阻塞线程 直到m_CrawlStopped
				if (!m_CrawlStopped)
				{
					m_CrawlCompleteEvent.WaitOne();
				}

				m_Runtime.Stop();

				m_Crawling = false;
			}

			if (m_Cancelled)
			{
				OnCancelled();
			}

			m_Logger.Verbose("Crawl ended @ {0} in {1}", m_BaseUri, m_Runtime.Elapsed);


			OnCrawlFinished();
		}

		/// <summary>
		/// 	添加一个任务进抓取队列
		/// </summary>
		/// <param name = "uri">url to crawl</param>
		/// <param name = "depth">depth of the url</param>
		public void AddStep(Uri uri, int depth)
		{
			AddStep(uri, depth, null, null);
		}

		/// <summary>
        /// 	添加一个任务进抓取队列
		/// </summary>
		/// <param name = "uri">待抓取url</param>
		/// <param name = "depth">url深度</param>
		/// <param name = "referrer">Step which the url was located</param>
		/// <param name = "properties">Custom properties</param>
		public void AddStep(Uri uri, int depth, CrawlStep referrer, Dictionary<string, object> properties)
		{
			if (!m_Crawling)
			{
				throw new InvalidOperationException("抓取器运行后才能添加任务！");
			}

			if (m_CrawlStopped)
			{
				return;
			}

            // 过滤URL 
			if ((uri.Scheme != Uri.UriSchemeHttps && uri.Scheme != Uri.UriSchemeHttp) || // Only accept http(s) schema
				(MaximumCrawlDepth.HasValue && MaximumCrawlDepth.Value > 0 && depth >= MaximumCrawlDepth.Value) ||
				!m_CrawlerRules.IsAllowedUrl(uri, referrer) ||
				!m_CrawlerHistory.Register(uri.GetUrlKeyString(UriSensitivity)))
			{
				if (depth == 0)
				{
					StopCrawl();
				}

				return;
			}

			// Make new crawl step
			CrawlStep crawlStep = new CrawlStep(uri, depth)
				{
					IsExternalUrl = m_CrawlerRules.IsExternalUrl(uri),
					IsAllowed = true,
				};

			m_CrawlerQueue.Push(new CrawlerQueueEntry
				{
					CrawlStep = crawlStep,
					Referrer = referrer,
					Properties = properties
				});
			m_Logger.Verbose("添加 {0} 入队列 来源页：{1}",
				crawlStep.Uri, referrer.IsNull() ? string.Empty : referrer.Uri.ToString());

            // process
			ProcessQueue();
		}

		public void Cancel()
		{
			if (!m_Crawling)
			{
				throw new InvalidOperationException("Crawler must be running before cancellation is possible");
			}

			m_Logger.Verbose("Cancelled crawler from {0}", m_BaseUri);
			if (m_Cancelled)
			{
				throw new ConstraintException("Already cancelled once");
			}

			m_Cancelled = true;
			StopCrawl();
		}

		protected override void Cleanup()
		{
			m_LifetimeScope.Dispose();
		}

        /// <summary>
        /// 网页下载完成
        /// </summary>
        /// <param name="requestState"></param>
		private void EndDownload(RequestState<ThreadSafeCounter.ThreadSafeCounterCookie> requestState)
		{
			using (requestState.State)
			{
                // 有异常
				if (requestState.Exception != null)
				{
					OnDownloadException(requestState.Exception, requestState.CrawlStep, requestState.Referrer);
				}

                // 结果不为空
				if (!requestState.PropertyBag.IsNull())
				{
					requestState.PropertyBag.Referrer = requestState.CrawlStep;

					// Assign initial properties to propertybag
					if (!requestState.State.CrawlerQueueEntry.Properties.IsNull())
					{
						requestState.State.CrawlerQueueEntry.Properties.
							ForEach(key => requestState.PropertyBag[key.Key].Value = key.Value);
					}

					if (OnAfterDownload(requestState.CrawlStep, requestState.PropertyBag))
					{
						// Executes all the pipelines sequentially for each downloaded content
						// in the crawl process. Used to extract data from content, like which
						// url's to follow, email addresses, aso.
						Pipeline.ForEach(pipelineStep => ExecutePipeLineStep(pipelineStep, requestState.PropertyBag));
					}
				}
			}

			ProcessQueue();
		}


        /// <summary>
        /// 抓取结果处理流程
        /// </summary>
        /// <param name="pipelineStep"></param>
        /// <param name="propertyBag"></param>
		private void ExecutePipeLineStep(IPipelineStep pipelineStep, PropertyBag propertyBag)
		{
			try
			{
				Stopwatch sw = Stopwatch.StartNew();
				m_Logger.Debug("Executing pipeline step {0}", pipelineStep.GetType().Name);
				if (pipelineStep is IPipelineStepWithTimeout)
				{
					IPipelineStepWithTimeout stepWithTimeout = (IPipelineStepWithTimeout) pipelineStep;
					m_Logger.Debug("Running pipeline step {0} with timeout {1}",
						pipelineStep.GetType().Name, stepWithTimeout.ProcessorTimeout);
					m_TaskRunner.RunSync(cancelArgs =>
						{
							if (!cancelArgs.Cancel)
							{
								pipelineStep.Process(this, propertyBag);
							}
						}, stepWithTimeout.ProcessorTimeout);
				}
				else
				{
					pipelineStep.Process(this, propertyBag);
				}

				m_Logger.Debug("Executed pipeline step {0} in {1}", pipelineStep.GetType().Name, sw.Elapsed);
			}
			catch (Exception ex)
			{
				OnProcessorException(propertyBag, ex);
			}
		}

        /// <summary>
        ///  处理队列
        /// </summary>
		private void ProcessQueue()
		{
			if (ThreadsInUse == 0 && WaitingQueueLength == 0)
			{
                // 释放
				m_CrawlCompleteEvent.Set();
				return;
			}

			if (m_CrawlStopped)
			{
				if (ThreadsInUse == 0)
				{
					m_CrawlCompleteEvent.Set();
				}

				return;
			}

            // 判断时间
			if (MaximumCrawlTime.HasValue && m_Runtime.Elapsed > MaximumCrawlTime.Value)
			{
				m_Logger.Verbose("Maximum crawl time({0}) exceeded, cancelling", MaximumCrawlTime.Value);
				StopCrawl();
				return;
			}

            // 最大抓取数目
			if (MaximumCrawlCount.HasValue && MaximumCrawlCount.Value > 0 &&
				MaximumCrawlCount.Value <= Interlocked.Read(ref m_VisitedCount))
			{
				m_Logger.Verbose("CrawlCount exceeded {0}, cancelling", MaximumCrawlCount.Value);
				StopCrawl();
				return;
			}

            // 队列有数据时持续下载
			while (ThreadsInUse < MaximumThreadCount && WaitingQueueLength > 0)
			{
				StartDownload();
			}
		}

        /// <summary>
        /// 开始下载
        /// </summary>
		private void StartDownload()
		{
            // 取出一个待抓取数据
			CrawlerQueueEntry crawlerQueueEntry = m_CrawlerQueue.Pop();
			if (crawlerQueueEntry.IsNull() || !OnBeforeDownload(crawlerQueueEntry.CrawlStep))
			{
				return;
			}

            // 构造web下载器
			IWebDownloader webDownloader = m_WebDownloaderFactory();
			webDownloader.MaximumDownloadSizeInRam = MaximumDownloadSizeInRam;
			webDownloader.ConnectionTimeout = ConnectionTimeout;
			webDownloader.MaximumContentSize = MaximumContentSize;
			webDownloader.DownloadBufferSize = DownloadBufferSize;
			webDownloader.UserAgent = UserAgent;
			webDownloader.UseCookies = UseCookies;
			webDownloader.ReadTimeout = ConnectionReadTimeout;
			webDownloader.RetryCount = DownloadRetryCount;
			webDownloader.RetryWaitDuration = DownloadRetryWaitDuration;
			m_Logger.Verbose("Downloading {0}", crawlerQueueEntry.CrawlStep.Uri);
			ThreadSafeCounter.ThreadSafeCounterCookie threadSafeCounterCookie = m_ThreadInUse.EnterCounterScope(crawlerQueueEntry);
			Interlocked.Increment(ref m_VisitedCount);

            // 开始下载
			webDownloader.DownloadAsync(crawlerQueueEntry.CrawlStep, crawlerQueueEntry.Referrer, DownloadMethod.GET,
				EndDownload, OnDownloadProgress, threadSafeCounterCookie);
		}

        /// <summary>
        /// 停止抓取
        /// </summary>
		private void StopCrawl()
		{
			if (m_CrawlStopped)
			{
				return;
			}

			m_CrawlStopped = true;
			if (ThreadsInUse == 0)
			{
				m_CrawlCompleteEvent.Set();
				return;
			}
		}

		#endregion
	}
}