using System.Threading;

namespace Jade.CQA.Robot.Utils
{
    /// <summary>
    /// �̼߳����������ڼ����߳���Ŀ��
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
        /// �����̼߳�����Scope ��ִ����ɺ��Զ��ͷż�����
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
        /// �̼߳�����Cookie 
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
            /// ִ����ɺ��ͷż���
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