using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010.Views;

namespace Jade
{
    public partial class WelcomePanel : DevExpress.XtraEditors.XtraUserControl
    {
        public WelcomePanel()
        {
            InitializeComponent();
            //this.webBrowser1.Navigate("http://www.iflytek.com");
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
            webBrowser1.StartNewWindow += new EventHandler<Com.iFLYTEK.WinForms.Browser.BrowserExtendedNavigatingEventArgs>(webBrowser1_StartNewWindow);
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
        }

        void webBrowser1_StartNewWindow(object sender, Com.iFLYTEK.WinForms.Browser.BrowserExtendedNavigatingEventArgs e)
        {   
            e.Cancel = true;
            var href = e.Url.AbsoluteUri;
            CacheObject.MainForm.OpenNewUrl(href);     
        }

        void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            var href = webBrowser1.StatusText;
            CacheObject.MainForm.OpenNewUrl(href); ;
        }

        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url == this.webBrowser1.Url)
            {
                this.document.Caption = this.webBrowser1.Document.Title;
            }
        }

        [System.Runtime.InteropServices.DllImport("wininet.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);

        BaseDocument document;
        public void Navigate(string url, BaseDocument document,string cookies ="")
        {
            if (cookies != "")
            {
                var cookie = GetKeyValueDictionFromCookie(cookies);
                foreach (var pair in cookie)
                {
                    //InternetSetCookie("house365.com", pair.Key, pair.Value);
                    InternetSetCookie("http://newscms.house365.com", pair.Key, pair.Value);
                }
            }

            this.webBrowser1.Navigate(url);
            this.document = document;
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

        public void LoadtoPage()
        {
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
    }
}
