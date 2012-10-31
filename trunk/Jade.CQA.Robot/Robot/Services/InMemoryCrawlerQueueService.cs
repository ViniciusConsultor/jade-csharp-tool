using System.Collections.Generic;

using Jade.CQA.Robot.Utils;

namespace Jade.CQA.Robot.Services
{
    /// <summary>
    /// 使用栈，深度优先
    /// </summary>
	public class InMemoryCrawlerQueueService : CrawlerQueueServiceBase
	{
		#region Readonly & Static Fields

		private readonly Stack<CrawlerQueueEntry> m_Stack = new Stack<CrawlerQueueEntry>();

		#endregion

		#region Instance Methods

		protected override long GetCount()
		{
			return m_Stack.Count;
		}

		protected override CrawlerQueueEntry PopImpl()
		{
			return m_Stack.Count == 0 ? null : m_Stack.Pop();
		}

		protected override void PushImpl(CrawlerQueueEntry crawlerQueueEntry)
		{
			m_Stack.Push(crawlerQueueEntry);
		}

		#endregion
	}

    /// <summary>
    /// 使用队列作为调度（先进先出，广度优先）
    /// </summary>
    public class InMemoryFIFOCrawlerQueueService : CrawlerQueueServiceBase
    {
        #region Readonly & Static Fields

        private readonly Queue<CrawlerQueueEntry> m_Stack = new Queue<CrawlerQueueEntry>();

        #endregion

        #region Instance Methods

        protected override long GetCount()
        {
            return m_Stack.Count;
        }

        protected override CrawlerQueueEntry PopImpl()
        {
            return m_Stack.Count == 0 ? null : m_Stack.Dequeue();
        }

        protected override void PushImpl(CrawlerQueueEntry crawlerQueueEntry)
        {
            m_Stack.Enqueue(crawlerQueueEntry);
        }

        #endregion
    }
}