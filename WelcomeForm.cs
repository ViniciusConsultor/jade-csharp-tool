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
            //this.webBrowser1.Navigate("http://bbs.hefei.cc");
        }
    }
}
