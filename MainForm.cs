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

            HtmlEditor editor = new HtmlEditor();
            editor.Html = "page 4";
            tabbedView1.BeginUpdate();
            BaseDocument document = tabbedView1.Controller.AddDocument(editor);
            document.Form.Text = "page4"; ;
            tabbedView1.EndUpdate();
            tabbedView1.BeginUpdate();
            WelcomePanel form = new WelcomePanel();
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

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

    }
}