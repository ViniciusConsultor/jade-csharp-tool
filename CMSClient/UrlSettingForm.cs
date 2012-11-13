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
            if (!string.IsNullOrEmpty(currentRule.DiyContentPageUrl))
            {
                string[] urls = currentRule.DiyContentPageUrl.Split(new string[] { BaseConfig.UrlSeparator }, StringSplitOptions.RemoveEmptyEntries);
                if (urls != null && urls.Length > 0)
                {
                    foreach (string url in urls)
                    {
                        this.lbxUrls.Items.Add(url);
                    }
                    this.lbxUrls.SelectedIndex = 0;
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            currentRule.IncludePart = this.tbxUrlInclude.Text;
            currentRule.ExcludePart = this.tbxUrlExclude.Text;
            if (this.lbxUrls.Items != null && this.lbxUrls.Items.Count > 0)
            {
                string tempUrl = string.Empty;
                foreach (string url in this.lbxUrls.Items)
                {
                    if (tempUrl != string.Empty)
                    {
                        tempUrl += BaseConfig.UrlSeparator;
                    }
                    tempUrl += url;
                }
                currentRule.DiyContentPageUrl = tempUrl;
            }
            this.Close();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.lbxUrls.Items.Remove(this.lbxUrls.SelectedItem);
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            URLBuilder urlBuilder = new URLBuilder();
            string[] urls = new string[this.lbxUrls.Items.Count];
            this.lbxUrls.Items.CopyTo(urls, 0);
            urlBuilder.FinishedUrls = urls;

            if (urlBuilder.ShowDialog() == DialogResult.OK)
            {
                this.lbxUrls.Items.Clear();
                this.lbxUrls.Items.AddRange(urlBuilder.FinishedUrls);
            }
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,
                 "您确定要清空所有的采集地址？",
                 "清空采集地址",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question,
                 MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.lbxUrls.Items.Clear();
            }
        }

        private void 查看代码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lbxUrls.SelectedItem == null)
            {
                MessageBox.Show(this, "请选择一个采集地址！", "请选择采集地址", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SourceGetter sourceGetter = new SourceGetter((string)this.lbxUrls.SelectedItem);
            sourceGetter.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            URLBuilder urlBuilder = new URLBuilder();
            if (urlBuilder.ShowDialog() == DialogResult.OK)
            {
                this.lbxUrls.Items.AddRange(urlBuilder.FinishedUrls);
            }
        }

    }
}