namespace Jade.ConfigTool
{
    partial class UrlSelectorPanel
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.radioHref = new System.Windows.Forms.RadioButton();
            this.radionInnerLinks = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.radioMulti = new System.Windows.Forms.RadioButton();
            this.radioOne = new System.Windows.Forms.RadioButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUrlResult = new DevExpress.XtraEditors.MemoEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.xpathesBox = new DevExpress.XtraEditors.ListBoxControl();
            this.startUrlmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtXPath = new DevExpress.XtraEditors.TextEdit();
            this.linkUrlSeniorSetting = new System.Windows.Forms.LinkLabel();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label8 = new System.Windows.Forms.Label();
            this.lblContentTips = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrlResult.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpathesBox)).BeginInit();
            this.startUrlmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtXPath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Controls.Add(this.btnAdd);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.txtUrlResult);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.xpathesBox);
            this.panelControl1.Controls.Add(this.txtXPath);
            this.panelControl1.Controls.Add(this.linkUrlSeniorSetting);
            this.panelControl1.Controls.Add(this.simpleButton4);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.label8);
            this.panelControl1.Controls.Add(this.lblContentTips);
            this.panelControl1.Controls.Add(this.label7);
            this.panelControl1.Controls.Add(this.label6);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(870, 254);
            this.panelControl1.TabIndex = 1;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.radioHref);
            this.panelControl3.Controls.Add(this.radionInnerLinks);
            this.panelControl3.Location = new System.Drawing.Point(86, 30);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(208, 23);
            this.panelControl3.TabIndex = 117;
            // 
            // radioHref
            // 
            this.radioHref.AutoSize = true;
            this.radioHref.Checked = true;
            this.radioHref.Location = new System.Drawing.Point(111, 4);
            this.radioHref.Name = "radioHref";
            this.radioHref.Size = new System.Drawing.Size(73, 18);
            this.radioHref.TabIndex = 106;
            this.radioHref.TabStop = true;
            this.radioHref.Text = "链接网址";
            this.radioHref.UseVisualStyleBackColor = true;
            this.radioHref.CheckedChanged += new System.EventHandler(this.radionInnerLinks_CheckedChanged);
            // 
            // radionInnerLinks
            // 
            this.radionInnerLinks.AutoSize = true;
            this.radionInnerLinks.Location = new System.Drawing.Point(10, 4);
            this.radionInnerLinks.Name = "radionInnerLinks";
            this.radionInnerLinks.Size = new System.Drawing.Size(97, 18);
            this.radionInnerLinks.TabIndex = 98;
            this.radionInnerLinks.Text = "所选框内网址";
            this.radionInnerLinks.UseVisualStyleBackColor = true;
            this.radionInnerLinks.CheckedChanged += new System.EventHandler(this.radionInnerLinks_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 14);
            this.label3.TabIndex = 117;
            this.label3.Text = "匹配模式：";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.radioMulti);
            this.panelControl2.Controls.Add(this.radioOne);
            this.panelControl2.Location = new System.Drawing.Point(373, 30);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(204, 23);
            this.panelControl2.TabIndex = 116;
            // 
            // radioMulti
            // 
            this.radioMulti.AutoSize = true;
            this.radioMulti.Location = new System.Drawing.Point(106, 3);
            this.radioMulti.Name = "radioMulti";
            this.radioMulti.Size = new System.Drawing.Size(73, 18);
            this.radioMulti.TabIndex = 2;
            this.radioMulti.TabStop = true;
            this.radioMulti.Text = "多项匹配";
            this.radioMulti.UseVisualStyleBackColor = true;
            this.radioMulti.CheckedChanged += new System.EventHandler(this.radionInnerLinks_CheckedChanged);
            // 
            // radioOne
            // 
            this.radioOne.AutoSize = true;
            this.radioOne.Checked = true;
            this.radioOne.Location = new System.Drawing.Point(14, 3);
            this.radioOne.Name = "radioOne";
            this.radioOne.Size = new System.Drawing.Size(73, 18);
            this.radioOne.TabIndex = 1;
            this.radioOne.TabStop = true;
            this.radioOne.Text = "单项匹配";
            this.radioOne.UseVisualStyleBackColor = true;
            this.radioOne.CheckedChanged += new System.EventHandler(this.radionInnerLinks_CheckedChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(591, 60);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 21);
            this.btnAdd.TabIndex = 114;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 14);
            this.label2.TabIndex = 113;
            this.label2.Text = "当前XPath：";
            // 
            // txtUrlResult
            // 
            this.txtUrlResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrlResult.Location = new System.Drawing.Point(96, 173);
            this.txtUrlResult.Name = "txtUrlResult";
            this.txtUrlResult.Size = new System.Drawing.Size(750, 69);
            this.txtUrlResult.TabIndex = 112;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 14);
            this.label1.TabIndex = 111;
            this.label1.Text = "已有XPATH：";
            // 
            // xpathesBox
            // 
            this.xpathesBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpathesBox.ContextMenuStrip = this.startUrlmenu;
            this.xpathesBox.Location = new System.Drawing.Point(92, 92);
            this.xpathesBox.Name = "xpathesBox";
            this.xpathesBox.Size = new System.Drawing.Size(754, 53);
            this.xpathesBox.TabIndex = 110;
            // 
            // startUrlmenu
            // 
            this.startUrlmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.清空ToolStripMenuItem});
            this.startUrlmenu.Name = "startUrlmenu";
            this.startUrlmenu.Size = new System.Drawing.Size(95, 70);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.编辑ToolStripMenuItem.Text = "编辑";
            this.编辑ToolStripMenuItem.Click += new System.EventHandler(this.编辑ToolStripMenuItem_Click);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // txtXPath
            // 
            this.txtXPath.Location = new System.Drawing.Point(92, 61);
            this.txtXPath.Name = "txtXPath";
            this.txtXPath.Size = new System.Drawing.Size(493, 20);
            this.txtXPath.TabIndex = 109;
            // 
            // linkUrlSeniorSetting
            // 
            this.linkUrlSeniorSetting.AutoSize = true;
            this.linkUrlSeniorSetting.Location = new System.Drawing.Point(17, 193);
            this.linkUrlSeniorSetting.Name = "linkUrlSeniorSetting";
            this.linkUrlSeniorSetting.Size = new System.Drawing.Size(55, 14);
            this.linkUrlSeniorSetting.TabIndex = 108;
            this.linkUrlSeniorSetting.TabStop = true;
            this.linkUrlSeniorSetting.Text = "高级设置";
            this.linkUrlSeniorSetting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUrlSeniorSetting_LinkClicked);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton4.Location = new System.Drawing.Point(745, 5);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(101, 38);
            this.simpleButton4.TabIndex = 107;
            this.simpleButton4.Text = "点此开始选择";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(669, 60);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(72, 21);
            this.simpleButton1.TabIndex = 105;
            this.simpleButton1.Text = "测试";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 14);
            this.label8.TabIndex = 103;
            this.label8.Text = "选择网址预览:";
            // 
            // lblContentTips
            // 
            this.lblContentTips.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContentTips.AutoSize = true;
            this.lblContentTips.ForeColor = System.Drawing.Color.DarkRed;
            this.lblContentTips.Location = new System.Drawing.Point(17, 10);
            this.lblContentTips.Name = "lblContentTips";
            this.lblContentTips.Size = new System.Drawing.Size(343, 14);
            this.lblContentTips.TabIndex = 95;
            this.lblContentTips.Text = "请用鼠标选择网址所在的框，鼠标移动选择，点击鼠标左键选定";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(94, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(212, 14);
            this.label7.TabIndex = 100;
            this.label7.Text = "** 可设置多个xpath，系统会逐一执行";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 14);
            this.label6.TabIndex = 99;
            this.label6.Text = "选择模式：";
            // 
            // UrlSelectorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "UrlSelectorPanel";
            this.Size = new System.Drawing.Size(870, 254);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrlResult.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpathesBox)).EndInit();
            this.startUrlmenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtXPath.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtXPath;
        private System.Windows.Forms.LinkLabel linkUrlSeniorSetting;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private System.Windows.Forms.RadioButton radioHref;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblContentTips;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radionInnerLinks;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ListBoxControl xpathesBox;
        private DevExpress.XtraEditors.MemoEdit txtUrlResult;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip startUrlmenu;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioMulti;
        private System.Windows.Forms.RadioButton radioOne;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
    }
}
