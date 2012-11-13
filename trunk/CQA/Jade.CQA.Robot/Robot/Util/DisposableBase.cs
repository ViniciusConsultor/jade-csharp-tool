using System;

namespace Jade.CQA.Robot.Utils
{
    /// <summary>
    /// IDisposable 对象基类 结束时自动释放分配的资源，需要实现Cleanup方法
    /// </summary>
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
}