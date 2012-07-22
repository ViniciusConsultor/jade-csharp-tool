using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Jade.Model;
using BrightIdeasSoftware;

namespace Jade
{
    public partial class TaskRunForm : DevExpress.XtraEditors.XtraUserControl, Jade.ILog
    {
        public SiteRule Task { get; set; }

        public TaskRunner taskRunner;

        public TaskRunForm(SiteRule rule)
        {
            this.DoubleBuffered = true;
            Task = rule;
            InitializeComponent();
            this.Text = rule.Name + "[运行]";
            //this.TabText = rule.Name + "[运行]";
            taskRunner = new TaskRunner(rule, this, new BLL.DataSaverManager());
            taskRunner.StateChange += new TaskStateChange(taskRunner_StateChange);
            this.treeListView1.CanExpandGetter = delegate(object x)
            {
                return false;
            };


            this.olvColumnProgress.Renderer = new BarRenderer(0, 100);

            this.olvColumnSpeed.AspectGetter = delegate(object x)
            {
                var value = ((DownloadFile)x).Speed.ToString("0.00 KB/s");
                return value;
            };

            this.olvColumn1.AspectGetter = delegate(object x)
            {
                return ((DownloadFile)x).Status.ToString();
            };
        }

        void taskRunner_StateChange(object sender, TaskRunnerEventArgs e)
        {
            this.lblStep.BeginInvoke(new MethodInvoker(() =>
            {
                if (e.CurrentState.StepName == "采集完成")
                {
                    //this.TabText = Task.Name + "[采集完成]";
                }
                else
                {
                    //this.TabText = Task.Name + "[" + e.CurrentState.StepName + "]";
                    this.lblStep.Text = e.CurrentState.StepName;
                    this.lblProcess.Text = e.CurrentState.CurrentCount + "/" + e.CurrentState.TotalCount;
                    this.progressBar1.Maximum = e.CurrentState.TotalCount;
                    this.progressBar1.Value = e.CurrentState.CurrentCount;
                }
            }));
        }

        private void InsertToRichTextbox(string str, RichTextBox txtbox, Color color)
        {
            try
            {
                lock (this)
                {
                    int i = txtbox.SelectionStart;
                    txtbox.Select(i, 0);
                    txtbox.SelectionColor = color;
                    txtbox.Focus();
                    txtbox.AppendText(str + "\r\n");
                    txtbox.Select(i + str.Length + 2, 0);
                    txtbox.SelectionColor = Color.Black;
                }
            }
            catch
            {
            }
        }

        public void Info(string msg)
        {
            Log(msg, Color.Black);
        }

        public void Success(string msg)
        {
            Log(msg, Color.Green);
        }

        public void Error(string msg)
        {
            Log(msg, Color.Red);

        }

        public void Warn(string msg)
        {
            Log(msg, Color.Yellow);
        }

        public void Log(string msg, Color color)
        {
            try
            {
                this.txtLog.BeginInvoke(new MethodInvoker(() =>
                {
                    InsertToRichTextbox(msg, this.txtLog, color);
                }));
            }
            catch
            {
            }
        }

        private void TaskRunForm_Load(object sender, EventArgs e)
        {
            new Thread(taskRunner.Start).Start();
            treeListView1.Roots = DownloadFileCollection.Instance.GetDownloadFiles(Task.SiteRuleId);
            DownloadFileCollection.Instance.OnChange += new Change(Instance_OnChange);
        }

        //BindingSource source = new BindingSource();


        void Instance_OnChange(object sender, EventArgs e)
        {
            try
            {
                this.treeListView1.BeginInvoke(new MethodInvoker(() =>
                {
                    treeListView1.Roots = DownloadFileCollection.Instance.GetDownloadFiles(Task.SiteRuleId);
                    //treeListView1.Refresh();
                }));
            }
            catch
            {
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
    }
}
