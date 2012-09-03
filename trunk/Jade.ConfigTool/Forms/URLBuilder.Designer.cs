namespace Jade
{
    partial class URLBuilder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(URLBuilder));
            this.tabURLBuilder = new System.Windows.Forms.TabControl();
            this.tbpSingle = new System.Windows.Forms.TabPage();
            this.pnlSingle = new System.Windows.Forms.Panel();
            this.btnSingleAdd = new System.Windows.Forms.Button();
            this.lblSingleUrl = new System.Windows.Forms.Label();
            this.tbxSingleUrl = new System.Windows.Forms.TextBox();
            this.tbpMulti = new System.Windows.Forms.TabPage();
            this.pnlMulti = new System.Windows.Forms.Panel();
            this.btnMultiPreview = new System.Windows.Forms.Button();
            this.tbxMultiUrlPreview = new System.Windows.Forms.TextBox();
            this.btnMultiAdd = new System.Windows.Forms.Button();
            this.lblMultiUrlPreview = new System.Windows.Forms.Label();
            this.lblMultiAddSymblic = new System.Windows.Forms.Label();
            this.lblMultiSymbolicInfo = new System.Windows.Forms.Label();
            this.cbxMultiDesc = new System.Windows.Forms.CheckBox();
            this.cbxMultiAddZero = new System.Windows.Forms.CheckBox();
            this.nudMultiSymbolicIncrement = new System.Windows.Forms.NumericUpDown();
            this.lblMultiIncrement = new System.Windows.Forms.Label();
            this.lblMultiRange = new System.Windows.Forms.Label();
            this.lblMultiSymbolic = new System.Windows.Forms.Label();
            this.nudMultiSymbolicEnd = new System.Windows.Forms.NumericUpDown();
            this.nudMultiSymbolicStart = new System.Windows.Forms.NumericUpDown();
            this.tbxMultiUrl = new System.Windows.Forms.TextBox();
            this.lblMultiUrl = new System.Windows.Forms.Label();
            this.tbpFromTxt = new System.Windows.Forms.TabPage();
            this.pnlFromTxt = new System.Windows.Forms.Panel();
            this.btnFromTxtPreviewFile = new System.Windows.Forms.Button();
            this.btnFromTxtAdd = new System.Windows.Forms.Button();
            this.btnFromTxtBrowseFile = new System.Windows.Forms.Button();
            this.tbxFromTextUrlPreview = new System.Windows.Forms.TextBox();
            this.lblFromTxtUrlPreview = new System.Windows.Forms.Label();
            this.tbxFromTxtFile = new System.Windows.Forms.TextBox();
            this.lblFromTxtFile = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbxFinishedUrl = new System.Windows.Forms.ListBox();
            this.cmsModifyUrl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmiDeleteUrl = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiCleanUrl = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFinish = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.txtXPathList = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStartUrl = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.tabURLBuilder.SuspendLayout();
            this.tbpSingle.SuspendLayout();
            this.pnlSingle.SuspendLayout();
            this.tbpMulti.SuspendLayout();
            this.pnlMulti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultiSymbolicIncrement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultiSymbolicEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultiSymbolicStart)).BeginInit();
            this.tbpFromTxt.SuspendLayout();
            this.pnlFromTxt.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.cmsModifyUrl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabURLBuilder
            // 
            this.tabURLBuilder.Controls.Add(this.tbpSingle);
            this.tabURLBuilder.Controls.Add(this.tbpMulti);
            this.tabURLBuilder.Controls.Add(this.tbpFromTxt);
            this.tabURLBuilder.Controls.Add(this.tabPage1);
            this.tabURLBuilder.Controls.Add(this.tabPage2);
            this.tabURLBuilder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabURLBuilder.Location = new System.Drawing.Point(12, 11);
            this.tabURLBuilder.Name = "tabURLBuilder";
            this.tabURLBuilder.SelectedIndex = 0;
            this.tabURLBuilder.Size = new System.Drawing.Size(548, 246);
            this.tabURLBuilder.TabIndex = 0;
            // 
            // tbpSingle
            // 
            this.tbpSingle.Controls.Add(this.pnlSingle);
            this.tbpSingle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbpSingle.Location = new System.Drawing.Point(4, 22);
            this.tbpSingle.Name = "tbpSingle";
            this.tbpSingle.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSingle.Size = new System.Drawing.Size(540, 220);
            this.tbpSingle.TabIndex = 0;
            this.tbpSingle.Text = "单个URL";
            this.tbpSingle.UseVisualStyleBackColor = true;
            // 
            // pnlSingle
            // 
            this.pnlSingle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSingle.Controls.Add(this.btnSingleAdd);
            this.pnlSingle.Controls.Add(this.lblSingleUrl);
            this.pnlSingle.Controls.Add(this.tbxSingleUrl);
            this.pnlSingle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSingle.Location = new System.Drawing.Point(3, 3);
            this.pnlSingle.Name = "pnlSingle";
            this.pnlSingle.Size = new System.Drawing.Size(534, 214);
            this.pnlSingle.TabIndex = 0;
            // 
            // btnSingleAdd
            // 
            this.btnSingleAdd.Location = new System.Drawing.Point(445, 179);
            this.btnSingleAdd.Name = "btnSingleAdd";
            this.btnSingleAdd.Size = new System.Drawing.Size(83, 30);
            this.btnSingleAdd.TabIndex = 2;
            this.btnSingleAdd.Text = "添加";
            this.btnSingleAdd.UseVisualStyleBackColor = true;
            this.btnSingleAdd.Click += new System.EventHandler(this.btnSingleAdd_Click);
            // 
            // lblSingleUrl
            // 
            this.lblSingleUrl.AutoSize = true;
            this.lblSingleUrl.Location = new System.Drawing.Point(3, 7);
            this.lblSingleUrl.Name = "lblSingleUrl";
            this.lblSingleUrl.Size = new System.Drawing.Size(158, 13);
            this.lblSingleUrl.TabIndex = 1;
            this.lblSingleUrl.Text = "单条/多条URL: [一行一个]";
            // 
            // tbxSingleUrl
            // 
            this.tbxSingleUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxSingleUrl.Location = new System.Drawing.Point(3, 28);
            this.tbxSingleUrl.Multiline = true;
            this.tbxSingleUrl.Name = "tbxSingleUrl";
            this.tbxSingleUrl.Size = new System.Drawing.Size(525, 146);
            this.tbxSingleUrl.TabIndex = 0;
            this.tbxSingleUrl.Text = "http://";
            // 
            // tbpMulti
            // 
            this.tbpMulti.Controls.Add(this.pnlMulti);
            this.tbpMulti.Location = new System.Drawing.Point(4, 22);
            this.tbpMulti.Name = "tbpMulti";
            this.tbpMulti.Padding = new System.Windows.Forms.Padding(3);
            this.tbpMulti.Size = new System.Drawing.Size(540, 220);
            this.tbpMulti.TabIndex = 1;
            this.tbpMulti.Text = "批量/多页";
            this.tbpMulti.UseVisualStyleBackColor = true;
            // 
            // pnlMulti
            // 
            this.pnlMulti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMulti.Controls.Add(this.btnMultiPreview);
            this.pnlMulti.Controls.Add(this.tbxMultiUrlPreview);
            this.pnlMulti.Controls.Add(this.btnMultiAdd);
            this.pnlMulti.Controls.Add(this.lblMultiUrlPreview);
            this.pnlMulti.Controls.Add(this.lblMultiAddSymblic);
            this.pnlMulti.Controls.Add(this.lblMultiSymbolicInfo);
            this.pnlMulti.Controls.Add(this.cbxMultiDesc);
            this.pnlMulti.Controls.Add(this.cbxMultiAddZero);
            this.pnlMulti.Controls.Add(this.nudMultiSymbolicIncrement);
            this.pnlMulti.Controls.Add(this.lblMultiIncrement);
            this.pnlMulti.Controls.Add(this.lblMultiRange);
            this.pnlMulti.Controls.Add(this.lblMultiSymbolic);
            this.pnlMulti.Controls.Add(this.nudMultiSymbolicEnd);
            this.pnlMulti.Controls.Add(this.nudMultiSymbolicStart);
            this.pnlMulti.Controls.Add(this.tbxMultiUrl);
            this.pnlMulti.Controls.Add(this.lblMultiUrl);
            this.pnlMulti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMulti.Location = new System.Drawing.Point(3, 3);
            this.pnlMulti.Name = "pnlMulti";
            this.pnlMulti.Size = new System.Drawing.Size(534, 214);
            this.pnlMulti.TabIndex = 0;
            // 
            // btnMultiPreview
            // 
            this.btnMultiPreview.Location = new System.Drawing.Point(363, 61);
            this.btnMultiPreview.Name = "btnMultiPreview";
            this.btnMultiPreview.Size = new System.Drawing.Size(75, 26);
            this.btnMultiPreview.TabIndex = 16;
            this.btnMultiPreview.Text = "预览";
            this.btnMultiPreview.UseVisualStyleBackColor = true;
            this.btnMultiPreview.Click += new System.EventHandler(this.btnMultiPreview_Click);
            // 
            // tbxMultiUrlPreview
            // 
            this.tbxMultiUrlPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxMultiUrlPreview.Location = new System.Drawing.Point(7, 97);
            this.tbxMultiUrlPreview.Multiline = true;
            this.tbxMultiUrlPreview.Name = "tbxMultiUrlPreview";
            this.tbxMultiUrlPreview.ReadOnly = true;
            this.tbxMultiUrlPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxMultiUrlPreview.Size = new System.Drawing.Size(512, 106);
            this.tbxMultiUrlPreview.TabIndex = 15;
            // 
            // btnMultiAdd
            // 
            this.btnMultiAdd.Location = new System.Drawing.Point(444, 61);
            this.btnMultiAdd.Name = "btnMultiAdd";
            this.btnMultiAdd.Size = new System.Drawing.Size(75, 26);
            this.btnMultiAdd.TabIndex = 14;
            this.btnMultiAdd.Text = "添加";
            this.btnMultiAdd.UseVisualStyleBackColor = true;
            this.btnMultiAdd.Click += new System.EventHandler(this.btnMultiAdd_Click);
            // 
            // lblMultiUrlPreview
            // 
            this.lblMultiUrlPreview.AutoSize = true;
            this.lblMultiUrlPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMultiUrlPreview.Location = new System.Drawing.Point(4, 82);
            this.lblMultiUrlPreview.Name = "lblMultiUrlPreview";
            this.lblMultiUrlPreview.Size = new System.Drawing.Size(43, 13);
            this.lblMultiUrlPreview.TabIndex = 13;
            this.lblMultiUrlPreview.Text = "预览：";
            // 
            // lblMultiAddSymblic
            // 
            this.lblMultiAddSymblic.AutoSize = true;
            this.lblMultiAddSymblic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMultiAddSymblic.ForeColor = System.Drawing.Color.Blue;
            this.lblMultiAddSymblic.Location = new System.Drawing.Point(499, 35);
            this.lblMultiAddSymblic.Name = "lblMultiAddSymblic";
            this.lblMultiAddSymblic.Size = new System.Drawing.Size(20, 13);
            this.lblMultiAddSymblic.TabIndex = 11;
            this.lblMultiAddSymblic.Text = "[*]";
            this.lblMultiAddSymblic.Click += new System.EventHandler(this.lblMultiAddSymblic_Click);
            // 
            // lblMultiSymbolicInfo
            // 
            this.lblMultiSymbolicInfo.AutoSize = true;
            this.lblMultiSymbolicInfo.Location = new System.Drawing.Point(418, 36);
            this.lblMultiSymbolicInfo.Name = "lblMultiSymbolicInfo";
            this.lblMultiSymbolicInfo.Size = new System.Drawing.Size(85, 13);
            this.lblMultiSymbolicInfo.TabIndex = 10;
            this.lblMultiSymbolicInfo.Text = "添加通配符：";
            // 
            // cbxMultiDesc
            // 
            this.cbxMultiDesc.AutoSize = true;
            this.cbxMultiDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxMultiDesc.Location = new System.Drawing.Point(264, 64);
            this.cbxMultiDesc.Name = "cbxMultiDesc";
            this.cbxMultiDesc.Size = new System.Drawing.Size(50, 17);
            this.cbxMultiDesc.TabIndex = 9;
            this.cbxMultiDesc.Text = "倒序";
            this.cbxMultiDesc.UseVisualStyleBackColor = true;
            // 
            // cbxMultiAddZero
            // 
            this.cbxMultiAddZero.AutoSize = true;
            this.cbxMultiAddZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxMultiAddZero.Location = new System.Drawing.Point(206, 63);
            this.cbxMultiAddZero.Name = "cbxMultiAddZero";
            this.cbxMultiAddZero.Size = new System.Drawing.Size(50, 17);
            this.cbxMultiAddZero.TabIndex = 8;
            this.cbxMultiAddZero.Text = "补零";
            this.cbxMultiAddZero.UseVisualStyleBackColor = true;
            // 
            // nudMultiSymbolicIncrement
            // 
            this.nudMultiSymbolicIncrement.Location = new System.Drawing.Point(129, 61);
            this.nudMultiSymbolicIncrement.Name = "nudMultiSymbolicIncrement";
            this.nudMultiSymbolicIncrement.Size = new System.Drawing.Size(47, 20);
            this.nudMultiSymbolicIncrement.TabIndex = 7;
            this.nudMultiSymbolicIncrement.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMultiIncrement
            // 
            this.lblMultiIncrement.AutoSize = true;
            this.lblMultiIncrement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMultiIncrement.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMultiIncrement.Location = new System.Drawing.Point(4, 63);
            this.lblMultiIncrement.Name = "lblMultiIncrement";
            this.lblMultiIncrement.Size = new System.Drawing.Size(94, 13);
            this.lblMultiIncrement.TabIndex = 6;
            this.lblMultiIncrement.Text = "通配符间隔倍数:";
            // 
            // lblMultiRange
            // 
            this.lblMultiRange.AutoSize = true;
            this.lblMultiRange.Location = new System.Drawing.Point(182, 38);
            this.lblMultiRange.Name = "lblMultiRange";
            this.lblMultiRange.Size = new System.Drawing.Size(20, 13);
            this.lblMultiRange.TabIndex = 5;
            this.lblMultiRange.Text = "～";
            // 
            // lblMultiSymbolic
            // 
            this.lblMultiSymbolic.AutoSize = true;
            this.lblMultiSymbolic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMultiSymbolic.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMultiSymbolic.Location = new System.Drawing.Point(4, 38);
            this.lblMultiSymbolic.Name = "lblMultiSymbolic";
            this.lblMultiSymbolic.Size = new System.Drawing.Size(118, 13);
            this.lblMultiSymbolic.TabIndex = 4;
            this.lblMultiSymbolic.Text = "通配符数字变化范围:";
            // 
            // nudMultiSymbolicEnd
            // 
            this.nudMultiSymbolicEnd.Location = new System.Drawing.Point(206, 34);
            this.nudMultiSymbolicEnd.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudMultiSymbolicEnd.Name = "nudMultiSymbolicEnd";
            this.nudMultiSymbolicEnd.Size = new System.Drawing.Size(47, 20);
            this.nudMultiSymbolicEnd.TabIndex = 3;
            this.nudMultiSymbolicEnd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nudMultiSymbolicStart
            // 
            this.nudMultiSymbolicStart.Location = new System.Drawing.Point(129, 34);
            this.nudMultiSymbolicStart.Name = "nudMultiSymbolicStart";
            this.nudMultiSymbolicStart.Size = new System.Drawing.Size(47, 20);
            this.nudMultiSymbolicStart.TabIndex = 2;
            this.nudMultiSymbolicStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tbxMultiUrl
            // 
            this.tbxMultiUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxMultiUrl.Location = new System.Drawing.Point(129, 6);
            this.tbxMultiUrl.Name = "tbxMultiUrl";
            this.tbxMultiUrl.Size = new System.Drawing.Size(390, 20);
            this.tbxMultiUrl.TabIndex = 1;
            this.tbxMultiUrl.Text = "http://";
            // 
            // lblMultiUrl
            // 
            this.lblMultiUrl.AutoSize = true;
            this.lblMultiUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMultiUrl.ForeColor = System.Drawing.Color.Brown;
            this.lblMultiUrl.Location = new System.Drawing.Point(4, 8);
            this.lblMultiUrl.Name = "lblMultiUrl";
            this.lblMultiUrl.Size = new System.Drawing.Size(106, 13);
            this.lblMultiUrl.TabIndex = 0;
            this.lblMultiUrl.Text = "多页类似地址形式:";
            // 
            // tbpFromTxt
            // 
            this.tbpFromTxt.Controls.Add(this.pnlFromTxt);
            this.tbpFromTxt.Location = new System.Drawing.Point(4, 22);
            this.tbpFromTxt.Name = "tbpFromTxt";
            this.tbpFromTxt.Padding = new System.Windows.Forms.Padding(3);
            this.tbpFromTxt.Size = new System.Drawing.Size(540, 220);
            this.tbpFromTxt.TabIndex = 2;
            this.tbpFromTxt.Text = "文本导入";
            this.tbpFromTxt.UseVisualStyleBackColor = true;
            // 
            // pnlFromTxt
            // 
            this.pnlFromTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFromTxt.Controls.Add(this.btnFromTxtPreviewFile);
            this.pnlFromTxt.Controls.Add(this.btnFromTxtAdd);
            this.pnlFromTxt.Controls.Add(this.btnFromTxtBrowseFile);
            this.pnlFromTxt.Controls.Add(this.tbxFromTextUrlPreview);
            this.pnlFromTxt.Controls.Add(this.lblFromTxtUrlPreview);
            this.pnlFromTxt.Controls.Add(this.tbxFromTxtFile);
            this.pnlFromTxt.Controls.Add(this.lblFromTxtFile);
            this.pnlFromTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFromTxt.Location = new System.Drawing.Point(3, 3);
            this.pnlFromTxt.Name = "pnlFromTxt";
            this.pnlFromTxt.Size = new System.Drawing.Size(534, 214);
            this.pnlFromTxt.TabIndex = 0;
            // 
            // btnFromTxtPreviewFile
            // 
            this.btnFromTxtPreviewFile.Location = new System.Drawing.Point(460, 6);
            this.btnFromTxtPreviewFile.Name = "btnFromTxtPreviewFile";
            this.btnFromTxtPreviewFile.Size = new System.Drawing.Size(64, 21);
            this.btnFromTxtPreviewFile.TabIndex = 22;
            this.btnFromTxtPreviewFile.Text = "预览";
            this.btnFromTxtPreviewFile.UseVisualStyleBackColor = true;
            this.btnFromTxtPreviewFile.Click += new System.EventHandler(this.btnFromTxtPreviewFile_Click);
            // 
            // btnFromTxtAdd
            // 
            this.btnFromTxtAdd.Location = new System.Drawing.Point(441, 179);
            this.btnFromTxtAdd.Name = "btnFromTxtAdd";
            this.btnFromTxtAdd.Size = new System.Drawing.Size(83, 30);
            this.btnFromTxtAdd.TabIndex = 21;
            this.btnFromTxtAdd.Text = "添加";
            this.btnFromTxtAdd.UseVisualStyleBackColor = true;
            this.btnFromTxtAdd.Click += new System.EventHandler(this.btnFromTxtAdd_Click);
            // 
            // btnFromTxtBrowseFile
            // 
            this.btnFromTxtBrowseFile.Location = new System.Drawing.Point(390, 6);
            this.btnFromTxtBrowseFile.Name = "btnFromTxtBrowseFile";
            this.btnFromTxtBrowseFile.Size = new System.Drawing.Size(64, 21);
            this.btnFromTxtBrowseFile.TabIndex = 20;
            this.btnFromTxtBrowseFile.Text = "浏览";
            this.btnFromTxtBrowseFile.UseVisualStyleBackColor = true;
            this.btnFromTxtBrowseFile.Click += new System.EventHandler(this.btnFromTxtBrowseFile_Click);
            // 
            // tbxFromTextUrlPreview
            // 
            this.tbxFromTextUrlPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxFromTextUrlPreview.Location = new System.Drawing.Point(12, 42);
            this.tbxFromTextUrlPreview.Multiline = true;
            this.tbxFromTextUrlPreview.Name = "tbxFromTextUrlPreview";
            this.tbxFromTextUrlPreview.ReadOnly = true;
            this.tbxFromTextUrlPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxFromTextUrlPreview.Size = new System.Drawing.Size(512, 132);
            this.tbxFromTextUrlPreview.TabIndex = 19;
            // 
            // lblFromTxtUrlPreview
            // 
            this.lblFromTxtUrlPreview.AutoSize = true;
            this.lblFromTxtUrlPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFromTxtUrlPreview.Location = new System.Drawing.Point(9, 27);
            this.lblFromTxtUrlPreview.Name = "lblFromTxtUrlPreview";
            this.lblFromTxtUrlPreview.Size = new System.Drawing.Size(43, 13);
            this.lblFromTxtUrlPreview.TabIndex = 18;
            this.lblFromTxtUrlPreview.Text = "预览：";
            // 
            // tbxFromTxtFile
            // 
            this.tbxFromTxtFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxFromTxtFile.Location = new System.Drawing.Point(73, 7);
            this.tbxFromTxtFile.Name = "tbxFromTxtFile";
            this.tbxFromTxtFile.Size = new System.Drawing.Size(311, 20);
            this.tbxFromTxtFile.TabIndex = 17;
            // 
            // lblFromTxtFile
            // 
            this.lblFromTxtFile.AutoSize = true;
            this.lblFromTxtFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFromTxtFile.ForeColor = System.Drawing.Color.Brown;
            this.lblFromTxtFile.Location = new System.Drawing.Point(9, 10);
            this.lblFromTxtFile.Name = "lblFromTxtFile";
            this.lblFromTxtFile.Size = new System.Drawing.Size(58, 13);
            this.lblFromTxtFile.TabIndex = 16;
            this.lblFromTxtFile.Text = "文本地址:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(540, 220);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "导入OPML";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(421, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 21);
            this.button1.TabIndex = 28;
            this.button1.Text = "预览";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(445, 180);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 30);
            this.button2.TabIndex = 27;
            this.button2.Text = "添加";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(16, 43);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(512, 132);
            this.textBox1.TabIndex = 25;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(77, 8);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(334, 20);
            this.textBox2.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "opml address:";
            // 
            // lbxFinishedUrl
            // 
            this.lbxFinishedUrl.ContextMenuStrip = this.cmsModifyUrl;
            this.lbxFinishedUrl.FormattingEnabled = true;
            this.lbxFinishedUrl.ItemHeight = 12;
            this.lbxFinishedUrl.Location = new System.Drawing.Point(12, 277);
            this.lbxFinishedUrl.Name = "lbxFinishedUrl";
            this.lbxFinishedUrl.Size = new System.Drawing.Size(551, 112);
            this.lbxFinishedUrl.TabIndex = 1;
            this.lbxFinishedUrl.DoubleClick += new System.EventHandler(this.lbxFinishedUrl_DoubleClick);
            // 
            // cmsModifyUrl
            // 
            this.cmsModifyUrl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiDeleteUrl,
            this.tmiCleanUrl});
            this.cmsModifyUrl.Name = "cmsModifyUrl";
            this.cmsModifyUrl.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsModifyUrl.ShowImageMargin = false;
            this.cmsModifyUrl.ShowItemToolTips = false;
            this.cmsModifyUrl.Size = new System.Drawing.Size(80, 48);
            // 
            // tmiDeleteUrl
            // 
            this.tmiDeleteUrl.Name = "tmiDeleteUrl";
            this.tmiDeleteUrl.Size = new System.Drawing.Size(79, 22);
            this.tmiDeleteUrl.Text = "删除";
            this.tmiDeleteUrl.Click += new System.EventHandler(this.tmiDeleteUrl_Click);
            // 
            // tmiCleanUrl
            // 
            this.tmiCleanUrl.Name = "tmiCleanUrl";
            this.tmiCleanUrl.Size = new System.Drawing.Size(79, 22);
            this.tmiCleanUrl.Text = "清空 ";
            this.tmiCleanUrl.Click += new System.EventHandler(this.tmiCleanUrl_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFinish.Location = new System.Drawing.Point(472, 394);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(91, 33);
            this.btnFinish.TabIndex = 2;
            this.btnFinish.Text = "完成";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo.ForeColor = System.Drawing.Color.DarkRed;
            this.lblInfo.Location = new System.Drawing.Point(14, 259);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(413, 13);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "已经添加的地址 [从上面各种方式添加的地址 编辑请在列表上点击右键]";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.txtStartUrl);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.txtXPathList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(540, 220);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "可视化选择";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(450, 171);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 30);
            this.button3.TabIndex = 4;
            this.button3.Text = "添加";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtXPathList
            // 
            this.txtXPathList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtXPathList.Location = new System.Drawing.Point(8, 54);
            this.txtXPathList.Multiline = true;
            this.txtXPathList.Name = "txtXPathList";
            this.txtXPathList.Size = new System.Drawing.Size(525, 112);
            this.txtXPathList.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "列表页URL:";
            // 
            // txtStartUrl
            // 
            this.txtStartUrl.Location = new System.Drawing.Point(89, 8);
            this.txtStartUrl.Name = "txtStartUrl";
            this.txtStartUrl.Size = new System.Drawing.Size(322, 20);
            this.txtStartUrl.TabIndex = 6;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(417, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "可视化选择";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // URLBuilder
            // 
            this.AcceptButton = this.btnFinish;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 435);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.lbxFinishedUrl);
            this.Controls.Add(this.tabURLBuilder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "URLBuilder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "URL向导";
            this.tabURLBuilder.ResumeLayout(false);
            this.tbpSingle.ResumeLayout(false);
            this.pnlSingle.ResumeLayout(false);
            this.pnlSingle.PerformLayout();
            this.tbpMulti.ResumeLayout(false);
            this.pnlMulti.ResumeLayout(false);
            this.pnlMulti.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultiSymbolicIncrement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultiSymbolicEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultiSymbolicStart)).EndInit();
            this.tbpFromTxt.ResumeLayout(false);
            this.pnlFromTxt.ResumeLayout(false);
            this.pnlFromTxt.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.cmsModifyUrl.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabURLBuilder;
        private System.Windows.Forms.TabPage tbpSingle;
        private System.Windows.Forms.TabPage tbpMulti;
        private System.Windows.Forms.TabPage tbpFromTxt;
        private System.Windows.Forms.ListBox lbxFinishedUrl;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Panel pnlSingle;
        private System.Windows.Forms.Button btnSingleAdd;
        private System.Windows.Forms.Label lblSingleUrl;
        private System.Windows.Forms.TextBox tbxSingleUrl;
        private System.Windows.Forms.Panel pnlMulti;
        private System.Windows.Forms.TextBox tbxMultiUrl;
        private System.Windows.Forms.Label lblMultiUrl;
        private System.Windows.Forms.NumericUpDown nudMultiSymbolicStart;
        private System.Windows.Forms.NumericUpDown nudMultiSymbolicIncrement;
        private System.Windows.Forms.Label lblMultiIncrement;
        private System.Windows.Forms.Label lblMultiRange;
        private System.Windows.Forms.Label lblMultiSymbolic;
        private System.Windows.Forms.NumericUpDown nudMultiSymbolicEnd;
        private System.Windows.Forms.CheckBox cbxMultiDesc;
        private System.Windows.Forms.CheckBox cbxMultiAddZero;
        private System.Windows.Forms.Label lblMultiSymbolicInfo;
        private System.Windows.Forms.Label lblMultiAddSymblic;
        private System.Windows.Forms.Label lblMultiUrlPreview;
        private System.Windows.Forms.TextBox tbxMultiUrlPreview;
        private System.Windows.Forms.Button btnMultiAdd;
        private System.Windows.Forms.Panel pnlFromTxt;
        private System.Windows.Forms.TextBox tbxFromTextUrlPreview;
        private System.Windows.Forms.Label lblFromTxtUrlPreview;
        private System.Windows.Forms.TextBox tbxFromTxtFile;
        private System.Windows.Forms.Label lblFromTxtFile;
        private System.Windows.Forms.Button btnFromTxtAdd;
        private System.Windows.Forms.Button btnFromTxtBrowseFile;
        private System.Windows.Forms.Button btnMultiPreview;
        private System.Windows.Forms.ContextMenuStrip cmsModifyUrl;
        private System.Windows.Forms.ToolStripMenuItem tmiDeleteUrl;
        private System.Windows.Forms.ToolStripMenuItem tmiCleanUrl;
        private System.Windows.Forms.Button btnFromTxtPreviewFile;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtStartUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtXPathList;
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         