namespace Jade
{
    partial class SourceGetter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SourceGetter));
            this.lblUrl = new System.Windows.Forms.Label();
            this.tbxUrl = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.pnlSetting = new System.Windows.Forms.Panel();
            this.tbxPostData = new System.Windows.Forms.TextBox();
            this.lblPostData = new System.Windows.Forms.Label();
            this.tbxUserAgent = new System.Windows.Forms.TextBox();
            this.rdbPost = new System.Windows.Forms.RadioButton();
            this.lblUserAgent = new System.Windows.Forms.Label();
            this.rdbGet = new System.Windows.Forms.RadioButton();
            this.lblMethod = new System.Windows.Forms.Label();
            this.tbxCookie = new System.Windows.Forms.TextBox();
            this.cbbEncoding = new System.Windows.Forms.ComboBox();
            this.lblCookie = new System.Windows.Forms.Label();
            this.lblEncoding = new System.Windows.Forms.Label();
            this.lblRefer = new System.Windows.Forms.Label();
            this.tbxReferer = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.psbStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbxHtml = new System.Windows.Forms.RichTextBox();
            this.pnlSetting.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUrl.Location = new System.Drawing.Point(11, 14);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(36, 13);
            this.lblUrl.TabIndex = 83;
            this.lblUrl.Text = "URL:";
            // 
            // tbxUrl
            // 
            this.tbxUrl.Location = new System.Drawing.Point(53, 11);
            this.tbxUrl.Name = "tbxUrl";
            this.tbxUrl.Size = new System.Drawing.Size(571, 21);
            this.tbxUrl.TabIndex = 82;
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSend.Location = new System.Drawing.Point(630, 6);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(93, 27);
            this.btnSend.TabIndex = 81;
            this.btnSend.Text = "GO";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // pnlSetting
            // 
            this.pnlSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSetting.Controls.Add(this.tbxPostData);
            this.pnlSetting.Controls.Add(this.lblPostData);
            this.pnlSetting.Controls.Add(this.tbxUserAgent);
            this.pnlSetting.Controls.Add(this.rdbPost);
            this.pnlSetting.Controls.Add(this.lblUserAgent);
            this.pnlSetting.Controls.Add(this.rdbGet);
            this.pnlSetting.Controls.Add(this.lblMethod);
            this.pnlSetting.Controls.Add(this.tbxCookie);
            this.pnlSetting.Controls.Add(this.cbbEncoding);
            this.pnlSetting.Controls.Add(this.lblCookie);
            this.pnlSetting.Controls.Add(this.lblEncoding);
            this.pnlSetting.Controls.Add(this.lblRefer);
            this.pnlSetting.Controls.Add(this.tbxReferer);
            this.pnlSetting.Location = new System.Drawing.Point(14, 39);
            this.pnlSetting.Name = "pnlSetting";
            this.pnlSetting.Size = new System.Drawing.Size(709, 135);
            this.pnlSetting.TabIndex = 84;
            // 
            // tbxPostData
            // 
            this.tbxPostData.Enabled = false;
            this.tbxPostData.Location = new System.Drawing.Point(6, 68);
            this.tbxPostData.Multiline = true;
            this.tbxPostData.Name = "tbxPostData";
            this.tbxPostData.Size = new System.Drawing.Size(695, 62);
            this.tbxPostData.TabIndex = 87;
            // 
            // lblPostData
            // 
            this.lblPostData.AutoSize = true;
            this.lblPostData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPostData.Location = new System.Drawing.Point(4, 54);
            this.lblPostData.Name = "lblPostData";
            this.lblPostData.Size = new System.Drawing.Size(63, 13);
            this.lblPostData.TabIndex = 86;
            this.lblPostData.Text = "发送数据:";
            // 
            // tbxUserAgent
            // 
            this.tbxUserAgent.Location = new System.Drawing.Point(416, 30);
            this.tbxUserAgent.Name = "tbxUserAgent";
            this.tbxUserAgent.Size = new System.Drawing.Size(285, 21);
            this.tbxUserAgent.TabIndex = 89;
            // 
            // rdbPost
            // 
            this.rdbPost.AutoSize = true;
            this.rdbPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbPost.Location = new System.Drawing.Point(295, 6);
            this.rdbPost.Name = "rdbPost";
            this.rdbPost.Size = new System.Drawing.Size(58, 17);
            this.rdbPost.TabIndex = 72;
            this.rdbPost.Text = "POST";
            this.rdbPost.UseVisualStyleBackColor = true;
            this.rdbPost.CheckedChanged += new System.EventHandler(this.rdbPost_CheckedChanged);
            // 
            // lblUserAgent
            // 
            this.lblUserAgent.AutoSize = true;
            this.lblUserAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUserAgent.Location = new System.Drawing.Point(360, 33);
            this.lblUserAgent.Name = "lblUserAgent";
            this.lblUserAgent.Size = new System.Drawing.Size(50, 13);
            this.lblUserAgent.TabIndex = 88;
            this.lblUserAgent.Text = "客户端:";
            // 
            // rdbGet
            // 
            this.rdbGet.AutoSize = true;
            this.rdbGet.Checked = true;
            this.rdbGet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbGet.Location = new System.Drawing.Point(239, 6);
            this.rdbGet.Name = "rdbGet";
            this.rdbGet.Size = new System.Drawing.Size(50, 17);
            this.rdbGet.TabIndex = 71;
            this.rdbGet.TabStop = true;
            this.rdbGet.Text = "GET";
            this.rdbGet.UseVisualStyleBackColor = true;
            this.rdbGet.CheckedChanged += new System.EventHandler(this.rdbGet_CheckedChanged);
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMethod.Location = new System.Drawing.Point(171, 6);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(63, 13);
            this.lblMethod.TabIndex = 70;
            this.lblMethod.Text = "发送方式:";
            // 
            // tbxCookie
            // 
            this.tbxCookie.Location = new System.Drawing.Point(56, 30);
            this.tbxCookie.Name = "tbxCookie";
            this.tbxCookie.Size = new System.Drawing.Size(289, 21);
            this.tbxCookie.TabIndex = 87;
            // 
            // cbbEncoding
            // 
            this.cbbEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbEncoding.FormattingEnabled = true;
            this.cbbEncoding.Location = new System.Drawing.Point(56, 2);
            this.cbbEncoding.Name = "cbbEncoding";
            this.cbbEncoding.Size = new System.Drawing.Size(109, 20);
            this.cbbEncoding.TabIndex = 69;
            // 
            // lblCookie
            // 
            this.lblCookie.AutoSize = true;
            this.lblCookie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCookie.Location = new System.Drawing.Point(4, 30);
            this.lblCookie.Name = "lblCookie";
            this.lblCookie.Size = new System.Drawing.Size(50, 13);
            this.lblCookie.TabIndex = 86;
            this.lblCookie.Text = "Cookie:";
            // 
            // lblEncoding
            // 
            this.lblEncoding.AutoSize = true;
            this.lblEncoding.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEncoding.Location = new System.Drawing.Point(4, 6);
            this.lblEncoding.Name = "lblEncoding";
            this.lblEncoding.Size = new System.Drawing.Size(37, 13);
            this.lblEncoding.TabIndex = 68;
            this.lblEncoding.Text = "编码:";
            // 
            // lblRefer
            // 
            this.lblRefer.AutoSize = true;
            this.lblRefer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRefer.Location = new System.Drawing.Point(359, 7);
            this.lblRefer.Name = "lblRefer";
            this.lblRefer.Size = new System.Drawing.Size(50, 13);
            this.lblRefer.TabIndex = 84;
            this.lblRefer.Text = "来源页:";
            // 
            // tbxReferer
            // 
            this.tbxReferer.Location = new System.Drawing.Point(415, 5);
            this.tbxReferer.Name = "tbxReferer";
            this.tbxReferer.Size = new System.Drawing.Size(286, 21);
            this.tbxReferer.TabIndex = 85;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 180);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(710, 273);
            this.tabControl1.TabIndex = 89;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbxHtml);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(702, 247);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Source";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(702, 247);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Text";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(701, 240);
            this.textBox1.TabIndex = 86;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 465);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 90;
            this.label1.Text = "选择文本：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 465);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 91;
            this.label2.Text = "label2";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.psbStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 495);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(735, 22);
            this.statusStrip1.TabIndex = 92;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // psbStatus
            // 
            this.psbStatus.Name = "psbStatus";
            this.psbStatus.Size = new System.Drawing.Size(100, 16);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(576, 469);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 86;
            this.button1.Text = "选定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(657, 469);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 93;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbxHtml
            // 
            this.tbxHtml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxHtml.Location = new System.Drawing.Point(3, 3);
            this.tbxHtml.Name = "tbxHtml";
            this.tbxHtml.Size = new System.Drawing.Size(696, 241);
            this.tbxHtml.TabIndex = 0;
            this.tbxHtml.Text = "";
            this.tbxHtml.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbxHtml_MouseUp);
            // 
            // SourceGetter
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 517);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pnlSetting);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.tbxUrl);
            this.Controls.Add(this.btnSend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SourceGetter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "源文件查看";
            this.Load += new System.EventHandler(this.SourceGetter_Load);
            this.pnlSetting.ResumeLayout(false);
            this.pnlSetting.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox tbxUrl;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel pnlSetting;
        private System.Windows.Forms.ComboBox cbbEncoding;
        private System.Windows.Forms.Label lblEncoding;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.RadioButton rdbGet;
        private System.Windows.Forms.RadioButton rdbPost;
        private System.Windows.Forms.TextBox tbxUserAgent;
        private System.Windows.Forms.Label lblUserAgent;
        private System.Windows.Forms.TextBox tbxCookie;
        private System.Windows.Forms.Label lblCookie;
        private System.Windows.Forms.Label lblRefer;
        private System.Windows.Forms.TextBox tbxReferer;
        private System.Windows.Forms.TextBox tbxPostData;
        private System.Windows.Forms.Label lblPostData;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar psbStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox tbxHtml;
    }
}