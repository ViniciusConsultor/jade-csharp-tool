using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;
using ICSharpCode.TextEditor.Document;

namespace Jade
{
    /// <summary>
    /// Html编辑器
    /// </summary>
    [Description("Html编辑器"), ClassInterface(ClassInterfaceType.AutoDispatch)]
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class HtmlEditor : UserControl
    {
        public HtmlEditor()
        {


            dataUpdate = 0;

            InitializeComponent();

            this.txtSource.ShowEOLMarkers = false;
            txtSource.ShowHRuler = false;
            txtSource.ShowInvalidLines = false;
            txtSource.ShowMatchingBracket = true;
            txtSource.ShowSpaces = false;
            txtSource.ShowTabs = false;
            txtSource.ShowVRuler = false;
            txtSource.LineViewerStyle = LineViewerStyle.None;
            txtSource.AllowCaretBeyondEOL = false;
            txtSource.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("HTML");
            txtSource.Encoding = Encoding.GetEncoding("GB2312");

            InitializeControls();
            //Bitmap bitmaps = HFBBS.Properties.Resources.editorToolbar1;
            //imageList1.ImageSize = new Size(20, 20);
            //imageList1.Images.AddStrip(bitmaps);
            //this.toolStripButtonBold.Image = imageList1.Images[0];

            this.Load += new EventHandler(HtmlEditor_Load);


        }

        public void SetScriptingForm(Form form)
        {
            webBrowserBody.ObjectForScripting = form;
        }

        public void NotifyMenuClick(string commad)
        {
            MessageBox.Show(commad);
        }


        void HtmlEditor_Load(object sender, EventArgs e)
        {
            if (this.ContextMenuStrip != null)
            {
                this.webBrowserBody.ContextMenuStrip = this.ContextMenuStrip;
            }
        }


        public void Clear()
        {
            webBrowserBody.Document.InvokeScript("Clear");
        }


        #region 扩展属性

        bool isLoad = false;

        /// <summary>
        /// 获取和设置当前的Html文本
        /// </summary>
        public override string Text
        {
            get
            {
                return webBrowserBody.DocumentText;
            }
            set
            {
                //webBrowserBody.DocumentText = value.Replace("\r\n", "<br>");
                webBrowserBody.Document.InvokeScript("InitPages", new string[] { value });
            }
        }

        public string Html
        {
            get
            {
                var value = webBrowserBody.Document.InvokeScript("GetHtml");
                if (value == null)
                {
                    return "";
                }
                return value.ToString();
            }
            set
            {
                if (value != null)
                {
                    var html = value.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;").Replace("\r\n", "</br>");

                    var pages = html.Split(new string[] { "{{{pager}}}" }, StringSplitOptions.RemoveEmptyEntries);

                    webBrowserBody.Document.InvokeScript("InitPages", pages);
                }
            }
        }

        /// <summary>
        /// 获取选择的文本
        /// </summary>
        public string SelectText
        {
            get
            {
                var value = webBrowserBody.Document.InvokeScript("getSelectText");
                if (value == null)
                {
                    return "";
                }
                return value.ToString();
            }
        }

        /// <summary>
        /// 获取插入的图片名称集合
        /// </summary>
        public string[] Images
        {
            get
            {
                List<string> images = new List<string>();

                foreach (HtmlElement element in webBrowserBody.Document.Images)
                {
                    string image = element.GetAttribute("src");
                    if (!images.Contains(image))
                    {
                        images.Add(image);
                    }
                }

                return images.ToArray();
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 控件初始化
        /// </summary>
        private void InitializeControls()
        {
            BeginUpdate();

            //工具栏
            foreach (FontFamily family in FontFamily.Families)
            {
                toolStripComboBoxName.Items.Add(family.Name);
            }

            toolStripComboBoxSize.Items.AddRange(FontSize.All.ToArray());

            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Pic\\editor.htm"))
            {
                //浏览器
                webBrowserBody.DocumentText = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Pic\\editor.htm", Encoding.GetEncoding("gb2312"));
            }
            else
            {
                webBrowserBody.DocumentText = "";
            }
            webBrowserBody.Document.Click += new HtmlElementEventHandler(webBrowserBody_DocumentClick);
            webBrowserBody.Document.Focusing += new HtmlElementEventHandler(webBrowserBody_DocumentFocusing);
            //webBrowserBody.Document.ExecCommand("EditMode", false, null);
            webBrowserBody.Document.ExecCommand("LiveResize", false, null);
            webBrowserBody.Document.MouseMove += new HtmlElementEventHandler(Document_MouseMove);
            webBrowserBody.Document.MouseUp += new HtmlElementEventHandler(Document_MouseUp);
            EndUpdate();
        }

        void Document_MouseUp(object sender, HtmlElementEventArgs e)
        {
            try
            {
                mshtml.IHTMLDocument2 document = (mshtml.IHTMLDocument2)webBrowserBody.Document.DomDocument;
                SelectedText = (document.selection.createRange() as mshtml.IHTMLTxtRange).text;
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        void Document_MouseMove(object sender, HtmlElementEventArgs e)
        {

        }

        public string SelectedText
        {
            get;
            set;
        }

        /// <summary>
        /// 刷新按钮状态
        /// </summary>
        private void RefreshToolBar()
        {
            BeginUpdate();

            try
            {
                mshtml.IHTMLDocument2 document = (mshtml.IHTMLDocument2)webBrowserBody.Document.DomDocument;

                toolStripComboBoxName.Text = document.queryCommandValue("FontName").ToString();
                toolStripComboBoxSize.SelectedItem = FontSize.Find((int)document.queryCommandValue("FontSize"));
                toolStripButtonBold.Checked = document.queryCommandState("Bold");
                toolStripButtonItalic.Checked = document.queryCommandState("Italic");
                toolStripButtonUnderline.Checked = document.queryCommandState("Underline");

                toolStripButtonNumbers.Checked = document.queryCommandState("InsertOrderedList");
                toolStripButtonBullets.Checked = document.queryCommandState("InsertUnorderedList");

                toolStripButtonLeft.Checked = document.queryCommandState("JustifyLeft");
                toolStripButtonCenter.Checked = document.queryCommandState("JustifyCenter");
                toolStripButtonRight.Checked = document.queryCommandState("JustifyRight");
                toolStripButtonFull.Checked = document.queryCommandState("JustifyFull");

                SelectedText = (document.selection.createRange() as mshtml.IHTMLTxtRange).text;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            finally
            {
                EndUpdate();
            }
        }

        #endregion

        #region 更新相关

        private int dataUpdate;
        private bool Updating
        {
            get
            {
                return dataUpdate != 0;
            }
        }

        private void BeginUpdate()
        {
            ++dataUpdate;
        }
        private void EndUpdate()
        {
            --dataUpdate;
        }

        #endregion

        #region 工具栏

        private void toolStripComboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("FontName", false, toolStripComboBoxName.Text);
        }
        private void toolStripComboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            int size = (toolStripComboBoxSize.SelectedItem == null) ? 1 : (toolStripComboBoxSize.SelectedItem as FontSize).Value;
            webBrowserBody.Document.ExecCommand("FontSize", false, size);
        }
        private void toolStripButtonBold_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("Bold", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonItalic_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("Italic", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonUnderline_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("Underline", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonColor_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            int fontcolor = (int)((mshtml.IHTMLDocument2)webBrowserBody.Document.DomDocument).queryCommandValue("ForeColor");

            ColorDialog dialog = new ColorDialog();
            dialog.Color = Color.FromArgb(0xff, fontcolor & 0xff, (fontcolor >> 8) & 0xff, (fontcolor >> 16) & 0xff);

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string color = dialog.Color.Name;
                if (!dialog.Color.IsNamedColor)
                {
                    color = "#" + color.Remove(0, 2);
                }

                webBrowserBody.Document.ExecCommand("ForeColor", false, color);
            }
            RefreshToolBar();
        }

        private void toolStripButtonNumbers_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("InsertOrderedList", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonBullets_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("InsertUnorderedList", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonOutdent_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("Outdent", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonIndent_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("Indent", false, null);
            RefreshToolBar();
        }

        private void toolStripButtonLeft_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("JustifyLeft", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonCenter_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("JustifyCenter", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonRight_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("JustifyRight", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonFull_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("JustifyFull", false, null);
            RefreshToolBar();
        }

        private void toolStripButtonLine_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("InsertHorizontalRule", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonHyperlink_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("CreateLink", true, null);
            RefreshToolBar();
        }
        private void toolStripButtonPicture_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            var imageSelect = new ImageSelecter();
            if (imageSelect.ShowDialog() == DialogResult.OK)
            {
                ImageForm image = new ImageForm(new ImageModel() { Src = imageSelect.SelectedFile, Title = "", Alt = "" });
                if (image.ShowDialog() == DialogResult.OK)
                {
                    if (!image.ImageModel.Src.Contains("http:"))
                    {
                        image.ImageModel.Src = "file:///" + image.ImageModel.Src.Replace("\\", "/");
                    }

                    var html = string.Format("<p style='text-align:center'><img src='{0}' alt='{1}' title='{2}' /><br/><span class='title'>{2}</span></p>", image.ImageModel.Src, image.ImageModel.Alt, image.ImageModel.Title);
                    this.webBrowserBody.Document.InvokeScript("insertImage", new object[] { html });
                }
            }

            //webBrowserBody.Document.ExecCommand("InsertImage", true, null);
            //RefreshToolBar();
        }

        #endregion

        #region 浏览器

        private void webBrowserBody_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
        }

        private void webBrowserBody_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.IsInputKey)
            {
                return;
            }
            RefreshToolBar();
        }

        private void webBrowserBody_DocumentClick(object sender, HtmlElementEventArgs e)
        {
            RefreshToolBar();
        }

        private void webBrowserBody_DocumentFocusing(object sender, HtmlElementEventArgs e)
        {
            RefreshToolBar();
        }

        #endregion

        #region 字体大小转换

        private class FontSize
        {
            private static List<FontSize> allFontSize = null;
            public static List<FontSize> All
            {
                get
                {
                    if (allFontSize == null)
                    {
                        allFontSize = new List<FontSize>();
                        allFontSize.Add(new FontSize(8, 1));
                        allFontSize.Add(new FontSize(10, 2));
                        allFontSize.Add(new FontSize(12, 3));
                        allFontSize.Add(new FontSize(14, 4));
                        allFontSize.Add(new FontSize(18, 5));
                        allFontSize.Add(new FontSize(24, 6));
                        allFontSize.Add(new FontSize(36, 7));
                    }

                    return allFontSize;
                }
            }

            public static FontSize Find(int value)
            {
                if (value < 1)
                {
                    return All[0];
                }

                if (value > 7)
                {
                    return All[6];
                }

                return All[value - 1];
            }

            private FontSize(int display, int value)
            {
                displaySize = display;
                valueSize = value;
            }

            private int valueSize;
            public int Value
            {
                get
                {
                    return valueSize;
                }
            }

            private int displaySize;
            public int Display
            {
                get
                {
                    return displaySize;
                }
            }

            public override string ToString()
            {
                return displaySize.ToString();
            }
        }

        #endregion

        #region 下拉框

        private class ToolStripComboBoxEx : ToolStripComboBox
        {
            public override Size GetPreferredSize(Size constrainingSize)
            {
                Size size = base.GetPreferredSize(constrainingSize);
                size.Width = Math.Max(Width, 0x20);
                return size;
            }
        }

        #endregion

        private void btnInsetPage_Click(object sender, EventArgs e)
        {
            this.webBrowserBody.Document.InvokeScript("insertPage");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 1)
            {
                this.txtSource.Text = this.Html;
            }
            else
            {
                this.Html = this.txtSource.Text;
            }
        }
    }
}
