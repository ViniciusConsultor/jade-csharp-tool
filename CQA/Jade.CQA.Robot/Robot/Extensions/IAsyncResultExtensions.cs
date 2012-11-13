using System;
using System.Threading;

namespace Jade.CQA.Robot.Extensions
{
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

            // 放入线程池子执行
            ThreadPool.RegisterWaitForSingleObject(asyncResult.AsyncWaitHandle,
                (s, isTimedout) => endMethod(asyncResult, isTimedout), null,
                timeoutValue, true);
        }

        #endregion
    }

}