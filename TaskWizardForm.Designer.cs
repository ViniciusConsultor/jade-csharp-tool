namespace HFBBS
{
    partial class TaskWizardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskWizardForm));
            this.taskWizard = new WizardBase.WizardControl();
            this.start = new WizardBase.StartStep();
            this.label1 = new System.Windows.Forms.Label();
            this.stepTaskName = new WizardBase.IntermediateStep();
            this.txtRuleName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.stepStartUrl = new WizardBase.IntermediateStep();
            this.lblStartUrlLoger = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.radioLinkHref = new System.Windows.Forms.RadioButton();
            this.radioInnerLinks = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStartUrlXPath = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSelectStartUrl = new System.Windows.Forms.Button();
            this.lbxUrls = new System.Windows.Forms.ListBox();
            this.startUrlmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.浏览ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看代码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblStartUrlLog = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtStartUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.stepContentUrl = new WizardBase.IntermediateStep();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lblContentTips = new System.Windows.Forms.Label();
            this.txtLinkXPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.radioHref = new System.Windows.Forms.RadioButton();
            this.radionInnerLinks = new System.Windows.Forms.RadioButton();
            this.txtUrlResult = new System.Windows.Forms.RichTextBox();
            this.stepTestUrl = new WizardBase.IntermediateStep();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.trvUrlTree = new System.Windows.Forms.TreeView();
            this.btnOutputParentNode = new System.Windows.Forms.Button();
            this.btnOutputChildNode = new System.Windows.Forms.Button();
            this.btnCopyUrlToClipboard = new System.Windows.Forms.Button();
            this.btnFetchUrl = new System.Windows.Forms.Button();
            this.stepItemRule = new WizardBase.IntermediateStep();
            this.tabTitle = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panelItemRule = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panelTxtProcess = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.chkDownloadPic = new System.Windows.Forms.CheckBox();
            this.txtPageXPath = new System.Windows.Forms.TextBox();
            this.chkIdentifyPage = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panelxPath = new System.Windows.Forms.Panel();
            this.lblItemLog = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioMulti = new System.Windows.Forms.RadioButton();
            this.radioOne = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioCHref = new System.Windows.Forms.RadioButton();
            this.radioCInnerLinks = new System.Windows.Forms.RadioButton();
            this.radioTextWithPic = new System.Windows.Forms.RadioButton();
            this.radioHtml = new System.Windows.Forms.RadioButton();
            this.radioText = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCXPath = new System.Windows.Forms.Button();
            this.txtCXpath = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabTime = new System.Windows.Forms.TabPage();
            this.tabSummary = new System.Windows.Forms.TabPage();
            this.tabContent = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tbxItemUrl = new System.Windows.Forms.TextBox();
            this.lblItemUrl = new System.Windows.Forms.Label();
            this.finish = new WizardBase.FinishStep();
            this.button4 = new System.Windows.Forms.Button();
            this.intermediateStep1 = new WizardBase.IntermediateStep();
            this.tbxResult = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.startUrlWebBrowser = new Com.iFLYTEK.WinForms.Browser.BaseWebBrowser(this.components);
            this.contentBrowser = new Com.iFLYTEK.WinForms.Browser.BaseWebBrowser(this.components);
            this.itemWebBrowser = new Com.iFLYTEK.WinForms.Browser.BaseWebBrowser(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.lblItemContentLog = new System.Windows.Forms.Label();
            this.start.SuspendLayout();
            this.stepTaskName.SuspendLayout();
            this.stepStartUrl.SuspendLayout();
            this.startUrlmenu.SuspendLayout();
            this.stepContentUrl.SuspendLayout();
            this.stepTestUrl.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.stepItemRule.SuspendLayout();
            this.tabTitle.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panelItemRule.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panelTxtProcess.SuspendLayout();
            this.panelxPath.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.finish.SuspendLayout();
            this.intermediateStep1.SuspendLayout();
            this.SuspendLayout();
            // 
            // taskWizard
            // 
            this.taskWizard.BackButtonEnabled = true;
            this.taskWizard.BackButtonText = "< 上一步";
            this.taskWizard.BackButtonVisible = true;
            this.taskWizard.CancelButtonEnabled = true;
            this.taskWizard.CancelButtonText = "取消";
            this.taskWizard.CancelButtonVisible = true;
            this.taskWizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskWizard.FinishButtonText = "完成";
            this.taskWizard.HelpButtonEnabled = true;
            this.taskWizard.HelpButtonText = "帮助";
            this.taskWizard.HelpButtonVisible = true;
            this.taskWizard.Location = new System.Drawing.Point(0, 0);
            this.taskWizard.Name = "taskWizard";
            this.taskWizard.NextButtonEnabled = true;
            this.taskWizard.NextButtonText = "下一步 >";
            this.taskWizard.NextButtonVisible = true;
            this.taskWizard.Size = new System.Drawing.Size(958, 606);
            this.taskWizard.WizardSteps.Add(this.start);
            this.taskWizard.WizardSteps.Add(this.stepTaskName);
            this.taskWizard.WizardSteps.Add(this.stepStartUrl);
            this.taskWizard.WizardSteps.Add(this.stepContentUrl);
            this.taskWizard.WizardSteps.Add(this.stepTestUrl);
            this.taskWizard.WizardSteps.Add(this.stepItemRule);
            this.taskWizard.WizardSteps.Add(this.intermediateStep1);
            this.taskWizard.WizardSteps.Add(this.finish);
            this.taskWizard.BackButtonClick += new WizardBase.WizardClickEventHandler(this.taskWizard_BackButtonClick);
            this.taskWizard.CancelButtonClick += new System.EventHandler(this.taskWizard_CancelButtonClick);
            this.taskWizard.FinishButtonClick += new System.EventHandler(this.taskWizard_FinishButtonClick);
            this.taskWizard.NextButtonClick += new WizardBase.WizardNextButtonClickEventHandler(this.taskWizard_NextButtonClick);
            // 
            // start
            // 
            this.start.BindingImage = ((System.Drawing.Image)(resources.GetObject("start.BindingImage")));
            this.start.Controls.Add(this.label1);
            this.start.Icon = ((System.Drawing.Image)(resources.GetObject("start.Icon")));
            this.start.Name = "start";
            this.start.Subtitle = "请按照向导完成规则设置";
            this.start.SubtitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.start.Title = "欢迎来到任务规则编写向导";
            this.start.TitleFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "你将体验到令人耳目一新的轻松规则设置，简单几部，完成负责的规则设置";
            // 
            // stepTaskName
            // 
            this.stepTaskName.BindingImage = ((System.Drawing.Image)(resources.GetObject("stepTaskName.BindingImage")));
            this.stepTaskName.Controls.Add(this.txtRuleName);
            this.stepTaskName.Controls.Add(this.label4);
            this.stepTaskName.Name = "stepTaskName";
            this.stepTaskName.Subtitle = "请填写任务基本信息";
            this.stepTaskName.SubtitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.stepTaskName.Title = "任务基本信息";
            this.stepTaskName.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            // 
            // txtRuleName
            // 
            this.txtRuleName.Location = new System.Drawing.Point(96, 90);
            this.txtRuleName.Name = "txtRuleName";
            this.txtRuleName.Size = new System.Drawing.Size(293, 21);
            this.txtRuleName.TabIndex = 3;
            this.txtRuleName.Text = "HFPTA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "任务名称：";
            // 
            // stepStartUrl
            // 
            this.stepStartUrl.BindingImage = ((System.Drawing.Image)(resources.GetObject("stepStartUrl.BindingImage")));
            this.stepStartUrl.Controls.Add(this.lblStartUrlLoger);
            this.stepStartUrl.Controls.Add(this.label10);
            this.stepStartUrl.Controls.Add(this.radioLinkHref);
            this.stepStartUrl.Controls.Add(this.radioInnerLinks);
            this.stepStartUrl.Controls.Add(this.label3);
            this.stepStartUrl.Controls.Add(this.txtStartUrlXPath);
            this.stepStartUrl.Controls.Add(this.linkLabel1);
            this.stepStartUrl.Controls.Add(this.label5);
            this.stepStartUrl.Controls.Add(this.btnSelectStartUrl);
            this.stepStartUrl.Controls.Add(this.lbxUrls);
            this.stepStartUrl.Controls.Add(this.startUrlWebBrowser);
            this.stepStartUrl.Controls.Add(this.lblStartUrlLog);
            this.stepStartUrl.Controls.Add(this.button1);
            this.stepStartUrl.Controls.Add(this.txtStartUrl);
            this.stepStartUrl.Controls.Add(this.label2);
            this.stepStartUrl.Name = "stepStartUrl";
            this.stepStartUrl.Subtitle = "最普遍的采集就是找到一个网站的列表页面，例如新浪国内新闻，当然，新闻很多，因此有分页。所以既需要列表首页，也需要列表的第二页，第三页。。。";
            this.stepStartUrl.SubtitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.stepStartUrl.Title = "起始页面设置";
            this.stepStartUrl.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            // 
            // lblStartUrlLoger
            // 
            this.lblStartUrlLoger.AutoSize = true;
            this.lblStartUrlLoger.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStartUrlLoger.Location = new System.Drawing.Point(317, 428);
            this.lblStartUrlLoger.Name = "lblStartUrlLoger";
            this.lblStartUrlLoger.Size = new System.Drawing.Size(293, 12);
            this.lblStartUrlLoger.TabIndex = 95;
            this.lblStartUrlLoger.Text = "请用鼠标选择分页链接，鼠标移动切换，左键点击选定";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 426);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 98;
            this.label10.Text = "选择模式：";
            // 
            // radioLinkHref
            // 
            this.radioLinkHref.AutoSize = true;
            this.radioLinkHref.Checked = true;
            this.radioLinkHref.Location = new System.Drawing.Point(199, 424);
            this.radioLinkHref.Name = "radioLinkHref";
            this.radioLinkHref.Size = new System.Drawing.Size(71, 16);
            this.radioLinkHref.TabIndex = 97;
            this.radioLinkHref.TabStop = true;
            this.radioLinkHref.Text = "链接网址";
            this.radioLinkHref.UseVisualStyleBackColor = true;
            // 
            // radioInnerLinks
            // 
            this.radioInnerLinks.AutoSize = true;
            this.radioInnerLinks.Location = new System.Drawing.Point(98, 424);
            this.radioInnerLinks.Name = "radioInnerLinks";
            this.radioInnerLinks.Size = new System.Drawing.Size(95, 16);
            this.radioInnerLinks.TabIndex = 96;
            this.radioInnerLinks.Text = "所选框内网址";
            this.radioInnerLinks.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 450);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 94;
            this.label3.Text = "可视化路径：";
            // 
            // txtStartUrlXPath
            // 
            this.txtStartUrlXPath.Location = new System.Drawing.Point(119, 443);
            this.txtStartUrlXPath.Name = "txtStartUrlXPath";
            this.txtStartUrlXPath.Size = new System.Drawing.Size(495, 21);
            this.txtStartUrlXPath.TabIndex = 93;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(49, 521);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 90;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "高级设置";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 498);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 89;
            this.label5.Text = "最终起始页面:";
            // 
            // btnSelectStartUrl
            // 
            this.btnSelectStartUrl.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSelectStartUrl.Location = new System.Drawing.Point(812, 421);
            this.btnSelectStartUrl.Name = "btnSelectStartUrl";
            this.btnSelectStartUrl.Size = new System.Drawing.Size(125, 45);
            this.btnSelectStartUrl.TabIndex = 88;
            this.btnSelectStartUrl.Text = "点此开始选择";
            this.btnSelectStartUrl.UseVisualStyleBackColor = true;
            this.btnSelectStartUrl.Click += new System.EventHandler(this.btnSelectStartUrl_Click);
            // 
            // lbxUrls
            // 
            this.lbxUrls.ContextMenuStrip = this.startUrlmenu;
            this.lbxUrls.FormattingEnabled = true;
            this.lbxUrls.ItemHeight = 12;
            this.lbxUrls.Location = new System.Drawing.Point(119, 470);
            this.lbxUrls.Name = "lbxUrls";
            this.lbxUrls.Size = new System.Drawing.Size(827, 88);
            this.lbxUrls.TabIndex = 87;
            // 
            // startUrlmenu
            // 
            this.startUrlmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.浏览ToolStripMenuItem,
            this.清空ToolStripMenuItem,
            this.查看代码ToolStripMenuItem});
            this.startUrlmenu.Name = "startUrlmenu";
            this.startUrlmenu.Size = new System.Drawing.Size(125, 114);
            this.startUrlmenu.Opening += new System.ComponentModel.CancelEventHandler(this.startUrlmenu_Opening);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.编辑ToolStripMenuItem.Text = "编辑";
            this.编辑ToolStripMenuItem.Click += new System.EventHandler(this.编辑ToolStripMenuItem_Click);
            // 
            // 浏览ToolStripMenuItem
            // 
            this.浏览ToolStripMenuItem.Name = "浏览ToolStripMenuItem";
            this.浏览ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.浏览ToolStripMenuItem.Text = "浏览";
            this.浏览ToolStripMenuItem.Click += new System.EventHandler(this.浏览ToolStripMenuItem_Click);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // 查看代码ToolStripMenuItem
            // 
            this.查看代码ToolStripMenuItem.Name = "查看代码ToolStripMenuItem";
            this.查看代码ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.查看代码ToolStripMenuItem.Text = "查看代码";
            this.查看代码ToolStripMenuItem.Click += new System.EventHandler(this.查看代码ToolStripMenuItem_Click);
            // 
            // lblStartUrlLog
            // 
            this.lblStartUrlLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartUrlLog.AutoSize = true;
            this.lblStartUrlLog.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStartUrlLog.Location = new System.Drawing.Point(3, 423);
            this.lblStartUrlLog.Name = "lblStartUrlLog";
            this.lblStartUrlLog.Size = new System.Drawing.Size(0, 12);
            this.lblStartUrlLog.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(699, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "GO>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtStartUrl
            // 
            this.txtStartUrl.Location = new System.Drawing.Point(119, 79);
            this.txtStartUrl.Name = "txtStartUrl";
            this.txtStartUrl.Size = new System.Drawing.Size(655, 21);
            this.txtStartUrl.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "请输入起始网址：";
            // 
            // stepContentUrl
            // 
            this.stepContentUrl.BindingImage = ((System.Drawing.Image)(resources.GetObject("stepContentUrl.BindingImage")));
            this.stepContentUrl.Controls.Add(this.button4);
            this.stepContentUrl.Controls.Add(this.label8);
            this.stepContentUrl.Controls.Add(this.button2);
            this.stepContentUrl.Controls.Add(this.lblContentTips);
            this.stepContentUrl.Controls.Add(this.txtLinkXPath);
            this.stepContentUrl.Controls.Add(this.label7);
            this.stepContentUrl.Controls.Add(this.label6);
            this.stepContentUrl.Controls.Add(this.radioHref);
            this.stepContentUrl.Controls.Add(this.radionInnerLinks);
            this.stepContentUrl.Controls.Add(this.txtUrlResult);
            this.stepContentUrl.Controls.Add(this.contentBrowser);
            this.stepContentUrl.Name = "stepContentUrl";
            this.stepContentUrl.Subtitle = "内容网址是指内容所在的网页网址，一般从列表页面获取，列表页面就是上一步设置的起始页面和选择的分页页面";
            this.stepContentUrl.SubtitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.stepContentUrl.Title = "内容网址设置";
            this.stepContentUrl.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 520);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 12);
            this.label8.TabIndex = 93;
            this.label8.Text = "选择网址预览:";
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.DarkRed;
            this.button2.Location = new System.Drawing.Point(835, 444);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 47);
            this.button2.TabIndex = 89;
            this.button2.Text = "点此开始选择";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblContentTips
            // 
            this.lblContentTips.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContentTips.AutoSize = true;
            this.lblContentTips.ForeColor = System.Drawing.Color.DarkRed;
            this.lblContentTips.Location = new System.Drawing.Point(311, 449);
            this.lblContentTips.Name = "lblContentTips";
            this.lblContentTips.Size = new System.Drawing.Size(365, 12);
            this.lblContentTips.TabIndex = 5;
            this.lblContentTips.Text = "请用鼠标选择分页网址所在的框，鼠标移动选择，点击鼠标左键选定";
            // 
            // txtLinkXPath
            // 
            this.txtLinkXPath.Location = new System.Drawing.Point(125, 471);
            this.txtLinkXPath.Name = "txtLinkXPath";
            this.txtLinkXPath.Size = new System.Drawing.Size(495, 21);
            this.txtLinkXPath.TabIndex = 92;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 475);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "可视化路径：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 447);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "选择模式：";
            // 
            // radioHref
            // 
            this.radioHref.AutoSize = true;
            this.radioHref.Checked = true;
            this.radioHref.Location = new System.Drawing.Point(193, 445);
            this.radioHref.Name = "radioHref";
            this.radioHref.Size = new System.Drawing.Size(71, 16);
            this.radioHref.TabIndex = 9;
            this.radioHref.TabStop = true;
            this.radioHref.Text = "链接网址";
            this.radioHref.UseVisualStyleBackColor = true;
            // 
            // radionInnerLinks
            // 
            this.radionInnerLinks.AutoSize = true;
            this.radionInnerLinks.Location = new System.Drawing.Point(92, 445);
            this.radionInnerLinks.Name = "radionInnerLinks";
            this.radionInnerLinks.Size = new System.Drawing.Size(95, 16);
            this.radionInnerLinks.TabIndex = 8;
            this.radionInnerLinks.Text = "所选框内网址";
            this.radionInnerLinks.UseVisualStyleBackColor = true;
            // 
            // txtUrlResult
            // 
            this.txtUrlResult.Location = new System.Drawing.Point(125, 498);
            this.txtUrlResult.Name = "txtUrlResult";
            this.txtUrlResult.Size = new System.Drawing.Size(821, 65);
            this.txtUrlResult.TabIndex = 7;
            this.txtUrlResult.Text = "";
            // 
            // stepTestUrl
            // 
            this.stepTestUrl.BindingImage = ((System.Drawing.Image)(resources.GetObject("stepTestUrl.BindingImage")));
            this.stepTestUrl.Controls.Add(this.groupBox6);
            this.stepTestUrl.Name = "stepTestUrl";
            this.stepTestUrl.Subtitle = "在这里你可以确认采集到的内容页网址是否正确，如果正确你可以回到上一步修改规则，如果正确，可以进入下一步";
            this.stepTestUrl.SubtitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.stepTestUrl.Title = "内容页网址确认";
            this.stepTestUrl.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.trvUrlTree);
            this.groupBox6.Controls.Add(this.btnOutputParentNode);
            this.groupBox6.Controls.Add(this.btnOutputChildNode);
            this.groupBox6.Controls.Add(this.btnCopyUrlToClipboard);
            this.groupBox6.Controls.Add(this.btnFetchUrl);
            this.groupBox6.Location = new System.Drawing.Point(12, 74);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(934, 478);
            this.groupBox6.TabIndex = 18;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "网址列表";
            // 
            // trvUrlTree
            // 
            this.trvUrlTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvUrlTree.Location = new System.Drawing.Point(6, 21);
            this.trvUrlTree.Name = "trvUrlTree";
            this.trvUrlTree.Size = new System.Drawing.Size(741, 460);
            this.trvUrlTree.TabIndex = 16;
            // 
            // btnOutputParentNode
            // 
            this.btnOutputParentNode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutputParentNode.Location = new System.Drawing.Point(765, 21);
            this.btnOutputParentNode.Name = "btnOutputParentNode";
            this.btnOutputParentNode.Size = new System.Drawing.Size(163, 41);
            this.btnOutputParentNode.TabIndex = 7;
            this.btnOutputParentNode.Text = "导出根节点";
            this.btnOutputParentNode.UseVisualStyleBackColor = true;
            this.btnOutputParentNode.Click += new System.EventHandler(this.btnOutputParentNode_Click);
            // 
            // btnOutputChildNode
            // 
            this.btnOutputChildNode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutputChildNode.Location = new System.Drawing.Point(768, 80);
            this.btnOutputChildNode.Name = "btnOutputChildNode";
            this.btnOutputChildNode.Size = new System.Drawing.Size(163, 41);
            this.btnOutputChildNode.TabIndex = 8;
            this.btnOutputChildNode.Text = "导出二级节点";
            this.btnOutputChildNode.UseVisualStyleBackColor = true;
            this.btnOutputChildNode.Click += new System.EventHandler(this.btnOutputChildNode_Click);
            // 
            // btnCopyUrlToClipboard
            // 
            this.btnCopyUrlToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyUrlToClipboard.Location = new System.Drawing.Point(765, 140);
            this.btnCopyUrlToClipboard.Name = "btnCopyUrlToClipboard";
            this.btnCopyUrlToClipboard.Size = new System.Drawing.Size(163, 37);
            this.btnCopyUrlToClipboard.TabIndex = 9;
            this.btnCopyUrlToClipboard.Text = "复制网址";
            this.btnCopyUrlToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyUrlToClipboard.Click += new System.EventHandler(this.btnCopyUrlToClipboard_Click);
            // 
            // btnFetchUrl
            // 
            this.btnFetchUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFetchUrl.Location = new System.Drawing.Point(765, 204);
            this.btnFetchUrl.Name = "btnFetchUrl";
            this.btnFetchUrl.Size = new System.Drawing.Size(163, 35);
            this.btnFetchUrl.TabIndex = 12;
            this.btnFetchUrl.Text = "测试该页";
            this.btnFetchUrl.UseVisualStyleBackColor = true;
            this.btnFetchUrl.Click += new System.EventHandler(this.btnFetchUrl_Click);
            // 
            // stepItemRule
            // 
            this.stepItemRule.BindingImage = ((System.Drawing.Image)(resources.GetObject("stepItemRule.BindingImage")));
            this.stepItemRule.Controls.Add(this.itemWebBrowser);
            this.stepItemRule.Controls.Add(this.tabTitle);
            this.stepItemRule.Controls.Add(this.tbxItemUrl);
            this.stepItemRule.Controls.Add(this.lblItemUrl);
            this.stepItemRule.Name = "stepItemRule";
            this.stepItemRule.Subtitle = "在这里可以配置内容页具体的采集规则";
            this.stepItemRule.SubtitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.stepItemRule.Title = "内容页采集规则配置";
            this.stepItemRule.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.stepItemRule.Click += new System.EventHandler(this.stepItemRule_Click);
            // 
            // tabTitle
            // 
            this.tabTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabTitle.Controls.Add(this.tabPage4);
            this.tabTitle.Controls.Add(this.tabPage5);
            this.tabTitle.Controls.Add(this.tabTime);
            this.tabTitle.Controls.Add(this.tabSummary);
            this.tabTitle.Controls.Add(this.tabContent);
            this.tabTitle.Controls.Add(this.tabPage6);
            this.tabTitle.Location = new System.Drawing.Point(6, 403);
            this.tabTitle.Name = "tabTitle";
            this.tabTitle.SelectedIndex = 0;
            this.tabTitle.Size = new System.Drawing.Size(3814, 1888);
            this.tabTitle.TabIndex = 10;
            this.tabTitle.SelectedIndexChanged += new System.EventHandler(this.tabTitle_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panelItemRule);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(3806, 1862);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "标题";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panelItemRule
            // 
            this.panelItemRule.BackColor = System.Drawing.SystemColors.Control;
            this.panelItemRule.Controls.Add(this.groupBox5);
            this.panelItemRule.Controls.Add(this.panelxPath);
            this.panelItemRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelItemRule.Location = new System.Drawing.Point(3, 3);
            this.panelItemRule.Name = "panelItemRule";
            this.panelItemRule.Size = new System.Drawing.Size(3800, 1856);
            this.panelItemRule.TabIndex = 6;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.panelTxtProcess);
            this.groupBox5.Location = new System.Drawing.Point(4, 73);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(770, 67);
            this.groupBox5.TabIndex = 112;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "高级选项";
            // 
            // panelTxtProcess
            // 
            this.panelTxtProcess.Controls.Add(this.button3);
            this.panelTxtProcess.Controls.Add(this.label13);
            this.panelTxtProcess.Controls.Add(this.chkDownloadPic);
            this.panelTxtProcess.Controls.Add(this.txtPageXPath);
            this.panelTxtProcess.Controls.Add(this.chkIdentifyPage);
            this.panelTxtProcess.Controls.Add(this.label15);
            this.panelTxtProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTxtProcess.Location = new System.Drawing.Point(3, 17);
            this.panelTxtProcess.Name = "panelTxtProcess";
            this.panelTxtProcess.Size = new System.Drawing.Size(764, 47);
            this.panelTxtProcess.TabIndex = 111;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(534, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 23);
            this.button3.TabIndex = 97;
            this.button3.Text = "点此开始选择";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 103;
            this.label13.Text = "文本处理：";
            // 
            // chkDownloadPic
            // 
            this.chkDownloadPic.AutoSize = true;
            this.chkDownloadPic.Location = new System.Drawing.Point(99, 4);
            this.chkDownloadPic.Name = "chkDownloadPic";
            this.chkDownloadPic.Size = new System.Drawing.Size(72, 16);
            this.chkDownloadPic.TabIndex = 105;
            this.chkDownloadPic.Text = "下载图片";
            this.chkDownloadPic.UseVisualStyleBackColor = true;
            // 
            // txtPageXPath
            // 
            this.txtPageXPath.Location = new System.Drawing.Point(277, 23);
            this.txtPageXPath.Multiline = true;
            this.txtPageXPath.Name = "txtPageXPath";
            this.txtPageXPath.Size = new System.Drawing.Size(253, 19);
            this.txtPageXPath.TabIndex = 108;
            // 
            // chkIdentifyPage
            // 
            this.chkIdentifyPage.AutoSize = true;
            this.chkIdentifyPage.Location = new System.Drawing.Point(99, 24);
            this.chkIdentifyPage.Name = "chkIdentifyPage";
            this.chkIdentifyPage.Size = new System.Drawing.Size(96, 16);
            this.chkIdentifyPage.TabIndex = 106;
            this.chkIdentifyPage.Text = "内容包含分页";
            this.chkIdentifyPage.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(214, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 107;
            this.label15.Text = "分页路径:";
            // 
            // panelxPath
            // 
            this.panelxPath.Controls.Add(this.lblItemContentLog);
            this.panelxPath.Controls.Add(this.lblItemLog);
            this.panelxPath.Controls.Add(this.groupBox4);
            this.panelxPath.Controls.Add(this.groupBox3);
            this.panelxPath.Controls.Add(this.label9);
            this.panelxPath.Controls.Add(this.btnCXPath);
            this.panelxPath.Controls.Add(this.txtCXpath);
            this.panelxPath.Location = new System.Drawing.Point(4, -3);
            this.panelxPath.Name = "panelxPath";
            this.panelxPath.Size = new System.Drawing.Size(854, 104);
            this.panelxPath.TabIndex = 6;
            // 
            // lblItemLog
            // 
            this.lblItemLog.AutoSize = true;
            this.lblItemLog.Location = new System.Drawing.Point(487, 7);
            this.lblItemLog.Name = "lblItemLog";
            this.lblItemLog.Size = new System.Drawing.Size(0, 12);
            this.lblItemLog.TabIndex = 97;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioMulti);
            this.groupBox4.Controls.Add(this.radioOne);
            this.groupBox4.Location = new System.Drawing.Point(388, 28);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(382, 47);
            this.groupBox4.TabIndex = 96;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "匹配模式";
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
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioCHref);
            this.groupBox3.Controls.Add(this.radioCInnerLinks);
            this.groupBox3.Controls.Add(this.radioTextWithPic);
            this.groupBox3.Controls.Add(this.radioHtml);
            this.groupBox3.Controls.Add(this.radioText);
            this.groupBox3.Location = new System.Drawing.Point(6, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(373, 46);
            this.groupBox3.TabIndex = 95;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "匹配类型";
            // 
            // radioCHref
            // 
            this.radioCHref.AutoSize = true;
            this.radioCHref.Location = new System.Drawing.Point(282, 20);
            this.radioCHref.Name = "radioCHref";
            this.radioCHref.Size = new System.Drawing.Size(71, 16);
            this.radioCHref.TabIndex = 4;
            this.radioCHref.TabStop = true;
            this.radioCHref.Text = "链接href";
            this.radioCHref.UseVisualStyleBackColor = true;
            // 
            // radioCInnerLinks
            // 
            this.radioCInnerLinks.AutoSize = true;
            this.radioCInnerLinks.Location = new System.Drawing.Point(201, 20);
            this.radioCInnerLinks.Name = "radioCInnerLinks";
            this.radioCInnerLinks.Size = new System.Drawing.Size(71, 16);
            this.radioCInnerLinks.TabIndex = 3;
            this.radioCInnerLinks.TabStop = true;
            this.radioCInnerLinks.Text = "框内链接";
            this.radioCInnerLinks.UseVisualStyleBackColor = true;
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
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "XPath：";
            // 
            // btnCXPath
            // 
            this.btnCXPath.Location = new System.Drawing.Point(388, 2);
            this.btnCXPath.Name = "btnCXPath";
            this.btnCXPath.Size = new System.Drawing.Size(91, 23);
            this.btnCXPath.TabIndex = 94;
            this.btnCXPath.Text = "点此开始选择";
            this.btnCXPath.UseVisualStyleBackColor = true;
            this.btnCXPath.Click += new System.EventHandler(this.btnCXPath_Click);
            // 
            // txtCXpath
            // 
            this.txtCXpath.Location = new System.Drawing.Point(58, 4);
            this.txtCXpath.Name = "txtCXpath";
            this.txtCXpath.Size = new System.Drawing.Size(324, 21);
            this.txtCXpath.TabIndex = 93;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(3806, 1862);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "来源";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabTime
            // 
            this.tabTime.Location = new System.Drawing.Point(4, 22);
            this.tabTime.Name = "tabTime";
            this.tabTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabTime.Size = new System.Drawing.Size(3806, 1862);
            this.tabTime.TabIndex = 2;
            this.tabTime.Text = "时间";
            this.tabTime.UseVisualStyleBackColor = true;
            // 
            // tabSummary
            // 
            this.tabSummary.Location = new System.Drawing.Point(4, 22);
            this.tabSummary.Name = "tabSummary";
            this.tabSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabSummary.Size = new System.Drawing.Size(3806, 1862);
            this.tabSummary.TabIndex = 3;
            this.tabSummary.Text = "摘要";
            this.tabSummary.UseVisualStyleBackColor = true;
            // 
            // tabContent
            // 
            this.tabContent.Location = new System.Drawing.Point(4, 22);
            this.tabContent.Name = "tabContent";
            this.tabContent.Padding = new System.Windows.Forms.Padding(3);
            this.tabContent.Size = new System.Drawing.Size(3806, 1862);
            this.tabContent.TabIndex = 4;
            this.tabContent.Text = "内容";
            this.tabContent.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(3806, 1862);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "其他";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tbxItemUrl
            // 
            this.tbxItemUrl.Location = new System.Drawing.Point(72, 70);
            this.tbxItemUrl.Name = "tbxItemUrl";
            this.tbxItemUrl.Size = new System.Drawing.Size(507, 21);
            this.tbxItemUrl.TabIndex = 8;
            // 
            // lblItemUrl
            // 
            this.lblItemUrl.AutoSize = true;
            this.lblItemUrl.Location = new System.Drawing.Point(9, 76);
            this.lblItemUrl.Name = "lblItemUrl";
            this.lblItemUrl.Size = new System.Drawing.Size(65, 12);
            this.lblItemUrl.TabIndex = 7;
            this.lblItemUrl.Text = "测试地址：";
            // 
            // finish
            // 
            this.finish.BackgroundImage = global::HFBBS.Properties.Resources.laboratory;
            this.finish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.finish.Controls.Add(this.label11);
            this.finish.Name = "finish";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(623, 470);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 94;
            this.button4.Text = "测试";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // intermediateStep1
            // 
            this.intermediateStep1.BindingImage = ((System.Drawing.Image)(resources.GetObject("intermediateStep1.BindingImage")));
            this.intermediateStep1.Controls.Add(this.button5);
            this.intermediateStep1.Controls.Add(this.tbxResult);
            this.intermediateStep1.Name = "intermediateStep1";
            this.intermediateStep1.Subtitle = "在这里可以预览采集到的结果，如果不正确，请回到上一步修改";
            this.intermediateStep1.SubtitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.intermediateStep1.Title = "采集结果预览";
            this.intermediateStep1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            // 
            // tbxResult
            // 
            this.tbxResult.Location = new System.Drawing.Point(15, 62);
            this.tbxResult.Multiline = true;
            this.tbxResult.Name = "tbxResult";
            this.tbxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxResult.Size = new System.Drawing.Size(849, 491);
            this.tbxResult.TabIndex = 10;
            this.tbxResult.Text = "使用提示：\r\n1.点测试可以预览结果\r\n2.可以多种方式采集内容";
            this.tbxResult.TextChanged += new System.EventHandler(this.tbxResult_TextChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(874, 530);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "返回修改";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // startUrlWebBrowser
            // 
            this.startUrlWebBrowser.Location = new System.Drawing.Point(9, 101);
            this.startUrlWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.startUrlWebBrowser.Name = "startUrlWebBrowser";
            this.startUrlWebBrowser.ScriptErrorsSuppressed = true;
            this.startUrlWebBrowser.Size = new System.Drawing.Size(949, 306);
            this.startUrlWebBrowser.TabIndex = 5;
            // 
            // contentBrowser
            // 
            this.contentBrowser.Location = new System.Drawing.Point(3, 66);
            this.contentBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.contentBrowser.Name = "contentBrowser";
            this.contentBrowser.ScriptErrorsSuppressed = true;
            this.contentBrowser.Size = new System.Drawing.Size(949, 372);
            this.contentBrowser.TabIndex = 6;
            // 
            // itemWebBrowser
            // 
            this.itemWebBrowser.Location = new System.Drawing.Point(5, 97);
            this.itemWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.itemWebBrowser.Name = "itemWebBrowser";
            this.itemWebBrowser.ScriptErrorsSuppressed = true;
            this.itemWebBrowser.Size = new System.Drawing.Size(949, 300);
            this.itemWebBrowser.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(313, 232);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(328, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "恭喜你，配置完成！点击完成按钮完成编辑！";
            // 
            // lblItemContentLog
            // 
            this.lblItemContentLog.AutoSize = true;
            this.lblItemContentLog.Location = new System.Drawing.Point(489, 10);
            this.lblItemContentLog.Name = "lblItemContentLog";
            this.lblItemContentLog.Size = new System.Drawing.Size(17, 12);
            this.lblItemContentLog.TabIndex = 98;
            this.lblItemContentLog.Text = "  ";
            // 
            // TaskWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 606);
            this.Controls.Add(this.taskWizard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskWizardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "规则设置向导";
            this.Load += new System.EventHandler(this.TaskWizardForm_Load);
            this.start.ResumeLayout(false);
            this.start.PerformLayout();
            this.stepTaskName.ResumeLayout(false);
            this.stepTaskName.PerformLayout();
            this.stepStartUrl.ResumeLayout(false);
            this.stepStartUrl.PerformLayout();
            this.startUrlmenu.ResumeLayout(false);
            this.stepContentUrl.ResumeLayout(false);
            this.stepContentUrl.PerformLayout();
            this.stepTestUrl.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.stepItemRule.ResumeLayout(false);
            this.stepItemRule.PerformLayout();
            this.tabTitle.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panelItemRule.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.panelTxtProcess.ResumeLayout(false);
            this.panelTxtProcess.PerformLayout();
            this.panelxPath.ResumeLayout(false);
            this.panelxPath.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.finish.ResumeLayout(false);
            this.finish.PerformLayout();
            this.intermediateStep1.ResumeLayout(false);
            this.intermediateStep1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WizardBase.WizardControl taskWizard;
        private WizardBase.StartStep start;
        private WizardBase.IntermediateStep stepStartUrl;
        private WizardBase.FinishStep finish;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStartUrlLog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtStartUrl;
        private System.Windows.Forms.Label label2;
        private WizardBase.IntermediateStep stepTaskName;
        private WizardBase.IntermediateStep stepContentUrl;
        private WizardBase.IntermediateStep stepItemRule;
        private WizardBase.IntermediateStep stepTestUrl;
        private System.Windows.Forms.TextBox txtRuleName;
        private System.Windows.Forms.Label label4;
        private Com.iFLYTEK.WinForms.Browser.BaseWebBrowser startUrlWebBrowser;
        private System.Windows.Forms.ListBox lbxUrls;
        private System.Windows.Forms.Button btnSelectStartUrl;
        private Com.iFLYTEK.WinForms.Browser.BaseWebBrowser contentBrowser;
        private System.Windows.Forms.RichTextBox txtUrlResult;
        private System.Windows.Forms.RadioButton radioHref;
        private System.Windows.Forms.RadioButton radionInnerLinks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLinkXPath;
        private System.Windows.Forms.Label lblContentTips;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbxItemUrl;
        private System.Windows.Forms.Label lblItemUrl;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TreeView trvUrlTree;
        private System.Windows.Forms.Button btnOutputParentNode;
        private System.Windows.Forms.Button btnOutputChildNode;
        private System.Windows.Forms.Button btnCopyUrlToClipboard;
        private System.Windows.Forms.Button btnFetchUrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStartUrlXPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblStartUrlLoger;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton radioLinkHref;
        private System.Windows.Forms.RadioButton radioInnerLinks;
        private System.Windows.Forms.TabControl tabTitle;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel panelItemRule;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel panelTxtProcess;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkDownloadPic;
        private System.Windows.Forms.TextBox txtPageXPath;
        private System.Windows.Forms.CheckBox chkIdentifyPage;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panelxPath;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioMulti;
        private System.Windows.Forms.RadioButton radioOne;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioCHref;
        private System.Windows.Forms.RadioButton radioCInnerLinks;
        private System.Windows.Forms.RadioButton radioTextWithPic;
        private System.Windows.Forms.RadioButton radioHtml;
        private System.Windows.Forms.RadioButton radioText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCXPath;
        private System.Windows.Forms.TextBox txtCXpath;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabTime;
        private System.Windows.Forms.TabPage tabSummary;
        private System.Windows.Forms.TabPage tabContent;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label lblItemLog;
        private System.Windows.Forms.ContextMenuStrip startUrlmenu;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 浏览ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看代码ToolStripMenuItem;
        private Com.iFLYTEK.WinForms.Browser.BaseWebBrowser itemWebBrowser;
        private System.Windows.Forms.Button button4;
        private WizardBase.IntermediateStep intermediateStep1;
        private System.Windows.Forms.TextBox tbxResult;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblItemContentLog;
    }
}