using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.IO;

namespace Com.iFLYTEK.WinForms.Browser
{
    public delegate Icon AsyncLoadIconDelegate(string Host);
    public delegate void IconLoadedCompletedDelegate(Icon icon);
    public delegate void Post(string postData);
    public partial class BaseWebBrowser : ExtendedWebBrowser
    {
        const string favIconName = "/favicon.ico";
        /// <summary>
        /// 当图标装载成功后调用
        /// </summary>
        public event IconLoadedCompletedDelegate IconLoadCompleted;

        public BaseWebBrowser()
        {
            InitializeComponent();
        }

        void wb_BeforeNavigate2(object pDisp, ref object URL, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers, ref bool Cancel)
        { 
   
        }

        SHDocVw.IWebBrowser2 Iwb2;

        protected override void AttachInterfaces(object nativeActiveXObject)
        {
            Iwb2 = (SHDocVw.IWebBrowser2)nativeActiveXObject;
            Iwb2.Silent = true;
            base.AttachInterfaces(nativeActiveXObject);

        }

        protected override void DetachInterfaces()
        {
            Iwb2 = null;
            base.DetachInterfaces();
        }

        public BaseWebBrowser(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        ////如果操作系统安装是windows xp sp2，则可以拦截到地址
        //protected override void OnStartNewWindow(BrowserExtendedNavigatingEventArgs e)
        //{
        //    base.OnStartNewWindow(e);
        //    //检测看是否需要内部的浏览器
        //    bool useInternal = Properties.Settings.Default.UseInternalWebBrowser;
        //    bool hasUrl = e.Url != null;
        //    if (useInternal && hasUrl)
        //    {
        //        e.Cancel = true;
        //        BrowserManager.OpenWebsiteInNewTab(e.Url);
        //    }
        //}

        //protected override void OnNavigating(System.Windows.Forms.WebBrowserNavigatingEventArgs e)
        //{
        //    base.OnNavigating(e);
        //    //没有人订阅图标，不劳神子了
        //    if (this.IconLoadCompleted == null)
        //    { return; }
        //    //begin to load the favicon icon of current website
        //    string host = e.Url.Host;
        //    //if the host is not the primary, forget it.
        //    if (this.Url != null && this.Url.Host != null && this.Url.Host.Equals(host))
        //    {
        //        //to verify if icon exists
        //        AsyncLoadIconDelegate loadIcon = new AsyncLoadIconDelegate(this.LoadIcon);
        //        loadIcon.BeginInvoke(host, new AsyncCallback(OnIconLoad), loadIcon);
        //    }
        //}

        private Icon LoadIcon(string Host)
        {

            Uri uri;
            //to check input uri
            if (!Uri.TryCreate("http://" + Host + favIconName, UriKind.Absolute, out uri))
            { return null; }
            //to verify if icon exists
            try
            {
                WebClient client = new WebClient();
                byte[] result = client.DownloadData(uri);
                MemoryStream stream = new MemoryStream(result, 0, result.Length);
                Icon icon = new Icon(stream);
                return icon;
            }
            catch (WebException)
            {
                return null;
            }
        }

        /// <summary>
        /// 图标读取操作异步调用结束
        /// </summary>
        /// <param name="ar"></param>
        private void OnIconLoad(IAsyncResult ar)
        {
            //AsyncLoadIconDelegate loadIcon = ar.AsyncState as AsyncLoadIconDelegate;
            //if (loadIcon == null)
            //{ return; }
            //try
            //{
            //    //获得异步调用结果
            //    Icon icon = loadIcon.EndInvoke(ar);
            //    if (icon == null)
            //    {
            //        icon = Jade.Properties.Resources.LogoIcon;
            //    }
            //    if (this.IconLoadCompleted != null)
            //    { this.IconLoadCompleted(icon); }
            //}
            //catch
            //{ }
        }
    }
}
