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
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rblServer = new System.Windows.Forms.RadioButton();
            this.rblSingle = new System.Windows.Forms.RadioButton();
            this.rblEdit = new System.Windows.Forms.RadioButton();
            this.rblNotEdit = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Image = global::Jade.Properties.Resources.login__1_;
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(615, 316);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 40);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "     登录";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Image = global::Jade.Properties.Resources.login__2_;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(722, 316);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 40);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "     取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rblServer);
            this.groupBox1.Controls.Add(this.rblSingle);
            this.groupBox1.Location = new System.Drawing.Point(571, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 43);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "运行模式";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rblEdit);
            this.groupBox2.Controls.Add(this.rblNotEdit);
            this.groupBox2.Location = new System.Drawing.Point(571, 256);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 43);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "默认界面";
            // 
            // rblServer
            // 
            this.rblServer.AutoSize = true;
            this.rblServer.Checked = true;
            this.rblServer.Location = new System.Drawing.Point(131, 18);
            this.rblServer.Name = "rblServer";
            this.rblServer.Size = new System.Drawing.Size(83, 16);
            this.rblServer.TabIndex = 3;
            this.rblServer.TabStop = true;
            this.rblServer.Text = "工作站模式";
            this.rblServer.UseVisualStyleBackColor = true;
            // 
            // rblSingle
            // 
            this.rblSingle.AutoSize = true;
            this.rblSingle.Location = new System.Drawing.Point(17, 18);
            this.rblSingle.Name = "rblSingle";
            this.rblSingle.Size = new System.Drawing.Size(71, 16);
            this.rblSingle.TabIndex = 2;
            this.rblSingle.Text = "单机模式";
            this.rblSingle.UseVisualStyleBackColor = true;
            // 
            // rblEdit
            // 
            this.rblEdit.AutoSize = true;
            this.rblEdit.Checked = true;
            this.rblEdit.Location = new System.Drawing.Point(131, 17);
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
            this.rblNotEdit.Location = new System.Drawing.Point(17, 17);
            this.rblNotEdit.Name = "rblNotEdit";
            this.rblNotEdit.Size = new System.Drawing.Size(47, 16);
            this.rblNotEdit.TabIndex = 2;
            this.rblNotEdit.Text = "采集";
            this.rblNotEdit.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::Jade.Properties.Resources.laboratory;
            this.ClientSize = new System.Drawing.Size(872, 387);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Text = "登陆编辑中心";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rblServer;
        private System.Windows.Forms.RadioButton rblSingle;
        private System.Windows.Forms.RadioButton rblEdit;
        private System.Windows.Forms.RadioButton rblNotEdit;

    }
}