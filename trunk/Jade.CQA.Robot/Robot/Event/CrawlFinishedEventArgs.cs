using System.ComponentModel;

namespace Jade.CQA.Robot.Event
{
	public class CrawlFinishedEventArgs : CancelEventArgs
	{
		#region Constructors

		internal CrawlFinishedEventArgs(Crawler crawler)
		{
			Crawler = crawler;
		}

		#endregion

		#region Instance Properties

		public Crawler Crawler { get; private set; }

		#endregion
	}
}