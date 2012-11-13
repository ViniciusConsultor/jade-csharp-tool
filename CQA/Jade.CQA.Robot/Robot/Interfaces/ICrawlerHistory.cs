namespace Jade.CQA.Robot.Interfaces
{

    /// <summary>
    /// ץȡ��ʷ
    /// </summary>
    public interface ICrawlerHistory
    {
        #region Instance Properties

        long RegisteredCount { get; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// 	ע��Ψһ��ʶ
        /// </summary>
        /// <param name = "key">��Ҫע���Ψһ��ʶ</param>
        /// <returns>false if key has already been registered else true</returns>
        bool Register(string key);

        #endregion
    }
}