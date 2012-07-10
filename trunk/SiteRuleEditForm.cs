using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HFBBS.Forms;
using HFBBS.Model;
using System.Threading;
using System.IO;

namespace HFBBS
{
    public partial class SiteRuleEditForm : Form, HFBBS.IWorkingThread
    {
        bool isSaving = false;

        public SiteRule CurrentSiteRule { get; set; }

        public ItemRule CurrentItemRule { get; set; }


        public void UpdateSiteRule()
        {
            CurrentSiteRule.Name = this.txtRuleName.Text;
            CurrentSiteRule.ListXPath = this.txtLinkXPath.Text;
            CurrentSiteRule.ListFetchType = this.rdoLinkXpath.Checked ? ItemFetchType.XPath : ItemFetchType.FromHTML;
            CurrentSiteRule.Encoding = (string)this.cbbEncoding.SelectedItem;
            CurrentSiteRule.HttpMethod = (string)this.cbbMethod.SelectedItem;
            if (string.IsNullOrEmpty(this.tbxReferer.Text))
                CurrentSiteRule.Referer = null;
            else
                CurrentSiteRule.Referer = this.tbxReferer.Text;

            if (this.rdbHtml.Checked)
                CurrentSiteRule.ListPageType = ListPageType.Html;
            else
                CurrentSiteRule.ListPageType = ListPageType.RSS;

            if (string.IsNullOrEmpty(this.tbxCookie.Text))
                CurrentSiteRule.Cookie = null;
            else
                CurrentSiteRule.Cookie = this.tbxCookie.Text;

            if (string.IsNullOrEmpty(this.tbxUserAgent.Text))
                CurrentSiteRule.UserAgent = null;
            else
                CurrentSiteRule.UserAgent = this.tbxUserAgent.Text;

            if (string.IsNullOrEmpty(this.tbxPostData.Text))
                CurrentSiteRule.HttpPostData = null;
            else
                CurrentSiteRule.HttpPostData = this.tbxPostData.Text;

            //Url Include Part.
            if (string.IsNullOrEmpty(this.tbxUrlInclude.Text))
                CurrentSiteRule.IncludePart = null;
            else
                CurrentSiteRule.IncludePart = this.tbxUrlInclude.Text;

            //Url Exclude Part.
            if (string.IsNullOrEmpty(this.tbxUrlExclude.Text))
                CurrentSiteRule.ExcludePart = null;
            else
                CurrentSiteRule.ExcludePart = this.tbxUrlExclude.Text;

            //FetchStartSymbolic
            if (string.IsNullOrEmpty(this.tbxFetchStartSymbolic.Text))
                CurrentSiteRule.PageStartAt = null;
            else
                CurrentSiteRule.PageStartAt = this.tbxFetchStartSymbolic.Text;

            //FetchEndSymbolic
            if (string.IsNullOrEmpty(this.tbxFetchEndSymbolic.Text))
                CurrentSiteRule.PageEndAt = null;
            else
                CurrentSiteRule.PageEndAt = this.tbxFetchEndSymbolic.Text;

            if (string.IsNullOrEmpty(this.cbListEncoding.SelectedItem.ToString()))
                CurrentSiteRule.ListEncoding = "UTF-8";
            else
                CurrentSiteRule.ListEncoding = this.cbListEncoding.SelectedItem.ToString();

            //CurrentSiteRule.Depth = int.Parse(this.cmbDepth.Text);
            // CurrentSiteRule.ListPageStartAt = this.txtListStart.Text;
            // CurrentSiteRule.ListPageEndAt = this.txtListEnd.Text;
            // CurrentSiteRule.ListIncludePart = this.txtListMust.Text;
            // CurrentSiteRule.ListExcludePart = this.txtListMustNotContain.Text;



            if (this.lbxUrls.Items != null || this.lbxUrls.Items.Count > 0)
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
                CurrentSiteRule.StartUrl = tempUrl;
            }

            CurrentSiteRule.ForTestUrl = this.tbxItemUrl.Text;

            //CurrentSiteRule.ItemRules.Clear();

            //siteRow.UrlTrim = this.getTrimString();

            //siteRow.Urlreplace = this.GetUrlTrim();
        }

        public void UpdateItemRule()
        {

            if (this.radioFixedValue.Checked)
            {
                CurrentItemRule.FetchType = ItemFetchType.UserDiy;
            }
            else if (this.radioCExtract.Checked)
            {
                CurrentItemRule.FetchType = ItemFetchType.FromHTML;
            }
            else if (this.radioCxPath.Checked)
            {
                CurrentItemRule.FetchType = ItemFetchType.XPath;
            }
            else if (this.radioCRegex.Checked)
            {
                CurrentItemRule.FetchType = ItemFetchType.FromRegex;
            }

            CurrentItemRule.StartTarget = this.tbxStartTarget.Text;

            CurrentItemRule.EndTarget = this.tbxEndTarget.Text;

            CurrentItemRule.XPath = this.txtCXpath.Text;

            if (this.radioOne.Checked)
            {
                CurrentItemRule.XMLPathSelectType = XMLPathSelectType.OnlyOne;
            }
            else
            {
                CurrentItemRule.XMLPathSelectType = XMLPathSelectType.Multiple;
            }

            if (this.radioHref.Checked)
            {
                CurrentItemRule.XMLPathType = XMLPathType.Href;
            }
            else if (this.radioHtml.Checked)
            {
                CurrentItemRule.XMLPathType = XMLPathType.InnerHtml;
            }
            else if (this.radionInnerLinks.Checked)
            {
                CurrentItemRule.XMLPathType = XMLPathType.InnerLinks;
            }
            else if (this.radioText.Checked)
            {
                CurrentItemRule.XMLPathType = XMLPathType.InnerText;
            }
            else if (this.radioTextWithPic.Checked)
            {
                CurrentItemRule.XMLPathType = XMLPathType.InnerTextWithPic;
            }

            CurrentItemRule.RegexText = this.txtRegex.Text;
            CurrentItemRule.IdentifyPage = this.chkIdentifyPage.Checked;
            CurrentItemRule.PageStart = this.txtPageStart.Text;
            CurrentItemRule.PageEnd = this.txtPageEnd.Text;
            if (this.radioDatetime.Checked)
            {
                CurrentItemRule.DiyType = UserDiyType.Datetime;
            }
            else
            {
                CurrentItemRule.DiyType = UserDiyType.DefaultValue;
            }

            CurrentItemRule.DateTimeFormatString = this.txtDatetimeFormat.Text;
            CurrentItemRule.DefaultValue = this.txtFixString.Text;
            CurrentItemRule.IsDownloadPic = chkDownloadPic.Checked;
        }

        public SiteRuleEditForm(SiteRule rule)
        {

            InitializeComponent();
            this.cbListEncoding.Items.AddRange(EncodingUIBuilder.EncodingList.ToArray());
            this.cbbEncoding.Items.AddRange(EncodingUIBuilder.EncodingList.ToArray());
            if (cbListEncoding.Items.Count > 0)
            {
                cbbEncoding.SelectedIndex = 0;
                cbListEncoding.SelectedIndex = 0;
            }

            this.CurrentSiteRule = rule;
            this.InitializeUIItem(rule);
            if (rule.ItemRules.Count > 0)
            {
                this.CurrentItemRule = rule.ItemRules[0];
                if (CurrentItemRule != null)
                {
                    switch (CurrentItemRule.ItemName)
                    {
                        case "标题":
                            this.tabTitle.SelectedIndex = 0;
                            break;

                        case "时间":
                            this.tabTitle.SelectedIndex = 2;
                            break;

                        case "来源":
                            this.tabTitle.SelectedIndex = 1;
                            break;

                        case "摘要":
                            this.tabTitle.SelectedIndex = 3;
                            break;

                        case "内容":
                            this.tabTitle.SelectedIndex = 4;
                            break;

                        case "其他":
                            this.tabTitle.SelectedIndex = 5;
                            break;
                    }
                }
                this.InitializeItemRuleDetail(CurrentItemRule);
            }
        }

        #region InitializeUIItem

        private void InitializeUIItem(SiteRule row)
        {//Fill Start Url List.
            this.txtRuleName.Text = row.Name;

            if (row.ListFetchType == ItemFetchType.XPath)
            {
                this.rdoLinkXpath.Checked = true;
            }
            else
            {
                this.rdoHtmlExtact.Checked = true;
            }
            this.txtLinkXPath.Text = row.ListXPath;

            this.tbxFetchStartSymbolic.Text = row.PageStartAt;
            this.tbxFetchEndSymbolic.Text = row.PageEndAt;

            this.lbxUrls.Items.Clear();
            if (row != null)
            {
                if (!string.IsNullOrEmpty(row.StartUrl))
                {
                    string[] urls = row.StartUrl.Split(new string[] { BaseConfig.UrlSeparator }, StringSplitOptions.RemoveEmptyEntries);
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

            //File Encoding ComboBox.
            if (this.cbbEncoding.Items.Count > 0)
                this.cbbEncoding.SelectedIndex = 0; //Empty Value.

            if (this.cbListEncoding.Items.Count > 0)
                this.cbListEncoding.SelectedIndex = 0; //Empty Value.

            if (row != null)
            {
                for (int i = 0; i < this.cbListEncoding.Items.Count; i++)
                {
                    if (this.cbListEncoding.Items[i].Equals(row.ListEncoding))
                    {
                        this.cbListEncoding.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < this.cbbEncoding.Items.Count; i++)
                {
                    if (this.cbbEncoding.Items[i].Equals(row.Encoding))
                    {
                        this.cbbEncoding.SelectedIndex = i;
                        break;
                    }
                }
            }

            //Fill Method ComboBox.
            if (this.cbbMethod.Items.Count > 0)
                this.cbbMethod.SelectedIndex = 0; //Empty Value.

            if (row != null)
            {
                for (int i = 0; i < this.cbbMethod.Items.Count; i++)
                {
                    if (this.cbbMethod.Items[i].Equals(row.HttpMethod))
                    {
                        this.cbbMethod.SelectedIndex = i;
                        break;
                    }
                }
            }

            if (row != null)
            {
                if (!string.IsNullOrEmpty(row.Referer))
                    this.tbxReferer.Text = row.Referer;
                else
                    this.tbxReferer.Clear();


                //File Type.
                if (row.ListPageType == ListPageType.Html)
                    this.rdbHtml.Checked = true;
                else
                    this.rdbRss.Checked = true;

                if (!this.rdbHtml.Checked && !this.rdbRss.Checked)
                    this.rdbHtml.Checked = true;

                //Fill Cookie.

                this.tbxCookie.Text = row.Cookie;

                //Fill User Agent.

                this.tbxUserAgent.Text = row.UserAgent;


                //Fill Post Data.

                this.tbxPostData.Text = row.HttpPostData;

                //Url Include Part.

                this.tbxUrlInclude.Text = row.IncludePart;

                this.tbxUrlExclude.Text = row.ExcludePart;

                this.tbxItemUrl.Text = row.ForTestUrl;

            }

        }

        private void InitializeItemRuleDetail(ItemRule row)
        {
            if (row != null)
            {
                switch (row.FetchType)
                {
                    case ItemFetchType.UserDiy:
                        this.radioFixedValue.Checked = true;
                        break;
                    case ItemFetchType.FromHTML:
                        this.radioCExtract.Checked = true;
                        break;
                    case ItemFetchType.XPath:
                        this.radioCxPath.Checked = true;
                        break;
                    case ItemFetchType.FromRegex:
                        this.radioCRegex.Checked = true;
                        break;
                }

                if (row.StartTarget != null)
                    this.tbxStartTarget.Text = row.StartTarget;

                if (row.EndTarget != null)
                    this.tbxEndTarget.Text = row.EndTarget;

                if (row.XPath != null)
                    this.txtCXpath.Text = row.XPath;


                BindXpathType(row.XMLPathType);

                if (row.XMLPathSelectType == XMLPathSelectType.OnlyOne)
                {
                    this.radioOne.Checked = true;
                }
                else
                {
                    this.radioMulti.Checked = true;
                }


                if (row.RegexText != null)
                    this.txtRegex.Text = row.RegexText;
                this.chkIdentifyPage.Checked = row.IdentifyPage;
                if (row.PageStart != null)
                    this.txtPageStart.Text = row.PageStart;
                if (row.PageEnd != null)
                    this.txtPageEnd.Text = row.PageEnd;

                this.chkDownloadPic.Checked = row.IsDownloadPic;
                chkDownloadPic.Checked = row.IsDownloadPic;
                if (row.DiyType == UserDiyType.Datetime)
                {
                    this.radioDatetime.Checked = true;
                }
                else
                {
                    this.radioFixString.Checked = true;
                }


                if (row.DefaultValue != null)
                    this.txtFixString.Text = row.DefaultValue;
                if (row.DateTimeFormatString != null)
                    this.txtDatetimeFormat.Text = row.DateTimeFormatString;

            }
        }

        private void BindXpathType(XMLPathType type)
        {
            switch (type)
            {
                case XMLPathType.Href:
                    this.radioHref.Checked = true;
                    break;
                case XMLPathType.InnerLinks:
                    this.radionInnerLinks.Checked = true;
                    break;
                case XMLPathType.InnerHtml:
                    this.radioHtml.Checked = true;
                    break;
                case XMLPathType.InnerText:
                    this.radioText.Checked = true;
                    break;
                case XMLPathType.InnerTextWithPic:
                    this.radioTextWithPic.Checked = true;
                    break;

                default:
                    break;
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            new HFBBS.Forms.XmlPathSelector("http://news.baidu.com").Show();
        }


        private void rdoLinkXpath_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoLinkXpath.Checked)
            {
                this.palExtract.Visible = false;
                this.panelLinkXPatg.Visible = true;
                this.palExtract.SendToBack();
                this.panelLinkXPatg.BringToFront();
            }
            else
            {
                this.palExtract.Visible = true;
                this.panelLinkXPatg.Visible = false;
                this.palExtract.BringToFront();
                this.panelLinkXPatg.SendToBack();
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InsertToRichTextbox("前字符串", this.txtRegex, Color.Black);
            InsertToRichTextbox("(?<content>[\\s\\S]*?)", this.txtRegex, Color.Green);
            InsertToRichTextbox("后字符串", this.txtRegex, Color.Black);
        }

        private void InsertToRichTextbox(string str, RichTextBox txtbox, Color color)
        {
            int i = txtbox.SelectionStart;
            txtbox.Select(i, 0);
            txtbox.SelectionColor = color;
            txtbox.Focus();
            txtbox.AppendText(str);
            txtbox.Select(i + str.Length, 0);
            txtbox.SelectionColor = Color.Black;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InsertToRichTextbox("(*)", this.txtRegex, Color.Green);
        }

        private void radioContentType_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox5.Show();
            if (this.radioCRegex.Checked)
            {
                this.panelUserDiy.SendToBack();
                this.panelxPath.SendToBack();
                this.panelCExtract.SendToBack();
                this.panelUserDiy.Visible = false;
                this.panelxPath.Visible = false;
                this.panelCExtract.Visible = false;
                this.panelRegex.BringToFront();
                this.panelRegex.Show();
            }
            else if (this.radioCxPath.Checked)
            {

                this.panelRegex.Visible = false;
                this.panelUserDiy.Visible = false;
                this.panelCExtract.Visible = false;
                this.panelxPath.BringToFront();
                this.panelxPath.Show();
            }
            else if (this.radioFixedValue.Checked)
            {
                this.panelCExtract.SendToBack();
                this.panelRegex.SendToBack();
                this.panelxPath.SendToBack();
                this.panelCExtract.Visible = false;
                this.panelRegex.Visible = false;
                this.panelxPath.Visible = false;
                this.panelUserDiy.BringToFront();
                this.panelUserDiy.Show();
                this.groupBox5.Hide();
            }
            else
            {
                this.panelRegex.Visible = false;
                this.panelUserDiy.Visible = false;
                this.panelxPath.Visible = false;
                this.panelCExtract.BringToFront();
                this.panelCExtract.Show();
            }
            this.groupBox5.BringToFront();
        }

        /// <summary>
        /// ItemRule 选择更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabItemRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateItemRule();

            this.panelItemRule.Parent.Controls.Remove(this.panelItemRule);
            this.tabTitle.SelectedTab.Controls.Add(this.panelItemRule);
            if (this.tabTitle.SelectedTab.Text == "内容")
            {
                this.chkDownloadPic.Enabled = true;
            }
            else
            {
                this.chkDownloadPic.Enabled = false;
            }

            CurrentItemRule = CurrentSiteRule.ItemRules.SingleOrDefault(r => r.ItemName == tabTitle.SelectedTab.Text);

            this.InitializeItemRuleDetail(CurrentItemRule);
        }

        #region 列表页控制

        private void btnAdd_Click(object sender, EventArgs e)
        {
            URLBuilder urlBuilder = new URLBuilder();
            if (urlBuilder.ShowDialog() == DialogResult.OK)
            {
                this.lbxUrls.Items.AddRange(urlBuilder.FinishedUrls);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.lbxUrls.Items.Remove(this.lbxUrls.SelectedItem);
        }

        private void btnClean_Click(object sender, EventArgs e)
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

        private void btnUrlSource_Click(object sender, EventArgs e)
        {
            if (this.lbxUrls.SelectedItem == null)
            {
                MessageBox.Show(this, "请选择一个采集地址！", "请选择采集地址", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SourceGetter sourceGetter = new SourceGetter((string)this.lbxUrls.SelectedItem);
            sourceGetter.Show();
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.isSaving = true;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnGetCookie_Click(object sender, EventArgs e)
        {
            CookieChecker cookieChecker;
            if (this.lbxUrls.SelectedItem != null)
            {
                cookieChecker = new CookieChecker((string)this.lbxUrls.SelectedItem);
            }
            else
            {
                cookieChecker = new CookieChecker();
            }
            if (cookieChecker.ShowDialog() == DialogResult.OK)
            {
                this.tbxCookie.Text = cookieChecker.CookieValue;
            }
        }

        private void SiteRuleEditForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLinkXPath_Click(object sender, EventArgs e)
        {
            List<Uri> urls;
            if (!CheckExtractUrlIsAvailable(out urls)) return;
            var url = urls.Count > 0 ? urls[0].AbsoluteUri : "http://www.hefei.cc";
            var path = this.txtLinkXPath.Text ?? "//a";
            HFBBS.Forms.XmlPathSelector xpath = new XmlPathSelector(url, path, CurrentSiteRule.ListXMLPathType, CurrentSiteRule.ListXMLPathSelectType);
            if (xpath.ShowDialog() == DialogResult.OK)
            {
                this.txtLinkXPath.Text = xpath.XPath;
                CurrentSiteRule.ListXMLPathSelectType = xpath.XMLPathSelectType;
                CurrentSiteRule.ListXMLPathType = xpath.XMLPathType;
            }
        }

        private void btnCXPath_Click(object sender, EventArgs e)
        {
            UpdateItemRule();
            var url = this.tbxItemUrl.Text != "" ? this.tbxItemUrl.Text : "http://www.hefei.cc";
            HFBBS.Forms.XmlPathSelector xpath = new XmlPathSelector(url, CurrentItemRule.XPath, CurrentItemRule.XMLPathType, CurrentItemRule.XMLPathSelectType);
            if (xpath.ShowDialog() == DialogResult.OK)
            {
                this.txtCXpath.Text = xpath.XPath;

                BindXpathType(xpath.XMLPathType);

                if (xpath.XMLPathSelectType == XMLPathSelectType.OnlyOne)
                {
                    this.radioOne.Checked = true;
                }
                else
                {
                    this.radioMulti.Checked = true;
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.UpdateSiteRule();
            this.UpdateItemRule();
            this.isSaving = true;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void SiteRuleEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isSaving)
            {
                if (MessageBox.Show("你有修改未保存，确认退出", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            UpdateSiteRule();
            List<Uri> urls;
            if (!CheckExtractUrlIsAvailable(out urls)) return;
            this.tabSetting.SelectedIndex = 3;
            this.tabSetting.Refresh();
            ExtractUrls(urls);
        }


        private bool CheckExtractUrlIsAvailable(out List<Uri> urls)
        {

            urls = new List<Uri>();
            foreach (string sourceUrl in lbxUrls.Items)
            {
                List<string> sourceUrls;
                try
                {
                    sourceUrls = ExtractUrl.ParseUrlFromParameter(sourceUrl);
                }
                catch
                {
                    MessageBox.Show(this, "测试采集网址的格式非法！", "测试采集网址错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                foreach (string extractUrl in sourceUrls)
                {
                    Uri uri;
                    if (Uri.TryCreate(extractUrl, UriKind.Absolute, out uri))
                    {
                        urls.Add(uri);
                    }
                }
            }
            if (urls.Count == 0)
            {
                MessageBox.Show(this, "没有合法的测试采集网址！", "测试采集网址错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public Thread workingThread { get; set; }

        private LoadingDialog loadingDialog = null;

        private void ExtractUrls(List<Uri> urls)
        {
            this.trvUrlTree.Nodes.Clear();
            this.loadingDialog = new LoadingDialog(this);
            loadingDialog.Show();
            loadingDialog.Percentage = 0;
            loadingDialog.Refresh();

            var item = CurrentSiteRule;

            this.workingThread = new Thread(delegate()
            {

                int i = 0;

                while (true)
                {
                    if (i == urls.Count)
                    {
                        loadingDialog.BeginInvoke(new MethodInvoker(delegate()
                        {
                            loadingDialog.Percentage = 100;
                            this.loadingDialog.Refresh();
                            this.loadingDialog.Close();
                        }));

                        break;
                    }

                    var html = HtmlPicker.VisitUrl(urls[i],
                                                       item.HttpMethod,
                                                       null,
                                                       string.IsNullOrEmpty(item.Referer) ? null : item.Referer,
                                                   string.IsNullOrEmpty(item.Cookie) ? null : Utility.GetCookies(item.Cookie),
                                                   string.IsNullOrEmpty(item.UserAgent) ? null : item.UserAgent,
                                                   string.IsNullOrEmpty(item.HttpPostData) ? null : item.HttpPostData,
                                                       System.Text.Encoding.GetEncoding(item.ListEncoding));

                    SetExtractUrl(item, html, urls[i].AbsoluteUri, item.ListEncoding);

                    File.WriteAllText("test.txt", html);
                    i++;

                    loadingDialog.BeginInvoke(new MethodInvoker(delegate()
                    {
                        loadingDialog.Refresh();
                        loadingDialog.Percentage = 100 * i / urls.Count;
                    }));

                    #region oldCode

                    //else if (extractClient.IsBusy)
                    //    continue;
                    //else
                    //{
                    //    if ((string)this.cbbMethod.SelectedItem != "POST")
                    //    {
                    //        extractClient.DownloadStringAsync(urls[i], new object[] { i, urls.Count, urls[i].AbsoluteUri });
                    //    }
                    //    else
                    //    {
                    //        extractClient.UploadStringAsync(urls[i], "POST", this.tbxPostData.Text, new object[] { i, urls.Count, urls[i].AbsoluteUri });
                    //    }
                    //    i++;
                    //}  
                    #endregion

                }
            });
            this.workingThread.Start();
        }

        private void SetExtractStatus(int percentage)
        {
            this.loadingDialog.Refresh();
            this.loadingDialog.Activate();
            this.loadingDialog.Percentage = percentage;
        }

        private void SetExtractUrl(
            SiteRule item,
            string html, string sourceUrl,
            string encoding)
        {

            // 1 级  
            if (item.Depth == 1)
            {
                TreeNode parentNode = new TreeNode(sourceUrl);
                List<string> urls;

                if (this.rdbHtml.Checked)
                {
                    if (this.rdoLinkXpath.Checked)
                    {
                        urls = ExtractUrl.ExtractAccurateUrl(CurrentSiteRule, html, sourceUrl);
                    }
                    else
                    {
                        urls = ExtractUrl.ExtractAccurateUrl(sourceUrl, html, item.PageStartAt, item.PageEndAt, item.IncludePart, item.ExcludePart, "", new List<string>());
                    }
                }
                else
                    urls = ExtractUrl.ExtractAccurateRssUrl(RssPicker.GetRssLinks(html, Encoding.GetEncoding(encoding)), item.IncludePart, item.ExcludePart);

                foreach (string url in urls)
                {
                    parentNode.Nodes.Add(url);
                }

                this.trvUrlTree.BeginInvoke(new MethodInvoker(delegate()
                {
                    this.trvUrlTree.Nodes.Add(parentNode);
                }));
            }
            else
            {
                // 2 级采集
                TreeNode parentNode = new TreeNode(sourceUrl);
                this.trvUrlTree.BeginInvoke(new MethodInvoker(delegate()
                {
                    this.trvUrlTree.Nodes.Add(parentNode);
                }));

                List<string> urls;
                List<string> childUrls;
                if (this.rdbHtml.Checked)
                    urls = ExtractUrl.ExtractAccurateUrl(sourceUrl, html, string.IsNullOrEmpty(item.ListPageStartAt) ? null : item.ListPageStartAt,
                                                                                    string.IsNullOrEmpty(item.ListPageEndAt) ? null : item.ListPageEndAt,
                                                                                   string.IsNullOrEmpty(item.ListIncludePart) ? null : item.ListIncludePart,
                                                                                   string.IsNullOrEmpty(item.ListExcludePart) ? null : item.ListExcludePart,
                                                                                   item.UrlTrim, item.Urlreplace);
                else
                    urls = ExtractUrl.ExtractAccurateRssUrl(RssPicker.GetRssLinks(html, Encoding.GetEncoding(encoding)), string.IsNullOrEmpty(item.ListIncludePart) ? null : item.ListIncludePart,
                                                                                                 string.IsNullOrEmpty(item.ListExcludePart) ? null : item.ListExcludePart);
                var index = 0;
                foreach (string url in urls)
                {
                    loadingDialog.BeginInvoke(new MethodInvoker(delegate()
                    {
                        loadingDialog.Percentage = 100 * index++ / urls.Count;
                        loadingDialog.Refresh();
                    }));

                    var childHtml = HtmlPicker.VisitUrl(new Uri(url),
                                                        item.HttpMethod,
                                                        null,
                                                        string.IsNullOrEmpty(item.Referer) ? null : item.Referer,
                                                    string.IsNullOrEmpty(item.Cookie) ? null : Utility.GetCookies(item.Cookie),
                                                    string.IsNullOrEmpty(item.UserAgent) ? null : item.UserAgent,
                                                    string.IsNullOrEmpty(item.HttpPostData) ? null : item.HttpPostData,
                                                        System.Text.Encoding.GetEncoding(item.Encoding));

                    if (this.rdbHtml.Checked)
                        childUrls = ExtractUrl.ExtractAccurateUrl(url, childHtml, item.PageStartAt,
                                                                                              item.PageEndAt,
                                                                                               item.IncludePart,
                                                                                               item.ExcludePart, "", new List<string>());
                    else

                        childUrls = ExtractUrl.ExtractAccurateRssUrl(RssPicker.GetRssLinks(childHtml, Encoding.GetEncoding(encoding)), item.IncludePart,
                                                                                               item.ExcludePart);

                    this.trvUrlTree.BeginInvoke(new MethodInvoker(delegate()
                    {
                        var listNode = new TreeNode();
                        listNode.Text = url;

                        foreach (var childUrl in childUrls)
                        {
                            listNode.Nodes.Add(childUrl);

                        }
                        parentNode.Nodes.Add(listNode);
                    }));
                }


            }
        }


        private void btnBackToUrlSetting_Click(object sender, EventArgs e)
        {
            this.tabSetting.SelectedIndex = 0;
        }

        private void btnOutputChildNode_Click(object sender, EventArgs e)
        {
            if (this.trvUrlTree.Nodes == null || this.trvUrlTree.Nodes.Count == 0)
            {
                MessageBox.Show(this, "没有可用的采集地址！", "操作采集地址错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "URL地址列表文件 [*.txt]|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(dialog.FileName))
                    File.Delete(dialog.FileName);
                StreamWriter writer = new StreamWriter(File.OpenWrite(dialog.FileName));
                foreach (TreeNode parent in this.trvUrlTree.Nodes)
                {
                    if (parent.Nodes != null && parent.Nodes.Count > 0)
                    {
                        foreach (TreeNode child in parent.Nodes)
                        {
                            writer.WriteLine(child.Text);
                        }
                    }
                }
                writer.Flush();
                writer.Close();
            }
        }

        private void btnOutputParentNode_Click(object sender, EventArgs e)
        {
            if (this.trvUrlTree.Nodes == null || this.trvUrlTree.Nodes.Count == 0)
            {
                MessageBox.Show(this, "没有可用的采集地址！", "操作采集地址错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "URL地址列表文件 [*.txt]|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(dialog.FileName))
                    File.Delete(dialog.FileName);
                StreamWriter writer = new StreamWriter(File.OpenWrite(dialog.FileName));
                foreach (TreeNode node in this.trvUrlTree.Nodes)
                {
                    writer.WriteLine(node.Text);
                }
                writer.Flush();
                writer.Close();
            }
        }

        private void btnCopyUrlToClipboard_Click(object sender, EventArgs e)
        {
            string url;
            if (!GetAAvailableExtractUrl(out url)) return;
            Clipboard.SetText(url);
            MessageBox.Show(this, "已将采集地址拷贝到剪贴板！", "操作采集地址成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBrowseUrl_Click(object sender, EventArgs e)
        {
            string url;
            if (!GetAAvailableExtractUrl(out url)) return;
            System.Diagnostics.Process.Start(url);
        }

        private void btnViewUrlSource_Click(object sender, EventArgs e)
        {
            string url;
            if (!GetAAvailableExtractUrl(out url)) return;
            SourceGetter sourceGetter = new SourceGetter(url);
            sourceGetter.ShowDialog();
        }

        private void btnFetchUrl_Click(object sender, EventArgs e)
        {
            string url;
            if (!GetAAvailableExtractUrl(out url)) return;
            this.tabSetting.SelectedIndex = 1;
            this.tabSetting.Refresh();
            this.tbxItemUrl.Text = url;
        }

        private void btnDeleteUrl_Click(object sender, EventArgs e)
        {
            if (this.trvUrlTree.Nodes == null || this.trvUrlTree.Nodes.Count == 0
                || this.trvUrlTree.SelectedNode == null)
            {
                MessageBox.Show(this, "没有可用的采集地址！", "操作采集地址错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.trvUrlTree.Nodes.Remove(this.trvUrlTree.SelectedNode);
        }

        private void btnCleanUrl_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,
                "您确定要清空所有的测试采集地址？",
                "清空测试采集地址",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.trvUrlTree.Nodes.Clear();
            }
        }
        private bool GetAAvailableExtractUrl(out string url)
        {
            if (this.trvUrlTree.Nodes == null || this.trvUrlTree.Nodes.Count == 0)
            {
                MessageBox.Show(this, "没有可用的采集地址！", "操作采集地址错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                url = null;
                return false;
            }
            if (this.trvUrlTree.SelectedNode != null)
            {
                url = this.trvUrlTree.SelectedNode.Text;
                return true;
            }
            else
            {
                url = this.trvUrlTree.Nodes[0].Text;
                return true;
            }
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            UpdateItemRule();
            UpdateSiteRule();

            if (string.IsNullOrEmpty(this.tbxItemUrl.Text))
            {
                MessageBox.Show(this, "请输入测试采集地址！", "测试采集设置错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Uri uri;
            if (!Uri.TryCreate(this.tbxItemUrl.Text, UriKind.Absolute, out uri))
            {
                MessageBox.Show(this, "非法测试采集地址！", "测试采集设置错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.loadingDialog = new LoadingDialog();
            //loadingDialog.AddOwnedForm(this);
            loadingDialog.Show();

            var html = HtmlPicker.VisitUrl(
                                     uri,
                                     (string)this.cbbMethod.SelectedItem != "POST" ? "GET" : "POST",
                                     null,
                                      string.IsNullOrEmpty(this.tbxReferer.Text) ? null : this.tbxReferer.Text,
                                     string.IsNullOrEmpty(this.tbxCookie.Text) ? null : Utility.GetCookies(this.tbxCookie.Text),
                                     string.IsNullOrEmpty(this.tbxUserAgent.Text) ? null : this.tbxUserAgent.Text,
                                     string.IsNullOrEmpty(this.tbxPostData.Text) ? null : this.tbxPostData.Text,
                                     System.Text.Encoding.GetEncoding((string)this.cbbEncoding.SelectedItem));
            loadingDialog.Close();
            SetFetchResult(html);
        }

        private void SetFetchResult(string html)
        {
            this.tbxResult.Clear();
            foreach (var itemRule in this.CurrentSiteRule.ItemRules)
            {
                IFetcher fetcher = new FetchItem(itemRule);
                var result = fetcher.Fetch(html);
                this.tbxResult.Text += string.Format("【{0}】: {1}\r\n", itemRule.ItemName, result);
            }
        }

        private void btnCStartTag_Click(object sender, EventArgs e)
        {
            var url = this.tbxItemUrl.Text != "" ? this.tbxItemUrl.Text : "http://www.hefei.cc";
            var source = new SourceGetter(url);
            if (source.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.tbxStartTarget.Text = source.SelectText;
            }
        }

        private void buttonCEndTag_Click(object sender, EventArgs e)
        {
            var url = this.tbxItemUrl.Text != "" ? this.tbxItemUrl.Text : "http://www.hefei.cc";
            var source = new SourceGetter(url);
            if (source.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.tbxEndTarget.Text = source.SelectText;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.txtInterval.Text = "60";
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.txtInterval.Text = "720";
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.txtInterval.Text = (60 * 24).ToString();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.txtInterval.Text = (7 * 24 * 60).ToString();
        }

    }
}
