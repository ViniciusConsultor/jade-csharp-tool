using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Jade.Model;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Jade
{
    public partial class WelcomeForm : Form
    {

        public WelcomeForm()
        {
            InitializeComponent();
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
        }

        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Console.WriteLine(this.webBrowser1.Document.Cookie);
        }

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);

        void webBrowser1_OnPost(string postData)
        {
            System.Diagnostics.Debug.WriteLine(postData);
        }

        private Dictionary<string, string> GetKeyValueDictionFromCookie(string cookie)
        {
            //var regex = new Regex(@"expires=\w+, \d+-\w+-\d+ \d+:\d+:\d+ GMT,*");
            //cookie = regex.Replace(cookie, "");
            var results = cookie.Split(';');
            var ResponseDictionary = new Dictionary<string, string>();
            foreach (var result in results)
            {
                var keyvaluepair = result.Split(new string[] { "=" }, 2, StringSplitOptions.RemoveEmptyEntries);
                if (keyvaluepair.Length == 2)
                {
                    ResponseDictionary.Add(keyvaluepair[0].Trim(), keyvaluepair[1].Trim());
                }
            }
            return ResponseDictionary;
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            SHDocVw.WebBrowser wb = (SHDocVw.WebBrowser)this.webBrowser1.ActiveXInstance;
            wb.BeforeNavigate2 += new SHDocVw.DWebBrowserEvents2_BeforeNavigate2EventHandler(wb_BeforeNavigate2);
        }

        public void LoadtoPage()
        {
            //var request = CacheObject.WebRequset;
            //request.Url = "http://newscms.house365.com/newCMS/news/editlist.php?channel_id=8000000";
            //request.Cookie = CacheObject.Cookie;
            //var text = request.Get();
            //text = text.Replace("../../newCMS/common.css", "http://newscms.house365.com/newCMS/common.css");
            //this.webBrowser1.DocumentText = text;

            //return;

            var url = "http://newscms.house365.com/newCMS/index.php";
            var cookie = GetKeyValueDictionFromCookie(CacheObject.Cookie);
            foreach (var pair in cookie)
            {
                //InternetSetCookie("house365.com", pair.Key, pair.Value);
                InternetSetCookie("http://newscms.house365.com", pair.Key, pair.Value);
            }
            InternetSetCookie(url, null, CacheObject.Cookie);

            this.webBrowser1.Navigate(url);
        }

        void wb_BeforeNavigate2(object pDisp, ref object URL, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers, ref bool Cancel)
        {
            string postDataText = System.Text.Encoding.ASCII.GetString(PostData as byte[]);

            if (postDataText != null)
            {
                Console.WriteLine(postDataText);
            }
        }
    }
}
