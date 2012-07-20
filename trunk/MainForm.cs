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

namespace Jade
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BaseDocument d;
        public MainForm()
        {
            InitializeComponent();
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

            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
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
            RichEditControl control = new RichEditControl();
            control.Name = s;
            control.Text = s;
            control.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            control.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            control.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            control.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            control.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            tabbedView1.BeginUpdate();
            BaseDocument document = tabbedView1.Controller.AddDocument(control);
            control.Document.Sections[0].Page.Width = 10000;
            document.Form.Text = s;
            tabbedView1.EndUpdate();
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

        private void navDraft_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            MessageBox.Show("草稿箱");
        }

        private void navEdited_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            MessageBox.Show("已编辑");
        }

        private void navPublished_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (d == null || d.Control == null)
            {
                tabbedView1.BeginUpdate();
                WelcomePanel form = new WelcomePanel();
                d = tabbedView1.Controller.AddDocument(form);
                d.Form.Text = "WelcomeForm";
                d.Caption = "WelcomeForm";
                tabbedView1.EndUpdate();
            }

            if (d != null)
            {
                tabbedView1.Controller.Activate(d);
            }
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
            }
            else
            {
                CurrentCategory = null;
                this.编辑分组ToolStripMenuItem.Enabled = false;
                this.删除分组ToolStripMenuItem.Enabled = false;
                this.新建任务ToolStripMenuItem.Enabled = false;
                toolStripMenuItem3.Enabled = false;
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
                EditSiteRule();
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
            var runnerForm = new TaskRunForm(task);

            tabbedView1.BeginUpdate();
            var document = tabbedView1.Controller.AddDocument(runnerForm);
            document.Form.Text = task.Name;
            document.Caption = task.Name + "[运行中]";
            tabbedView1.EndUpdate();

            //CacheObject.MainForm.AddDock(runnerForm, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
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
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var editForm = new TaskWizardForm(this.taskTree.SelectedNode.Tag as SiteRule);
            if (editForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var siteRule = editForm.CurrentSiteRule;
                CacheObject.RuleManager.Update(siteRule);
                var index = GetImageIndex(siteRule.IconImage);
                this.taskTree.SelectedNode.Tag = siteRule;
                this.taskTree.SelectedNode.Text = siteRule.Name;
                this.taskTree.SelectedNode.ImageIndex = GetImageIndex(siteRule.IconImage);
                this.taskTree.SelectedNode.SelectedImageIndex = GetImageIndex(siteRule.IconImage);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

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
    }
}