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
    public partial class ContentManageForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public ContentManageForm()
        {
            InitializeComponent();
        }

        private void ContentManageForm_Load(object sender, EventArgs e)
        {
            this.treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            BindList();
        }

        private void BindList()
        {
            if (this.treeView1.SelectedNode != null)
            {
                switch (this.treeView1.SelectedNode.Text)
                {
                    case "草稿箱":
                        CacheObject.DraftForm.IsPublished = false;
                        CacheObject.DraftForm.Activate();
                        break;
                    case "已发箱":
                        CacheObject.DraftForm.IsPublished = true;
                        CacheObject.DraftForm.Activate();
                        break;
                }
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            BindList();
        }
    }
}
