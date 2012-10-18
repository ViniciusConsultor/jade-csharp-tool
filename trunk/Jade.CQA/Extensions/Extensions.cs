using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Jade.CQA
{
    public static class StringExtensions
    {
        #region Class Methods

        public static string FormatWith(this string source, params object[] parameters)
        {
            return string.Format(CultureInfo.InvariantCulture, source, parameters);
        }

        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        #endregion
    }

    public static class ObjectExtensions
    {
        #region Class Methods

        /// <summary>
        /// Dynamically retrieves a property value.
        /// </summary>
        /// <typeparam name="T">The expected return data type</typeparam>
        /// <param name="obj">The object to perform on.</param>
        /// <param name="propertyName">The Name of the property.</param>
        /// <param name="defaultValue">The default value to return.</param>
        /// <returns>The property value.</returns>
        /// <example>
        /// <code>
        /// var type = Type.GetType("System.IO.FileInfo, mscorlib");
        /// var file = type.CreateInstance(@"c:\autoexec.bat");
        /// if(file.GetPropertyValue&lt;bool&gt;("Exists")) {
        ///  var reader = file.InvokeMethod&lt;StreamReader&gt;("OpenText");
        ///  Console.WriteLine(reader.ReadToEnd());
        ///  reader.Close();
        /// }
        /// </code>
        /// </example>
        public static T GetPropertyValue<T>(this object obj, string propertyName, T defaultValue)
        {
            Type type = obj.GetType();
            PropertyInfo property = type.GetProperty(propertyName);

            if (property.IsNull())
            {
                return defaultValue;
            }

            object value = property.GetValue(obj, null);
            return value is T ? (T)value : defaultValue;
        }

        /// <summary>
        /// Dynamically sets a property value.
        /// </summary>
        /// <param name="obj">The object to perform on.</param>
        /// <param name="propertyName">The Name of the property.</param>
        /// <param name="value">The value to be set.</param>
        public static void SetPropertyValue(this object obj, string propertyName, object value)
        {
            Type type = obj.GetType();
            PropertyInfo property = type.GetProperty(propertyName);

            if (!property.IsNull())
            {
                property.SetValue(obj, value, null);
            }
        }

        public static bool IsNull<T>(this T @object)
        {
            return Equals(@object, null);
        }

        public static byte[] ToBinary<T>(this T o) where T : class, new()
        {
            DataContractSerializer dc = new DataContractSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                dc.WriteObject(ms, o);
                return ms.ToArray();
            }
        }

        public static T FromBinary<T>(this byte[] byteArray) where T : class, new()
        {
            DataContractSerializer dc = new DataContractSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(byteArray, 0, byteArray.Length);
                ms.Seek(0, SeekOrigin.Begin);
                return dc.ReadObject(ms) as T;
            }
        }

        public static bool IsIn<T>(this T t, params T[] tt)
        {
            return tt.Contains(t);
        }

        #endregion
    }

    public static class AspectExtensions
    {
        #region Class Methods

        [DebuggerStepThrough]
        public static AspectF Cache<TReturnType>(this AspectF aspect,
            ICache cacheResolver, string key)
        {
            return aspect.Combine(work => Cache<TReturnType>(aspect, cacheResolver, key, work, cached => cached));
        }

        [DebuggerStepThrough]
        public static AspectF CacheList<TItemType, TListType>(this AspectF aspect,
            ICache cacheResolver, string listCacheKey, Func<TItemType, string> getItemKey)
            where TListType : IList<TItemType>, new()
        {
            return aspect.Combine(work =>
            {
                Func<TListType> workDelegate = (Func<TListType>)aspect.m_WorkDelegate;

                // Replace the actual work delegate with a new delegate so that
                // when the actual work delegate returns a collection, each item
                // in the collection is stored in cache individually.
                Func<TListType> newWorkDelegate = () =>
                {
                    TListType collection = workDelegate();
                    foreach (TItemType item in collection)
                    {
                        string key = getItemKey(item);
                        cacheResolver.Set(key, item);
                    }
                    return collection;
                };
                aspect.m_WorkDelegate = newWorkDelegate;

                // Get the collection from cache or real source. If collection is returned
                // from cache, resolve each item in the collection from cache
                Cache<TListType>(aspect, cacheResolver, listCacheKey, work,
                    cached =>
                    {
                        // Get each item from cache. If any of the item is not in cache
                        // then discard the whole collection from cache and reload the 
                        // collection from source.
                        TListType itemList = new TListType();
                        foreach (TItemType item in cached)
                        {
                            object cachedItem = cacheResolver.Get(getItemKey(item));
                            if (null != cachedItem)
                            {
                                itemList.Add((TItemType)cachedItem);
                            }
                            else
                            {
                                // One of the item is missing from cache. So, discard the 
                                // cached list.
                                return default(TListType);
                            }
                        }

                        return itemList;
                    });
            });
        }

        [DebuggerStepThrough]
        public static AspectF CacheRetry<TReturnType>(this AspectF aspect,
            ICache cacheResolver,
            string key)
        {
            return aspect.Combine(work =>
            {
                try
                {
                    Cache<TReturnType>(aspect, cacheResolver, key, work, cached => cached);
                }
                catch
                {
                    Thread.Sleep(1000);

                    //Retry
                    Cache<TReturnType>(aspect, cacheResolver, key, work, cached => cached);
                }
            });
        }

        /// <summary>
        /// 延时执行
        /// </summary>
        /// <param name="aspect"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static AspectF Delay(this AspectF aspect, int milliseconds)
        {
            return aspect.Combine(work =>
            {
                Thread.Sleep(milliseconds);
                work();
            });
        }

        /// <summary>
        /// 忽略异常
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aspect"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static AspectF IgnoreException<T>(this AspectF aspect) where T : Exception
        {
            return aspect.Combine(work =>
            {
                try
                {
                    work();
                }
                catch (T)
                {
                }
            });
        }

        [DebuggerStepThrough]
        public static AspectF IgnoreExceptions(this AspectF aspect)
        {
            return aspect.Combine(work =>
            {
                try
                {
                    work();
                }
                catch
                {
                }
            });
        }

        [DebuggerStepThrough]
        public static AspectF MustBeNonDefault<T>(this AspectF aspect, params T[] args)
            where T : IComparable
        {
            return aspect.Combine(work =>
            {
                T defaultvalue = default(T);
                for (int i = 0; i < args.Length; i++)
                {
                    T arg = args[i];
                    if (arg.IsNull() || arg.Equals(defaultvalue))
                    {
                        throw new ArgumentException(string.Format("Parameter at index {0} is null", i));
                    }
                }

                work();
            });
        }

        [DebuggerStepThrough]
        public static AspectF MustBeNonNull(this AspectF aspect, params object[] args)
        {
            return aspect.Combine(work =>
            {
                for (int i = 0; i < args.Length; i++)
                {
                    object arg = args[i];
                    if (arg.IsNull())
                    {
                        throw new ArgumentException(string.Format("Parameter at index {0} is null", i));
                    }
                }

                work();
            });
        }

        [DebuggerStepThrough]
        public static AspectF NotNull(this AspectF aspect, object @object, string parameterName)
        {
            if (@object.IsNull())
            {
                throw new ArgumentNullException(parameterName);
            }

            return aspect;
        }

        [DebuggerStepThrough]
        public static AspectF NotNullOrEmpty(this AspectF aspect, string @object, string parameterName)
        {
            if (@object.IsNullOrEmpty())
            {
                throw new ArgumentNullException(parameterName);
            }

            return aspect;
        }

        [DebuggerStepThrough]
        public static AspectF ReadLock(this AspectF aspect, ReaderWriterLockSlim @lock)
        {
            return aspect.Combine(work =>
            {
                @lock.EnterReadLock();
                try
                {
                    work();
                }
                finally
                {
                    @lock.ExitReadLock();
                }
            });
        }

        /// <summary>
        /// 开启读锁
        /// </summary>
        /// <param name="aspect"></param>
        /// <param name="lock"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static AspectF ReadLockUpgradable(this AspectF aspect, ReaderWriterLockSlim @lock)
        {
            return aspect.Combine(work =>
            {
                @lock.EnterUpgradeableReadLock();
                try
                {
                    work();
                }
                finally
                {
                    @lock.ExitUpgradeableReadLock();
                }
            });
        }

        [DebuggerStepThrough]
        public static AspectF Retry(this AspectF aspects)
        {
            return aspects.Combine(work =>
                Retry(TimeSpan.FromSeconds(1), 1, (error, retry) => DoNothing(error), x => DoNothing(), work));
        }

        [DebuggerStepThrough]
        public static AspectF Retry(this AspectF aspects, Action<IEnumerable<Exception>> failHandler)
        {
            return aspects.Combine(work =>
                Retry(TimeSpan.FromSeconds(1), 1, (error, retry) => DoNothing(error), x => DoNothing(), work));
        }

        [DebuggerStepThrough]
        public static AspectF Retry(this AspectF aspects, TimeSpan retryDuration)
        {
            return aspects.Combine(work =>
                Retry(retryDuration, 1, (error, retry) => DoNothing(error), x => DoNothing(), work));
        }

        [DebuggerStepThrough]
        public static AspectF Retry(this AspectF aspects, TimeSpan retryDuration,
            Action<Exception, int> errorHandler)
        {
            return aspects.Combine(work =>
                Retry(retryDuration, 1, errorHandler, x => DoNothing(), work));
        }

        [DebuggerStepThrough]
        public static AspectF Retry(this AspectF aspects, TimeSpan retryDuration,
            int retryCount, Action<Exception, int> errorHandler)
        {
            return aspects.Combine(work =>
                Retry(retryDuration, retryCount, errorHandler, x => DoNothing(), work));
        }

        [DebuggerStepThrough]
        public static AspectF Retry(this AspectF aspects, TimeSpan retryDuration,
            int retryCount, Action<Exception, int> errorHandler, Action<IEnumerable<Exception>> retryFailed)
        {
            return aspects.Combine(work =>
                Retry(retryDuration, retryCount, errorHandler, retryFailed, work));
        }

        [DebuggerStepThrough]
        public static void Retry(TimeSpan retryDuration, int retryCount,
            Action<Exception, int> errorHandler, Action<IEnumerable<Exception>> retryFailed, Action work)
        {
            List<Exception> errors = null;
            int maxRetries = retryCount;
            do
            {
                try
                {
                    work();
                    return;
                }
                catch (Exception x)
                {
                    if (null == errors)
                    {
                        errors = new List<Exception>();
                    }

                    errors.Add(x);
                    if (!errorHandler.IsNull())
                    {
                        errorHandler(x, maxRetries - retryCount);
                    }

                    Thread.Sleep(retryDuration);
                }
            } while (retryCount-- > 0);
            if (!retryFailed.IsNull())
            {
                retryFailed(errors);
            }
        }

        [DebuggerStepThrough]
        public static AspectF RunAsync(this AspectF aspect, Action completeCallback)
        {
            return aspect.Combine(work => work.BeginInvoke(asyncresult =>
            {
                work.EndInvoke(asyncresult);
                completeCallback();
            }, null));
        }

        [DebuggerStepThrough]
        public static AspectF Timer(this AspectF aspect, string title)
        {
            return aspect.Combine(work =>
            {
                Stopwatch start = Stopwatch.StartNew();
                work();
                start.Stop();
                Console.Out.WriteLine("{0}: {1}", title, start.Elapsed);
            });
        }

        [DebuggerStepThrough]
        public static AspectF Until(this AspectF aspect, Func<bool> test)
        {
            return aspect.Combine(work =>
            {
                while (!test()) ;
                work();
            });
        }

        [DebuggerStepThrough]
        public static AspectF WhenTrue(this AspectF aspect, params Func<bool>[] conditions)
        {
            return aspect.Combine(work =>
            {
                if (conditions.Any(condition => !condition()))
                {
                    return;
                }

                work();
            });
        }

        [DebuggerStepThrough]
        public static AspectF While(this AspectF aspect, Func<bool> test)
        {
            return aspect.Combine(work =>
            {
                while (test())
                {
                    work();
                }
            });
        }

        [DebuggerStepThrough]
        public static AspectF WriteLock(this AspectF aspect, ReaderWriterLockSlim @lock)
        {
            return aspect.Combine(work =>
            {
                @lock.EnterWriteLock();
                try
                {
                    work();
                }
                finally
                {
                    @lock.ExitWriteLock();
                }
            });
        }

        private static void Cache<TReturnType>(AspectF aspect, ICache cacheResolver,
            string key, Action work, Func<TReturnType, TReturnType> foundInCache)
        {
            object cachedData = cacheResolver.Get(key);
            if (cachedData.IsNull())
            {
                GetListFromSource<TReturnType>(aspect, cacheResolver, key);
            }
            else
            {
                // Give caller a chance to shape the cached item before it is returned
                TReturnType cachedType = foundInCache((TReturnType)cachedData);
                if (cachedType.IsNull())
                {
                    GetListFromSource<TReturnType>(aspect, cacheResolver, key);
                }
                else
                {
                    aspect.m_WorkDelegate = new Func<TReturnType>(() => cachedType);
                }
            }

            work();
        }

        private static void DoNothing()
        {
        }

        private static void DoNothing(params object[] parameters)
        {
        }

        private static void GetListFromSource<TReturnType>(AspectF aspect, ICache cacheResolver, string key)
        {
            Func<TReturnType> workDelegate = (Func<TReturnType>)aspect.m_WorkDelegate;
            TReturnType realObject = workDelegate();
            cacheResolver.Add(key, realObject);
            workDelegate = () => realObject;
            aspect.m_WorkDelegate = workDelegate;
        }

        #endregion
    }

    public static class IAsyncResultExtensions
    {
        #region Class Methods

        /// <summary>
        /// 执行异步方法
        /// </summary>
        /// <param name="asyncResult">异步操作状态</param>
        /// <param name="endMethod">结束方法</param>
        /// <param name="timeout">超时时间</param>
        public static void FromAsync(this IAsyncResult asyncResult, Action<IAsyncResult, bool> endMethod, TimeSpan? timeout)
        {
            int timeoutValue = -1;
            if (timeout.HasValue)
            {
                timeoutValue = Convert.ToInt32(timeout.Value.TotalMilliseconds);
            }

            ThreadPool.RegisterWaitForSingleObject(asyncResult.AsyncWaitHandle,
                (s, isTimedout) => endMethod(asyncResult, isTimedout), null,
                timeoutValue, true);
        }

        #endregion
    }

    public static class StreamExtensions
    {
        #region Class Methods

        /// <summary>
        /// 	Copies any stream into a local MemoryStream
        /// </summary>
        /// <param name = "stream">The source stream.</param>
        /// <returns>The copied memory stream.</returns>
        public static MemoryStream CopyToMemory(this Stream stream)
        {
            MemoryStream memoryStream = new MemoryStream((int)stream.Length);
            stream.CopyToStream(memoryStream);
            return memoryStream;
        }

        public static void CopyToStream(this Stream source, Stream destination)
        {
#if !DOTNET4
            const int bufferSize = 1024 * 4;
            byte[] buffer = new byte[bufferSize];
            int bytesRead;
            while ((bytesRead = source.Read(buffer, 0, bufferSize)) > 0)
            {
                destination.Write(buffer, 0, bytesRead);
            }
#else
			source.CopyTo(destination);
#endif
        }

        public static void CopyToStreamAsync(this Stream source, Stream destination,
            Action<Stream, Stream, Exception> completed, Action<uint> progress,
            uint bufferSize, uint? maximumDownloadSize, TimeSpan? timeout)
        {
            byte[] buffer = new byte[bufferSize];

            Action<Exception> done = exception =>
            {
                if (completed != null)
                {
                    completed(source, destination, exception);
                }
            };

            int maxDownloadSize = maximumDownloadSize.HasValue
                ? (int)maximumDownloadSize.Value
                : int.MaxValue;
            int bytesDownloaded = 0;
            IAsyncResult asyncResult = source.BeginRead(buffer, 0, new[] { maxDownloadSize, buffer.Length }.Min(), null, null);
            Action<IAsyncResult, bool> endRead = null;
            endRead = (innerAsyncResult, innerIsTimedOut) =>
            {
                try
                {
                    int bytesRead = source.EndRead(innerAsyncResult);
                    if (innerIsTimedOut)
                    {
                        done(new TimeoutException());
                    }

                    int bytesToWrite = new[] { maxDownloadSize - bytesDownloaded, buffer.Length, bytesRead }.Min();
                    destination.Write(buffer, 0, bytesToWrite);
                    bytesDownloaded += bytesToWrite;

                    if (!progress.IsNull() && bytesToWrite > 0)
                    {
                        progress((uint)bytesDownloaded);
                    }

                    if (bytesToWrite == bytesRead && bytesToWrite > 0)
                    {
                        asyncResult = source.BeginRead(buffer, 0, new[] { maxDownloadSize, buffer.Length }.Min(), null, null);
                        // ReSharper disable PossibleNullReferenceException
                        // ReSharper disable AccessToModifiedClosure
                        asyncResult.FromAsync((ia, isTimeout) => endRead(ia, isTimeout), timeout);
                        // ReSharper restore AccessToModifiedClosure
                        // ReSharper restore PossibleNullReferenceException
                    }
                    else
                    {
                        done(null);
                    }
                }
                catch (Exception exc)
                {
                    done(exc);
                }
            };

            asyncResult.FromAsync((ia, isTimeout) => endRead(ia, isTimeout), timeout);
        }

        public static TResult FromBinary<TResult>(this Stream s) where TResult : class, new()
        {
            DataContractSerializer dc = new DataContractSerializer(typeof(TResult));
            return (TResult)dc.ReadObject(s);
        }

        /// <summary>
        /// 	Opens a StreamReader using the specified encoding.
        /// </summary>
        /// <param name = "stream">The stream.</param>
        /// <param name = "encoding">The encoding.</param>
        /// <returns>The stream reader</returns>
        public static StreamReader GetReader(this Stream stream, Encoding encoding)
        {
            if (!stream.CanRead)
            {
                throw new InvalidOperationException("Stream does not support reading.");
            }

            return encoding.IsNull()
                ? new StreamReader(stream, true)
                : new StreamReader(stream, encoding);
        }

        /// <summary>
        /// 	Reads all text from the stream using the default encoding.
        /// </summary>
        /// <param name = "stream">The stream.</param>
        /// <returns>The result string.</returns>
        public static string ReadToEnd(this Stream stream)
        {
            return stream.ReadToEnd(null);
        }

        /// <summary>
        /// 	Reads all text from the stream using a specified encoding.
        /// </summary>
        /// <param name = "stream">The stream.</param>
        /// <param name = "encoding">The encoding.</param>
        /// <returns>The result string.</returns>
        public static string ReadToEnd(this Stream stream, Encoding encoding)
        {
            using (StreamReader reader = stream.GetReader(encoding))
            {
                return reader.ReadToEnd();
            }
        }

        #endregion
    }

    public static class UriExtensions
    {
        #region Class Methods

        public static string GetUrlKeyString(this Uri uri, UriComponents uriSensitivity)
        {
            // Get complete url
            string completeUrl = uri.ToString().ToUpperInvariant();

            // Get sensitive part
            string sensitiveUrlPart = uri.GetComponents(uriSensitivity, UriFormat.Unescaped);

            if (sensitiveUrlPart.IsNullOrEmpty())
            {
                return completeUrl;
            }

            return completeUrl.Replace(sensitiveUrlPart.ToUpperInvariant(), sensitiveUrlPart);
        }

        /// <summary>
        /// Checks if url is the same as the base url
        /// </summary>
        /// <param name="uriBase">Base Uri</param>
        /// <param name="uri">url to check</param>
        /// <returns>Returns true if url is not same as base url, else false</returns>
        public static bool IsHostMatch(this Uri uriBase, Uri uri)
        {
            AspectF.Define.
                NotNull(uriBase, "uriBase");

            if (uri.IsNull())
            {
                return false;
            }

            return !uriBase.Host.Equals(uri.Host, StringComparison.OrdinalIgnoreCase);
        }

        #endregion
    }
}
