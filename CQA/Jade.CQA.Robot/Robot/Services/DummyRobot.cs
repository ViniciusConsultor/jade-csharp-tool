using System;

using Jade.CQA.Robot.Interfaces;

namespace Jade.CQA.Robot.Services
{
	public class DummyRobot : IRobot
	{
		#region IRobot Members

		public bool IsAllowed(string userAgent, Uri uri)
		{
			return true;
		}

		#endregion
	}
}