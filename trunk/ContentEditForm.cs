﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jade.Model;
using System.Security.Permissions;
using System.Threading;
using System.Runtime.InteropServices;
using PresentationControls;
using Jade.Model.MySql;

namespace Jade
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public partial class ContentEditForm : Form
    {

        public IDownloadData CurrentData { get; set; }
        ListSelectionWrapper<DisplayNameValuePair> StatusSelections;
        List<DisplayNameValuePair> SpecilTags;
        public ContentEditForm()
        {
            InitializeComponent();
            this.txtnews_source_name.DataSource = RemoteWebService.Instance.GetSource();
            this.txtnews_source_name.DisplayMember = "DisplayName";
            this.txtnews_source_name.ValueMember = "Value";

            this.txt_news_template_file.DataSource = RemoteWebService.Instance.GetTemplate();
            this.txt_news_template_file.DisplayMember = "DisplayName";
            this.txt_news_template_file.ValueMember = "Value";

            SpecilTags = RemoteWebService.Instance.GetSpecilTags();
            StatusSelections = new ListSelectionWrapper<DisplayNameValuePair>(SpecilTags, "DisplayName");
            this.txt_tags.DataSource = StatusSelections;
            txt_tags.DisplayMemberSingleItem = "Name";
            this.txt_tags.DisplayMember = "NameConcatenated";
            this.txt_tags.ValueMember = "Selected";
            StatusSelections[0].Selected = true;

            this.cmbSearchLabel.DataSource = SpecilTags;
            this.cmbSearchLabel.DisplayMember = "DisplayName";
            this.cmbSearchLabel.ValueMember = "Value";
            this.cmbSearchLabel.SelectedIndexChanged += new EventHandler(cmbSearchLabel_SelectedIndexChanged);
            this.txtContent.SetScriptingForm(this);

        }

        void cmbSearchLabel_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tag = this.cmbSearchLabel.Text;
            var specialTag = SpecilTags.SingleOrDefault(t => t.DisplayName.Equals(tag.Trim()));
            var item = StatusSelections.FindObjectWithItem(specialTag);
            if (item != null)
                item.Selected = true;

            txt_tags.RefreshTxt();
        }

        public ContentEditForm(IDownloadData data)
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
                case "text5":
                    设为附加正文5ToolStripMenuItem_Click(null, null);
                    break;
                case "seoDescription":
                    设为SEO描述ToolStripMenuItem_Click(null, null);
                    break;
                case "seoKeyword":
                    toolStripMenuItem1_Click(null, null);
                    break;
                case "keyword":
                    添加为关键字ToolStripMenuItem_Click(null, null);
                    break;
            }
        }

        public void InitDownloadData(IDownloadData data)
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

                StatusSelections.ForEach(item => item.Selected = false);

                if (data.label_base != null)
                {
                    var tags = data.label_base.Replace("\"", "").Split('&');
                    foreach (var tag in tags)
                    {
                        if (tag != "")
                        {
                            var specialTag = SpecilTags.SingleOrDefault(t => t.DisplayName.Equals(tag.Trim()));
                            var item = StatusSelections.FindObjectWithItem(specialTag);
                            if (item != null)
                                item.Selected = true;
                        }

                    }
                }

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

                this.txt_gfbm_id.Text = data.gfbm_id;
                this.txt_gfbm_link.Text = data.gfbm_link;
                this.txt_kfbm_link.Text = data.kfbm_link;
                this.txt_kfbm_id.Text = data.kfbm_id;
                this.txt_news_abs.Text = data.news_abs;
                this.txt_news_description.Text = data.news_description;
                this.txt_news_down.Text = data.news_down;
                this.txt_news_guideimage.Text = data.news_guideimage;
                this.txt_news_guideimage2.Text = data.news_guideimage2;
                this.txt_news_left.Text = data.news_left;
                this.txt_news_right.Text = data.news_right;
                this.txt_news_top.Text = data.news_top;
                this.txtCommentUrl.Text = data.comment_url;

                this.chkISgfbm.Checked = data.ISgfbm;
                this.chkISkfbm.Checked = data.ISkfbm;

                this.panelkgbm.Visible = chkISkfbm.Checked;
                this.panelgfbm.Visible = chkISgfbm.Checked;


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
            UpdateCurrentData();
       
            CacheObject.DownloadDataDAL.Update(CurrentData);

            MessageBox.Show("保存成功");
        }

        private void UpdateCurrentData()
        {
            CurrentData.IsEdit = true;
            CurrentData.EditTime = DateTime.Now;
            CurrentData.EditorUserName = CacheObject.CurrentUser.Name;
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

            CurrentData.gfbm_id = this.txt_gfbm_id.Text;
            CurrentData.gfbm_link = this.txt_gfbm_link.Text;
            CurrentData.kfbm_link = this.txt_kfbm_link.Text;
            CurrentData.kfbm_id = this.txt_kfbm_id.Text;
            CurrentData.news_abs = this.txt_news_abs.Text;
            CurrentData.news_description =
           this.txt_news_description.Text;
            CurrentData.news_down =
           this.txt_news_down.Text;
            CurrentData.news_guideimage =
           this.txt_news_guideimage.Text;
            CurrentData.news_guideimage2 =
           this.txt_news_guideimage2.Text;
            CurrentData.news_left =
           this.txt_news_left.Text;
            CurrentData.news_right =
           this.txt_news_right.Text;
            CurrentData.news_top =
           this.txt_news_top.Text;
            CurrentData.comment_url =
           this.txtCommentUrl.Text;

            CurrentData.ISgfbm = this.chkISgfbm.Checked;
            CurrentData.ISkfbm = this.chkISkfbm.Checked;


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

        #region 编辑器菜单

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
            if (this.txt_news_keywords.Text != "")
                this.txt_news_keywords.AddWord(this.txtContent.SelectedText);
            else
                this.txt_news_keywords.Text = this.txtContent.SelectedText;
            this.txt_news_keywords.Focus();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.txt_news_keyword2.Text != "")
                this.txt_news_keyword2.AddWord(this.txtContent.SelectedText);
            else
                this.txt_news_keyword2.Text = this.txtContent.SelectedText;
            this.txt_news_keyword2.Focus();
        }

        private void 设为标题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txt_news_title.Text = this.txtContent.SelectedText;
        }

        private void 设为副标题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txt_news_subtitle.Text = this.txtContent.SelectedText;
            this.txt_news_subtitle.Focus();
        }

        private void 设为SEO描述ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txt_news_description.Text = this.txtContent.SelectedText;
            this.tabControl1.SelectedIndex = 1;
            this.txt_news_description.Focus();
        }

        private void 设为附件正文2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txt_news_top.Text = this.txtContent.SelectedText;
            this.tabControl1.SelectedIndex = 1;
            this.txt_news_top.Focus();
        }

        private void 设为附加正文3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txt_news_down.Text = this.txtContent.SelectedText;
            this.tabControl1.SelectedIndex = 1;
            this.txt_news_down.Focus();
        }

        private void 设为附加正文4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txt_news_left.Text = this.txtContent.SelectedText;
            this.tabControl1.SelectedIndex = 1;
            this.txt_news_left.Focus();
        }

        private void 设为附加正文5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txt_news_right.Text = this.txtContent.SelectedText;
            this.tabControl1.SelectedIndex = 1;
            this.txt_news_right.Focus();
        }

        #endregion

        private void chkISkfbm_CheckedChanged(object sender, EventArgs e)
        {
            this.panelkgbm.Visible = chkISkfbm.Checked;
        }

        private void chkISgfbm_CheckedChanged(object sender, EventArgs e)
        {
            this.panelgfbm.Visible = chkISgfbm.Checked;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            UpdateCurrentData();
            CurrentData.IsPublish = true;
            CacheObject.DownloadDataDAL.Update(CurrentData);
            MessageBox.Show("送签发成功");
            this.Close();
        }

        private void txt_news_keywords_Load(object sender, EventArgs e)
        {

        }

        private void txtContent_Load(object sender, EventArgs e)
        {

        }

        private void txt_news_keyword2_Load(object sender, EventArgs e)
        {

        }

        private void cmbSearchLabel_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void text_news_video_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }



    }
}