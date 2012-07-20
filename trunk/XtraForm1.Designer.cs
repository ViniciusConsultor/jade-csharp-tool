namespace Jade
{
    partial class XtraForm1
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
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.wizardPage2 = new DevExpress.XtraWizard.WizardPage();
            this.wizardPage3 = new DevExpress.XtraWizard.WizardPage();
            this.wizardPage4 = new DevExpress.XtraWizard.WizardPage();
            this.wizardPage5 = new DevExpress.XtraWizard.WizardPage();
            this.startUrlWebBrowser = new Com.iFLYTEK.WinForms.Browser.BaseWebBrowser(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.lblStartUrlLoger = new System.Windows.Forms.Label();
            this.lbxUrls = new System.Windows.Forms.ListBox();
            this.btnSelectStartUrl = new System.Windows.Forms.Button();
            this.radioLinkHref = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.radioInnerLinks = new System.Windows.Forms.RadioButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStartUrlXPath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.wizardPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.Controls.Add(this.welcomeWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage1);
            this.wizardControl1.Controls.Add(this.completionWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage2);
            this.wizardControl1.Controls.Add(this.wizardPage3);
            this.wizardControl1.Controls.Add(this.wizardPage4);
            this.wizardControl1.Controls.Add(this.wizardPage5);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wizardPage1,
            this.wizardPage2,
            this.wizardPage3,
            this.wizardPage4,
            this.wizardPage5,
            this.completionWizardPage1});
            this.wizardControl1.Size = new System.Drawing.Size(1112, 502);
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(895, 369);
            // 
            // wizardPage1
            // 
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(1080, 357);
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.Size = new System.Drawing.Size(895, 369);
            // 
            // wizardPage2
            // 
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(1080, 357);
            // 
            // wizardPage3
            // 
            this.wizardPage3.Controls.Add(this.panel1);
            this.wizardPage3.Controls.Add(this.startUrlWebBrowser);
            this.wizardPage3.Name = "wizardPage3";
            this.wizardPage3.Size = new System.Drawing.Size(1080, 357);
            // 
            // wizardPage4
            // 
            this.wizardPage4.Name = "wizardPage4";
            this.wizardPage4.Size = new System.Drawing.Size(1080, 357);
            // 
            // wizardPage5
            // 
            this.wizardPage5.Name = "wizardPage5";
            this.wizardPage5.Size = new System.Drawing.Size(1080, 357);
            // 
            // startUrlWebBrowser
            // 
            this.startUrlWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.startUrlWebBrowser.Location = new System.Drawing.Point(8, 8);
            this.startUrlWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.startUrlWebBrowser.Name = "startUrlWebBrowser";
            this.startUrlWebBrowser.ScriptErrorsSuppressed = true;
            this.startUrlWebBrowser.Size = new System.Drawing.Size(1069, 212);
            this.startUrlWebBrowser.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lblStartUrlLoger);
            this.panel1.Controls.Add(this.lbxUrls);
            this.panel1.Controls.Add(this.btnSelectStartUrl);
            this.panel1.Controls.Add(this.radioLinkHref);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.radioInnerLinks);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtStartUrlXPath);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 233);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1080, 124);
            this.panel1.TabIndex = 100;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 14);
            this.label10.TabIndex = 98;
            this.label10.Text = "选择模式：";
            // 
            // lblStartUrlLoger
            // 
            this.lblStartUrlLoger.AutoSize = true;
            this.lblStartUrlLoger.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStartUrlLoger.Location = new System.Drawing.Point(309, 8);
            this.lblStartUrlLoger.Name = "lblStartUrlLoger";
            this.lblStartUrlLoger.Size = new System.Drawing.Size(295, 14);
            this.lblStartUrlLoger.TabIndex = 95;
            this.lblStartUrlLoger.Text = "请用鼠标选择分页链接，鼠标移动切换，左键点击选定";
            // 
            // lbxUrls
            // 
            this.lbxUrls.FormattingEnabled = true;
            this.lbxUrls.ItemHeight = 14;
            this.lbxUrls.Location = new System.Drawing.Point(111, 50);
            this.lbxUrls.Name = "lbxUrls";
            this.lbxUrls.Size = new System.Drawing.Size(827, 60);
            this.lbxUrls.TabIndex = 87;
            // 
            // btnSelectStartUrl
            // 
            this.btnSelectStartUrl.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSelectStartUrl.Location = new System.Drawing.Point(804, 1);
            this.btnSelectStartUrl.Name = "btnSelectStartUrl";
            this.btnSelectStartUrl.Size = new System.Drawing.Size(125, 45);
            this.btnSelectStartUrl.TabIndex = 88;
            this.btnSelectStartUrl.Text = "点此开始选择";
            this.btnSelectStartUrl.UseVisualStyleBackColor = true;
            // 
            // radioLinkHref
            // 
            this.radioLinkHref.AutoSize = true;
            this.radioLinkHref.Checked = true;
            this.radioLinkHref.Location = new System.Drawing.Point(191, 4);
            this.radioLinkHref.Name = "radioLinkHref";
            this.radioLinkHref.Size = new System.Drawing.Size(73, 18);
            this.radioLinkHref.TabIndex = 97;
            this.radioLinkHref.TabStop = true;
            this.radioLinkHref.Text = "链接网址";
            this.radioLinkHref.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 14);
            this.label5.TabIndex = 89;
            this.label5.Text = "最终起始页面:";
            // 
            // radioInnerLinks
            // 
            this.radioInnerLinks.AutoSize = true;
            this.radioInnerLinks.Location = new System.Drawing.Point(90, 4);
            this.radioInnerLinks.Name = "radioInnerLinks";
            this.radioInnerLinks.Size = new System.Drawing.Size(97, 18);
            this.radioInnerLinks.TabIndex = 96;
            this.radioInnerLinks.Text = "所选框内网址";
            this.radioInnerLinks.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(39, 89);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 14);
            this.linkLabel1.TabIndex = 90;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "高级设置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 14);
            this.label3.TabIndex = 94;
            this.label3.Text = "可视化路径：";
            // 
            // txtStartUrlXPath
            // 
            this.txtStartUrlXPath.Location = new System.Drawing.Point(111, 23);
            this.txtStartUrlXPath.Name = "txtStartUrlXPath";
            this.txtStartUrlXPath.Size = new System.Drawing.Size(495, 22);
            this.txtStartUrlXPath.TabIndex = 93;
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 502);
            this.Controls.Add(this.wizardControl1);
            this.Name = "XtraForm1";
            this.Text = "XtraForm1";
            this.Load += new System.EventHandler(this.XtraForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.wizardPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage2;
        private DevExpress.XtraWizard.WizardPage wizardPage3;
        private DevExpress.XtraWizard.WizardPage wizardPage4;
        private DevExpress.XtraWizard.WizardPage wizardPage5;
        private Com.iFLYTEK.WinForms.Browser.BaseWebBrowser startUrlWebBrowser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblStartUrlLoger;
        private System.Windows.Forms.ListBox lbxUrls;
        private System.Windows.Forms.Button btnSelectStartUrl;
        private System.Windows.Forms.RadioButton radioLinkHref;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioInnerLinks;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStartUrlXPath;
    }
}