using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraRichEdit;
using Jade.Properties;
using Jade.Model;
using DevExpress.XtraSplashScreen;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Jade
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm, Jade.ILog
    {
        BaseDocument d;
        public MainForm()
        {
            InitializeComponent();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");
            CacheObject.MainForm = this;

            this.DoubleBuffered = true;
            this.imageList1.Images.Add(Resources.scheduled_tasks__1_);
            this.imageList1.Images.Add(Resources.sites);
            ImageIndexDic.Add("sites", this.imageList1.Images.Count - 1);
            WelcomePanel form = new WelcomePanel();
            tabbedView1.BeginUpdate();
            d = tabbedView1.Controller.AddDocument(form);
            d.Form.Text = "WelcomeForm";
            d.Caption = "WelcomeForm";
            tabbedView1.EndUpdate();

            var categories = CacheObject.Categories.Where(c => c.ParentCategoryID == 0);
            var baseNode = this.taskTree.Nodes[0];
            foreach (var category in categories)
            {
                InitTree(baseNode, category);
            }
            this.taskTree.ExpandAll();

            //throw new Exception("test");

        }

        Dictionary<string, int> ImageIndexDic = new Dictionary<string, int>();

        int GetImageIndex(string icon)
        {
            if (string.IsNullOrEmpty(icon))
            {
                icon = "favicon.ico";
            }

            if (ImageIndexDic.ContainsKey(icon))
            {
                return ImageIndexDic[icon];
            }
            else
            {
                try
                {
                    this.imageList1.Images.Add(Image.FromFile(CacheObject.IconDir + "\\" + icon));
                    ImageIndexDic.Add(icon, this.imageList1.Images.Count - 1);
                    return this.imageList1.Images.Count - 1;
                }
                catch
                {
                    return 0;
                }
            }
        }

        private void InitTree(TreeNode baseNode, Model.Category category)
        {

            TreeNode node = new TreeNode(category.Name, 0, 0);
            node.Tag = category;
            var childCategories = CacheObject.Categories.Where(c => c.ParentCategoryID == category.ID);
            foreach (var childCategory in childCategories)
            {
                InitTree(node, childCategory);
            }
            var rules = CacheObject.Rules.Where(r => r.CategoryID == category.ID);
            foreach (var rule in rules)
            {
                var index = GetImageIndex(rule.IconImage);
                TreeNode leaf = new TreeNode(rule.Name, index, index);
                leaf.Tag = rule;
                node.Nodes.Add(leaf);
            }
            baseNode.Nodes.Add(node);
        }

        private TreeNode CurrentCategoryNode;
        private Category CurrentCategory;
        private void add(string s)
        {
            //RichEditControl control = new RichEditControl();
            //control.Name = s;
            //control.Text = s;
            //control.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            //control.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            //control.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            //control.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            //control.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            //tabbedView1.BeginUpdate();
            //BaseDocument document = tabbedView1.Controller.AddDocument(control);
            //control.Document.Sections[0].Page.Width = 10000;
            //document.Form.Text = s;
            //tabbedView1.EndUpdate();
        }

        //private void navBarGroup2_ItemChanged(object sender, EventArgs e)
        //{
        //    // 任务管理
        //    switch (navBarGroup2.SelectedLink.ItemName)
        //    {
        //        case "草稿箱":
        //            MessageBox.Show("草稿箱");
        //            break;
        //    }
        //}

        //private void navTask_ItemChanged(object sender, EventArgs e)
        //{
        //    // 任务管理
        //    switch (navTask.SelectedLink.ItemName)
        //    {
        //        case "草稿箱":
        //            MessageBox.Show("草稿箱");
        //            break;
        //    }
        //}

        BaseDocument editor;

        private void navDraft_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            PrepareContentPanel();
            editor.Caption = "草稿箱（未送CMS）";
            var draft = editor.Control as ContentListPanel;
            draft.IsEdited = false;
            draft.IsPublished = false;
            tabbedView1.Controller.Activate(editor);
        }

        private void PrepareContentPanel()
        {
            if (editor == null || editor.Control == null)
            {
                //SplashScreenManager.ShowForm(typeof(WaitForm1));
                tabbedView1.BeginUpdate();
                // var form = new DraftBoxForm();
                var form = new ContentListPanel();
                editor = tabbedView1.Controller.AddDocument(form);
                editor.Form.Text = "草稿箱";
                editor.Caption = "草稿箱";
                var draft = editor.Control as ContentListPanel;
                //draft.IsEdited = false;
                //draft.IsPublished = false;
                tabbedView1.EndUpdate();
                //SplashScreenManager.CloseForm();
            }
        }

        BaseDocument newsDoc = null;

        public void OpenNewUrl(string url, WebBrowser parent = null)
        {
            tabbedView1.BeginUpdate();
            var form = new WelcomePanel(parent);
            var doc = tabbedView1.Controller.AddDocument(form);
            form.Navigate(url, doc);
            doc.Caption = "新窗口";
            tabbedView1.EndUpdate();
            tabbedView1.Controller.Activate(doc);
        }

        public void OpenNewUrlAndClose(string url, WebBrowser parent = null)
        {
            tabbedView1.BeginUpdate();
            var form = new WelcomePanel(parent);
            var doc = tabbedView1.Controller.AddDocument(form);
            form.NavigateAndClose(url, doc);
            //Thread
            doc.Caption = "新窗口";
            tabbedView1.EndUpdate();
            tabbedView1.Controller.Activate(doc);
        }

        public void GernateHtml(string url, string newsId)
        {
            //http://newscms.house365.com/newCMS/template/createhtml.php?news_id=020734942&channel_id=8000000
            tabbedView1.BeginUpdate();
            var form = new WelcomePanel(null);
            var doc = tabbedView1.Controller.AddDocument(form);
            form.GernateHtml(url, doc, newsId);
            newsDoc = doc;
            //Thread
            doc.Caption = "新窗口";
            tabbedView1.EndUpdate();
            tabbedView1.Controller.Activate(doc);

        }

        public void CloseDoc(BaseDocument doc)
        {
            tabbedView1.Controller.RemoveDocument(doc);
            doc.Dispose();
            if (newsDoc != null && newsDoc.Control != null)
            {
                tabbedView1.Controller.Activate(newsDoc);
            }
            else
            {
                tabbedView1.Controller.Activate(editor);
            }
        }

        private void navEdited_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            PrepareContentPanel();
            editor.Caption = "已编辑但未签发";
            var draft = editor.Control as ContentListPanel;
            draft.IsEdited = true;
            draft.IsPublished = false;
            tabbedView1.Controller.Activate(editor);
        }

        private void navPublished_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            PrepareContentPanel();
            var draft = editor.Control as ContentListPanel;
            draft.IsEdited = false;
            draft.IsPublished = true;
            editor.Caption = "已编辑且已送CMS";
            tabbedView1.Controller.Activate(editor);
        }

        private void 新建分组ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CategoryForm();
            if (DialogResult.OK == form.ShowDialog())
            {
                var category = form.CurrentCategory;
                CacheObject.RuleManager.AddCategory(category);

                var node = new TreeNode(category.Name, 0, 0);
                node.Tag = category;
                if (category.ParentCategoryID == 0)
                {
                    this.taskTree.Nodes[0].Nodes.Add(node);
                }
                else if (CurrentCategoryNode != null)
                {
                    CurrentCategoryNode.Nodes.Add(node);
                }
            }
        }

        private void taskTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.CurrentCategoryNode = e.Node;
        }

        private void 编辑分组ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CategoryForm(CurrentCategory);
            if (DialogResult.OK == form.ShowDialog())
            {
                var category = form.CurrentCategory;
                CacheObject.RuleManager.UpdateCategory(category);
                this.CurrentCategoryNode.Text = category.Name;
                this.CurrentCategoryNode.Tag = category;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (this.taskTree.SelectedNode != null && this.taskTree.SelectedNode.Tag is Category)
            {
                CurrentCategory = this.taskTree.SelectedNode.Tag as Category;
                this.编辑分组ToolStripMenuItem.Enabled = true;
                this.删除分组ToolStripMenuItem.Enabled = true;
                this.新建任务ToolStripMenuItem.Enabled = true;
                toolStripMenuItem3.Enabled = true;
                this.粘贴规则ToolStripMenuItem.Enabled = true;
                this.复制规则ToolStripMenuItem.Enabled = false;
            }
            else
            {
                CurrentCategory = null;
                this.编辑分组ToolStripMenuItem.Enabled = false;
                this.删除分组ToolStripMenuItem.Enabled = false;
                this.新建任务ToolStripMenuItem.Enabled = false;
                toolStripMenuItem3.Enabled = false;
                this.粘贴规则ToolStripMenuItem.Enabled = false;
                this.复制规则ToolStripMenuItem.Enabled = true;
            }

            if (this.taskTree.SelectedNode != null && this.taskTree.SelectedNode.Tag is SiteRule)
            {
                this.编辑任务ToolStripMenuItem.Enabled = true;
                this.删除任务ToolStripMenuItem.Enabled = true;
                this.运行ToolStripMenuItem.Enabled = true;
                toolStripMenuItem4.Enabled = true;
            }
            else
            {
                this.编辑任务ToolStripMenuItem.Enabled = false;
                toolStripMenuItem4.Enabled = false;
                this.删除任务ToolStripMenuItem.Enabled = false;
                this.运行ToolStripMenuItem.Enabled = false;

            }

        }

        private void 删除分组ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除?", "删除警告", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (CacheObject.Rules.Any(r => r.CategoryID == CurrentCategory.ID))
                {
                    MessageBox.Show("不能删除包含任务的分类");
                }
                else
                {
                    CacheObject.RuleManager.DeleteCategory(CurrentCategory.ID);
                    CacheObject.Categories.Remove(CurrentCategory);
                    this.CurrentCategoryNode.Parent.Nodes.Remove(this.CurrentCategoryNode);
                    MessageBox.Show("删除成功");
                }
            }
        }

        private void 新建任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var siteRule = SiteRule.CreateDefaultRule();
            siteRule.CategoryID = this.CurrentCategory.ID;
            var ruleForm = new SiteRuleEditForm(siteRule);
            //CacheObject.BLL.AddSite(siteRule);
            if (ruleForm.ShowDialog() == DialogResult.OK)
            {
                siteRule = ruleForm.CurrentSiteRule;
                CacheObject.RuleManager.AddSite(siteRule);
                var index = GetImageIndex(siteRule.IconImage);
                TreeNode leaf = new TreeNode(siteRule.Name, index, index);
                leaf.Tag = siteRule;
                this.CurrentCategoryNode.Nodes.Add(leaf);
            }
        }

        private void tasktree_DoubleClick(object sender, EventArgs e)
        {
            if (this.taskTree.SelectedNode != null && this.taskTree.SelectedNode.Tag is SiteRule)
            {
                toolStripMenuItem4_Click(sender, e);
            }
        }

        private void EditSiteRule()
        {
            var editForm = new SiteRuleEditForm(this.taskTree.SelectedNode.Tag as SiteRule);
            if (editForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var siteRule = editForm.CurrentSiteRule;
                CacheObject.RuleManager.Update(siteRule);
                this.taskTree.SelectedNode.Tag = siteRule;
                this.taskTree.SelectedNode.Text = siteRule.Name;
                this.taskTree.SelectedNode.ImageIndex = GetImageIndex(siteRule.IconImage);
                this.taskTree.SelectedNode.SelectedImageIndex = GetImageIndex(siteRule.IconImage);
            }
        }

        private void 删除任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除任务?", "警告", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                var rule = this.taskTree.SelectedNode.Tag as SiteRule;
                CacheObject.RuleManager.DeleteSite(rule.SiteRuleId);
                CacheObject.Rules.Remove(rule);
                this.taskTree.SelectedNode.Parent.Nodes.Remove(this.taskTree.SelectedNode);
                MessageBox.Show("删除成功");
            }
        }

        private void 编辑任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSiteRule();
        }

        private void 运行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var task = this.taskTree.SelectedNode.Tag as SiteRule;
            var taskRunner = new TaskRunner(task, this, new BLL.DataSaverManager());
            new System.Threading.Thread(taskRunner.Start).Start();

            dockManager1.ActivePanel = this.dockPanel2;

            //var runnerForm = new TaskRunForm(task);

            //tabbedView1.BeginUpdate();
            //var document = tabbedView1.Controller.AddDocument(runnerForm);
            //document.Form.Text = task.Name;
            //document.Caption = task.Name + "[运行中]";
            //tabbedView1.EndUpdate();

            //CacheObject.MainForm.AddDock(runnerForm, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CurrentCategory = this.taskTree.SelectedNode.Tag as Category;
            var siteRule = SiteRule.CreateDefaultRule();
            siteRule.CategoryID = this.CurrentCategory.ID;
            // var ruleForm = new SiteRuleEditForm(siteRule);
            var ruleForm = new SiteRuleWizardForm(siteRule);
            //new TaskWizardForm(siteRule);
            //CacheObject.BLL.AddSite(siteRule);
            if (ruleForm.ShowDialog() == DialogResult.OK)
            {
                siteRule = ruleForm.CurrentSiteRule;
                CacheObject.RuleManager.AddSite(siteRule);
                var index = GetImageIndex(siteRule.IconImage);
                TreeNode leaf = new TreeNode(siteRule.Name, index, index);
                leaf.Tag = siteRule;
                this.CurrentCategoryNode.Nodes.Add(leaf);
                ruleForm.Dispose();
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var editForm = new SiteRuleWizardForm(this.taskTree.SelectedNode.Tag as SiteRule);
            if (editForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var siteRule = editForm.CurrentSiteRule;
                CacheObject.RuleManager.Update(siteRule);
                var index = GetImageIndex(siteRule.IconImage);
                this.taskTree.SelectedNode.Tag = siteRule;
                this.taskTree.SelectedNode.Text = siteRule.Name;
                this.taskTree.SelectedNode.ImageIndex = GetImageIndex(siteRule.IconImage);
                this.taskTree.SelectedNode.SelectedImageIndex = GetImageIndex(siteRule.IconImage);
                editForm.Dispose();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Jade.Helper.AccessHelper.CreateMDBDataBase();

            navDraft_LinkClicked(sender, null);

            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();

            if (!CacheObject.IsDebug)
            {
                DialogResult dr = new LoginForm().ShowDialog();

                if (dr == DialogResult.Cancel)
                {
                    this.Close();
                }
            }
            // CacheObject.NavForm.UpdateUI();
            this.Show();
            this.WindowState = FormWindowState.Maximized;
            var tasks = CacheObject.Rules.Where(t => t.EnableAutoRun).ToList();
            this.Text += " 欢迎你," + CacheObject.CurrentUser.Name;
            if (CacheObject.IsTest)
            {
                this.Text += " (试用版）- （每次限采集50篇新闻，允许多次采集)";
            }

            if (Properties.Settings.Default.IsEditModel)
            {
                this.navBarControl1.ActiveGroup = this.navBarGroup2;
            }
            else
            {
                this.navBarControl1.ActiveGroup = this.navTask;
            }



            if (CacheObject.IsLognIn)
            {
                // 更新API数据
                new System.Threading.Thread(() =>
                {
                    RemoteAPI.GetNewsId();
                }).Start();

                if (d == null || d.Control == null)
                {
                    tabbedView1.BeginUpdate();
                    WelcomePanel form = new WelcomePanel();
                    d = tabbedView1.Controller.AddDocument(form);

                    WelcomePanel testForm = new WelcomePanel();
                    var d2 = tabbedView1.Controller.AddDocument(testForm);
                    d2.Caption = "测试";

                    tabbedView1.EndUpdate();
                }
                d.Form.Text = "远程网站";
                d.Caption = "远程网站";
                if (d != null)
                {
                    (d.Control as WelcomePanel).Navigate("http://newscms.house365.com/newCMS/index.php", d, CacheObject.Cookie);

                    tabbedView1.Controller.Activate(d);
                }
            }

            if (tasks.Count > 0)
            {
                if (MessageBox.Show("系统发现你有设为自动运行的采集任务,是否现在开始自动执行采集任务？", "自动采集确认!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    // 立即开始
                    tasks.ForEach(task =>
                    {
                        var taskRunner = new TaskRunner(task, this, new BLL.DataSaverManager());
                        new System.Threading.Thread(taskRunner.Start).Start();
                    });
                }
            }

        }

        private void barDockingMenuItem1_ListItemClick(object sender, ListItemClickEventArgs e)
        {

        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void galleryControl1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            toolStripMenuItem4_Click(sender, e);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            var task = this.taskTree.SelectedNode.Tag as SiteRule;

            if (task != null)
            {
                var taskRunner = new TaskRunner(task, this, new BLL.DataSaverManager());
                new System.Threading.Thread(taskRunner.Start).Start();
                dockManager1.ActivePanel = this.dockPanel4;
                //var runnerForm = new TaskRunForm(task);
                //tabbedView1.BeginUpdate();
                //var document = tabbedView1.Controller.AddDocument(runnerForm);
                //document.Form.Text = task.Name;
                //document.Caption = task.Name + "[运行中]";
                //tabbedView1.EndUpdate();
            }
            else
            {
                MessageBox.Show("请选择一个任务");
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.taskTree.SelectedNode != null && this.taskTree.SelectedNode.Tag is Category)
            {
                toolStripMenuItem3_Click(sender, e);
            }
            else
            {
                MessageBox.Show("请选择一个分类节点");
            }

        }

        private void barButtonItem4_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            navDraft_LinkClicked(sender, null);
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            navEdited_LinkClicked(null, null);
        }

        private void barCheckItem1_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            navPublished_LinkClicked(null, null);
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            new SystemConfigForm().ShowDialog();
        }

        private void 导出规则ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var task = this.taskTree.SelectedNode.Tag as SiteRule;

            if (task != null)
            {

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.FileName = task.Name + ".task";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    CommXmlSerialize.ObjectSerializeXml(task, dialog.FileName);
                    MessageBox.Show("导出成功");
                }
            }
            else
            {
                MessageBox.Show("请选择一个任务");
            }
        }

        private void 导入任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.taskTree.SelectedNode != null && this.taskTree.SelectedNode.Tag is Category)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.FileName = "*.task";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var task = CommXmlSerialize.XmlDeserializeObject<SiteRule>(dialog.FileName);
                        var categoryID = (this.taskTree.SelectedNode.Tag as Category).ID;
                        task.CategoryID = categoryID;
                        task.SiteRuleId = 0;
                        CacheObject.RuleManager.AddSite(task);
                        var index = GetImageIndex(task.IconImage);
                        TreeNode leaf = new TreeNode(task.Name, index, index);
                        leaf.Tag = task;
                        this.CurrentCategoryNode.Nodes.Add(leaf);
                    }
                    catch
                    {
                        MessageBox.Show("导入失败");
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择一个分类节点");
            }

        }

        private void hideContainerBottom_Click(object sender, EventArgs e)
        {

        }

        private void taskRunnerPanel1_Load(object sender, EventArgs e)
        {

        }

        private void dockPanel4_Click(object sender, EventArgs e)
        {

        }

        #region ILog 成员


        private void InsertToRichTextbox(string str, RichTextBox txtbox, Color color)
        {
            try
            {
                lock (this)
                {
                    int i = txtbox.TextLength - 1;
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

        #endregion

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            new EditDefaultSettingForm().ShowDialog();
        }

        SiteRule CopyRule = null;

        private void 复制规则ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyRule = this.taskTree.SelectedNode.Tag as SiteRule;
            MessageBox.Show("复制成功");
        }

        public static T DeepCopy<T>(T obj) where T : class
        {
            object retval;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                //序列化成流
                bf.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                //反序列化成对象
                retval = bf.Deserialize(ms);
                ms.Close();
            }
            return (T)retval;
        }

        private void 粘贴规则ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.taskTree.SelectedNode != null && this.taskTree.SelectedNode.Tag is Category)
            {
                try
                {
                    var task = DeepCopy(CopyRule);
                    var categoryID = (this.taskTree.SelectedNode.Tag as Category).ID;
                    task.CategoryID = categoryID;
                    task.SiteRuleId = 0;
                    task.Name += "复制";
                    CacheObject.RuleManager.AddSite(task);
                    var index = GetImageIndex(task.IconImage);
                    TreeNode leaf = new TreeNode(task.Name, index, index);
                    leaf.Tag = task;
                    this.CurrentCategoryNode.Nodes.Add(leaf);
                }
                catch
                {
                    MessageBox.Show("导入失败");
                }
            }
            else
            {
                MessageBox.Show("请选择一个分类节点");
            }
        }

        /// <summary>
        /// 批量导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            var category = this.taskTree.SelectedNode.Tag as Category;

            if (category != null)
            {

                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "请选择一个文件夹存储规则";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var tasks = CacheObject.Rules.FindAll(r => r.CategoryID == category.ID);
                    foreach (var task in tasks)
                    {
                        CommXmlSerialize.ObjectSerializeXml(task, dialog.SelectedPath + "\\" + task.Name + ".task");
                    }
                    MessageBox.Show("导出成功");
                }
            }
            else
            {
                MessageBox.Show("请选择一个分类节点");
            }
        }

        /// <summary>
        /// 批量导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            var category = this.taskTree.SelectedNode.Tag as Category;

            if (category != null)
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "请选择存储规则的文件夹";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var files = Directory.GetFiles(dialog.SelectedPath, "*.task", SearchOption.AllDirectories);
                    foreach (var file in files)
                    {
                        try
                        {
                            var task = CommXmlSerialize.XmlDeserializeObject<SiteRule>(file);
                            var categoryID = (this.taskTree.SelectedNode.Tag as Category).ID;
                            task.CategoryID = categoryID;
                            task.SiteRuleId = 0;
                            CacheObject.RuleManager.AddSite(task);
                            var index = GetImageIndex(task.IconImage);
                            TreeNode leaf = new TreeNode(task.Name, index, index);
                            leaf.Tag = task;
                            this.CurrentCategoryNode.Nodes.Add(leaf);
                        }
                        catch
                        {
                        }
                    }
                    MessageBox.Show("导入成功");
                }
            }
            else
            {
                MessageBox.Show("请选择一个分类节点");
            }
        }

        private void 编辑分组ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            编辑分组ToolStripMenuItem_Click(sender, e);
        }
    }
}