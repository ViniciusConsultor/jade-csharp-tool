using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using WeifenLuo.WinFormsUI.Docking;

namespace HFBBS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitDockPanel();
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
            var siteRule = new SiteRuleForm();
            AddDock(siteRule, DockState.DockLeft);
            //AddDock(new TaskQueqeForm(), DockState.DockTopAutoHide);
            new ContentManageForm().Show(siteRule.Pane, DockAlignment.Bottom, 0.5);
            var taskForm = new WelcomeForm();
            AddDock(taskForm, DockState.Document);
            taskForm.DockAreas = DockAreas.Document;
            var queqe = new TaskQueqeForm();
            queqe.Show(taskForm.Pane, DockAlignment.Top, 0.2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HFBBS.Helper.AccessHelper.CreateMDBDataBase();
            CacheObject.MainForm = this;
            DialogResult dr = new FrmLogin(new TestLogin()).ShowDialog();

            if (dr == DialogResult.Cancel)
            {
                this.Close();
            }
            else
            {
                this.Show();
                this.WindowState = FormWindowState.Maximized;
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
