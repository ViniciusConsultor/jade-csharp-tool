using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jade
{
    public partial class SystemConfigForm : Form
    {
        Jade.Properties.Settings setting;

        public SystemConfigForm()
        {
            InitializeComponent();
            setting = Jade.Properties.Settings.Default;
            Bind();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Update();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        void Bind()
        {
            this.rblEdit.Checked = setting.IsEditModel;
            this.rblNotEdit.Checked = !this.rblEdit.Checked;
            this.rblServer.Checked = setting.IsOnline;
            this.rblSingle.Checked = !this.rblServer.Checked;

            this.txtIp.Text = setting.ServerIp;
            this.txtPass.Text = setting.ServerPasword;
            this.txtDatabase.Text = setting.ServerDatabase;
            this.txtUserName.Text = setting.ServerUser;
        }

        void Update()
        {
            setting.IsEditModel = this.rblEdit.Checked;
            setting.IsOnline = this.rblServer.Checked;
            setting.ServerIp = this.txtIp.Text;
            setting.ServerPasword = this.txtPass.Text;
            setting.ServerDatabase = this.txtDatabase.Text;
            setting.ServerUser = this.txtUserName.Text;
            setting.Save();

            // 
           CacheObject.DownloadDataDAL = DatabaseFactory.Instance.CreateDAL();
        }
    }
}
