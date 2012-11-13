using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace HFBBS
{
    public partial class FrmLogin : Office2007Form
    {
        private ILogin login = null;

        public FrmLogin(ILogin login)
        {
            this.login = login;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //錄入數據的有效性
            if (!superValidator1.Validate())
            {
                txtUsername.Focus();
                lblErrorMessage.Text = superValidator1.GetValidator1(txtUsername).ErrorMessage;
                return;
            }
 
            string username = this.txtUsername.Text;
            string password = this.txtPassword.Text;

            //驗證用戶名和密碼有效性
            if (login.ValidateUser(username, password))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                txtUsername.Focus();
                //提示錯誤信息
                this.lblErrorMessage.Text = "登入失败";
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}