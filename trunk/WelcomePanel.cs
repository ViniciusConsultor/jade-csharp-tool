using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010.Views;
using System.Reflection;
using Com.iFLYTEK.WinForms.Browser;

namespace Jade
{
    public partial class WelcomePanel : DevExpress.XtraEditors.XtraUserControl, IBaseBrowserForm
    {
        WebBrowser parentBrowser;
        public WelcomePanel(WebBrowser parent = null)
        {
            parentBrowser = parent;
            InitializeComponent();
            //this.webBrowser1.Parent 
            //this.webBrowser1.Navigate("http://www.iflytek.com");
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
            webBrowser1.StartNewWindow += new EventHandler<Com.iFLYTEK.WinForms.Browser.BrowserExtendedNavigatingEventArgs>(webBrowser1_StartNewWindow);
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.WebBrowserShortcutsEnabled = true;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = true;
            this.webBrowser1.Quit += new EventHandler(webBrowser1_Quit);

            SHDocVw.WebBrowser wb = (SHDocVw.WebBrowser)this.webBrowser1.ActiveXInstance;
            wb.BeforeNavigate2 += new SHDocVw.DWebBrowserEvents2_BeforeNavigate2EventHandler(wb_BeforeNavigate2);
        }

        // My most favorite method :)
        // Contains exactly that hack, we're talking about
        private void SetOpener(WebBrowser opener, WebBrowser popup)
        {
            HtmlWindow htmlPopup = popup.Document.Window;
            HtmlWindow htmlOpener = opener.Document.Window;

            // let the dark magic begin

            // actually, WebBrowser control is .NET wrapper around IE COM interfaces
            // we can get a bit closer to them access by getting reference to 
            // "mshtml.IHTMLWindow2" field via Reflection
            FieldInfo fi = htmlPopup.GetType().GetField("htmlWindow2", BindingFlags.Instance | BindingFlags.NonPublic);

            mshtml.IHTMLWindow2 htmlPopup2 = (mshtml.IHTMLWindow2)fi.GetValue(htmlPopup);
            mshtml.IHTMLWindow2 htmlOpener2 = (mshtml.IHTMLWindow2)fi.GetValue(htmlOpener);

            // opener is set here
            htmlPopup2.window.opener = htmlOpener2.window.self;
        }

        void webBrowser1_Quit(object sender, EventArgs e)
        {
            if (this.document != null)
            {
                CacheObject.MainForm.CloseDoc(this.document);
            }
        }

        void wb_BeforeNavigate2(object pDisp, ref object URL, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers, ref bool Cancel)
        {
            if (PostData != null)
            {
                string postDataText = System.Text.Encoding.ASCII.GetString(PostData as byte[]);

                if (postDataText != null)
                {
                    Console.WriteLine(postDataText);
                }
            }
        }

        void webBrowser1_StartNewWindow(object sender, Com.iFLYTEK.WinForms.Browser.BrowserExtendedNavigatingEventArgs e)
        {   
            e.Cancel = true;
            var href = e.Url.AbsoluteUri;
            CacheObject.MainForm.OpenNewUrl(href,this.webBrowser1);     
        }

        void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url == this.webBrowser1.Url)
            {
                this.document.Caption = this.webBrowser1.Document.Title;
                if (this.parentBrowser != null)
                {
                    this.SetOpener(this.parentBrowser, this.webBrowser1);
                }

                if (autoClose)
                {
                    CacheObject.MainForm.CloseDoc(this.document);
                }

                if (autoRedirect)
                {
                    CacheObject.MainForm.CloseDoc(this.document);
                    return;
                    autoRedirect = false;
                    this.webBrowser1.Navigate(redirecUrl);
                }
            }
        }

        [System.Runtime.InteropServices.DllImport("wininet.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);



        BaseDocument document;
        public void Navigate(string url, BaseDocument document,string cookies ="")
        {
            if (cookies == "")
            {
                cookies = CacheObject.Cookie;
            }
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
            this.browserToolStrip1.UrlCombo.Text = url;
        }

        bool autoClose = false;
        bool autoRedirect =  false;
        string redirecUrl = "";
        public void NavigateAndClose(string url, BaseDocument document, string cookies = "")
        {
            Navigate(url, document, cookies);
            autoClose = true;
        }

        public void GernateHtml(string url, BaseDocument document, string newsId)
        {
            Navigate(url, document, CacheObject.Cookie);
            autoRedirect = true;
            //URL = "http://newscms.house365.com/newCMS/pub/hfestate/system/2012/09/11/020743567.html"
            redirecUrl = string.Format("http://newscms.house365.com/newCMS/pub/hfccbbs/system/{0}/{1}.shtml?t=1", DateTime.Now.ToString("yyyy/MMdd"), newsId);
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


        /// <summary>
        /// 后退
        /// </summary>
        public void GoBack()
        {
            this.webBrowser1.GoBack();
        }

        /// <summary>
        /// 向前
        /// </summary>
        public void GoForward()
        {
            this.webBrowser1.GoForward();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        public void RefreshBrowser()
        {
            this.webBrowser1.Refresh();
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            this.webBrowser1.Stop();
        }

        /// <summary>
        /// 导航至当前的地址栏的地址
        /// </summary>
        public void GoNavigate()
        {
            string tempUrl = "";
            if (this.browserToolStrip1.UrlCombo.Text.IndexOf("://") == -1)
            {
                tempUrl = "http://" + this.browserToolStrip1.UrlCombo.Text;
            }
            else
            {
                tempUrl = this.browserToolStrip1.UrlCombo.Text;
            }
        }
    }
}
