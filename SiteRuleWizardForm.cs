using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Jade
{
    public partial class SiteRuleWizardForm : DevExpress.XtraEditors.XtraForm
    {
        public SiteRuleWizardForm()
        {
            InitializeComponent();
        }

        private void txtStartUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtStartUrl.Text != "")
                {
                    if (!this.txtStartUrl.Text.Contains("http://"))
                    {
                        this.txtStartUrl.Text = "http://" + this.txtStartUrl.Text;
                    }
                    //var temp = this.enableNavigate;
                    //this.enableNavigate = true;
                    this.startUrlWebBrowser.Navigate(this.txtStartUrl.Text);

                    //this.enableNavigate = temp;
                    e.Handled = true;
                }

            }
        }
    }
}