using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Jade.Model
{
    /// <summary>
    /// 任务规则
    /// </summary>
    public class SiteRule : XmlDatabase.Core.IXmlStoreItem
    {
        /// <summary>
        /// 创建默认规则
        /// </summary>
        /// <returns></returns>
        public static SiteRule CreateDefaultRule()
        {
            var rule = new SiteRule();

            rule.ItemRules.AddRange(new List<ItemRule>() { 
                new ItemRule() {
                CloumnName = "Title",
                ItemName="标题",
                FetchType = ItemFetchType.XPath,
                IsDownloadPic = false,
                XMLPathType = XMLPathType.InnerText,
                XPath="//h1",
                AnotherXPath="//title",
                XMLPathSelectType = XMLPathSelectType.OnlyOne      
                },  new ItemRule() {
                CloumnName = "SubTitle",
                ItemName="副标题",
                FetchType = ItemFetchType.XPath,
                IsDownloadPic = false,
                XPath="",
                },  new ItemRule() {
                CloumnName = "Keywords",
                ItemName="关键字",
                FetchType = ItemFetchType.XPath,
                IsDownloadPic = false,
                XPath="",  
                }, 
              new ItemRule() {
                CloumnName = "Source",
                ItemName="来源",
                FetchType = ItemFetchType.XPath,
                IsDownloadPic = false,
                XMLPathType = XMLPathType.InnerText,
                XPath="",
                XMLPathSelectType = XMLPathSelectType.OnlyOne      
                }, new ItemRule() {
                CloumnName = "Time",
                ItemName="时间",
                FetchType = ItemFetchType.UserDiy,
                IsDownloadPic = false,
               DiyType= UserDiyType.Datetime,
               DateTimeFormatString="yyyy-MM-dd hh:mm"
                }, new ItemRule() {
                CloumnName = "Content",
                ItemName="内容",
                FetchType = ItemFetchType.XPath,
                IsDownloadPic = true,
                XMLPathType = XMLPathType.InnerTextWithPic,
                XPath="//body",
                XMLPathSelectType = XMLPathSelectType.OnlyOne      
                }, new ItemRule() {
                CloumnName = "Summary",
                ItemName="摘要",
                FetchType = ItemFetchType.XPath,
                IsDownloadPic = false,
                XMLPathType = XMLPathType.InnerText,
                XPath="//h1",
                XMLPathSelectType = XMLPathSelectType.OnlyOne      
                }, new ItemRule() {
                CloumnName = "Other",
                ItemName="其他",
                FetchType = ItemFetchType.XPath,
                IsDownloadPic = false,
                XMLPathType = XMLPathType.InnerText,
                XPath="",
                XMLPathSelectType = XMLPathSelectType.OnlyOne      
                }
            });
            return rule;
        }

        /// <summary>
        /// 分类ID
        /// </summary>
        public int CategoryID { get; set; }

        public SiteRule()
        {
            this.CategoryID = 0;
            this.Cookie = "";
            this.Encoding = "gb2312";
            this.ExcludePart = "";
            this.ForTestUrl = "";
            this.HttpMethod = "GET";
            this.HttpPostData = "";
            this.IncludePart = "";
            this.ItemRules = new List<ItemRule>();
            this.ListEncoding = "gb2312";
            this.PageEndAt = "";
            this.PageStartAt = "";
            this.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; 4399Box.1272; 4399Box.1272)";
            this.TableName = "NewsTab";
            this.Depth = 1;
            this.ListExcludePart = "";
            this.ListIncludePart = "";
            this.ListPageEndAt = "";
            this.ListPageStartAt = "";
            this.ListPageType = Model.ListPageType.Html;
            this.ListXPath = "";
            this.ListXMLPathSelectType = XMLPathSelectType.Multiple;
            this.ListXMLPathType = XMLPathType.Href;
            this.EnableAutoRun = false;
            this.AutoRunInterval = 60;
            this.IconImage = "favicon.ico";
        }


        public string IconImage
        {
            get;
            set;
        }

        /// <summary>
        /// 编码ID
        /// </summary>
        public int SiteRuleId
        {
            get;
            set;
        }

        /// <summary>
        /// 站点名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 列表页类型
        /// </summary>
        public ListPageType ListPageType
        {
            get;
            set;
        }

        /// <summary>
        /// 起始地址
        /// </summary>
        public string StartUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 自定义内容页地址
        /// </summary>
        public string DiyContentPageUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 网页编码
        /// </summary>
        public string Encoding
        {
            get;
            set;
        }

        /// <summary>
        /// GET OR POST
        /// </summary>
        public string HttpMethod
        {
            get;
            set;
        }

        /// <summary>
        /// POST 数据
        /// </summary>
        public string HttpPostData
        {
            get;
            set;
        }

        /// <summary>
        /// Cookie数据
        /// </summary>
        public string Cookie
        {
            get;
            set;
        }


        /// <summary>
        /// 深度(1 所给的页面为列表页  2所给的页面为主业，采集到得页面时列表页）
        /// </summary>
        public int Depth
        {
            get;
            set;
        }

        /// <summary>
        /// 列表页必须包含
        /// </summary>
        public string ListIncludePart
        {
            get;
            set;
        }

        /// <summary>
        /// 列表页不得包含
        /// </summary>
        public string ListExcludePart
        {
            get;
            set;
        }


        public string IncludePart
        {
            get;
            set;
        }


        public string ExcludePart
        {
            get;
            set;
        }
        public string ListPageStartAt
        {
            get;
            set;
        }


        public string ListPageEndAt
        {
            get;
            set;
        }

        /// <summary>
        /// Link开始
        /// </summary>
        public string PageStartAt
        {
            get;
            set;
        }

        /// <summary>
        /// link结束
        /// </summary>
        public string PageEndAt
        {
            get;
            set;
        }


        public string UserAgent
        {
            get;
            set;
        }


        public string Referer
        {
            get;
            set;
        }

        /// <summary>
        /// 测试页URL
        /// </summary>
        public string ForTestUrl
        {
            get;
            set;
        }


        /// <summary>
        /// 列表页编码
        /// </summary>
        public string ListEncoding
        {
            get;
            set;
        }

        /// <summary>
        /// 规则
        /// </summary>
        public List<ItemRule> ItemRules
        {
            get;
            set;
        }


        public string HostUrl { get; set; }


        public string UrlTrim { get; set; }


        public List<string> Urlreplace { get; set; }

        /// <summary>
        /// 存储的数据表
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 列表页抓取类型
        /// </summary>
        public ItemFetchType ListFetchType { get; set; }

        /// <summary>
        /// 列表页XPath
        /// </summary>
        public string ListXPath { get; set; }

        /// <summary>
        /// 列表页XMLPathType
        /// </summary>
        public XMLPathType ListXMLPathType { get; set; }


        /// <summary>
        /// 列表页选择类型
        /// </summary>
        public XMLPathSelectType ListXMLPathSelectType { get; set; }


        /// <summary>
        /// 是否自动运行
        /// </summary>
        public bool EnableAutoRun
        {
            get;
            set;
        }

        /// <summary>
        /// 自动运行时间间隔
        /// </summary>
        public int AutoRunInterval
        {
            get;
            set;
        }

        #region IXmlStoreItem 成员

        public object GetPrimaryKey()
        {
            return this.SiteRuleId;
        }

        #endregion
    }

    /// <summary>
    /// XPATH取值类型【InnerText，InnerLinks】
    /// </summary>
    public enum XMLPathType
    {
        InnerText,
        InnerTextWithPic,
        InnerLinks,
        InnerHtml,
        Href
    }

    /// <summary>
    /// XPATH选择类型  单选还是多选
    /// </summary>
    public enum XMLPathSelectType
    {
        OnlyOne,
        Multiple
    }

    /// <summary>
    /// 条目规则
    /// </summary>
    public class ItemRule
    {

        /// <summary>
        /// 多相匹配
        /// </summary>
        public bool MulityMatch { get; set; }

        /// <summary>
        /// 替换XPath
        /// </summary>
        public string AnotherXPath { get; set; }

        /// <summary>
        /// 采集方式
        /// </summary>
        public ItemFetchType FetchType { get; set; }

        /// <summary>
        /// XPATH
        /// </summary>
        public string XPath { get; set; }

        /// <summary>
        /// XPATH类型
        /// </summary>
        public XMLPathType XMLPathType { get; set; }

        /// <summary>
        /// XPATH选择类型
        /// </summary>
        public XMLPathSelectType XMLPathSelectType { get; set; }

        /// <summary>
        /// 条目名称
        /// </summary>
        public string ItemName
        {
            get;
            set;
        }

        /// <summary>
        /// 存储名称
        /// </summary>
        public string CloumnName
        {
            get;
            set;
        }
        public string StartTarget
        {
            get;
            set;
        }

        public string EndTarget
        {
            get;
            set;
        }

        /// <summary>
        /// 正则
        /// </summary>
        public string RegexText
        {
            get;
            set;
        }



        /// <summary>
        /// 是否过滤文本
        /// </summary>
        public bool IsExtractText
        {
            get;
            set;
        }

        /// <summary>
        /// 是否下载图片
        /// </summary>
        public bool IsDownloadPic { get; set; }

        /// <summary>
        /// 是否识别分页
        /// </summary> 
        public bool IdentifyPage
        {
            get;
            set;
        }

        /// <summary>
        /// 分页开始标记
        /// </summary>
        public string PageStart
        {
            get;
            set;
        }

        /// <summary>
        /// 分页结束标记
        /// </summary>
        public string PageEnd
        {
            get;
            set;
        }

        public string PageXPath { get; set; }

        /// <summary>
        /// 替换字符串
        /// </summary>
        public string ReplaceString
        {
            get;
            set;
        }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public UserDiyType DiyType { get; set; }


        /// <summary>
        /// 时间格式字符串
        /// </summary>
        public string DateTimeFormatString { get; set; }

    }

    public enum ItemFetchType
    {
        XPath = 0,
        FromHTML = 1,
        FromRegex = 2,
        UserDiy = 3
    }

    public enum UserDiyType
    {
        DefaultValue = 0,
        Datetime = 1
    }

    public enum ListPageType
    {
        Html = 0,
        RSS = 1
    }
}
