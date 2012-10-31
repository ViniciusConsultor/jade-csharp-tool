using System;
using System.Threading;

namespace Jade.CQA.Robot.Extensions
{
    public static class IAsyncResultExtensions
    {
        #region Class Methods

        /// <summary>
        /// ִ���첽����
        /// </summary>
        /// <param name="asyncResult">�첽����״̬</param>
        /// <param name="endMethod">��������</param>
        /// <param name="timeout">��ʱʱ��</param>
        public static void FromAsync(this IAsyncResult asyncResult, Action<IAsyncResult, bool> endMethod, TimeSpan? timeout)
        {
            int timeoutValue = -1;
            if (timeout.HasValue)
            {
                timeoutValue = Convert.ToInt32(timeout.Value.TotalMilliseconds);
            }

            // �����̳߳���ִ��
            ThreadPool.RegisterWaitForSingleObject(asyncResult.AsyncWaitHandle,
                (s, isTimedout) => endMethod(asyncResult, isTimedout), null,
                timeoutValue, true);
        }

        #endregion
    }

}