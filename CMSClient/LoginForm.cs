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
using System.Data.SqlClient;

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
            var result = "";
            try
            {
                result = request.Post();
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接CMS服务器失败，错误信息为：" + ex.Message + "\n你可以选择离线模式");
                Log4Log.Exception(ex);
            }

            //var result = RemoteAPI.POST("http://newscms.house365.com/newCMS/chk_log.php", "user_name=" + this.txtUserName.Text + "&pass_word=" + this.txtPassword.Text + "&yzmcode=" + this.textBox1.Text + "&login.x=47&login.y=32");

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


            if (setting.IsOnline)
            {
                try
                {
                    if (!InitDataBase())
                    {
                        MessageBox.Show("启用工作组模式失败——数据库初始化失败，请选择本地模式！");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Log4Log.Exception(ex);
                    MessageBox.Show("启用工作组模式失败，数据库连接失败，请确认用户名密码是是否正确\n你可以先选择单机模式，然后在系统设置里配置数据库连接参数");
                    return;
                }
            }

            CacheObject.DownloadDataDAL = DatabaseFactory.Instance.CreateDAL();

            CacheObject.CurrentUser = new User
            {
                Id = setting.UserId,
                Name = trueName,
                UserName = setting.UserName,
                Password = this.txtPassword.Text
            };

            CacheObject.IsLognIn = true;

            try
            {
                if (setting.IsOnline)
                {
                    RemoteAPI.GetNewsId();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取CMS系统参数失败！");
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            return;

            //CookieAwareWebClient client = new CookieAwareWebClient();
            //client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            ////client._cookieContainer = this.cookie;
            //client.Headers[HttpRequestHeader.Cookie] = cookie;
            //client.UploadDataCompleted += new UploadDataCompletedEventHandler(client_UploadDataCompleted);
            //client.UploadDataAsync(new Uri("http://newscms.house365.com/newCMS/chk_log.php"), "POST", System.Text.Encoding.GetEncoding("GB2312").GetBytes("user_name=zhangyang&pass_word=House365&yzmcode=" + this.textBox1.Text + "&login.x=47&login.y=32"));

        }

        bool InitDataBase()
        {
            string serverName = setting.ServerIp;
            string databaseName = setting.ServerDatabase;

            // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder =
                new SqlConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = "INFORMATION_SCHEMA";
            sqlBuilder.IntegratedSecurity = false;
            sqlBuilder.UserID = setting.ServerUser;
            sqlBuilder.Password = setting.ServerPasword;
            // Build the SqlConnection connection string.
            MySqlHelper.DBConnectionString = sqlBuilder.ToString();
            var checkDatabase = "SELECT * FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = '" + setting.ServerDatabase + "'";
            var reader = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, checkDatabase);
            if (reader.Tables.Count == 0 || reader.Tables[0].Rows.Count == 0)
            {
                //$$
                if (MessageBox.Show("检测到不存在数据库" + setting.ServerDatabase + "，是否创建?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text, "CREATE DATABASE `" + setting.ServerDatabase + "` /*!40100 DEFAULT CHARACTER SET utf8 */");
                }
                else
                {
                    return false;
                }

            }

            sqlBuilder.InitialCatalog = setting.ServerDatabase;
            MySqlHelper.DBConnectionString = sqlBuilder.ToString(); ;
            var checkTable = " SELECT * FROM information_schema.tables where table_type = 'BASE TABLE' AND TABLE_SCHEMA = '" + setting.ServerDatabase + "' AND TABLE_NAME = 'downloaddata'";
            var tables = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, checkTable);
            if (tables.Tables.Count > 0 && tables.Tables[0].Rows.Count == 1)
            {

            }
            else
            {
                if (MessageBox.Show("检测到不存在数据表downloaddata,是否自动创建?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //
                    var sql = @"CREATE TABLE `downloaddata` (
  `ID` int(11) NOT NULL auto_increment,
  `TaskId` int(11) default NULL,
  `Title` text,
  `SubTitle` text,
  `Keywords` text,
  `news_source_name` text,
  `news_template_file` text,
  `news_top` text,
  `news_guideimage` text,
  `news_guideimage2` text,
  `news_description` text,
  `news_link` text,
  `news_down` text,
  `news_right` text,
  `news_left` text,
  `comment_url` text,
  `news_video` text,
  `news_keywords2` text,
  `label_base` text,
  `cmspinglun` bit(1) NOT NULL default '\0',
  `bbspinglun` bit(1) NOT NULL default '\0',
  `ISkfbm` bit(1) NOT NULL default '\0',
  `kfbm_id` text,
  `kfbm_link` text,
  `ISgfbm` bit(1) NOT NULL default '\0',
  `gfbm_id` text,
  `gfbm_link` text,
  `news_abs` text,
  `Content` text,
  `Summary` text,
  `Source` text,
  `CreateTime` text,
  `Other` text,
  `Url` text,
  `IsEdit` bit(1) NOT NULL default '\0',
  `EditorUserName` text,
  `DownloadTime` datetime default NULL,
  `IsDownload` bit(1) NOT NULL default '\0',
  `IsPublish` bit(1) NOT NULL default '\0',
  `EditTime` datetime default NULL,
  `RemoteId` int(11) NOT NULL default '0',
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8";
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text, sql);
                }
                else
                {
                    return false;
                }
            }
            checkTable = " SELECT * FROM information_schema.tables where table_type = 'BASE TABLE' AND TABLE_SCHEMA = '" + setting.ServerDatabase + "' AND TABLE_NAME = 'imagefiles'";
            tables = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, checkTable);
            if (tables.Tables.Count > 0 && tables.Tables[0].Rows.Count == 1)
            {

            }
            else
            {
                if (MessageBox.Show("检测到不存在数据表imagefiles，是否自动创建?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var sql = @"CREATE TABLE `imagefiles` (
  `Id` int(11) NOT NULL auto_increment,
  `FileName` text NOT NULL,
  `Url` text NOT NULL,
  `Data` longblob,
  PRIMARY KEY  (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8";

                    MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text, sql);
                }
                else
                {
                    return false;
                }
            }

            checkTable = " SELECT * FROM information_schema.tables where table_type = 'BASE TABLE' AND TABLE_SCHEMA = '" + setting.ServerDatabase + "' AND TABLE_NAME = 'userlog'";
            tables = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, checkTable);
            if (tables.Tables.Count > 0 && tables.Tables[0].Rows.Count == 1)
            {

            }
            else
            {
                if (MessageBox.Show("检测到不存在数据表userlog，是否自动创建?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var sql = @"CREATE TABLE `userlog` (
  `Id` int(11) NOT NULL auto_increment,
  `UserName` varchar(100) default NULL,
  `LogType` varchar(100) default '登录',
  `Description` varchar(200) default '',
  `CreateTime` datetime default NULL,
  PRIMARY KEY  (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户操作日志'";

                    MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text, sql);
                }
                else
                {
                    return false;
                }
            }
            return true;

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


            if (setting.IsOnline)
            {
                try
                {
                    if (!InitDataBase())
                    {
                        MessageBox.Show("启用工作组模式失败——数据库初始化失败，请选择本地模式！");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Log4Log.Exception(ex);
                    MessageBox.Show("启用工作组模式失败，数据库连接失败，请确认用户名密码是是否正确\n你可以先选择单机模式，然后在系统设置里配置数据库连接参数");
                    return;
                }
            }

            // 重新设置DAL
            CacheObject.DownloadDataDAL = DatabaseFactory.Instance.CreateDAL();

            if (Jade.Properties.Settings.Default.IsOnline)
            {
                (CacheObject.DownloadDataDAL as Jade.Model.MySql.NewsDAL).AddLog(Jade.Properties.Settings.Default.Name, "登录CMS Client");
            }
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
