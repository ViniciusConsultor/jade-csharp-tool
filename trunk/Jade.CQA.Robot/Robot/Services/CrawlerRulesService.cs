using System;
using System.Linq;

using Jade.CQA.Robot.Extensions;
using Jade.CQA.Robot.Interfaces;
using Jade.CQA.Robot.Utils;

namespace Jade.CQA.Robot.Services
{
    /// <summary>
    /// Handles logic of how to follow links when crawling
    /// </summary>
    public class CrawlerRulesService : ICrawlerRules
    {
        #region Readonly & Static Fields

        protected readonly Uri m_BaseUri;
        protected readonly Crawler m_Crawler;
        protected readonly IRobot m_Robot;

        #endregion

        #region Constructors

        public CrawlerRulesService(Crawler crawler, IRobot robot, Uri baseUri)
        {
            AspectF.Define.
                NotNull(crawler, "crawler").
                NotNull(robot, "robot").
                NotNull(baseUri, "baseUri");

            m_Crawler = crawler;
            m_Robot = robot;
            m_BaseUri = baseUri;
        }

        #endregion

        #region ICrawlerRules Members

        /// <summary>
        /// 检查URL是否需要抓取	
        /// Checks if the crawler should follow an url
        /// </summary>
        /// <param name = "uri">Url to check</param>
        /// <param name = "referrer"></param>
        /// <returns>True if the crawler should follow the url, else false</returns>
        public virtual bool IsAllowedUrl(Uri uri, CrawlStep referrer)
        {
            // 来源为空，允许抓取
            if (referrer == null)
            {
                return true;
            }

            if (m_Crawler.MaximumUrlSize.HasValue && m_Crawler.MaximumUrlSize.Value > 10 &&
                uri.ToString().Length > m_Crawler.MaximumUrlSize.Value)
            {
                return false;
            }

            if (IsExternalUrl(uri))
            {
                return false;
            }

            if (!m_Crawler.ExcludeFilter.IsNull() && m_Crawler.ExcludeFilter.Any(f => f.Match(uri, referrer)))
            {
                return false;
            }

            if (!m_Crawler.IncludeFilter.IsNull() && m_Crawler.IncludeFilter.Any(f => f.Match(uri, referrer)))
            {
                return true;
            }

            //todo
            return false;


            return !m_Crawler.AdhereToRobotRules || m_Robot.IsAllowed(m_Crawler.UserAgent, uri);
        }

        public virtual bool IsExternalUrl(Uri uri)
        {
            return m_BaseUri.IsHostMatch(uri);
        }

        #endregion
    }
}