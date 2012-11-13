namespace Jade.CQA.Robot.Interfaces
{
    /// <summary>
    /// 日志接口
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Info
        /// </summary>
        /// <param name="format"></param>
        /// <param name="parameters"></param>
        void Verbose(string format, params object[] parameters);

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="format"></param>
        /// <param name="parameters"></param>
        void Warning(string format, params object[] parameters);

        /// <summary>
        /// debug
        /// </summary>
        /// <param name="format"></param>
        /// <param name="parameters"></param>
        void Debug(string format, params object[] parameters);

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="format"></param>
        /// <param name="parameters"></param>
        void Error(string format, params object[] parameters);

        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="format"></param>
        /// <param name="parameters"></param>
        void FatalError(string format, params object[] parameters);
    }
}