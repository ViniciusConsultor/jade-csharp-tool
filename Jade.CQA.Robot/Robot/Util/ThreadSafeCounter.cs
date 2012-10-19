using System.Threading;

namespace Jade.CQA.Robot.Utils
{
    /// <summary>
    /// 线程计数器（用于计量线程数目）
    /// </summary>
	internal class ThreadSafeCounter
	{
		#region Fields

		private long m_Counter;

		#endregion

		#region Instance Properties

		public long Value
		{
			get { return Interlocked.Read(ref m_Counter); }
		}

		#endregion

		#region Instance Methods

        /// <summary>
        /// 进入线程计数器Scope （执行完成后，自动释放计数）
        /// </summary>
        /// <param name="crawlerQueueEntry"></param>
        /// <returns></returns>
		public ThreadSafeCounterCookie EnterCounterScope(CrawlerQueueEntry crawlerQueueEntry)
		{
			Increment();
			return new ThreadSafeCounterCookie(this, crawlerQueueEntry);
		}

        
		private void Decrement()
		{
			Interlocked.Decrement(ref m_Counter);
		}

		private void Increment()
		{
			Interlocked.Increment(ref m_Counter);
		}

		#endregion

		#region Nested type: ThreadSafeCounterCookie

        /// <summary>
        /// 线程计数器Cookie 
        /// </summary>
		internal class ThreadSafeCounterCookie : DisposableBase
		{
			#region Readonly & Static Fields

			private readonly ThreadSafeCounter m_ThreadSafeCounter;

			#endregion

			#region Constructors

			public ThreadSafeCounterCookie(ThreadSafeCounter threadSafeCounter, CrawlerQueueEntry crawlerQueueEntry)
			{
				m_ThreadSafeCounter = threadSafeCounter;
				CrawlerQueueEntry = crawlerQueueEntry;
			}

			#endregion

			#region Instance Methods

			public CrawlerQueueEntry CrawlerQueueEntry { get; private set; }

            /// <summary>
            /// 执行完成后释放计数
            /// </summary>
			protected override void Cleanup()
			{
				m_ThreadSafeCounter.Decrement();
			}

			#endregion
		}

		#endregion
	}
}