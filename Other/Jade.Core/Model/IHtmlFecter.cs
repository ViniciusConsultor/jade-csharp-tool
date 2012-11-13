using System;
namespace Jade.ConfigTool.Model
{
    /// <summary>
    /// html 抓取
    /// </summary>
    public interface IHtmlFecter
    {
        /// <summary>
        /// Cookie
        /// </summary>
        string Cookie { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        string Encoding { get; set; }

        /// <summary>
        /// 列表页编码
        /// </summary>
        string ListEncoding
        {
            get;
            set;
        }
        /// <summary>
        /// GET OR POST
        /// </summary>
        string HttpMethod { get; set; }

        /// <summary>
        /// post data
        /// </summary>
        string HttpPostData { get; set; }

        /// <summary>
        /// 引用页、来源页
        /// </summary>
        string Referer { get; set; }

        /// <summary>
        /// 客户端
        /// </summary>
        string UserAgent { get; set; }

        string FetchHtml(string url, string encoding);

        string FetchContentPageHtml(string url);

        string FetchListPageHtml(string url);

    }


    public class HtmlFecter : IHtmlFecter
    {
        #region IHtmlFecter 成员

        /// <summary>
        /// 列表页编码
        /// </summary>
        public string ListEncoding
        {
            get;
            set;
        }
        /// <summary>
        /// Cookie
        /// </summary>
        public string Cookie { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Encoding { get; set; }

        /// <summary>
        /// GET OR POST
        /// </summary>
        public string HttpMethod { get; set; }

        /// <summary>
        /// post data
        /// </summary>
        public string HttpPostData { get; set; }

        /// <summary>
        /// 引用页、来源页
        /// </summary>
        public string Referer { get; set; }

        /// <summary>
        /// 客户端
        /// </summary>
        public string UserAgent { get; set; }


        public string FetchHtml(string url, string encoding)
        {
            if (url != "")
            {
                return HtmlPicker.VisitUrl(new Uri(url), this.HttpMethod, null, string.IsNullOrEmpty(this.Referer) ? null : this.Referer, string.IsNullOrEmpty(this.Cookie) ? null : Utility.GetCookies(this.Cookie), string.IsNullOrEmpty(this.UserAgent) ? null : this.UserAgent, string.IsNullOrEmpty(this.HttpPostData) ? null : this.HttpPostData, System.Text.Encoding.GetEncoding(encoding));
            }
            return "";
        }

        public string FetchContentPageHtml(string url)
        {
            return FetchHtml(url, this.Encoding);
        }

        public string FetchListPageHtml(string url)
        {
            return FetchHtml(url, this.ListEncoding);
        }

        #endregion
    }
}
