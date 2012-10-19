using System;
using System.ComponentModel;

namespace Jade.CQA.Robot.Interfaces
{
    /// <summary>
    /// task 执行器
    /// </summary>
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
}