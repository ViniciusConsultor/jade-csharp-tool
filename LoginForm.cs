﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jade
{
    public partial class LoginForm : Form
    {
        Jade.Properties.Settings setting;
        private ILogin login = null;

        public LoginForm(ILogin login)
        {
            this.login = login;
            InitializeComponent();
            setting = Jade.Properties.Settings.Default;
            this.rblEdit.Checked = setting.IsEditModel;
            this.rblNotEdit.Checked = !this.rblEdit.Checked;
            this.rblServer.Checked = setting.IsOnline;
            this.rblSingle.Checked = !this.rblServer.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            setting.IsEditModel = this.rblEdit.Checked;
            setting.IsOnline = this.rblServer.Checked;
            setting.Save();

            string username = this.txtUserName.Text;
            string password = this.txtPassword.Text;

            //驗證用戶名和密碼有效性
            if (login.ValidateUser(username, password))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("登录失败");
            }
        }
    }
}
