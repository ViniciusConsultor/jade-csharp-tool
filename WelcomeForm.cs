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

namespace Jade
{
    public partial class WelcomeForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {

        public WelcomeForm()
        {
            InitializeComponent();
            this.TabText = "欢迎页";
          
        }

        void webBrowser1_OnPost(string postData)
        {
            System.Diagnostics.Debug.WriteLine(postData);
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            SHDocVw.WebBrowser wb = (SHDocVw.WebBrowser)this.webBrowser1.ActiveXInstance;
            wb.BeforeNavigate2 += new SHDocVw.DWebBrowserEvents2_BeforeNavigate2EventHandler(wb_BeforeNavigate2);

            this.webBrowser1.Navigate("http://newscms.house365.com/newCMS/login.php");
        }

        void wb_BeforeNavigate2(object pDisp, ref object URL, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers, ref bool Cancel)
        {
            string postDataText = System.Text.Encoding.ASCII.GetString(PostData as byte[]);
            System.Diagnostics.Debug.WriteLine(postDataText);
        }
    }
}
