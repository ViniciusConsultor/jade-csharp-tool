using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HFBBS
{
    public interface IRemoteWebService
    {
        /// <summary>
        /// 获取特殊标记
        /// </summary>
        /// <returns></returns>
        List<DisplayNameValuePair> GetSpecilTags();

        /// <summary>
        /// 获取稿源
        /// </summary>
        /// <returns></returns>
        List<DisplayNameValuePair> GetSource();

        /// <summary>
        /// 获取模板
        /// </summary>
        /// <returns></returns>
        List<DisplayNameValuePair> GetTemplate();
    }

    public class DisplayNameValuePair
    {
        public string DisplayName { get; set; }

        public string Value { get; set; }
    }

    public interface INews
    {
        string news_id { get; set; }

        string news_type_id { get; set; }

        string news_source_name { get; set; }

        string news_template_file { get; set; }

        string news_title { get; set; }

        string news_sub_title { get; set; }

        string news_content { get; set; }

        /// <summary>
        /// 附加正文
        /// </summary>
        string news_top { get; set; }

        /// <summary>
        /// 导读图片
        /// </summary>
        string news_guideimage { get; set; }
        string news_guideimage2 { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        string row_news_abstract { get; set; }

        /// <summary>
        /// SEO描述 (150字)
        /// </summary>
        string news_description { get; set; }

        /// <summary>
        /// 相关新闻
        /// </summary>
        string news_link { get; set; }

        /// <summary>
        /// 附加正文3
        /// </summary>
        string news_down { get; set; }

        /// <summary>
        /// 附加正文5
        /// </summary>
        string news_right { get; set; }

        /// <summary>
        /// 附加正文4
        /// </summary>
        string news_left { get; set; }

        /// <summary>
        /// 评论地址
        /// </summary>
        string comment_url { get; set; }

        /// <summary>
        /// 音频视频
        /// </summary>
        string news_video { get; set; }

        string news_keywords { get; set; }

        /// <summary>
        /// seo keywords
        /// </summary>
        string news_keywords2 { get; set; }
        /// <summary>
        /// label
        /// </summary>
        string label_base { get; set; }

        /// <summary>
        /// 
        /// </summary>
        bool cmspinglun { get; set; }

        bool bbspinglun { get; set; }

        /// <summary>
        /// 是否是看房报名
        /// </summary>
        bool ISkfbm { get; set; }
        string kfbm_id { get; set; }
        string kfbm_link { get; set; }
        /// <summary>
        /// 是否是购房报名
        /// </summary>
        bool ISgfbm { get; set; }
        string gfbm_id { get; set; }
        string gfbm_link { get; set; }
        /// <summary>
        /// 跳转地址
        /// </summary>
        string news_abs { get; set; }
    }

    public class RemoteWebService : IRemoteWebService
    {
        static RemoteWebService instance;

        /// <summary>
        /// 唯一实例
        /// </summary>
        public static RemoteWebService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RemoteWebService();
                }
                return instance;
            }
        }

        #region IRemoteWebService 成员

        public List<DisplayNameValuePair> GetSpecilTags()
        {
            return new List<DisplayNameValuePair> { 
               new DisplayNameValuePair(){ DisplayName="标签1",Value = "标签1"},
               new DisplayNameValuePair(){DisplayName="标签2",Value = "标签2"},  
               new DisplayNameValuePair(){DisplayName="标签3",Value = "标签3"}
            };
        }

        public List<DisplayNameValuePair> GetSource()
        {
            return new List<DisplayNameValuePair> { 
               new DisplayNameValuePair(){ DisplayName="来源1",Value = "来源1"},
               new DisplayNameValuePair(){DisplayName="来源2",Value = "来源2"},  
               new DisplayNameValuePair(){DisplayName="来源3",Value = "来源3"}
            };
        }

        public List<DisplayNameValuePair> GetTemplate()
        {
            return new List<DisplayNameValuePair> { 
               new DisplayNameValuePair(){DisplayName="模板1",Value = "模板1"},
               new DisplayNameValuePair(){DisplayName="模板2",Value = "模板2"},  
               new DisplayNameValuePair(){DisplayName="模板3",Value = "模板3"}
            };
        }

        #endregion
    }
}
