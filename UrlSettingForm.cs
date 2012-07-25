using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Jade.Model;

namespace Jade
{
    public partial class UrlSettingForm : DevExpress.XtraEditors.XtraForm
    {
        SiteRule currentRule;

        public UrlSettingForm(SiteRule rule)
        {
            this.currentRule = rule;
            InitializeComponent();
            this.tbxUrlInclude.Text = currentRule.IncludePart;
            this.tbxUrlExclude.Text = currentRule.ExcludePart;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            currentRule.IncludePart = this.tbxUrlInclude.Text;
            currentRule.ExcludePart = this.tbxUrlExclude.Text;
            this.Close();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}