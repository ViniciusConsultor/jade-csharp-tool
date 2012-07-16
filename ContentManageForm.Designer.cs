namespace HFBBS
{
    partial class ContentManageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("草稿箱");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("待发箱");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("已发箱");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("任务列表");
            this.naviBar1 = new Guifreaks.NavigationBar.NaviBar(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新建分组ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑分组ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除分组ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.新建任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.运行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.naviBand1 = new Guifreaks.NavigationBar.NaviBand(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.naviBand2 = new Guifreaks.NavigationBar.NaviBand(this.components);
            this.taskTree = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.naviBar1)).BeginInit();
            this.naviBar1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.naviBand1.ClientArea.SuspendLayout();
            this.naviBand1.SuspendLayout();
            this.naviBand2.ClientArea.SuspendLayout();
            this.naviBand2.SuspendLayout();
            this.SuspendLayout();
            // 
            // naviBar1
            // 
            this.naviBar1.ActiveBand = this.naviBand1;
            this.naviBar1.Controls.Add(this.naviBand1);
            this.naviBar1.Controls.Add(this.naviBand2);
            this.naviBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.naviBar1.LayoutStyle = Guifreaks.NavigationBar.NaviLayoutStyle.Office2007Black;
            this.naviBar1.Location = new System.Drawing.Point(0, 0);
            this.naviBar1.Name = "naviBar1";
            this.naviBar1.ShowCollapseButton = false;
            this.naviBar1.Size = new System.Drawing.Size(296, 430);
            this.naviBar1.TabIndex = 2;
            this.naviBar1.Text = "naviBar1";
            this.naviBar1.VisibleLargeButtons = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建分组ToolStripMenuItem,
            this.编辑分组ToolStripMenuItem,
            this.删除分组ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripSeparator1,
            this.新建任务ToolStripMenuItem,
            this.编辑任务ToolStripMenuItem,
            this.删除任务ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.运行ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 220);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 新建分组ToolStripMenuItem
            // 
            this.新建分组ToolStripMenuItem.Name = "新建分组ToolStripMenuItem";
            this.新建分组ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.新建分组ToolStripMenuItem.Text = "新建分组";
            this.新建分组ToolStripMenuItem.Click += new System.EventHandler(this.新建分组ToolStripMenuItem_Click);
            // 
            // 编辑分组ToolStripMenuItem
            // 
            this.编辑分组ToolStripMenuItem.Name = "编辑分组ToolStripMenuItem";
            this.编辑分组ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.编辑分组ToolStripMenuItem.Text = "编辑分组";
            this.编辑分组ToolStripMenuItem.Click += new System.EventHandler(this.编辑分组ToolStripMenuItem_Click);
            // 
            // 删除分组ToolStripMenuItem
            // 
            this.删除分组ToolStripMenuItem.Name = "删除分组ToolStripMenuItem";
            this.删除分组ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除分组ToolStripMenuItem.Text = "删除分组";
            this.删除分组ToolStripMenuItem.Click += new System.EventHandler(this.删除分组ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(145, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem3.Text = "向导新建任务";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem4.Text = "向导编辑任务";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // 新建任务ToolStripMenuItem
            // 
            this.新建任务ToolStripMenuItem.Name = "新建任务ToolStripMenuItem";
            this.新建任务ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.新建任务ToolStripMenuItem.Text = "高级新建任务";
            this.新建任务ToolStripMenuItem.Click += new System.EventHandler(this.新建任务ToolStripMenuItem_Click);
            // 
            // 编辑任务ToolStripMenuItem
            // 
            this.编辑任务ToolStripMenuItem.Name = "编辑任务ToolStripMenuItem";
            this.编辑任务ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.编辑任务ToolStripMenuItem.Text = "高级编辑任务";
            this.编辑任务ToolStripMenuItem.Click += new System.EventHandler(this.编辑任务ToolStripMenuItem_Click);
            // 
            // 删除任务ToolStripMenuItem
            // 
            this.删除任务ToolStripMenuItem.Name = "删除任务ToolStripMenuItem";
            this.删除任务ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除任务ToolStripMenuItem.Text = "删除任务";
            this.删除任务ToolStripMenuItem.Click += new System.EventHandler(this.删除任务ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(145, 6);
            // 
            // 运行ToolStripMenuItem
            // 
            this.运行ToolStripMenuItem.Name = "运行ToolStripMenuItem";
            this.运行ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.运行ToolStripMenuItem.Text = "运行";
            this.运行ToolStripMenuItem.Click += new System.EventHandler(this.运行ToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // naviBand1
            // 
            // 
            // naviBand1.ClientArea
            // 
            this.naviBand1.ClientArea.Controls.Add(this.treeView1);
            this.naviBand1.ClientArea.Location = new System.Drawing.Point(0, 0);
            this.naviBand1.ClientArea.Name = "ClientArea";
            this.naviBand1.ClientArea.Size = new System.Drawing.Size(294, 299);
            this.naviBand1.ClientArea.TabIndex = 0;
            this.naviBand1.LargeImage = global::HFBBS.Properties.Resources.page;
            this.naviBand1.LayoutStyle = Guifreaks.NavigationBar.NaviLayoutStyle.Office2007Black;
            this.naviBand1.Location = new System.Drawing.Point(1, 27);
            this.naviBand1.Name = "naviBand1";
            this.naviBand1.Size = new System.Drawing.Size(294, 299);
            this.naviBand1.SmallImage = global::HFBBS.Properties.Resources.logo按钮图标5;
            this.naviBand1.TabIndex = 3;
            this.naviBand1.Text = "内容管理";
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("SimSun", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList2;
            this.treeView1.Indent = 20;
            this.treeView1.ItemHeight = 30;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node0";
            treeNode1.Text = "草稿箱";
            treeNode2.ImageIndex = 2;
            treeNode2.Name = "root";
            treeNode2.Text = "待发箱";
            treeNode3.ImageIndex = 1;
            treeNode3.Name = "Node1";
            treeNode3.Text = "已发箱";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowLines = false;
            this.treeView1.Size = new System.Drawing.Size(294, 299);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // naviBand2
            // 
            // 
            // naviBand2.ClientArea
            // 
            this.naviBand2.ClientArea.Controls.Add(this.taskTree);
            this.naviBand2.ClientArea.Location = new System.Drawing.Point(0, 0);
            this.naviBand2.ClientArea.Name = "ClientArea";
            this.naviBand2.ClientArea.Size = new System.Drawing.Size(294, 299);
            this.naviBand2.ClientArea.TabIndex = 0;
            this.naviBand2.ClientArea.Text = "任务管理";
            this.naviBand2.LargeImage = global::HFBBS.Properties.Resources.scheduled_tasks__1_;
            this.naviBand2.LayoutStyle = Guifreaks.NavigationBar.NaviLayoutStyle.Office2007Black;
            this.naviBand2.Location = new System.Drawing.Point(1, 27);
            this.naviBand2.Name = "naviBand2";
            this.naviBand2.Size = new System.Drawing.Size(294, 299);
            this.naviBand2.TabIndex = 5;
            this.naviBand2.Text = "任务管理";
            // 
            // taskTree
            // 
            this.taskTree.ContextMenuStrip = this.contextMenuStrip1;
            this.taskTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskTree.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.taskTree.ImageIndex = 0;
            this.taskTree.ImageList = this.imageList1;
            this.taskTree.Location = new System.Drawing.Point(0, 0);
            this.taskTree.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.taskTree.Name = "taskTree";
            treeNode4.Name = "root";
            treeNode4.Text = "任务列表";
            this.taskTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.taskTree.SelectedImageIndex = 0;
            this.taskTree.ShowRootLines = false;
            this.taskTree.Size = new System.Drawing.Size(294, 299);
            this.taskTree.TabIndex = 1;
            this.taskTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.taskTree_AfterSelect);
            this.taskTree.DoubleClick += new System.EventHandler(this.tasktree_DoubleClick);
            // 
            // ContentManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 430);
            this.Controls.Add(this.naviBar1);
            this.Name = "ContentManageForm";
            this.TabText = "功能导航";
            this.Text = "ContentManageForm";
            this.Load += new System.EventHandler(this.ContentManageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.naviBar1)).EndInit();
            this.naviBar1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.naviBand1.ClientArea.ResumeLayout(false);
            this.naviBand1.ResumeLayout(false);
            this.naviBand2.ClientArea.ResumeLayout(false);
            this.naviBand2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private Guifreaks.NavigationBar.NaviBar naviBar1;
        private Guifreaks.NavigationBar.NaviBand naviBand1;
        private Guifreaks.NavigationBar.NaviBand naviBand2;
        private System.Windows.Forms.TreeView taskTree;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新建分组ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑分组ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除分组ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 新建任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 运行ToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
    }
}