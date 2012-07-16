using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HFBBS.Model;
using mshtml;
using System.Reflection;
using System.Threading;
using System.IO;

namespace HFBBS
{
    public partial class TaskWizardForm : Form, IWorkingThread
    {
        public SiteRule CurrentSiteRule { get; set; }

        public ItemRule CurrentItemRule { get; set; }

        public TaskWizardForm(SiteRule rule)
        {
            InitializeComponent();
            this.CurrentSiteRule = rule;
            this.InitializeUIItem(rule);
            if (rule.ItemRules.Count > 0)
            {
                this.CurrentItemRule = rule.ItemRules[0];
                if (CurrentItemRule != null)
                {
                    this.InitializeItemRuleDetail(CurrentItemRule);
                }
            }
        }

        #region InitializeUIItem

        private void InitializeUIItem(SiteRule row)
        {
            radionInnerLinks.Checked = row.ListXMLPathType == Model.XMLPathType.InnerLinks;

            //Fill Start Url List.
            this.txtRuleName.Text = row.Name;
            this.txtLinkXPath.Text = row.ListXPath;

            this.chkIntervalTask.Checked = row.EnableAutoRun;
            this.txtInterval.Text = row.AutoRunInterval.ToString();

            //this.tbxFetchStartSymbolic.Text = row.PageStartAt;
            //this.tbxFetchEndSymbolic.Text = row.PageEndAt;

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
            List<string> sourceUrls = new List<string>();
            try
            {
                if (this.lbxUrls.Items.Count > 0)
                {
                    sourceUrls = ExtractUrl.ParseUrlFromParameter(this.lbxUrls.Items[0].ToString());
                    if (sourceUrls.Count > 0)
                    {
                        this.txtStartUrl.Text = sourceUrls[0];
                        this.startUrlWebBrowser.Navigate(sourceUrls[0]);
                    }
                }
            }
            catch
            {
            }
            ////File Encoding ComboBox.
            //if (this.cbbEncoding.Items.Count > 0)
            //    this.cbbEncoding.SelectedIndex = 0; //Empty Value.

            //if (this.cbListEncoding.Items.Count > 0)
            //    this.cbListEncoding.SelectedIndex = 0; //Empty Value.

            //if (row != null)
            //{
            //    for (int i = 0; i < this.cbListEncoding.Items.Count; i++)
            //    {
            //        if (this.cbListEncoding.Items[i].Equals(row.ListEncoding))
            //        {
            //            this.cbListEncoding.SelectedIndex = i;
            //            break;
            //        }
            //    }

            //    for (int i = 0; i < this.cbbEncoding.Items.Count; i++)
            //    {
            //        if (this.cbbEncoding.Items[i].Equals(row.Encoding))
            //        {
            //            this.cbbEncoding.SelectedIndex = i;
            //            break;
            //        }
            //    }
            //}

            ////Fill Method ComboBox.
            //if (this.cbbMethod.Items.Count > 0)
            //    this.cbbMethod.SelectedIndex = 0; //Empty Value.

            //if (row != null)
            //{
            //    for (int i = 0; i < this.cbbMethod.Items.Count; i++)
            //    {
            //        if (this.cbbMethod.Items[i].Equals(row.HttpMethod))
            //        {
            //            this.cbbMethod.SelectedIndex = i;
            //            break;
            //        }
            //    }
            //}

            if (row != null)
            {
                //if (!string.IsNullOrEmpty(row.Referer))
                //    this.tbxReferer.Text = row.Referer;
                //else
                //    this.tbxReferer.Clear();


                ////File Type.
                //if (row.ListPageType == ListPageType.Html)
                //    this.rdbHtml.Checked = true;
                //else
                //    this.rdbRss.Checked = true;

                //if (!this.rdbHtml.Checked && !this.rdbRss.Checked)
                //    this.rdbHtml.Checked = true;

                ////Fill Cookie.

                //this.tbxCookie.Text = row.Cookie;

                ////Fill User Agent.

                //this.tbxUserAgent.Text = row.UserAgent;


                ////Fill Post Data.

                //this.tbxPostData.Text = row.HttpPostData;

                ////Url Include Part.

                //this.tbxUrlInclude.Text = row.IncludePart;

                //this.tbxUrlExclude.Text = row.ExcludePart;

                this.tbxItemUrl.Text = row.ForTestUrl;

            }

        }

        private void InitializeItemRuleDetail(ItemRule row)
        {
            if (row != null)
            {
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

                this.chkIdentifyPage.Checked = row.IdentifyPage;
                this.chkDownloadPic.Checked = row.IsDownloadPic;
                this.txtPageXPath.Text = row.PageXPath;
            }
        }

        private void BindXpathType(XMLPathType type)
        {
            switch (type)
            {
                case XMLPathType.Href:
                    this.radioCHref.Checked = true;
                    break;
                case XMLPathType.InnerLinks:
                    this.radioCInnerLinks.Checked = true;
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

        private string GetDefaultUserAgent()
        {
            object window = startUrlWebBrowser.Document.Window.DomWindow;
            Type wt = window.GetType();
            object navigator = wt.InvokeMember("navigator", BindingFlags.GetProperty,
                null, window, new object[] { });
            Type nt = navigator.GetType();
            object userAgent = nt.InvokeMember("userAgent", BindingFlags.GetProperty,
                null, navigator, new object[] { });
            return userAgent.ToString();
        }

        public void UpdateSiteRule()
        {
            CurrentSiteRule.Name = this.txtRuleName.Text;
            CurrentSiteRule.ListXPath = this.txtLinkXPath.Text;

            CurrentSiteRule.ListXMLPathType = radionInnerLinks.Checked ? XMLPathType.InnerLinks : Model.XMLPathType.Href;
            CurrentSiteRule.ListFetchType = ItemFetchType.XPath;
            CurrentSiteRule.ListXMLPathSelectType = radionInnerLinks.Checked ? Model.XMLPathSelectType.OnlyOne : Model.XMLPathSelectType.Multiple;
            CurrentSiteRule.Encoding = this.contentBrowser.Document.Encoding;
            CurrentSiteRule.HttpMethod = "GET";
            if (string.IsNullOrEmpty(this.txtStartUrl.Text))
                CurrentSiteRule.Referer = null;
            else
                CurrentSiteRule.Referer = this.txtStartUrl.Text;

            CurrentSiteRule.ListPageType = ListPageType.Html;

            if (string.IsNullOrEmpty(this.startUrlWebBrowser.Document.Cookie))
                CurrentSiteRule.Cookie = null;
            else
                CurrentSiteRule.Cookie = this.startUrlWebBrowser.Document.Cookie;

            CurrentSiteRule.UserAgent = GetDefaultUserAgent();


            CurrentSiteRule.ListEncoding = this.startUrlWebBrowser.Document.Encoding;

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

            CurrentSiteRule.EnableAutoRun = this.chkIntervalTask.Checked;
            if (this.txtInterval.Text != "")
            {
                CurrentSiteRule.AutoRunInterval = int.Parse(this.txtInterval.Text);
            }
        }

        public void UpdateItemRule()
        {

            CurrentItemRule.FetchType = ItemFetchType.XPath;
            CurrentItemRule.XPath = this.txtCXpath.Text;

            if (this.radioOne.Checked)
            {
                CurrentItemRule.XMLPathSelectType = XMLPathSelectType.OnlyOne;
            }
            else
            {
                CurrentItemRule.XMLPathSelectType = XMLPathSelectType.Multiple;
            }

            if (this.radioCHref.Checked)
            {
                CurrentItemRule.XMLPathType = XMLPathType.Href;
            }
            else if (this.radioHtml.Checked)
            {
                CurrentItemRule.XMLPathType = XMLPathType.InnerHtml;
            }
            else if (this.radioCInnerLinks.Checked)
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
            CurrentItemRule.IdentifyPage = this.chkIdentifyPage.Checked;
            CurrentItemRule.PageXPath = this.txtPageXPath.Text;
            CurrentItemRule.IsDownloadPic = chkDownloadPic.Checked;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            URLBuilder urlBuilder = new URLBuilder();
            if (urlBuilder.ShowDialog() == DialogResult.OK)
            {
                this.lbxUrls.Items.AddRange(urlBuilder.FinishedUrls);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.enableNavigate = false;
            this.EnableSelect = true;
            this.XMLPathType = radionInnerLinks.Checked ? XMLPathType.InnerLinks : XMLPathType.Href;
            this.XMLPathSelectType = radionInnerLinks.Checked ? Model.XMLPathSelectType.OnlyOne : Model.XMLPathSelectType.Multiple;
            this.CurrentXPathSelected = (xpath) =>
            {
                TestContentPageExtract();
            };
        }

        private void TestContentPageExtract()
        {
            var Datas = ExtractDataFromHtml();
            StringBuilder sb = new StringBuilder();
            var index = 1;
            foreach (var r in Datas)
            {
                sb.AppendFormat("【第{0}条结果】:{1}\r\n", index++, r);
            }
            var txt = sb.ToString();
            if (txt == "")
            {
                txt = "没有匹配结果";
            }
            this.txtUrlResult.Text = txt;
        }

        private void stepItemRule_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteUrl_Click(object sender, EventArgs e)
        {

        }

        int itemRuleIndex = 0;
        LoadingDialog loadingDialog;
        private void taskWizard_NextButtonClick(WizardBase.WizardControl sender, WizardBase.WizardNextButtonClickEventArgs args)
        {
            if (sender.CurrentStepIndex == 0)
            {

            }
            else if (sender.CurrentStepIndex == 1)
            {
                if (this.txtRuleName.Text == "")
                {
                    MessageBox.Show("请填写任务名称");
                    args.Cancel = true;
                }
                this.currenActiveBrowser = startUrlWebBrowser;
                this.currentActiveLogLabel = lblStartUrlLoger;
                this.currentTxtbox = txtStartUrlXPath;
                this.XMLPathSelectType = Model.XMLPathSelectType.Multiple;
                this.XMLPathType = Model.XMLPathType.Href;
            }
            else if (sender.CurrentStepIndex == 2)
            {
                if (this.txtStartUrl.Text == "")
                {
                    MessageBox.Show("请填写起始网址！");
                    args.Cancel = true;
                }
                this.enableNavigate = true;
                this.EnableSelect = false;
                this.currenActiveBrowser = contentBrowser;
                this.currentActiveLogLabel = lblContentTips;
                this.currentTxtbox = txtLinkXPath;
                this.XMLPathSelectType = Model.XMLPathSelectType.Multiple;
                this.XMLPathType = Model.XMLPathType.Href;
                this.contentBrowser.Navigate(this.txtStartUrl.Text);
            }
            else if (sender.CurrentStepIndex == 3)
            {
                UpdateSiteRule();
                List<Uri> urls = new List<Uri>();
                foreach (string sourceUrl in lbxUrls.Items)
                {
                    List<string> sourceUrls = new List<string>();
                    try
                    {
                        sourceUrls = ExtractUrl.ParseUrlFromParameter(sourceUrl);
                    }
                    catch
                    {
                        MessageBox.Show(this, "测试采集网址的格式非法！", "测试采集网址错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        args.Cancel = true;
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
                    args.Cancel = true;
                }

                itemRuleIndex = 0;

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
                                if (this.tbxItemUrl.Text == "")
                                {
                                    this.tbxItemUrl.Text = forTestUrl;
                                }

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
                        i++;

                        loadingDialog.BeginInvoke(new MethodInvoker(delegate()
                        {
                            loadingDialog.Refresh();
                            loadingDialog.Percentage = 100 * i / urls.Count;
                        }));
                    }
                });
                this.workingThread.Start();
            }
            else if (sender.CurrentStepIndex == 4)
            {
                this.itemWebBrowser.Navigate(this.tbxItemUrl.Text);
                this.enableNavigate = true;
                this.EnableSelect = false;
                this.currenActiveBrowser = itemWebBrowser;
                this.currentActiveLogLabel = lblItemLog;
                this.currentTxtbox = txtCXpath;
                this.CurrentItemRule = this.CurrentSiteRule.ItemRules[0];
                this.XMLPathSelectType = this.CurrentItemRule.XMLPathSelectType;
                this.XMLPathType = this.CurrentItemRule.XMLPathType;
            }
            else if (sender.CurrentStepIndex == 5)
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
                                         "GET",
                                         null,
                                          CurrentSiteRule.Referer,
                                          Utility.GetCookies(CurrentSiteRule.Cookie),
                                         CurrentSiteRule.UserAgent,
                                         "",
                                        Encoding.GetEncoding(CurrentSiteRule.Encoding));
                loadingDialog.Close();
                SetFetchResult(html);
            }
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

        string forTestUrl = "";

        private void SetExtractUrl(
            SiteRule item,
            string html, string sourceUrl,
            string encoding)
        {

            TreeNode parentNode = new TreeNode(sourceUrl);
            List<string> urls;
            urls = ExtractUrl.ExtractAccurateUrl(CurrentSiteRule, html, sourceUrl);

            foreach (string url in urls)
            {
                parentNode.Nodes.Add(url);
                if (forTestUrl == "")
                {
                    forTestUrl = url;
                }
            }
            this.trvUrlTree.BeginInvoke(new MethodInvoker(delegate()
            {
                this.trvUrlTree.Nodes.Add(parentNode);
            }));
        }
        private void taskWizard_BackButtonClick(WizardBase.WizardControl sender, WizardBase.WizardClickEventArgs args)
        {

        }

        private void taskWizard_CancelButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void taskWizard_FinishButtonClick(object sender, EventArgs e)
        {
            UpdateSiteRule();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region browser



        XMLPathType XMLPathType;
        XMLPathSelectType XMLPathSelectType;
        bool EnableSelect;
        TextBox currentTxtbox;
        int SelectedCount = 0;
        string firstXpath = "";
        string secondXpath = "";
        bool enableNavigate = true;
        WebBrowser currenActiveBrowser;

        Label currentActiveLogLabel;

        public bool IsElement(string tagName, ref HtmlElement element)
        {
            for (; element != null; element = element.Parent)
            {
                if (element.TagName == tagName)
                {
                    return true;
                }

                if (element.TagName.ToLower() == "body")
                {
                    break;
                }
            }
            return false;
        }

        void Body_MouseOver(object sender, HtmlElementEventArgs e)
        {
            if (EnableSelect)
            {
                e.BubbleEvent = false;
                var element = e.ToElement;
                if (this.XMLPathType == XMLPathType.Href)
                {
                    if (!IsElement("A", ref element))
                    {
                        return;
                    }
                }
                Console.WriteLine(e.ToElement.ClientRectangle);
                if (current != null)
                {
                    current.Style = current.Style.Replace("BACKGROUND-COLOR: #9fc4e7", "");
                }
                current = element;
                Console.WriteLine(e.ToElement.ClientRectangle);
                current.Style += "background-color:#9FC4E7;";

                //this.currentTxtbox.Text = GetXmlPath(current);
            }
        }

        HtmlElement current;


        string GetCleanXpathName(string path)
        {
            var index = path.IndexOf("[");
            if (index != -1)
            {
                path = path.Substring(0, index);
            }
            return path;
        }

        public string GetCommonXpath(string path1, string path2)
        {
            if (path1 == path2)
            {
                return string.Empty;
            }
            var paths1 = path1.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            var paths2 = path2.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);


            if (paths1.Length != paths2.Length)
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("/");
            for (var i = 0; i < paths1.Length; i++)
            {
                if (paths1[i] != paths2[i])
                {
                    sb.Append("//");
                    sb.Append(GetCleanXpathName(paths1[i]));

                    for (i = i + 1; i < paths1.Length; i++)
                    {
                        if (paths1[i] != paths2[i])
                        {
                            return string.Empty;
                        }
                        else
                        {
                            sb.Append("/");
                            sb.Append(paths1[i]);
                        }
                    }
                }
                else
                {
                    sb.Append("/");
                    sb.Append(paths1[i]);

                }
            }

            return sb.ToString();
        }

        public string GetXmlPath(HtmlElement element)
        {
            //IHTMLDocument2 htmlDocument = this.iReaperWebBrowser.Document.DomDocument as mshtml.IHTMLDocument2;
            var name = element.TagName.ToLower();
            //IHTMLElement el = element as IHTMLElement;
            IHTMLDocument2 htmlDocument = currenActiveBrowser.Document.DomDocument as IHTMLDocument2;

            IHTMLSelectionObject currentSelection = htmlDocument.selection;

            Console.WriteLine(currentSelection.type);

            if (element.Id != null)
            {
                name += "[@id=\"" + element.Id + "\"]";
                return "//" + name;
            }

            var path = "";
            for (; element != null; element = element.Parent)
            {
                var index = 1;

                if (element.TagName.ToLower() == "body")
                {
                    break;
                }

                if (element.Parent != null)
                {
                    var children = element.Parent.Children;
                    foreach (HtmlElement c in children)
                    {
                        if (c.TagName != element.TagName)
                        {
                            continue;
                        }
                        if (c.InnerHtml == element.InnerHtml)
                        {
                            break;
                        }
                        index++;
                    }

                }
                var xname = element.TagName.ToLower();
                if (element.Id != null)
                {
                    xname += "[@id=\"" + element.Id + "\"]";
                    path = "/" + xname + path;
                    break;
                }
                else
                {
                    if (index > 0)
                        xname += "[" + index + "]";
                }
                path = "/" + xname + path;
            }
            path = "/" + path;
            // path = path.Replace("html[1]/body[1]", "html/body");

            return path;
        }

        void Document_Click(object sender, HtmlElementEventArgs e)
        {
            if (EnableSelect)
            {
                var newPath = GetXmlPath(current);

                if (newPath == this.currentTxtbox.Text)
                {
                    return;
                }

                this.currentTxtbox.Text = newPath;

                //if (XPathDic.ContainsKey(this.txtxmlpath.Text))
                //{
                //    this.treeXPath.SelectedNode = XPathDic[this.txtxmlpath.Text];
                //}

                if (this.XMLPathSelectType == XMLPathSelectType.Multiple)
                {
                    SelectedCount++;
                    if (SelectedCount == 1)
                    {
                        this.currentActiveLogLabel.Text = "你已经选择一次，请再选择和第一次选择同级的节点";
                        firstXpath = this.currentTxtbox.Text;
                    }
                    else
                    {

                        SelectedCount = 0;
                        secondXpath = this.currentTxtbox.Text;

                        var commonPath = this.GetCommonXpath(firstXpath, secondXpath);
                        if (!string.IsNullOrEmpty(commonPath))
                        {
                            this.currentActiveLogLabel.Text = "你已经选择两次，请测试是否正确";
                            this.currentTxtbox.Text = commonPath;
                        }
                        else
                        {
                            this.currentActiveLogLabel.Text = "选择失败，必须选择同一级别的元素,不能是同一元素";
                        }
                        EnableSelect = false;
                        if (CurrentXPathSelected != null)
                        {
                            CurrentXPathSelected(currentTxtbox.Text);
                        }
                    }
                }
                else
                {
                    EnableSelect = false;
                    if (CurrentXPathSelected != null)
                    {
                        CurrentXPathSelected(currentTxtbox.Text);
                    }
                }

            }
        }

        void Browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            e.Cancel = !enableNavigate;
        }

        void Browser_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = !enableNavigate;
        }

        private void TaskWizardForm_Load(object sender, EventArgs e)
        {
            BindBrowseEvent(startUrlWebBrowser);
            BindBrowseEvent(contentBrowser);
            BindBrowseEvent(itemWebBrowser);
        }

        private void BindBrowseEvent(WebBrowser browser)
        {
            browser.NewWindow += new CancelEventHandler(Browser_NewWindow);
            browser.Navigating += new WebBrowserNavigatingEventHandler(Browser_Navigating);
            browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);
        }

        void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //if (currenActiveBrowser.ReadyState != WebBrowserReadyState.Complete)
            //    return;

            if (e.Url == currenActiveBrowser.Url)
            {
                OnBrowserLoaded();
            }
        }

        void OnBrowserLoaded()
        {
            currenActiveBrowser.Document.Body.MouseOver += new HtmlElementEventHandler(Body_MouseOver);
            currenActiveBrowser.Document.Click += new HtmlElementEventHandler(Document_Click);
        }

        delegate void XPathSelected(string xpath);

        XPathSelected CurrentXPathSelected;

        public List<string> ExtractDataFromHtml()
        {

            var result = ExtractUrl.ExtractDataFromHtml(this.currenActiveBrowser.Document.Body.OuterHtml, this.currentTxtbox.Text, XMLPathSelectType, XMLPathType);

            var pathType = this.XMLPathType;
            var xpath = this.currentTxtbox.Text;
            switch (pathType)
            {
                case XMLPathType.Href:
                case XMLPathType.InnerLinks:
                    for (var i = 0; i < result.Count; i++)
                    {
                        result[i] = RepairUrl(this.currenActiveBrowser.Url.AbsoluteUri, result[i]);
                    }
                    break;
            }
            return result;
        }

        public static string RepairUrl(string baseUrl, string originalUrl)
        {
            try
            {
                Uri originalUri;
                Uri baseUri = new Uri(baseUrl);
                Uri resultUri;

                if (Uri.TryCreate(baseUri, originalUrl, out resultUri))
                {
                    return resultUri.OriginalString;
                }

                if (Uri.TryCreate(originalUrl, UriKind.RelativeOrAbsolute, out originalUri))
                {
                    if (originalUri.Scheme != "about")
                    {
                        return originalUrl;
                    }
                }



                string ieBlank = "about:blank";
                string threeSplit = "///";

                if (originalUrl.StartsWith(ieBlank))
                {
                    originalUrl = originalUrl.Remove(0, ieBlank.Length);
                }
                if (originalUrl.IndexOf(threeSplit) > -1)
                {
                    originalUrl = originalUrl.Remove(0, originalUrl.IndexOf(threeSplit) + 2);
                }

                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtStartUrl.Text != "")
            {
                if (!this.txtStartUrl.Text.Contains("http://"))
                {
                    this.txtStartUrl.Text = "http://" + this.txtStartUrl.Text;
                }
                var temp = this.enableNavigate;
                this.enableNavigate = true;
                this.startUrlWebBrowser.Navigate(this.txtStartUrl.Text);
                this.enableNavigate = temp;

            }
        }

        private void btnSelectStartUrl_Click(object sender, EventArgs e)
        {
            this.enableNavigate = false;
            this.EnableSelect = true;
            this.XMLPathType = radioInnerLinks.Checked ? XMLPathType.InnerLinks : XMLPathType.Href;
            this.XMLPathSelectType = radioInnerLinks.Checked ? Model.XMLPathSelectType.OnlyOne : Model.XMLPathSelectType.Multiple;
            this.CurrentXPathSelected = (xpath) =>
            {
                if (!this.lbxUrls.Items.Contains(this.txtStartUrl.Text))
                {
                    this.lbxUrls.Items.Add(this.txtStartUrl.Text);
                }
                var urls = ExtractDataFromHtml();
                foreach (var url in urls)
                {
                    if (!this.lbxUrls.Items.Contains(url))
                    {
                        this.lbxUrls.Items.Add(url);
                    }
                }
            };
        }

        private void tabTitle_SelectedIndexChanged(object sender, EventArgs e)
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

        #region IWorkingThread 成员

        public System.Threading.Thread workingThread
        {
            get;
            set;
        }

        #endregion

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

        private void 浏览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lbxUrls.SelectedItem != null)
            {

                List<string> sourceUrls = new List<string>();
                try
                {
                    sourceUrls = ExtractUrl.ParseUrlFromParameter(this.lbxUrls.SelectedItem.ToString());
                    this.startUrlWebBrowser.Navigate(sourceUrls[0]);
                }
                catch
                {
                }
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

        private void startUrlmenu_Opening(object sender, CancelEventArgs e)
        {

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

        private void btnFetchUrl_Click(object sender, EventArgs e)
        {
            string url;
            if (!GetAAvailableExtractUrl(out url)) return;
            this.tbxItemUrl.Text = url;
            this.itemWebBrowser.Navigate(this.tbxItemUrl.Text);
            this.enableNavigate = true;
            this.EnableSelect = false;
            this.currenActiveBrowser = itemWebBrowser;
            this.currentActiveLogLabel = lblItemLog;
            this.currentTxtbox = txtCXpath;
            this.CurrentItemRule = this.CurrentSiteRule.ItemRules[0];
            this.XMLPathSelectType = this.CurrentItemRule.XMLPathSelectType;
            this.XMLPathType = this.CurrentItemRule.XMLPathType;
            this.taskWizard.CurrentStepIndex = 5;

        }

        private void btnCXPath_Click(object sender, EventArgs e)
        {
            this.EnableSelect = true;
            this.currentTxtbox = this.txtCXpath;
            this.currentActiveLogLabel = this.lblItemContentLog;
            UpdateItemRule();
            this.XMLPathSelectType = CurrentItemRule.XMLPathSelectType;
            this.XMLPathType = CurrentItemRule.XMLPathType;
            this.lblItemContentLog.Text = "请用鼠标选择，通过鼠标移动切换，左键点击选定";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.EnableSelect = true;
            this.currentTxtbox = this.txtPageXPath;
            this.XMLPathSelectType = Model.XMLPathSelectType.OnlyOne;
            this.XMLPathType = Model.XMLPathType.InnerLinks;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TestContentPageExtract();
        }

        private void tbxResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.taskWizard.CurrentStepIndex--;
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

        private void txtInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            //全角占一个汉字,半角点半个汉字,所以在字节上是不同的
            //全角数字"KeyChar"=2,半解数字"KeyChar"=1
            byte[] array = System.Text.Encoding.Default.GetBytes(e.KeyChar.ToString());
            //array.LongLength,而不是array.Length
            if (!char.IsDigit(e.KeyChar) || array.LongLength == 2) e.Handled = true;
            //'\b'是退格键值
            if (e.KeyChar == '\b' || e.KeyChar == '.') e.Handled = false;
        }
       
    }
}
