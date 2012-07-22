namespace Jade
{
    partial class DraftBoxForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DraftBoxForm));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new Jade.DataGridViewEx.DataGridViewEx();
            this.Select = new Jade.DataGridViewEx.ColumnEx.DataGridViewCheckBoxColumnEx();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsPublish = new System.Windows.Forms.DataGridViewImageColumn();
            this.IsEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.editor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Summary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DownloadTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewLinkColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.pager1 = new Jade.Pager();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLinkColumn1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(393, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(237, 20);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtKeyword);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 47);
            this.panel1.TabIndex = 2;
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(70, 15);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(243, 21);
            this.txtKeyword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "关键字：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "所属任务：";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 26);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.编辑ToolStripMenuItem.Text = "编辑";
            this.编辑ToolStripMenuItem.Click += new System.EventHandler(this.编辑ToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(0, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(969, 335);
            this.panel2.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.Title,
            this.IsPublish,
            this.IsEdit,
            this.editor,
            this.Content,
            this.Summary,
            this.Source,
            this.DownloadTime,
            this.Url});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 60, 3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(969, 335);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            // 
            // Select
            // 
            this.Select.HeaderText = "选择";
            this.Select.Name = "Select";
            this.Select.ReadOnly = true;
            this.Select.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Select.Width = 40;
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "标题";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Title.Width = 35;
            // 
            // IsPublish
            // 
            this.IsPublish.HeaderText = "已签发";
            this.IsPublish.Name = "IsPublish";
            this.IsPublish.ReadOnly = true;
            this.IsPublish.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsPublish.Width = 50;
            // 
            // IsEdit
            // 
            this.IsEdit.HeaderText = "已编辑";
            this.IsEdit.Name = "IsEdit";
            this.IsEdit.ReadOnly = true;
            this.IsEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsEdit.Width = 50;
            // 
            // editor
            // 
            this.editor.DataPropertyName = "EditorUserName";
            this.editor.HeaderText = "编辑";
            this.editor.Name = "editor";
            this.editor.ReadOnly = true;
            this.editor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Content
            // 
            this.Content.DataPropertyName = "Content";
            this.Content.HeaderText = "内容";
            this.Content.Name = "Content";
            this.Content.ReadOnly = true;
            this.Content.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Content.Width = 200;
            // 
            // Summary
            // 
            this.Summary.DataPropertyName = "Summary";
            this.Summary.HeaderText = "摘要";
            this.Summary.Name = "Summary";
            this.Summary.ReadOnly = true;
            this.Summary.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Source
            // 
            this.Source.DataPropertyName = "Source";
            this.Source.HeaderText = "来源";
            this.Source.Name = "Source";
            this.Source.ReadOnly = true;
            this.Source.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DownloadTime
            // 
            this.DownloadTime.DataPropertyName = "DownloadTime";
            this.DownloadTime.HeaderText = "采集时间";
            this.DownloadTime.Name = "DownloadTime";
            this.DownloadTime.ReadOnly = true;
            this.DownloadTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Url
            // 
            this.Url.DataPropertyName = "Url";
            this.Url.HeaderText = "网址";
            this.Url.Name = "Url";
            this.Url.ReadOnly = true;
            this.Url.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Url.Width = 200;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 47);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(969, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::Jade.Properties.Resources.no;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton1.Text = "删除";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton2.Text = "发布";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // pager1
            // 
            this.pager1.CurrentPageIndex = 0;
            this.pager1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pager1.Location = new System.Drawing.Point(0, 416);
            this.pager1.Name = "pager1";
            this.pager1.PageCount = 0;
            this.pager1.PageSize = 20;
            this.pager1.Size = new System.Drawing.Size(969, 30);
            this.pager1.TabIndex = 4;
            this.pager1.TotalCount = 0;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Title";
            this.dataGridViewTextBoxColumn1.HeaderText = "标题";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "已签发";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "已编辑";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "EditorUserName";
            this.dataGridViewTextBoxColumn2.HeaderText = "编辑";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Content";
            this.dataGridViewTextBoxColumn3.HeaderText = "内容";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Summary";
            this.dataGridViewTextBoxColumn4.HeaderText = "摘要";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Source";
            this.dataGridViewTextBoxColumn5.HeaderText = "来源";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "DownloadTime";
            this.dataGridViewTextBoxColumn6.HeaderText = "采集时间";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewLinkColumn1
            // 
            this.dataGridViewLinkColumn1.DataPropertyName = "Url";
            this.dataGridViewLinkColumn1.HeaderText = "网址";
            this.dataGridViewLinkColumn1.Name = "dataGridViewLinkColumn1";
            this.dataGridViewLinkColumn1.ReadOnly = true;
            this.dataGridViewLinkColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLinkColumn1.Width = 200;
            // 
            // DraftBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pager1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "DraftBoxForm";
            this.Size = new System.Drawing.Size(969, 446);
            this.Load += new System.EventHandler(this.DraftBoxForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private DataGridViewEx.DataGridViewEx dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private Pager pager1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn1;
        private DataGridViewEx.ColumnEx.DataGridViewCheckBoxColumnEx Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewImageColumn IsPublish;
        private System.Windows.Forms.DataGridViewImageColumn IsEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn editor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Content;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn DownloadTime;
        private System.Windows.Forms.DataGridViewLinkColumn Url;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}