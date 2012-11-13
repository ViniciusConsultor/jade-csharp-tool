using System.Collections.Generic;

using Jade.CQA.Robot.Utils;

namespace Jade.CQA.Robot.Services
{
    /// <summary>
    /// 内存历史记录
    /// </summary>
	public class InMemoryCrawlerHistoryService : HistoryServiceBase
	{
		#region Readonly & Static Fields

		private readonly HashSet<string> m_VisitedUrls = new HashSet<string>();

		#endregion

		#region Instance Methods

		protected override void Add(string key)
		{
			m_VisitedUrls.Add(key);
		}

		protected override bool Exists(string key)
		{
			return m_VisitedUrls.Contains(key);
		}

		protected override long GetRegisteredCount()
		{
			return m_VisitedUrls.Count;
		}

		#endregion
	}

    public class BloomFilterHistoryService : HistoryServiceBase
    {
        SiteUrlFilter fiter;
        public BloomFilterHistoryService()
        {
            fiter = new SiteUrlFilter("Filter.bin"); 
        }

        protected override void Add(string key)
        {
            fiter.AddContentPage(key);
        }

        protected override bool Exists(string key)
        {
            return fiter.IsContentPageExist(key, false);
        }

        protected override long GetRegisteredCount()
        {
            return 0;
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            fiter.Dispose();
        }
    }
}