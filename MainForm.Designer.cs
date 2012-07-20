namespace Jade
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockingMenuItem1 = new DevExpress.XtraBars.BarDockingMenuItem();
            this.ribbonMiniToolbar1 = new DevExpress.XtraBars.Ribbon.RibbonMiniToolbar(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.dockPanel3 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navTask = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.taskTree = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navEdited = new DevExpress.XtraNavBar.NavBarItem();
            this.navDraft = new DevExpress.XtraNavBar.NavBarItem();
            this.navPublished = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.tabbedView2 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.tabbedView3 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            this.dockPanel3.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.navBarControl1.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            this.dockPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonDropDownControl = this.applicationMenu1;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barButtonItem1,
            this.barDockingMenuItem1,
            this.barButtonItem2,
            this.barButtonItem3});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 7;
            this.ribbon.MiniToolbars.Add(this.ribbonMiniToolbar1);
            this.ribbon.Name = "ribbon";
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItem3);
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(743, 148);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ItemLinks.Add(this.barButtonItem1);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barDockingMenuItem1
            // 
            this.barDockingMenuItem1.Caption = "窗口管理";
            this.barDockingMenuItem1.Id = 4;
            this.barDockingMenuItem1.Name = "barDockingMenuItem1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "管理";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barDockingMenuItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "管理";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 469);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(743, 32);
            // 
            // dockManager1
            // 
            this.dockManager1.Controller = this.barAndDockingController1;
            this.dockManager1.Form = this;
            this.dockManager1.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel3});
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1,
            this.dockPanel2});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.PaintStyleName = "Skin";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dockPanel3
            // 
            this.dockPanel3.Controls.Add(this.dockPanel3_Container);
            this.dockPanel3.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dockPanel3.ID = new System.Guid("3558c613-38a1-4199-8ed8-171c34fdca21");
            this.dockPanel3.Location = new System.Drawing.Point(-32768, -32768);
            this.dockPanel3.Name = "dockPanel3";
            this.dockPanel3.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel3.SavedIndex = 2;
            this.dockPanel3.Size = new System.Drawing.Size(200, 200);
            this.dockPanel3.Text = "dockPanel3";
            this.dockPanel3.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Location = new System.Drawing.Point(4, 25);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(192, 171);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("cf3e2d3d-11be-49f5-8be7-f2ab0ff0285d");
            this.dockPanel1.Image = global::Jade.Properties.Resources.scheduled_tasks__1_;
            this.dockPanel1.Location = new System.Drawing.Point(0, 148);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.Size = new System.Drawing.Size(200, 321);
            this.dockPanel1.Text = "导航";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.navBarControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 25);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(192, 292);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navTask;
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer1);
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navTask,
            this.navBarGroup2,
            this.navBarGroup1});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navDraft,
            this.navEdited,
            this.navPublished});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 192;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new System.Drawing.Size(192, 292);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navTask
            // 
            this.navTask.Caption = "任务管理";
            this.navTask.ControlContainer = this.navBarGroupControlContainer1;
            this.navTask.Expanded = true;
            this.navTask.GroupClientHeight = 80;
            this.navTask.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navTask.LargeImage = global::Jade.Properties.Resources.scheduled_tasks__1_;
            this.navTask.Name = "navTask";
            this.navTask.SmallImage = global::Jade.Properties.Resources.scheduled_tasks__1_;
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Controls.Add(this.taskTree);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(192, 113);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // taskTree
            // 
            this.taskTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.taskTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskTree.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.taskTree.ImageIndex = 0;
            this.taskTree.ImageList = this.imageList1;
            this.taskTree.Location = new System.Drawing.Point(0, 0);
            this.taskTree.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.taskTree.Name = "taskTree";
            treeNode1.Name = "root";
            treeNode1.Text = "任务列表";
            this.taskTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.taskTree.SelectedImageIndex = 0;
            this.taskTree.ShowRootLines = false;
            this.taskTree.Size = new System.Drawing.Size(192, 113);
            this.taskTree.TabIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "内容管理";
            this.navBarGroup2.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navEdited),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navDraft),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navPublished)});
            this.navBarGroup2.LargeImage = global::Jade.Properties.Resources.page;
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // navEdited
            // 
            this.navEdited.Caption = "已编辑";
            this.navEdited.LargeImage = global::Jade.Properties.Resources.daiqianfapingtai;
            this.navEdited.Name = "navEdited";
            this.navEdited.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navEdited_LinkClicked);
            // 
            // navDraft
            // 
            this.navDraft.Caption = "草稿箱";
            this.navDraft.LargeImage = global::Jade.Properties.Resources.bianjipingtai;
            this.navDraft.Name = "navDraft";
            this.navDraft.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navDraft_LinkClicked);
            // 
            // navPublished
            // 
            this.navPublished.Caption = "已发布";
            this.navPublished.LargeImage = global::Jade.Properties.Resources.yiqianfapingtai;
            this.navPublished.Name = "navPublished";
            this.navPublished.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navPublished_LinkClicked);
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "服务器内容";
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navDraft),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navEdited),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navPublished)});
            this.navBarGroup1.LargeImage = global::Jade.Properties.Resources.page;
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarGroup1.TopVisibleLinkIndex = 1;
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanel2.ID = new System.Guid("ddb177ea-4214-48f7-a7e7-9bf6cf38e536");
            this.dockPanel2.Location = new System.Drawing.Point(200, 269);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel2.Size = new System.Drawing.Size(543, 200);
            this.dockPanel2.Text = "dockPanel2";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 25);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(535, 171);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // documentManager1
            // 
            this.documentManager1.BarAndDockingController = this.barAndDockingController1;
            this.documentManager1.ContainerControl = this;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1,
            this.tabbedView2,
            this.tabbedView3});
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "navBarItem2";
            this.navBarItem2.Name = "navBarItem2";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.ItemLinks.Add(this.barButtonItem2);
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this.ribbon;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "退出";
            this.barButtonItem2.Id = 5;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 6;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 501);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            this.dockPanel3.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.navBarControl1.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            this.dockPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel3;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView2;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarDockingMenuItem barDockingMenuItem1;
        private DevExpress.XtraBars.Ribbon.RibbonMiniToolbar ribbonMiniToolbar1;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navTask;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraNavBar.NavBarItem navDraft;
        private DevExpress.XtraNavBar.NavBarItem navEdited;
        private DevExpress.XtraNavBar.NavBarItem navPublished;
        private System.Windows.Forms.TreeView taskTree;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
    }
}