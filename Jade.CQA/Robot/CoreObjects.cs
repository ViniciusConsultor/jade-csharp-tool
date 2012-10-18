using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Net;
using System.IO;

namespace Jade.CQA
{

    /// <summary>
    /// 爬虫爬行过程中的URL包装
    /// </summary>
    public class UrlWrapper
    {
        public string Title { get; set; }

        public string ReferUrl
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }

        public int Depth
        {
            get;
            set;
        }

        public bool IsContentPage
        {
            get;
            set;
        }

        public UrlWrapper(string url)
        {
            this.Url = url;
            this.Depth = 1;
            this.ReferUrl = "";
            this.IsContentPage = true;
            this.Title = "";
        }

        public UrlWrapper(UrlWrapper wrapper, string url)
        {
            this.Url = url;
            this.Depth = wrapper.Depth + 1;
            this.ReferUrl = wrapper.Url;
            this.IsContentPage = true;
            this.Title = "";
        }
    }

    /// <summary>
    /// 程序配置
    /// </summary>
    public class Setting
    {
        /// <summary>
        /// 最大深度
        /// </summary>
        public const int MAX_DEPTH = 6;

    }

    /// <summary>
    /// 管道
    /// </summary>
    public class PipeLine
    {
        /// <summary>
        /// 是否终止
        /// </summary>
        public bool Stop { get; set; }

        /// <summary>
        /// 当前Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 当前Url的网页
        /// </summary>
        public string Html { get; set; }

        /// <summary>
        /// 包含的url
        /// </summary>
        public List<UrlWrapper> Urls { get; set; }

        /// <summary>
        /// 执行
        /// </summary>
        public virtual void Execute()
        {
        }
    }

    /// <summary>
    /// 采集器步骤
    /// </summary>
    public class CrawlStep : IEquatable<CrawlStep>, IComparable<CrawlStep>, IComparable
    {
        #region Constructors

        public CrawlStep(Uri uri, int depth)
        {
            Uri = uri;
            Depth = depth;
            IsAllowed = true;
            IsExternalUrl = false;
        }

        #endregion

        #region Instance Properties

        [DataMember]
        public int Depth { get; private set; }

        [DataMember]
        public bool IsAllowed { get; set; }

        [DataMember]
        public bool IsExternalUrl { get; set; }

        [DataMember]
        public Uri Uri { get; internal set; }

        #endregion

        #region Instance Methods

        public override bool Equals(object other)
        {
            if (other.IsNull())
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (other is CrawlStep)
            {
                return Equals((CrawlStep)other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Depth;
                result = (result * 397) ^ IsAllowed.GetHashCode();
                result = (result * 397) ^ IsExternalUrl.GetHashCode();
                result = (result * 397) ^ (Uri != null ? Uri.GetHashCode() : 0);
                return result;
            }
        }

        public override string ToString()
        {
            return "Depth: {0}, IsAllowed: {1}, IsExternalUrl: {2}, Uri: {3}".FormatWith(Depth, IsAllowed, IsExternalUrl, Uri);
        }

        #endregion

        #region Operators

        public static bool operator ==(CrawlStep left, CrawlStep right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CrawlStep left, CrawlStep right)
        {
            return !Equals(left, right);
        }

        #endregion

        #region IComparable Members

        public int CompareTo(object obj)
        {
            return CompareTo(obj as CrawlStep);
        }

        #endregion

        #region IComparable<CrawlStep> Members

        public int CompareTo(CrawlStep other)
        {
            return Uri.ToString().CompareTo(other.Uri.ToString());
        }

        #endregion

        #region IEquatable<CrawlStep> Members

        public bool Equals(CrawlStep other)
        {
            if (other.IsNull())
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(other.Uri, Uri);
        }

        #endregion
    }

    /// <summary>
    /// 过滤器
    /// </summary>
    public interface IFilter
    {
        #region Instance Methods

        bool Match(Uri uri, CrawlStep referrer);

        #endregion
    }

    public abstract class DisposableBase : IDisposable
    {
        #region Instance Properties

        protected bool Disposed { get; private set; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Do cleanup here
        /// </summary>
        protected abstract void Cleanup();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || Disposed)
            {
                return;
            }

            Cleanup();
            Disposed = true;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);

            // Take off the finalization queue to prevent finalization from executing a second time.
            GC.SuppressFinalize(this);
        }

        #endregion
    }

    /// <summary>
    /// 函数链
    /// </summary>
    public class AspectF
    {
        #region Fields

        /// <summary>
        /// Chain of aspects to invoke
        /// </summary>
        internal Action<Action> m_Chain;

        /// <summary>
        /// The acrual work delegate that is finally called
        /// </summary>
        internal Delegate m_WorkDelegate;

        #endregion

        #region Instance Methods

        /// <summary>
        /// Create a composition of function e.g. f(g(x))
        /// </summary>
        /// <param name="newAspectDelegate">A delegate that offers an aspect's behavior. 
        /// It's added into the aspect chain</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public AspectF Combine(Action<Action> newAspectDelegate)
        {
            if (m_Chain.IsNull())
            {
                m_Chain = newAspectDelegate;
            }
            else
            {
                Action<Action> existingChain = m_Chain;
                Action<Action> callAnother = work => existingChain(() => newAspectDelegate(work));
                m_Chain = callAnother;
            }

            return this;
        }

        /// <summary>
        /// 执行函数（不返回，返回用Return)
        /// </summary>
        /// <param name="work">The actual code that needs to be run</param>
        [DebuggerStepThrough]
        public void Do(Action work)
        {
            if (m_Chain.IsNull())
            {
                work();
            }
            else
            {
                m_Chain(work);
            }
        }

        /// <summary>
        /// Execute your real code applying the aspects over it
        /// </summary>
        /// <param name="work">The actual code that needs to be run</param>
        [DebuggerStepThrough]
        public void Do<TParam1>(Action<TParam1> work) where TParam1 : IDisposable, new()
        {
            using (TParam1 p = new TParam1())
            {
                Do(p, work);
            }
        }

        /// <summary>
        /// Execute your real code applying the aspects over it
        /// </summary>
        /// <param name="p"></param>
        /// <param name="work">
        /// 	The actual code that needs to be run
        /// </param>
        [DebuggerStepThrough]
        public void Do<TParam1>(TParam1 p, Action<TParam1> work)
        {
            if (m_Chain.IsNull())
            {
                work(p);
            }
            else
            {
                m_Chain(() => work(p));
            }
        }

        /// <summary>
        /// 执行真正的函数并返回结果
        /// </summary>
        /// <typeparam name="TReturnType"></typeparam>
        /// <param name="work">The actual code that needs to be run</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public TReturnType Return<TReturnType>(Func<TReturnType> work)
        {
            m_WorkDelegate = work;

            if (m_Chain.IsNull())
            {
                return work();
            }

            TReturnType returnValue = default(TReturnType);
            m_Chain(() =>
            {
                Func<TReturnType> workDelegate = (Func<TReturnType>)m_WorkDelegate;
                returnValue = workDelegate();
            });
            return returnValue;
        }

        /// <summary>
        /// Execute your real code applying aspects over it.
        /// </summary>
        /// <typeparam name="TReturnType"></typeparam>
        /// <typeparam name="TParam1"></typeparam>
        /// <param name="work">The actual code that needs to be run</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public TReturnType Return<TReturnType, TParam1>(Func<TParam1, TReturnType> work) where TParam1 : IDisposable, new()
        {
            using (TParam1 p = new TParam1())
            {
                return Return(p, work);
            }
        }

        /// <summary>
        /// Execute your real code applying aspects over it.
        /// </summary>
        /// <typeparam name="TReturnType"></typeparam>
        /// <typeparam name="TParam1"></typeparam>
        /// <param name="p"></param>
        /// <param name="work">
        /// 	The actual code that needs to be run
        /// </param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public TReturnType Return<TReturnType, TParam1>(TParam1 p, Func<TParam1, TReturnType> work)
        {
            m_WorkDelegate = work;

            if (m_Chain.IsNull())
            {
                return work(p);
            }

            TReturnType returnValue = default(TReturnType);
            m_Chain(() =>
            {
                Func<TParam1, TReturnType> workDelegate = (Func<TParam1, TReturnType>)m_WorkDelegate;
                returnValue = workDelegate(p);
            });

            return returnValue;
        }

        #endregion

        #region Class Properties

        /// <summary>
        /// 流式接口
        /// Handy property to start writing aspects using fluent style
        /// </summary>
        public static AspectF Define
        {
            [DebuggerStepThrough]
            get { return new AspectF(); }
        }

        #endregion
    }

    /// <summary>
    /// 管道步骤
    /// </summary>
    public interface IPipelineStep
    {
        void Process(Crawler crawler);
    }

    #region 缓存

    /// <summary>
    /// 缓存
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Add(string key, object value);
        void Add(string key, object value, TimeSpan timeout);
        void Set(string key, object value);
        void Set(string key, object value, TimeSpan timeout);

        /// <summary>
        /// 是否包含
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Contains(string key);
        void Flush();

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        object Get(string key);

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);
    }

    /// <summary>
    /// 内存缓存（使用字典）
    /// </summary>
    public class DictionaryCache : DisposableBase, ICache
    {
        #region Readonly & Static Fields

        private readonly Dictionary<string, object> m_Cache = new Dictionary<string, object>();

        private readonly ReaderWriterLockSlim m_CacheLock =
            new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

        private readonly int m_MaxEntries;

        #endregion

        #region Constructors

        public DictionaryCache(int maxEntries)
        {
            m_MaxEntries = maxEntries;
        }

        #endregion

        #region Instance Methods

        protected override void Cleanup()
        {
            m_CacheLock.Dispose();
        }

        #endregion

        #region ICache Members

        public void Add(string key, object value)
        {
            AspectF.Define.
                WriteLock(m_CacheLock).
                Do(() =>
                {
                    if (!m_Cache.ContainsKey(key))
                    {
                        m_Cache.Add(key, value);
                    }

                    while (m_Cache.Count > m_MaxEntries)
                    {
                        m_Cache.Remove(m_Cache.Keys.First());
                    }
                });
        }

        public void Add(string key, object value, TimeSpan timeout)
        {
            Add(key, value);
        }

        public void Set(string key, object value)
        {
            AspectF.Define.
                WriteLock(m_CacheLock).
                Do(() => m_Cache[key] = value);
        }

        public void Set(string key, object value, TimeSpan timeout)
        {
            Set(key, value);
        }

        public bool Contains(string key)
        {
            return AspectF.Define.
                ReadLock(m_CacheLock).
                Return(() => m_Cache.ContainsKey(key));
        }

        public void Flush()
        {
            AspectF.Define.
                WriteLock(m_CacheLock).
                Do(() => m_Cache.Clear());
        }

        public object Get(string key)
        {
            return AspectF.Define.
                ReadLock(m_CacheLock).
                Return(() => m_Cache.ContainsKey(key) ? m_Cache[key] : null);
        }

        public void Remove(string key)
        {
            AspectF.Define.
                WriteLock(m_CacheLock).
                Do(() => m_Cache.Remove(key));
        }

        #endregion
    }

    #endregion

    #region Log

    /// <summary>
    /// 日志接口
    /// </summary>
    public interface ILog
    {
        void Verbose(string format, params object[] parameters);
        void Warning(string format, params object[] parameters);
        void Debug(string format, params object[] parameters);
        void Error(string format, params object[] parameters);
        void FatalError(string format, params object[] parameters);
    }

    /// <summary>
    /// Trace 日志
    /// </summary>
    public class SystemTraceLoggerService : ILog
    {
        #region ILog Members

        public void Verbose(string format, params object[] parameters)
        {
            Trace.TraceInformation(ToMessage(format, parameters));
        }

        public void Warning(string format, params object[] parameters)
        {
            Trace.TraceWarning(ToMessage(format, parameters));
        }

        public void Debug(string format, params object[] parameters)
        {
            System.Diagnostics.Debug.Write(ToMessage(format, parameters));
        }

        public void Error(string format, params object[] parameters)
        {
            Trace.TraceError(ToMessage(format, parameters));
        }

        public void FatalError(string format, params object[] parameters)
        {
            Trace.TraceError(ToMessage(format, parameters));
        }

        #endregion

        #region Class Methods

        private static string ToMessage(string format, object[] parameters)
        {
            return format.FormatWith(parameters);
        }

        #endregion
    }


    #endregion

    #region 工具

    /// <summary>
    /// 线程安全计数器
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

            protected override void Cleanup()
            {
                m_ThreadSafeCounter.Decrement();
            }

            #endregion
        }

        #endregion
    }

    #endregion

    #region 爬虫队列 Queue

    /// <summary>
    /// 队列
    /// </summary>
    [DataContract]
    [Serializable]
    public class CrawlerQueueEntry : IEquatable<CrawlerQueueEntry>, IComparable<CrawlerQueueEntry>, IComparable
    {
        #region Instance Properties

        /// <summary>
        /// 当前步骤
        /// </summary>
        [DataMember]
        public CrawlStep CrawlStep { get; set; }

        /// <summary>
        /// 引用步骤
        /// </summary>
        [DataMember]
        public CrawlStep Referrer { get; set; }

        #endregion

        #region Instance Methods

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != typeof(CrawlerQueueEntry))
            {
                return false;
            }

            return Equals((CrawlerQueueEntry)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (CrawlStep != null ? CrawlStep.GetHashCode() : 0);
                result = (result * 397) ^ (Referrer != null ? Referrer.GetHashCode() : 0);
                return result;
            }
        }

        public override string ToString()
        {
            return "CrawlStep: {0}, Referrer: {1}".FormatWith(CrawlStep, Referrer);
        }

        #endregion

        #region Operators

        public static bool operator ==(CrawlerQueueEntry left, CrawlerQueueEntry right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CrawlerQueueEntry left, CrawlerQueueEntry right)
        {
            return !Equals(left, right);
        }

        #endregion

        #region IComparable Members

        public int CompareTo(object obj)
        {
            return CompareTo((CrawlerQueueEntry)obj);
        }

        #endregion

        #region IComparable<CrawlerQueueEntry> Members

        public int CompareTo(CrawlerQueueEntry other)
        {
            return CrawlStep.CompareTo(other.CrawlStep);
        }

        #endregion

        #region IEquatable<CrawlerQueueEntry> Members

        public bool Equals(CrawlerQueueEntry other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(other.CrawlStep, CrawlStep) &&
                Equals(other.Referrer, Referrer);
        }

        #endregion
    }

    /// <summary>
    /// 爬虫队列
    /// </summary>
    public interface ICrawlerQueue
    {
        #region Instance Properties

        long Count { get; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// 	Get next entry to crawl
        /// </summary>
        /// <returns></returns>
        CrawlerQueueEntry Pop();

        /// <summary>
        /// 	Queue entry to crawl
        /// </summary>
        void Push(CrawlerQueueEntry crawlerQueueEntry);

        #endregion
    }

    /// <summary>
    /// 队列基类
    /// </summary>
    public abstract class CrawlerQueueServiceBase : DisposableBase, ICrawlerQueue
    {
        #region Readonly & Static Fields

        private readonly ReaderWriterLockSlim m_QueueLock =
            new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        #endregion

        #region Instance Methods

        protected abstract long GetCount();
        protected abstract CrawlerQueueEntry PopImpl();
        protected abstract void PushImpl(CrawlerQueueEntry crawlerQueueEntry);

        protected override void Cleanup()
        {
            m_QueueLock.Dispose();
        }

        #endregion

        #region ICrawlerQueue Members

        public CrawlerQueueEntry Pop()
        {
            return AspectF.Define.
                WriteLock(m_QueueLock).
                Return<CrawlerQueueEntry>(PopImpl);
        }

        public void Push(CrawlerQueueEntry crawlerQueueEntry)
        {
            AspectF.Define.
                WriteLock(m_QueueLock).
                Do(() => PushImpl(crawlerQueueEntry));
        }

        public long Count
        {
            get
            {
                return AspectF.Define.
                    ReadLock(m_QueueLock).
                    Return<long>(GetCount);
            }
        }

        #endregion
    }

    /// <summary>
    /// 内存队列
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

    #endregion

    #region 抓取历史 CrawlerHistory

    /// <summary>
    /// 抓取历史
    /// </summary>
    public interface ICrawlerHistory
    {
        #region Instance Properties

        long RegisteredCount { get; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// 	注册唯一标识
        /// </summary>
        /// <param name = "key">需要注册的唯一标识</param>
        /// <returns>false if key has already been registered else true</returns>
        bool Register(string key);

        #endregion
    }

    public abstract class HistoryServiceBase : DisposableBase, ICrawlerHistory
    {
        #region Readonly & Static Fields

        private readonly ReaderWriterLockSlim m_CrawlHistoryLock =
            new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

        #endregion

        #region Instance Methods

        protected abstract void Add(string key);
        protected abstract bool Exists(string key);
        protected abstract long GetRegisteredCount();

        protected override void Cleanup()
        {
            m_CrawlHistoryLock.Dispose();
        }

        #endregion

        #region ICrawlerHistory Members

        public virtual long RegisteredCount
        {
            get
            {
                return AspectF.Define.
                    ReadLock(m_CrawlHistoryLock).
                    Return(() => GetRegisteredCount());
            }
        }

        public virtual bool Register(string key)
        {
            return AspectF.Define.
                NotNullOrEmpty(key, "key").
                ReadLockUpgradable(m_CrawlHistoryLock).
                Return(() =>
                    {
                        bool exists = Exists(key);
                        if (!exists)
                        {
                            AspectF.Define.
                                WriteLock(m_CrawlHistoryLock).
                                Do(() => Add(key));
                        }

                        return !exists;
                    });
        }

        #endregion
    }

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

    #endregion


    /// <summary>
    /// 属性包
    /// </summary>
    [DataContract]
    public class PropertyBag : IEquatable<PropertyBag>, IComparable<PropertyBag>, IComparable
    {
        #region Fields

        // A Hashtable to contain the properties in the bag
        private Dictionary<string, Property> m_ObjPropertyCollection = new Dictionary<string, Property>();

        #endregion

        #region Instance Indexers

        /// <summary>
        /// Indexer which retrieves a property from the PropertyBag based on 
        /// the property name
        /// </summary>
        public Property this[string name]
        {
            get
            {
                if (m_ObjPropertyCollection == null)
                {
                    m_ObjPropertyCollection = new Dictionary<string, Property>();
                }

                // An instance of the Property that will be returned
                Property objProperty;

                // If the PropertyBag already contains a property whose name matches
                // the property required, ...
                if (m_ObjPropertyCollection.ContainsKey(name))
                {
                    // ... then return the pre-existing property
                    objProperty = m_ObjPropertyCollection[name];
                }
                else
                {
                    // ... otherwise, create a new Property with a matching name, and
                    // a null Value, and add it to the PropertyBag
                    objProperty = new Property(name, this);
                    m_ObjPropertyCollection.Add(name, objProperty);
                }

                return objProperty;
            }
        }

        #endregion

        #region Instance Properties

        /// <summary>
        /// CharacterSet
        /// </summary>
        [DataMember]
        public string CharacterSet { get; internal set; }

        /// <summary>
        /// 内容编码
        /// </summary>
        [DataMember]
        public string ContentEncoding { get; internal set; }

        /// <summary>
        /// 类型
        /// </summary>
        [DataMember]
        public string ContentType { get; internal set; }

        /// <summary>
        /// 下载时间
        /// </summary>
        [DataMember]
        public TimeSpan DownloadTime { get; internal set; }

        /// <summary>
        /// 响应头
        /// </summary>
        [DataMember]
        public WebHeaderCollection Headers { get; internal set; }

        /// <summary>
        /// 非否来自缓存
        /// </summary>
        [DataMember]
        public bool IsFromCache { get; internal set; }

        /// <summary>
        /// 是否通过认证
        /// </summary>
        [DataMember]
        public bool IsMutuallyAuthenticated { get; internal set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DataMember]
        public DateTime LastModified { get; internal set; }

        /// <summary>
        /// 请求方式
        /// </summary>
        [DataMember]
        public string Method { get; internal set; }

        /// <summary>
        /// 原始引用页
        /// </summary>
        [DataMember]
        public Uri OriginalReferrerUrl { get; internal set; }

        /// <summary>
        /// 原始URL
        /// </summary>
        [DataMember]
        public string OriginalUrl { get; internal set; }

        [DataMember]
        public Version ProtocolVersion { get; internal set; }

        /// <summary>
        /// 步骤
        /// </summary>
        [DataMember]
        public CrawlStep Referrer { get; internal set; }

        /// <summary>
        /// 获取结果
        /// </summary>
        [DataMember]
        public Func<Stream> GetResponse { get; set; }

        /// <summary>
        /// ResponseUri
        /// </summary>
        [DataMember]
        public Uri ResponseUri { get; internal set; }

        [DataMember]
        public string Server { get; internal set; }

        [DataMember]
        public HttpStatusCode StatusCode { get; internal set; }

        [DataMember]
        public string StatusDescription { get; internal set; }

        [DataMember]
        public CrawlStep Step { get; internal set; }

        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public string Title { get; set; }

        #endregion

        #region Instance Methods

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != typeof(PropertyBag))
            {
                return false;
            }

            return Equals((PropertyBag)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (m_ObjPropertyCollection != null ? m_ObjPropertyCollection.GetHashCode() : 0);
                result = (result * 397) ^ (CharacterSet != null ? CharacterSet.GetHashCode() : 0);
                result = (result * 397) ^ (ContentEncoding != null ? ContentEncoding.GetHashCode() : 0);
                result = (result * 397) ^ (ContentType != null ? ContentType.GetHashCode() : 0);
                result = (result * 397) ^ (Headers != null ? Headers.GetHashCode() : 0);
                result = (result * 397) ^ IsFromCache.GetHashCode();
                result = (result * 397) ^ IsMutuallyAuthenticated.GetHashCode();
                result = (result * 397) ^ LastModified.GetHashCode();
                result = (result * 397) ^ (Method != null ? Method.GetHashCode() : 0);
                result = (result * 397) ^ (OriginalReferrerUrl != null ? OriginalReferrerUrl.GetHashCode() : 0);
                result = (result * 397) ^ (OriginalUrl != null ? OriginalUrl.GetHashCode() : 0);
                result = (result * 397) ^ (ProtocolVersion != null ? ProtocolVersion.GetHashCode() : 0);
                result = (result * 397) ^ (Referrer != null ? Referrer.GetHashCode() : 0);
                result = (result * 397) ^ (ResponseUri != null ? ResponseUri.GetHashCode() : 0);
                result = (result * 397) ^ (Server != null ? Server.GetHashCode() : 0);
                result = (result * 397) ^ StatusCode.GetHashCode();
                result = (result * 397) ^ (StatusDescription != null ? StatusDescription.GetHashCode() : 0);
                result = (result * 397) ^ (Step != null ? Step.GetHashCode() : 0);
                result = (result * 397) ^ (Text != null ? Text.GetHashCode() : 0);
                result = (result * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                result = (result * 397) ^ DownloadTime.GetHashCode();
                return result;
            }
        }

        #endregion

        #region Operators

        public static bool operator ==(PropertyBag left, PropertyBag right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PropertyBag left, PropertyBag right)
        {
            return !Equals(left, right);
        }

        #endregion

        #region IComparable Members

        public int CompareTo(object obj)
        {
            return CompareTo(obj as PropertyBag);
        }

        #endregion

        #region IComparable<PropertyBag> Members

        public int CompareTo(PropertyBag other)
        {
            return Step.CompareTo(other.Step);
        }

        #endregion

        #region IEquatable<PropertyBag> Members

        public bool Equals(PropertyBag other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(other.m_ObjPropertyCollection, m_ObjPropertyCollection) &&
                Equals(other.CharacterSet, CharacterSet) &&
                Equals(other.ContentEncoding, ContentEncoding) &&
                Equals(other.ContentType, ContentType) &&
                Equals(other.Headers, Headers) &&
                other.IsFromCache.Equals(IsFromCache) &&
                other.IsMutuallyAuthenticated.Equals(IsMutuallyAuthenticated) &&
                other.LastModified.Equals(LastModified) &&
                Equals(other.Method, Method) &&
                Equals(other.OriginalReferrerUrl, OriginalReferrerUrl) &&
                Equals(other.OriginalUrl, OriginalUrl) &&
                Equals(other.ProtocolVersion, ProtocolVersion) &&
                Equals(other.Referrer, Referrer) &&
                Equals(other.ResponseUri, ResponseUri) &&
                Equals(other.Server, Server) &&
                Equals(other.StatusCode, StatusCode) &&
                Equals(other.StatusDescription, StatusDescription) &&
                Equals(other.Step, Step) &&
                Equals(other.Text, Text) &&
                Equals(other.Title, Title) &&
                other.DownloadTime.Equals(DownloadTime);
        }

        #endregion

        #region Nested type: Property

        public class Property
        {
            #region Fields

            /// Field to hold the name of the property 
            private object m_Value;

            #endregion

            #region Constructors

            /// Event fires immediately prior to value changes
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="name">The name of the new property</param>
            /// <param name="owner">The owner i.e. parent of the PropertyBag</param>
            public Property(string name, object owner)
            {
                Name = name;
                Owner = owner;
                m_Value = null;
            }

            #endregion

            #region Instance Properties

            /// <summary>
            /// The name of the Property
            /// </summary>
            public string Name { get; private set; }

            /// <summary>
            /// A pointer to the ultimate client class of the Property / PropertyBag
            /// </summary>
            public object Owner { get; private set; }

            /// <summary>
            /// The property value
            /// </summary>
            public object Value
            {
                get
                {
                    // The lock statement makes the class thread safe. Multiple threads 
                    // can attempt to get the value of the Property at the same time
                    lock (this)
                    {
                        return Owner.GetPropertyValue(Name, m_Value);
                    }
                }
                set
                {
                    // The lock statement makes the class thread safe. Multiple threads 
                    // can attempt to set the value of the Property at the same time
                    lock (this)
                    {
                        m_Value = value;
                        Owner.SetPropertyValue(Name, value);
                    }
                }
            }

            #endregion
        }

        #endregion
    }

    /// <summary>
    /// 临时文件 GC时自动删除
    /// TempFile creates a temp file, that deleted itself when garbage collected
    /// </summary>
    public class TempFile : DisposableBase
    {
        #region Constructors

        public TempFile()
        {
            FileName = GetTempFileName();
        }

        public TempFile(string fileName)
        {
            FileName = fileName;
        }

        #endregion

        #region Instance Properties

        public string FileName { get; set; }
        public string Tag { get; set; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Do cleanup here
        /// </summary>
        protected override void Cleanup()
        {
            AspectF.Define.
                IgnoreException<Exception>().
                Do(() =>
                    {
                        FileInfo fi = new FileInfo(FileName);
                        if (!fi.Exists)
                        {
                            return;
                        }

                        fi.Attributes = FileAttributes.Normal;
                        fi.Delete();
                    });
        }

        #endregion

        #region Class Methods

        public static string GetTempFileName()
        {
            return Path.GetTempFileName();
        }

        #endregion
    }

    /// <summary>
    /// 	Used for writing data to memory stream, but if data gets to large, writes dta to disk storage
    /// </summary>
    public class MemoryStreamWithFileBackingStore : Stream
    {
        #region Fields

        private MemoryStream m_MemoryStream = new MemoryStream();
        private long bytesWritten;
        private FileStream m_FileStoreStream;
        private readonly int m_BufferSize;
        private TempFile m_TempFile;
        private byte[] m_Data;

        #endregion

        #region Constructors

        public MemoryStreamWithFileBackingStore(int contentLength, long maxBytesInMemory, int bufferSize)
        {
            m_BufferSize = bufferSize;
            if (contentLength > maxBytesInMemory)
            {
                m_TempFile = new TempFile();
                m_FileStoreStream = m_FileStoreStream = new FileStream(m_TempFile.FileName, FileMode.Create, FileAccess.Write, FileShare.Write, m_BufferSize);
            }
            else
            {
                m_MemoryStream = new MemoryStream(contentLength < 0 ? m_BufferSize : contentLength);
            }
        }

        #endregion

        #region Instance Properties

        public override bool CanRead
        {
            get { return false; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override long Length
        {
            get { throw new NotImplementedException(); }
        }

        public override long Position
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        #endregion

        #region Instance Methods

        public override void Flush()
        {
            throw new NotImplementedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            bytesWritten += count;
            if (m_MemoryStream != null)
            {
                m_MemoryStream.Write(buffer, offset, count);
            }
            else
            {
                m_FileStoreStream.Write(buffer, offset, count);
            }
        }

        public void FinishedWriting()
        {
            if (m_MemoryStream != null)
            {
                m_Data = m_MemoryStream.ToArray();
                m_MemoryStream.Dispose();
                m_MemoryStream = null;
            }

            if (m_FileStoreStream != null)
            {
                m_FileStoreStream.Dispose();
                m_FileStoreStream = null;
            }
        }

        public Stream GetReaderStream()
        {
            if (!m_Data.IsNull())
            {
                return new MemoryStream(m_Data);
            }

            return new FileStream(m_TempFile.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, m_BufferSize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                FinishedWriting();

                if (!m_TempFile.IsNull())
                {
                    m_TempFile.Dispose();
                    m_TempFile = null;
                }
            }
        }

        #endregion
    }

    #region Web下载器 IWebDownloader

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

    public interface ITaskRunner
    {
        /// <summary>
        /// Returns true on success run without timeout
        /// </summary>
        /// <param name="action"></param>
        /// <param name="maxRuntime"></param>
        /// <returns>True on success</returns>
        bool RunSync(Action<CancelEventArgs> action, TimeSpan maxRuntime);
    }

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
                SetDefaultRequestProperties(requestState.Request);
                IAsyncResult asyncResult = requestState.Request.BeginGetResponse(null, requestState);
                asyncResult.FromAsync((ia, isTimeout) =>
                    {
                        if (isTimeout)
                        {
                            DownloadAsync(requestState, new TimeoutException("Connection Timeout"));
                        }
                        else
                        {
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
    }

    #endregion

    #region Robot 协议

    public interface IRobot
    {
        #region Instance Methods

        bool IsAllowed(string userAgent, Uri uri);

        #endregion
    }

    /// <summary>
    /// 	Taken from Searcharoo 7, and modifed
    /// </summary>
    public class RobotService : IRobot
    {
        #region Readonly & Static Fields

        private readonly Uri m_StartPageUri;
        private readonly IWebDownloader m_WebDownloader;

        #endregion

        #region Fields

        private string[] m_DenyUrls = new string[0];

        private bool m_Initialized;

        #endregion

        #region Constructors

        public RobotService(Uri startPageUri, IWebDownloader webDownloader)
        {
            m_StartPageUri = startPageUri;
            m_WebDownloader = webDownloader;
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// 	Does the parsed robots.txt file allow this Uri to be spidered for this user-agent?
        /// </summary>
        /// <remarks>
        /// 	This method does all its "matching" in uppercase - it expects the _DenyUrl 
        /// 	elements to be ToUpper() and it calls ToUpper on the passed-in Uri...
        /// </remarks>
        public bool Allowed(Uri uri)
        {
            if (!m_Initialized)
            {
                Initialize();
                m_Initialized = true;
            }

            if (m_DenyUrls.Length == 0)
            {
                return true;
            }

            string url = uri.AbsolutePath.ToUpperInvariant();
            if (m_DenyUrls.
                Where(denyUrlFragment => url.Length >= denyUrlFragment.Length).
                Any(denyUrlFragment => url.Substring(0, denyUrlFragment.Length) == denyUrlFragment))
            {
                return false;
            }

            return !url.Equals("/robots.txt", StringComparison.OrdinalIgnoreCase);
        }

        private void Initialize()
        {
            try
            {
                Uri robotsUri = new Uri("http://{0}/robots.txt".FormatWith(m_StartPageUri.Host));
                PropertyBag robots = m_WebDownloader.Download(new CrawlStep(robotsUri, 0), null, DownloadMethod.GET);

                if (robots == null || robots.StatusCode != HttpStatusCode.OK)
                {
                    return;
                }

                string fileContents;
                using (StreamReader stream = new StreamReader(robots.GetResponse(), Encoding.ASCII))
                {
                    fileContents = stream.ReadToEnd();
                }

                string[] fileLines = fileContents.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                bool rulesApply = false;
                List<string> rules = new List<string>();
                foreach (string line in fileLines)
                {
                    RobotInstruction ri = new RobotInstruction(line);
                    if (!ri.Instruction.IsNullOrEmpty())
                    {
                        switch (ri.Instruction[0])
                        {
                            case '#': //then comment - ignore
                                break;
                            case 'u': // User-Agent
                                if ((ri.UrlOrAgent.IndexOf("*") >= 0) || (ri.UrlOrAgent.IndexOf(m_WebDownloader.UserAgent) >= 0))
                                {
                                    // these rules apply
                                    rulesApply = true;
                                }
                                else
                                {
                                    rulesApply = false;
                                }
                                break;
                            case 'd': // Disallow
                                if (rulesApply)
                                {
                                    rules.Add(ri.UrlOrAgent.ToUpperInvariant());
                                }
                                break;
                            case 'a': // Allow
                                break;
                            default:
                                // empty/unknown/error
                                break;
                        }
                    }
                }

                m_DenyUrls = rules.ToArray();
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region IRobot Members

        public bool IsAllowed(string userAgent, Uri uri)
        {
            return Allowed(uri);
        }

        #endregion

        #region Nested type: RobotInstruction

        /// <summary>
        /// 	Use this class to read/parse the robots.txt file
        /// </summary>
        /// <remarks>
        /// 	Types of data coming into this class
        /// 	User-agent: * ==> _Instruction='User-agent', _Url='*'
        /// 	Disallow: /cgi-bin/ ==> _Instruction='Disallow', _Url='/cgi-bin/'
        /// 	Disallow: /tmp/ ==> _Instruction='Disallow', _Url='/tmp/'
        /// 	Disallow: /~joe/ ==> _Instruction='Disallow', _Url='/~joe/'
        /// </remarks>
        private class RobotInstruction
        {
            #region Constructors

            /// <summary>
            /// 	Constructor requires a line, hopefully in the format [instuction]:[url]
            /// </summary>
            public RobotInstruction(string line)
            {
                UrlOrAgent = string.Empty;
                string instructionLine = line;
                int commentPosition = instructionLine.IndexOf('#');
                if (commentPosition == 0)
                {
                    Instruction = "#";
                }

                if (commentPosition >= 0)
                {
                    // comment somewhere on the line, trim it off
                    instructionLine = instructionLine.Substring(0, commentPosition);
                }

                if (instructionLine.Length > 0)
                {
                    // wasn't just a comment line (which should have been filtered out before this anyway
                    string[] lineArray = instructionLine.Split(':');
                    Instruction = lineArray[0].Trim().ToUpperInvariant();
                    if (lineArray.Length > 1)
                    {
                        UrlOrAgent = lineArray[1].Trim();
                    }
                }
            }

            #endregion

            #region Instance Properties

            /// <summary>
            /// 	Upper-case part of robots.txt line, before the colon (:)
            /// </summary>
            public string Instruction { get; private set; }

            /// <summary>
            /// 	Upper-case part of robots.txt line, after the colon (:)
            /// </summary>
            public string UrlOrAgent { get; private set; }

            #endregion
        }

        #endregion
    }

    public class DummyRobot : IRobot
    {
        #region IRobot Members

        public bool IsAllowed(string userAgent, Uri uri)
        {
            return true;
        }

        #endregion
    }
    #endregion

    public interface ICrawlerRules
    {
        #region Instance Methods

        /// <summary>
        /// 	Checks if the crawler should follow an url
        /// </summary>
        /// <param name = "uri">Url to check</param>
        /// <param name = "referrer"></param>
        /// <returns>True if the crawler should follow the url, else false</returns>
        bool IsAllowedUrl(Uri uri, CrawlStep referrer);

        bool IsExternalUrl(Uri uri);

        #endregion
    }


    /// <summary>
    /// Handles logic of how to follow links when crawling
    /// </summary>
    public class CrawlerRulesService : ICrawlerRules
    {
        #region Readonly & Static Fields

        protected readonly Uri m_BaseUri;
        protected readonly Crawler m_Crawler;
        protected readonly IRobot m_Robot;

        #endregion

        #region Constructors

        public CrawlerRulesService(Crawler crawler, IRobot robot, Uri baseUri)
        {
            AspectF.Define.
                NotNull(crawler, "crawler").
                NotNull(robot, "robot").
                NotNull(baseUri, "baseUri");

            m_Crawler = crawler;
            m_Robot = robot;
            m_BaseUri = baseUri;
        }

        #endregion

        #region ICrawlerRules Members

        /// <summary>
        /// 	Checks if the crawler should follow an url
        /// </summary>
        /// <param name = "uri">Url to check</param>
        /// <param name = "referrer"></param>
        /// <returns>True if the crawler should follow the url, else false</returns>
        public virtual bool IsAllowedUrl(Uri uri, CrawlStep referrer)
        {
            if (m_Crawler.MaximumUrlSize.HasValue && m_Crawler.MaximumUrlSize.Value > 10 &&
                uri.ToString().Length > m_Crawler.MaximumUrlSize.Value)
            {
                return false;
            }

            if (!m_Crawler.IncludeFilter.IsNull() && m_Crawler.IncludeFilter.Any(f => f.Match(uri, referrer)))
            {
                return true;
            }

            if (!m_Crawler.ExcludeFilter.IsNull() && m_Crawler.ExcludeFilter.Any(f => f.Match(uri, referrer)))
            {
                return false;
            }

            if (IsExternalUrl(uri))
            {
                return false;
            }

            return !m_Crawler.AdhereToRobotRules || m_Robot.IsAllowed(m_Crawler.UserAgent, uri);
        }

        public virtual bool IsExternalUrl(Uri uri)
        {
            return m_BaseUri.IsHostMatch(uri);
        }

        #endregion
    }

    /// <summary>
    /// 爬虫
    /// </summary>
    public partial class Crawler : DisposableBase
    {
        #region Readonly & Static Fields

        protected readonly Uri m_BaseUri;
        private readonly ThreadSafeCounter m_ThreadInUse = new ThreadSafeCounter();
        private long m_VisitedCount;

        #endregion

        #region Fields

        protected ICrawlerHistory m_CrawlerHistory;
        protected ICrawlerQueue m_CrawlerQueue;
        protected ILog m_Logger;
        protected ITaskRunner m_TaskRunner;
        protected Func<IWebDownloader> m_WebDownloaderFactory;

        private bool m_Cancelled;
        private ManualResetEvent m_CrawlCompleteEvent;
        private bool m_CrawlStopped;
        private ICrawlerRules m_CrawlerRules;
        private bool m_Crawling;
        private long m_DownloadErrors;
        private Stopwatch m_Runtime;
        private bool m_OnlyOneCrawlPerInstance;

        #endregion

        #region Instance Properties

        /// <summary>
        /// Should the crawler follow the rules of the site beeing crawled.
        /// </summary>
        public bool AdhereToRobotRules { get; set; }

        public IEnumerable<IFilter> ExcludeFilter { get; set; }
        public IEnumerable<IFilter> IncludeFilter { get; set; }

        /// <summary>
        /// Maximum amount of time allowed to make a connection
        /// </summary>
        public TimeSpan? ConnectionReadTimeout { get; set; }

        /// <summary>
        /// In seconds
        /// </summary>
        public TimeSpan? ConnectionTimeout { get; set; }

        /// <summary>
        /// Maximum size a single download is allowed to be
        /// </summary>
        public uint? MaximumContentSize { get; set; }

        public uint DownloadBufferSize { get; set; }

        /// <summary>
        /// Maximum number of steps to download before ending crawl
        /// </summary>
        public int? MaximumCrawlCount { get; set; }

        /// <summary>
        /// Maximum levels to crawl into a website
        /// </summary>
        public int? MaximumCrawlDepth { get; set; }

        /// <summary>
        /// Maximum download error allowed before crawl is cancelled
        /// </summary>
        public int? MaximumHttpDownloadErrors { get; set; }

        /// <summary>
        /// Number of crawler threads to use
        /// </summary>
        public int MaximumThreadCount { get; set; }

        /// <summary>
        /// Maximum length of an url
        /// </summary>
        public int? MaximumUrlSize { get; set; }

        /// <summary>
        /// The maximum amount of time the crawler is allowed to run
        /// </summary>
        public TimeSpan? MaximumCrawlTime { get; set; }

        public IEnumerable<IPipelineStep> Pipeline { get; private set; }

        /// <summary>
        /// How many threads are currently in use
        /// </summary>
        public long ThreadsInUse
        {
            get { return m_ThreadInUse.Value; }
        }

        /// <summary>
        /// Determines how sensitive ncrawler is in following urls that contain upper and lower case characters
        /// </summary>
        public UriComponents UriSensitivity { get; set; }

        /// <summary>
        /// How the crawler should present itself to websites
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// How many times crawler should try to download a single url before giving up
        /// </summary>
        public int? DownloadRetryCount { get; set; }

        /// <summary>
        /// How long the crawler should wait before retrying a download
        /// </summary>
        public TimeSpan? DownloadRetryWaitDuration { get; set; }

        /// <summary>
        /// Use cookies when downloading
        /// </summary>
        public bool UseCookies { get; set; }

        /// <summary>
        /// How many url's are currently waiting to be downloaded/analysed
        /// </summary>
        public long WaitingQueueLength
        {
            get { return m_CrawlerQueue.Count; }
        }

        public uint MaximumDownloadSizeInRam { get; set; }

        #endregion

        public partial class Crawler
        {
            #region Instance Methods

            /// <summary>
            /// Returns true to continue crawl of this url, else false
            /// </summary>
            /// <returns>True if this step should be cancelled, else false</returns>
            private bool OnAfterDownload(CrawlStep crawlStep, PropertyBag response)
            {
                EventHandler<AfterDownloadEventArgs> afterDownloadTmp = AfterDownload;
                if (afterDownloadTmp.IsNull())
                {
                    return crawlStep.IsAllowed;
                }

                AfterDownloadEventArgs e =
                    new AfterDownloadEventArgs(!crawlStep.IsAllowed, response);
                afterDownloadTmp(this, e);
                return !e.Cancel;
            }

            /// <summary>
            /// Returns true to continue crawl of this url, else false
            /// </summary>
            /// <returns>True if this step should be cancelled, else false</returns>
            private bool OnBeforeDownload(CrawlStep crawlStep)
            {
                EventHandler<BeforeDownloadEventArgs> beforeDownloadTmp = BeforeDownload;
                if (beforeDownloadTmp.IsNull())
                {
                    return crawlStep.IsAllowed;
                }

                BeforeDownloadEventArgs e =
                    new BeforeDownloadEventArgs(!crawlStep.IsAllowed, crawlStep);
                beforeDownloadTmp(this, e);
                return !e.Cancel;
            }

            /// <summary>
            /// Executes OnProcessorException event
            /// </summary>
            private void OnCancelled()
            {
                Cancelled.ExecuteEvent(this, () => new EventArgs());
            }

            /// <summary>
            /// Executes CrawlFinished event
            /// </summary>
            private void OnCrawlFinished()
            {
                CrawlFinished.ExecuteEvent(this, () => new CrawlFinishedEventArgs(this));
            }

            /// <summary>
            /// Executes OnDownloadException event
            /// </summary>
            private void OnDownloadException(Exception exception, CrawlStep crawlStep, CrawlStep referrer)
            {
                long downloadErrors = Interlocked.Increment(ref m_DownloadErrors);
                if (MaximumHttpDownloadErrors.HasValue && MaximumHttpDownloadErrors.Value > downloadErrors)
                {
                    m_Logger.Error("Number of maximum failed downloads exceeded({0}), cancelling crawl", MaximumHttpDownloadErrors.Value);
                    StopCrawl();
                }

                m_Logger.Error("Download exception while downloading {0}, error was {1}", crawlStep.Uri, exception);
                DownloadException.ExecuteEvent(this, () => new DownloadExceptionEventArgs(crawlStep, referrer, exception));
            }

            /// <summary>
            /// Executes OnProcessorException event
            /// </summary>
            private void OnProcessorException(PropertyBag propertyBag, Exception exception)
            {
                m_Logger.Error("Exception while processing pipeline for {0}, error was {1}", propertyBag.OriginalUrl, exception);
                PipelineException.ExecuteEvent(this, () => new PipelineExceptionEventArgs(propertyBag, exception));
            }

            /// <summary>
            /// Executes DownloadProgress event
            /// </summary>
            private void OnDownloadProgress(DownloadProgressEventArgs downloadProgressEventArgs)
            {
                m_Logger.Error("Download progress for step {0}", downloadProgressEventArgs.Step.Uri);
                DownloadProgress.ExecuteEvent(this, () => downloadProgressEventArgs);
            }

            #endregion

            #region Event Declarations

            /// <summary>
            /// Event executed after each download, with option to cancel step
            /// </summary>
            public event EventHandler<AfterDownloadEventArgs> AfterDownload;

            /// <summary>
            /// Event executed before each download, with option to cancel step
            /// </summary>
            public event EventHandler<BeforeDownloadEventArgs> BeforeDownload;

            /// <summary>
            /// Event executed if crawl process has been cancelled
            /// </summary>
            public event EventHandler<EventArgs> Cancelled;

            /// <summary>
            /// Event executed when crawl has finished
            /// </summary>
            public event EventHandler<CrawlFinishedEventArgs> CrawlFinished;

            /// <summary>
            /// Event executed when an exception occours when downloading content
            /// </summary>
            public event EventHandler<DownloadExceptionEventArgs> DownloadException;

            /// <summary>
            /// Event executed if there is an exception when processing the pipeline
            /// </summary>
            public event EventHandler<PipelineExceptionEventArgs> PipelineException;

            /// <summary>
            /// Event executed between every download step
            /// </summary>
            public event EventHandler<DownloadProgressEventArgs> DownloadProgress;

            #endregion
        }

        protected override void Cleanup()
        {
            //throw new NotImplementedException();
        }
    }


}
