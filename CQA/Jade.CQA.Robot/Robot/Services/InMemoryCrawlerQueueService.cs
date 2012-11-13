using System.Collections.Generic;

using Jade.CQA.Robot.Utils;
using System.IO;
using System;

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

    public class AutoGernateUrlQueueService : InMemoryFIFOCrawlerQueueService
    {
        public AutoGernateUrlQueueService()
            : base()
        {
            Start = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Start"]);
            End = int.Parse(System.Configuration.ConfigurationManager.AppSettings["End"]);
            Format = System.Configuration.ConfigurationManager.AppSettings["Format"];

            if (System.IO.File.Exists("index.bin"))
            {
                try
                {
                    var start = int.Parse(System.IO.File.ReadAllText("index.bin"));

                    if (start < Start && start > End)
                    {
                        Start = start;
                    }
                }
                catch
                {
                }
            }
        }


        int currentIndex = 0;

        string GetUrl()
        {
            lock (this)
            {
                File.WriteAllText("index.bin", Start.ToString());
                return string.Format(Format, Start--);
            }
        }

        CrawlerQueueEntry GernateQueque()
        {
            var entry = new CrawlerQueueEntry();
            entry.CrawlStep = new CrawlStep(new Uri(GetUrl()), 0);
            return entry;
        }

        public string Format
        {
            get;
            set;
        }


        public int Start
        {
            get;
            set;
        }

        public int End
        {
            get;
            set;
        }

        protected override long GetCount()
        {
            return (Start - End) + base.GetCount();
        }

        protected override CrawlerQueueEntry PopImpl()
        {
            return GetCount() == 0 ? null : (base.GetCount() == 0 ? GernateQueque() : base.PopImpl());
        }

        protected override void PushImpl(CrawlerQueueEntry crawlerQueueEntry)
        {
            base.PushImpl(crawlerQueueEntry);
        }
    }

}