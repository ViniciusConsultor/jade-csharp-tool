namespace Jade.Forms
{
    partial class XmlPathSelector
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XmlPathSelector));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.iReaperWebBrowser = new Com.iFLYTEK.WinForms.Browser.BaseWebBrowser(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLog = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioMulti = new System.Windows.Forms.RadioButton();
            this.radioOne = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioHref = new System.Windows.Forms.RadioButton();
            this.radionInnerLinks = new System.Windows.Forms.RadioButton();
            this.radioTextWithPic = new System.Windows.Forms.RadioButton();
            this.radioHtml = new System.Windows.Forms.RadioButton();
            this.radioText = new System.Windows.Forms.RadioButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtxmlpath = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.browserToolStrip1 = new Com.iFLYTEK.WinForms.Browser.BrowserToolStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(989, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.文件ToolStripMenuItem.Text = "文件";
            this.文件ToolStripMenuItem.Click += new System.EventHandler(this.文件ToolStripMenuItem_Click);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.iReaperWebBrowser);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(989, 550);
            this.splitContainer1.SplitterDistance = 268;
            this.splitContainer1.TabIndex = 2;
            // 
            // iReaperWebBrowser
            // 
            this.iReaperWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iReaperWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.iReaperWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.iReaperWebBrowser.Name = "iReaperWebBrowser";
            this.iReaperWebBrowser.ScriptErrorsSuppressed = true;
            this.iReaperWebBrowser.Size = new System.Drawing.Size(989, 268);
            this.iReaperWebBrowser.TabIndex = 0;
            this.iReaperWebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.iReaperWebBrowser_DocumentCompleted);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(989, 278);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.statusStrip1);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(981, 253);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "可视化选择";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(3, 228);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(975, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(388, 37);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(585, 186);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblLog);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.radioMulti);
            this.groupBox2.Controls.Add(this.radioOne);
            this.groupBox2.Location = new System.Drawing.Point(9, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 141);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "匹配模式";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(353, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "鼠标移到要选择的节点之上，节点会显示红色边框，左键单击即可";
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLog.ForeColor = System.Drawing.Color.Red;
            this.lblLog.Location = new System.Drawing.Point(22, 86);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(0, 17);
            this.lblLog.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(15, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "多项匹配需要选择同级的节点两次，";
            // 
            // radioMulti
            // 
            this.radioMulti.AutoSize = true;
            this.radioMulti.Location = new System.Drawing.Point(112, 20);
            this.radioMulti.Name = "radioMulti";
            this.radioMulti.Size = new System.Drawing.Size(71, 16);
            this.radioMulti.TabIndex = 2;
            this.radioMulti.TabStop = true;
            this.radioMulti.Text = "多项匹配";
            this.radioMulti.UseVisualStyleBackColor = true;
            this.radioMulti.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioOne
            // 
            this.radioOne.AutoSize = true;
            this.radioOne.Checked = true;
            this.radioOne.Location = new System.Drawing.Point(20, 21);
            this.radioOne.Name = "radioOne";
            this.radioOne.Size = new System.Drawing.Size(71, 16);
            this.radioOne.TabIndex = 1;
            this.radioOne.TabStop = true;
            this.radioOne.Text = "单项匹配";
            this.radioOne.UseVisualStyleBackColor = true;
            this.radioOne.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioHref);
            this.groupBox1.Controls.Add(this.radionInnerLinks);
            this.groupBox1.Controls.Add(this.radioTextWithPic);
            this.groupBox1.Controls.Add(this.radioHtml);
            this.groupBox1.Controls.Add(this.radioText);
            this.groupBox1.Location = new System.Drawing.Point(9, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 46);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择";
            // 
            // radioHref
            // 
            this.radioHref.AutoSize = true;
            this.radioHref.Location = new System.Drawing.Point(282, 20);
            this.radioHref.Name = "radioHref";
            this.radioHref.Size = new System.Drawing.Size(71, 16);
            this.radioHref.TabIndex = 4;
            this.radioHref.TabStop = true;
            this.radioHref.Text = "链接地址";
            this.radioHref.UseVisualStyleBackColor = true;
            this.radioHref.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radionInnerLinks
            // 
            this.radionInnerLinks.AutoSize = true;
            this.radionInnerLinks.Location = new System.Drawing.Point(201, 20);
            this.radionInnerLinks.Name = "radionInnerLinks";
            this.radionInnerLinks.Size = new System.Drawing.Size(71, 16);
            this.radionInnerLinks.TabIndex = 3;
            this.radionInnerLinks.TabStop = true;
            this.radionInnerLinks.Text = "框内链接";
            this.radionInnerLinks.UseVisualStyleBackColor = true;
            this.radionInnerLinks.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioTextWithPic
            // 
            this.radioTextWithPic.AutoSize = true;
            this.radioTextWithPic.Checked = true;
            this.radioTextWithPic.Location = new System.Drawing.Point(112, 20);
            this.radioTextWithPic.Name = "radioTextWithPic";
            this.radioTextWithPic.Size = new System.Drawing.Size(83, 16);
            this.radioTextWithPic.TabIndex = 2;
            this.radioTextWithPic.TabStop = true;
            this.radioTextWithPic.Text = "带图片文本";
            this.radioTextWithPic.UseVisualStyleBackColor = true;
            this.radioTextWithPic.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioHtml
            // 
            this.radioHtml.AutoSize = true;
            this.radioHtml.Location = new System.Drawing.Point(59, 20);
            this.radioHtml.Name = "radioHtml";
            this.radioHtml.Size = new System.Drawing.Size(47, 16);
            this.radioHtml.TabIndex = 1;
            this.radioHtml.TabStop = true;
            this.radioHtml.Text = "Html";
            this.radioHtml.UseVisualStyleBackColor = true;
            this.radioHtml.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioText
            // 
            this.radioText.AutoSize = true;
            this.radioText.Location = new System.Drawing.Point(6, 20);
            this.radioText.Name = "radioText";
            this.radioText.Size = new System.Drawing.Size(47, 16);
            this.radioText.TabIndex = 0;
            this.radioText.TabStop = true;
            this.radioText.Text = "文本";
            this.radioText.UseVisualStyleBackColor = true;
            this.radioText.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButton1,
            this.toolStripLabel2,
            this.txtxmlpath,
            this.toolStripButton3,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(975, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(29, 28);
            this.toolStripLabel1.Text = "点击";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Jade.Properties.Resources.select;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Text = "开始选择";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(53, 28);
            this.toolStripLabel2.Text = "开始选择";
            // 
            // txtxmlpath
            // 
            this.txtxmlpath.Name = "txtxmlpath";
            this.txtxmlpath.Size = new System.Drawing.Size(520, 31);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::Jade.Properties.Resources.laboratory;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(57, 28);
            this.toolStripButton3.Text = "测试";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::Jade.Properties.Resources.select__1_;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(57, 28);
            this.toolStripButton2.Text = "选定";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // browserToolStrip1
            // 
            this.browserToolStrip1.Location = new System.Drawing.Point(0, 24);
            this.browserToolStrip1.Name = "browserToolStrip1";
            this.browserToolStrip1.Size = new System.Drawing.Size(989, 25);
            this.browserToolStrip1.TabIndex = 1;
            this.browserToolStrip1.Text = "browserToolStrip1";
            this.browserToolStrip1.WbForm = null;
            // 
            // XmlPathSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 599);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.browserToolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "XmlPathSelector";
            this.Text = "可视化选择";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.XmlPathSelector_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private Com.iFLYTEK.WinForms.Browser.BrowserToolStrip browserToolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Com.iFLYTEK.WinForms.Browser.BaseWebBrowser iReaperWebBrowser;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripTextBox txtxmlpath;
        private System.Windows.Forms.RadioButton radioText;
        private System.Windows.Forms.RadioButton radioHref;
        private System.Windows.Forms.RadioButton radionInnerLinks;
        private System.Windows.Forms.RadioButton radioTextWithPic;
        private System.Windows.Forms.RadioButton radioHtml;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioMulti;
        private System.Windows.Forms.RadioButton radioOne;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}