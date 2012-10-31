using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jade.Model;
using System.Data.SqlClient;

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

            try
            {
                if (!InitDataBase())
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                Log4Log.Exception(ex);
                MessageBox.Show("数据库连接失败，请确认用户名密码是是否正确");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
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


            return true;

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
