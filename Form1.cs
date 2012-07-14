using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace HFBBS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitDockPanel();

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 50; j++)
                {
                    var bitmap = ImageHelper.Cut(HFBBS.Properties.Resources.icons, j * 20, 20 * i, 20, 20);
                    bitmap.Save("d:\\icons\\" + i + j + ".bmp");
                }
            }

            //var bitmap = ImageHelper.Cut(HFBBS.Properties.Resources.icons, 0, 0, 1000, 20);
            //bitmap.Save("d:\\1.bmp");
            //bitmap = ImageHelper.Cut(HFBBS.Properties.Resources.icons, 0, 20, 1000, 20);
            //bitmap.Save("d:\\2.bmp");
            //bitmap = ImageHelper.Cut(HFBBS.Properties.Resources.icons, 0, 40, 1000, 20);
            //bitmap.Save("d:\\3.bmp");
            //this.keywordBox1.Keywords = new List<string> { "思想", "音乐", "80后", "美食", "旅游", "电影", "听音乐", "时尚", "摄影", "健康" };
        }

        class TestLogin : ILogin
        {

            #region ILogin 成员

            public bool ValidateUser(string username, string password)
            {
                return true;
            }

            #endregion
        }

        /// <summary>
        /// 添加DOCK
        /// </summary>
        /// <param name="dockContent"></param>
        /// <param name="state"></param>
        public void AddDock(DockContent dockContent, DockState state)
        {
            dockContent.Show(this.dockPanel1, state);
        }

        public virtual void InitDockPanel()
        {
            var siteRule = new ContentManageForm();
            siteRule.Width = 150;
            AddDock(siteRule, DockState.DockLeft);
            //AddDock(new TaskQueqeForm(), DockState.DockTopAutoHide);
           // new ContentManageForm().Show(siteRule.Pane, DockAlignment.Bottom, 0.5);

            var taskForm = new WelcomeForm();
            AddDock(taskForm, DockState.Document);
            taskForm.DockAreas = DockAreas.Document;
            var queqe = new TaskQueqeForm();
            AddDock(queqe, DockState.DockTop);
            //queqe.Show(taskForm.Pane, DockAlignment.Top, 0.2);
            queqe.DockState = DockState.DockTopAutoHide;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //////HFBBS.Helper.AccessHelper.CreateMDBDataBase();
            CacheObject.MainForm = this;
            DialogResult dr = new LoginForm(new TestLogin()).ShowDialog();

            if (dr == DialogResult.Cancel)
            {
                this.Close();
            }
            else
            {
                this.Show();
                this.WindowState = FormWindowState.Maximized;
                var tasks = CacheObject.Rules.Where(t => t.EnableAutoRun).ToList();

                if (tasks.Count > 0)
                {
                    if (MessageBox.Show("系统发现你有设为自动运行的采集任务,是否现在开始自动执行采集任务？", "自动采集确认!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        // 立即开始
                        tasks.ForEach(task =>
                        {
                            var runnerForm = new TaskRunForm(task);
                            CacheObject.MainForm.AddDock(runnerForm, WeifenLuo.WinFormsUI.Docking.DockState.Document);
                        });
                    }
                }
            }
        }


        public void ShowDock(string itemText)
        {
            DockContent item = null;
            string type = itemText;//uc.GetType().Name;
            if (CacheObject.MdiDict.ContainsKey(type))
            {
                item = CacheObject.MdiDict[type];
                item.Activate();
            }
        }
    }
}
