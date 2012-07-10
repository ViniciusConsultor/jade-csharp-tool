using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HFBBS
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

        private void TaskQueqeForm_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = RunningTaskCollection.Instance;
            RunningTaskCollection.Instance.OnChange += new Change(Instance_OnChange);
        }

        void Instance_OnChange(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.BeginInvoke(new MethodInvoker(() =>
                {
                    this.dataGridView1.DataSource = null;
                    this.dataGridView1.DataSource = RunningTaskCollection.Instance;
                    this.dataGridView1.Refresh();
                }));
            }
            catch
            {
            }
        }
    }
}
