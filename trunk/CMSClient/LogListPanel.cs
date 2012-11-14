using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Jade
{
    public partial class LogListPanel : DevExpress.XtraEditors.XtraUserControl
    {
        public LogListPanel()
        {
            InitializeComponent();
            this.devPager1.PageChange += new EventPagingHandler(devPager1_PageChange);
            btnSearch_Click(null, null);
        }

        void devPager1_PageChange(EventPagingArg e)
        {
            var newsDal = CacheObject.DownloadDataDAL as Jade.Model.MySql.NewsDAL;

            if (newsDal != null)
            {
                int totalCount;
                this.gridControl1.DataSource = newsDal.GetUserLogs(this.txtKeyword.Text, devPager1.CurrentPageIndex, currentPageSize, out totalCount);
            }
            else
            {
                MessageBox.Show("请启用工作组模式");
            }
        }

        int currentPageSize = 20;

        private void btnSearch_Click(object sender, EventArgs e)
        {

            int totalCount;

            var newsDal = CacheObject.DownloadDataDAL as Jade.Model.MySql.NewsDAL;

            if (newsDal != null)
            {
                this.gridControl1.DataSource = newsDal.GetUserLogs(this.txtKeyword.Text, 1, currentPageSize, out totalCount);
                this.devPager1.CurrentPageIndex = 1;
                this.devPager1.PageSize = currentPageSize;
                this.devPager1.TotalCount = totalCount;
                this.devPager1.Bind();
            }
            else
            {
                //MessageBox.Show("请启用工作组模式");
            }
        }

        private void chkOnlyMyContent_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkOnlyMyContent.Checked)
            {
                this.txtKeyword.Text = CacheObject.CurrentUser.Name;
            }
            else
            {
                this.txtKeyword.Text = "";
            }
            btnSearch_Click(null, null);
        }
    }
}
