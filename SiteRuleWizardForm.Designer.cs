namespace Jade
{
    partial class SiteRuleWizardForm
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
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.txtStartUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.startUrlWebBrowser = new Com.iFLYTEK.WinForms.Browser.BaseWebBrowser(this.components);
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.linkLabel6 = new System.Windows.Forms.LinkLabel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.chkIntervalTask = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.welcomeWizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.wizardPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.CancelText = "取消";
            this.wizardControl1.Controls.Add(this.welcomeWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage1);
            this.wizardControl1.Controls.Add(this.completionWizardPage1);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.NextText = "下一步&N >";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wizardPage1,
            this.completionWizardPage1});
            this.wizardControl1.PreviousText = "< 返回(&B)";
            this.wizardControl1.Size = new System.Drawing.Size(829, 512);
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.Controls.Add(this.groupBox1);
            this.welcomeWizardPage1.Controls.Add(this.textEdit1);
            this.welcomeWizardPage1.Controls.Add(this.labelControl1);
            this.welcomeWizardPage1.IntroductionText = "通过向导，你将轻松创建一个站点规则\r\n首先，请填写站点名称，这个名称是你完全自定义的，可以是真实名称，也可以是你自己定义的名称";
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.ProceedText = "请点击下一步继续";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(612, 379);
            this.welcomeWizardPage1.Text = "欢迎来到任务规则创建向导";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(82, 42);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(343, 20);
            this.textEdit1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 45);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "任务名称：";
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.txtStartUrl);
            this.wizardPage1.Controls.Add(this.label1);
            this.wizardPage1.Controls.Add(this.panel1);
            this.wizardPage1.Controls.Add(this.startUrlWebBrowser);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(797, 367);
            // 
            // txtStartUrl
            // 
            this.txtStartUrl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.txtStartUrl.Location = new System.Drawing.Point(76, 1);
            this.txtStartUrl.Name = "txtStartUrl";
            this.txtStartUrl.Size = new System.Drawing.Size(715, 22);
            this.txtStartUrl.TabIndex = 102;
            this.txtStartUrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStartUrl_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 101;
            this.label1.Text = "起始地址：";
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
            this.panel1.Location = new System.Drawing.Point(0, 226);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 141);
            this.panel1.TabIndex = 100;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 14);
            this.label10.TabIndex = 98;
            this.label10.Text = "选择模式：";
            // 
            // lblStartUrlLoger
            // 
            this.lblStartUrlLoger.AutoSize = true;
            this.lblStartUrlLoger.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStartUrlLoger.Location = new System.Drawing.Point(297, 8);
            this.lblStartUrlLoger.Name = "lblStartUrlLoger";
            this.lblStartUrlLoger.Size = new System.Drawing.Size(295, 14);
            this.lblStartUrlLoger.TabIndex = 95;
            this.lblStartUrlLoger.Text = "请用鼠标选择分页链接，鼠标移动切换，左键点击选定";
            // 
            // lbxUrls
            // 
            this.lbxUrls.FormattingEnabled = true;
            this.lbxUrls.ItemHeight = 14;
            this.lbxUrls.Location = new System.Drawing.Point(99, 50);
            this.lbxUrls.Name = "lbxUrls";
            this.lbxUrls.Size = new System.Drawing.Size(827, 74);
            this.lbxUrls.TabIndex = 87;
            // 
            // btnSelectStartUrl
            // 
            this.btnSelectStartUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectStartUrl.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSelectStartUrl.Location = new System.Drawing.Point(668, 2);
            this.btnSelectStartUrl.Name = "btnSelectStartUrl";
            this.btnSelectStartUrl.Size = new System.Drawing.Size(125, 38);
            this.btnSelectStartUrl.TabIndex = 88;
            this.btnSelectStartUrl.Text = "点此开始选择";
            this.btnSelectStartUrl.UseVisualStyleBackColor = true;
            // 
            // radioLinkHref
            // 
            this.radioLinkHref.AutoSize = true;
            this.radioLinkHref.Checked = true;
            this.radioLinkHref.Location = new System.Drawing.Point(179, 4);
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
            this.label5.Location = new System.Drawing.Point(10, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 14);
            this.label5.TabIndex = 89;
            this.label5.Text = "最终起始页面:";
            // 
            // radioInnerLinks
            // 
            this.radioInnerLinks.AutoSize = true;
            this.radioInnerLinks.Location = new System.Drawing.Point(78, 4);
            this.radioInnerLinks.Name = "radioInnerLinks";
            this.radioInnerLinks.Size = new System.Drawing.Size(97, 18);
            this.radioInnerLinks.TabIndex = 96;
            this.radioInnerLinks.Text = "所选框内网址";
            this.radioInnerLinks.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(29, 101);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 14);
            this.linkLabel1.TabIndex = 90;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "高级设置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 14);
            this.label3.TabIndex = 94;
            this.label3.Text = "可视化路径：";
            // 
            // txtStartUrlXPath
            // 
            this.txtStartUrlXPath.Location = new System.Drawing.Point(99, 23);
            this.txtStartUrlXPath.Name = "txtStartUrlXPath";
            this.txtStartUrlXPath.Size = new System.Drawing.Size(495, 22);
            this.txtStartUrlXPath.TabIndex = 93;
            // 
            // startUrlWebBrowser
            // 
            this.startUrlWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.startUrlWebBrowser.Location = new System.Drawing.Point(6, 27);
            this.startUrlWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.startUrlWebBrowser.Name = "startUrlWebBrowser";
            this.startUrlWebBrowser.ScriptErrorsSuppressed = true;
            this.startUrlWebBrowser.Size = new System.Drawing.Size(785, 195);
            this.startUrlWebBrowser.TabIndex = 6;
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.Size = new System.Drawing.Size(612, 379);
            // 
            // linkLabel6
            // 
            this.linkLabel6.AutoSize = true;
            this.linkLabel6.Location = new System.Drawing.Point(247, 86);
            this.linkLabel6.Name = "linkLabel6";
            this.linkLabel6.Size = new System.Drawing.Size(31, 14);
            this.linkLabel6.TabIndex = 24;
            this.linkLabel6.TabStop = true;
            this.linkLabel6.Text = "一周";
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Location = new System.Drawing.Point(203, 86);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(31, 14);
            this.linkLabel5.TabIndex = 23;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "一天";
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(168, 86);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(31, 14);
            this.linkLabel4.TabIndex = 22;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "半天";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(118, 86);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(38, 14);
            this.linkLabel2.TabIndex = 21;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "1小时";
            // 
            // txtInterval
            // 
            this.txtInterval.AcceptsReturn = true;
            this.txtInterval.Location = new System.Drawing.Point(118, 58);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(158, 22);
            this.txtInterval.TabIndex = 20;
            this.txtInterval.Text = "360";
            // 
            // chkIntervalTask
            // 
            this.chkIntervalTask.AutoSize = true;
            this.chkIntervalTask.Location = new System.Drawing.Point(122, 20);
            this.chkIntervalTask.Name = "chkIntervalTask";
            this.chkIntervalTask.Size = new System.Drawing.Size(98, 18);
            this.chkIntervalTask.TabIndex = 19;
            this.chkIntervalTask.Text = "开启定时执行";
            this.chkIntervalTask.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(35, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 14);
            this.label12.TabIndex = 18;
            this.label12.Text = "执行周期：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(35, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 14);
            this.label14.TabIndex = 17;
            this.label14.Text = "定时执行：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.linkLabel6);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.linkLabel5);
            this.groupBox1.Controls.Add(this.chkIntervalTask);
            this.groupBox1.Controls.Add(this.linkLabel4);
            this.groupBox1.Controls.Add(this.txtInterval);
            this.groupBox1.Controls.Add(this.linkLabel2);
            this.groupBox1.Location = new System.Drawing.Point(15, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 125);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "定时执行";
            // 
            // SiteRuleWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 512);
            this.Controls.Add(this.wizardControl1);
            this.Name = "SiteRuleWizardForm";
            this.Text = "站点规则添加";
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.welcomeWizardPage1.ResumeLayout(false);
            this.welcomeWizardPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.wizardPage1.ResumeLayout(false);
            this.wizardPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStartUrl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.LinkLabel linkLabel6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.CheckBox chkIntervalTask;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}