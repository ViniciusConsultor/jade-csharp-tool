namespace Jade
{
    partial class UrlSettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrlSettingForm));
            this.lblUrlInclude = new System.Windows.Forms.Label();
            this.lblUrlExclude = new System.Windows.Forms.Label();
            this.urlSettingBox = new DevExpress.XtraEditors.GroupControl();
            this.tbxUrlInclude = new DevExpress.XtraEditors.TextEdit();
            this.tbxUrlExclude = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.lbxUrls = new System.Windows.Forms.ListBox();
            this.startUrlmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看代码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.urlSettingBox)).BeginInit();
            this.urlSettingBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxUrlInclude.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxUrlExclude.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.startUrlmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUrlInclude
            // 
            this.lblUrlInclude.AutoSize = true;
            this.lblUrlInclude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUrlInclude.Location = new System.Drawing.Point(18, 33);
            this.lblUrlInclude.Name = "lblUrlInclude";
            this.lblUrlInclude.Size = new System.Drawing.Size(58, 13);
            this.lblUrlInclude.TabIndex = 88;
            this.lblUrlInclude.Text = "必须包含:";
            // 
            // lblUrlExclude
            // 
            this.lblUrlExclude.AutoSize = true;
            this.lblUrlExclude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUrlExclude.Location = new System.Drawing.Point(18, 67);
            this.lblUrlExclude.Name = "lblUrlExclude";
            this.lblUrlExclude.Size = new System.Drawing.Size(58, 13);
            this.lblUrlExclude.TabIndex = 89;
            this.lblUrlExclude.Text = "不得包含:";
            // 
            // urlSettingBox
            // 
            this.urlSettingBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.urlSettingBox.Controls.Add(this.tbxUrlInclude);
            this.urlSettingBox.Controls.Add(this.tbxUrlExclude);
            this.urlSettingBox.Controls.Add(this.lblUrlExclude);
            this.urlSettingBox.Controls.Add(this.lblUrlInclude);
            this.urlSettingBox.Location = new System.Drawing.Point(1, 2);
            this.urlSettingBox.Name = "urlSettingBox";
            this.urlSettingBox.Size = new System.Drawing.Size(469, 117);
            this.urlSettingBox.TabIndex = 92;
            this.urlSettingBox.Text = "内容页地址高级设置";
            // 
            // tbxUrlInclude
            // 
            this.tbxUrlInclude.Location = new System.Drawing.Point(88, 28);
            this.tbxUrlInclude.Name = "tbxUrlInclude";
            this.tbxUrlInclude.Size = new System.Drawing.Size(274, 20);
            this.tbxUrlInclude.TabIndex = 95;
            // 
            // tbxUrlExclude
            // 
            this.tbxUrlExclude.Location = new System.Drawing.Point(88, 67);
            this.tbxUrlExclude.Name = "tbxUrlExclude";
            this.tbxUrlExclude.Size = new System.Drawing.Size(274, 20);
            this.tbxUrlExclude.TabIndex = 94;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton3.Location = new System.Drawing.Point(303, 297);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(82, 23);
            this.simpleButton3.TabIndex = 93;
            this.simpleButton3.Text = "确定";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton4.Location = new System.Drawing.Point(388, 297);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(82, 23);
            this.simpleButton4.TabIndex = 94;
            this.simpleButton4.Text = "取消";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.CaptionImage = global::Jade.Properties.Resources._025;
            this.groupControl1.ContentImageAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.groupControl1.Controls.Add(this.btnAdd);
            this.groupControl1.Controls.Add(this.lbxUrls);
            this.groupControl1.Location = new System.Drawing.Point(1, 125);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(469, 154);
            this.groupControl1.TabIndex = 96;
            this.groupControl1.Text = "自定义内容页";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(6, 29);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(82, 23);
            this.btnAdd.TabIndex = 97;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbxUrls
            // 
            this.lbxUrls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxUrls.ContextMenuStrip = this.startUrlmenu;
            this.lbxUrls.FormattingEnabled = true;
            this.lbxUrls.ItemHeight = 14;
            this.lbxUrls.Location = new System.Drawing.Point(5, 58);
            this.lbxUrls.Name = "lbxUrls";
            this.lbxUrls.Size = new System.Drawing.Size(459, 88);
            this.lbxUrls.TabIndex = 91;
            // 
            // startUrlmenu
            // 
            this.startUrlmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.清空ToolStripMenuItem,
            this.查看代码ToolStripMenuItem});
            this.startUrlmenu.Name = "startUrlmenu";
            this.startUrlmenu.Size = new System.Drawing.Size(119, 92);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.编辑ToolStripMenuItem.Text = "编辑";
            this.编辑ToolStripMenuItem.Click += new System.EventHandler(this.编辑ToolStripMenuItem_Click);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // 查看代码ToolStripMenuItem
            // 
            this.查看代码ToolStripMenuItem.Name = "查看代码ToolStripMenuItem";
            this.查看代码ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.查看代码ToolStripMenuItem.Text = "查看代码";
            this.查看代码ToolStripMenuItem.Click += new System.EventHandler(this.查看代码ToolStripMenuItem_Click);
            // 
            // UrlSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 329);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.urlSettingBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UrlSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "链接地址高级设置";
            ((System.ComponentModel.ISupportInitialize)(this.urlSettingBox)).EndInit();
            this.urlSettingBox.ResumeLayout(false);
            this.urlSettingBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxUrlInclude.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxUrlExclude.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.startUrlmenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUrlInclude;
        private System.Windows.Forms.Label lblUrlExclude;
        private DevExpress.XtraEditors.GroupControl urlSettingBox;
        private DevExpress.XtraEditors.TextEdit tbxUrlInclude;
        private DevExpress.XtraEditors.TextEdit tbxUrlExclude;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.ListBox lbxUrls;
        private System.Windows.Forms.ContextMenuStrip startUrlmenu;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看代码ToolStripMenuItem;
    }
}