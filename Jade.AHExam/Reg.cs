using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Jade.AHExam
{
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Reg_Load(object sender, EventArgs e)
        {
            this.webBrowser1.DocumentText = "<html><HEAD><STYLE>body {MARGIN: 0px;padding:0px; border:0px;}IMG {MARGIN: 0px; border:0px;}A {MARGIN: 0px;border：0px;}</STYLE></HEAD><BODY><A href=\"http://me.alipay.com/jadepeng\" target=_blank><IMG src=\"https://img.alipay.com/sys/personalprod/style/mc/btn-index.png\"> </A></BODY></html>";
        }

        public string UserName
        {
            get
            {
                return this.textBox2.Text;
            }
        }

        public string RegCode
        {
            get
            {
                return this.textBox1.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (KeyCodeHelper.IsValid(UserName, RegCode))
                {
                    MessageBox.Show("恭喜你，注册成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("注册码错误");
                }
            }
            catch
            {
            }
        }
    }
}
