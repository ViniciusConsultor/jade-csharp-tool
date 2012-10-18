using System;

namespace Jade.CQA
{
	public class PipelineExceptionEventArgs : EventArgs
	{
		#region Constructors

		public PipelineExceptionEventArgs(PropertyBag propertyBag, Exception exception)
		{
			PropertyBag = propertyBag;
			Exception = exception;
		}

		#endregion

		#region Instance Properties

		public Exception Exception { get; private set; }
		public PropertyBag PropertyBag { get; private set; }

		#endregion
	}
}