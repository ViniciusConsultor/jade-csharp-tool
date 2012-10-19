using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Net;
using System.IO;

using Jade.CQA.Robot.Event;
using System.Data;
using Autofac.Core;
using Autofac;
using Jade.CQA.Robot;
using Jade.CQA.Robot.Interfaces;

namespace Jade.CQA.Robot
{

    /// <summary>
    /// 爬虫爬行过程中的URL包装
    /// </summary>
    public class UrlWrapper
    {
        public string Title { get; set; }

        public string ReferUrl
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }

        public int Depth
        {
            get;
            set;
        }

        public bool IsContentPage
        {
            get;
            set;
        }

        public UrlWrapper(string url)
        {
            this.Url = url;
            this.Depth = 1;
            this.ReferUrl = "";
            this.IsContentPage = true;
            this.Title = "";
        }

        public UrlWrapper(UrlWrapper wrapper, string url)
        {
            this.Url = url;
            this.Depth = wrapper.Depth + 1;
            this.ReferUrl = wrapper.Url;
            this.IsContentPage = true;
            this.Title = "";
        }
    }

    /// <summary>
    /// 程序配置
    /// </summary>
    public class Setting
    {
        /// <summary>
        /// 最大深度
        /// </summary>
        public const int MAX_DEPTH = 6;

    }

    /// <summary>
    /// 管道
    /// </summary>
    public class PipeLine
    {
        /// <summary>
        /// 是否终止
        /// </summary>
        public bool Stop { get; set; }

        /// <summary>
        /// 当前Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 当前Url的网页
        /// </summary>
        public string Html { get; set; }

        /// <summary>
        /// 包含的url
        /// </summary>
        public List<UrlWrapper> Urls { get; set; }

        /// <summary>
        /// 执行
        /// </summary>
        public virtual void Execute()
        {
        }
    }

}
