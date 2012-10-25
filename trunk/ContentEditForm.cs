using System;
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
using DevExpress.XtraSplashScreen;

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
            try
            {
                InitializeComponent();
                this.txt_news_keywords.SplitWord = "|";
                this.txt_news_keyword2.SplitWord = ",";
                this.DoubleBuffered = true;
                BindSelector();
                //StatusSelections[0].Selected = true;

                //this.cmbSearchLabel.DataSource = SpecilTags;
                this.cmbSearchLabel.DisplayMember = "DisplayName";
                this.cmbSearchLabel.ValueMember = "Value";
                this.cmbSearchLabel.SelectedIndexChanged += new EventHandler(cmbSearchLabel_SelectedIndexChanged);
                this.cmbSearchLabel.Text = "";
                this.txtContent.SetScriptingForm(this);
            }
            catch
            {
            }
        }

        private void BindSelector()
        {
            try
            {
                this.txtnews_source_name.DataSource = null;
                this.txtnews_source_name.DataSource = RemoteWebService.Instance.GetSource();
                this.txtnews_source_name.DisplayMember = "DisplayName";
                this.txtnews_source_name.ValueMember = "Value"
                    ;
                this.txt_news_template_file.DataSource = null;
                this.txt_news_template_file.DataSource = RemoteWebService.Instance.GetTemplate();
                this.txt_news_template_file.DisplayMember = "DisplayName";
                this.txt_news_template_file.ValueMember = "Value";

                SpecilTags = RemoteWebService.Instance.GetSpecilTags();
                StatusSelections = new ListSelectionWrapper<DisplayNameValuePair>(SpecilTags, "DisplayName");
                this.txt_tags.DataSource = StatusSelections;
                txt_tags.DisplayMemberSingleItem = "Name";
                this.txt_tags.DisplayMember = "NameConcatenated";
                this.txt_tags.ValueMember = "Selected";

                this.linkButtonGroup1.DataSource = RemoteWebService.Instance.GetCommonTags();
                this.linkButtonGroup1.DataBind();
            }
            catch
            {
            }
        }

        void cmbSearchLabel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isProcess)
            {
                if (this.cmbSearchLabel.SelectedItem != null && this.cmbSearchLabel.SelectedItem is DisplayNameValuePair)
                {
                    var tag = this.cmbSearchLabel.Text;
                    var specialTag = this.cmbSearchLabel.SelectedItem as DisplayNameValuePair;
                    var item = StatusSelections.FindObjectWithItem(specialTag);
                    if (item != null)
                    {
                        item.Selected = true;
                    }
                    else
                    {
                        RemoteWebService.Instance.SpecilTags.Add(specialTag);
                        RemoteWebService.Instance.Save();
                        item = new ObjectSelectionWrapper<DisplayNameValuePair>(specialTag, StatusSelections);
                        item.Selected = true;
                        StatusSelections.Add(item);
                        txt_tags.DataSource = null;
                        txt_tags.DataSource = StatusSelections;
                        //this.txt_tags.Items.Add(item);
                    }
                    txt_tags.RefreshTxt();
                }
            }
        }

        public ContentEditForm(IDownloadData data)
            : this()
        {
            InitDownloadData(data);
        }

        public string EditImage(string src, string title, string alt)
        {
            ImageForm image = new ImageForm(new ImageModel() { Src = src, Title = title, Alt = alt });
            if (image.ShowDialog() != DialogResult.OK)
            {
                return "";
            }
            return image.ImageModel.ToString();
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
                case "copy":
                    Clipboard.SetText(this.txtContent.SelectedText);
                    break;
                case "delete":
                    this.txtContent.DeleteSelect();
                    break;
            }
        }


        public void Log(string msg)
        {
            try
            {
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    lblStatus.Text = msg;
                    Log4Log.Error(msg);
                }));
            }
            catch
            {
            }
        }

        delegate void ReplaceImage(string old, string newUrl);

        public void UploadImage()
        {
            if (!CacheObject.IsLognIn)
            {
                return;
            }
            Log("上传图片中...");
            var data = CurrentData;
            if (data.Content.IndexOf("<img") > -1 || data.Content.IndexOf("<IMG") > -1)
            {
                HtmlAgilityPack.HtmlDocument HtmlDoc = new HtmlAgilityPack.HtmlDocument();
                HtmlDoc.OptionAutoCloseOnEnd = true;

                HtmlDoc.LoadHtml(data.Content);
                var nodes = HtmlDoc.DocumentNode.SelectNodes("//img");
                if (nodes != null)
                {
                    foreach (HtmlAgilityPack.HtmlNode node in nodes)
                    {
                        var src = node.Attributes["src"].Value;
                        if (!src.Contains("http://"))
                        {
                            //"file:///D:/project/Client-1.2R2/HFBBS/release//Pic/5/n14290497.jpg"
                            var file = src.Replace("file:///", "").Replace("//", "\\").Replace("/", "\\").Replace("%20", " ");
                            if (System.IO.File.Exists(file))
                            {
                                try
                                {
                                    Log("上传" + file + "中...");
                                    var real = RemoteAPI.UploadImage(file);
                                    if (real != "")
                                    {

                                        this.BeginInvoke(new ReplaceImage((string old,string newUrl) =>
                                        {
                                            try
                                            {
                                                Log("上传图片" + src + "成功，正在替换...");
                                                this.txtContent.Html = this.txtContent.Html.Replace(old, newUrl);
                                                Log("替换" + src + "成功");
                                            }
                                            catch
                                            {
                                                Log("替换" + src + "失败");
                                            }
                                        }), src, real);

                                        Thread.Sleep(2000);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Log("上传图片" + src + "失败...");
                                    Log4Log.Error("上传图片" + src + "失败");
                                }
                            }
                        }
                    }
                }
                HtmlDoc = null;
            }
            Log("上传图片完毕");
        }

        public void InitDownloadData(IDownloadData data)
        {
            BindSelector();
            CurrentData = data;

            
            if (data.Content != null)
            {
                this.txt_news_title.Text = data.Title;
                this.txt_news_subtitle.Text = "";
                this.txt_news_keywords.Text = data.Keywords;
                this.txtContent.Html = data.Content;
                this.txtContent.PageTitles = data.news_left;
                this.txt_row_news_abstract.Text = data.Summary;
                this.txt_news_keyword2.Text = data.news_keywords2;

                if (StatusSelections != null)
                    StatusSelections.ForEach(item => item.Selected = false);

                if (!string.IsNullOrEmpty(data.label_base))
                {
                    var tags = data.label_base.Replace("\"", "").Split('&', ',');
                    foreach (var tag in tags)
                    {
                        if (tag != "")
                        {
                            var specialTag = SpecilTags.FirstOrDefault(t => t.DisplayName.Equals(tag.Trim()));
                            var item = StatusSelections.FindObjectWithItem(specialTag);
                            if (item != null)
                                item.Selected = true;
                        }
                    }
                }
                else
                {
                    var specialTag = SpecilTags.FirstOrDefault(t => t.DisplayName.Equals(Properties.Settings.Default.DefaultTag.Trim()));
                    var item = StatusSelections.FindObjectWithItem(specialTag);
                    if (item != null)
                        item.Selected = true;
                }

                this.chk_bbspinglun.Checked = data.bbspinglun;
                this.chk_cmspinglun.Checked = data.cmspinglun;

                if (!string.IsNullOrEmpty(data.news_source_name))
                {
                    this.txtnews_source_name.Text = data.news_source_name;
                }
                else if (!string.IsNullOrEmpty(data.Source))
                {
                    this.txtnews_source_name.Text = data.Source;
                }
                else
                {
                    try
                    {
                        var defaultSouce = Properties.Settings.Default.DefaultSource.Trim();
                        this.txtnews_source_name.SelectedValue = defaultSouce;
                    }
                    catch
                    {
                        try
                        {
                            this.txtnews_source_name.SelectedIndex = 0;
                        }
                        catch
                        {
                        }
                    }
                }

                if (!string.IsNullOrEmpty(data.news_template_file))
                {
                    this.txt_news_template_file.SelectedValue = data.news_template_file;
                }
                else
                {
                    try
                    {
                        var defaultSouce = Properties.Settings.Default.DefaultTemplate.Trim();
                        this.txt_news_template_file.SelectedValue = defaultSouce;
                    }
                    catch
                    {
                        try
                        {
                            this.txt_news_template_file.SelectedIndex = 0;
                        }
                        catch
                        {
                        }
                    }
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

                data.Content = this.txtContent.Html;

                new Thread(UploadImage).Start();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateCurrentData();
            CacheObject.DownloadDataDAL.Update(CurrentData);
            MessageBox.Show("保存成功");
        }

        private void UpdateCurrentData()
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                this.txt_news_left.Text = this.txtContent.PageTitles;
            }

            if (CacheObject.CurrentRequestCount > CacheObject.MaxRequestCount)
            {
                //throw new Exception(
                // MessageBox.Show("已超过限定使用次数，程序自动退出");
                //Thread.Sleep(2000);
                //System.Environment.Exit(0);
                MessageBox.Show("你使用的是试用版，有问题请及时反馈！~");

                if (CacheObject.CurrentRequestCount > CacheObject.MaxRequestCount * 2)
                {
                    //throw new Exception(
                    MessageBox.Show("已超过限定使用次数，程序自动退出");
                    Thread.Sleep(2000);
                    System.Environment.Exit(0);
                }
            }

            if (this.txtnews_source_name.Text != "")
            {
                CurrentData.news_source_name = this.txtnews_source_name.Text;
            }
            else
            {
                CurrentData.news_source_name = RemoteWebService.Instance.GetSource()[0].DisplayName;
            }

            if (this.txt_news_template_file.SelectedItem != null)
            {
                CurrentData.news_template_file = (this.txt_news_template_file.SelectedItem as DisplayNameValuePair).Value;
            }
            else
            {
                CurrentData.news_template_file = (txt_news_template_file.Items[0] as DisplayNameValuePair).Value;
            }

            CurrentData.IsEdit = true;
            CurrentData.EditTime = DateTime.Now;
            CurrentData.EditorUserName = CacheObject.CurrentUser.Name;
            CurrentData.Content = txtContent.Html;
            CurrentData.Summary = this.txt_row_news_abstract.Text;

            CurrentData.Title = this.txt_news_title.Text;

            CurrentData.SubTitle = "";
                //this.txt_news_subtitle.Text;

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
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

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
            {
                this.txt_news_keywords.AddWord(this.txtContent.SelectedText);
            }
            else
                this.txt_news_keywords.Text = this.txtContent.SelectedText;

            if (this.txt_news_keyword2.Text != "")
                this.txt_news_keyword2.AddWord(this.txtContent.SelectedText);
            else
                this.txt_news_keyword2.Text = this.txtContent.SelectedText;

            this.txt_news_keywords.Focus();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.txt_news_keywords.Text != "")
            {
                this.txt_news_keywords.AddWord(this.txtContent.SelectedText);
            }
            else
                this.txt_news_keywords.Text = this.txtContent.SelectedText;

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
            //this.tabControl1.SelectedIndex = 1;
            this.txt_news_description.Focus();
        }

        private void 设为附件正文2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txt_news_top.Text = this.txtContent.SelectedText;
            //this.tabControl1.SelectedIndex = 1;
            this.txt_news_top.Focus();
        }

        private void 设为附加正文3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txt_news_down.Text = this.txtContent.SelectedText;
            //this.tabControl1.SelectedIndex = 1;
            this.txt_news_down.Focus();
        }

        private void 设为附加正文4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txt_news_left.Text = this.txtContent.SelectedText;
            //.tabControl1.SelectedIndex = 1;
            this.txt_news_left.Focus();
        }

        private void 设为附加正文5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txt_news_right.Text = this.txtContent.SelectedText;
            //this.tabControl1.SelectedIndex = 1;
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
            PublishContent(true);
        }

        bool isProcess = false;

        private void cmbSearchLabel_TextUpdate(object sender, EventArgs e)
        {
            if (CacheObject.IsLognIn)
            {
                if (this.cmbSearchLabel.Text != null)
                {
                    isProcess = true;
                    this.cmbSearchLabel.TextUpdate -= new System.EventHandler(this.cmbSearchLabel_TextUpdate);

                    try
                    {
                        var text = this.cmbSearchLabel.Text;

                        // this.cmbSearchLabel.Items.Clear();

                        this.cmbSearchLabel.DataSource = RemoteAPI.SearchLabel(this.cmbSearchLabel.Text);
                        cmbSearchLabel.SelectedIndex = -1;

                        cmbSearchLabel.DroppedDown = true;


                        cmbSearchLabel.Text = text;
                        cmbSearchLabel.SelectionStart = cmbSearchLabel.Text.Length;
                        //显示鼠标指针  
                        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.IBeam;
                        //保持鼠标指针形状  
                        Cursor = System.Windows.Forms.Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    this.cmbSearchLabel.TextUpdate += new System.EventHandler(this.cmbSearchLabel_TextUpdate);

                    isProcess = false;
                }
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {
            var imageSelector = new ImageSelecter(true);
            if (imageSelector.ShowDialog() == DialogResult.OK)
            {
                this.txt_news_guideimage.Text = imageSelector.SelectedFile;
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {

            var imageSelector = new ImageSelecter(true);
            if (imageSelector.ShowDialog() == DialogResult.OK)
            {
                this.txt_news_guideimage.Text = imageSelector.SelectedFile;
            }
        }
        LoadingDialog loadingDialog;
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            PublishContent();
        }

        private void PublishContent(bool sendToCheck = false)
        {
            if (CacheObject.IsLognIn)
            {

                if (this.txt_tags.Text == "")
                {
                    MessageBox.Show("请选择标签！'");
                    return;
                }

                if (this.txt_news_keywords.Text == "")
                {
                    MessageBox.Show("请填写关键字！'");
                    return;
                }

                if (this.txt_news_keyword2.Text == "")
                {
                    MessageBox.Show("请填写SEO关键字！'");
                    return;
                }

                this.loadingDialog = new LoadingDialog();

                loadingDialog.Show();
                loadingDialog.Message = "正在保存数据到服务器....";
                loadingDialog.Refresh();

                UpdateCurrentData();

                if (RemoteAPI.Publish(CurrentData))
                {
                    if (sendToCheck)
                    {
                        loadingDialog.BeginInvoke(new MethodInvoker(delegate()
                        {
                            loadingDialog.Refresh();
                            loadingDialog.Message = "保存成功，正在送签发....";
                        }));
                        RemoteAPI.SendNews(CurrentData.RemoteId, true);
                    }
                    CurrentData.IsPublish = true;

                    loadingDialog.BeginInvoke(new MethodInvoker(delegate()
                    {
                        loadingDialog.Refresh();
                        loadingDialog.Message = "保存成功，正在保存到数据库....";
                    }));
                    CacheObject.DownloadDataDAL.Update(CurrentData);

                    loadingDialog.Close();

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    loadingDialog.Close();
                    MessageBox.Show("发布失败，服务器响应'修改失败！'");
                }
            }
            else
            {
                MessageBox.Show("对不起，你还没有登录，不能往服务器发送内容");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                //
                this.txt_news_left.Text = this.txtContent.PageTitles;
            }
            else
            {
                if (this.txt_news_left.Text != this.txtContent.PageTitles)
                {
                    this.txtContent.PageTitles = this.txt_news_left.Text;
                }
            }
        }

        private void ContentEditForm_Load(object sender, EventArgs e)
        {

        }

        private void txt_news_title_TextChanged(object sender, EventArgs e)
        {
            this.lblWordCount.Text = "共" + GetLength(this.txt_news_title.Text) + "字";
        }

        public static double GetLength(string str)
        {
            if (str.Length == 0) return 0;
            ASCIIEncoding ascii = new ASCIIEncoding();
            double tempLen = 0;
            byte[] s = ascii.GetBytes(str);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 1;
                }
                else
                {
                    tempLen += 0.5;
                }
            }
            return tempLen;
        }

        private void txt_news_keywords_OnChange(object sender, EventArgs e)
        {
            this.txt_news_keyword2.Keywords = this.txt_news_keywords.Keywords;
        }

        private void txt_news_keyword2_OnChange(object sender, EventArgs e)
        {
            this.txt_news_keywords.Keywords = this.txt_news_keyword2.Keywords;
        }

        private void linkButtonGroup1_OnClick(object sender, Control.GroupClickArgs args)
        {
            var tag = args.Tag.Trim();
            var item = StatusSelections.Find(o => o.Name == tag);
            if (item != null)
            {
                item.Selected = true;
                txt_tags.RefreshTxt();
            }

        }
    }
}
