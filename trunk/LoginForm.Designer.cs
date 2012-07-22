namespace Jade
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rblServer = new System.Windows.Forms.RadioButton();
            this.rblSingle = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rblEdit = new System.Windows.Forms.RadioButton();
            this.rblNotEdit = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSelectStartUrl = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserName.Location = new System.Drawing.Point(647, 125);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(170, 14);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Text = "test";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Location = new System.Drawing.Point(647, 169);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '#';
            this.txtPassword.Size = new System.Drawing.Size(170, 14);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "pass";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rblServer);
            this.groupBox1.Controls.Add(this.rblSingle);
            this.groupBox1.Location = new System.Drawing.Point(551, 248);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 43);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "运行模式";
            // 
            // rblServer
            // 
            this.rblServer.AutoSize = true;
            this.rblServer.Checked = true;
            this.rblServer.Location = new System.Drawing.Point(70, 18);
            this.rblServer.Name = "rblServer";
            this.rblServer.Size = new System.Drawing.Size(59, 16);
            this.rblServer.TabIndex = 3;
            this.rblServer.TabStop = true;
            this.rblServer.Text = "工作组";
            this.rblServer.UseVisualStyleBackColor = true;
            // 
            // rblSingle
            // 
            this.rblSingle.AutoSize = true;
            this.rblSingle.Location = new System.Drawing.Point(17, 18);
            this.rblSingle.Name = "rblSingle";
            this.rblSingle.Size = new System.Drawing.Size(47, 16);
            this.rblSingle.TabIndex = 2;
            this.rblSingle.Text = "本地";
            this.rblSingle.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.rblEdit);
            this.groupBox2.Controls.Add(this.rblNotEdit);
            this.groupBox2.Location = new System.Drawing.Point(704, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(131, 43);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "默认界面";
            // 
            // rblEdit
            // 
            this.rblEdit.AutoSize = true;
            this.rblEdit.Checked = true;
            this.rblEdit.Location = new System.Drawing.Point(70, 17);
            this.rblEdit.Name = "rblEdit";
            this.rblEdit.Size = new System.Drawing.Size(47, 16);
            this.rblEdit.TabIndex = 3;
            this.rblEdit.TabStop = true;
            this.rblEdit.Text = "编辑";
            this.rblEdit.UseVisualStyleBackColor = true;
            // 
            // rblNotEdit
            // 
            this.rblNotEdit.AutoSize = true;
            this.rblNotEdit.BackColor = System.Drawing.Color.Transparent;
            this.rblNotEdit.Location = new System.Drawing.Point(17, 17);
            this.rblNotEdit.Name = "rblNotEdit";
            this.rblNotEdit.Size = new System.Drawing.Size(47, 16);
            this.rblNotEdit.TabIndex = 2;
            this.rblNotEdit.Text = "采集";
            this.rblNotEdit.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(189, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(554, 190);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 47);
            this.panel1.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(93, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(80, 14);
            this.textBox1.TabIndex = 8;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // btnSelectStartUrl
            // 
            this.btnSelectStartUrl.Image = global::Jade.Properties.Resources.network;
            this.btnSelectStartUrl.Location = new System.Drawing.Point(568, 326);
            this.btnSelectStartUrl.Name = "btnSelectStartUrl";
            this.btnSelectStartUrl.Size = new System.Drawing.Size(90, 29);
            this.btnSelectStartUrl.TabIndex = 102;
            this.btnSelectStartUrl.Text = " 联网登录";
            this.btnSelectStartUrl.ToolTip = "登录到网址服务器，可以发布内容";
            this.btnSelectStartUrl.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::Jade.Properties.Resources.pc_security_2;
            this.simpleButton1.Location = new System.Drawing.Point(672, 326);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(91, 29);
            this.simpleButton1.TabIndex = 103;
            this.simpleButton1.Text = " 离线操作";
            this.simpleButton1.ToolTip = "登录到本地，不能发布内容到服务器";
            this.simpleButton1.Click += new System.EventHandler(this.button1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Image = global::Jade.Properties.Resources.login__2_;
            this.simpleButton2.Location = new System.Drawing.Point(774, 326);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(69, 29);
            this.simpleButton2.TabIndex = 104;
            this.simpleButton2.Text = " 取消";
            this.simpleButton2.ToolTip = "登录到本地，不能发布内容到服务器";
            this.simpleButton2.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Jade.Properties.Resources.loginbg1;
            this.ClientSize = new System.Drawing.Size(872, 387);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnSelectStartUrl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登陆编辑中心";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rblServer;
        private System.Windows.Forms.RadioButton rblSingle;
        private System.Windows.Forms.RadioButton rblEdit;
        private System.Windows.Forms.RadioButton rblNotEdit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.XtraEditors.SimpleButton btnSelectStartUrl;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;

    }
}