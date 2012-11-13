using System;
using System.ComponentModel;
using System.Threading;

using Jade.CQA.Robot.Interfaces;

namespace Jade.CQA.Robot.Services
{
	public class ThreadTaskRunnerService : ITaskRunner
	{
		#region ITaskRunner Members

		public bool RunSync(Action<CancelEventArgs> action, TimeSpan maxRuntime)
		{
			if (maxRuntime.TotalMilliseconds <= 0)
			{
				throw new ArgumentOutOfRangeException("maxRuntime");
			}

			CancelEventArgs args = new CancelEventArgs(false);
			IAsyncResult functionResult = action.BeginInvoke(args, null, null);
			WaitHandle waitHandle = functionResult.AsyncWaitHandle;

            // 执行超时
			if (!waitHandle.WaitOne(maxRuntime))
			{
				args.Cancel = true; // flag to worker that it should cancel!
				ThreadPool.UnsafeRegisterWaitForSingleObject(waitHandle,
					(state, timedOut) => action.EndInvoke(functionResult),
					null, -1, true);
				return false;
			}

			action.EndInvoke(functionResult);
			return true;
		}

		#endregion
	}
}