using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using Jade.Model;
using mshtml;
using System.Reflection;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using Jade.ConfigTool;

namespace Jade
{
    public partial class SiteRuleWizardForm : DevExpress.XtraEditors.XtraForm, IWorkingThread
    {

        public SiteRule CurrentSiteRule { get; set; }

        public ItemRule CurrentItemRule { get; set; }


        public SiteRuleWizardForm(SiteRule rule)
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
            if (row.SiteExractMode == SiteExractMode.ListContent)
            {
                this.radioButtonListPage.Checked = true;
            }
            else if (row.SiteExractMode == SiteExractMode.HomeListContent)
            {
                this.radioButtonAllSite.Checked = true;
            }
            else
            {
                this.radioButtonAllSite2.Checked = true;
            }

            //radionInnerLinks.Checked = row.ListXMLPathType == Model.XMLPathType.InnerLinks;
            radioButtonNotWithSameDomain.Checked = !row.WithSameDomain;
            radioButtonWithSameDomain.Checked = row.WithSameDomain;
            this.txtHomePage.Text = row.IndexPage;
            this.txtStartUrl.Text = row.Referer;
            //Fill Start Url List.
            this.txtRuleName.Text = row.Name;
            //this.txtLinkXPath.Text = row.ListXPath;
            this.chkIntervalTask.Checked = row.EnableAutoRun;
            this.txtInterval.Text = row.AutoRunInterval.ToString();

            this.homePageUrlSelectorMarker.CurrentUrlSelector = row.ColumnUrlSelector;
            this.columnPageUrlSelectorMarker.CurrentUrlSelector = row.LisPageUrlSelector;
            this.listPageUrlSelectorMarker.CurrentUrlSelector = row.ListPagePagerUrlSelector;
            this.contentUrlSelectorMarker.CurrentUrlSelector = row.ContentUrlSelector;
            //this.tbxFetchStartSymbolic.Text = row.PageStartAt;
            //this.tbxFetchEndSymbolic.Text = row.PageEndAt;
            //this.lbxUrls.Items.Clear();
            //if (row != null)
            //{
            //    if (!string.IsNullOrEmpty(row.StartUrl))
            //    {
            //        string[] urls = row.StartUrl.Split(new string[] { BaseConfig.UrlSeparator }, StringSplitOptions.RemoveEmptyEntries);
            //        if (urls != null && urls.Length > 0)
            //        {
            //            foreach (string url in urls)
            //            {
            //                this.lbxUrls.Items.Add(url);
            //            }
            //            this.lbxUrls.SelectedIndex = 0;
            //        }
            //    }
            //}
            List<string> sourceUrls = new List<string>();
            //try
            //{
            //    if (this.lbxUrls.Items.Count > 0)
            //    {
            //        sourceUrls = ExtractUrl.ParseUrlFromParameter(this.lbxUrls.Items[0].ToString());
            //        if (sourceUrls.Count > 0)
            //        {
            //            this.txtStartUrl.Text = sourceUrls[0];
            //            this.isBindCompleted = false;
            //        }
            //    }
            //}
            //catch
            //{
            //}
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

                this.txtTestUrl.Text = row.ForTestUrl;

            }

        }

        private void InitializeItemRuleDetail(ItemRule row)
        {
            if (row != null)
            {
                this.txtReplace.Text = CurrentItemRule.ReplaceString;

                this.txtAnotherXPath.Text = CurrentItemRule.AnotherXPath;

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
            if (this.radioButtonListPage.Checked)
            {
                CurrentSiteRule.SiteExractMode = SiteExractMode.ListContent;
            }
            else if (this.radioButtonAllSite.Checked)
            {
                CurrentSiteRule.SiteExractMode = SiteExractMode.HomeListContent;
            }
            else
            {
                CurrentSiteRule.SiteExractMode = SiteExractMode.HomeColumnListContent;
            }

            this.homePageUrlSelectorMarker.UpdateUrlSelector();
            this.columnPageUrlSelectorMarker.UpdateUrlSelector();
            this.listPageUrlSelectorMarker.UpdateUrlSelector();
            this.contentUrlSelectorMarker.UpdateUrlSelector();

            CurrentSiteRule.WithSameDomain = this.radioButtonWithSameDomain.Checked;
            CurrentSiteRule.Name = this.txtRuleName.Text;
            CurrentSiteRule.IndexPage = this.txtHomePage.Text;

            //CurrentSiteRule.ListXMLPathType = radionInnerLinks.Checked ? XMLPathType.InnerLinks : Model.XMLPathType.Href;
            //CurrentSiteRule.ListFetchType = ItemFetchType.XPath;
            //CurrentSiteRule.ListXMLPathSelectType = radionInnerLinks.Checked ? Model.XMLPathSelectType.OnlyOne : Model.XMLPathSelectType.Multiple;
            CurrentSiteRule.HttpMethod = "GET";
            if (string.IsNullOrEmpty(this.txtStartUrl.Text))
                CurrentSiteRule.Referer = null;
            else
                CurrentSiteRule.Referer = this.txtStartUrl.Text;

            CurrentSiteRule.ListPageType = ListPageType.Html;
            if (this.startUrlWebBrowser.Document != null)
            {
                if (string.IsNullOrEmpty(this.startUrlWebBrowser.Document.Cookie))
                    CurrentSiteRule.Cookie = null;
                else
                    CurrentSiteRule.Cookie = this.startUrlWebBrowser.Document.Cookie;

                CurrentSiteRule.ListEncoding = this.startUrlWebBrowser.Document.Encoding;
                if (contentBrowser.Document != null)
                {
                    CurrentSiteRule.Encoding = this.contentBrowser.Document.Encoding;
                }
                CurrentSiteRule.UserAgent = GetDefaultUserAgent();
            }

            //if (this.lbxUrls.Items != null || this.lbxUrls.Items.Count > 0)
            //{
            //    string tempUrl = string.Empty;
            //    foreach (string url in this.lbxUrls.Items)
            //    {
            //        if (tempUrl != string.Empty)
            //        {
            //            tempUrl += BaseConfig.UrlSeparator;
            //        }
            //        tempUrl += url;
            //    }
            //    CurrentSiteRule.StartUrl = tempUrl;
            //}

            CurrentSiteRule.ForTestUrl = this.txtTestUrl.Text;

            CurrentSiteRule.EnableAutoRun = this.chkIntervalTask.Checked;
            if (this.txtInterval.Text != "")
            {
                CurrentSiteRule.AutoRunInterval = int.Parse(this.txtInterval.Text);
            }
        }

        public void UpdateItemRule()
        {
            CurrentItemRule.ReplaceString = this.txtReplace.Text;
            CurrentItemRule.AnotherXPath = this.txtAnotherXPath.Text;

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
                    this.isBindCompleted = false;
                    //this.enableNavigate = temp;
                    e.Handled = true;
                }

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            URLBuilder urlBuilder = new URLBuilder();
            if (urlBuilder.ShowDialog() == DialogResult.OK)
            {
                //this.lbxUrls.Items.AddRange(urlBuilder.FinishedUrls);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            current = null;
            last = null;
            //force bind
            OnBrowserLoaded();
            this.enableNavigate = false;
            this.EnableSelect = true;
            // this.XMLPathType = radionInnerLinks.Checked ? XMLPathType.InnerLinks : XMLPathType.Href;
            //this.XMLPathSelectType = radionInnerLinks.Checked ? Model.XMLPathSelectType.OnlyOne : Model.XMLPathSelectType.Multiple;
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
                if (!r.Contains("javascript:"))
                    sb.AppendFormat("【第{0}条结果】:{1}\r\n", index++, r);
            }
            var txt = sb.ToString();
            if (txt == "")
            {
                txt = "没有匹配结果";
            }
            //this.txtUrlResult.Text = txt;
        }

        private void stepItemRule_Click(object sender, EventArgs e)
        {

        }

        int itemRuleIndex = 0;
        LoadingDialog loadingDialog;

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
            List<string> urls;

            //WebBrowser b = new WebBrowser();
            //b.DocumentText = html;
            //Console.WriteLine(html == b.DocumentText);
            //html = b.DocumentText;
            //b.Dispose();
            //b = null;
            //urls = ExtractUrl.ExtractAccurateUrl(CurrentSiteRule, html, sourceUrl);

            // TreeNode parentNode = new TreeNode(sourceUrl);

            //BindUrlTree(urls, parentNode);
        }

        private void BindUrlTree(List<string> urls, TreeNode parentNode)
        {
            foreach (string url in urls)
            {
                if (!url.Contains("javascript"))
                {
                    parentNode.Nodes.Add(url);
                    if (forTestUrl == "")
                    {
                        forTestUrl = url;
                    }
                }
            }
            this.trvUrlTree.BeginInvoke(new MethodInvoker(delegate()
            {
                this.trvUrlTree.Nodes.Add(parentNode);
            }));
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
        TextEdit currentTxtbox;

        int SelectedCount = 0;
        string firstXpath = "";
        string secondXpath = "";
        bool enableNavigate = true;

        WebBrowser currenActiveBrowser;
        UrlSelectorMarker currentUrlMaker;

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
                    current.Style = current.Style.Replace("BORDER-BOTTOM: #0000cc 1px solid;", "").Replace("BORDER-LEFT: #0000cc 1px solid;", "").Replace("BACKGROUND-COLOR: #9fc4e7;", "").Replace("BORDER-TOP: #0000cc 1px solid;", "").Replace("BORDER-RIGHT: #0000cc 1px solid", "");
                }
                current = element;
                Console.WriteLine(e.ToElement.ClientRectangle);
                current.Style += "background-color:#9FC4E7;border:1px solid #0000CC;";

                //currentUrlMaker.Xpath = GetXmlPath(current);
                currentUrlMaker.SetXPath(GetXmlPath(current));
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
                return path1;
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

        bool isLink = true;

        public string GetXmlPath2(HtmlElement element)
        {
            HtmlAgilityPack.HtmlDocument HtmlDoc = new HtmlAgilityPack.HtmlDocument();
            HtmlDoc.OptionAutoCloseOnEnd = true;
            var html = currenActiveBrowser.DocumentText.ToLower();

            html = html.Replace("<tbody>", "").Replace("</tbody>", "");
            var body = new Regex("<body[^>]*>[\\s\\S]+</body>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            html = body.Match(html).Value;
            // check html
            var checkRegex = new Regex("<body", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var checkResults = checkRegex.Matches(html);
            if (checkResults.Count > 1)
            {
                html = html.Substring(checkResults[checkResults.Count - 1].Index);
            }
            HtmlDoc.LoadHtml(html);
            var nodes = HtmlDoc.DocumentNode.SelectNodes("//" + element.TagName.ToLower());
            var outHtml = element.InnerHtml.ToLower();
            var selected = nodes.FirstOrDefault(n => n.InnerHtml == outHtml);

            if (selected != null)
            {
                return selected.XPath.Replace("/body[1]", "/");
            }
            HtmlDoc = null;
            return GetXmlPath(element);
        }

        public string GetXmlPath(HtmlElement element)
        {
            //IHTMLDocument2 htmlDocument = this.iReaperWebBrowser.Document.DomDocument as mshtml.IHTMLDocument2;
            var name = element.TagName.ToLower();
            //IHTMLElement el = element as IHTMLElement;
            //IHTMLDocument2 htmlDocument = currenActiveBrowser.Document.DomDocument as IHTMLDocument2;

            //IHTMLSelectionObject currentSelection = htmlDocument.selection;

            //Console.WriteLine(currentSelection.type);

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
                    // 采集链接可以用class，亲
                    if (isLink)
                        if (element.GetAttribute("className") != "")
                        {
                            xname += "[@class=\"" + element.GetAttribute("className") + "\"]";
                            path = "/" + xname + path;
                            break;
                        }

                    if (index > 0)
                        xname += "[" + index + "]";
                }
                path = "/" + xname + path;
            }
            path = "/" + path;
            // path = path.Replace("html[1]/body[1]", "html/body");

            return path;
        }

        HtmlElement last;

        string lastXpath = "";

        void Document_Click(object sender, HtmlElementEventArgs e)
        {
            if (EnableSelect)
            {
                //if (current == last)
                //{
                //    return;
                //}

                last = current;

                var newPath = GetXmlPath(current);

                //if (newPath == currentUrlMaker.Xpath)
                //{
                //    return;
                //}
                //if (this.XMLPathSelectType == XMLPathSelectType.Multiple)
                //{
                //    currentUrlMaker.SetXPath(newPath);
                //}
                //if (XPathDic.ContainsKey(this.txtxmlpath.Text))
                //{
                //    this.treeXPath.SelectedNode = XPathDic[this.txtxmlpath.Text];
                //}
                currentUrlMaker.TipMessage = newPath;
                if (this.XMLPathSelectType == XMLPathSelectType.Multiple)
                {
                    SelectedCount++;
                    if (SelectedCount == 1)
                    {
                        firstXpath = newPath;
                        if (this.wizardControl1.SelectedPageIndex != 6)
                        {
                            currentUrlMaker.TipMessage = "你已经选择一次，请再选择和第一次选择同级的节点";
                        }
                        else
                        {
                            currentActiveLogLabel.Text = "你已经选择一次，请再选择和第一次选择同级的节点";
                            currentTxtbox.Text = newPath;
                        }
                    }
                    else
                    {

                        SelectedCount = 0;
                        secondXpath = newPath;
                        var commonPath = this.GetCommonXpath(firstXpath, secondXpath);
                        if (!string.IsNullOrEmpty(commonPath))
                        {
                            if (this.wizardControl1.SelectedPageIndex != 6)
                            {
                                currentUrlMaker.TipMessage = "你已经选择两次，请测试是否正确";
                                currentUrlMaker.Xpath = commonPath;
                            }
                            else
                            {
                                currentActiveLogLabel.Text = "你已经选择两次，请测试是否正确";
                                currentTxtbox.Text = commonPath;
                            }
                        }
                        else
                        {
                            if (this.wizardControl1.SelectedPageIndex != 6)
                            {
                                currentUrlMaker.TipMessage = "选择失败，必须选择同一级别的元素,不能是同一元素";
                            }
                            else
                            {
                                currentActiveLogLabel.Text = "选择失败，必须选择同一级别的元素,不能是同一元素";
                            }

                        }
                        EnableSelect = false;
                        if (CurrentXPathSelected != null)
                        {
                            CurrentXPathSelected(currentUrlMaker.Xpath);
                        }
                        current = null;
                    }
                }
                else
                {
                    EnableSelect = false;

                    if (this.wizardControl1.SelectedPageIndex == 6)
                    {
                        currentTxtbox.Text = newPath;
                    }
                    if (CurrentXPathSelected != null)
                    {
                        CurrentXPathSelected(currentUrlMaker.Xpath);
                    }
                    current = null;
                }

            }
        }

        void Browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (enableNavigate)
            {
                try
                {
                    if (DevExpress.XtraSplashScreen.SplashScreenManager.Default == null)
                        DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(WaitForm1));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
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
            BindBrowseEvent(bwHomePage);
            BindBrowseEvent(bwColumnPage);
        }

        private void BindBrowseEvent(WebBrowser browser)
        {
            browser.NewWindow += new CancelEventHandler(Browser_NewWindow);
            browser.Navigating += new WebBrowserNavigatingEventHandler(Browser_Navigating);
            browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);
        }

        public Uri Url
        {
            get;
            set;
        }

        bool isBindCompleted = false;

        void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (currenActiveBrowser.ReadyState >= WebBrowserReadyState.Interactive)
            {
                //if (!isBindCompleted)
                //{
                isBindCompleted = true;
                OnBrowserLoaded();
                enableNavigate = false;
                //}

                //if (e.Url == Url)
                //{

                //}
            }
            if (e.Url == Url)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();

                //this.currenActiveBrowser.DocumentText = ExtractUrl.SgmlTranslate(this.currenActiveBrowser.DocumentText);
            }

        }

        void OnBrowserLoaded()
        {
            if (currenActiveBrowser.Document != null)
            {
                currenActiveBrowser.Document.Body.MouseOver -= new HtmlElementEventHandler(Body_MouseOver);
                currenActiveBrowser.Document.Click -= new HtmlElementEventHandler(Document_Click);
                currenActiveBrowser.Document.Body.MouseOver += new HtmlElementEventHandler(Body_MouseOver);
                currenActiveBrowser.Document.Click += new HtmlElementEventHandler(Document_Click);
            }
        }

        delegate void XPathSelected(string xpath);

        XPathSelected CurrentXPathSelected;

        public List<string> ExtractDataFromHtml()
        {

            var result = ExtractUrl.ExtractDataFromHtml(this.currenActiveBrowser.DocumentText, currentUrlMaker.Xpath, XMLPathSelectType, XMLPathType);


            var domain = this.txtHomePage.Text != "" ? new Uri(this.txtHomePage.Text).Host : new Uri(this.txtStartUrl.Text).Host;

            var newResult = new List<string>();

            var pathType = this.XMLPathType;
            var xpath = currentUrlMaker.Xpath;
            switch (pathType)
            {
                case XMLPathType.Href:
                case XMLPathType.InnerLinks:
                    for (var i = 0; i < result.Count; i++)
                    {
                        var url = RepairUrl(this.currenActiveBrowser.Url.AbsoluteUri, result[i]);

                        if (radioButtonNotWithSameDomain.Checked || url.Contains(domain))
                        {
                            newResult.Add(url);
                        }
                    }
                    break;
            }
            return newResult;
        }

        public static string RepairUrl(string baseUrl, string originalUrl)
        {
            try
            {
                if (originalUrl.StartsWith("javas"))
                {
                    return string.Empty; ;
                }

                originalUrl = originalUrl.Replace("&amp;", "&");

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
                this.enableNavigate = true;
                this.startUrlWebBrowser.Navigate(this.txtStartUrl.Text);
                this.isBindCompleted = false;
            }
        }



        #region IWorkingThread 成员

        public System.Threading.Thread workingThread
        {
            get;
            set;
        }

        #endregion





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
            this.txtTestUrl.Text = url;
            this.itemWebBrowser.Navigate(this.txtTestUrl.Text);
            this.isBindCompleted = false;
            this.enableNavigate = true;
            this.EnableSelect = false;
            this.currenActiveBrowser = itemWebBrowser;
            this.currentActiveLogLabel = lblItemLog;
            this.currentTxtbox = txtCXpath;
            this.CurrentItemRule = this.CurrentSiteRule.ItemRules[0];
            this.XMLPathSelectType = this.CurrentItemRule.XMLPathSelectType;
            this.XMLPathType = this.CurrentItemRule.XMLPathType;
            this.wizardControl1.SelectedPage = contentDetailPage;
        }

        private void btnCXPath_Click(object sender, EventArgs e)
        {
            current = null;
            last = null;
            //force bind
            OnBrowserLoaded();
            this.EnableSelect = true;
            this.currentTxtbox = this.txtCXpath;
            this.currentActiveLogLabel = this.lblItemContentLog;
            UpdateItemRule();
            this.XMLPathSelectType = CurrentItemRule.XMLPathSelectType;
            this.XMLPathType = CurrentItemRule.XMLPathType;
            currentUrlMaker.TipMessage = "请用鼠标选择，通过鼠标移动切换，左键点击选定";
        }


        private void button4_Click(object sender, EventArgs e)
        {
            TestContentPageExtract();
        }

        private void tbxResult_TextChanged(object sender, EventArgs e)
        {

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


        private void wizardControl1_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            if (e.Page == this.welcomeWizardPage1)
            {
                if (this.txtRuleName.Text == "")
                {
                    MessageBox.Show("请填写任务名称");
                    e.Handled = true;
                    return;
                }

                if (this.radioButtonListPage.Checked)
                {
                    this.currenActiveBrowser = startUrlWebBrowser;
                    this.XMLPathSelectType = Model.XMLPathSelectType.Multiple;
                    this.XMLPathType = Model.XMLPathType.Href;
                    if (this.txtStartUrl.Text != "")
                    {
                        this.enableNavigate = true;
                        this.startUrlWebBrowser.Navigate(txtStartUrl.Text);
                    }
                    this.wizardControl1.SelectedPage = startPage;
                    this.currentUrlMaker = this.listPageUrlSelectorMarker;
                    e.Handled = true;
                    return;
                }
                else
                {
                    this.currenActiveBrowser = this.bwHomePage;
                    this.XMLPathSelectType = Model.XMLPathSelectType.Multiple;
                    this.XMLPathType = Model.XMLPathType.Href;
                    this.currentUrlMaker = homePageUrlSelectorMarker;
                    if (this.txtHomePage.Text != "")
                    {
                        this.enableNavigate = true;
                        this.bwHomePage.Navigate(txtHomePage.Text);
                    }
                }

            }
            else if (e.Page == this.homePage)
            {
                // 首页 -列表 -列表分页-内容
                if (radioButtonAllSite.Checked)
                {
                    this.currenActiveBrowser = startUrlWebBrowser;
                    if (this.txtStartUrl.Text != "")
                    {
                        this.enableNavigate = true;
                        this.startUrlWebBrowser.Navigate(txtStartUrl.Text);
                    }
                    else
                    {
                        UpdateSiteRule();
                        var urlSet = this.CurrentSiteRule.ProcessUrlSet(new UrlSet() { ListPages = new List<string> { this.txtHomePage.Text } }, this.homePageUrlSelectorMarker.CurrentUrlSelector);
                        if (urlSet.ListPages.Count > 0)
                        {
                            this.txtStartUrl.Text = urlSet.ListPages[0];
                            this.startUrlWebBrowser.Navigate(txtStartUrl.Text);
                        }
                        else
                        {
                            e.Handled = true;
                            MessageBox.Show("请限设置好规则再进入下一步！");
                            return;
                        }
                    }
                    this.currentUrlMaker = this.listPageUrlSelectorMarker;
                    this.wizardControl1.SelectedPage = startPage;
                    e.Handled = true;
                    return;
                }

                if (this.txtColumnPage.Text != "")
                {
                    this.enableNavigate = true;
                    this.bwColumnPage.Navigate(txtColumnPage.Text);
                }
                else
                {
                    UpdateSiteRule();
                    var urlSet = this.CurrentSiteRule.ProcessUrlSet(new UrlSet() { ListPages = new List<string> { this.txtHomePage.Text } }, this.homePageUrlSelectorMarker.CurrentUrlSelector);
                    if (urlSet.ListPages.Count > 0)
                    {
                        this.txtColumnPage.Text = urlSet.ListPages[0];
                        this.bwColumnPage.Navigate(txtColumnPage.Text);
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show("请限设置好规则再进入下一步！");
                        return;
                    }
                }
                this.currenActiveBrowser = this.bwColumnPage;
                this.XMLPathSelectType = Model.XMLPathSelectType.Multiple;
                this.XMLPathType = Model.XMLPathType.Href;
                this.currentUrlMaker = columnPageUrlSelectorMarker;
            }
            else if (e.Page == this.columnPage)
            {

                if (this.txtStartUrl.Text != "")
                {
                    this.enableNavigate = true;
                    this.startUrlWebBrowser.Navigate(txtStartUrl.Text);
                }
                else
                {
                    UpdateSiteRule();
                    var urlSet = this.CurrentSiteRule.ProcessUrlSet(new UrlSet() { ListPages = new List<string> { this.txtColumnPage.Text } }, this.columnPageUrlSelectorMarker.CurrentUrlSelector);
                    if (urlSet.ListPages.Count > 0)
                    {
                        this.txtStartUrl.Text = urlSet.ListPages[0];
                        this.startUrlWebBrowser.Navigate(txtStartUrl.Text);
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show("请限设置好规则再进入下一步！");
                        return;
                    }
                }
                this.currentUrlMaker = this.listPageUrlSelectorMarker;
                this.currenActiveBrowser = startUrlWebBrowser;
            }
            else if (e.Page == this.startPage)
            {
                if (this.txtStartUrl.Text == "")
                {
                    MessageBox.Show("请填写起始网址！");
                    e.Handled = true;
                    return;
                }
                if (this.txtTestUrl.Text != "")
                {
                    this.contentBrowser.Navigate(this.txtTestUrl.Text);
                }
                else
                {
                    UpdateSiteRule();
                    var urlSet = this.CurrentSiteRule.ProcessUrlSet(new UrlSet() { ListPages = new List<string> { this.txtStartUrl.Text } }, this.contentUrlSelectorMarker.CurrentUrlSelector);
                    if (urlSet.ListPages.Count > 0)
                    {
                        this.txtTestUrl.Text = urlSet.ListPages[0];
                        this.contentBrowser.Navigate(this.txtTestUrl.Text);
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show("请限设置好规则再进入下一步！");
                        return;
                    }
                }

                this.enableNavigate = true;
                this.EnableSelect = false;
                this.currenActiveBrowser = contentBrowser;
                this.XMLPathSelectType = Model.XMLPathSelectType.Multiple;
                this.XMLPathType = Model.XMLPathType.Href;


                this.isBindCompleted = false;
                this.Url = new Uri(this.txtStartUrl.Text);
                this.currentUrlMaker = contentUrlSelectorMarker;
                isLink = true;
            }
            else if (e.Page == this.contentUrlPage)
            {

                UpdateSiteRule();
                //List<Uri> urls = new List<Uri>();

                //if (!string.IsNullOrEmpty(CurrentSiteRule.ListPagePagerUrlSelector.DiyContentPageUrl))
                //{
                //    string[] rawUrls = CurrentSiteRule.ListPagePagerUrlSelector.DiyContentPageUrl.Split(new string[] { BaseConfig.UrlSeparator }, StringSplitOptions.RemoveEmptyEntries);
                //    if (rawUrls != null && rawUrls.Length > 0)
                //    {
                //        foreach (string url in rawUrls)
                //        {
                //            urls.Add(new Uri(url));
                //        }
                //    }
                //}

                //foreach (string sourceUrl in lbxUrls.Items)
                //{
                //    List<string> sourceUrls = new List<string>();
                //    try
                //    {
                //        sourceUrls = ExtractUrl.ParseUrlFromParameter(sourceUrl);
                //    }
                //    catch
                //    {
                //        MessageBox.Show(this, "测试采集网址的格式非法！", "测试采集网址错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        e.Handled = true;
                //        return;
                //    }
                //    foreach (string extractUrl in sourceUrls)
                //    {
                //        Uri uri;
                //        if (Uri.TryCreate(extractUrl, UriKind.Absolute, out uri))
                //        {
                //            urls.Add(uri);
                //        }
                //    }
                //}

                itemRuleIndex = 0;

                this.trvUrlTree.Nodes.Clear();
                this.loadingDialog = new LoadingDialog(this);

                loadingDialog.Show();
                loadingDialog.Percentage = 0;
                loadingDialog.Refresh();

                var item = CurrentSiteRule;

                var urlSet = new UrlSet();
                TreeNode parentNode = null;
                if (this.CurrentSiteRule.SiteExractMode == SiteExractMode.ListContent)
                {
                    urlSet.ListPages.Add(this.CurrentSiteRule.Referer);
                    parentNode = new TreeNode(this.CurrentSiteRule.Referer);
                }
                else
                {
                    urlSet.ListPages.Add(this.CurrentSiteRule.IndexPage);
                    parentNode = new TreeNode(this.CurrentSiteRule.IndexPage);
                }

                this.trvUrlTree.Nodes.Clear();
                this.trvUrlTree.Nodes.Add(parentNode);

                this.workingThread = new Thread(delegate()
                {
                    //if (!string.IsNullOrEmpty(item.DiyContentPageUrl))
                    //{
                    //    string[] dirBaseUrls = item.DiyContentPageUrl.Split(new string[] { BaseConfig.UrlSeparator }, StringSplitOptions.RemoveEmptyEntries);
                    //    List<string> dirUrls = new List<string>();
                    //    if (urls != null && dirBaseUrls.Length > 0)
                    //    {
                    //        foreach (string url in dirBaseUrls)
                    //        {
                    //            dirUrls.AddRange(ExtractUrl.ParseUrlFromParameter(url));
                    //        }
                    //    }
                    //    TreeNode parentNode = new TreeNode("用户自定义");
                    //    BindUrlTree(dirUrls, parentNode);
                    //}

                    int i = 0;

                    //while (true)
                    //{
                    //if (i == urls.Count)
                    //{
                    loadingDialog.BeginInvoke(new MethodInvoker(delegate()
                    {
                        loadingDialog.Percentage = 10;
                        this.loadingDialog.Refresh();
                    }));

                    //    break;
                    //}


                    if (this.CurrentSiteRule.SiteExractMode != SiteExractMode.ListContent)
                    {
                        // 栏目页面
                        urlSet = this.CurrentSiteRule.ProcessUrlSet(urlSet, CurrentSiteRule.ColumnUrlSelector);

                        foreach (var sourceUrl in urlSet.ListPages)
                        {
                            TreeNode node = new TreeNode(sourceUrl);
                            loadingDialog.BeginInvoke(new MethodInvoker(delegate()
                            {
                                loadingDialog.Percentage = Math.Min(100, loadingDialog.Percentage + 1);
                                this.loadingDialog.Refresh();
                                parentNode.Nodes.Add(node);
                            }));

                            if (CurrentSiteRule.SiteExractMode == SiteExractMode.HomeListContent)
                            {
                                // 列表分页
                                var childSet = this.CurrentSiteRule.ProcessUrlSet(new UrlSet { ListPages = new List<string> { sourceUrl } }, CurrentSiteRule.ListPagePagerUrlSelector);
                                foreach (var cUrl in childSet.ListPages)
                                {

                                    TreeNode cnode = new TreeNode(cUrl);

                                    loadingDialog.BeginInvoke(new MethodInvoker(delegate()
                                    {
                                        loadingDialog.Percentage = Math.Min(100, loadingDialog.Percentage + 1);
                                        this.loadingDialog.Refresh();
                                        node.Nodes.Add(cnode);
                                    }));

                                    // 列表
                                    var childSet2 = this.CurrentSiteRule.ProcessUrlSet(new UrlSet { ListPages = new List<string> { cUrl } }, CurrentSiteRule.ContentUrlSelector);
                                    loadingDialog.BeginInvoke(new MethodInvoker(delegate()
                                    {
                                        loadingDialog.Percentage = Math.Min(100, loadingDialog.Percentage + 1);
                                        this.loadingDialog.Refresh();
                                        foreach (var cUrl2 in childSet2.ListPages)
                                        {
                                            TreeNode cnode2 = new TreeNode(cUrl2);
                                            cnode.Nodes.Add(cnode2);
                                        }
                                        foreach (var cUrl2 in childSet2.ContetnPages)
                                        {
                                            TreeNode cnode2 = new TreeNode(cUrl2);
                                            cnode.Nodes.Add(cnode2);
                                        } //  列表 end
                                    }));
                                }
                                loadingDialog.BeginInvoke(new MethodInvoker(delegate()
                                {
                                    loadingDialog.Percentage = Math.Min(100, loadingDialog.Percentage + 1);
                                    this.loadingDialog.Refresh();
                                    foreach (var cUrl in childSet.ContetnPages)
                                    {
                                        TreeNode cnode = new TreeNode(cUrl);
                                        node.Nodes.Add(cnode);
                                    } //  列表分页 end
                                }));
                            }
                            else
                            {
                                // 列表页面
                                var columnSet = this.CurrentSiteRule.ProcessUrlSet(new UrlSet { ListPages = new List<string> { sourceUrl } }, CurrentSiteRule.LisPageUrlSelector);

                                foreach (var listUrl in columnSet.ContetnPages)
                                {
                                    TreeNode listNode = new TreeNode(listUrl);
                                    loadingDialog.BeginInvoke(new MethodInvoker(delegate()
                                    {
                                        loadingDialog.Percentage = Math.Min(100, loadingDialog.Percentage + 1);
                                        this.loadingDialog.Refresh();
                                        node.Nodes.Add(listNode);
                                    }));

                                    // 列表分页
                                    var childSet = this.CurrentSiteRule.ProcessUrlSet(new UrlSet { ListPages = new List<string> { listUrl } }, CurrentSiteRule.ListPagePagerUrlSelector);

                                    foreach (var cUrl in childSet.ListPages)
                                    {
                                        TreeNode cnode = new TreeNode(cUrl);
                                        loadingDialog.BeginInvoke(new MethodInvoker(delegate()
                                        {
                                            loadingDialog.Percentage = Math.Min(100, loadingDialog.Percentage + 1);
                                            this.loadingDialog.Refresh();
                                            listNode.Nodes.Add(cnode);
                                        }));

                                        // 列表
                                        var childSet2 = this.CurrentSiteRule.ProcessUrlSet(new UrlSet { ListPages = new List<string> { cUrl } }, CurrentSiteRule.ContentUrlSelector);
                                        loadingDialog.BeginInvoke(new MethodInvoker(delegate()
                                        {
                                            foreach (var cUrl2 in childSet2.ListPages)
                                            {
                                                TreeNode cnode2 = new TreeNode(cUrl2);
                                                cnode.Nodes.Add(cnode2);
                                            }
                                            foreach (var cUrl2 in childSet2.ContetnPages)
                                            {
                                                TreeNode cnode2 = new TreeNode(cUrl2);
                                                cnode.Nodes.Add(cnode2);
                                            } //  列表 end
                                        }));
                                    }
                                    loadingDialog.BeginInvoke(new MethodInvoker(delegate()
                                    {
                                        loadingDialog.Percentage = Math.Min(100, loadingDialog.Percentage + 1);
                                        this.loadingDialog.Refresh();
                                        foreach (var cUrl in childSet.ContetnPages)
                                        {
                                            TreeNode cnode = new TreeNode(cUrl);
                                            node.Nodes.Add(cnode);
                                        } //  列表分页 end
                                    }));
                                }
                                loadingDialog.BeginInvoke(new MethodInvoker(delegate()
                                {
                                    loadingDialog.Percentage = Math.Min(100, loadingDialog.Percentage + 1);
                                    this.loadingDialog.Refresh();
                                    foreach (var cUrl in columnSet.ContetnPages)
                                    {
                                        TreeNode cnode = new TreeNode(cUrl);
                                        node.Nodes.Add(cnode);
                                    } //  列表分页 end
                                }));
                            }

                            //BindUrlTree(urls, parentNode);
                        }
                        loadingDialog.BeginInvoke(new MethodInvoker(delegate()
                        {
                            loadingDialog.Percentage = Math.Min(100, loadingDialog.Percentage + 1);
                            this.loadingDialog.Refresh();
                            foreach (var url in urlSet.ContetnPages)
                            {
                                TreeNode node = new TreeNode(url);
                                parentNode.Nodes.Add(node);
                            }
                        }));
                    }
                    else
                    {
                        urlSet = this.CurrentSiteRule.ProcessUrlSet(urlSet, CurrentSiteRule.ListPagePagerUrlSelector);
                        foreach (var cUrl in urlSet.ListPages)
                        {
                            TreeNode cnode = new TreeNode(cUrl);

                            // 列表
                            var childSet2 = this.CurrentSiteRule.ProcessUrlSet(new UrlSet { ListPages = new List<string> { cUrl } }, CurrentSiteRule.ContentUrlSelector);
                            foreach (var cUrl2 in childSet2.ListPages)
                            {
                                TreeNode cnode2 = new TreeNode(cUrl2);
                                cnode.Nodes.Add(cnode2);
                            }
                            foreach (var cUrl2 in childSet2.ContetnPages)
                            {
                                TreeNode cnode2 = new TreeNode(cUrl2);
                                cnode.Nodes.Add(cnode2);
                            } //  列表 end

                            loadingDialog.BeginInvoke(new MethodInvoker(delegate()
                            {
                                loadingDialog.Percentage = Math.Min(100, loadingDialog.Percentage + 1);
                                this.loadingDialog.Refresh();
                                parentNode.Nodes.Add(cnode);
                            }));
                        }
                        foreach (var cUrl in urlSet.ContetnPages)
                        {
                            TreeNode cnode = new TreeNode(cUrl);
                            parentNode.Nodes.Add(cnode);
                        } //  列表分页 end
                    }

                    //var html = HtmlPicker.VisitUrl(urls[i],
                    //                                   item.HttpMethod,
                    //                                   null,
                    //                                   string.IsNullOrEmpty(item.Referer) ? null : item.Referer,
                    //                               string.IsNullOrEmpty(item.Cookie) ? null : Utility.GetCookies(item.Cookie),
                    //                               string.IsNullOrEmpty(item.UserAgent) ? null : item.UserAgent,
                    //                               string.IsNullOrEmpty(item.HttpPostData) ? null : item.HttpPostData,
                    //                                   System.Text.Encoding.GetEncoding(item.ListEncoding));

                    //SetExtractUrl(item, html, urls[i].AbsoluteUri, item.ListEncoding);
                    //i++;

                    loadingDialog.BeginInvoke(new MethodInvoker(delegate()
                    {
                        loadingDialog.Refresh();
                        loadingDialog.Close();
                    }));

                });
                this.workingThread.Start();
                isLink = false;
            }
            else if (e.Page == this.previewPage)
            {
                if (loadingDialog != null && workingThread != null)
                {
                    loadingDialog.Close();
                    workingThread.Abort();
                }

                if (this.txtTestUrl.Text == "")
                {
                    this.txtTestUrl.Text = forTestUrl;
                }
                this.enableNavigate = true;
                this.Url = new Uri(this.txtTestUrl.Text);
                this.itemWebBrowser.Navigate(this.txtTestUrl.Text);
                this.enableNavigate = true;
                this.EnableSelect = false;
                this.isBindCompleted = false;
                this.currenActiveBrowser = itemWebBrowser;
                this.currentActiveLogLabel = lblItemLog;
                this.currentTxtbox = txtCXpath;
                this.CurrentItemRule = this.CurrentSiteRule.ItemRules[0];
                this.XMLPathSelectType = this.CurrentItemRule.XMLPathSelectType;
                this.XMLPathType = this.CurrentItemRule.XMLPathType;
            }
            else if (e.Page == this.contentDetailPage)
            {
                UpdateItemRule();
                UpdateSiteRule();

                if (string.IsNullOrEmpty(this.txtTestUrl.Text))
                {
                    MessageBox.Show(this, "请输入测试采集地址！", "测试采集设置错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Uri uri;
                if (!Uri.TryCreate(this.txtTestUrl.Text, UriKind.Absolute, out uri))
                {
                    MessageBox.Show(this, "非法测试采集地址！", "测试采集设置错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //this.loadingDialog = new LoadingDialog();
                ////loadingDialog.AddOwnedForm(this);
                //loadingDialog.Show();
                if (DevExpress.XtraSplashScreen.SplashScreenManager.Default != null)
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
                }

                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(WaitForm1));
                var html = HtmlPicker.VisitUrl(
                                         uri,
                                         "GET",
                                         null,
                                          CurrentSiteRule.Referer,
                                          Utility.GetCookies(CurrentSiteRule.Cookie),
                                         CurrentSiteRule.UserAgent,
                                         "",
                                        Encoding.GetEncoding(CurrentSiteRule.Encoding));
                SetFetchResult(html);
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
            }

        }

        private void wizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void wizardControl1_CancelClick(object sender, CancelEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this.txtStartUrl.Text != "")
            {
                if (!this.txtStartUrl.Text.Contains("http://"))
                {
                    this.txtStartUrl.Text = "http://" + this.txtStartUrl.Text;
                }
                //var temp = this.enableNavigate;
                this.enableNavigate = true;
                this.startUrlWebBrowser.Navigate(this.txtStartUrl.Text);
                this.isBindCompleted = false;
                this.Url = new Uri(this.txtStartUrl.Text);
                //this.enableNavigate = temp;
            }
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            URLBuilder urlBuilder = new URLBuilder();
            if (urlBuilder.ShowDialog() == DialogResult.OK)
            {
                //this.lbxUrls.Items.AddRange(urlBuilder.FinishedUrls);
            }
        }


        private void SiteRuleWizardForm_Load(object sender, EventArgs e)
        {
            BindBrowseEvent(startUrlWebBrowser);
            BindBrowseEvent(contentBrowser);
            BindBrowseEvent(itemWebBrowser);
            BindBrowseEvent(bwHomePage);
            BindBrowseEvent(bwColumnPage);
        }

        /// <summary>
        /// 自动识别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoReListPage_Click(object sender, EventArgs e)
        {
            var linkNodes = ExtractUrl.GetLinkNodes(this.currenActiveBrowser.Document.Body.OuterHtml, "下一页", "Next", "Next &gt;", "下页", "Last", "末页", "尾页", "2", "3");

            bool hasLast = false;

            if (linkNodes.Count != 0)
            {
                var linkTexts = linkNodes.Select(t => t.InnerText).ToList();

                // 下一页
                HtmlAgilityPack.HtmlNode next = null;

                if (linkTexts.Contains("下一页"))
                {
                    next = linkNodes.FirstOrDefault(n => n.InnerText == "下一页");
                }
                else if (linkTexts.Contains("下页"))
                {
                    next = linkNodes.FirstOrDefault(n => n.InnerText == "下页");
                }
                else if (linkTexts.Contains("Next"))
                {
                    next = linkNodes.FirstOrDefault(n => n.InnerText == "Next");
                }
                else if (linkTexts.Contains("Next &gt;"))
                {
                    next = linkNodes.FirstOrDefault(n => n.InnerText == "Next &gt;");
                }
                else if (linkTexts.Contains("2"))
                {
                    next = linkNodes.FirstOrDefault(n => n.InnerText == "2");
                }

                // 尾页
                HtmlAgilityPack.HtmlNode last = null;
                if (linkTexts.Contains("尾页"))
                {
                    last = linkNodes.FirstOrDefault(n => n.InnerText == "尾页");
                }
                else if (linkTexts.Contains("末页"))
                {
                    last = linkNodes.FirstOrDefault(n => n.InnerText == "末页");
                }
                else if (linkTexts.Contains("Last"))
                {
                    last = linkNodes.FirstOrDefault(n => n.InnerText == "Last");
                }
                else if (linkTexts.Contains("3"))
                {
                    last = linkNodes.FirstOrDefault(n => n.InnerText == "3");
                }

                string pageXpath = "";

                if (last != null && next != null)
                {
                    pageXpath = this.GetCommonXpath(next.XPath, last.XPath);

                }
                else
                {
                    // 只有下一页
                    pageXpath = linkNodes[0].XPath;
                    pageXpath = pageXpath.Substring(0, pageXpath.LastIndexOf("a") + 1);
                    //pageXpath = pageXpath.Insert(pageXpath.LastIndexOf("/"), "/");
                }

                linkNodes = linkNodes[0].SelectNodes(pageXpath).ToList();
                // get 下一页
            }

            ProcessLinkNodes(linkNodes);
        }

        private void ProcessLinkNodes(List<HtmlAgilityPack.HtmlNode> linkNodes)
        {

            foreach (var node in linkNodes)
            {
                //if (!this.lbxUrls.Items.Contains(this.txtStartUrl.Text))
                //{
                //    this.lbxUrls.Items.Add(this.txtStartUrl.Text);
                //}
                var url = node.Attributes["href"].Value;

                if (url.StartsWith("javas"))
                {
                    continue;
                }

                if (!url.Contains("http://"))
                {
                    url = ExtractUrl.RepairUrl(this.txtStartUrl.Text, url);
                }

                url = url.Replace("&amp;", "&");


                //if (!this.lbxUrls.Items.Contains(url))
                //{
                //    this.lbxUrls.Items.Add(url);
                //}
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.enableNavigate = true;
            this.itemWebBrowser.Navigate(this.txtTestUrl.Text);
            this.isBindCompleted = false;
        }

        private void linkUrlSeniorSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new UrlSettingForm(this.CurrentSiteRule).ShowDialog();
        }

        private void itemRuleTab_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            UpdateItemRule();

            this.ItemContrainerPanel.Parent.Controls.Remove(this.ItemContrainerPanel);
            this.itemRuleTab.SelectedTabPage.Controls.Add(this.ItemContrainerPanel);
            if (this.itemRuleTab.SelectedTabPage.Text == "内容")
            {
                this.chkDownloadPic.Enabled = true;

            }
            else
            {
                this.chkDownloadPic.Enabled = false;
            }
            CurrentItemRule = CurrentSiteRule.ItemRules.SingleOrDefault(r => r.ItemName == itemRuleTab.SelectedTabPage.Text);
            this.InitializeItemRuleDetail(CurrentItemRule);
        }

        /// <summary>
        /// 选择分页Pager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectPager_Click(object sender, EventArgs e)
        {
            this.EnableSelect = true;
            this.currentTxtbox = this.txtPageXPath;
            this.XMLPathSelectType = Model.XMLPathSelectType.OnlyOne;
            this.XMLPathType = Model.XMLPathType.InnerLinks;
        }

        /// <summary>
        /// 选择可替换XPath
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectAnotherXpath_Click(object sender, EventArgs e)
        {
            current = null;
            last = null;
            this.EnableSelect = true;
            this.currentTxtbox = this.txtAnotherXPath;
            this.XMLPathSelectType = Model.XMLPathSelectType.OnlyOne;
            this.XMLPathType = Model.XMLPathType.InnerLinks;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnGotoHomePage_Click(object sender, EventArgs e)
        {
            if (this.txtHomePage.Text != "")
            {
                if (!this.txtHomePage.Text.Contains("http://"))
                {
                    this.txtHomePage.Text = "http://" + this.txtHomePage.Text;
                }
                //var temp = this.enableNavigate;
                this.enableNavigate = true;
                this.bwHomePage.Navigate(this.txtHomePage.Text);
                this.isBindCompleted = false;
                this.Url = new Uri(this.txtHomePage.Text);
                //this.enableNavigate = temp;
            }
        }

        private void btnGotoColumnPage_Click(object sender, EventArgs e)
        {
            if (this.txtColumnPage.Text != "")
            {
                if (!this.txtColumnPage.Text.Contains("http://"))
                {
                    this.txtColumnPage.Text = "http://" + this.txtColumnPage.Text;
                }
                //var temp = this.enableNavigate;
                this.enableNavigate = true;
                this.bwColumnPage.Navigate(this.txtColumnPage.Text);
                this.isBindCompleted = false;
                this.Url = new Uri(this.txtColumnPage.Text);
                //this.enableNavigate = temp;
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {

        }


        private void wizardControl1_PrevClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            // 列表分页
            if (e.Page == this.startPage)
            {
                // 首页 -栏目- 列表 -列表分页-内容
                if (radioButtonAllSite2.Checked)
                {
                    this.currentUrlMaker = this.columnPageUrlSelectorMarker;
                }
                // 首页 -列表 -列表分页-内容
                else if (radioButtonAllSite.Checked)
                {
                    wizardControl1.SelectedPage = columnPage;
                    e.Handled = true;
                    this.currentUrlMaker = this.homePageUrlSelectorMarker;
                    return;

                }
                else if (radioButtonListPage.Checked)
                {
                    wizardControl1.SelectedPage = welcomeWizardPage1;
                    e.Handled = true;
                    return;
                }
            }
        }

        private void UrlSelectorMarker_OnXpathSelectorClick(object sender, EventArgs e)
        {
            OnBrowserLoaded();
            this.enableNavigate = false;
            this.EnableSelect = true;
            this.XMLPathSelectType = currentUrlMaker.CurrentXMLPathSelectType;
            this.XMLPathType = currentUrlMaker.CurrentXMLPathType;

            this.CurrentXPathSelected = (xpath) =>
            {
                currentUrlMaker.SetXPath(xpath);
                var Datas = ExtractDataFromHtml();
                currentUrlMaker.SetUrlResult(Datas);
                if (Datas.Count > 0)
                {
                    if (wizardControl1.SelectedPage == homePage)
                    {
                        if (this.txtColumnPage.Text == "" && this.radioButtonAllSite2.Checked)
                        {
                            this.txtColumnPage.Text = Datas[0];
                        }
                        else if (this.txtStartUrl.Text == "" && this.radioButtonAllSite.Checked)
                        {
                            this.txtStartUrl.Text = Datas[0];
                        }
                    }
                    else if (wizardControl1.SelectedPage == columnPage && this.txtStartUrl.Text == "")
                    {
                        this.txtStartUrl.Text = Datas[0];
                    }
                    else if (wizardControl1.SelectedPage == startPage && this.txtTestUrl.Text == "")
                    {
                        this.txtTestUrl.Text = Datas[0];
                    }
                }
            };
        }

        private void UrlSelectorMarker_OnTestClick(object sender, EventArgs e)
        {
            var Datas = ExtractDataFromHtml();
            currentUrlMaker.SetUrlResult(Datas);
        }

        private void UrlSelectorMarker_OnSelectUrlClick(object sender, EventArgs e)
        {
            OnBrowserLoaded();
            this.enableNavigate = false;
            this.EnableSelect = true;
            this.XMLPathSelectType = Model.XMLPathSelectType.OnlyOne;
            this.XMLPathType = Model.XMLPathType.Href;
            this.CurrentXPathSelected = (xpath) =>
            {
                var Datas = ExtractDataFromHtml();
                if (Datas.Count > 0)
                {
                    currentUrlMaker.SelectUrlClickFinish(Datas[0]);
                }
            };
        }

    }
}