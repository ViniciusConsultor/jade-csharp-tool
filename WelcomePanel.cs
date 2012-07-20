using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Jade
{
    public partial class WelcomePanel : DevExpress.XtraEditors.XtraUserControl
    {
        public WelcomePanel()
        {
            InitializeComponent();
            this.webBrowser1.Navigate("http://www.iflytek.com");
        }
    }
}
