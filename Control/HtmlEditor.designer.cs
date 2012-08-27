
namespace Jade
{
    partial class HtmlEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HtmlEditor));
            this.toolStripToolBar = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBoxName = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBoxSize = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonBold = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonItalic = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUnderline = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparatorFont = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonNumbers = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBullets = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOutdent = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonIndent = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparatorFormat = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonLeft = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCenter = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFull = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparatorAlign = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonLine = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonHyperlink = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPicture = new System.Windows.Forms.ToolStripButton();
            this.btnInsetPage = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabEditor = new System.Windows.Forms.TabPage();
            this.webBrowserBody = new Com.iFLYTEK.WinForms.Browser.BaseWebBrowser(this.components);
            this.tabSource = new System.Windows.Forms.TabPage();
            this.txtSource = new ICSharpCode.TextEditor.TextEditorControl();
            this.toolStripToolBar.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabEditor.SuspendLayout();
            this.tabSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripToolBar
            // 
            this.toolStripToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripToolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxName,
            this.toolStripComboBoxSize,
            this.toolStripButtonBold,
            this.toolStripButtonItalic,
            this.toolStripButtonUnderline,
            this.toolStripButtonColor,
            this.toolStripSeparatorFont,
            this.toolStripButtonNumbers,
            this.toolStripButtonBullets,
            this.toolStripButtonOutdent,
            this.toolStripButtonIndent,
            this.toolStripSeparatorFormat,
            this.toolStripButtonLeft,
            this.toolStripButtonCenter,
            this.toolStripButtonRight,
            this.toolStripButtonFull,
            this.toolStripSeparatorAlign,
            this.toolStripButtonLine,
            this.toolStripButtonHyperlink,
            this.toolStripButtonPicture,
            this.btnInsetPage});
            this.toolStripToolBar.Location = new System.Drawing.Point(0, 0);
            this.toolStripToolBar.Name = "toolStripToolBar";
            this.toolStripToolBar.Size = new System.Drawing.Size(600, 27);
            this.toolStripToolBar.TabIndex = 1;
            this.toolStripToolBar.Text = "Tool Bar";
            // 
            // toolStripComboBoxName
            // 
            this.toolStripComboBoxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolStripComboBoxName.MaxDropDownItems = 30;
            this.toolStripComboBoxName.Name = "toolStripComboBoxName";
            this.toolStripComboBoxName.Size = new System.Drawing.Size(100, 27);
            this.toolStripComboBoxName.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxName_SelectedIndexChanged);
            // 
            // toolStripComboBoxSize
            // 
            this.toolStripComboBoxSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolStripComboBoxSize.Name = "toolStripComboBoxSize";
            this.toolStripComboBoxSize.Size = new System.Drawing.Size(75, 27);
            this.toolStripComboBoxSize.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxSize_SelectedIndexChanged);
            // 
            // toolStripButtonBold
            // 
            this.toolStripButtonBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBold.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBold.Image")));
            this.toolStripButtonBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBold.Name = "toolStripButtonBold";
            this.toolStripButtonBold.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonBold.Text = "加粗";
            this.toolStripButtonBold.Click += new System.EventHandler(this.toolStripButtonBold_Click);
            // 
            // toolStripButtonItalic
            // 
            this.toolStripButtonItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonItalic.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonItalic.Image")));
            this.toolStripButtonItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonItalic.Name = "toolStripButtonItalic";
            this.toolStripButtonItalic.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonItalic.Text = "倾斜";
            this.toolStripButtonItalic.Click += new System.EventHandler(this.toolStripButtonItalic_Click);
            // 
            // toolStripButtonUnderline
            // 
            this.toolStripButtonUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUnderline.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUnderline.Image")));
            this.toolStripButtonUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUnderline.Name = "toolStripButtonUnderline";
            this.toolStripButtonUnderline.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonUnderline.Text = "下划线";
            this.toolStripButtonUnderline.Click += new System.EventHandler(this.toolStripButtonUnderline_Click);
            // 
            // toolStripButtonColor
            // 
            this.toolStripButtonColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonColor.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonColor.Image")));
            this.toolStripButtonColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonColor.Name = "toolStripButtonColor";
            this.toolStripButtonColor.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonColor.Text = "字体颜色";
            this.toolStripButtonColor.Click += new System.EventHandler(this.toolStripButtonColor_Click);
            // 
            // toolStripSeparatorFont
            // 
            this.toolStripSeparatorFont.Name = "toolStripSeparatorFont";
            this.toolStripSeparatorFont.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButtonNumbers
            // 
            this.toolStripButtonNumbers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNumbers.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNumbers.Image")));
            this.toolStripButtonNumbers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNumbers.Name = "toolStripButtonNumbers";
            this.toolStripButtonNumbers.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonNumbers.Text = "Format Numbers";
            this.toolStripButtonNumbers.Click += new System.EventHandler(this.toolStripButtonNumbers_Click);
            // 
            // toolStripButtonBullets
            // 
            this.toolStripButtonBullets.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBullets.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBullets.Image")));
            this.toolStripButtonBullets.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBullets.Name = "toolStripButtonBullets";
            this.toolStripButtonBullets.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonBullets.Text = "Format Bullets";
            this.toolStripButtonBullets.Click += new System.EventHandler(this.toolStripButtonBullets_Click);
            // 
            // toolStripButtonOutdent
            // 
            this.toolStripButtonOutdent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOutdent.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOutdent.Image")));
            this.toolStripButtonOutdent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOutdent.Name = "toolStripButtonOutdent";
            this.toolStripButtonOutdent.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonOutdent.Text = "减少缩进";
            this.toolStripButtonOutdent.Click += new System.EventHandler(this.toolStripButtonOutdent_Click);
            // 
            // toolStripButtonIndent
            // 
            this.toolStripButtonIndent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonIndent.Image = global::Jade.Properties.Resources._020;
            this.toolStripButtonIndent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonIndent.Name = "toolStripButtonIndent";
            this.toolStripButtonIndent.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonIndent.Text = "增加缩进";
            this.toolStripButtonIndent.Click += new System.EventHandler(this.toolStripButtonIndent_Click);
            // 
            // toolStripSeparatorFormat
            // 
            this.toolStripSeparatorFormat.Name = "toolStripSeparatorFormat";
            this.toolStripSeparatorFormat.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButtonLeft
            // 
            this.toolStripButtonLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLeft.Image = global::Jade.Properties.Resources._023;
            this.toolStripButtonLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLeft.Name = "toolStripButtonLeft";
            this.toolStripButtonLeft.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonLeft.Text = "左对齐";
            this.toolStripButtonLeft.Click += new System.EventHandler(this.toolStripButtonLeft_Click);
            // 
            // toolStripButtonCenter
            // 
            this.toolStripButtonCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCenter.Image = global::Jade.Properties.Resources._021;
            this.toolStripButtonCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCenter.Name = "toolStripButtonCenter";
            this.toolStripButtonCenter.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonCenter.Text = "剧中对齐";
            this.toolStripButtonCenter.Click += new System.EventHandler(this.toolStripButtonCenter_Click);
            // 
            // toolStripButtonRight
            // 
            this.toolStripButtonRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRight.Image = global::Jade.Properties.Resources._024;
            this.toolStripButtonRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRight.Name = "toolStripButtonRight";
            this.toolStripButtonRight.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonRight.Text = "右对齐";
            this.toolStripButtonRight.Click += new System.EventHandler(this.toolStripButtonRight_Click);
            // 
            // toolStripButtonFull
            // 
            this.toolStripButtonFull.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFull.Image = global::Jade.Properties.Resources._022;
            this.toolStripButtonFull.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFull.Name = "toolStripButtonFull";
            this.toolStripButtonFull.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonFull.Text = "Justify";
            this.toolStripButtonFull.Click += new System.EventHandler(this.toolStripButtonFull_Click);
            // 
            // toolStripSeparatorAlign
            // 
            this.toolStripSeparatorAlign.Name = "toolStripSeparatorAlign";
            this.toolStripSeparatorAlign.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButtonLine
            // 
            this.toolStripButtonLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLine.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLine.Image")));
            this.toolStripButtonLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLine.Name = "toolStripButtonLine";
            this.toolStripButtonLine.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonLine.Text = "插入直线";
            this.toolStripButtonLine.Click += new System.EventHandler(this.toolStripButtonLine_Click);
            // 
            // toolStripButtonHyperlink
            // 
            this.toolStripButtonHyperlink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonHyperlink.Image = global::Jade.Properties.Resources._025;
            this.toolStripButtonHyperlink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHyperlink.Name = "toolStripButtonHyperlink";
            this.toolStripButtonHyperlink.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonHyperlink.Text = "插入链接";
            this.toolStripButtonHyperlink.Click += new System.EventHandler(this.toolStripButtonHyperlink_Click);
            // 
            // toolStripButtonPicture
            // 
            this.toolStripButtonPicture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPicture.Image = global::Jade.Properties.Resources._019;
            this.toolStripButtonPicture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPicture.Name = "toolStripButtonPicture";
            this.toolStripButtonPicture.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonPicture.Text = "插入图片";
            this.toolStripButtonPicture.Click += new System.EventHandler(this.toolStripButtonPicture_Click);
            // 
            // btnInsetPage
            // 
            this.btnInsetPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInsetPage.Image = global::Jade.Properties.Resources._20;
            this.btnInsetPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInsetPage.Name = "btnInsetPage";
            this.btnInsetPage.Size = new System.Drawing.Size(24, 24);
            this.btnInsetPage.Text = "插入分页";
            this.btnInsetPage.Click += new System.EventHandler(this.btnInsetPage_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabEditor);
            this.tabControl1.Controls.Add(this.tabSource);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(600, 423);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabEditor
            // 
            this.tabEditor.Controls.Add(this.webBrowserBody);
            this.tabEditor.Location = new System.Drawing.Point(4, 25);
            this.tabEditor.Name = "tabEditor";
            this.tabEditor.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditor.Size = new System.Drawing.Size(592, 394);
            this.tabEditor.TabIndex = 0;
            this.tabEditor.Text = "编辑器";
            this.tabEditor.UseVisualStyleBackColor = true;
            // 
            // webBrowserBody
            // 
            this.webBrowserBody.AllowWebBrowserDrop = false;
            this.webBrowserBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserBody.IsWebBrowserContextMenuEnabled = false;
            this.webBrowserBody.Location = new System.Drawing.Point(3, 3);
            this.webBrowserBody.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserBody.Name = "webBrowserBody";
            this.webBrowserBody.ScriptErrorsSuppressed = true;
            this.webBrowserBody.Size = new System.Drawing.Size(586, 388);
            this.webBrowserBody.TabIndex = 0;
            this.webBrowserBody.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowserBody_DocumentCompleted);
            this.webBrowserBody.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.webBrowserBody_PreviewKeyDown);
            // 
            // tabSource
            // 
            this.tabSource.Controls.Add(this.txtSource);
            this.tabSource.Location = new System.Drawing.Point(4, 25);
            this.tabSource.Name = "tabSource";
            this.tabSource.Padding = new System.Windows.Forms.Padding(3);
            this.tabSource.Size = new System.Drawing.Size(592, 394);
            this.tabSource.TabIndex = 1;
            this.tabSource.Text = "源代码";
            this.tabSource.UseVisualStyleBackColor = true;
            // 
            // txtSource
            // 
            this.txtSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSource.IsReadOnly = false;
            this.txtSource.Location = new System.Drawing.Point(3, 3);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(586, 389);
            this.txtSource.TabIndex = 0;
            // 
            // HtmlEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStripToolBar);
            this.Name = "HtmlEditor";
            this.Size = new System.Drawing.Size(600, 450);
            this.toolStripToolBar.ResumeLayout(false);
            this.toolStripToolBar.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabEditor.ResumeLayout(false);
            this.tabSource.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripToolBar;
        private Com.iFLYTEK.WinForms.Browser.BaseWebBrowser webBrowserBody;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxName;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxSize;
        private System.Windows.Forms.ToolStripButton toolStripButtonBold;
        private System.Windows.Forms.ToolStripButton toolStripButtonItalic;
        private System.Windows.Forms.ToolStripButton toolStripButtonUnderline;
        private System.Windows.Forms.ToolStripButton toolStripButtonColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorFont;
        private System.Windows.Forms.ToolStripButton toolStripButtonNumbers;
        private System.Windows.Forms.ToolStripButton toolStripButtonBullets;
        private System.Windows.Forms.ToolStripButton toolStripButtonOutdent;
        private System.Windows.Forms.ToolStripButton toolStripButtonIndent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorFormat;
        private System.Windows.Forms.ToolStripButton toolStripButtonLeft;
        private System.Windows.Forms.ToolStripButton toolStripButtonCenter;
        private System.Windows.Forms.ToolStripButton toolStripButtonRight;
        private System.Windows.Forms.ToolStripButton toolStripButtonFull;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorAlign;
        private System.Windows.Forms.ToolStripButton toolStripButtonLine;
        private System.Windows.Forms.ToolStripButton toolStripButtonHyperlink;
        private System.Windows.Forms.ToolStripButton toolStripButtonPicture;
        private System.Windows.Forms.ToolStripButton btnInsetPage;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEditor;
        private System.Windows.Forms.TabPage tabSource;
        private ICSharpCode.TextEditor.TextEditorControl txtSource;
    }
}
