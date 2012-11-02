namespace Jade
{
    partial class RelatedNews
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
            this.urlSettingBox = new DevExpress.XtraEditors.GroupControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.txtKeyword = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.urlSettingBox)).BeginInit();
            this.urlSettingBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // urlSettingBox
            // 
            this.urlSettingBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.urlSettingBox.Controls.Add(this.label3);
            this.urlSettingBox.Controls.Add(this.textBox1);
            this.urlSettingBox.Controls.Add(this.label1);
            this.urlSettingBox.Controls.Add(this.simpleButton4);
            this.urlSettingBox.Controls.Add(this.txtKeyword);
            this.urlSettingBox.Controls.Add(this.label2);
            this.urlSettingBox.Controls.Add(this.simpleButton2);
            this.urlSettingBox.Controls.Add(this.simpleButton1);
            this.urlSettingBox.Location = new System.Drawing.Point(0, 0);
            this.urlSettingBox.Name = "urlSettingBox";
            this.urlSettingBox.Size = new System.Drawing.Size(874, 115);
            this.urlSettingBox.TabIndex = 96;
            this.urlSettingBox.Text = "搜索相关新闻";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(58, 53);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(804, 57);
            this.textBox1.TabIndex = 110;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 109;
            this.label1.Text = "已选择：";
            // 
            // simpleButton4
            // 
            this.simpleButton4.Location = new System.Drawing.Point(351, 25);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(101, 22);
            this.simpleButton4.TabIndex = 108;
            this.simpleButton4.Text = "搜索";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.EditValue = "";
            this.txtKeyword.Location = new System.Drawing.Point(58, 27);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(271, 20);
            this.txtKeyword.TabIndex = 101;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(9, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 100;
            this.label2.Text = "关键字：";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(367, 232);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 93;
            this.simpleButton2.Text = "取消";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(286, 232);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 92;
            this.simpleButton1.Text = "确定";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.checkedListBox1);
            this.groupControl1.Location = new System.Drawing.Point(0, 121);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(874, 254);
            this.groupControl1.TabIndex = 110;
            this.groupControl1.Text = "相关新闻";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(2, 22);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(870, 230);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // simpleButton5
            // 
            this.simpleButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton5.Location = new System.Drawing.Point(770, 393);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(75, 23);
            this.simpleButton5.TabIndex = 93;
            this.simpleButton5.Text = "取消";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // simpleButton6
            // 
            this.simpleButton6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton6.Location = new System.Drawing.Point(689, 393);
            this.simpleButton6.Name = "simpleButton6";
            this.simpleButton6.Size = new System.Drawing.Size(75, 23);
            this.simpleButton6.TabIndex = 92;
            this.simpleButton6.Text = "确定";
            this.simpleButton6.Click += new System.EventHandler(this.simpleButton6_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(458, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 111;
            this.label3.Text = "正在搜索中....";
            // 
            // RelatedNews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 428);
            this.Controls.Add(this.simpleButton5);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.simpleButton6);
            this.Controls.Add(this.urlSettingBox);
            this.Name = "RelatedNews";
            this.Text = "设置相关新闻";
            this.Load += new System.EventHandler(this.RelatedNews_Load);
            ((System.ComponentModel.ISupportInitialize)(this.urlSettingBox)).EndInit();
            this.urlSettingBox.ResumeLayout(false);
            this.urlSettingBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl urlSettingBox;
        private DevExpress.XtraEditors.TextEdit txtKeyword;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraEditors.SimpleButton simpleButton6;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
    }
}