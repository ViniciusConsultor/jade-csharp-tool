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
    public partial class TaskRunnerPanel : DevExpress.XtraEditors.XtraUserControl
    {
        public TaskRunnerPanel()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.runningTaskCollectionBindingSource.DataSource = RunningTaskCollection.Instance;
            RunningTaskCollection.Instance.OnChange += new Change(Instance_OnChange);
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);

        }
        void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Equals(EndTime))
            {
                var dataTable = RunningTaskCollection.Instance;
                var data = dataTable[e.RowHandle];
                if (data.EndTime < new DateTime(2012, 1, 1, 0, 0, 0, 0))
                    e.DisplayText = "----";
            }
        }
        void Instance_OnChange(object sender, EventArgs e)
        {
            try
            {
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    this.runningTaskCollectionBindingSource.ResetBindings(true);
                }));
            }
            catch
            {
            }
        }

        private void 开始采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.gridView1.FocusedRowHandle > -1)
            {
                var task = RunningTaskCollection.Instance[this.gridView1.FocusedRowHandle];
                if (task.Status != TaskStatus.运行中)
                {
                    task.StartWork();
                }
            }
        }

        private void 停止采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.gridView1.SelectedRowsCount > -1)
            {
                var task = RunningTaskCollection.Instance[this.gridView1.FocusedRowHandle];
                if (task.Status == TaskStatus.运行中)
                {
                    task.StopWork();
                }
            }
        }
    }
}
