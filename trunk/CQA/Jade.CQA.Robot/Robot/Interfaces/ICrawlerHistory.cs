namespace Jade.CQA.Robot.Interfaces
{

    /// <summary>
    /// 抓取历史
    /// </summary>
    public interface ICrawlerHistory
    {
        #region Instance Properties

        long RegisteredCount { get; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// 	注册唯一标识
        /// </summary>
        /// <param name = "key">需要注册的唯一标识</param>
        /// <returns>false if key has already been registered else true</returns>
        bool Register(string key);

        #endregion
    }
}