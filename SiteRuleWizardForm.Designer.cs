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
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.welcomeWizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.wizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.textEdit1.Location = new System.Drawing.Point(76, 58);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(343, 20);
            this.textEdit1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 58);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "任务名称：";
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.comboBoxEdit1);
            this.wizardPage1.Controls.Add(this.comboBox1);
            this.wizardPage1.Controls.Add(this.panel1);
            this.wizardPage1.Controls.Add(this.startUrlWebBrowser);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(797, 367);
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(174, 0);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Size = new System.Drawing.Size(323, 20);
            this.comboBoxEdit1.TabIndex = 102;
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(46, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 22);
            this.comboBox1.TabIndex = 101;
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
            this.label10.Location = new System.Drawing.Point(18, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 14);
            this.label10.TabIndex = 98;
            this.label10.Text = "选择模式：";
            // 
            // lblStartUrlLoger
            // 
            this.lblStartUrlLoger.AutoSize = true;
            this.lblStartUrlLoger.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStartUrlLoger.Location = new System.Drawing.Point(311, 25);
            this.lblStartUrlLoger.Name = "lblStartUrlLoger";
            this.lblStartUrlLoger.Size = new System.Drawing.Size(295, 14);
            this.lblStartUrlLoger.TabIndex = 95;
            this.lblStartUrlLoger.Text = "请用鼠标选择分页链接，鼠标移动切换，左键点击选定";
            // 
            // lbxUrls
            // 
            this.lbxUrls.FormattingEnabled = true;
            this.lbxUrls.ItemHeight = 14;
            this.lbxUrls.Location = new System.Drawing.Point(113, 67);
            this.lbxUrls.Name = "lbxUrls";
            this.lbxUrls.Size = new System.Drawing.Size(827, 88);
            this.lbxUrls.TabIndex = 87;
            // 
            // btnSelectStartUrl
            // 
            this.btnSelectStartUrl.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSelectStartUrl.Location = new System.Drawing.Point(806, 18);
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
            this.radioLinkHref.Location = new System.Drawing.Point(193, 21);
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
            this.label5.Location = new System.Drawing.Point(24, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 14);
            this.label5.TabIndex = 89;
            this.label5.Text = "最终起始页面:";
            // 
            // radioInnerLinks
            // 
            this.radioInnerLinks.AutoSize = true;
            this.radioInnerLinks.Location = new System.Drawing.Point(92, 21);
            this.radioInnerLinks.Name = "radioInnerLinks";
            this.radioInnerLinks.Size = new System.Drawing.Size(97, 18);
            this.radioInnerLinks.TabIndex = 96;
            this.radioInnerLinks.Text = "所选框内网址";
            this.radioInnerLinks.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(43, 118);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 14);
            this.linkLabel1.TabIndex = 90;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "高级设置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 14);
            this.label3.TabIndex = 94;
            this.label3.Text = "可视化路径：";
            // 
            // txtStartUrlXPath
            // 
            this.txtStartUrlXPath.Location = new System.Drawing.Point(113, 40);
            this.txtStartUrlXPath.Name = "txtStartUrlXPath";
            this.txtStartUrlXPath.Size = new System.Drawing.Size(495, 22);
            this.txtStartUrlXPath.TabIndex = 93;
            // 
            // startUrlWebBrowser
            // 
            this.startUrlWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.startUrlWebBrowser.Location = new System.Drawing.Point(0, 25);
            this.startUrlWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.startUrlWebBrowser.Name = "startUrlWebBrowser";
            this.startUrlWebBrowser.ScriptErrorsSuppressed = true;
            this.startUrlWebBrowser.Size = new System.Drawing.Size(800, 195);
            this.startUrlWebBrowser.TabIndex = 6;
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.Size = new System.Drawing.Size(612, 379);
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
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}