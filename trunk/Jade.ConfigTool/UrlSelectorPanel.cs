using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Jade.Model;

namespace Jade.ConfigTool
{
    public partial class UrlSelectorPanel : DevExpress.XtraEditors.XtraUserControl
    {
        UrlSelector currentUrlSelector;
        XPath currentXPath;

        /// <summary>
        /// 选择XPATH
        /// </summary>
        public event EventHandler OnXpathSelectorClick;

        /// <summary>
        /// 测试XPATH
        /// </summary>
        public event EventHandler OnTestClick;

        /// <summary>
        /// 选择URL
        /// </summary>
        public event EventHandler OnSelectUrlClick;

        /// <summary>
        /// 选择URL完毕
        /// </summary>
        /// <param name="url"></param>
        public void SelectUrlClickFinish(string url)
        {
            //string[] urls = new string[this.lbxUrls.Items.Count];
            //this.lbxUrls.Items.CopyTo(urls, 0);
            //var list = new List<string>();
            //list.AddRange(urls);
            //if (!list.Contains(url))
            if (!lbxUrls.Items.Contains(url))
            {
                this.lbxUrls.Items.Add(url);
            }
        }

        public UrlSelector CurrentUrlSelector
        {
            get
            {
                UpdateUrlSelector();
                return currentUrlSelector;
            }
            set
            {
                currentUrlSelector = value;
                Init();
            }
        }

        public void UpdateUrlSelector()
        {
            this.btnAdd_Click(null, null);
            if (currentUrlSelector != null)
            {
                currentUrlSelector.IncludePart = this.tbxUrlInclude.Text;
                currentUrlSelector.ExcludePart = this.tbxUrlExclude.Text;
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
                    currentUrlSelector.DiyContentPageUrl = tempUrl;
                }
            }
        }

        void Init()
        {
            if (currentUrlSelector != null)
            {
                this.xpathesBox.DisplayMember = "XPathString";
                this.xpathesBox.Items.Clear();
                this.xpathesBox.DataSource = currentUrlSelector.XPathList;
                if (currentUrlSelector.XPathList.Count > 0)
                {
                    var xpath = currentUrlSelector.XPathList[0];
                    BindXPath(xpath);
                }

                this.tbxUrlInclude.Text = currentUrlSelector.IncludePart;
                this.tbxUrlExclude.Text = currentUrlSelector.ExcludePart;
                this.lbxUrls.Items.Clear();
                if (!string.IsNullOrEmpty(currentUrlSelector.DiyContentPageUrl))
                {
                    string[] urls = currentUrlSelector.DiyContentPageUrl.Split(new string[] { BaseConfig.UrlSeparator }, StringSplitOptions.RemoveEmptyEntries);
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
        }

        public UrlSelectorPanel()
        {
            InitializeComponent();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (OnXpathSelectorClick != null)
            {
                OnXpathSelectorClick(sender, e);
            }
        }

        /// <summary>
        /// 设置结果
        /// </summary>
        /// <param name="datas"></param>
        public void SetUrlResult(List<string> datas)
        {
            StringBuilder sb = new StringBuilder();
            var index = 1;
            foreach (var r in datas)
            {
                if (!r.Contains("javascript:"))
                    sb.AppendFormat("【第{0}条结果】:{1}\r\n", index++, r);
            }
            var txt = sb.ToString();
            if (txt == "")
            {
                txt = "没有匹配结果";
            }
            this.txtUrlResult.Text = txt;
            this.xtraTabControl1.SelectedTabPageIndex = 2;
        }

        /// <summary>
        /// 设置XPath
        /// </summary>
        /// <param name="xpath"></param>
        public void SetXPath(string xpath)
        {
            this.txtXPath.Text = xpath;
            // this.btnAdd_Click(null, null);
        }

        private void linkUrlSeniorSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new UrlSettingForm(this.CurrentUrlSelector).ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (OnTestClick != null)
            {
                OnTestClick(sender, e);
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.xtraTabControl1.SelectedTabPageIndex == 0)
            {
                if (this.xpathesBox.SelectedItem != null)
                {
                    this.xpathesBox.Items.Remove(this.xpathesBox.SelectedItem);
                    var xpath = this.xpathesBox.SelectedItem as XPath;
                    if (xpath != null)
                        this.currentUrlSelector.XPathList.Remove(xpath);
                }
            }
            else
            {
                if (this.lbxUrls.SelectedItem != null)
                {
                    this.lbxUrls.Items.Remove(this.lbxUrls.SelectedItem);
                }
            }
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.xtraTabControl1.SelectedTabPageIndex == 0)
            {
                if (MessageBox.Show(this,
                    "您确定要清空XPATH？",
                    "清空XPATH",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.xpathesBox.Items.Clear();
                }
            }
            else
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
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.xtraTabControl1.SelectedTabPageIndex == 0)
            {
                var xpath = this.xpathesBox.SelectedItem as XPath;
                if (xpath != null)
                {
                    BindXPath(xpath);
                }

            }
            else
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
        }

        private void BindXPath(XPath xpath)
        {
            if (xpath != null)
            {
                this.txtXPath.Text = xpath.XPathString;
                if (xpath.XMLPathType == XMLPathType.Href)
                {
                    this.radioHref.Checked = true;
                }
                else
                {
                    this.radionInnerLinks.Checked = true;
                }

                if (xpath.XMLPathSelectType == XMLPathSelectType.Multiple)
                {
                    this.radioMulti.Checked = true;
                }
                else
                {
                    this.radioOne.Checked = true;
                }
            }
        }

        /// <summary>
        /// 当前XMLPathType
        /// </summary>
        public XMLPathType CurrentXMLPathType
        {
            get
            {
                return radioHref.Checked ? XMLPathType.Href : XMLPathType.InnerLinks;
            }
        }

        /// <summary>
        /// 当前XMLPathSelectType
        /// </summary>
        public XMLPathSelectType CurrentXMLPathSelectType
        {
            get
            {
                return radioMulti.Checked ? XMLPathSelectType.Multiple : XMLPathSelectType.OnlyOne;
            }
        }

        public void SetTipMessage(string msg)
        {
            lblContentTips.Text = msg;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (currentUrlSelector != null)
            {
                var xpath = currentUrlSelector.XPathList.Find(x => x.XPathString == this.txtXPath.Text);
                if (xpath == null)
                {
                    xpath = new XPath();
                    currentUrlSelector.XPathList.Add(xpath);
                }
                xpath.XPathString = this.txtXPath.Text;
                xpath.XMLPathType = this.CurrentXMLPathType;
                xpath.XMLPathSelectType = this.CurrentXMLPathSelectType;
                currentXPath = xpath;
            }
        }

        private void radionInnerLinks_CheckedChanged(object sender, EventArgs e)
        {
            if (currentXPath != null)
            {
                currentXPath.XPathString = this.txtXPath.Text;
                currentXPath.XMLPathType = this.CurrentXMLPathType;
            }
        }

        public string Xpath
        {
            get
            {
                return this.txtXPath.Text;
            }
        }

        private void btnUrlBuilder_Click(object sender, EventArgs e)
        {
            URLBuilder urlBuilder = new URLBuilder();
            if (urlBuilder.ShowDialog() == DialogResult.OK)
            {
                this.lbxUrls.Items.AddRange(urlBuilder.FinishedUrls);
            }
        }

        private void btnAddUrlBySelect_Click(object sender, EventArgs e)
        {
            if (this.OnSelectUrlClick != null)
            {
                OnSelectUrlClick(sender, e);
            }
        }
    }
}
