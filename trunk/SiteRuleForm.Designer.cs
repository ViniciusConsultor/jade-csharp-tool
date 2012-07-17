namespace Jade
{
    partial class SiteRuleForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("任务列表");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SiteRuleForm));
            this.taskTree = new System.Windows.Forms.TreeView();
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
            this.iglIcons = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // taskTree
            // 
            this.taskTree.ContextMenuStrip = this.contextMenuStrip1;
            this.taskTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskTree.ImageIndex = 0;
            this.taskTree.ImageList = this.iglIcons;
            this.taskTree.Location = new System.Drawing.Point(0, 0);
            this.taskTree.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.taskTree.Name = "taskTree";
            treeNode1.Name = "root";
            treeNode1.Text = "任务列表";
            this.taskTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.taskTree.SelectedImageIndex = 0;
            this.taskTree.Size = new System.Drawing.Size(284, 262);
            this.taskTree.TabIndex = 0;
            this.taskTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.taskTree.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
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
            // iglIcons
            // 
            this.iglIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iglIcons.ImageStream")));
            this.iglIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.iglIcons.Images.SetKeyName(0, "Root.ico");
            this.iglIcons.Images.SetKeyName(1, "Site.ico");
            // 
            // SiteRuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.taskTree);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SiteRuleForm";
            this.TabText = "任务列表";
            this.Text = "任务列表";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView taskTree;
        private System.Windows.Forms.ImageList iglIcons;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新建分组ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑分组ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除分组ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 新建任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 运行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;


    }
}