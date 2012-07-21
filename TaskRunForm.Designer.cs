namespace Jade
{
    partial class TaskRunForm
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
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.lblStep = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProcess = new System.Windows.Forms.Label();
            this.treeListView1 = new BrightIdeasSoftware.TreeListView();
            this.olvColumnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnUrl = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnProgress = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnSpeed = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(14, 14);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(943, 324);
            this.txtLog.TabIndex = 1;
            this.txtLog.Text = "";
            // 
            // lblStep
            // 
            this.lblStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStep.AutoSize = true;
            this.lblStep.Location = new System.Drawing.Point(14, 346);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(55, 14);
            this.lblStep.TabIndex = 2;
            this.lblStep.Text = "采集内容";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar1.Location = new System.Drawing.Point(84, 341);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(502, 27);
            this.progressBar1.TabIndex = 3;
            // 
            // lblProcess
            // 
            this.lblProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProcess.AutoSize = true;
            this.lblProcess.Location = new System.Drawing.Point(594, 346);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(36, 14);
            this.lblProcess.TabIndex = 4;
            this.lblProcess.Text = "(0/0)";
            // 
            // treeListView1
            // 
            this.treeListView1.AllColumns.Add(this.olvColumnName);
            this.treeListView1.AllColumns.Add(this.olvColumnUrl);
            this.treeListView1.AllColumns.Add(this.olvColumnProgress);
            this.treeListView1.AllColumns.Add(this.olvColumnSpeed);
            this.treeListView1.AllColumns.Add(this.olvColumn1);
            this.treeListView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeListView1.CheckBoxes = false;
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnName,
            this.olvColumnUrl,
            this.olvColumnProgress,
            this.olvColumnSpeed,
            this.olvColumn1});
            this.treeListView1.Location = new System.Drawing.Point(14, 374);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.OwnerDraw = true;
            this.treeListView1.ShowGroups = false;
            this.treeListView1.Size = new System.Drawing.Size(943, 121);
            this.treeListView1.TabIndex = 13;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.View = System.Windows.Forms.View.Details;
            this.treeListView1.VirtualMode = true;
            // 
            // olvColumnName
            // 
            this.olvColumnName.AspectName = "FileName";
            this.olvColumnName.Text = "文件名";
            this.olvColumnName.Width = 200;
            // 
            // olvColumnUrl
            // 
            this.olvColumnUrl.AspectName = "Url";
            this.olvColumnUrl.Text = "Url";
            this.olvColumnUrl.Width = 200;
            // 
            // olvColumnProgress
            // 
            this.olvColumnProgress.AspectName = "Progress";
            this.olvColumnProgress.Text = "进度";
            this.olvColumnProgress.Width = 150;
            // 
            // olvColumnSpeed
            // 
            this.olvColumnSpeed.AspectName = "Speed";
            this.olvColumnSpeed.AspectToStringFormat = "";
            this.olvColumnSpeed.Text = "下载速度";
            this.olvColumnSpeed.Width = 150;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Status";
            this.olvColumn1.Text = "状态";
            this.olvColumn1.Width = 100;
            // 
            // TaskRunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListView1);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblStep);
            this.Controls.Add(this.txtLog);
            this.Name = "TaskRunForm";
            this.Size = new System.Drawing.Size(972, 499);
            this.Load += new System.EventHandler(this.TaskRunForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Label lblStep;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProcess;
        private BrightIdeasSoftware.TreeListView treeListView1;
        private BrightIdeasSoftware.OLVColumn olvColumnName;
        private BrightIdeasSoftware.OLVColumn olvColumnUrl;
        private BrightIdeasSoftware.OLVColumn olvColumnProgress;
        private BrightIdeasSoftware.OLVColumn olvColumnSpeed;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
    }
}