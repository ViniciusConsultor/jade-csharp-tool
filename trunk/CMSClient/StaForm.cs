using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using System.Linq;
using System.Data.SqlClient;

namespace Jade
{
    public partial class StaForm : DevExpress.XtraEditors.XtraUserControl
    {
        public StaForm()
        {
            InitializeComponent();
            this.startTime.Value = DateTime.Now.AddDays(-10);
            this.endTime.Value = DateTime.Now.AddDays(1);
        }

        private void StaForm_Load(object sender, EventArgs e)
        {
            /*
             * CREATE VIEW `hfbbs`.`userLogSta` AS
SELECT Count(*) as TotalCount,DATE(CreateTime),UserName FROM hfbbs.userlog
where LogType='发布新闻'
group by UserName,DATE(CreateTime)
             * */

            if (Jade.Properties.Settings.Default.IsOnline)
            {
                var setting = Jade.Properties.Settings.Default;
                SqlConnectionStringBuilder sqlBuilder =
                    new SqlConnectionStringBuilder();

                // Set the properties for the data source.
                sqlBuilder.DataSource = setting.ServerIp;
                sqlBuilder.InitialCatalog = setting.ServerDatabase;
                sqlBuilder.IntegratedSecurity = false;
                sqlBuilder.UserID = setting.ServerUser;
                sqlBuilder.Password = setting.ServerPasword;
                // Build the SqlConnection connection string.
                MySqlHelper.DBConnectionString = sqlBuilder.ToString();

                //var dal = (CacheObject.DownloadDataDAL as Jade.Model.MySql.NewsDAL);
                //if (dal != null)
                //{
                ChartTitle title = new ChartTitle();
                title.Text = "编辑新闻发布量统计";
                chartControl1.Titles.Clear();
                chartControl1.Titles.Add(title);
                chartControl1.Series.Clear();
                //var stas = dal.GetUserLogSta(this.startTime.Value, this.endTime.Value);

                //var userNames = stas.Select(t => t.UserName).ToList();

                var checkDatabase = "SELECT * FROM hfbbs.userlogsta where WorkDate > '" + this.startTime.Value.ToString("yyyy-MM-dd") + "' and WorkDate<'" + this.endTime.Value.ToString("yyyy-MM-dd") + "' ";
                var results = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, checkDatabase);

                var userNames = results.Tables[0].Rows.Cast<DataRow>().Select(r => r["UserName"].ToString()).ToList();

                foreach (var userName in userNames)
                {
                    Series series = new Series(userName, ViewType.Line);
                    series.ArgumentScaleType = ScaleType.DateTime;
                    var datas = results.Tables[0].Rows.Cast<DataRow>().Where(r => r["UserName"] == userName).ToList();
                    foreach (var data in datas)
                    {
                        series.Points.Add(new SeriesPoint(DateTime.Parse(data["WorkDate"].ToString()), new double[] { int.Parse(data["TotalCount"].ToString()) }));
                    }
                    series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                    ((PointSeriesView)series.View).PointMarkerOptions.Kind = MarkerKind.Circle;
                    chartControl1.Series.Add(series);
                }
                //}
            }
            chartControl1.Legend.Visible = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            StaForm_Load(null, null);
        }
    }
}