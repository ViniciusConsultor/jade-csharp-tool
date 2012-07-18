using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

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
            remoteLogin();
            return;

            setting.IsEditModel = this.rblEdit.Checked;
            setting.IsOnline = this.rblServer.Checked;
            setting.Save();

            string username = this.txtUserName.Text;
            string password = this.txtPassword.Text;

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

        /// </summary>
        internal class CookieAwareWebClient : WebClient
        {
            internal CookieContainer _cookieContainer = new CookieContainer();

            protected override WebRequest GetWebRequest(Uri address)
            {
                var request = base.GetWebRequest(address);
                if (request is HttpWebRequest)
                    (request as HttpWebRequest).CookieContainer = this._cookieContainer;
                return request;
            }

            protected override WebResponse GetWebResponse(WebRequest request)
            {
                var r = base.GetWebResponse(request);
                if (r is HttpWebResponse)
                    this._cookieContainer.Add((r as HttpWebResponse).Cookies);
                return r;
            }
        }


        string cookie;
        void remoteLogin()
        {
            CookieAwareWebClient client = new CookieAwareWebClient();
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            //client._cookieContainer = this.cookie;
            client.Headers[HttpRequestHeader.Cookie] = cookie; 
            client.UploadDataCompleted += new UploadDataCompletedEventHandler(client_UploadDataCompleted);
            client.UploadDataAsync(new Uri("http://newscms.house365.com/newCMS/chk_log.php"), "POST", System.Text.Encoding.GetEncoding("GB2312").GetBytes("user_name=zhangyang&pass_word=House365&yzmcode=" + this.textBox1.Text + "&login.x=47&login.y=32"));

        }

        void client_UploadDataCompleted(object sender, UploadDataCompletedEventArgs e)
        {
            var html = System.Text.Encoding.GetEncoding("GB2312").GetString(e.Result);

            Console.WriteLine(html);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            DownloadValidCode();
        }

        private void DownloadValidCode()
        {
            WebClient client = new WebClient();
            client.DownloadDataCompleted += new DownloadDataCompletedEventHandler(client_DownloadDataCompleted);
            client.DownloadDataAsync(new Uri("http://newscms.house365.com/WEB_INFO/authimg2.php"));
        }


        void client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MemoryStream stream = new MemoryStream(e.Result, 0, e.Result.Length);
                this.pictureBox1.Image = Image.FromStream(stream);
                cookie =(sender as WebClient).ResponseHeaders[HttpResponseHeader.SetCookie];
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            DownloadValidCode();
        }
    }
}
