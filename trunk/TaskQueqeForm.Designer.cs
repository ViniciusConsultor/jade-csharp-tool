namespace Jade
{
    partial class TaskQueqeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskQueqeForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UrlCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContentCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.开始采集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停止采集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaskName,
            this.Status,
            this.UrlCount,
            this.ContentCount,
            this.StartTime,
            this.EndTime});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(755, 281);
            this.dataGridView1.TabIndex = 0;
            // 
            // TaskName
            // 
            this.TaskName.DataPropertyName = "TaskName";
            this.TaskName.HeaderText = "任务名称";
            this.TaskName.Name = "TaskName";
            this.TaskName.Width = 150;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "状态";
            this.Status.Name = "Status";
            // 
            // UrlCount
            // 
            this.UrlCount.DataPropertyName = "UrlCount";
            this.UrlCount.HeaderText = "网址数目";
            this.UrlCount.Name = "UrlCount";
            this.UrlCount.Width = 120;
            // 
            // ContentCount
            // 
            this.ContentCount.DataPropertyName = "ContentCount";
            this.ContentCount.HeaderText = "内容数目";
            this.ContentCount.Name = "ContentCount";
            this.ContentCount.Width = 120;
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "StartTime";
            this.StartTime.HeaderText = "开始时间";
            this.StartTime.Name = "StartTime";
            this.StartTime.Width = 120;
            // 
            // EndTime
            // 
            this.EndTime.DataPropertyName = "EndTime";
            this.EndTime.HeaderText = "结束时间";
            this.EndTime.Name = "EndTime";
            this.EndTime.Width = 120;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始采集ToolStripMenuItem,
            this.停止采集ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
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
            // TaskQueqeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 281);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TaskQueqeForm";
            this.TabText = "任务队列";
            this.Text = "任务队列";
            this.DockStateChanged += new System.EventHandler(this.TaskQueqeForm_DockStateChanged);
            this.Load += new System.EventHandler(this.TaskQueqeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn UrlCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContentCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 开始采集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停止采集ToolStripMenuItem;
    }
}