using System;

namespace Jade.CQA.Robot.Interfaces
{
    /// <summary>
    /// 过滤器
    /// </summary>
    public interface IFilter
    {
        #region Instance Methods

        bool Match(Uri uri, CrawlStep referrer);

        #endregion
    }
}