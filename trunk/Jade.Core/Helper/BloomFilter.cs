using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Jade
{
    public abstract class BloomFilter<TValue> : IDisposable
    {
        private BitArray hashbits;
        private int numKeys;
        protected int[] hashKeys;

        public BloomFilter(int tableSize, int nKeys)
        {
            numKeys = nKeys;
            hashKeys = new int[numKeys];
            hashbits = new BitArray(tableSize);
        }

        /// <summary>
        /// 检验是否存在
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool Test(TValue val, bool add)
        {
            var hashs = CreateHashes(val);

            // Test each hash key.  Return false 
            //  if any one of the bits is not set.
            foreach (int hash in hashs)
            {
                if (!hashbits[hash])
                {
                    if (add)
                        this.Add(val);
                    return false;
                }
            }
            // All bits set.  The item is there.
            return true;
        }

        public bool Add(TValue val)
        {
            // Initially assume that the item is in the table
            bool rslt = true;
            var hashs = CreateHashes(val);
            foreach (int hash in hashs)
            {
                if (!hashbits[hash])
                {
                    // One of the bits wasn't set, so show that
                    // the item wasn't in the table, and set that bit.
                    rslt = false;
                    hashbits[hash] = true;
                }
            }
            return rslt;
        }

        protected virtual int[] CreateHashes(TValue val)
        {
            var result = new int[numKeys];

            int hash1 = CreateHash1(val);
            int hash2 = CreateHash2(val);

            hashKeys[0] = Math.Abs(hash1 % hashbits.Count);
            if (numKeys > 1)
            {
                for (int i = 1; i < numKeys; i++)
                {
                    result[i] = Math.Abs((hash1 + (i * hash2)) %
                                         hashbits.Count);
                }
            }

            return result;
        }

        protected abstract int CreateHash1(TValue val);

        protected abstract int CreateHash2(TValue val);

        public void LoadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    try
                    {
                        IFormatter formatter = new BinaryFormatter();
                        var result = (BitArray)formatter.Deserialize(stream);
                        if (result != null)
                        {
                            hashbits = result;
                        }
                    }
                    catch (Exception exception)
                    {
                        Log.Exception(exception);
                    }
                    finally
                    {
                        stream.Close();
                    }
                }

            }
        }

        object locker = new object();

        public void WriteToFile(string fileName)
        {
            lock (locker)
            {
                using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    try
                    {
                        IFormatter formatter = new BinaryFormatter();

                        formatter.Serialize(stream, hashbits);

                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        stream.Close();
                    }
                }

            }
        }

        public void Dispose()
        {
            this.hashbits = null;
            GC.Collect();
        }
    }

    public class StringBloomFilter : BloomFilter<string>
    {
        public StringBloomFilter(int tableSize, int nKeys)
            : base(tableSize, nKeys)
        {
        }

        protected override int CreateHash1(string val)
        {
            return val.GetHashCode();
        }

        protected override int CreateHash2(string val)
        {
            int hash = 0;

            for (int i = 0; i < val.Length; i++)
            {
                hash += val[i];
                hash += (hash << 10);
                hash ^= (hash >> 6);
            }
            hash += (hash << 3);
            hash ^= (hash >> 11);
            hash += (hash << 15);
            return hash;
        }
    }

    public class UrlFilter
    {
        static System.Timers.Timer timer = new System.Timers.Timer();

        static StringBloomFilter historyFilter = new StringBloomFilter(200000000, 4);

        static UrlFilter()
        {
            historyFilter.LoadFromFile("historyFilter.bin");
            timer.Interval = 5 * 60 * 1000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }

        private static object locker = new object();

        static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (locker)
            {
                try
                {
                    historyFilter.WriteToFile("historyFilter.bin");
                }
                catch
                {
                }
            }
        }

        public static bool Test(string url, bool add)
        {
            return historyFilter.Test(url, add);
        }

        public static void Add(string url)
        {
            historyFilter.Add(url);
        }
    }

    /// <summary>
    /// 单个站点的filter
    /// 每个domain 一个filter
    /// </summary>
    public class SiteUrlFilter : IDisposable
    {
        public int FilterCount { get; private set; }


        public string ContentPageFilterFilePath { get; set; }


        private StringBloomFilter domainFilter = null;


        System.Timers.Timer timer = new System.Timers.Timer();

        public SiteUrlFilter(string path, int filterCount = int.MaxValue/10)
        {
            ContentPageFilterFilePath = path;
            FilterCount = filterCount;
            domainFilter = new StringBloomFilter(filterCount, 4);

            timer.Interval = 5 * 60 * 1000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Start();

            try
            {
                domainFilter.LoadFromFile(path);
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 重建
        /// </summary>
        public void Rebuild()
        {
            domainFilter = new StringBloomFilter(FilterCount, 4);
            // 保存
            SaveFilter();
        }

        object locker = new object();

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (locker)
            {
                try
                {
                    SaveFilter();
                }
                catch
                {
                }
            }
        }

        public void SaveFilter()
        {
            domainFilter.WriteToFile(ContentPageFilterFilePath);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            try
            {
                timer.Stop();
                domainFilter.WriteToFile(ContentPageFilterFilePath);
                domainFilter.Dispose();
            }
            catch
            {
            }
        }

        public bool IsContentPageExist(string url, bool add)
        {
            return domainFilter.Test(url, add);
        }

        public void AddContentPage(string url)
        {
            domainFilter.Add(url);
        }
    }
}