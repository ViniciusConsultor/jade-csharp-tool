using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jade.Model;
using System.Threading;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Reflection;
using Jade.BLL;

namespace Jade
{
    public class CacheObject
    {
        public static int MaxRequestCount = 10;
        public static int CurrentRequestCount = 0;
        static CacheObject()
        {
            RuleManager = new RuleManager();
            Rules = RuleManager.GetSiteRules();
            Categories = RuleManager.GetCategories();
        }
        public static RuleManager RuleManager { get; set; }
        static MyWebRequest webRequset;
        public static MyWebRequest WebRequset
        {
            get
            {
                if (webRequset == null)
                {
                    webRequset = new MyWebRequest();
                }
                return webRequset;
            }
        }

        public static string Cookie = "";
        public static bool IsDebug = false;
        public static bool IsTest = true;



        /// <summary>
        /// 是否已登录
        /// </summary>
        public static bool IsLognIn
        {
            get;
            set;
        }

        /// <summary>
        /// 任务目录
        /// </summary>
        public static string GetTaskDir(string taskId)
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory + "\\Task";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                Directory.CreateDirectory(dir + "\\" + taskId);
            }
            dir = "\\" + taskId;
            return dir;

        }


        public static string IconDir
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "\\Pic";
            }
        }



        public static List<SiteRule> Rules
        {
            get;
            set;
        }

        public static List<Category> Categories
        {
            get;
            set;
        }


        public static string channelid { get; set; }
    }
}
