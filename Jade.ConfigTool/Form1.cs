using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using Jade.Model;
using Jade.ConfigTool.Properties;


namespace Jade.ConfigTool
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            this.imageList1.Images.Add(Resources.scheduled_tasks__1_);
            this.imageList1.Images.Add(Resources.sites);

            this.taskTree.ImageList = this.imageList1;
            var categories = CacheObject.Categories.Where(c => c.ParentCategoryID == 0);
            var baseNode = this.taskTree.Nodes[0];
            foreach (var category in categories)
            {
                InitTree(baseNode, category);
            }
            this.taskTree.ExpandAll();

            this.baseWebBrowser1.Navigate("http://192.168.75.31");
        }
        Dictionary<string, int> ImageIndexDic = new Dictionary<string, int>();
        ImageList imageList1 = new ImageList();

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

        private void InitTree(TreeNode baseNode, Category category)
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
                toolStripMenuItem3.Enabled = true;
            }
            else
            {
                CurrentCategory = null;
                this.编辑分组ToolStripMenuItem.Enabled = false;
                this.删除分组ToolStripMenuItem.Enabled = false;
                toolStripMenuItem3.Enabled = false;
            }

            if (this.taskTree.SelectedNode != null && this.taskTree.SelectedNode.Tag is SiteRule)
            {
                this.删除任务ToolStripMenuItem.Enabled = true;
                toolStripMenuItem4.Enabled = true;
            }
            else
            {
                toolStripMenuItem4.Enabled = false;
                this.删除任务ToolStripMenuItem.Enabled = false;
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


        private void tasktree_DoubleClick(object sender, EventArgs e)
        {
            if (this.taskTree.SelectedNode != null && this.taskTree.SelectedNode.Tag is SiteRule)
            {
                toolStripMenuItem4_Click(sender, e);
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


        private TreeNode CurrentCategoryNode;
        private Category CurrentCategory;

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

    }
}