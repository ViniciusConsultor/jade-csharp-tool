﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HFBBS.Model;
using System.Security.Permissions;
using System.Threading;
using System.Runtime.InteropServices;

namespace HFBBS
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public partial class ContentEditForm : Form
    {

        public DownloadData CurrentData { get; set; }

        public ContentEditForm()
        {
            InitializeComponent();
            this.txtnews_source_name.DataSource = RemoteWebService.Instance.GetSource();
            this.txtnews_source_name.DisplayMember = "DisplayName";
            this.txtnews_source_name.ValueMember = "Value";

            this.txt_news_template_file.DataSource = RemoteWebService.Instance.GetTemplate();
            this.txt_news_template_file.DisplayMember = "DisplayName";
            this.txt_news_template_file.ValueMember = "Value";

            this.txt_tags.DataSource = RemoteWebService.Instance.GetSpecilTags();
            this.txt_tags.DisplayMember = "DisplayName";
            this.txt_tags.ValueMember = "Value";

            this.txtContent.SetScriptingForm(this);

        }
        public ContentEditForm(DownloadData data)
            : this()
        {
            InitDownloadData(data);
        }

        public void NotifyMenuClick(string commad)
        {
            //<li><a href="javascript:void(0);" name="summary">设为摘要</a></li>
            //    <li><a href="javascript:void(0);" name="title">设为标题</a></li>
            //    <li><a href="javascript:void(0);" name="subtitle">设为副标题</a></li>
            //    <li><a href="javascript:void(0);" name="text2">设为附加正文2</a></li>
            //    <li><a href="javascript:void(0);" name="text3">设为附加正文3</a></li>
            //    <li><a href="javascript:void(0);" name="text4">设为附加正文4</a></li>
            //    <li><a href="javascript:void(0);" name="seoDescription">设为SEO描述</a></li>
            //    <li><a href="javascript:void(0);" name="seoKeyword">添加为SEO关键词</a></li>
            //    <li><a href="javascript:void(0);" name="keyword">添加为关键词</a></li>
            switch (commad)
            {
                case "summary":
                    设为ToolStripMenuItem_Click(null, null);
                    break;
                case "title":
                    设为标题ToolStripMenuItem_Click(null, null);
                    break;
                case "subtitle":
                    设为副标题ToolStripMenuItem_Click(null, null);
                    break;
                case "text2":
                    设为附件正文2ToolStripMenuItem_Click(null, null);
                    break;
                case "text3":
                    设为附加正文3ToolStripMenuItem_Click(null, null);
                    break;
                case "text4":
                    设为附加正文4ToolStripMenuItem_Click(null, null);
                    break;
                case "seoDescription":
                    设为SEO描述ToolStripMenuItem_Click(null, null);
                    break;
                case "seoKeyword":
                    添加为关键字ToolStripMenuItem_Click(null, null);
                    break;
                case "keyword":
                    添加为关键字ToolStripMenuItem_Click(null, null);
                    break;
            }
        }

        public void InitDownloadData(DownloadData data)
        {
            CurrentData = data;
            if (data.Content != null)
            {
                this.txt_news_title.Text = data.Title;
                this.txt_news_subtitle.Text = data.SubTitle;
                this.txt_news_keywords.Text = data.Keywords;
                this.txtContent.Html = data.Content;
                this.txt_row_news_abstract.Text = data.Summary;
                this.txt_news_keyword2.Text = data.news_keywords2;
                this.txt_tags.Text = data.label_base;
                this.chk_bbspinglun.Checked = data.bbspinglun;
                this.chk_cmspinglun.Checked = data.cmspinglun;

                if (data.news_source_name != null)
                {
                    this.txtnews_source_name.Text = data.news_source_name;
                }

                if (data.news_template_file != null)
                {
                    this.txt_news_template_file.Text = data.news_template_file;
                }
            }
        }

        private void ContentEditForm_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CurrentData.Content = txtContent.Html;
            CurrentData.Summary = this.txt_row_news_abstract.Text;

            CurrentData.Title = this.txt_news_title.Text;

            CurrentData.SubTitle =
                       this.txt_news_subtitle.Text;

            CurrentData.Keywords =
                       this.txt_news_keywords.Text;

            CurrentData.Content =
                       this.txtContent.Html;

            CurrentData.Summary =
                       this.txt_row_news_abstract.Text;

            CurrentData.news_keywords2 =
                       this.txt_news_keyword2.Text;

            CurrentData.label_base =
                       this.txt_tags.Text;

            CurrentData.bbspinglun =
                       this.chk_bbspinglun.Checked;

            CurrentData.cmspinglun =
                       this.chk_cmspinglun.Checked;

            CurrentData.Update();

            MessageBox.Show("保存成功");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
            this.Close();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void 设为XXXToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (this.txtContent.SelectedText == null)
            {
                e.Cancel = true;
            }
        }

        private void 设为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txt_row_news_abstract.Text = this.txtContent.SelectedText;
        }

        private void 添加为关键字ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txt_news_keywords.Text += "|" + this.txtContent.SelectedText;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.txt_news_keyword2.Text += " " + this.txtContent.SelectedText;
        }

        private void 设为标题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txt_news_title.Text = this.txtContent.SelectedText;
        }

        private void 设为副标题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txt_news_subtitle.Text = this.txtContent.SelectedText;
        }

        private void 设为SEO描述ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 设为附件正文2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 设为附加正文3ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 设为附加正文4ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chkISkfbm_CheckedChanged(object sender, EventArgs e)
        {
            this.panelkgbm.Visible = chkISkfbm.Checked;
        }

        private void chkISgfbm_CheckedChanged(object sender, EventArgs e)
        {
            this.panelgfbm.Visible = chkISgfbm.Checked;
        }

    }
}
