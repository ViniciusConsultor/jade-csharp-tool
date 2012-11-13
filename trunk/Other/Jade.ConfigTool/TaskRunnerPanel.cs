using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Jade.Model;

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
    }
}
