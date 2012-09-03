using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.iFLYTEK.WinForms.Browser;
using System.Text.RegularExpressions;
using mshtml;
using Jade.Model;
using System.Threading;     //包含正则表达式  

namespace Jade.Forms
{
    public partial class XmlPathSelector : Form, IBaseBrowserForm
    {
        private static string html2TextPattern =
  @"(?<script><script[^>]*?>.*?</script>)|(?<style><style>.*?</style>)|(?<comment><!--.*?-->)" +
  @"|(?<html>(?!<ps|(<p>)|(<img)|(<br)|(strong))" +   //保留的html标记前缀,<a>,<p>,<img><br><STRONG>
     @"<[^>]+>)" + // HTML标记
  @"|(?<quot>&(quot|#34);)" + // 符号: "
  @"|(?<amp>&(amp|#38);)" + // 符号: &
  @"|(?<end>(?!(</strong)|(</p>))</[^>]+>)" +        //HTML闭合标签 保留</A>,</STRONG>,</P>
  @"|(?<iexcl>&(iexcl|#161);)" + // 符号: (char)161
  @"|(?<cent>&(cent|#162);)" + // 符号: (char)162
  @"|(?<pound>&(pound|#163);)" + // 符号: (char)163
  @"|(?<copy>&(copy|#169);)" + // 符号: (char)169
  @"|(?<others>&(d+);)"; // 符号: 其他

        public static string NoHTML(string Htmlstring) //去除HTML标记  
        {
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled;
            //删除脚本  
            Htmlstring = Regex.Replace(Htmlstring, html2TextPattern, "", options);
            return Htmlstring;
        }

        public XMLPathType XMLPathType
        {
            get;
            set;
        }

        public XMLPathSelectType XMLPathSelectType
        {
            get;
            set;
        }

        public string XPath
        {
            get
            {
                return this.txtxmlpath.Text;
            }
        }


        bool EnableSelect = false;

        private void XmlPathSelector_Load(object sender, EventArgs e)
        {
            this.iReaperWebBrowser.Document.Window.Error += new HtmlElementErrorEventHandler(Window_Error);
            this.iReaperWebBrowser.StatusTextChanged += new EventHandler(iReaperWebBrowser_StatusTextChanged);
            this.Resize += new EventHandler((o, ea) =>
            {
                var width = 0;
                foreach (ToolStripItem item in this.toolStrip1.Items)
                {
                    if (item != this.txtxmlpath)
                    {
                        width += item.Width;
                    }
                }
                this.txtxmlpath.Size = new Size(this.Width - width - 60, this.txtxmlpath.Height);
            });
        }

        void Window_Error(object sender, HtmlElementErrorEventArgs e)
        {
            e.Handled = true;
        }

        void iReaperWebBrowser_StatusTextChanged(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = this.iReaperWebBrowser.StatusText;
        }

        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        System.ComponentModel.ComponentResourceManager resources;

        private TabContextMenu tabContextMenu = new TabContextMenu();

        public XmlPathSelector()
        {
            Init();
        }

        private void Init()
        {
            InitializeComponent();
            this.XMLPathType = XMLPathType.InnerTextWithPic;
            this.XMLPathSelectType = XMLPathSelectType.OnlyOne;
            this.iReaperWebBrowser.DocumentTitleChanged += new EventHandler(UpdateTabTitle);
            //this.TabPageContextMenu = tabContextMenu;
            //tabContextMenu.Context = this;
            this.browserToolStrip1.WbForm = this;
            this.browserToolStrip1.UrlCombo.KeyUp += new KeyEventHandler(UrlCombo_KeyUp);

        }


        public XmlPathSelector(string url, string xPath = "", XMLPathType type = XMLPathType.InnerTextWithPic, XMLPathSelectType selectType = Model.XMLPathSelectType.OnlyOne)
        {
            Init();
            this.XMLPathType = type;
            this.XMLPathSelectType = selectType;
            this.txtxmlpath.Text = xPath;
            BindUIData();
            this.Url = new Uri(url);

        }

        void BindUIData()
        {
            switch (XMLPathType)
            {
                case XMLPathType.Href:
                case XMLPathType.InnerLinks:
                    this.radioHref.Enabled = true;
                    this.radionInnerLinks.Enabled = true;
                    this.radioText.Enabled = false;
                    this.radioHtml.Enabled = false;
                    this.radioTextWithPic.Enabled = false;
                    break;
                default:
                    break;
            }

            if (XMLPathSelectType == Model.XMLPathSelectType.Multiple)
            {
                this.radioMulti.Checked = true;
            }
            else
            {
                this.radioOne.Checked = true;
            }

            BindXpathType(XMLPathType);
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


        void Browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            e.Cancel = true;
        }

        void Browser_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
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
                    current.Style = current.Style.Replace("BORDER-BOTTOM: #0000cc 1px solid; BORDER-LEFT: #0000cc 1px solid; BACKGROUND-COLOR: #9fc4e7; BORDER-TOP: #0000cc 1px solid; BORDER-RIGHT: #0000cc 1px solid", "");
                }
                current = element;
                Console.WriteLine(e.ToElement.ClientRectangle);
                current.Style += "background-color:#9FC4E7;border:1px solid #0000CC;";

                this.txtxmlpath.Text = GetXmlPath(current);
            }
        }

        HtmlElement current;

        void Document_MouseOver(object sender, HtmlElementEventArgs e)
        {
            if (EnableSelect)
            {
                if (e.FromElement != null)
                {

                    if (current != null)
                    {
                        current.Style = current.Style.Replace("BORDER-BOTTOM-STYLE: solid; BORDER-BOTTOM-COLOR: red; BORDER-TOP-COLOR: red; BORDER-LEFT-STYLE: solid; BORDER-TOP-STYLE: solid; BORDER-RIGHT-COLOR: red; BORDER-RIGHT-STYLE: solid; BORDER-LEFT-COLOR: red; box-shadow: 0px 0px 1px red", "");
                    }
                    current = e.FromElement;
                    current.Style += "border-style:solid;border-color:red;box-shadow: 0px 0px 1px red;";

                    this.toolStrip1.Text = GetXmlPath(current);

                }
            }
        }

        string firstXpath = "";
        string secondXpath = "";

        void Document_Click(object sender, HtmlElementEventArgs e)
        {
            if (EnableSelect)
            {
                this.txtxmlpath.Text = GetXmlPath(current);

                //if (XPathDic.ContainsKey(this.txtxmlpath.Text))
                //{
                //    this.treeXPath.SelectedNode = XPathDic[this.txtxmlpath.Text];
                //}

                if (this.XMLPathSelectType == XMLPathSelectType.Multiple)
                {
                    SelectedCount++;
                    if (SelectedCount == 1)
                    {
                        this.lblLog.Text = "你已经选择一次，请再选择和第一次选择同级的节点";
                        firstXpath = this.txtxmlpath.Text;
                    }
                    else
                    {

                        SelectedCount = 0;
                        secondXpath = this.txtxmlpath.Text;

                        var commonPath = this.GetCommonXpath(firstXpath, secondXpath);
                        if (!string.IsNullOrEmpty(commonPath))
                        {
                            this.lblLog.Text = "你已经选择两次，请测试是否正确";
                            this.txtxmlpath.Text = commonPath;
                        }
                        else
                        {
                            this.lblLog.Text = "选择失败，必须选择同一级别的元素,不能是同一元素";
                        }
                        EnableSelect = false;
                        toolStripButton3_Click(null, null);
                    }
                }
                else
                {
                    EnableSelect = false;
                    toolStripButton3_Click(null, null);
                }

            }
        }

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

        public string GetXmlPath(HtmlElement element)
        {
            //IHTMLDocument2 htmlDocument = this.iReaperWebBrowser.Document.DomDocument as mshtml.IHTMLDocument2;
            var name = element.TagName.ToLower();
            //IHTMLElement el = element as IHTMLElement;
            IHTMLDocument2 htmlDocument = iReaperWebBrowser.Document.DomDocument as IHTMLDocument2;

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

        void UrlCombo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                GoNavigate();
            }
        }

        /// <summary>
        /// 载入欢迎页面
        /// </summary>
        public void LoadWelcomeWeb(string url)
        {
            this.iReaperWebBrowser.Navigate(url);
            this.iReaperWebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(delegate(object obj, WebBrowserDocumentCompletedEventArgs e)
            {
                if (!this.IsDisposed)
                {
                    this.Show();
                    this.Activate();
                    //msdn的页面载入成功之后，修改地址栏
                    this.browserToolStrip1.UrlCombo.Text = this.iReaperWebBrowser.Url.AbsoluteUri;
                }
            });
            this.iReaperWebBrowser.NavigationError += new EventHandler(delegate(object sender, EventArgs e)
            {
                this.Close();
            });

        }

        protected override void OnLoad(EventArgs e)
        {
            //装载成功后，注册自己
            //BrowserManager.RegisterBrowser(this);
            //CoreObjects.ActiveBrowser = this;
            base.OnLoad(e);
        }

        /// <summary>
        /// 及时更新TabText为DocumentTitle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTabTitle(object sender, EventArgs e)
        {
            this.Text = this.iReaperWebBrowser.DocumentTitle;
            if (this.Text == "")
            {
                this.Text = "about:blank";
            }
        }

        /// <summary>
        /// 设置浏览器的Url
        /// </summary>
        public Uri Url
        {
            set
            {
                if (value == null || !value.IsAbsoluteUri)
                { return; }
                this.Text = value.AbsoluteUri;
                this.iReaperWebBrowser.Url = value;
                this.browserToolStrip1.UrlCombo.Text = value.AbsoluteUri;
            }
            get
            {
                return this.iReaperWebBrowser.Url;
            }
        }

        /// <summary>
        /// 浏览器读取到了新的图标，更新之
        /// </summary>
        /// <param name="icon"></param>
        private void IconChanged(Icon icon)
        {
            this.Icon = icon;
        }

        /// <summary>
        /// 如果浏览器由于某种原因被关闭了，则
        /// 整个窗体需要同时被关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckQuit(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 后退
        /// </summary>
        public void GoBack()
        {
            this.iReaperWebBrowser.GoBack();
        }

        /// <summary>
        /// 向前
        /// </summary>
        public void GoForward()
        {
            this.iReaperWebBrowser.GoForward();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        public void RefreshBrowser()
        {
            this.iReaperWebBrowser.Refresh();
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            this.iReaperWebBrowser.Stop();
        }

        /// <summary>
        /// 导航至当前的地址栏的地址
        /// </summary>
        public void GoNavigate()
        {
            if (iReaperWebBrowser.Document != null)
            {
                iReaperWebBrowser.Document.Body.MouseOver -= new HtmlElementEventHandler(Body_MouseOver);

                iReaperWebBrowser.Document.Click -= new HtmlElementEventHandler(Document_Click);
            }
            iReaperWebBrowser.NewWindow -= new CancelEventHandler(Browser_NewWindow);
            iReaperWebBrowser.Navigating -= new WebBrowserNavigatingEventHandler(Browser_Navigating);

            string tempUrl = "";
            if (this.browserToolStrip1.UrlCombo.Text.IndexOf("://") == -1)
            {
                tempUrl = "http://" + this.browserToolStrip1.UrlCombo.Text;
            }
            else
            {
                tempUrl = this.browserToolStrip1.UrlCombo.Text;
            }
            this.Url = new Uri(tempUrl, UriKind.Absolute);
        }

        /// <summary>
        /// 使用指定的从Windows Live ID中获得的验证信息访问网站
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postedData"></param>
        public void NavigateWithPostedAuthenInfo(string url, byte[] postedData)
        {
            this.iReaperWebBrowser.Navigate(url, "_self", postedData, "Content-Type: application/x-www-form-urlencoded");
        }

        private void UpdateUrl(object sender, WebBrowserNavigatingEventArgs e)
        {
            this.browserToolStrip1.UrlCombo.Text = e.Url.AbsoluteUri;
        }

        private void iReaperWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url == this.Url)
            {
                iReaperWebBrowser.Document.Body.MouseOver += new HtmlElementEventHandler(Body_MouseOver);
                iReaperWebBrowser.NewWindow += new CancelEventHandler(Browser_NewWindow);
                iReaperWebBrowser.Navigating += new WebBrowserNavigatingEventHandler(Browser_Navigating);
                iReaperWebBrowser.Document.Click += new HtmlElementEventHandler(Document_Click);

                //var html = this.iReaperWebBrowser.Document.Body.OuterHtml;
                //new Thread(() =>
                //{
                //    //bindTree
                //    BindTree(html);
                //}).Start();

            }
        }

        private Dictionary<object, TreeNode> XPathDic = new Dictionary<object, TreeNode>();

        private void BindTree(string html)
        {
            XPathDic.Clear();
        

            var pathType = this.XMLPathType;
            var xpath = this.txtxmlpath.Text;
            HtmlAgilityPack.HtmlDocument HtmlDoc = new HtmlAgilityPack.HtmlDocument();
            HtmlDoc.LoadHtml(html);

            var htmlNode = HtmlDoc.DocumentNode;
            var root = new TreeNode(htmlNode.OriginalName);
            root.Tag = htmlNode.XPath;
            XPathDic.Add(root.Tag, root);
            BindXPathTree(root, htmlNode);

            try
            {
                //this.treeXPath.BeginInvoke(new MethodInvoker(() =>
                //{
                //    this.treeXPath.Nodes.Clear();
                //    this.treeXPath.Nodes.Add(root);
                //    this.treeXPath.ExpandAll();
                //}));
            }
            catch
            {
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioHref.Checked)
            {
                this.XMLPathType = XMLPathType.Href;
            }
            else if (this.radioHtml.Checked)
            {
                this.XMLPathType = XMLPathType.InnerHtml;
            }
            else if (this.radionInnerLinks.Checked)
            {
                this.XMLPathType = XMLPathType.InnerLinks;
            }
            else if (this.radioText.Checked)
            {
                this.XMLPathType = XMLPathType.InnerText;
            }
            else if (this.radioTextWithPic.Checked)
            {
                this.XMLPathType = XMLPathType.InnerTextWithPic;
            }
        }


        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioOne.Checked)
            {
                this.XMLPathSelectType = XMLPathSelectType.OnlyOne;
            }
            else
            {
                this.XMLPathSelectType = XMLPathSelectType.Multiple;
            }
        }

        void BindXPathTree(TreeNode parent, HtmlAgilityPack.HtmlNode htmlNode)
        {
            if (htmlNode.HasChildNodes)
            {
                foreach (var childNode in htmlNode.ChildNodes)
                {
                    var childTreeNode = new TreeNode(childNode.OriginalName);
                    childTreeNode.Tag = childNode.XPath;
                    BindXPathTree(childTreeNode, childNode);
                    parent.Nodes.Add(childTreeNode);
                    XPathDic.Add(childTreeNode.Tag, childTreeNode);
                }
            }
        }

        int SelectedCount = 0;

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.EnableSelect = true;
        }

        public List<string> Datas
        {
            get;
            set;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (this.txtxmlpath.Text == "")
            {
                MessageBox.Show("请先选择！");
                return;
            }
            try
            {
                Datas = ExtractDataFromHtml();
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
                this.richTextBox1.Text = txt;
            }
            catch
            {
                MessageBox.Show("匹配错误，请重新选择");
            }
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
        public List<string> ExtractDataFromHtml()
        {

            var result = ExtractUrl.ExtractDataFromHtml(this.iReaperWebBrowser.Document.Body.OuterHtml, this.txtxmlpath.Text, XMLPathSelectType, XMLPathType);

            var pathType = this.XMLPathType;
            var xpath = this.txtxmlpath.Text;
            switch (pathType)
            {
                case XMLPathType.Href:
                case XMLPathType.InnerLinks:
                    for (var i = 0; i < result.Count; i++)
                    {
                        result[i] = RepairUrl(this.Url.AbsoluteUri, result[i]);
                    }
                    break;
            }
            return result;
            //var result = new List<string>();
            var html = this.iReaperWebBrowser.Document.Body.OuterHtml;

       
            //if (xpath.Contains("table"))
            //{
            //    xpath = xpath.Replace("table", "xtable");
            //    html = html.Replace("table", "xtable");
            //}

            HtmlAgilityPack.HtmlDocument HtmlDoc = new HtmlAgilityPack.HtmlDocument();
            HtmlDoc.LoadHtml(html);
            var nodes = HtmlDoc.DocumentNode.SelectNodes(xpath);
            if (nodes != null)
            {
                if (this.XMLPathSelectType == XMLPathSelectType.Multiple)
                {
                    foreach (HtmlAgilityPack.HtmlNode node in nodes)
                    {
                        switch (pathType)
                        {
                            case XMLPathType.Href:
                                result.Add(RepairUrl(this.Url.AbsoluteUri, node.Attributes["href"].Value.ToString()));
                                break;
                            case XMLPathType.InnerHtml:
                                result.Add(node.InnerHtml);
                                break;
                            case XMLPathType.InnerText:
                                result.Add(node.InnerText);
                                break;
                            case XMLPathType.InnerLinks:
                                result.AddRange(GetLinks(node));
                                break;
                            case XMLPathType.InnerTextWithPic:
                                result.Add(NoHTML(node.InnerHtml));
                                break;
                        }
                    }
                }
                else
                {
                    if (nodes.Count > 0)
                    {
                        var node = nodes[0];
                        switch (pathType)
                        {
                            case XMLPathType.Href:
                                result.Add(node.Attributes["href"].Value.ToString());
                                break;
                            case XMLPathType.InnerHtml:
                                result.Add(node.InnerHtml);
                                break;
                            case XMLPathType.InnerText:
                                result.Add(node.InnerText);
                                break;
                            case XMLPathType.InnerLinks:
                                result.AddRange(GetLinks(node));
                                break;
                            case XMLPathType.InnerTextWithPic:
                                result.Add(NoHTML(node.InnerHtml));
                                break;
                        }
                    }

                }
            }
            return result;
        }

        List<string> GetLinks(HtmlAgilityPack.HtmlNode node)
        {
            var links = node.SelectNodes("//a");
            return links.Select(l => RepairUrl(this.Url.AbsoluteUri, l.Attributes["href"].Value.ToString())).ToList();
        }

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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void treeXPath_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
