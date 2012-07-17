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
    public partial class TaskQueqeForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public TaskQueqeForm()
        {
            InitializeComponent();
        }

        private void TaskQueqeForm_DockStateChanged(object sender, EventArgs e)
        {
            Console.WriteLine(this.DockState.ToString());
        }
        BindingSource source = new BindingSource();
        private void TaskQueqeForm_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            source.DataSource = RunningTaskCollection.Instance;
            this.dataGridView1.DataSource = source;
            RunningTaskCollection.Instance.OnChange += new Change(Instance_OnChange);
        }

        void Instance_OnChange(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.BeginInvoke(new MethodInvoker(() =>
                {
                    source.ResetBindings(false);
                    //this.dataGridView1.DataSource = RunningTaskCollection.Instance;
                }));
            }
            catch
            {
            }
        }

        private void 开始采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                var task = RunningTaskCollection.Instance[this.dataGridView1.SelectedCells[0].RowIndex];
                if (task.Status != TaskStatus.运行中)
                {
                    task.StartWork();
                }
            }
        }

        private void 停止采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                var task = RunningTaskCollection.Instance[this.dataGridView1.SelectedCells[0].RowIndex];
                if (task.Status == TaskStatus.运行中)
                {
                    task.StopWork();
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                if (this.dataGridView1.SelectedCells[0].RowIndex > -1 && this.dataGridView1.SelectedCells[0].RowIndex < RunningTaskCollection.Instance.Count)
                {
                    var task = RunningTaskCollection.Instance[this.dataGridView1.SelectedCells[0].RowIndex];
                    if (task.Status == TaskStatus.运行中)
                    {
                        停止采集ToolStripMenuItem.Enabled = true;
                        开始采集ToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        停止采集ToolStripMenuItem.Enabled = false;
                        开始采集ToolStripMenuItem.Enabled = true;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
                
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
