using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using HFBBS.Model;

namespace HFBBS
{
    public partial class TaskRunForm : WeifenLuo.WinFormsUI.Docking.DockContent, HFBBS.ILog
    {
        public SiteRule Task { get; set; }

        TaskRunner taskRunner;

        public TaskRunForm(SiteRule rule)
        {
            this.DoubleBuffered = true;
            Task = rule;
            InitializeComponent();
            this.Text = rule.Name + "[运行]";
            this.TabText = rule.Name + "[运行]";
            taskRunner = new TaskRunner(rule, this, new BLL.DataSaverManager());
            taskRunner.StateChange += new TaskStateChange(taskRunner_StateChange);

        }

        void taskRunner_StateChange(object sender, TaskRunnerEventArgs e)
        {
            this.lblStep.BeginInvoke(new MethodInvoker(() =>
            {
                this.lblStep.Text = e.CurrentState.StepName;
                this.lblProcess.Text = e.CurrentState.CurrentCount + "/" + e.CurrentState.TotalCount;
                this.progressBar1.Maximum = e.CurrentState.TotalCount;
                this.progressBar1.Value = e.CurrentState.CurrentCount;
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
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = DownloadFileCollection.Instance.GetDownloadFiles(Task.SiteRuleId);
            DownloadFileCollection.Instance.OnChange += new Change(Instance_OnChange);
        }

        void Instance_OnChange(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.BeginInvoke(new MethodInvoker(() =>
                {
                    this.dataGridView1.DataSource = null;
                    this.dataGridView1.DataSource = DownloadFileCollection.Instance.GetDownloadFiles(Task.SiteRuleId);
                }));
            }
            catch
            {
            }
        }
    }
}
