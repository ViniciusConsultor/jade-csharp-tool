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
using System.Text.RegularExpressions;

namespace Jade
{
    public partial class LoginForm : Form
    {
        Jade.Properties.Settings setting;
        private ILogin login = null;

        public LoginForm()
        {
            //this.login = login;
            InitializeComponent();
            setting = Jade.Properties.Settings.Default;
            this.rblEdit.Checked = setting.IsEditModel;
            this.rblNotEdit.Checked = !this.rblEdit.Checked;
            this.rblServer.Checked = setting.IsOnline;
            this.rblSingle.Checked = !this.rblServer.Checked;
            this.txtUserName.Text = setting.UserName;
            this.txtPassword.Text = setting.UserPassword;

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
            System.Net.ServicePointManager.Expect100Continue = false;
            MyWebRequest request = CacheObject.WebRequset;
            request.Url = "http://newscms.house365.com/newCMS/chk_log.php";
            request.RequestData = new RequestPostData()
            {
                PostDatas = new List<PostDataItem> { new PostDataItem{
                        Data = "user_name="+this.txtUserName.Text+ "&pass_word="+this.txtPassword.Text+ "&yzmcode=" + this.textBox1.Text + "&login.x=47&login.y=32"
                    }}
            };

            request.Cookie = cookie;
            var result = request.Post();
            Console.WriteLine(result);
            CacheObject.Cookie = request.Cookie;

            // "<script type=\"text/javascript\">alert(\"验证码不正确!\"); location.href=\"../newCMS/login.php\";</script>"
            if (!result.Contains("index.php"))
            {
                if (result.Contains("验证码不正确"))
                {
                    MessageBox.Show("验证码不正确！");
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！");
                }
                DownloadValidCode();
                return;
            }

            var decodeCookie = System.Web.HttpUtility.UrlDecode(CacheObject.Cookie, Encoding.GetEncoding("GB2312"));
            var uStart = decodeCookie.IndexOf("usid=");
            var uEnd = decodeCookie.IndexOf(";", uStart);
            var userId = decodeCookie.Substring(uStart, uEnd - uStart).Replace("usid=", "");
            var trueName = decodeCookie.Substring(decodeCookie.LastIndexOf("=") + 1);

            // var PHPSESSID=d95b4f4b6c6e24be2ac96d1ae826d50c; usid=2190;  channelids=12000000;  user_manage=0%2C12000000;  true_name=%CD%F5%CE%B0%CE%B0

            uStart = decodeCookie.IndexOf("channelids=");
            uEnd = decodeCookie.IndexOf(";", uStart);
            var channelid = decodeCookie.Substring(uStart, uEnd - uStart).Replace("channelids=", "");

            CacheObject.channelid = channelid;

            // 更新setting
            setting.UserName = this.txtUserName.Text;
            setting.UserPassword = this.txtPassword.Text;
            setting.IsEditModel = this.rblEdit.Checked;
            setting.IsOnline = this.rblServer.Checked;
            setting.UserId = userId;
            setting.Name = trueName;
            setting.Save();


            CacheObject.CurrentUser = new User
            {
                Id = setting.UserId,
                Name = trueName,
                UserName = setting.UserName,
                Password = this.txtPassword.Text
            };

            CacheObject.IsLognIn = true;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            return;

            //CookieAwareWebClient client = new CookieAwareWebClient();
            //client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            ////client._cookieContainer = this.cookie;
            //client.Headers[HttpRequestHeader.Cookie] = cookie;
            //client.UploadDataCompleted += new UploadDataCompletedEventHandler(client_UploadDataCompleted);
            //client.UploadDataAsync(new Uri("http://newscms.house365.com/newCMS/chk_log.php"), "POST", System.Text.Encoding.GetEncoding("GB2312").GetBytes("user_name=zhangyang&pass_word=House365&yzmcode=" + this.textBox1.Text + "&login.x=47&login.y=32"));

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
                try
                {

                    MemoryStream stream = new MemoryStream(e.Result, 0, e.Result.Length);
                    this.pictureBox1.Image = Image.FromStream(stream);
                    cookie = (sender as WebClient).ResponseHeaders[HttpResponseHeader.SetCookie].Replace("; path=/", "");
                }
                catch
                {
                    MessageBox.Show("加载验证码出错，请选择离线操作");
                }
            }
            else
            {
                MessageBox.Show("加载验证码出错，请选择离线操作");
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            DownloadValidCode();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DownloadValidCode();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setting.UserName = this.txtUserName.Text;
            setting.UserPassword = this.txtPassword.Text;
            setting.IsEditModel = this.rblEdit.Checked;
            setting.IsOnline = this.rblServer.Checked;
            setting.Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }
    }
}
