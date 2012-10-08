namespace Jade
{
    partial class TaskRunnerPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.runningTaskCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.taskName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UrlCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ContentCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.开始采集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停止采集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.runningTaskCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.DataSource = this.runningTaskCollectionBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(618, 357);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // runningTaskCollectionBindingSource
            // 
            this.runningTaskCollectionBindingSource.DataSource = typeof(Jade.RunningTaskCollection);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.taskName,
            this.status,
            this.UrlCount,
            this.ContentCount,
            this.StartTime,
            this.EndTime});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = " ";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // taskName
            // 
            this.taskName.Caption = "任务名称";
            this.taskName.FieldName = "TaskName";
            this.taskName.Name = "taskName";
            this.taskName.OptionsColumn.AllowEdit = false;
            this.taskName.Visible = true;
            this.taskName.VisibleIndex = 0;
            // 
            // status
            // 
            this.status.Caption = "状态";
            this.status.FieldName = "Status";
            this.status.Name = "status";
            this.status.OptionsColumn.AllowEdit = false;
            this.status.OptionsFilter.AllowFilter = false;
            this.status.Visible = true;
            this.status.VisibleIndex = 1;
            // 
            // UrlCount
            // 
            this.UrlCount.Caption = "网址";
            this.UrlCount.FieldName = "UrlCount";
            this.UrlCount.Name = "UrlCount";
            this.UrlCount.OptionsColumn.AllowEdit = false;
            this.UrlCount.Visible = true;
            this.UrlCount.VisibleIndex = 2;
            // 
            // ContentCount
            // 
            this.ContentCount.Caption = "内容";
            this.ContentCount.FieldName = "ContentCount";
            this.ContentCount.Name = "ContentCount";
            this.ContentCount.OptionsColumn.AllowEdit = false;
            this.ContentCount.Visible = true;
            this.ContentCount.VisibleIndex = 3;
            // 
            // StartTime
            // 
            this.StartTime.Caption = "开始时间";
            this.StartTime.FieldName = "StartTime";
            this.StartTime.Name = "StartTime";
            this.StartTime.OptionsColumn.AllowEdit = false;
            this.StartTime.Visible = true;
            this.StartTime.VisibleIndex = 4;
            // 
            // EndTime
            // 
            this.EndTime.Caption = "结束时间";
            this.EndTime.FieldName = "EndTime";
            this.EndTime.Name = "EndTime";
            this.EndTime.OptionsColumn.AllowEdit = false;
            this.EndTime.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.EndTime.Visible = true;
            this.EndTime.VisibleIndex = 5;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始采集ToolStripMenuItem,
            this.停止采集ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // 开始采集ToolStripMenuItem
            // 
            this.开始采集ToolStripMenuItem.Name = "开始采集ToolStripMenuItem";
            this.开始采集ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.开始采集ToolStripMenuItem.Text = "开始采集";
            this.开始采集ToolStripMenuItem.Click += new System.EventHandler(this.开始采集ToolStripMenuItem_Click);
            // 
            // 停止采集ToolStripMenuItem
            // 
            this.停止采集ToolStripMenuItem.Name = "停止采集ToolStripMenuItem";
            this.停止采集ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.停止采集ToolStripMenuItem.Text = "停止采集";
            this.停止采集ToolStripMenuItem.Click += new System.EventHandler(this.停止采集ToolStripMenuItem_Click);
            // 
            // TaskRunnerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "TaskRunnerPanel";
            this.Size = new System.Drawing.Size(618, 357);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.runningTaskCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn taskName;
        private DevExpress.XtraGrid.Columns.GridColumn status;
        private System.Windows.Forms.BindingSource runningTaskCollectionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn UrlCount;
        private DevExpress.XtraGrid.Columns.GridColumn ContentCount;
        private DevExpress.XtraGrid.Columns.GridColumn StartTime;
        private DevExpress.XtraGrid.Columns.GridColumn EndTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 开始采集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停止采集ToolStripMenuItem;
    }
}
