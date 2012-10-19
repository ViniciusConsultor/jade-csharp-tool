using System;

namespace Jade.CQA.Robot.Interfaces
{
	public interface IPipelineStepWithTimeout : IPipelineStep
	{
		TimeSpan ProcessorTimeout { get; }
	}
}