using System;

namespace Jade.CQA.Robot.Interfaces
{

    /// <summary>
    /// URL采集规则
    /// </summary>
    public interface ICrawlerRules
    {
        #region Instance Methods

        /// <summary>
        /// 	Checks if the crawler should follow an url
        /// </summary>
        /// <param name = "uri">Url to check</param>
        /// <param name = "referrer"></param>
        /// <returns>True if the crawler should follow the url, else false</returns>
        bool IsAllowedUrl(Uri uri, CrawlStep referrer);

        bool IsExternalUrl(Uri uri);

        #endregion
    }
}